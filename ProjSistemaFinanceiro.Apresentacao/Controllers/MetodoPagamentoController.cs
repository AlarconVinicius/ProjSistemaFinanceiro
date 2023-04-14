using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/metodo-pagamento")]
    [ApiController]
    public class MetodoPagamentoController : ControllerBase
    {
        private readonly IMetodoPagamentoService _iMetodoPagamentoService;

        public MetodoPagamentoController(IMetodoPagamentoService iMetodoPagamentoService)
        {
            _iMetodoPagamentoService = iMetodoPagamentoService;
        }

        [HttpPost]
        public async Task AdicionarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            await _iMetodoPagamentoService.AdicionarMetodoPagamento(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<MetodoPagamentoEntity>> ListarMetodosPagamento([FromQuery] Guid? metodoPagamentoId = null)
        {
            var objeto = await _iMetodoPagamentoService.ListarMetodosPagamento(metodoPagamentoId);
            //var objetoMapeado = _mapper.Map<List<MetodoPagamentoView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            await _iMetodoPagamentoService.AtualizarMetodoPagamento(objeto);
        }
        [HttpDelete]
        public async Task DeletarMetodoPagamento([FromQuery] Guid id)
        {
            await _iMetodoPagamentoService.DeletarMetodoPagamento(id);
        }
    }
}
