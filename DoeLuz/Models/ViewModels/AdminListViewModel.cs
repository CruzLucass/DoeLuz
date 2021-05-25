using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models.ViewModels
{
    public class AdminListViewModel
    {
        public IEnumerable<Admin> Admins { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
