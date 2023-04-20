using FluentValidation;
using ProjSistemaFinanceiro.Aplicacao.DTOs.MetodoPagamento;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.MetodoPagamento
{
    public class MetodoPagamentoAddValidator : AbstractValidator<MetodoPagamentoAddDTO>
    {
        public MetodoPagamentoAddValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");

        }
    }
}
