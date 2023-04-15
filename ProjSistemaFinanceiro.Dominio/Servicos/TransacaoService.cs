using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Servicos
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacao _iTransacao;

        public TransacaoService(ITransacao iTransacao)
        {
            _iTransacao = iTransacao;
        }
        public async Task AdicionarTransacoes(List<TransacaoEntity> listaObjetos)
        {
            foreach(var objeto in listaObjetos)
            {
                objeto.DataCriacao = DateTime.Now;
                objeto.DataAlteracao = DateTime.Now;
            }
            //objeto.DataCriacao = DateTime.Now;
            //objeto.DataAlteracao = DateTime.Now;
            await _iTransacao.AdicionarTransacoes(listaObjetos);
        }

        public async Task AtualizarTransacao(TransacaoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iTransacao.AtualizarTransacao(objeto);
        }

        public async Task DeletarTransacao(Guid id)
        {
            await _iTransacao.Deletar(id);
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(TransacaoFiltro? filtro = null)
        {
            return await _iTransacao.ListarTransacoes(filtro);
        }
    }
}
