namespace VoiceSystem.Web.Areas.Admin
{
    using System.Web.Mvc;
    using VoiceSystem.Web.Infrastructure.Constraints;

    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                constraints: new { authConstraint = new AuthenticationRouteConstraint() },
                namespaces: new string[] { "VoiceSystem.Web.Areas.Admin.Controllers" }
            );
        }
    }
}