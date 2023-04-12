using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/bancos")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _iBancoService;

        public BancoController(IBancoService iBancoService)
        {
            _iBancoService = iBancoService;
        }

        [HttpPost]
        public async Task AdicionarBanco(BancoEntity objeto)
        {
            await _iBancoService.AdicionarBanco(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<BancoEntity>> ListarBancos([FromQuery] Guid? bancoId = null)
        {
            var objeto = await _iBancoService.ListarBancos(bancoId);
            //var objetoMapeado = _mapper.Map<List<BancoView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarBanco(BancoEntity objeto)
        {
            await _iBancoService.AtualizarBanco(objeto);
        }
        [HttpDelete]
        public async Task DeletarBanco(BancoEntity objeto)
        {
            await _iBancoService.DeletarBanco(objeto);
        }
    }
}
