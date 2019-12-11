using MercadOn.Models.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            this.endereco = new EnderecoDetail();
        }

        public long cpf { get; set; }
        public string nome { get; set; }
        public long celular { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public long clienteid { get; set; }

        public EnderecoDetail endereco { get; set; }

    }
}