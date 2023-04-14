using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public CategoriaController(ICategoriaService iCategoriaService)
        {
            _iCategoriaService = iCategoriaService;
        }

        [HttpPost]
        public async Task AdicionarCategoria(CategoriaEntity objeto)
        {
            //var objetoMapeado = _mapper.Map<Categoria>(objeto);
            await _iCategoriaService.AdicionarCategoria(objeto);
        }

        [HttpGet]
        public async Task<ResultadoPagina<CategoriaEntity>> ListarCategorias([FromQuery] Guid? categoriaId = null)
        {
            var objeto = await _iCategoriaService.ListarCategorias(categoriaId);
            //var objetoMapeado = _mapper.Map<List<CategoriaView>>(objeto);
            return objeto;
        }
        [HttpPut]
        public async Task AtualizarCategoria(CategoriaEntity objeto)
        {
            await _iCategoriaService.AtualizarCategoria(objeto);
        }
        [HttpDelete]
        public async Task DeletarCategoria([FromQuery] Guid id)
        {
            await _iCategoriaService.DeletarCategoria(id);
        }
    }
}
