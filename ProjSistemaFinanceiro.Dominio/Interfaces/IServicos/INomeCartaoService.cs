using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface INomeCartaoService
    {
        Task AdicionarNomeCartao(NomeCartaoEntity objeto);
        Task AtualizarNomeCartao(NomeCartaoEntity objeto);
        Task DeletarNomeCartao(Guid id);
        Task<ResultadoPagina<NomeCartaoEntity>> ListarNomeCartoes(Guid? nomeCartaoId = null);
    }
}
