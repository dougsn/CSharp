using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataNotation.Models
{
    public class Pessoa
    {

        // Incluindo as Data Annotations para validar os campos que serão preenchidos por esses atributos.

        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1,90, ErrorMessage = "Você não é tão velho assim ! Digite um valor válido.")]
        public int Iade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Compare("Email", ErrorMessage = "Os e-mails devem ser iguais.")]
        public string ConfirmarEmail { get; set; }
    }
}
