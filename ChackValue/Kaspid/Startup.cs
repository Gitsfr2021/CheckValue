using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kaspid.Startup))]
namespace Kaspid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
