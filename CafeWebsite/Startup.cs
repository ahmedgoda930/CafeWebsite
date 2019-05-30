using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeWebsite.Startup))]
namespace CafeWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
