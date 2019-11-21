namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioEntities",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 50),
                        senha = c.String(nullable: false, maxLength: 100),
                        dataCriacao = c.DateTime(nullable: false),
                        dataAlteracao = c.DateTime(nullable: false),
                        ativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsuarioEntities");
        }
    }
}
