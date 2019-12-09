using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class PedidoItemModel
    {

        public PedidoItemModel()
        {
            this.Itens = new List<PedidoItemDetail>();
        }

        public int pedidoid { get; set; }

        public List<PedidoItemDetail> Itens { get; set; }

    }
}