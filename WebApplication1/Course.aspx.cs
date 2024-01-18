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
    public partial class Course : System.Web.UI.Page
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
                    lblAdvisorId.Text = $"Advisor ID: {advisorId}";
                    GetAdvisorDetails(advisorId);
                }
                else
                {
                    // Handle the case when advisor_Id is not present in the session
                    Response.Redirect("Login1.aspx"); // Redirect to login page or handle appropriately
                }
            }
        }
        private void GetAdvisorDetails(int advisorId)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Assuming the columns in the Advisor table are named advisor_Name, advisor_Email, advisor_Office
                    SqlCommand cmd = new SqlCommand("SELECT advisor_name, email, office FROM Advisor WHERE advisor_Id = @AdvisorId", conn);
                    cmd.Parameters.AddWithValue("@AdvisorId", advisorId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string advisorName = reader["advisor_name"].ToString();
                        string advisorEmail = reader["email"].ToString();
                        string advisorOffice = reader["office"].ToString();

                        // Display the advisor details as needed
                        lblAdvisorName.Text = $"Name: {advisorName}";
                        lblAdvisorEmail.Text = $"Email: {advisorEmail}";
                        lblAdvisorOffice.Text = $"Office: {advisorOffice}";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("HELLO");
                // Handle exceptions
                // Log or display an error message
            }
        }
    }

}
