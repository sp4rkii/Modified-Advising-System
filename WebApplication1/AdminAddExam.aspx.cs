using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class AdminAddExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddExam_Click(object sender, EventArgs e)
        {
            try
            {
                // Get form data
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                int courseId = Convert.ToInt32(txtCourseID.Text);
                string Type = txtType.Text;

                // Validate data (additional validation can be added)
                if (Date == DateTime.MinValue || string.IsNullOrEmpty(Type) || !int.TryParse(txtCourseID.Text, out courseId))
                {
                    lblError.Text = "One of the inputs is empty or invalid. Please fill out all fields.";
                    lblResult.Text = "";
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Procedures_AdminAddExam", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Type", Type);
                            cmd.Parameters.AddWithValue("@date", Date);
                            cmd.Parameters.AddWithValue("@courseID", courseId);

                            conn.Open();

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                lblResult.Text = "New Exam added successfully!";
                                lblError.Text = "";
                            }
                            else
                            {
                                lblError.Text = "Error adding Exam. Please try again.";
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