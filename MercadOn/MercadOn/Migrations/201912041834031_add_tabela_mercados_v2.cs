namespace DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tabela_mercados_v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MercadoEntities", "cnpj", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MercadoEntities", "cnpj", c => c.Int(nullable: false));
        }
    }
}
