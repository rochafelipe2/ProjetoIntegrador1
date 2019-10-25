using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class PrecoEntity
    {
        public int idPreco { get; set; }
        public int idProduto { get; set; }
        public int idMercado { get; set; }
        public float precoProduto { get; set; }
        public ProdutoEntity produtoEntity { get; set; }
        public MercadoEntity mercadoEntity { get; set; }
    }
}
