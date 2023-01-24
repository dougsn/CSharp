using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Use menos caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(13,100,ErrorMessage = "Idade inválido")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(10, 150, ErrorMessage = "Peso inválido")]
        public double Peso { get; set; }

        public int ObjetivoId { get; set; }
        public Objetivo Objetivo { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1,7, ErrorMessage = "Frequência inválida")]
        public int FrequenciaSemanal { get; set; }

        public ICollection<Ficha> Fichas { get; set; }
    }
}
