using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/bancos")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _iBancoService;
        private readonly IMapper _mapper;
        private IValidator<BancoAddDTO> _addValidator;
        private IValidator<BancoUpdDTO> _updValidator;

        public BancoController(IBancoService iBancoService, IMapper mapper, IValidator<BancoAddDTO> addValidator, IValidator<BancoUpdDTO> updValidator)
        {
            _iBancoService = iBancoService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarBanco(BancoAddDTO objeto)
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
            var objetoMapeado = _mapper.Map<BancoEntity>(objeto);
            await _iBancoService.AdicionarBanco(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<BancoViewDTO>> ListarBancos([FromQuery] Guid? bancoId = null)
        {
            var objeto = await _iBancoService.ListarBancos(bancoId);
            var objetoMapeado = _mapper.Map<List<BancoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<BancoViewDTO>
            {
                Titulo = "Listagem dos bancos.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarBanco(BancoUpdDTO objeto)
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
            var objetoMapeado = _mapper.Map<BancoEntity>(objeto);
            await _iBancoService.AtualizarBanco(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarBanco([FromQuery] Guid id)
        {
            await _iBancoService.DeletarBanco(id);
        }
    }
}
