using System;
using System.Web.UI.HtmlControls;

namespace Todos.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public string SuccessMessage
        {
            get { return this.success.InnerText; }
            set { this.success.InnerText = value; }
        }

        public void ShowSuccessMessage(string message)
        {
            this.success.InnerText = message;
            this.success.Attributes.Remove("hidden");
        }
    }
}