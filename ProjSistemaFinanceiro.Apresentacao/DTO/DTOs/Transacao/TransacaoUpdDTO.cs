using System.Text.Json.Serialization;

namespace ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao
{
    public class TransacaoUpdDTO
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid BancoId { get; set; }
        public Guid TipoContaId { get; set; }
        public Guid MetodoPagamentoId { get; set; }
        public Guid NomeCartaoId { get; set; }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string Estabelecimento { get; set; }

        public double Valor { get; set; }

        public bool Entrada { get; set; }
        public bool Pago { get; set; }

        //public DateTime DataCompraStr { get; set; }
        //public DateTime DataPagamentoStr { get; set; }

        //[JsonIgnore]
        //public DateTime DataCompra { get; set; }
        //[JsonIgnore]
        //public DateTime DataPagamento { get; set; }
    }
}
