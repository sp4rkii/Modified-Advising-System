using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmClick(object sender, EventArgs e)
        {
            String formattedText;
            lblError1.Text = null;
            try
            {
                // Get form data



                string semester = txtSemester.Text;
                string coursename = course_name.Text;
                int Student_Id = Convert.ToInt32(studentid.Text);

                // Validate data (additional validation can be added)
                if (string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(coursename))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Semeter Code and Course Name</h4>
                </div>";
                    lblError1.Text = formattedText;
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorAddCourseGP]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@Semester_code", semester);
                            cmd.Parameters.AddWithValue("@student_id", Student_Id);
                            cmd.Parameters.AddWithValue("@course_name", coursename);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>New Course Added Successfully!</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                            else
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Error Adding Course, Please Try Agian</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                formattedText = $@"
    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
        <h5>Please make sure given inputs are registered in Database!</h5>
    </div>";
                lblError1.Text = formattedText;
            }

        }
    }
}