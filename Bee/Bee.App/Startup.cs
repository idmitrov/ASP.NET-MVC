using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bee.App.Startup))]
namespace Bee.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
