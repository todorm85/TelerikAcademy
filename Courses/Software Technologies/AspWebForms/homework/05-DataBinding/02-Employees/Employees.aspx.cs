using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.employeesGrid.DataSource = this.db.Employees.ToList();

            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            this.db.Dispose();
        }

        protected void employeesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.employeesGrid.PageIndex = e.NewPageIndex;
            this.employeesGrid.DataSource = this.db.Employees.ToList();
            this.employeesGrid.DataBind();
        }
    }
}