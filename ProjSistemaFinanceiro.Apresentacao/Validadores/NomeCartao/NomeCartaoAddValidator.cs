using FluentValidation;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.NomeCartao;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.NomeCartao
{
    public class NomeCartaoAddValidator : AbstractValidator<NomeCartaoAddDTO>
    {
        public NomeCartaoAddValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");

        }
    }
}
