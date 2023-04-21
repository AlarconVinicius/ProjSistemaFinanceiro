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
    public class MetodoPagamentoService : IMetodoPagamentoService
    {
        private readonly IMetodoPagamento _iMetodoPagamento;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MetodoPagamentoService(IMetodoPagamento iMetodoPagamento, IHttpContextAccessor httpContextAccessor)
        {
            _iMetodoPagamento = iMetodoPagamento;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iMetodoPagamento.Adicionar(objeto);
        }

        public async Task AtualizarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iMetodoPagamento.ObterPorId(objeto.Id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.Nome = objeto.Nome;
            objetoDb.DataAlteracao = DateTime.Now;

            await _iMetodoPagamento.Atualizar(objetoDb);
        }

        public async Task DeletarMetodoPagamento(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iMetodoPagamento.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }

            await _iMetodoPagamento.Deletar(id);
        }

        public async Task<ResultadoPagina<MetodoPagamentoEntity>> ListarMetodosPagamento(Guid? metodoPagamentoId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iMetodoPagamento.ListarMetodosPagamento(usuarioId, metodoPagamentoId);
        }
    }
}
