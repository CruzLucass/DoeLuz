using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IBeneficiarioRepositorio
    {
        IQueryable<Beneficiario> Beneficiarios { get; }
    }
}
