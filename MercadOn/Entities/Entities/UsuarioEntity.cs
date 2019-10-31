using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class UsuarioEntity
    {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int ativo { get; set; }
    }
}
