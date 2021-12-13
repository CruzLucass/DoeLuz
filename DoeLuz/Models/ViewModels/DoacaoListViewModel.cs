using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models.ViewModels
{
    public class DoacaoListViewModel
    {
        public IEnumerable<Doacao> Doacoes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
