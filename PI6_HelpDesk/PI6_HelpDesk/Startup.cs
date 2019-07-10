using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PI6_HelpDesk.Startup))]
namespace PI6_HelpDesk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
