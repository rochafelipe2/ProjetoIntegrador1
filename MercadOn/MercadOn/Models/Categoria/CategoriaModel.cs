using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Categoria
{
    public class CategoriaModel
    {
        public CategoriaModel()
        {
            this.Categorias = new List<CategoriaDetail>();
        }

        public List<CategoriaDetail> Categorias { get; set; }

    }
}