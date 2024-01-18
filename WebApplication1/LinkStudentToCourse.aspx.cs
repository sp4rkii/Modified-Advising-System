using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Admin
{
    public partial class LinkStudentToCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLinkStudentToCourse_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                int courseId = Convert.ToInt32(txtCourseId.Text);
                int instructorId = Convert.ToInt32(txtInstructorId.Text);
                int studentId = Convert.ToInt32(txtStudentId.Text);
                string semesterCode = txtSemesterCode.Text;

                // Validate data (additional validation can be added)
                if (courseId <= 0 || instructorId <= 0 || studentId <= 0 || string.IsNullOrEmpty(semesterCode))
                {
                    lblError.Text = "One of the inputs is empty or invalid. Please fill out all fields.";
                    lblResult.Text = "";
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Procedures_AdminLinkStudent", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@cours_id", courseId);
                            cmd.Parameters.AddWithValue("@instructor_id", instructorId);
                            cmd.Parameters.AddWithValue("@studentID", studentId);
                            cmd.Parameters.AddWithValue("@semester_code", semesterCode);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "Student linked to course with instructor successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error linking student to course with instructor. Please try again.";
                                lblResult.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
                lblResult.Text = "";
            }
        }
    }
}