namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tabela_clientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteEntities",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        cpf = c.Long(nullable: false),
                        nome = c.String(),
                        celular = c.Long(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        ativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCliente)
                .ForeignKey("dbo.UsuarioEntities", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteEntities", "idUsuario", "dbo.UsuarioEntities");
            DropIndex("dbo.ClienteEntities", new[] { "idUsuario" });
            DropTable("dbo.ClienteEntities");
        }
    }
}
