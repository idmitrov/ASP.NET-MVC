using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhC.App.Startup))]
namespace PhC.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
