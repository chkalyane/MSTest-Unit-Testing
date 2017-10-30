using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceExample.Startup))]
namespace ServiceExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
