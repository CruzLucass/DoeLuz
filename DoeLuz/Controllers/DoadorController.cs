using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;
using DoeLuz.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoeLuz.Controllers
{
    public class DoadorController : Controller
    {
        private IDoadorRepositorio repositorio;
        private ApplicationDbContext context;
        public int PageSize = 4;
        public DoadorController(IDoadorRepositorio repo, ApplicationDbContext ctx)
        {
            context = ctx;
            repositorio = repo;
        }
        //gera a lista paginada de doadores
        public ViewResult List(int paginaDoador = 1) => View(new DoadorListViewModel
        {
            Doadores = repositorio.Doadores
            .OrderBy(d => d.DoadorID)
            .Skip((paginaDoador - 1) * PageSize)
            .Take(PageSize),
            PagingInfo =  new PagingInfo
            {
                PaginaAtual = paginaDoador,
                ItensPorPagina = PageSize,
                TotalItens = repositorio.Doadores.Count()
            }
        });

        //view para cadastrar novo doador
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Doador doador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Create(doador);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ConfirmaCadastro()
        {
            return View();
        }
        //View para exibir as informações dos doadores
        public IActionResult Details(int id)
        {
            var doador = repositorio.ObterDoador(id);
            return View(doador);
        }
        public IActionResult DetailsAdmin(int id)
        {
            var doador = repositorio.ObterDoador(id);
            return View(doador);
        }

        //View para editar as informações do doador
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doador = context.Doadores.Find(id);
            return View(doador);
        }
        [HttpPost]
        public IActionResult Edit(Doador doador)
        {
            repositorio.Edit(doador);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var doador = context.Doadores.Find(id);
            return View(doador);
        }
        [HttpPost]
        public IActionResult EditAdmin(Doador doador)
        {
            repositorio.Edit(doador);
            return RedirectToAction("List");
        }

        //view para excluir um cadastro
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doador = repositorio.ObterDoador(id);
            return View(doador);
        }
        [HttpPost]
        public IActionResult Delete(Doador doador)
        {
            repositorio.Delete(doador);
            return RedirectToAction("List");
        }
    }
}
