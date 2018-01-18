using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(ExpenseTracker.Web.Startup))]

namespace ExpenseTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
