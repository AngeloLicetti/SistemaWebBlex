namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disenoElegido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "DisenoElegido", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyectoes", "DisenoElegido");
        }
    }
}
