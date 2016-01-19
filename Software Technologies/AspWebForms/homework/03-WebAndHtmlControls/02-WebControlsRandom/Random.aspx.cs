using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_Random
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private Random randomGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var lower = int.Parse(this.tbLowerBound.Text);
                var upper = int.Parse(this.tbUpperBound.Text);

                if (lower >= upper)
                {
                    this.result.InnerHtml = "Invalid input. Lower must be less than upper";
                    return;
                }

                var randomNumber = randomGenerator.Next(lower, upper);
                this.result.InnerHtml = randomNumber.ToString();
            }
            catch (Exception)
            {
                this.result.InnerHtml = "Invalid input";
            }
        }
    }
}