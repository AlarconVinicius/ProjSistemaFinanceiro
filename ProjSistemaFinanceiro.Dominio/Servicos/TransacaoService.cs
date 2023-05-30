using Microsoft.AspNetCore.Http;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Identity.Servicos;

namespace ProjSistemaFinanceiro.Dominio.Servicos
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacao _iTransacao;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransacaoService(ITransacao iTransacao, IHttpContextAccessor httpContextAccessor)
        {
            _iTransacao = iTransacao;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AdicionarTransacoes(List<TransacaoEntity> listaObjetos)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            foreach (var objeto in listaObjetos)
            {
                objeto.UsuarioId = usuarioId;
                objeto.DataCriacao = DateTime.Now;
                objeto.DataAlteracao = DateTime.Now;
            }
            await _iTransacao.AdicionarTransacoes(listaObjetos);
        }

        public async Task AtualizarTransacao(TransacaoEntity objeto)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTransacao.ObterPorId(objeto.Id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para atualizar este registro.");
            }
            objetoDb.UsuarioId = usuarioId;
            objetoDb.CategoriaId = objeto.CategoriaId;
            objetoDb.BancoId = objeto.BancoId;
            objetoDb.TipoContaId = objeto.TipoContaId;
            objetoDb.MetodoPagamentoId = objeto.MetodoPagamentoId;
            objetoDb.NomeCartaoId = objeto.NomeCartaoId;
            objetoDb.Nome = objeto.Nome;
            objetoDb.Descricao = objeto.Descricao;
            objetoDb.Estabelecimento = objeto.Estabelecimento;
            objetoDb.Valor = objeto.Valor;
            objetoDb.Entrada = objeto.Entrada;
            objetoDb.Pago = objeto.Pago;
            objetoDb.DataCompra = objeto.DataCompra;
            objetoDb.DataPagamento = objeto.DataPagamento;
            objetoDb.DataAlteracao = DateTime.Now;
            await _iTransacao.Atualizar(objetoDb);
        }

        public async Task DeletarTransacao(Guid id)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            var objetoDb = await _iTransacao.ObterPorId(id);
            if (objetoDb.UsuarioId != usuarioId)
            {
                throw new Exception("Você não tem permissão para deletar este registro.");
            }
            await _iTransacao.Deletar(id);
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(TransacaoFiltro? filtro = null)
        {
            var usuarioId = await AutenticacaoHelper.ObterUsuarioId(_httpContextAccessor);
            return await _iTransacao.ListarTransacoes(usuarioId, filtro);
        }
    }
}
