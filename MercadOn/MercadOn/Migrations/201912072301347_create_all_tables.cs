namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_all_tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoEntities", "tipoProduto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProdutoEntities", "tipoProduto");
        }
    }
}
