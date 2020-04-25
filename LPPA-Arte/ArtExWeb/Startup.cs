using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtExWeb.Startup))]
namespace ArtExWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
