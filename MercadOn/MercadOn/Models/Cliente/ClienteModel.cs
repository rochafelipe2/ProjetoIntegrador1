using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Cliente
{
    public class ClienteModel
    {
        public long cpf { get; set; }
        public string nome { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

    }
}