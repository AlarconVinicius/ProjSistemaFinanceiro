using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.TipoControle;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
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

        public TipoControleController(ITipoControleService iTipoControleService, IMapper mapper)
        {
            _iTipoControleService = iTipoControleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarTipoControle(TipoControleAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TipoControleEntity>(objeto);
            await _iTipoControleService.AdicionarTipoControle(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoControleViewDTO>> ListarTiposControle([FromQuery] Guid? tipoControleId = null)
        {
            var objeto = await _iTipoControleService.ListarTiposControle(tipoControleId);
            var objetoMapeado = _mapper.Map<List<TipoControleViewDTO>>(objeto);
            return new ResultadoPagina<TipoControleViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarTipoControle(TipoControleUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TipoControleEntity>(objeto);
            await _iTipoControleService.AtualizarTipoControle(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarTipoControle([FromQuery] Guid id)
        {
            await _iTipoControleService.DeletarTipoControle(id);
        }
    }
}
