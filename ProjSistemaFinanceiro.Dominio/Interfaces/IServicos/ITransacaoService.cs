using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface ITransacaoService
    {
        Task AdicionarTransacao(TransacaoEntity objeto);
        Task AtualizarTransacao(TransacaoEntity objeto);
        Task DeletarTransacao(TransacaoEntity objeto);
        Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? transacaoId = null);
    }
}
