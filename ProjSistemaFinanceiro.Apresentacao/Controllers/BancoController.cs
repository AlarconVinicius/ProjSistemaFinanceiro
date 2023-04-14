using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
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

        public BancoController(IBancoService iBancoService, IMapper mapper)
        {
            _iBancoService = iBancoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarBanco(BancoAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<BancoEntity>(objeto);
            await _iBancoService.AdicionarBanco(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<BancoViewDTO>> ListarBancos([FromQuery] Guid? bancoId = null)
        {
            var objeto = await _iBancoService.ListarBancos(bancoId);
            var objetoMapeado = _mapper.Map<List<BancoViewDTO>>(objeto.Resultado);
            return new ResultadoPagina<BancoViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarBanco(BancoUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<BancoEntity>(objeto);
            await _iBancoService.AtualizarBanco(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarBanco(BancoUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<BancoEntity>(objeto);
            await _iBancoService.DeletarBanco(objetoMapeado);
        }
    }
}
