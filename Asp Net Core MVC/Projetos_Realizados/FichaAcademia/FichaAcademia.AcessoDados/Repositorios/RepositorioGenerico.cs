using FichaAcademia.AcessoDados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        private readonly Contexto _contexto;
        
        public RepositorioGenerico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Atualizar(T t)
        {
            _contexto.Set<T>().Update(t);
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var entity = await PegarPeloId(id);
            _contexto.Set<T>().Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task Inserir(T t)
        {
            await _contexto.Set<T>().AddAsync(t);
            await _contexto.SaveChangesAsync();
        }

        public async Task<T> PegarPeloId(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public IQueryable<T> PegarTodos()
        {
            return _contexto.Set<T>();
        }
    }
}
