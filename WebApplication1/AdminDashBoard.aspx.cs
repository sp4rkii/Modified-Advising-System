using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class AdminDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ListAdvisors_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAdvisors.aspx");
        }
        protected void ListStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListStudents.aspx");
        }
        protected void PendingRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingRequests.aspx");
        }

        protected void AddNewSemester_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewSemester.aspx");
        }

        protected void AddNewCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewCourse.aspx");
        }

        protected void AdminLinkInstructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLinkInstructor.aspx");
        }

        protected void LinkStudentToAdvisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkStudentToAdvisor.aspx");
        }

        protected void LinkStudentToCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkStudentToCourse.aspx");
        }

        protected void ViewInstructorsAssignedCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInstructorsAssignedCourses.aspx");
        }

        protected void ViewSemestersOfferedCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSemestersOfferedCourses.aspx");
        }
    }
}