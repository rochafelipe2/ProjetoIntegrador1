using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class ProdutoEntity
    {
        public int idProduto { get; set; }
        public Enum tipoProduto { get; set; }
        public string nomeProduto { get; set; }
        public string marcaProduto { get; set; }
        public int IdSubcategoria { get; set; }
        public int ativo { get; set; }
        public SubcategoriaEntity subcategoriaEntity { get; set; }
    }
}
