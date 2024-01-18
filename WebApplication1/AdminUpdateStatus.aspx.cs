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
    public partial class AdminUpdateStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            int studentId;
            if (int.TryParse(txtStudentID.Text, out studentId))
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("Procedure_AdminUpdateStudentStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@student_id", studentId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblResult.Text = "Student status updated successfully!";
                        }
                        else
                        {
                            lblError.Text = "Insert a valid id";
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error updating student status: " + ex.Message;
                    }
                }
            }
            else
            {
                lblError.Text = "Please enter a valid student ID.";
            }
        }
    }
}