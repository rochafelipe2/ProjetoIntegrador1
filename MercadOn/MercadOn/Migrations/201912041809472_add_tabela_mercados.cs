namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tabela_mercados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MercadoEntities",
                c => new
                    {
                        idMercado = c.Int(nullable: false, identity: true),
                        cnpj = c.Int(nullable: false),
                        nome = c.String(),
                        ativo = c.Int(nullable: false),
                        url = c.String(),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMercado)
                .ForeignKey("dbo.UsuarioEntities", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MercadoEntities", "idUsuario", "dbo.UsuarioEntities");
            DropIndex("dbo.MercadoEntities", new[] { "idUsuario" });
            DropTable("dbo.MercadoEntities");
        }
    }
}
