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
    public class NomeCartaoService : INomeCartaoService
    {
        private readonly INomeCartao _iNomeCartao;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NomeCartaoService(INomeCartao iNomeCartao, IHttpContextAccessor httpContextAccessor)
        {
            _iNomeCartao = iNomeCartao;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarNomeCartao(NomeCartaoEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iNomeCartao.Adicionar(objeto);
        }

        public async Task AtualizarNomeCartao(NomeCartaoEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iNomeCartao.ObterPorId(objeto.Id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.Nome = objeto.Nome;
            objetoDb.DataAlteracao = DateTime.Now;

            await _iNomeCartao.Atualizar(objetoDb);
        }

        public async Task DeletarNomeCartao(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iNomeCartao.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }
            await _iNomeCartao.Deletar(id);
        }

        public async Task<ResultadoPagina<NomeCartaoEntity>> ListarNomeCartoes(Guid? nomeCartaoId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iNomeCartao.ListarNomeCartoes(usuarioId, nomeCartaoId);
        }
    }
}
