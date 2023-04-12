using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Entidade.Entidades;
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


        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? transacaoId = null)
        {
            string transacaoIdStr = transacaoId?.ToString();

            var query = base._context.Transacoes
                .AsQueryable();
            if (!string.IsNullOrEmpty(transacaoIdStr))
            {
                query = query.Where(c => c.Id == transacaoId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<TransacaoEntity>
            {
                Resultado = result
            };

        }
    }
}
