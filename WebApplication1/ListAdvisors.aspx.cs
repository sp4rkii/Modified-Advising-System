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
    public partial class ListAdvisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdvisorsData();
            }
        }

        private void BindAdvisorsData()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                {
                    using (SqlCommand cmd = new SqlCommand("[Procedures_AdminListAdvisors]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters if needed
                        // cmd.Parameters.AddWithValue("@ParameterName", parameterValue);

                        conn.Open();

                        // Execute the stored procedure
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the result to GridView
                        GridViewAdvisors.DataSource = dt;
                        GridViewAdvisors.DataBind();
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