using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/nome-cartao")]
    [ApiController]
    public class NomeCartaoController : ControllerBase
    {
        private readonly INomeCartaoService _iNomeCartaoService;

        public NomeCartaoController(INomeCartaoService iNomeCartaoService)
        {
            _iNomeCartaoService = iNomeCartaoService;
        }

        [HttpPost]
        public async Task AdicionarNomeCartao(NomeCartaoEntity objeto)
        {
            //var objetoMapeado = _mapper.Map<NomeCartao>(objeto);
            await _iNomeCartaoService.AdicionarNomeCartao(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<NomeCartaoEntity>> ListarNomeCartoes([FromQuery] Guid? nomeCartaoId = null)
        {
            var objeto = await _iNomeCartaoService.ListarNomeCartoes(nomeCartaoId);
            //var objetoMapeado = _mapper.Map<List<NomeCartaoView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarNomeCartao(NomeCartaoEntity objeto)
        {
            await _iNomeCartaoService.AtualizarNomeCartao(objeto);
        }
        [HttpDelete]
        public async Task DeletarNomeCartao(NomeCartaoEntity objeto)
        {
            await _iNomeCartaoService.DeletarNomeCartao(objeto);
        }
    }
}
