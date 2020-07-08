using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AutenticacionManual.App_Start.Startup))]

namespace AutenticacionManual.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType="CookieAuthentication",
                LoginPath=new PathString("/Auth/Login")
            });
        }
    }
}
