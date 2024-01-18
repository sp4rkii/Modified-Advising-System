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
    public partial class AdminInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIssueInstallment_Click(object sender, EventArgs e)
        {
            try
            {
                int paymentId = Convert.ToInt32(txtPaymentID.Text);

                string connectionString = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("Procedures_AdminIssueInstallment", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@payment_id", paymentId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblResult.Text = "Installmment issued successfully!";
                    }
                    else
                    {
                        lblError.Text = "Insert a valid id";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error issuing installments ";
            }
        }
    }
}