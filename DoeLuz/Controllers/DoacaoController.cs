using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;

namespace DoeLuz.Controllers
{
    public class DoacaoController : Controller
    {
        private IDoacaoRepositorio repositorio;
        public DoacaoController(IDoacaoRepositorio repo)
        {
            repositorio = repo;
        }
        public ViewResult List() => View(repositorio.Doacoes);
    }
}
