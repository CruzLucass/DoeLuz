using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Models
{
    public class EFDoacaoRepositorio : IDoacaoRepositorio
    {
        private ApplicationDbContext context;
        public EFDoacaoRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Doacao> Doacoes => context.Doacoes
            .Include(a => a.Admin)
            .Include(d => d.Doador)
            .Include(b => b.Beneficiario);
    }
}
