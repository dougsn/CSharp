using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDemoMvc.Models {
    public class Filme 
    {
        [Key] // Especificando para o BDD que o ID é a chave primária.
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O título precisa ter entre 3 ou 60 caracteres.")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto.")]
        [Required(ErrorMessage = "O campo data de lançamento é obrigatório.")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Genêro em formato inválido.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres."), Required(ErrorMessage = "O campo Genêro é requerido")]
        public string Genero { get; set; }

        [Range(1,1000, ErrorMessage = "Valor de 1 a 1000")]
        [Required(ErrorMessage = "Preencha o campo valor.")]
        [Column(TypeName = "decimal(18,2)")] // Especificando para o banco de dados o Tipo do Atributo VALOR
        public decimal Valor { get; set; }

        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somento números")]
        [Required(ErrorMessage = "Preencha o campo avaliação.")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
