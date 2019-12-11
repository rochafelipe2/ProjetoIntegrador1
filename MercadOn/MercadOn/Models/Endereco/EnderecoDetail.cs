using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Endereco
{
    public class EnderecoDetail
    {

        public int id { get; set; }

        public string nome { get; set; }

        public string rua { get; set; }

        public string numero { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public int cep {get;set;}

        public string complemento { get; set; }
    }
}