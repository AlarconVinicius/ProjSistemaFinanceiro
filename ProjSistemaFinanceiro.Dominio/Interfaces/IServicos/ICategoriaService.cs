using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface ICategoriaService
    {
        Task AdicionarCategoria(CategoriaEntity objeto);
        Task AtualizarCategoria(CategoriaEntity objeto);
        Task DeletarCategoria(CategoriaEntity objeto);
        Task<ResultadoPagina<CategoriaEntity>> ListarCategorias(Guid? categoriaId = null);
    }
}
