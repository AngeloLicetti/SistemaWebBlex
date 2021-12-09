namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noValidationUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Dni", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Celular", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Celular", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Dni", c => c.String(nullable: false));
        }
    }
}
