namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoProyect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyectoes", "Estado");
        }
    }
}
