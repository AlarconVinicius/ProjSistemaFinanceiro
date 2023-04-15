using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.MetodoPagamento;
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
        private readonly IMapper _mapper;

        public MetodoPagamentoController(IMetodoPagamentoService iMetodoPagamentoService, IMapper mapper)
        {
            _iMetodoPagamentoService = iMetodoPagamentoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarMetodoPagamento(MetodoPagamentoAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<MetodoPagamentoEntity>(objeto);
            await _iMetodoPagamentoService.AdicionarMetodoPagamento(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<MetodoPagamentoViewDTO>> ListarMetodosPagamento([FromQuery] Guid? metodoPagamentoId = null)
        {
            var objeto = await _iMetodoPagamentoService.ListarMetodosPagamento(metodoPagamentoId);
            var objetoMapeado = _mapper.Map<List<MetodoPagamentoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<MetodoPagamentoViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarMetodoPagamento(MetodoPagamentoUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<MetodoPagamentoEntity>(objeto);
            await _iMetodoPagamentoService.AtualizarMetodoPagamento(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarMetodoPagamento([FromQuery] Guid id)
        {
            await _iMetodoPagamentoService.DeletarMetodoPagamento(id);
        }
    }
}
