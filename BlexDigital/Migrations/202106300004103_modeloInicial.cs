namespace BlexDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Dni = c.String(nullable: false, maxLength: 128),
                        NombreCliente = c.String(),
                        CorreoDeContacto = c.String(),
                        CelularDeContacto = c.String(),
                    })
                .PrimaryKey(t => t.Dni);
            
            CreateTable(
                "dbo.SolCotizacions",
                c => new
                    {
                        SolCotizacionId = c.Int(nullable: false, identity: true),
                        NombreEmpresa = c.String(),
                        DescripcionDelNegocio = c.String(),
                        Mision = c.String(),
                        Vision = c.String(),
                        Direccion = c.String(),
                        CorreoDeEmpresa = c.String(),
                        TelefonoDeEmpresa = c.String(),
                        NumeroPaginas = c.Int(nullable: false),
                        PaginaConCatalogo = c.Boolean(nullable: false),
                        CarritoDeCompras = c.Boolean(nullable: false),
                        FechaSolicitud = c.DateTime(nullable: false),
                        Cliente_Id = c.String(maxLength: 128),
                        Cliente_Dni = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SolCotizacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.Cliente_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Dni)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Cliente_Dni);
            
            CreateTable(
                "dbo.Cotizacions",
                c => new
                    {
                        CotizacionId = c.Int(nullable: false, identity: true),
                        Mensaje = c.String(),
                        Dias = c.Int(nullable: false),
                        PrecioTotal = c.Double(nullable: false),
                        FechaCotizacion = c.DateTime(nullable: false),
                        SolCotizacion_SolCotizacionId = c.Int(),
                    })
                .PrimaryKey(t => t.CotizacionId)
                .ForeignKey("dbo.SolCotizacions", t => t.SolCotizacion_SolCotizacionId)
                .Index(t => t.SolCotizacion_SolCotizacionId);
            
            CreateTable(
                "dbo.DetalleCotizacions",
                c => new
                    {
                        DetalleCotizacionId = c.Int(nullable: false, identity: true),
                        NombreDetalle = c.String(),
                        PrecioDetalle = c.Double(nullable: false),
                        Cotizacion_CotizacionId = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleCotizacionId)
                .ForeignKey("dbo.Cotizacions", t => t.Cotizacion_CotizacionId)
                .Index(t => t.Cotizacion_CotizacionId);
            
            CreateTable(
                "dbo.SolicitudCotizacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreEmpresa = c.String(),
                        Correo = c.String(),
                        Celular = c.String(),
                        NumeroPaginas = c.Int(nullable: false),
                        CarritoDeCompras = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabajadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dni = c.String(),
                        Nombre = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Sueldo = c.Double(nullable: false),
                        Puesto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Dni", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "Celular", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cotizacions", "SolCotizacion_SolCotizacionId", "dbo.SolCotizacions");
            DropForeignKey("dbo.DetalleCotizacions", "Cotizacion_CotizacionId", "dbo.Cotizacions");
            DropForeignKey("dbo.SolCotizacions", "Cliente_Dni", "dbo.Clientes");
            DropForeignKey("dbo.SolCotizacions", "Cliente_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DetalleCotizacions", new[] { "Cotizacion_CotizacionId" });
            DropIndex("dbo.Cotizacions", new[] { "SolCotizacion_SolCotizacionId" });
            DropIndex("dbo.SolCotizacions", new[] { "Cliente_Dni" });
            DropIndex("dbo.SolCotizacions", new[] { "Cliente_Id" });
            DropColumn("dbo.AspNetUsers", "Celular");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropColumn("dbo.AspNetUsers", "Dni");
            DropTable("dbo.Trabajadors");
            DropTable("dbo.SolicitudCotizacions");
            DropTable("dbo.DetalleCotizacions");
            DropTable("dbo.Cotizacions");
            DropTable("dbo.SolCotizacions");
            DropTable("dbo.Clientes");
        }
    }
}
