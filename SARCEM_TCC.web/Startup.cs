using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SARCEM_TCC.web.Startup))]
namespace SARCEM_TCC.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
