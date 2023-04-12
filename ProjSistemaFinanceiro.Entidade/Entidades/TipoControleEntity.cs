using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Entidade.Entidades
{
    public class TipoControleEntity : BaseEntity
    {
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(300)]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
