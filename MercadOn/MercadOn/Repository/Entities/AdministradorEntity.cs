using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class AdministradorEntity
    {
        [Key]
        public int idAdministrador { get; set; }
        public string nomeAdmin { get; set; }

        public int ativo { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("UsuarioEntity")]
        public int idUsuario { get; set; }
        public virtual UsuarioEntity UsuarioEntity { get; set; }

    }
}
