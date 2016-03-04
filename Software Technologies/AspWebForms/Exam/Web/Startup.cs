using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouTubePlaylists.Web.Startup))]
namespace YouTubePlaylists.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}