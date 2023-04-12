using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/tipo-controles")]
    [ApiController]
    public class TipoControleController : ControllerBase
    {
        private readonly ITipoControleService _iTipoControleService;

        public TipoControleController(ITipoControleService iTipoControleService)
        {
            _iTipoControleService = iTipoControleService;
        }

        [HttpPost]
        public async Task AdicionarTipoControle(TipoControleEntity objeto)
        {
            //var objetoMapeado = _mapper.Map<TipoControle>(objeto);
            await _iTipoControleService.AdicionarTipoControle(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle([FromQuery] Guid? tipoControleId = null)
        {
            var objeto = await _iTipoControleService.ListarTiposControle(tipoControleId);
            //var objetoMapeado = _mapper.Map<List<TipoControleView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarTipoControle(TipoControleEntity objeto)
        {
            await _iTipoControleService.AtualizarTipoControle(objeto);
        }
        [HttpDelete]
        public async Task DeletarTipoControle(TipoControleEntity objeto)
        {
            await _iTipoControleService.DeletarTipoControle(objeto);
        }
    }
}
