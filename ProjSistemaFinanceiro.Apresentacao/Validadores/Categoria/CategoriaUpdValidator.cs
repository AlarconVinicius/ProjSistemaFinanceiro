﻿using FluentValidation;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Categoria;

namespace ProjSistemaFinanceiro.Apresentacao.Validadores.Categoria
{
    public class CategoriaUpdValidator : AbstractValidator<CategoriaUpdDTO>
    {
        public CategoriaUpdValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio.")
                .Length(3, 50).WithMessage("O campo 'Nome' deve ter entre 3 e 50 caracteres.");
            RuleFor(dto => dto.Descricao)
                .MaximumLength(300).WithMessage("O campo 'Descrição' deve ter no máximo 300 caracteres.");

        }
    }
}
