using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Class10Autentication.Startup))]
namespace Class10Autentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
