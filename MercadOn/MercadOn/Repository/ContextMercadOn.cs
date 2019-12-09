using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Entity;
using Entities.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MercadOn
{
    public class ContextMercadOn : DbContext
    {
        
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<AdministradorEntity> Administradores { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }

        public DbSet<MercadoEntity> Mercados { get; set; }

        public DbSet<CategoriaEntity> Categorias { get; set; }

        public DbSet<EnderecoEntity> Enderecos { get; set; }

        public DbSet<ItemPedidoEntity> ItemPedidos { get; set; }

        public DbSet<PedidoEntity> Pedidos { get; set; }

        public DbSet<PrecoEntity> Precos { get; set; }

        public DbSet<ProdutoEntity> Produtos { get; set; }

        public DbSet<SubcategoriaEntity> SubCategorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
