using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeMinisters.Startup))]
namespace PrimeMinisters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
