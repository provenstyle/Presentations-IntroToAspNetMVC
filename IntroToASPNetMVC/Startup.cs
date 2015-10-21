using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntroToASPNetMVC.Startup))]
namespace IntroToASPNetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
