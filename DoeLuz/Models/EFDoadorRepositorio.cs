using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Models
{
    public class EFDoadorRepositorio : IDoadorRepositorio
    {
        private ApplicationDbContext context;
        public EFDoadorRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Doador> Doadores => context.Doadores;
    }
}
