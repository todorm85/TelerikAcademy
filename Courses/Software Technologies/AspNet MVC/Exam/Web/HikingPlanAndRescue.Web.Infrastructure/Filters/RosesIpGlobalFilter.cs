namespace VoiceSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class RosesIpGlobalFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string userIP = filterContext.HttpContext.Request.UserHostAddress;

            filterContext.RequestContext.HttpContext.Response.AddHeader("X-ROSES-ARE-RED-VIOLETS-ARE-BlUE-I-KNOW-EVERYTHING-ABOUT-YOU", userIP);

            base.OnActionExecuted(filterContext);
        }
    }
}
