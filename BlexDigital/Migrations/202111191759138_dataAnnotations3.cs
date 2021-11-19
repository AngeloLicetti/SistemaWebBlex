namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "NombreCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "CorreoDeContacto", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "CelularDeContacto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "CelularDeContacto", c => c.String());
            AlterColumn("dbo.Clientes", "CorreoDeContacto", c => c.String());
            AlterColumn("dbo.Clientes", "NombreCliente", c => c.String());
        }
    }
}
