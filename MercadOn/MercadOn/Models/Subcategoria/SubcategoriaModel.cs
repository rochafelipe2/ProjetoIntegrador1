using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Subcategoria
{
    public class SubcategoriaModel
    {
        public SubcategoriaModel()
        {
            this.Subcategorias = new List<SubcategoriaDetail>();
        }

        public List<SubcategoriaDetail> Subcategorias { get; set; }

    }
}