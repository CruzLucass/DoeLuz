using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string NomeOng { get; set; }
        public virtual ICollection<Doacao> Doacoes { get; set; }
    }
}
