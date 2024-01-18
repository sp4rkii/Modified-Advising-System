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
    public partial class LinkStudentToAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLinkStudentToAdvisor_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                int studentId = Convert.ToInt32(txtStudentId.Text);
                int advisorId = Convert.ToInt32(txtAdvisorId.Text);

                // Validate data (additional validation can be added)
                if (studentId <= 0 || advisorId <= 0)
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
                        using (SqlCommand cmd = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@studentID", studentId);
                            cmd.Parameters.AddWithValue("@advisorID", advisorId);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "Student linked to advisor successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error linking student to advisor. Please try again.";
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