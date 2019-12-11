using MercadOn.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Mercado
{
    public class ProdutoPrecoModel
    {

        public ProdutoPrecoModel()
        {
            this.ProdutosPreco = new List<MercadoProdutoDetail>();
            this.Produtos = new List<ProdutoViewModel>();
        }

        public int idMercado { get; set; }
        public float preco { get; set; }


        public int produtoSelecinado { get; set; }
        public List<ProdutoViewModel> Produtos { get; set; }
        public List<MercadoProdutoDetail> ProdutosPreco { get; set; }

    }
}