using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class EnderecoService : ServiceBase<EnderecoEntity>
    {
        public EnderecoService(ContextMercadOn context)
            :base(context)
        {

        }
    }
}