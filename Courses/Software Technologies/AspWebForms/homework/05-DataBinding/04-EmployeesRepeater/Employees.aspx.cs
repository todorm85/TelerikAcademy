using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _02_Employees;

namespace _04_EmployeesRepeater
{
    public partial class Employees : System.Web.UI.Page
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterEmployees.DataSource = this.db.Employees.ToList();
            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            this.db.Dispose();
        }
    }
}