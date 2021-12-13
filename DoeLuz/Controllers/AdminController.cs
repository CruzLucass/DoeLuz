using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;
using DoeLuz.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
        private IAdminRepositorio repositorio;
        public int PageSize = 4;
        public AdminController(IAdminRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        //view com a lista de admins
        public ViewResult List(int paginaAdmin = 1)
            => View(new AdminListViewModel
            {
                Admins = repositorio.Admins
                .OrderBy(a => a.AdminID)
                .Skip((paginaAdmin - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    PaginaAtual = paginaAdmin,
                    ItensPorPagina = PageSize,
                    TotalItens = repositorio.Admins.Count()
                }
            });

        //view para adicionar um administrador
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Admin admin)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repositorio.Create(admin);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //view de confirmação
        public IActionResult ConfirmaCadastro()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var admin = repositorio.ObterAdmin(id);
            return View(admin);
        }

        //view para editar um administrador
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var admin = context.Admins.Find(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            repositorio.Edit(admin);
            return RedirectToAction("List");
        }

        //view para excluir um administrador
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var admin = repositorio.ObterAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Delete(Admin admin)
        {
            repositorio.Delete(admin);
            return RedirectToAction("List");
        }
    }
}
