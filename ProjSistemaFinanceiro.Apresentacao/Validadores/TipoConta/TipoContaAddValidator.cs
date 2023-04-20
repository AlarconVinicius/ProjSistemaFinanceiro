using FluentValidation;
using ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.TipoConta;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.TipoConta
{
    public class TipoContaAddValidator : AbstractValidator<TipoContaAddDTO>
    {
        public TipoContaAddValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");

        }
    }
}
