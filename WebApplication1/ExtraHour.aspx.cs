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
    public partial class ExtraHour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmClick(object sender, EventArgs e)
        {
            string formattedText;
            lblError1.Text = null;
            string Current_Semester = null;
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Assuming the columns in the Advisor table are named advisor_Name, advisor_Email, advisor_Office
                    SqlCommand cmd = new SqlCommand("SELECT semester_code FROM Semester WHERE GETDATE() BETWEEN start_date AND end_date;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Current_Semester = reader["semester_code"].ToString();

                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("No current Semester Registered");
                // Handle exceptions
                // Log or display an error message
            }


            try
            {
                // Get form data




                int Request = Convert.ToInt32(request.Text);

                // Validate data (additional validation can be added)
                if (string.IsNullOrEmpty(Current_Semester))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h6>Current Semester Code Not Found in Database</h6>
                </div>";
                    lblError1.Text = formattedText;
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorApproveRejectCHRequest]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@requestID", Request);
                            cmd.Parameters.AddWithValue("@current_sem_code", Current_Semester);


                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>Request Updated!</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                            else
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Error Updating Request, try again</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>please enter a valid request Id</h4>
                </div>";
                lblError1.Text = formattedText;
            }
        }
    }
}