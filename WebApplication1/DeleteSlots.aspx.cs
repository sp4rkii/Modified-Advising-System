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
    public partial class DeleteSlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDeleteSlots_Click(object sender, EventArgs e)
        {
            try
            {
                string currentSemester = txtSemester.Text.Trim();
                string connectionString = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Procedures_AdminDeleteSlots", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@current_semester", currentSemester);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblResult.Text = "Slot deleted successfully!";
                    }
                    else
                    {
                        lblError.Text = "Insert a valid id";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error deleting slot: " + ex.Message;
            }
        }
    }
}