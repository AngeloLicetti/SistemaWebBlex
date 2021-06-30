using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sistema_de_gestion_comercial_Blex_Digital.Models;

namespace BlexDigital.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BlexCS", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<SolicitudCotizacion> SolicitudesCotizacion { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<SolCotizacion> SolCotizacions { get; set; }
        public DbSet<Cotizacion> Cotizacions { get; set; }
        public DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }
    }
}