using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPMTestEMS.Startup))]
namespace KPMTestEMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
