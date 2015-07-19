using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSMWeb.Startup))]
namespace SSMWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
