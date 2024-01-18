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
    public partial class AdminLinkInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLinkInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                int courseId = Convert.ToInt32(txtCourseId.Text);
                int instructorId = Convert.ToInt32(txtInstructorId.Text);
                int slotId = Convert.ToInt32(txtSlotId.Text);

                // Validate data (additional validation can be added)
                if (courseId <= 0 || instructorId <= 0 || slotId <= 0)
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
                        using (SqlCommand cmd = new SqlCommand("Procedures_AdminLinkInstructor", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@cours_id", courseId);
                            cmd.Parameters.AddWithValue("@instructor_id", instructorId);
                            cmd.Parameters.AddWithValue("@slot_id", slotId);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "Instructor linked to course successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error linking instructor to course. Please try again.";
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