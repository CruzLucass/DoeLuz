using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;

namespace DoeLuz.Controllers
{
    public class DoadorController : Controller
    {
        private IDoadorRepositorio repositorio;
        public DoadorController(IDoadorRepositorio repo)
        {
            repositorio = repo;
        }
        public ViewResult List() => View(repositorio.Doadores);
    }
}
