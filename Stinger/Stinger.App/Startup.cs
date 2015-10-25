using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stinger.App.Startup))]
namespace Stinger.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
