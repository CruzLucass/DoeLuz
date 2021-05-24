using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public class Beneficiario
    {
        public int BeneficiarioID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Preferencia { get; set; }
        public string DataEntrega { get; set; }
        public string Historia { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Doacao> Doacoes { get; set; }
    }
}
