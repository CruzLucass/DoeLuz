using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;

namespace DoeLuz.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepositorio repositorio;
        public AdminController(IAdminRepositorio repo)
        {
            repositorio = repo;
        }
        public ViewResult List() => View(repositorio.Admins);
    }
}
