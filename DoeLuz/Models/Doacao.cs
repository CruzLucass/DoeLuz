using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoeLuz.Models
{
    public class Doacao
    {

        public int DoacaoID { get; set; }

        [Display(Name = "Data de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataEntrega { get; set; }

        public string Confirma { get; set; }
        public string TipoDoacao { get; set; }

        [Required(ErrorMessage = "É obrigatório adicionar pelo menos um item")]
        public string Item { get; set; }
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar um doador")]
        public int DoadorID { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar um beneficiario")]
        public int BeneficiarioID { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar uma ong")]
        public int AdminID { get; set; }

        public Admin Admin { get; set; }
        public Doador Doador { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
