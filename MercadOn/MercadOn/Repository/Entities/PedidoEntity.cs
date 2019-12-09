using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class PedidoEntity
    {
        [Key]
        public int idPedido { get; set; }
        public DateTime dataPedido { get; set; }
        public DateTime dataConfirmado { get; set; }

        public int ativo { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("MercadoEntity")]
        public int idMercado { get; set; }
        public virtual MercadoEntity MercadoEntity { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("ClienteEntity")]
        public int idCliente { get; set; }
        public virtual ClienteEntity ClienteEntity { get; set; }
    }
}
