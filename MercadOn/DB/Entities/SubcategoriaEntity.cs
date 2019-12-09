using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class SubcategoriaEntity
    {  
        [Key]
        public int idSubcategoria { get; set; }
        public string nomeSubcategoria { get; set; }
        public int ativo { get; set; }

        [ForeignKey("CategoriaEntity")]
        public int idCategoria { get; set; }
        public CategoriaEntity CategoriaEntity { get; set; }
    }
}
