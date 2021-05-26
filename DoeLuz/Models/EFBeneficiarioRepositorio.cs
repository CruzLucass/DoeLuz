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
        //retorna a lista de beneficiarios
        public IQueryable<Beneficiario> Beneficiarios => context.Beneficiarios;
        
        //cria um novo beneficiario
        public void Create(Beneficiario beneficiario)
        {
            context.Add(beneficiario);
            context.SaveChanges();
        }

        //busca um novo beneficiario
        public Beneficiario ObterBeneficiario(int id)
        {
            var beneficiario = context.Beneficiarios
                .FirstOrDefault(a => a.BeneficiarioID == id);
            return beneficiario;
        }

        //edita um cadastro de beneficiario
        public void Edit(Beneficiario beneficiario)
        {
            context.Entry(beneficiario).State = EntityState.Modified;
            context.SaveChanges();
        }

        //deleta a cadastro de beneficiario
        public void Delete(Beneficiario beneficiario)
        {
            context.Remove(beneficiario);
            context.SaveChanges();
        }
    }
}
