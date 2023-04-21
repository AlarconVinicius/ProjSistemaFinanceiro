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
    public class NomeCartaoRepository : GenericoRepository<NomeCartaoEntity>, INomeCartao
    {
        public NomeCartaoRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<NomeCartaoEntity>> ListarNomeCartoes(string usuarioId, Guid? nomeCartaoId = null)
        {
            string nomeCartaoIdStr = nomeCartaoId?.ToString();

            var query = base._context.NomeCartoes
                .Where(q => q.UsuarioId == usuarioId)
                .AsQueryable();
            if (!string.IsNullOrEmpty(nomeCartaoIdStr))
            {
                query = query.Where(c => c.Id == nomeCartaoId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<NomeCartaoEntity>
            {
                Resultado = result
            };

        }
    }
}
