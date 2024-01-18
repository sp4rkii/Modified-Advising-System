using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class DeleteCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int courseId = Convert.ToInt32(txtCourseID.Text);
                string connectionString = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Procedures_AdminDeleteCourse", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@courseID", courseId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblResult.Text = "Course deleted successfully!";
                    }
                    else
                    {
                        lblError.Text = "Insert a valid id";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error deleting course: " + ex.Message;
            }
        }
    }
}