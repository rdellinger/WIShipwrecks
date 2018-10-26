using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WIShipwrecks.Startup))]
namespace WIShipwrecks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
