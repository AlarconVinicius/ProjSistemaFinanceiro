using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface IMetodoPagamentoService
    {
        Task AdicionarMetodoPagamento(MetodoPagamentoEntity objeto);
        Task AtualizarMetodoPagamento(MetodoPagamentoEntity objeto);
        Task DeletarMetodoPagamento(Guid id);
        Task<ResultadoPagina<MetodoPagamentoEntity>> ListarMetodosPagamento(Guid? metodoPagamentoId = null);
    }
}
