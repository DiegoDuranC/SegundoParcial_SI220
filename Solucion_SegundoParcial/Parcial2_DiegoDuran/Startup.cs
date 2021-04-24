using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parcial2_DiegoDuran.Startup))]
namespace Parcial2_DiegoDuran
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
