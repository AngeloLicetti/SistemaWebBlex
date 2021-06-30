namespace BlexDigital.Migrations
{
    using BlexDigital.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Sistema_de_gestion_comercial_Blex_Digital.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlexDigital.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlexDigital.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.SolicitudesCotizacion.AddOrUpdate(
                s => s.Id,
                  new SolicitudCotizacion { Id = 1, NombreEmpresa = "EyGO Delivery", Correo = "eygodelivery@gmail.com", Celular = "999888777", NumeroPaginas = 5, CarritoDeCompras = false },
                  new SolicitudCotizacion { Id = 2, NombreEmpresa = "Cleia - Tienda de ropa", Correo = "cleiaperu@gmail.com", Celular = "998557664", NumeroPaginas = 6, CarritoDeCompras = true },
                  new SolicitudCotizacion { Id = 3, NombreEmpresa = "Geriatrico Vivencias", Correo = "eygodelivery@gmail.com", Celular = "987654321", NumeroPaginas = 8, CarritoDeCompras = false }
            );

            context.Trabajadores.AddOrUpdate(
                t => t.Id,
                    new Trabajador { Id = 1, Dni = "72263833", Nombre = "Federico", ApellidoPaterno = "Perez", ApellidoMaterno = "Leon", Puesto = "Desarrollador", Sueldo = 1500.00 },
                    new Trabajador { Id = 2, Dni = "6453521", Nombre = "Luis", ApellidoPaterno = "Farfan", ApellidoMaterno = "Beingolea", Puesto = "Disenador", Sueldo = 1200.00 },
                    new Trabajador { Id = 3, Dni = "72630638", Nombre = "Angelo", ApellidoPaterno = "Licetti", ApellidoMaterno = "Leon", Puesto = "Proyect Manager", Sueldo = 1300.00 }
            );

            context.Roles.AddOrUpdate(
                u => u.Id,
                    new IdentityRole { Id = "1", Name = "Admin"},
                    new IdentityRole { Id = "2", Name = "Cliente" }
            );
        }
    }
}
