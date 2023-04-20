using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.TipoControle;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/tipo-controles")]
    [ApiController]
    public class TipoControleController : ControllerBase
    {
        private readonly ITipoControleService _iTipoControleService;
        private readonly IMapper _mapper;
        private IValidator<TipoControleAddDTO> _addValidator;
        private IValidator<TipoControleUpdDTO> _updValidator;

        public TipoControleController(ITipoControleService iTipoControleService, IMapper mapper, IValidator<TipoControleAddDTO> addValidator, IValidator<TipoControleUpdDTO> updValidator)
        {
            _iTipoControleService = iTipoControleService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarTipoControle(TipoControleAddDTO objeto)
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
            var objetoMapeado = _mapper.Map<TipoControleEntity>(objeto);
            await _iTipoControleService.AdicionarTipoControle(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoControleViewDTO>> ListarTiposControle([FromQuery] Guid? tipoControleId = null)
        {
            var objeto = await _iTipoControleService.ListarTiposControle(tipoControleId);
            var objetoMapeado = _mapper.Map<List<TipoControleViewDTO>>(objeto);
            return new ResultadoPagina<TipoControleViewDTO>
            {
                Titulo = "Listagem dos tipos de controles.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarTipoControle(TipoControleUpdDTO objeto)
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
            var objetoMapeado = _mapper.Map<TipoControleEntity>(objeto);
            await _iTipoControleService.AtualizarTipoControle(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarTipoControle([FromQuery] Guid id)
        {
            await _iTipoControleService.DeletarTipoControle(id);
        }
    }
}
