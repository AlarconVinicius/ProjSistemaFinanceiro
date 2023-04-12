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
    public class TipoControleRepository : GenericoRepository<TipoControleEntity>, ITipoControle
    {
        public TipoControleRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle(Guid? tipoControleId = null)
        {
            string tipoControleIdStr = tipoControleId?.ToString();

            var query = base._context.TipoControles
                .AsQueryable();
            if (!string.IsNullOrEmpty(tipoControleIdStr))
            {
                query = query.Where(c => c.Id == tipoControleId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<TipoControleEntity>
            {
                Resultado = result
            };

        }
    }
}
