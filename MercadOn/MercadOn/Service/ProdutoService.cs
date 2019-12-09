using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Controllers
{
    public class ProdutoService : ServiceBase<ProdutoEntity>
    {

        public ProdutoService(ContextMercadOn context)
            : base(context)
        {
        }
    }
}