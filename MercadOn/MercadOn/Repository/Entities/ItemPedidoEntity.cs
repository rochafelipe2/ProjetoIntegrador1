using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class ItemPedidoEntity
    {
        public int idItemPedido { get; set; }
        public string idPedido { get; set; }
        public int idPreco { get; set; }
        public int quantidade { get; set; }
        public int precoItem { get; set; }
        public PedidoEntity pedidoEntity { get; set; }
        public PrecoEntity precoEntity { get; set; }
    }
}
