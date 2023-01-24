using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relacionamento_1x1.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade{ get; set; }
        public int? EnderecoId { get; set; } // Esse atributo é necessário, pois é uma propriedade navegacional
        public Endereco Endereco { get; set; }
    }
}
