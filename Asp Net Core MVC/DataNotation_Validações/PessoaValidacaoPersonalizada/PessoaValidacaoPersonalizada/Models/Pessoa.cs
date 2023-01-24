using PessoaValidacaoPersonalizada.Validação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaValidacaoPersonalizada.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        [Adulto]
        public int Idade { get; set; }
    }
}
