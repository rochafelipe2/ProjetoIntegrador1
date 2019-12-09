using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Mercado
{
    public class MercadoProdutoModel
    {

        public MercadoProdutoModel()
        {
            this.Produtos = new List<MercadoProdutoDetail>();
        }

        public int idMercado { get; set; }
        public int idCliente { get; set; }
        public List<MercadoProdutoDetail> Produtos { get; set; }

    }
}