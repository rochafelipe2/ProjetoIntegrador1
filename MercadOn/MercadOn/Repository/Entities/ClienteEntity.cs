using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class ClienteEntity
    {
        [Key]
        public int idCliente { get; set; }
        public long cpf { get; set; }
        public string nome { get; set; }
        public long celular { get; set; }
        [ForeignKey("UsuarioEntity")]
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "obrigatório")]
        public virtual UsuarioEntity UsuarioEntity { get; set; }
        public int ativo { get; set; }
        
    }
}
