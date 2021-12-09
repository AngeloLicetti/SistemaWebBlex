namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userProyectRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectoes", "Cliente_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Proyectoes", "Cliente_Id");
            AddForeignKey("dbo.Proyectoes", "Cliente_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectoes", "Cliente_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Proyectoes", new[] { "Cliente_Id" });
            DropColumn("dbo.Proyectoes", "Cliente_Id");
        }
    }
}
