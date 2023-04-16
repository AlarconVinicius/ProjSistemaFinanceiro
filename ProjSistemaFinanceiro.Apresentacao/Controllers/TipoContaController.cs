using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.TipoConta;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
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

        public TipoContaController(ITipoContaService iTipoContaService, IMapper mapper)
        {
            _iTipoContaService = iTipoContaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarTipoConta(TipoContaAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TipoContaEntity>(objeto);
            await _iTipoContaService.AdicionarTipoConta(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<TipoContaViewDTO>> ListarTiposConta([FromQuery] Guid? tipoContaId = null)
        {
            var objeto = await _iTipoContaService.ListarTiposConta(tipoContaId);
            var objetoMapeado = _mapper.Map<List<TipoContaViewDTO>>(objeto);
            return new ResultadoPagina<TipoContaViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarTipoConta(TipoContaUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<TipoContaEntity>(objeto);
            await _iTipoContaService.AtualizarTipoConta(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarTipoConta([FromQuery] Guid id)
        {
            await _iTipoContaService.DeletarTipoConta(id);
        }
    }
}
