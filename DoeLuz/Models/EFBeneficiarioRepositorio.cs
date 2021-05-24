using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Models
{
    public class EFBeneficiarioRepositorio : IBeneficiarioRepositorio
    {
        private ApplicationDbContext context;
        public EFBeneficiarioRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Beneficiario> Beneficiarios => context.Beneficiarios;
    }
}
