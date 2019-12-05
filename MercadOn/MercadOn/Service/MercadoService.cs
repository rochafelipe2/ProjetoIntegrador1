using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class MercadoService : ServiceBase<MercadoEntity>
    {

        public MercadoService(ContextMercadOn context)
            : base(context)
        {
        }
    }
}