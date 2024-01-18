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
    public partial class AddNewSemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSemester_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime endDate = Convert.ToDateTime(txtEndDate.Text);
                string semesterCode = txtSemesterCode.Text;

                // Validate data (additional validation can be added)
                if (startDate == DateTime.MinValue || endDate == DateTime.MinValue || string.IsNullOrEmpty(semesterCode))
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
                        using (SqlCommand cmd = new SqlCommand("AdminAddingSemester", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@start_date", startDate);
                            cmd.Parameters.AddWithValue("@end_date", endDate);
                            cmd.Parameters.AddWithValue("@semester_code", semesterCode);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "New semester added successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error adding semester. Please try again.";
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