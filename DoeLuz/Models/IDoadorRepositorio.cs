using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IDoadorRepositorio
    { 
        IQueryable<Doador> Doadores { get; }
    }
}
