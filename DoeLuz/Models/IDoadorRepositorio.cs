using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IDoadorRepositorio
    { 
        IQueryable<Doador> Doadores { get; }
        public void Create(Doador doador);
        public Doador ObterDoador(int id);
        public void Edit(Doador doador);
        public void Delete(Doador doador);
    }
}
