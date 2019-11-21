namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabelaadministrador2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEntities",
                c => new
                    {
                        idAdministrador = c.Int(nullable: false, identity: true),
                        nomeAdmin = c.String(),
                        ativo = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAdministrador)
                .ForeignKey("dbo.UsuarioEntities", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdministradorEntities", "idUsuario", "dbo.UsuarioEntities");
            DropIndex("dbo.AdministradorEntities", new[] { "idUsuario" });
            DropTable("dbo.AdministradorEntities");
        }
    }
}
