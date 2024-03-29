﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    class AdministradorEntity
    {
        [Key]
        public int idAdministrador { get; set; }
        public string nomeAdmin { get; set; }

        public int ativo { get; set; }

        [ForeignKey("UsuarioEntity")]
        public int idUsuario { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }

    }
}
