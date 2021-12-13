using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models.ViewModels
{
    public class DoadorListViewModel
    {
        public IEnumerable<Doador> Doadores { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
