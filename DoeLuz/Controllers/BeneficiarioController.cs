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
            .Where(b => b.Status == null)
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

        //lista com status igual a null ou indisponivel para o admin gerenciar
        public ViewResult ListforAdmin(int paginaBeneficiario = 1) => View(new BeneficiarioListViewModel
        {
            Beneficiarios = repositorio.Beneficiarios
            .Where(b => b.Status == null)
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

        //list para o doador ver os benefiiciarios com status igual a disponivel
        public ViewResult ListparaDoador(int paginaBeneficiario = 1) => View(new BeneficiarioListViewModel
        {
            Beneficiarios = repositorio.Beneficiarios
            .Where(b => b.Status == null)
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
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Create(beneficiario);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //mostra os detalhes do cadastro
        public IActionResult Details(int id)
        {
            var beneficiario = repositorio.ObterBeneficiario(id);
            return View(beneficiario);
        }
        public IActionResult DetailsAdmin(int id)
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

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var beneficiario = context.Beneficiarios.Find(id);
            return View(beneficiario);
        }
        [HttpPost]
        public IActionResult EditAdmin(Beneficiario beneficiario)
        {
            repositorio.Edit(beneficiario);
            return RedirectToAction("ListforAdmin");
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
