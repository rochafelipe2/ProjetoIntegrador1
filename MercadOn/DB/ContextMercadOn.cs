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

        public ContextMercadOn() : base("LAPTOP-QL7I3P7H\\SQLEXPRESS;Integrated Security=SSPI; Initial Catalog=MercadOn;Persist Security Info=True;User ID=;Password= providerName = System.Data.SqlClient")
        {

        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
