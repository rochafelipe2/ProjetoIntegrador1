using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    class ProdutoEntity
    {
        [Key]
        public int idProduto { get; set; }
        public Enum tipoProduto { get; set; }
        public string nomeProduto { get; set; }
        public string marcaProduto { get; set; }
       
        public int ativo { get; set; }

        [ForeignKey("SubcategoriaEntity")]
        public int IdSubcategoria { get; set; }
        public SubcategoriaEntity SubcategoriaEntity { get; set; }
    }
}
