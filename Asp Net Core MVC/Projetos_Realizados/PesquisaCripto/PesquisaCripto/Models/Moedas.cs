using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCripto.Models
{
    public class Moedas
    {
        public int MoedasId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        [NotMapped] // Para não mapear a entidade CheckBoxMarcado para o Banco de Dados
        public bool CheckBoxMarcado { get; set; }
    }
}
