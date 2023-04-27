using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Usuario;
using ProjSistemaFinanceiro.Apresentacao.Mapeamentos.Usuario;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        private readonly UsuarioMapping _usuarioMapping;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            _usuarioMapping = new UsuarioMapping();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsuarioViewDTO>> ObterUsuarioLogado()
        {
            var objeto = await _usuarioService.ObterUsuarioLogado();
            var objetoMapeado = _usuarioMapping.MapToGetDTO(objeto);
            return Ok(objetoMapeado);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UsuarioViewDTO>> AtualizarUsuarioLogado(UsuarioViewDTO objeto)
        {
            var objetoMapeado = _usuarioMapping.MapToUpdOrDelDTO(objeto);
            await _usuarioService.AtualizarUsuarioLogado(objetoMapeado);
            return Ok(objeto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeletarUsuarioLogado()
        {
            await _usuarioService.DeletarUsuarioLogado();
            return Ok();
        }
    }
}
