using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Mercado
{
    public class MercadoModel
    {
        public MercadoModel()
        {
            this.Mercados = new List<MercadoDetail>();
        }

        public List<MercadoDetail> Mercados { get; set; }

    }
}