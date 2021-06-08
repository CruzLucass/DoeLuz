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
            //tres variaveis para receber as informação do login, vai verificar qual o tipo do usuário
            var confirmaAdmin = context.Admins.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
            var confirmaDoador = context.Doadores.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
            var confirmaBeneficiario = context.Beneficiarios.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();


            //define o retorno para a view do usuário correto
            if (confirmaAdmin != null)
            {
                HttpContext.Session.SetString("usuario_session", confirmaAdmin.Nome);
                HttpContext.Session.SetInt32("id_session", confirmaAdmin.AdminID);
                return RedirectToAction("Home");
            }
            else if(confirmaDoador != null)
            {
                HttpContext.Session.SetString("usuario_session", confirmaDoador.Nome);
                HttpContext.Session.SetInt32("id_session", confirmaDoador.DoadorID);

                return RedirectToAction("HomeDoador");
            }
            else if (confirmaBeneficiario != null)
            {
                HttpContext.Session.SetString("usuario_session", confirmaBeneficiario.Nome);
                HttpContext.Session.SetInt32("id_session", confirmaBeneficiario.BeneficiarioID);
                return RedirectToAction("HomeBeneficiario");
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

        //view para a tela inicial do doador
        public IActionResult HomeDoador()
        {
            return View();
        }

        //view para a tela inicial do doador
        public IActionResult HomeBeneficiario()
        {
            return View();
        }
    }
}
