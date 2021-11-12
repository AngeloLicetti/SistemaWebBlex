namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoDeWebYDetallesAdicionales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SolCotizacions", "TipoWeb", c => c.Int(nullable: false));
            AddColumn("dbo.SolCotizacions", "DetallesAdicionales", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SolCotizacions", "DetallesAdicionales");
            DropColumn("dbo.SolCotizacions", "TipoWeb");
        }
    }
}
