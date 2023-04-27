using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Identity.Entidades;
using ProjSistemaFinanceiro.Identity.Servicos;
using System;
using System.Data.SqlTypes;

namespace ProjSistemaFinanceiro.Dominio.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _iUsuario;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUserEntity> _userManager;

        public UsuarioService(IUsuarioRepository iUsuario, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUserEntity> userManager)
        {
            _iUsuario = iUsuario;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApplicationUserEntity> ObterUsuarioLogado()
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return  await _userManager.FindByIdAsync(usuarioId);
        }
        public async Task AtualizarUsuarioLogado(ApplicationUserEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            if (usuarioId == null)
            {
                throw new Exception("Nenhum Id localizado!");
            }

            var usuario = await _userManager.FindByIdAsync(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            usuario.Nome = objeto.Nome;
            usuario.Sobrenome = objeto.Sobrenome;
            usuario.NomeCompleto = objeto.NomeCompleto;
            usuario.Email = objeto.Email;
            usuario.UserName = objeto.Email;

            await _userManager.UpdateAsync(usuario);
        }

        public async Task DeletarUsuarioLogado()
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            if (usuarioId == null)
            {
                throw new Exception("Nenhum Id localizado!");
            }

            var usuario = await _userManager.FindByIdAsync(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            await _userManager.DeleteAsync(usuario);
        }

    }
}
