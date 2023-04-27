using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Identity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IServicos
{
    public interface IUsuarioService
    {
        Task<ApplicationUserEntity> ObterUsuarioLogado();
        Task AtualizarUsuarioLogado(ApplicationUserEntity objeto);
        Task DeletarUsuarioLogado();
    }
}
