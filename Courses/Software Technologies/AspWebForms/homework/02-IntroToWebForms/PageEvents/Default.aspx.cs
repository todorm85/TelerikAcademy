using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageEvents
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pPageEvents.InnerHtml += "Page_Load invoked" + "<br/>";
            this.pLocationMessage.InnerHtml = Assembly.GetExecutingAssembly().Location;
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("<div class=\"jumbotron\"><p class=\"lead\">Page_PreInit invoked</p></div>" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.pPageEvents.InnerHtml += ("Page_Init invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.pPageEvents.InnerHtml += ("Page_PreRender invoked" + "<br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
        }
    }
}