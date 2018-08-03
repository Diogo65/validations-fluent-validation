using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacoesFluentValidation.Entidades;

namespace ValidacoesFluentValidation.Validacoes
{
    class ItemVendaValidator : AbstractValidator<ItemVenda>
    {
        //validador para o item da venda
        public ItemVendaValidator()
        {
            RuleFor(i => i.Descricao)
                .Length(3, 50).WithMessage("A descrição deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Preco)
                .GreaterThan(0).WithMessage("O preco do item deve ser maior que {ComparisonValue}");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do item deve ser maior que {ComparisonValue}");

        }
    }
}
