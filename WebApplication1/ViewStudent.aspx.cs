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
    public partial class ViewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    // Check if the session variable is not null
                    if (Session["LoggedInAdvisorId"] != null)
                    {
                        int advisorId = Convert.ToInt32(Session["LoggedInAdvisorId"]);
                        // Use advisorId as needed, for example, display it in a label
                        BindAdvisorsData(advisorId);
                    }
                    else
                    {
                        // Handle the case when advisor_Id is not present in the session
                        Response.Redirect("Login1.aspx"); // Redirect to login page or handle appropriately
                    }
                }
            }
        }

        private void BindAdvisorsData(int advisor_Id)
        {
            try
            {
                String formattedText;
                lblError1.Text = null;
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT student_id ,f_name ,l_name , faculty , email , major ,financial_status ,semester ,acquired_hours , assigned_hours  FROM Student Where advisor_Id = @AdvisorId", conn))

                    {
                        cmd.Parameters.AddWithValue("@AdvisorId", advisor_Id);
                        cmd.CommandType = CommandType.Text;

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
                        if (dt.Rows.Count == 0)
                        {
                            formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>You do not have any Assigned Students Currently</h4>
                </div>";
                            lblError1.Text = formattedText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Hello");
                // Handle exceptions if necessary
                // You may display an error message or log the exception
            }
        }

    }
}