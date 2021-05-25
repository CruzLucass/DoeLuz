using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoeLuz.Models
{
    public class EFAdminRepositorio :IAdminRepositorio
    {
        public ApplicationDbContext context;
        public EFAdminRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Admin> Admins => context.Admins;
        public void Create(Admin admin)
        {
            context.Add(admin);
            context.SaveChanges();
        }
        public Admin ObterAdmin(int id)
        {
            var admin = context.Admins
                .FirstOrDefault(a => a.AdminID == id);
            return admin;
        }
        public void Edit(Admin admin)
        {
            context.Entry(admin).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Admin admin)
        {
            context.Remove(admin);
            context.SaveChanges();
        }
    }
}
