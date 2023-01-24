using Microsoft.EntityFrameworkCore;
using PadraoRepositorio.AcessoDados.Interface;
using PadraoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepositorio.AcessoDados.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly PessoasDBContext _contexto;

        public PessoaRepositorio(PessoasDBContext contexto)
        {
            _contexto = contexto;
        }

        public void AtualizarPessoa(Pessoas pessoas)
        {
            _contexto.Entry(pessoas).State = EntityState.Modified;
        }

        public void ExcluirPessoa(int id)
        {
            Pessoas pessoa = PegarPeloId(id);
            _contexto.Pessoas.Remove(pessoa);
        }

        public void InserirPessoa(Pessoas pessoas)
        {
            _contexto.Pessoas.Add(pessoas);
        }

        public Pessoas PegarPeloId(int id)
        {
            return _contexto.Pessoas.Find(id); 
        }

        public IEnumerable<Pessoas> PegarTodos()
        {
            return _contexto.Pessoas.ToList();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
