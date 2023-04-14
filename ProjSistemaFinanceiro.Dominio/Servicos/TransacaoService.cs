using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
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
            await _iTransacao.Atualizar(objeto);
        }

        public async Task DeletarTransacao(TransacaoEntity objeto)
        {
            await _iTransacao.Deletar(objeto);
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? tipoControleId = null, Guid? tipoContaId = null, Guid? transacaoId = null)
        {
            return await _iTransacao.ListarTransacoes(tipoControleId, tipoContaId, transacaoId);
        }
    }
}
