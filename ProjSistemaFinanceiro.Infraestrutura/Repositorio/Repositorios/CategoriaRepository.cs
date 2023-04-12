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
    public class CategoriaRepository : GenericoRepository<CategoriaEntity>, ICategoria
    {
        public CategoriaRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<CategoriaEntity>> ListarCategorias(Guid? categoriaId = null)
        {
            string categoriaIdStr = categoriaId?.ToString();

            var query = base._context.Categorias
                .AsQueryable();
            if (!string.IsNullOrEmpty(categoriaIdStr))
            {
                query = query.Where(c => c.Id == categoriaId);
            }
            var result = await query.OrderByDescending(c => c.Nome).ToListAsync();
            return new ResultadoPagina<CategoriaEntity>
            {
                Resultados = result
            };

        }
    }
}
