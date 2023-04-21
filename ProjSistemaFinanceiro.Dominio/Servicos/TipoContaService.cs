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
    public class TipoContaService : ITipoContaService
    {
        private readonly ITipoConta _iTipoConta;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TipoContaService(ITipoConta iTipoConta, IHttpContextAccessor httpContextAccessor)
        {
            _iTipoConta = iTipoConta;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarTipoConta(TipoContaEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoConta.Adicionar(objeto);
        }

        public async Task AtualizarTipoConta(TipoContaEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTipoConta.ObterPorId(objeto.Id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.Nome = objeto.Nome;
            objetoDb.DataAlteracao = DateTime.Now;
            await _iTipoConta.Atualizar(objetoDb);
        }

        public async Task DeletarTipoConta(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTipoConta.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }
            await _iTipoConta.Deletar(id);
        }

        public async Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta(Guid? tipoContaId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iTipoConta.ListarTiposConta(usuarioId, tipoContaId);
        }
    }
}
