using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(VoiceSystem.Web.Startup))]

namespace VoiceSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
