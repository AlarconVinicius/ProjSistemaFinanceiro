using FluentValidation;
using System.Text.RegularExpressions;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.TipoConta;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.Transacao
{
    public class TransacaoAddValidator : AbstractValidator<TransacaoAddDTO>
    {
        public TransacaoAddValidator()
        {
            RuleFor(x => x.BancoId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'BancoId' é inválido.");
            RuleFor(x => x.CategoriaId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'CategoriaId' é inválido.");
            RuleFor(x => x.MetodoPagamentoId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'MetodoPagamentoId' é inválido.");
            RuleFor(x => x.NomeCartaoId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'NomeCartaoId' é inválido.");
            RuleFor(x => x.TipoContaId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'TipoContaId' é inválido.");
            RuleFor(x => x.TipoControleId)
                .NotNull().NotEmpty()
                .Must(x => Guid.TryParse(x.ToString(), out _))
                .WithMessage("O campo 'TipoControleId' é inválido.");

            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");
            RuleFor(dto => dto.Descricao)
                .MaximumLength(300).WithMessage("O campo 'Descricao' deve ter no máximo 300 caracteres.");

            RuleFor(x => x.Valor).GreaterThanOrEqualTo(0).WithMessage("O campo 'Valor' deve ser maior ou igual a zero.");


            RuleFor(x => x.DataCompraStr).NotNull().NotEmpty().Matches(DataRegex).WithMessage("O campo 'DataCompraStr' é inválido. (dd/MM/yyyy)");
            RuleFor(x => x.DataPagamentoStr).NotNull().NotEmpty().Matches(DataRegex).WithMessage("O campo 'DataPagamentoStr' é inválido. (dd/MM/yyyy)");
        }

        private const string DataRegex = @"^((0[1-9]|[12]\d|3[01])\/(0[1-9]|1[0-2])\/\d{4})$";

    }
}