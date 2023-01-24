using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Interfaces
{
    public interface IRepositorioGenerico<T> where T: class
    {
        IQueryable<T> PegarTodos();
        Task<T> PegarPeloId(int id);
        Task Inserir(T t);
        Task Atualizar(T t);
        Task Excluir(int id);

    }
}
