using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relacionamento_NxN.Models
{
    public class EmpregadoTrabalho
    {
        public int EmpregadoId { get; set; }
        public Empregado Empregado { get; set; }

        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }

        public int CargaHoraria { get; set; }

    }
}
