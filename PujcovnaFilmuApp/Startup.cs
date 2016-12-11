using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PujcovnaFilmuApp.Startup))]
namespace PujcovnaFilmuApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
