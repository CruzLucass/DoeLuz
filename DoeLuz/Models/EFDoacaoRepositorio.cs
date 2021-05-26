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

        //retorna a lista de doacoes
        public IQueryable<Doacao> Doacoes => context.Doacoes
            .Include(a => a.Admin)
            .Include(d => d.Doador)
            .Include(b => b.Beneficiario);


        //cria um novo doacao
        public void Create(Doacao doacao)
        {
            context.Add(doacao);
            context.SaveChanges();
        }

        //busca um novo doacao
        public Doacao ObterDoacao(int id)
        {
            var doacao = context.Doacoes
                .Include(a => a.Admin)
                .Include(d => d.Doador)
                .Include(b => b.Beneficiario)
                .FirstOrDefault(a => a.DoacaoID == id);
            return doacao;
        }

        //edita um cadastro de doacao
        public void Edit(Doacao doacao)
        {
            context.Entry(doacao).State = EntityState.Modified;
            context.SaveChanges();
        }

        //deleta a cadastro de doacao
        public void Delete(Doacao doacao)
        {
            context.Remove(doacao);
            context.SaveChanges();
        }
    }
}
