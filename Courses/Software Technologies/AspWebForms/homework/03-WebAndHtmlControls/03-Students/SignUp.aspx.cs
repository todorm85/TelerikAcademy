using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _03_Students
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnSubmit_Click(object sender, EventArgs e)
        {
            var firstName = this.tbFirstName.Text;
            var lastName = this.tbLastName.Text;
            var facNum = this.tbFacultyNumber.Text;
            var uni = this.dlistlUniversity.SelectedItem.Text;
            var spe = this.dlistSpecialty.SelectedItem.Text;
            List<String> courses = new List<string>();
            foreach (ListItem item in this.selectCourses.Items)
            {
                if (item.Selected)
                {
                    courses.Add(item.Text);
                }
            }

            var output = this.output.Controls;

            var summaryHeading = new HtmlGenericControl("h1");
            summaryHeading.InnerText = "Summary information";
            output.Add(summaryHeading);

            var firstNameParagraph = new HtmlGenericControl("p");
            firstNameParagraph.InnerHtml = $"<strong>First name:</strong> {firstName}";
            output.Add(firstNameParagraph);

            var lastNameParagraph = new HtmlGenericControl("p");
            lastNameParagraph.InnerHtml = $"<strong>Last name:</strong> {lastName}";
            output.Add(lastNameParagraph);

            var detailsInfo = new LiteralControl($@"
<p><strong>Faculty number</strong>: {facNum}</p>
<p><strong>University</strong>: {uni}</p>
<p><strong>Speciality</strong>: {spe}</p>
");
            output.Add(detailsInfo);

            var allCourses = String.Join(", ", courses);
            detailsInfo.Text += $"<p><strong>Courses: </strong>{allCourses}</p>";
        }
    }
}