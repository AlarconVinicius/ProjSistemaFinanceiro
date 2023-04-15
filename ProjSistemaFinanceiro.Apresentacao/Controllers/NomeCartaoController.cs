using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.NomeCartao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
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

        public NomeCartaoController(INomeCartaoService iNomeCartaoService, IMapper mapper)
        {
            _iNomeCartaoService = iNomeCartaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AdicionarNomeCartao(NomeCartaoAddDTO objeto)
        {
            var objetoMapeado = _mapper.Map<NomeCartaoEntity>(objeto);
            await _iNomeCartaoService.AdicionarNomeCartao(objetoMapeado);
        }

        [HttpGet]
        public async Task<ResultadoPagina<NomeCartaoViewDTO>> ListarNomeCartoes([FromQuery] Guid? nomeCartaoId = null)
        {
            var objeto = await _iNomeCartaoService.ListarNomeCartoes(nomeCartaoId);
            var objetoMapeado = _mapper.Map<List<NomeCartaoViewDTO>>(objeto);
            return new ResultadoPagina<NomeCartaoViewDTO>
            {
                Resultado = objetoMapeado
            };
        }
        [HttpPut]
        public async Task AtualizarNomeCartao(NomeCartaoUpdDTO objeto)
        {
            var objetoMapeado = _mapper.Map<NomeCartaoEntity>(objeto);
            await _iNomeCartaoService.AtualizarNomeCartao(objetoMapeado);
        }
        [HttpDelete]
        public async Task DeletarNomeCartao([FromQuery] Guid id)
        {
            await _iNomeCartaoService.DeletarNomeCartao(id);
        }
    }
}
