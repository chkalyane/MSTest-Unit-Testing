using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestDemoUI.Startup))]
namespace UnitTestDemoUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
