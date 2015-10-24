using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW.App.Startup))]
namespace HW.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
