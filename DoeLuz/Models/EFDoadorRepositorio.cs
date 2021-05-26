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
        // retorna a lista de doadores

        //cria um novo doador
        public void Create(Doador doador)
        {
            context.Add(doador);
            context.SaveChanges();
        }

        //busca um novo doador
        public Doador ObterDoador(int id)
        {
            var doador = context.Doadores
                .FirstOrDefault(a => a.DoadorID == id);
            return doador;
        }

        //edita um cadastro de doador
        public void Edit(Doador doador)
        {
            context.Entry(doador).State = EntityState.Modified;
            context.SaveChanges();
        }

        //deleta a cadastro de doador
        public void Delete(Doador doador)
        {
            context.Remove(doador);
            context.SaveChanges();
        }
    }
}
