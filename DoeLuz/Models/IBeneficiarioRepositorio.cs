using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IBeneficiarioRepositorio
    {
        IQueryable<Beneficiario> Beneficiarios { get; }
        public void Create(Beneficiario beneficiario);
        public Beneficiario ObterBeneficiario(int id);
        public void Edit(Beneficiario beneficiario);
        public void Delete(Beneficiario beneficiario);
    }
}
