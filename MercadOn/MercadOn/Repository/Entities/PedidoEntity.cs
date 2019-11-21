using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class PedidoEntity
    {
        public int idPedido { get; set; }
        public DateTime dataPedido { get; set; }
        public DateTime dataConfirmado { get; set; }
        public int idMercado { get; set; }
        public int idCliente { get; set; }
        public int ativo { get; set; }
        public MercadoEntity mercadoEntity { get; set; }
        public ClienteEntity clienteEntity { get; set; }
    }
}
