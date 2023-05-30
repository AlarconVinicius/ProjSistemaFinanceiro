using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjSistemaFinanceiro.Entidade.Entidades
{
    public class TipoControleEntity : BaseEntity
    {
        [Column(Order = 2)]
        public string UsuarioId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(300)]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
