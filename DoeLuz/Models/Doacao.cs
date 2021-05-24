using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeLuz.Models
{
    public class Doacao
    {

        public int DoacaoID { get; set; }
        public string DataEntrega { get; set; }
        public string Confirma { get; set; }
        public string TipoDoacao { get; set; }
        public string Item { get; set; }
        public string Mensagem { get; set; }
        public int DoadorID { get; set; }
        public int BeneficiarioID { get; set; }
        public int AdminID { get; set; }

        public Admin Admin { get; set; }
        public Doador Doador { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
