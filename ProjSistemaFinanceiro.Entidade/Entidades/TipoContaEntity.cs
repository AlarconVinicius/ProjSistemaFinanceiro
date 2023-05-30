using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjSistemaFinanceiro.Entidade.Entidades
{
    public class TipoContaEntity : BaseEntity
    {
        [Column(Order = 2)]
        public string UsuarioId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
