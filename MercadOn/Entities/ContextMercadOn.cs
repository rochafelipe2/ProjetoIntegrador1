using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Entities.Entities;


namespace MercadOn.Repository
{
    public class ContextMercadOn : DbContext
    {

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
