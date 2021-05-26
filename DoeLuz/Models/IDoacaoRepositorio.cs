using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IDoacaoRepositorio
    {
        IQueryable<Doacao> Doacoes { get; }
        public void Create(Doacao doacao);
        public Doacao ObterDoacao(int id);
        public void Edit(Doacao doacao);
        public void Delete(Doacao doacao);
    }
}
