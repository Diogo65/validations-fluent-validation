using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacoesFluentValidation.Entidades
{
    class ItemVenda
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade{ get; set; }
    }
}
