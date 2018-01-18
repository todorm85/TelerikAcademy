using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            var num1 = 0M;
            var num2 = 0M;
            try
            {
                num1 = decimal.Parse(this.firstNumber.Value.ToString());
                num2 = decimal.Parse(this.secondNumber.Value.ToString());

            }
            catch (Exception ex)
            {
                this.result.Value = "Invalid input";
                return;
            }

            this.result.Value = (num1 + num2).ToString();
        }
    }
}