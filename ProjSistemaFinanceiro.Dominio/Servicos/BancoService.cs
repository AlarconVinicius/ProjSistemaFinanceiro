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
    public class BancoService : IBancoService
    {
        private readonly IBanco _iBanco;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BancoService(IBanco iBanco, IHttpContextAccessor httpContextAccessor)
        {
            _iBanco = iBanco;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AdicionarBanco(BancoEntity objeto)
        {
            objeto.UsuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iBanco.Adicionar(objeto);
        }

        public async Task AtualizarBanco(BancoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iBanco.Atualizar(objeto);
        }

        public async Task DeletarBanco(Guid id)
        {
            await _iBanco.Deletar(id);
        }

        public async Task<ResultadoPagina<BancoEntity>> ListarBancos(Guid? bancoId = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iBanco.ListarBancos(usuarioId, bancoId);
        }
    }
}
