using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/tipo-contas")]
    [ApiController]
    public class TipoContaController : ControllerBase
    {
        private readonly ITipoContaService _iTipoContaService;

        public TipoContaController(ITipoContaService iTipoContaService)
        {
            _iTipoContaService = iTipoContaService;
        }

        [HttpPost]
        public async Task AdicionarTipoConta(TipoContaEntity objeto)
        {
            //var objetoMapeado = _mapper.Map<TipoConta>(objeto);
            await _iTipoContaService.AdicionarTipoConta(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta([FromQuery] Guid? tipoContaId = null)
        {
            var objeto = await _iTipoContaService.ListarTiposConta(tipoContaId);
            //var objetoMapeado = _mapper.Map<List<TipoContaView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarTipoConta(TipoContaEntity objeto)
        {
            await _iTipoContaService.AtualizarTipoConta(objeto);
        }
        [HttpDelete]
        public async Task DeletarTipoConta([FromQuery] Guid id)
        {
            await _iTipoContaService.DeletarTipoConta(id);
        }
    }
}
