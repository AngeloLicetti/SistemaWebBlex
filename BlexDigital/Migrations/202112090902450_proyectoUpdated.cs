namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyectoUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "Diseno1", c => c.String());
            AddColumn("dbo.Proyectoes", "Diseno2", c => c.String());
            AddColumn("dbo.Proyectoes", "Diseno3", c => c.String());
            AddColumn("dbo.Proyectoes", "Trabajador_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Proyectoes", "Trabajador_Id");
            AddForeignKey("dbo.Proyectoes", "Trabajador_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectoes", "Trabajador_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Proyectoes", new[] { "Trabajador_Id" });
            DropColumn("dbo.Proyectoes", "Trabajador_Id");
            DropColumn("dbo.Proyectoes", "Diseno3");
            DropColumn("dbo.Proyectoes", "Diseno2");
            DropColumn("dbo.Proyectoes", "Diseno1");
        }
    }
}
