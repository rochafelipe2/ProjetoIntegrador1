using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class ProdutoEntity
    {
        [Key]
        public int idProduto { get; set; }
        public string tipoProduto { get; set; }
        public string nomeProduto { get; set; }

        public string descricaoProduto { get; set; }

        public string marcaProduto { get; set; }
        
        public int ativo { get; set; }

        public string url { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("SubcategoriaEntity")]
        public int IdSubcategoria { get; set; }
        public virtual SubcategoriaEntity SubcategoriaEntity { get; set; }
    }
}
