﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Auth;
using ProjSistemaFinanceiro.Aplicacao.Interfaces.IServicos;
using ProjSistemaFinanceiro.Identity.Configuracao.JWT;
using ProjSistemaFinanceiro.Identity.Entidades;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Identity.Servicos
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUserEntity> _signInManager;
        private readonly UserManager<ApplicationUserEntity> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<ApplicationUserEntity> signInManager,
                               UserManager<ApplicationUserEntity> userManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<AuthCadastroDTOResponse> CadastrarUsuario(AuthCadastroDTO usuarioCadastro)
        {
            var identityUser = new ApplicationUserEntity
            {
                Nome = usuarioCadastro.Nome,
                Sobrenome = usuarioCadastro.Sobrenome,
                NomeCompleto = $"{usuarioCadastro.Nome} {usuarioCadastro.Sobrenome}",
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, "user");
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            }

            var usuarioCadastroResponse = new AuthCadastroDTOResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<AuthLoginDTOResponse> Login(AuthLoginDTO usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
                return await GerarToken(usuarioLogin.Email);
                //return await GerarCredenciais(usuarioLogin.Email);

            var usuarioLoginResponse = new AuthLoginDTOResponse(); // Atentar aqui
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<AuthLoginDTOResponse> GerarToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await ObterClaims(user);

            var dataExpiracao = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthLoginDTOResponse
                (
                    sucesso: true,
                    accessToken: token,
                    refreshToken: dataExpiracao
                );
        }

        public async Task<IList<Claim>> ObterClaims(ApplicationUserEntity user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }

    }
}
