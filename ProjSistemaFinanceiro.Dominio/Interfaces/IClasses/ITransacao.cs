using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IClasses
{
    public interface ITransacao : IGenerica<TransacaoEntity>
    {
        Task AdicionarTransacoes(List<TransacaoEntity> listaObjeto);
        Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(string usuarioId, TransacaoFiltro? filtro = null);
    }
}
