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
    public class TipoControleService : ITipoControleService
    {
        private readonly ITipoControle _iTipoControle;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TipoControleService(ITipoControle iTipoControle, IHttpContextAccessor httpContextAccessor)
        {
            _iTipoControle = iTipoControle;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarTipoControle(TipoControleEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoControle.Adicionar(objeto);
        }

        public async Task AtualizarTipoControle(TipoControleEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTipoControle.ObterPorId(objeto.Id);
            if(objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.Nome = objeto.Nome;
            objetoDb.Descricao = objeto.Descricao;
            objetoDb.DataAlteracao = DateTime.Now;
            await _iTipoControle.Atualizar(objetoDb);
        }

        public async Task DeletarTipoControle(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTipoControle.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }
            await _iTipoControle.Deletar(id);
        }

        public async Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle(Guid? tipoControleId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iTipoControle.ListarTiposControle(usuarioId, tipoControleId);
        }
    }
}
