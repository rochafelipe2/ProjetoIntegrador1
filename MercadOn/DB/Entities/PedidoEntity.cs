using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    class PedidoEntity
    {
        [Key]
        public int idPedido { get; set; }
        public DateTime dataPedido { get; set; }
        public DateTime dataConfirmado { get; set; }
      
        public int ativo { get; set; }

        [ForeignKey("MercadoEntity")]
        public int idMercado { get; set; }
        public MercadoEntity MercadoEntity { get; set; }

        [ForeignKey("ClienteEntity")]
        public int idCliente { get; set; }
        public ClienteEntity ClienteEntity { get; set; }
    }
}
