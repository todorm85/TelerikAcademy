namespace MusicAlbums.Api
{
    using System.Reflection;
    using System.Web.Http;
    using MusicAlbums.Api.App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings(Assembly.Load("MusicAlbums.Api"));
            DatabaseConfig.Initialize();
        }
    }
}