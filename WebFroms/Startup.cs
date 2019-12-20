using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFroms.Startup))]
namespace WebFroms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
