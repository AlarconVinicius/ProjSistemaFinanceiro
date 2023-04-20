namespace ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Transacao
{
    public class TransacaoViewDTO
    {
        public Guid Id { get; set; }

        public Guid TipoControleId { get; set; }
        public string TipoControle { get; set; }

        public Guid CategoriaId { get; set; }
        public string Categoria { get; set; }

        public Guid BancoId { get; set; }
        public string Banco { get; set; }

        public Guid TipoContaId { get; set; }
        public string TipoConta { get; set; }

        public Guid MetodoPagamentoId { get; set; }
        public string MetodoPagamento { get; set; }

        public Guid NomeCartaoId { get; set; }
        public string NomeCartao { get; set; }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string Estabelecimento { get; set; }

        public double Valor { get; set; }

        public bool Entrada { get; set; }
        public bool Pago { get; set; }

        public string DataCompra { get; set; }
        public string DataPagamento { get; set; }
        public string DataCriacao { get; set; }
        public string DataAlteracao { get; set; }
    }
}
