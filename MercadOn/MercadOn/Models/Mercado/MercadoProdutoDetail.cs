﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Models.Mercado
{
    public class MercadoProdutoDetail
    {
        public string nome { get; set; }

        public float preco { get; set; }

        public string descricao { get; set; }

        public int idProduto { get; set; }

        public string url { get; set; }

    }
}