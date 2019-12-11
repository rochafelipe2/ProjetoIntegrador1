using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Produto
{
    public class ProdutoModel
    {

        public ProdutoModel()
        {
            this.Produtos = new List<ProdutoDetail>();
        }

        public string nome { get; set; }

        public string descricao { get; set; }

        public string marca { get; set; }

        public string url { get; set; }

        public int subCategoria { get; set; }

        public List<ProdutoDetail> Produtos { get; set; }

    }
}