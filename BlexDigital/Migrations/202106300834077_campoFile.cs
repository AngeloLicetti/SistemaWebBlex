namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cotizacions", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cotizacions", "File");
        }
    }
}
