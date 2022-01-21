using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPASPNETPOURDEVRAI.Startup))]
namespace TPASPNETPOURDEVRAI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
