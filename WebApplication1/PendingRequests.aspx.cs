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
    public partial class PendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRequestsData();
            }
        }

        private void BindRequestsData()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from Request where status = 'Pending'", conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        // Execute the stored procedure
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the result to GridView
                        GridViewRequests.DataSource = dt;
                        GridViewRequests.DataBind();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                // You may display an error message or log the exception
            }
        }
    }
}