using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios
{
    public class TransacaoRepository : GenericoRepository<TransacaoEntity>, ITransacao
    {
        public TransacaoRepository(ContextoBase context) : base(context) {}

        public async Task AdicionarTransacoes(List<TransacaoEntity> listaObjetos)
        {

            //foreach(var objeto in listaObjeto)
            //{
            //    objeto.DataCriacao = DateTime.Now;
            //    objeto.DataAlteracao = DateTime.Now;
            //    await base._context.Transacoes.AddAsync(objeto);
            //    await _context.SaveChangesAsync();
            //}
            base._context.Transacoes?.AddRangeAsync(listaObjetos);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarTransacao(TransacaoEntity objeto)
        {
            var objetoOriginal = await _context.Transacoes.FindAsync(objeto.Id);
            _context.Entry(objetoOriginal).CurrentValues.SetValues(objeto);
            _context.Entry(objetoOriginal).Property("TipoControleId").IsModified = false;
            await _context.SaveChangesAsync();
            ////var objId = await _context.Transacoes.FindAsync(objeto.Id);
            ////objeto.TipoControleId = objId.TipoControleId;
            ////_context.Transacoes.Update(objeto);
            ////await _context.SaveChangesAsync();
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(TransacaoFiltro? filtro = null)
        {
            //string tipoControleIdStr = tipoControleId?.ToString();
            //string tipoContaIdStr = tipoContaId?.ToString();
            //string transacaoIdStr = transacaoId?.ToString();

            var query = base._context.Transacoes
                .Include(t => t.TipoControle)
                .Include(t => t.Categoria)
                .Include(t => t.MetodoPagamento)
                .Include(t => t.NomeCartao)
                .Include(t => t.Banco)
                .Include(t => t.TipoConta)
                .AsQueryable();
            //if (!string.IsNullOrEmpty(tipoControleIdStr))
            //{
            //    query = query.Where(t => t.TipoControleId == tipoControleId);
            //}
            //if (!string.IsNullOrEmpty(tipoContaIdStr))
            //{
            //    query = query.Where(t => t.TipoContaId == tipoContaId);
            //}
            //if (!string.IsNullOrEmpty(transacaoIdStr))
            //{
            //    query = query.Where(t => t.Id == transacaoId);
            //}
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
