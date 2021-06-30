namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoSol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SolCotizacions", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SolCotizacions", "Estado");
        }
    }
}
