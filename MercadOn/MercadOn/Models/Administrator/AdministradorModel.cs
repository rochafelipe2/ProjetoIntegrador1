using MercadOn.Models.Mercado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Administrator
{
    public class AdministradorModel
    {

        public AdministradorModel()
        {
            this.Mercados = new List<MercadoDetail>();
        }


        public List<MercadoDetail> Mercados { get; set; }
    }
}