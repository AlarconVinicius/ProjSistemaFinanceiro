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
    public class MetodoPagamentoRepository : GenericoRepository<MetodoPagamentoEntity>, IMetodoPagamento
    {
        public MetodoPagamentoRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<MetodoPagamentoEntity>> ListarMetodosPagamento(string usuarioId, Guid? metodoPagamentoId = null)
        {
            string metodoPagamentoIdStr = metodoPagamentoId?.ToString();

            var query = base._context.MetodosDePagamentos
                .Where(q => q.UsuarioId == usuarioId)
                .AsQueryable();
            if (!string.IsNullOrEmpty(metodoPagamentoIdStr))
            {
                query = query.Where(c => c.Id == metodoPagamentoId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<MetodoPagamentoEntity>
            {
                Resultado = result
            };

        }
    }
}
