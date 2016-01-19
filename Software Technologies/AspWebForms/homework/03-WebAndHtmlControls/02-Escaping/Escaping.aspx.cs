using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBtnSend_Click(object sender, EventArgs e)
        {
            var input = this.tbInput.Text;
            this.tbResult.Text = input;
            this.lbResult.Text = Server.HtmlEncode(input); ;
        }
    }
}