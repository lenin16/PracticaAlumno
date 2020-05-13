using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practicaweb_Alumno.Startup))]
namespace Practicaweb_Alumno
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
