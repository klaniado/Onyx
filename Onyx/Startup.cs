using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Onyx.Startup))]
namespace Onyx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
