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
    public partial class ViewSemestersOfferedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                // Connection string (replace with your actual connection string)
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Semster_offered_Courses", conn))
                    {
                        conn.Open();

                        // Execute the query
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the result to GridView
                        GridViewSemesters.DataSource = dt;
                        GridViewSemesters.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
        }
    }
}