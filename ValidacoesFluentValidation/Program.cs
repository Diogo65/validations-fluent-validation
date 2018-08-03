using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidacoesFluentValidation.Entidades;
using ValidacoesFluentValidation.Validacoes;

namespace ValidacoesFluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemVenda item1 = new ItemVenda()
            {
                Descricao = "Cabo Usb 3.0",
                Preco = 30,
                Quantidade = 1
            };

            ItemVenda item2 = new ItemVenda()
            {
                Descricao = "",
                Preco = 0,
                Quantidade = 0
            };

            //Instalar o FluentValidation
            Venda venda = new Venda();
            venda.Data = DateTime.Today;
            venda.Tipo = TipoVenda.Brinde;
            venda.Total = 0;
            venda.Itens = new List<ItemVenda>(new[] { item1 });

            //instanciar a classe de validação
            VendaValidator validator = new VendaValidator();
            
            try
            {
                //Realiza a validação
                validator.ValidateAndThrow(venda);
                Console.WriteLine("Venda validada com sucesso");
            }
            catch (ValidationException excecao)
            {
                //vai percorrer as mensagens de erro e imprimi-las no console
                Console.WriteLine("Venda inválida.");
                excecao.Errors
                       .ToList()
                       .ForEach(e => Console.WriteLine($"{e.PropertyName} : {e.ErrorMessage}"));
            }

            Console.ReadKey();
        }
    }
}
