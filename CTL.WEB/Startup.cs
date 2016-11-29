using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CTL.WEB.Startup))]
namespace CTL.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
