using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTOs.NomeCartao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/nome-cartao")]
    [ApiController]
    public class NomeCartaoController : ControllerBase
    {
        private readonly INomeCartaoService _iNomeCartaoService;
        private readonly IMapper _mapper;
        private IValidator<NomeCartaoAddDTO> _addValidator;
        private IValidator<NomeCartaoUpdDTO> _updValidator;

        public NomeCartaoController(INomeCartaoService iNomeCartaoService, IMapper mapper, IValidator<NomeCartaoAddDTO> addValidator, IValidator<NomeCartaoUpdDTO> updValidator)
        {
            _iNomeCartaoService = iNomeCartaoService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarNomeCartao(NomeCartaoAddDTO objeto)
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
            var objetoMapeado = _mapper.Map<NomeCartaoEntity>(objeto);
            await _iNomeCartaoService.AdicionarNomeCartao(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<NomeCartaoViewDTO>> ListarNomeCartoes([FromQuery] Guid? nomeCartaoId = null)
        {
            var objeto = await _iNomeCartaoService.ListarNomeCartoes(nomeCartaoId);
            var objetoMapeado = _mapper.Map<List<NomeCartaoViewDTO>>(objeto);
            return new ResultadoPagina<NomeCartaoViewDTO>
            {
                Titulo = "Listagem dos nomes dos cartões.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarNomeCartao(NomeCartaoUpdDTO objeto)
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
            var objetoMapeado = _mapper.Map<NomeCartaoEntity>(objeto);
            await _iNomeCartaoService.AtualizarNomeCartao(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarNomeCartao([FromQuery] Guid id)
        {
            await _iNomeCartaoService.DeletarNomeCartao(id);
        }
    }
}
