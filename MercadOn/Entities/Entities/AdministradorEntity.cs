using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class AdministradorEntity
    {
        public int idAdministrador { get; set; }
        public string nomeAdmin { get; set; }
        public int idUsuario { get; set; }
        public int ativo { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }
    }
}
