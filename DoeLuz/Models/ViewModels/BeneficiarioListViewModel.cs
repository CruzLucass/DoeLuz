using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models.ViewModels
{
    public class BeneficiarioListViewModel
    {
        public IEnumerable<Beneficiario> Beneficiarios { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
