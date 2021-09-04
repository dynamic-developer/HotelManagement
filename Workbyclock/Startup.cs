using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workbyclock.Startup))]
namespace Workbyclock
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
