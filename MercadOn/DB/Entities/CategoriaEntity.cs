using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class CategoriaEntity
    {
        [Key]
        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; }
        public int ativo { get; set; }
    }
}
