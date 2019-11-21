using Entities.Entities;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{


    public class UsuarioService : ServiceBase<UsuarioEntity>
    {
        private ContextMercadOn repository;
        public UsuarioService(ContextMercadOn context)
            : base(context)
        {
        }

    }
}