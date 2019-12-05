using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class MercadoEntity
    {
        [Key]
        public int idMercado { get; set; }
        public long cnpj { get; set; }
        public string nome { get; set; }
        
        public int ativo { get; set; }

        public string url { get; set; }

        [ForeignKey("UsuarioEntity")]
        public int idUsuario { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }
    }
}
