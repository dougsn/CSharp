using PadraoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepositorio.AcessoDados.Interface
{
    public interface IPessoaRepositorio
    {
        IEnumerable<Pessoas> PegarTodos();
        Pessoas PegarPeloId(int id);
        void InserirPessoa(Pessoas pessoas);
        void AtualizarPessoa(Pessoas pessoas);
        void ExcluirPessoa(int id);
        void Salvar();
    }
}
