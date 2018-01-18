namespace Teleimot.Server.Api
{
    using System.Reflection;
    using System.Web.Http;
    using Common.Constants;
    using Config;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(AssembliesConstants.ApiModelsAssemblyName));
        }
    }
}