using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTOs.TipoConta;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/tipo-contas")]
    [ApiController]
    public class TipoContaController : ControllerBase
    {
        private readonly ITipoContaService _iTipoContaService;
        private readonly IMapper _mapper;
        private IValidator<TipoContaAddDTO> _addValidator;
        private IValidator<TipoContaUpdDTO> _updValidator;

        public TipoContaController(ITipoContaService iTipoContaService, IMapper mapper, IValidator<TipoContaAddDTO> addValidator, IValidator<TipoContaUpdDTO> updValidator)
        {
            _iTipoContaService = iTipoContaService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarTipoConta(TipoContaAddDTO objeto)
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
            var objetoMapeado = _mapper.Map<TipoContaEntity>(objeto);
            await _iTipoContaService.AdicionarTipoConta(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoContaViewDTO>> ListarTiposConta([FromQuery] Guid? tipoContaId = null)
        {
            var objeto = await _iTipoContaService.ListarTiposConta(tipoContaId);
            var objetoMapeado = _mapper.Map<List<TipoContaViewDTO>>(objeto);
            return new ResultadoPagina<TipoContaViewDTO>
            {
                Titulo = "Listagem dos tipos de contas.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarTipoConta(TipoContaUpdDTO objeto)
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
            var objetoMapeado = _mapper.Map<TipoContaEntity>(objeto);
            await _iTipoContaService.AtualizarTipoConta(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarTipoConta([FromQuery] Guid id)
        {
            await _iTipoContaService.DeletarTipoConta(id);
        }
    }
}
