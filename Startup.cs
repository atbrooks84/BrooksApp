using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrooksApp.Startup))]
namespace BrooksApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
