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
    public partial class AddNewCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                string major = txtMajor.Text;
                int semester = Convert.ToInt32(txtSemester.Text);
                int creditHours = Convert.ToInt32(txtCreditHours.Text);
                string courseName = txtCourseName.Text;
                int isOffered = Convert.ToInt32(ddlIsOffered.SelectedValue);

                // Validate data (additional validation can be added)
                if (string.IsNullOrEmpty(major) || semester <= 0 || creditHours <= 0 || string.IsNullOrEmpty(courseName))
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
                        using (SqlCommand cmd = new SqlCommand("Procedures_AdminAddingCourse", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@major", major);
                            cmd.Parameters.AddWithValue("@semester", semester);
                            cmd.Parameters.AddWithValue("@credit_hours", creditHours);
                            cmd.Parameters.AddWithValue("@name", courseName);
                            cmd.Parameters.AddWithValue("@is_offered", isOffered);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "New course added successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error adding course. Please try again.";
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