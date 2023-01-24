using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaValidacaoRemota.Models
{
    public class Pessoa
    {   // O Remote utiliza o método criado no controller (UsuarioExistenteAsync) para validar o atributo Nome.

        public int PessoaId { get; set; }
        [Remote("UsuarioExisteAsync", "Pessoas")]
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
