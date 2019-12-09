using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class PedidoItemDetail
    {

        

        public int pedidoitemid { get; set; }

        public int quantidade { get; set; }

        public float valor { get; set; }

        public string produto { get; set; }

    }
}