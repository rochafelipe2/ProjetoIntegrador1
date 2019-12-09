using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    public class EnderecoEntity
    {
        [Key]
        public int idEndereco { get; set; }
        public string nomeEndereco { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public int cep { get; set; }
        public string complemento { get; set; }
        
        public int ativo { get; set; }

        [Required(ErrorMessage = "obrigatório")]
        [ForeignKey("UsuarioEntity")]
        public int idUsuario { get; set; }
        public virtual UsuarioEntity UsuarioEntity { get; set; }
    }
}
