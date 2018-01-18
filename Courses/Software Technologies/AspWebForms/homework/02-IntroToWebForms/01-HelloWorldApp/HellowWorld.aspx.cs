using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HelloWorldApp
{
    public partial class HellowWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pMessage.InnerHtml = "Your greet message here.";
        }

        protected void OnBtnSendNameClick(object sender, EventArgs e)
        {
            this.pMessage.InnerHtml = $"Hello, {this.tbName.Text}";
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            //this.pMessage.InnerHtml = "Hahah overrided it with page_prerender";
        }

    }
}