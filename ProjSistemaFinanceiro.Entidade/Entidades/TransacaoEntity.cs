using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjSistemaFinanceiro.Entidade.Entidades
{
    public class TransacaoEntity : BaseEntity
    {
        //public TransacaoEntity(string usuarioId, Guid tipoControleId, Guid categoriaId, Guid bancoId, Guid tipoContaId, Guid metodoPagamentoId, Guid nomeCartaoId, string nome, string estabelecimento, double valor, bool entrada, bool pago, DateTime dataCompra, DateTime dataPagamento, string? descricao = "")
        //{
        //    UsuarioId = usuarioId;
        //    TipoControleId = tipoControleId;
        //    CategoriaId = categoriaId;
        //    BancoId = bancoId;
        //    TipoContaId = tipoContaId;
        //    MetodoPagamentoId = metodoPagamentoId;
        //    NomeCartaoId = nomeCartaoId;
        //    Nome = nome;
        //    Descricao = descricao;
        //    Estabelecimento = estabelecimento;
        //    Status = ObterStatus();
        //    Valor = valor;
        //    Entrada = entrada;
        //    Pago = pago;
        //    DataCompra = dataCompra;
        //    DataPagamento = dataPagamento;
        //}

        //public TransacaoEntity(Guid id, string usuarioId, Guid categoriaId, Guid bancoId, Guid tipoContaId, Guid metodoPagamentoId, Guid nomeCartaoId, string nome, string estabelecimento, double valor, bool entrada, bool pago, DateTime dataCompra, DateTime dataPagamento, string? descricao = "")
        //{
        //    Id = id;
        //    UsuarioId = usuarioId;
        //    CategoriaId = categoriaId;
        //    BancoId = bancoId;
        //    TipoContaId = tipoContaId;
        //    MetodoPagamentoId = metodoPagamentoId;
        //    NomeCartaoId = nomeCartaoId;
        //    Nome = nome;
        //    Descricao = descricao;
        //    Estabelecimento = estabelecimento;
        //    Status = ObterStatus();
        //    Valor = valor;
        //    Entrada = entrada;
        //    Pago = pago;
        //    DataCompra = dataCompra;
        //    DataPagamento = dataPagamento;
        //}

        [Column(Order = 2)]
        public string UsuarioId { get; set; }

        [ForeignKey("TipoControle")]
        public Guid TipoControleId { get; set; }
        public virtual TipoControleEntity? TipoControle { get; set; }

        [ForeignKey("Categoria")]
        public Guid CategoriaId { get; set; }
        public virtual CategoriaEntity? Categoria { get; set; }

        [ForeignKey("Banco")]
        public Guid BancoId { get; set; }
        public virtual BancoEntity? Banco { get; set; }


        [ForeignKey("TipoConta")]
        public Guid TipoContaId { get; set; }
        public virtual TipoContaEntity? TipoConta { get; set; }


        [ForeignKey("MetodoPagamento")]
        public Guid MetodoPagamentoId { get; set; }
        public virtual MetodoPagamentoEntity? MetodoPagamento { get; set; }


        [ForeignKey("NomeCartao")]
        public Guid NomeCartaoId { get; set; }
        public virtual NomeCartaoEntity? NomeCartao { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(700)]
        public string? Descricao { get; set; }
        public string Estabelecimento { get; set; }
        public string? Status { get; set; }

        public double Valor { get; set; } = 00.00;

        public bool Entrada { get; set; } = false;
        public bool Pago { get; set; } = false;

        public DateTime DataCompra { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string ObterStatus()
        {
            if (!this.Pago)
            {
                if (this.DataPagamento > DateTime.Today)
                {
                    return "Pendente";
                }
                else
                {
                    return "Vencido";
                }
            }
            else
            {
                return "Pago";
            }
        }
    }
}
