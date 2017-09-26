using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YesMed.Startup))]
namespace YesMed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         //   ConfigureAuth(app);
        }
    }
}
