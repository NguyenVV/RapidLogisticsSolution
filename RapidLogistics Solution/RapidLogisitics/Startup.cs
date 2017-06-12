using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RapidLogisitics.Startup))]
namespace RapidLogisitics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
