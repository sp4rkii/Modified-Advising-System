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
    public partial class DeleteCourse1 : System.Web.UI.Page
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
                int Student_Id = Convert.ToInt32(studentid.Text);
                int Course_Id = Convert.ToInt32(courseId.Text);
                // Validate data (additional validation can be added)
                if (string.IsNullOrEmpty(semester))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>please enter a Semester Code</h4>
                </div>";
                    lblError1.Text = formattedText;
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorDeleteFromGP]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@studentID", Student_Id);
                            cmd.Parameters.AddWithValue("@sem_code", semester);
                            cmd.Parameters.AddWithValue("@courseID", Course_Id);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>Course Deleted Successfully!</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                            else
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Error Deleting Course, Please Try Agian</h4>
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
                    <h4>Invalid Inputs, Please Try Agian</h4>
                </div>";
                lblError1.Text = formattedText;
            }
        }
    }
}