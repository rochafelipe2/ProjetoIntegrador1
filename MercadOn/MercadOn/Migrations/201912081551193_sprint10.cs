namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprint10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemPedidoEntities", "precoItem", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemPedidoEntities", "precoItem", c => c.Int(nullable: false));
        }
    }
}
