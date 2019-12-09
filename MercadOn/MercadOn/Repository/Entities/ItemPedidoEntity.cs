using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class ItemPedidoEntity
    {
        [Key]
        public int idItemPedido { get; set; }
        
        
        public int quantidade { get; set; }
        public float precoItem { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("PedidoEntity")]
        public int idPedido { get; set; }
        public virtual PedidoEntity PedidoEntity { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("PrecoEntity")]
        public int idPreco { get; set; }
        public virtual PrecoEntity PrecoEntity { get; set; }
    }
}
