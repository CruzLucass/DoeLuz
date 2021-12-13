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
        //retorna a lista de admins
        public IQueryable<Admin> Admins => context.Admins;

        //cria um novo admin
        public void Create(Admin admin)
        {
            context.Add(admin);
            context.SaveChanges();
        }

        //busca um admin
        public Admin ObterAdmin(int id)
        {
            var admin = context.Admins
                .FirstOrDefault(a => a.AdminID == id);
            return admin;
        }

        //edita o cadastro do admin
        public void Edit(Admin admin)
        {
            context.Entry(admin).State = EntityState.Modified;
            context.SaveChanges();
        }

        //deleta um cadastro de admin
        public void Delete(Admin admin)
        {
            context.Remove(admin);
            context.SaveChanges();
        }
    }
}
