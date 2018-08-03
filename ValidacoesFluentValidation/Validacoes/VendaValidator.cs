using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacoesFluentValidation.Entidades;

namespace ValidacoesFluentValidation.Validacoes
{
    //herdar e tipar ela com a Entidade que deseja validar
    class VendaValidator : AbstractValidator<Venda>
    {
        //CLasse onde fica as regras de validação
        //Especificação das regras de validação
        public VendaValidator()
        {
            RuleFor(v => v.Data) //Regra e Mensagem
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data da venda deve ser menor ou igual á data atual")
                .NotNull().WithMessage("A data não pode ser nula");

            RuleFor(v => v.Total)
                .GreaterThan(0).When(v => v.Tipo == TipoVenda.Padrao).WithMessage("O total da venda deve ser maior que zero");

            RuleFor(v => v.Itens)
                //verifica se a lista nao é nula, se não for nula o retorno será o Count dela maior que zero, se for nula retorna false
                .NotNull().WithMessage("A propriedade Itens da venda não pode ser nula")
                .Must(i => i != null ? i.Count > 0 : false).WithMessage("A venda deve possuir pelo menos um item")
                //Validando propriedades em cascata
                //Para cada item dentro da lista ele vai usar esse validador
                .SetCollectionValidator(new ItemVendaValidator());

            //Quando o tipo da venda for brinde, será aplicado a regra
            When(v => v.Tipo == TipoVenda.Brinde, () =>
            {
                RuleFor(v => v.Total)
                    .Equal(0).WithMessage("O total da venda deve ser {ComparisonValue} para vendas do tipo brinde");

                //vendo do tipo item devem ter um unico item
                RuleFor(v => v.Itens.Count)
                .Equal(1).WithMessage("Vendas do tipo brinde devem conter apenas {ComparisonValue item}");
            });
        }

    }
}
