using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    class EnderecoEntity
    {
        public int idEndereco { get; set; }
        public string nomeEndereco { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public int cep { get; set; }
        public string complemento { get; set; }
        public int idUsuario { get; set; }
        public int ativo { get; set; }
        public UsuarioEntity UsuarioEntity { get; set; }
    }
}
