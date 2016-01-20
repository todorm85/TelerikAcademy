using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _02_Employees;

namespace _03_EmployeesFormView
{
    public partial class Employees : System.Web.UI.Page
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id != null)
            {
                this.fvEmployees.ChangeMode(FormViewMode.Edit);
                this.fvEmployees.PageIndex = int.Parse(id) - 1;
                this.fvEmployees.AllowPaging = false;
            }

            this.fvEmployees.DataSource = this.db.Employees.ToList();
            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            this.db.Dispose();
        }

        protected void fvEmployees_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            this.fvEmployees.PageIndex = e.NewPageIndex;
            this.fvEmployees.DataSource = this.db.Employees.ToList();
            this.fvEmployees.DataBind();
        }
    }
}