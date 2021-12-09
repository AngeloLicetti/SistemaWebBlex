namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urlProyecto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "UrlProyecto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyectoes", "UrlProyecto");
        }
    }
}
