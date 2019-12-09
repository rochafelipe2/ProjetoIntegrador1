using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class PrecoEntity
    {
        [Key]
        public int idPreco { get; set; }
       
        
        public float precoProduto { get; set; }

        [ForeignKey("ProdutoEntity")]
        public int idProduto { get; set; }
        public virtual ProdutoEntity ProdutoEntity { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("MercadoEntity")]
        public int idMercado { get; set; }
        public virtual MercadoEntity MercadoEntity { get; set; }
    }
}
