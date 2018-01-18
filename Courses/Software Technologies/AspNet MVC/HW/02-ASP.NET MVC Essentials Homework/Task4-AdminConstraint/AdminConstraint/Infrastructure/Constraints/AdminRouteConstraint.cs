using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AdminConstraint.Infrastructure.Constraints
{
    public class AdminRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var virtualPath = route.Url;

            var controllerName = values["controller"].ToString();
            if (controllerName.ToLower().StartsWith("admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}