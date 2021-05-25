using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public interface IAdminRepositorio
    {
        IQueryable<Admin> Admins { get; }
        public void Create(Admin admin);
        public Admin ObterAdmin(int id);
        public void Edit(Admin admin);
        public void Delete(Admin admin);
    }
}
