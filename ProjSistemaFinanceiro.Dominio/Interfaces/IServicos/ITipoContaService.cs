using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface ITipoContaService
    {
        Task AdicionarTipoConta(TipoContaEntity objeto);
        Task AtualizarTipoConta(TipoContaEntity objeto);
        Task DeletarTipoConta(Guid id);
        Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta(Guid? tipoContaId = null);
    }
}
