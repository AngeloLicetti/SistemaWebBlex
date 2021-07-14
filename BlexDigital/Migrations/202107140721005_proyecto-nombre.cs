namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyectonombre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "NombreProyecto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyectoes", "NombreProyecto");
        }
    }
}
