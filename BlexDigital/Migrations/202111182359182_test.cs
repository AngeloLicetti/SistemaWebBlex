namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SolCotizacions", "TelefonoDeEmpresa", c => c.String(maxLength: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SolCotizacions", "TelefonoDeEmpresa", c => c.String());
        }
    }
}
