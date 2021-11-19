namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SolCotizacions", "NombreEmpresa", c => c.String(nullable: false));
            AlterColumn("dbo.SolCotizacions", "DescripcionDelNegocio", c => c.String(nullable: false));
            AlterColumn("dbo.SolCotizacions", "CorreoDeEmpresa", c => c.String(nullable: false));
            AlterColumn("dbo.SolCotizacions", "TelefonoDeEmpresa", c => c.String(nullable: false, maxLength: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SolCotizacions", "TelefonoDeEmpresa", c => c.String(maxLength: 9));
            AlterColumn("dbo.SolCotizacions", "CorreoDeEmpresa", c => c.String());
            AlterColumn("dbo.SolCotizacions", "DescripcionDelNegocio", c => c.String());
            AlterColumn("dbo.SolCotizacions", "NombreEmpresa", c => c.String());
        }
    }
}
