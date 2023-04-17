using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Categoria;
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
        private IValidator<MetodoPagamentoAddDTO> _addValidator;
        private IValidator<MetodoPagamentoUpdDTO> _updValidator;

        public MetodoPagamentoController(IMetodoPagamentoService iMetodoPagamentoService, IMapper mapper, IValidator<MetodoPagamentoAddDTO> addValidator, IValidator<MetodoPagamentoUpdDTO> updValidator)
        {
            _iMetodoPagamentoService = iMetodoPagamentoService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarMetodoPagamento(MetodoPagamentoAddDTO objeto)
        {
            var validacao = await _addValidator.ValidateAsync(objeto);
            if (!validacao.IsValid)
            {
                var resultado = new ResultadoErroPagina
                {
                    Titulo = "Ocorreu um ou mais erros de validação.",
                    Status = 400,
                    //Erros = result.Errors.Select(e => e.ErrorMessage).ToList()
                };
                validacao.Errors.ForEach(error =>
                {
                    resultado.AdicionarErro(error.PropertyName, error.ErrorMessage);
                });
                return BadRequest(resultado);
            }
            var objetoMapeado = _mapper.Map<MetodoPagamentoEntity>(objeto);
            await _iMetodoPagamentoService.AdicionarMetodoPagamento(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<MetodoPagamentoViewDTO>> ListarMetodosPagamento([FromQuery] Guid? metodoPagamentoId = null)
        {
            var objeto = await _iMetodoPagamentoService.ListarMetodosPagamento(metodoPagamentoId);
            var objetoMapeado = _mapper.Map<List<MetodoPagamentoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<MetodoPagamentoViewDTO>
            {
                Titulo = "Listagem dos métodos de pagamento.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarMetodoPagamento(MetodoPagamentoUpdDTO objeto)
        {
            var validacao = await _updValidator.ValidateAsync(objeto);
            if (!validacao.IsValid)
            {
                var resultado = new ResultadoErroPagina
                {
                    Titulo = "Ocorreu um ou mais erros de validação.",
                    Status = 400,
                    //Erros = result.Errors.Select(e => e.ErrorMessage).ToList()
                };
                validacao.Errors.ForEach(error =>
                {
                    resultado.AdicionarErro(error.PropertyName, error.ErrorMessage);
                });
                return BadRequest(resultado);
            }
            var objetoMapeado = _mapper.Map<MetodoPagamentoEntity>(objeto);
            await _iMetodoPagamentoService.AtualizarMetodoPagamento(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarMetodoPagamento([FromQuery] Guid id)
        {
            await _iMetodoPagamentoService.DeletarMetodoPagamento(id);
        }
    }
}
