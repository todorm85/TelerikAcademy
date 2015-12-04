namespace Teleimot.Server.Wcf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    using Teleimot.Common.Constants;
    using Teleimot.Server.Api;
    using Teleimot.Server.Api.Config;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            DataConfig.Initialize();

            AutoMapperConfig.RegisterMappings(Assembly.Load(AssembliesConstants.ApiModelsAssemblyName));
        }
    }
}