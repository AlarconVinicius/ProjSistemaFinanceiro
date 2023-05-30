using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;

namespace ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios
{
    public class TransacaoRepository : GenericoRepository<TransacaoEntity>, ITransacao
    {
        public TransacaoRepository(ContextoBase context) : base(context) {}

        public async Task AdicionarTransacoes(List<TransacaoEntity> listaObjetos)
        {
            base._context.Transacoes?.AddRangeAsync(listaObjetos);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(string usuarioId, TransacaoFiltro? filtro = null)
        {
            var query = base._context.Transacoes
                .Include(t => t.TipoControle)
                .Include(t => t.Categoria)
                .Include(t => t.MetodoPagamento)
                .Include(t => t.NomeCartao)
                .Include(t => t.Banco)
                .Include(t => t.TipoConta)
                .Where(q => q.UsuarioId == usuarioId)
                .AsQueryable();
            if(filtro != null)
            {
                if (filtro.TipoControleId.HasValue)
                {
                    query = query.Where(t => t.TipoControleId == filtro.TipoControleId);
                }
                if (filtro.TipoContaId.HasValue)
                {
                    query = query.Where(t => t.TipoContaId == filtro.TipoContaId);
                }
                if (filtro.TransacaoId.HasValue)
                {
                    query = query.Where(t => t.Id == filtro.TransacaoId);
                }
            }
            
            var result = await query.OrderByDescending(t => t.DataPagamento).ToListAsync();
            return new ResultadoPagina<TransacaoEntity>
            {
                Resultado = result
            };

        }
    }
}
