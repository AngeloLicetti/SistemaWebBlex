using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlexDigital.Startup))]
namespace BlexDigital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
