using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Template.Web.Startup))]
namespace Template.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}