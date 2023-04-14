using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface IBancoService
    {
        Task AdicionarBanco(BancoEntity objeto);
        Task AtualizarBanco(BancoEntity objeto);
        Task DeletarBanco(Guid id);
        Task<ResultadoPagina<BancoEntity>> ListarBancos(Guid? bancoId = null);
    }
}
