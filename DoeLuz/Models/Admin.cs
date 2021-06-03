using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoeLuz.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        
        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite uma senha de 6 a 8 numeros!")]
        [DataType(DataType.Password, ErrorMessage = "Digite uma senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Digite um email válido.")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um endereço válido!")]
        public string Email { get; set; }

        [Compare("Email",ErrorMessage ="A confirmação não corresponde ao e-mail.")]
        [Display(Name = "Confirmação do email")]
        public string ConfirmaEmail { get; set; }

        [Required(ErrorMessage ="Digite seu endereço completo!")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Nome da Organização")]
        public string NomeOng { get; set; }
        public virtual ICollection<Doacao> Doacoes { get; set; }
    }
}
