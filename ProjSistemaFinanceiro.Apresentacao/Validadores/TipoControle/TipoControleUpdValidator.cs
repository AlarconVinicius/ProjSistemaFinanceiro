﻿using FluentValidation;
using ProjSistemaFinanceiro.Aplicacao.DTOs.TipoControle;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.TipoControle
{
    public class TipoControleUpdValidator : AbstractValidator<TipoControleUpdDTO>
    {
        public TipoControleUpdValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");

        }
    }
}
