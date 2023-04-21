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
    public interface ITipoControle : IGenerica<TipoControleEntity>
    {
        Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle(string usuarioId, Guid? tipoControleId = null);
    }
}
