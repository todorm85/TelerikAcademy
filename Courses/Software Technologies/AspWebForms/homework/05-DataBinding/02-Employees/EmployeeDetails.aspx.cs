using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_Employees
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("Employees.aspx");
            }

            var employeeId = int.Parse(Request.Params["id"]);

            this.employeeDetails.DataSource = this.db.Employees.ToList();
            this.employeeDetails.PageIndex = employeeId - 1;

            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            this.db.Dispose();
        }

    }
}