using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Categoria;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;

namespace ProjSistemaFinanceiro.Apresentacao.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _iCategoriaService;
        private readonly IMapper _mapper;
        private IValidator<CategoriaAddDTO> _addValidator;
        private IValidator<CategoriaUpdDTO> _updValidator;

        public CategoriaController(ICategoriaService iCategoriaService, IMapper mapper, IValidator<CategoriaAddDTO> addValidator, IValidator<CategoriaUpdDTO> updValidator)
        {
            _iCategoriaService = iCategoriaService;
            _mapper = mapper;
            _addValidator = addValidator;
            _updValidator = updValidator;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCategoria(CategoriaAddDTO objeto)
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
            var objetoMapeado = _mapper.Map<CategoriaEntity>(objeto);
            await _iCategoriaService.AdicionarCategoria(objetoMapeado);
            return Ok();
        }

        [HttpGet]
        public async Task<ResultadoPagina<CategoriaViewDTO>> ListarCategorias([FromQuery] Guid? categoriaId = null)
        {
            var objeto = await _iCategoriaService.ListarCategorias(categoriaId);
            var objetoMapeado = _mapper.Map<List<CategoriaViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<CategoriaViewDTO>
            {
                Titulo = "Listagem das categorias.",
                Status = 200,
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarCategoria(CategoriaUpdDTO objeto)
        {
            var validacao = await _updValidator.ValidateAsync(objeto);
            if (!validacao.IsValid)
            {
                var resultado = new ResultadoErroPagina
                {
                    Titulo = "Ocorreu um ou mais erros de validação.",
                    Status = 400,
                };
                validacao.Errors.ForEach(error =>
                {
                    resultado.AdicionarErro(error.PropertyName, error.ErrorMessage);
                });
                return BadRequest(resultado);
            }
            var objetoMapeado = _mapper.Map<CategoriaEntity>(objeto);
            await _iCategoriaService.AtualizarCategoria(objetoMapeado);
            return Ok();
        }
        [HttpDelete]
        public async Task DeletarCategoria([FromQuery] Guid id)
        {
            await _iCategoriaService.DeletarCategoria(id);
        }
    }
}
