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
    public class BeneficiarioController : Controller
    {
        private ApplicationDbContext context;
        private IBeneficiarioRepositorio repositorio;

        public int PageSize = 4;
        public  BeneficiarioController(IBeneficiarioRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        //Lista paginada de beneficiarios
        public ViewResult List(int paginaBeneficiario = 1) => View(new BeneficiarioListViewModel
        {
            Beneficiarios = repositorio.Beneficiarios
            .OrderBy(b => b.BeneficiarioID)
            .Skip((paginaBeneficiario - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PaginaAtual = paginaBeneficiario,
                ItensPorPagina = PageSize,
                TotalItens = repositorio.Beneficiarios.Count()
            }
        });

        //lista de beneficiados do mês, que o status é igual a disponivel
        public ViewResult ListStatus(int paginaBeneficiario = 1) => View(new BeneficiarioListViewModel
        {
            Beneficiarios = repositorio.Beneficiarios
            .Where(b => b.Status == "disponivel")
            .OrderBy(b => b.Nome)
            .Skip((paginaBeneficiario - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PaginaAtual = paginaBeneficiario,
                ItensPorPagina = PageSize,
                TotalItens = repositorio.Beneficiarios.Count()
            }
        });


        //Criar novo beneficiario
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Beneficiario beneficiario)
        {
            repositorio.Create(beneficiario);
            return RedirectToAction("List");
        }

        //mostra os detalhes do cadastro
        public IActionResult Details(int id)
        {
            var beneficiario = repositorio.ObterBeneficiario(id);
            return View(beneficiario);
        }

        //permite editar as informacoes do cadastro
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var beneficiario = context.Beneficiarios.Find(id);
            return View(beneficiario);
        }
        [HttpPost]
        public IActionResult Edit(Beneficiario beneficiario)
        {
            repositorio.Edit(beneficiario);
            return RedirectToAction("List");
        }

        public IActionResult ConfirmaCadastro()
        {
            return View();
        }

        //delte o cadastro
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var beneficiario = repositorio.ObterBeneficiario(id);
            return View(beneficiario);
        }
        [HttpPost]
        public IActionResult Delete(Beneficiario beneficiario)
        {
            repositorio.Delete(beneficiario);
            return RedirectToAction("List");
        }
    }
}
