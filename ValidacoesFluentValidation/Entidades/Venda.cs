using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacoesFluentValidation.Entidades
{
    class Venda
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public TipoVenda Tipo{ get; set; }
        public List<ItemVenda> Itens { get; set; }
    }
}
