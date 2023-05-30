using FluentValidation;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Banco;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.Banco
{
    public class BancoAddValidator : AbstractValidator<BancoAddDTO>
    {
        public BancoAddValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");
        }
    }
}
