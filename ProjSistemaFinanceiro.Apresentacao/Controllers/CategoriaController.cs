using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Categoria;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
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

        public CategoriaController(ICategoriaService iCategoriaService, IMapper mapper)
        {
            _iCategoriaService = iCategoriaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarCategoria(CategoriaAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<CategoriaEntity>(objeto);
            await _iCategoriaService.AdicionarCategoria(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<CategoriaViewDTO>> ListarCategorias([FromQuery] Guid? categoriaId = null)
        {
            var objeto = await _iCategoriaService.ListarCategorias(categoriaId);
            var objetoMapeado = _mapper.Map<List<CategoriaViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<CategoriaViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarCategoria(CategoriaUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<CategoriaEntity>(objeto);
            await _iCategoriaService.AtualizarCategoria(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarCategoria([FromQuery] Guid id)
        {
            await _iCategoriaService.DeletarCategoria(id);
        }
    }
}
