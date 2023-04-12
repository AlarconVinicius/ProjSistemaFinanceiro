using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica
{
    public interface IGenerica<T> where T : class
    {
        Task Adicionar(T objeto);
        Task Atualizar(T objeto);
        Task Deletar(T objeto);
        Task<T> PegarPorId(Guid Id);
        Task<List<T>> ListarTodos();
    }
}
