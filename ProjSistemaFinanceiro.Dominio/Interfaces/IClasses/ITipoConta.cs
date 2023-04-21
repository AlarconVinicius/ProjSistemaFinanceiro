using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IClasses
{
    public interface ITipoConta : IGenerica<TipoContaEntity>
    {
        Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta(string usuarioId, Guid? bancoId = null);
    }
}
