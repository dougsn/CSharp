using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Relacionamento_1xN.Models
{
    public class Empregado
    {
        public int EmpregadoId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
        [Display(Name = "Profissão")]
        public int TrabalhoId { get; set; } 
        public Trabalho Trabalho { get; set; } // Vinculação de 1 Empregado com 1 Trabalho
    }
}
