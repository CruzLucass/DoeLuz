using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;
using DoeLuz.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace DoeLuz.Controllers
{
    public class SessionControler : Controller
    {
        private ApplicationDbContext context;

        public SessionControler(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var acesso = HttpContext.Session.GetString("usuario_session");
            if (acesso != null)
                return View(context);
            else
                return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var confirma = context.Admins.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
            if (confirma != null)
            {
                HttpContext.Session.SetString("usuario_session", confirma.Nome);
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //pagina de apresentação
        public IActionResult Main()
        {
            return View();
        }

        //primeira view do admin, precisa linkar para o controler admin
        public IActionResult Home()
        {
            return View();
        }
    }
}
