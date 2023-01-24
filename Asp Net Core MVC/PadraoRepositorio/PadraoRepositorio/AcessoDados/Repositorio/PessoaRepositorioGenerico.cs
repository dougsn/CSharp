using PadraoRepositorio.AcessoDados.Interface;
using PadraoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepositorio.AcessoDados.Repositorio
{
    public class PessoaRepositorioGenerico : RepositorioGenerico<Pessoas>, IPessoaGenerico
    {
        public PessoaRepositorioGenerico(PessoasDBContext contexto) : base(contexto)
        {
        }
    }
}
