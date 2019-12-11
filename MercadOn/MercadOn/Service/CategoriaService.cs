using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class CategoriaService : ServiceBase<CategoriaEntity>
    {
        public CategoriaService(ContextMercadOn context)
        :base(context)
        {

        }
    }
}