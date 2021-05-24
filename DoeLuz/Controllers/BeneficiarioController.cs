using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;

namespace DoeLuz.Controllers
{
    public class BeneficiarioController : Controller
    {
        private IBeneficiarioRepositorio repositorio;
        public  BeneficiarioController(IBeneficiarioRepositorio repo)
        {
            repositorio = repo;
        }
        public ViewResult List() => View(repositorio.Beneficiarios);
    }
}
