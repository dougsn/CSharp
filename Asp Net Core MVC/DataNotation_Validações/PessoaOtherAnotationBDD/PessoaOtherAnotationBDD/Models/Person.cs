using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaOthersAnotationsBDD.Models
{
    [Table("Pessoa")]
    public class Person
    {
        [Key]
        [Column("PessoaId", TypeName = "int")]
        [Display(Name = "Seu ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // O ID será gerado pelo usuário
        public int PersonId { get; set; }

        [Column("Nome", TypeName = "ntext")]
        [Display(Name = "Seu Nome")]
        public string Nome { get; set; }
        [Column("CPF", TypeName = "ntext")]
        [Display(Name = "Cadastro de pessoa física")]
        public string CPF { get; set; }
        [Column("Nascimento", TypeName = "date")]
        [Display(Name = "Sua data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] // Formatando a Data, para aparecer com esse "máscara" e também para aparecer com essa configuração no UPDATE
        public DateTime DateOfBirth { get; set; }
        [Column("Idade", TypeName = "int")]
        [Display(Name = "Sua Idade")]
        public int Age { get; set; }
    }
}
