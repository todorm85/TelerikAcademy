using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _02_Employees;

namespace _05_EmployeesListView
{
    public partial class Employees : System.Web.UI.Page
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.employeesList.DataSource = this.db.Employees.ToList();
            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            this.db.Dispose();
        }
    }
}