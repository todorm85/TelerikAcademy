using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolutionTemplate.Web.Startup))]
namespace SolutionTemplate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}