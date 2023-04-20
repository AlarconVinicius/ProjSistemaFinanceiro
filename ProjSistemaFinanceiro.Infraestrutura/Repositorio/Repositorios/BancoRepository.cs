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
    public class BancoRepository : GenericoRepository<BancoEntity>, IBanco
    {
        public BancoRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<BancoEntity>> ListarBancos(string usuarioId, Guid? bancoId = null)
        {
            string bancoIdStr = bancoId?.ToString();

            var query = base._context.Bancos
                .Where(q => q.UsuarioId == usuarioId)
                .AsQueryable();
            if (!string.IsNullOrEmpty(bancoIdStr))
            {
                query = query.Where(c => c.Id == bancoId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<BancoEntity>
            {
                Resultado = result
            };

        }
    }
}
