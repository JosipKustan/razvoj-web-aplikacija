using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWA_Login.Startup))]
namespace RWA_Login
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
