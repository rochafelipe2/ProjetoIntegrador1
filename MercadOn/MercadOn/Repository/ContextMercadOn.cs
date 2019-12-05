using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Entity;
using Entities.Entities;

namespace MercadOn
{
    public class ContextMercadOn : DbContext
    {
        
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<AdministradorEntity> Administradores { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }

        public DbSet<MercadoEntity> Mercados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
