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
    public partial class ViewRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        private void BindAdvisorsData(int advisor_Id)
        {
            lblError1.Text = null;
            String formattedText;
            try
            {


                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [FN_Advisors_Requests](@AdvisorId)", conn))
                    {

                        cmd.Parameters.AddWithValue("@AdvisorId", advisor_Id); // Corrected parameter name

                        conn.Open();

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
                        <h4>No Requests Currently</h4>
                    </div>";
                            lblError1.Text = formattedText;

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                // Log or display an error message
                formattedText = $@"
        <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
            <h4>An error occurred: {ex.Message}</h4>
        </div>";
                lblError1.Text = formattedText;
                Response.Write($"An error occurred: {ex.Message}");
            }
        }
    }
}
