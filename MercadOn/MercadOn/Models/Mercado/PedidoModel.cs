using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Mercado
{
    public class PedidoModel
    {

        public PedidoModel()
        {
            this.Produtos = new List<MercadoProdutoDetail>();
        }

        public string Carrinho { get; set; }

        public int mercadoid { get; set; }

        public int clienteid { get; set; }

        public List<MercadoProdutoDetail> Produtos { get; set; }
    }
}