using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Transacao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Authorize]
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _iTransacaoService;
        private readonly IMapper _mapper;
        private IValidator<TransacaoAddDTO> _addValidator;
        private IValidator<TransacaoUpdDTO> _updValidator;

        public TransacaoController(ITransacaoService iTransacaoService, IMapper mapper, IValidator<TransacaoAddDTO> addValidator, IValidator<TransacaoUpdDTO> updValidator)
        {
            _iTransacaoService = iTransacaoService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarTransacoes(List<TransacaoAddDTO> listaObjetos)
        {
            
            foreach (var objeto in listaObjetos)
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
                objeto.DataCompra = DateTime.ParseExact(objeto.DataCompraStr, "dd/MM/yyyy", null);
                objeto.DataPagamento = DateTime.ParseExact(objeto.DataPagamentoStr, "dd/MM/yyyy", null);
            }
            var objetoMapeado = _mapper.Map<List<TransacaoEntity>>(listaObjetos);
            await _iTransacaoService.AdicionarTransacoes(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<TransacaoViewDTO>> ListarTransacoes([FromQuery]TransacaoFiltro? filtro = null)
        {
            var objeto = await _iTransacaoService.ListarTransacoes(filtro);
            var objetoMapeado = _mapper.Map<List<TransacaoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<TransacaoViewDTO>
            {
                Titulo = "Listagem das transações.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarTransacao(TransacaoUpdDTO objeto)
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
            objeto.DataCompra = DateTime.ParseExact(objeto.DataCompraStr, "dd/MM/yyyy", null);
            objeto.DataPagamento = DateTime.ParseExact(objeto.DataPagamentoStr, "dd/MM/yyyy", null);
            var objetoMapeado = _mapper.Map<TransacaoEntity>(objeto);
            await _iTransacaoService.AtualizarTransacao(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarTransacao([FromQuery]Guid id)
        {
            await _iTransacaoService.DeletarTransacao(id);
        }
    }
}
