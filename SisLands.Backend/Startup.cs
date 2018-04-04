using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SisLands.Backend.Startup))]
namespace SisLands.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
