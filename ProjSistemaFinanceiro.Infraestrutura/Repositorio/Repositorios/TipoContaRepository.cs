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
    public class TipoContaRepository : GenericoRepository<TipoContaEntity>, ITipoConta
    {
        public TipoContaRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta(string usuarioId, Guid? tipoContaId = null)
        {
            string tipoContaIdStr = tipoContaId?.ToString();

            var query = base._context.TipoContas
                .Where(q => q.UsuarioId == usuarioId)
                .AsQueryable();
            if (!string.IsNullOrEmpty(tipoContaIdStr))
            {
                query = query.Where(c => c.Id == tipoContaId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<TipoContaEntity>
            {
                Resultado = result
            };

        }
    }
}
