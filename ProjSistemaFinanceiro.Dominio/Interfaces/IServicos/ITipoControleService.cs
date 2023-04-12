using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface ITipoControleService
    {
        Task AdicionarTipoControle(TipoControleEntity objeto);
        Task AtualizarTipoControle(TipoControleEntity objeto);
        Task DeletarTipoControle(TipoControleEntity objeto);
        Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle(Guid? tipoControleId = null);
    }
}
