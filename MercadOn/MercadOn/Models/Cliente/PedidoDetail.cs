using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class PedidoDetail
    {

        public string Mercado { get; set; }

        public string Cliente { get; set; }

        public int pedidoid { get; set; }

        public float total { get; set; }

        public string dataPedido { get; set; }

    }
}