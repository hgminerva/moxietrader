using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(moxietrader.Startup))]
namespace moxietrader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
