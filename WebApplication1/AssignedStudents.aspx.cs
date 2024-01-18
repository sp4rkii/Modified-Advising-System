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
    public partial class AssignedStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmClick(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = null;
                lblError1.Text = null;
                String formattedText;
                // Get form data
                string major = Txtmajor.Text;
                int advisorId = 0;
                if (Session["LoggedInAdvisorId"] != null)
                {
                    advisorId = Convert.ToInt32(Session["LoggedInAdvisorId"]);
                    // Use advisorId as needed, for example, display it in a label
                }
                else
                {
                    // Handle the case when advisor_Id is not present in the session
                    Response.Redirect("Login1.aspx"); // Redirect to the login page or handle appropriately
                }

                // Validate data (additional validation can be added)
                if (string.IsNullOrEmpty(major))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>One of the inputs is empty or invalid. Please fill out all fields.</h4>
                </div>";
                    lblError.Text = formattedText;
                    GridViewAdvisors.DataSource = null;
                    GridViewAdvisors.DataBind();
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorViewAssignedStudents]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@major", major);
                            cmd.Parameters.AddWithValue("@AdvisorID", advisorId);

                            conn.Open();

                            // Execute the stored procedure
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the result to GridView
                            GridViewAdvisors.DataSource = dt;
                            GridViewAdvisors.DataBind();
                            if (dt.Rows.Count == 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>No Assigned Students Taking This Major</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
