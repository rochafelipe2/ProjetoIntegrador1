using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class SubcategoriaEntity
    {
        public int idSubcategoria { get; set; }
        public string nomeSubcategoria { get; set; }
        public int idCategoria { get; set; }
        public int ativo { get; set; }
        public CategoriaEntity CategoriaEntity { get; set; }
    }
}
