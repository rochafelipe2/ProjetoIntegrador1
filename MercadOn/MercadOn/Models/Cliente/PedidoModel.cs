using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class PedidoModel
    {
        public PedidoModel()
        {
            this.Pedidos = new List<PedidoDetail>();
        }

        public int clienteid { get; set; }

        public List<PedidoDetail> Pedidos { get; set; }
    }
}