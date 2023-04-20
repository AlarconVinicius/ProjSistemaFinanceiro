using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Usuario;
using ProjSistemaFinanceiro.Aplicacao.Interfaces.IServicos;
using System.Net;
using System.Security.Claims;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IIdentityService _identityService;

        public UsuarioController(IIdentityService identityService) =>
            _identityService = identityService;

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioCadastroDTOResponse>> Cadastrar(UsuarioCadastroDTO usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);
            if (resultado.Sucesso)
                return Ok(resultado);
            else if (resultado.Erros.Count > 0)
            {
                return BadRequest(resultado);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioCadastroDTOResponse>> Login(UsuarioLoginDTO usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.Login(usuarioLogin);
            if (resultado.Sucesso)
                return Ok(resultado);

            return Unauthorized(resultado);
        }

    }
}
