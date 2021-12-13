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
        
        [Required(ErrorMessage ="O nome completo é obrigatório!")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite uma senha de 6 a 8 numeros!")]
        [DataType(DataType.Password, ErrorMessage = "Digite uma senha!")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "A confirmação não corresponde a senha.")]
        [Display(Name = "Confirmação de senha")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

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

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$", ErrorMessage = "Digite o telefone no formato correto (xx) 9xxxx-xxxx! ")]
        public string Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataNascimento { get; set; }

        [Display(Name = "Nome da Organização")]
        public string NomeOng { get; set; }
        public virtual ICollection<Doacao> Doacoes { get; set; }
    }
}
