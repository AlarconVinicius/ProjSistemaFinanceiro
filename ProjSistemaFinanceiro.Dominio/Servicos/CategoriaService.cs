using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Servicos
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoria _iCategoria;

        public CategoriaService(ICategoria iCategoria)
        {
            _iCategoria = iCategoria;
        }
        public async Task AdicionarCategoria(CategoriaEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iCategoria.Adicionar(objeto);
        }

        public async Task AtualizarCategoria(CategoriaEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iCategoria.Atualizar(objeto);
        }

        public async Task DeletarCategoria(Guid id)
        {
            await _iCategoria.Deletar(id);
        }

        public async Task<ResultadoPagina<CategoriaEntity>> ListarCategorias(Guid? categoriaId = null)
        {
            return await _iCategoria.ListarCategorias(categoriaId);
        }
    }
}
