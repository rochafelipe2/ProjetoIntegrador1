using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class ClienteEntity
    {
        public int idCliente { get; set; }
        public int cpf { get; set; }
        public string nome { get; set; }
        public int celular { get; set; }
        public int idUsuario { get; set; }
        public int ativo { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }
    }
}
