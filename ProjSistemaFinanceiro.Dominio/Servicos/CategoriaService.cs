using Microsoft.AspNetCore.Http;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Identity.Servicos;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriaService(ICategoria iCategoria, IHttpContextAccessor httpContextAccessor)
        {
            _iCategoria = iCategoria;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarCategoria(CategoriaEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iCategoria.Adicionar(objeto);
        }

        public async Task AtualizarCategoria(CategoriaEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iCategoria.ObterPorId(objeto.Id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.Nome = objeto.Nome;
            objetoDb.Descricao = objeto.Descricao;
            objetoDb.DataAlteracao = DateTime.Now;

            await _iCategoria.Atualizar(objetoDb);
        }

        public async Task DeletarCategoria(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iCategoria.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }

            await _iCategoria.Deletar(id);
        }

        public async Task<ResultadoPagina<CategoriaEntity>> ListarCategorias(Guid? categoriaId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iCategoria.ListarCategorias(usuarioId, categoriaId);
        }
    }
}
