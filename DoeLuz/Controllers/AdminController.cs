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
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Admin admin)
        {
            repositorio.Create(admin);
            return RedirectToAction("List");
        }
    }
}
