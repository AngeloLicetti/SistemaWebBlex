namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyectov1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proyectoes",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Cotizacion_CotizacionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProyectoId)
                .ForeignKey("dbo.Cotizacions", t => t.Cotizacion_CotizacionId)
                .Index(t => t.Cotizacion_CotizacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectoes", "Cotizacion_CotizacionId", "dbo.Cotizacions");
            DropIndex("dbo.Proyectoes", new[] { "Cotizacion_CotizacionId" });
            DropTable("dbo.Proyectoes");
        }
    }
}
