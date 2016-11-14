using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using CTL.BLL.Identity.Services;
using Microsoft.AspNet.Identity;
using CTL.BLL.Identity.Interfaces;

[assembly: OwinStartup(typeof(CTL.WEB.App_Start.Startup))]

namespace CTL.WEB.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}