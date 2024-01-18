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
    public partial class ViewPaymentStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                string query = "SELECT * FROM Student_Payment";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();


                    connection.Open();
                    dataAdapter.Fill(dataTable);


                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }
    }
}