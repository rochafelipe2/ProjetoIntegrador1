using Entities.Entities;
using MercadOn;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DB
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContextMercadOn>
    {

        protected override void Seed(ContextMercadOn context)
        {

            if (context.Administradores.Count() == 0)
            {

                var usuarioMateus = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "mateus@mercadon.com",
                    senha = "123456"
                };

                var usuarioJair = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "jair@mercadon.com",
                    senha = "123456"
                };

                var usuarioFelipe = new UsuarioEntity()
                {
                    ativo = 1,
                    dataAlteracao = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    email = "felipe@mercadon.com",
                    senha = "123456"
                };

                context.Usuarios.Add(usuarioMateus);
                context.Usuarios.Add(usuarioJair);
                context.Usuarios.Add(usuarioFelipe);

                var adminMateus = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioMateus,
                    nomeAdmin = "Mateus Sanches"
                };

                var adminJair = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioJair,
                    nomeAdmin = "Jair Brann"
                };

                var adminFelipe = new AdministradorEntity()
                {
                    ativo = 1,
                    UsuarioEntity = usuarioFelipe,
                    nomeAdmin = "Felipe Rocha"
                };

                context.Administradores.Add(adminMateus);
                context.Administradores.Add(adminJair);
                context.Administradores.Add(adminFelipe);
                context.SaveChanges();


            }
        }
    }
}