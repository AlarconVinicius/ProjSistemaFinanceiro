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
    public class MetodoPagamentoService : IMetodoPagamentoService
    {
        private readonly IMetodoPagamento _iMetodoPagamento;

        public MetodoPagamentoService(IMetodoPagamento iMetodoPagamento)
        {
            _iMetodoPagamento = iMetodoPagamento;
        }
        public async Task AdicionarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iMetodoPagamento.Adicionar(objeto);
        }

        public async Task AtualizarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iMetodoPagamento.Atualizar(objeto);
        }

        public async Task DeletarMetodoPagamento(MetodoPagamentoEntity objeto)
        {
            await _iMetodoPagamento.Deletar(objeto);
        }

        public async Task<ResultadoPagina<MetodoPagamentoEntity>> ListarMetodosPagamento(Guid? metodoPagamentoId = null)
        {
            return await _iMetodoPagamento.ListarMetodosPagamento(metodoPagamentoId);
        }
    }
}
