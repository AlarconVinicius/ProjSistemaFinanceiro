using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System.Drawing;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _iTransacaoService;
        private readonly IMapper _mapper;

        public TransacaoController(ITransacaoService iTransacaoService, IMapper mapper)
        {
            _iTransacaoService = iTransacaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarTransacoes(List<TransacaoAddDTO> listaObjetos)
        {
            foreach(var objeto in listaObjetos)
            {
                objeto.DataCompra = DateTime.ParseExact(objeto.DataCompraStr, "dd/MM/yyyy", null);
                objeto.DataPagamento = DateTime.ParseExact(objeto.DataPagamentoStr, "dd/MM/yyyy", null);
            }
            var objetoMapeado = _mapper.Map<List<TransacaoEntity>>(listaObjetos);
            await _iTransacaoService.AdicionarTransacoes(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TransacaoViewDTO>> ListarTransacoes([FromQuery] Guid? transacaoId = null)
        {
            var objeto = await _iTransacaoService.ListarTransacoes(transacaoId);
            var objetoMapeado = _mapper.Map<List<TransacaoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<TransacaoViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarTransacao(TransacaoUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TransacaoEntity>(objeto);
            await _iTransacaoService.AtualizarTransacao(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarTransacao(TransacaoViewDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TransacaoEntity>(objeto);
            await _iTransacaoService.DeletarTransacao(objetoMapeado);
        }
    }
}
