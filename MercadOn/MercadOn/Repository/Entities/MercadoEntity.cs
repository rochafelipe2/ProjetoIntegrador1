using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class MercadoEntity
    {
        public int idMercado { get; set; }
        public int cnpj { get; set; }
        public string nome { get; set; }
        public int idUsuario { get; set; }
        public int ativo { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }
    }
}
