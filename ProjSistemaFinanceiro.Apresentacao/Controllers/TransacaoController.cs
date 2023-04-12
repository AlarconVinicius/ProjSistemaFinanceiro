using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/transacaos")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _iTransacaoService;

        public TransacaoController(ITransacaoService iTransacaoService)
        {
            _iTransacaoService = iTransacaoService;
        }

        [HttpPost]
        public async Task AdicionarTransacao(TransacaoEntity objeto)
        {
            //var objetoMapeado = _mapper.Map<Transacao>(objeto);
            await _iTransacaoService.AdicionarTransacao(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes([FromQuery] Guid? transacaoId = null)
        {
            var objeto = await _iTransacaoService.ListarTransacoes(transacaoId);
            //var objetoMapeado = _mapper.Map<List<TransacaoView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarTransacao(TransacaoEntity objeto)
        {
            await _iTransacaoService.AtualizarTransacao(objeto);
        }
        [HttpDelete]
        public async Task DeletarTransacao(TransacaoEntity objeto)
        {
            await _iTransacaoService.DeletarTransacao(objeto);
        }
    }
}
