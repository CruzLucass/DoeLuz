using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Models
{
    public class EFAdminRepositorio :IAdminRepositorio
    {
        private ApplicationDbContext context;
        public EFAdminRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Admin> Admins => context.Admins;
    }
}
