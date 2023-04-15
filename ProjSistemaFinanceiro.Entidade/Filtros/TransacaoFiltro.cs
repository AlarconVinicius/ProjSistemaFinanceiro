using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Entidade.Filtros
{
    public class TransacaoFiltro
    {
        public Guid? TipoControleId { get; set; }
        public Guid? TipoContaId { get; set; }
        public Guid? TransacaoId { get; set; }
    }
}
