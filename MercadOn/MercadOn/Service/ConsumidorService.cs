using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class ConsumidorService : ServiceBase<ClienteEntity>
    {
        private ContextMercadOn repository;
        public ConsumidorService(ContextMercadOn context)
            : base(context)
        {
        }
    }
}