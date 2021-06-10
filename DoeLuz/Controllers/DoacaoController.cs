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
    public class DoacaoController : Controller
    {
        private IDoacaoRepositorio repositorio;
        private ApplicationDbContext context;
        public int PageSize = 4;
        public DoacaoController(IDoacaoRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            context = ctx;
        }

        //retorna lista de doacoes paginada
        public ViewResult List(int paginaDoacao = 1) => View(new DoacaoListViewModel
        {
            Doacoes = repositorio.Doacoes
                .OrderBy(d => d.DoacaoID)
                .Skip((paginaDoacao - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PaginaAtual = paginaDoacao,
                ItensPorPagina = PageSize,
                TotalItens = repositorio.Doacoes.Count()
            }
        });

        //view para cadastrar nova doacao
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.DoadorID = new SelectList(context.Doadores.OrderBy(d => d.Nome), "Nome");
            ViewBag.BeneficiarioID = new SelectList(context.Beneficiarios.OrderBy(b => b.Nome),"Nome");
            ViewBag.AdminID = new SelectList(context.Admins.OrderBy(a => a.Nome), "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult New(Doacao doacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Create(doacao);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    //Aqui o doador vai realizar a doação direta para o beneficiario
        [HttpGet]
        public IActionResult DoacaoDireta(int id)
        {
            var beneficiario = context.Beneficiarios.Find(id);
            ViewBag.DoadorID = new SelectList(context.Doadores.OrderBy(d => d.Nome), "Nome");
            //ViewBag.BeneficiarioID = new SelectList(context.Beneficiarios.OrderBy(b => b.Nome), "Nome");
            ViewBag.AdminID = new SelectList(context.Admins.OrderBy(a => a.Nome), "Nome");
            return View(beneficiario);
        }

        [HttpPost]
        public IActionResult DoacaoDireta(Doacao doacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Create(doacao);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //Aqui o admin vai cadastrar uma doação
        [HttpGet]
        public IActionResult DoarAdmin(int id)
        {
            var beneficiario = context.Beneficiarios.Find(id);
            ViewBag.DoadorID = new SelectList(context.Doadores.OrderBy(d => d.Nome), "Nome");
            //ViewBag.BeneficiarioID = new SelectList(context.Beneficiarios.OrderBy(b => b.Nome), "Nome");
            ViewBag.AdminID = new SelectList(context.Admins.OrderBy(a => a.Nome), "Nome");
            return View(beneficiario);
        }

        [HttpPost]
        public IActionResult DoarAdmin(Doacao doacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Create(doacao);
                    return RedirectToAction("ConfirmaCadastro");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //view para exibir os detalhes da doacao
        public IActionResult Details(int id)
        {
            var doacao = repositorio.ObterDoacao(id);
            return View(doacao);
        }

        public IActionResult ConfirmaCadastro()
        {
            return View();
        }

        public IActionResult ConfirmaCadastroAdmin()
        {
            return View();
        }

        //view para editar as informações da doação
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doacao = context.Doacoes.Find(id);
            ViewBag.DoadorID = new SelectList(context.Doadores
                .OrderBy(d => d.Nome), "Nome");
            ViewBag.BeneficiarioID = new SelectList(context.Beneficiarios
                .OrderBy(b => b.Nome), "Nome");
            ViewBag.AdminID = new SelectList(context.Admins
                .OrderBy(a => a.Nome), "Nome");
            return View(doacao);
        }
        [HttpPost]
        public IActionResult Edit(Doacao doacao)
        {
            repositorio.Edit(doacao);
            return RedirectToAction("List");
        }

        //view para excluir uma doação
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doacao = repositorio.ObterDoacao(id);
            return View(doacao);
        }
        [HttpPost]
        public IActionResult Delete(Doacao doacao)
        {
            repositorio.Delete(doacao);
            return RedirectToAction("List");
        }

    }
}
