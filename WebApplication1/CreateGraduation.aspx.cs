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
    public partial class CreateGraduation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmClick(object sender, EventArgs e)
        {
            String formattedText;
            try
            {
                // Get form data


                int creditHours = Convert.ToInt32(txtCreditHours.Text);
                string semester = txtSemester.Text;
                int Student_Id = Convert.ToInt32(studentid.Text);
                DateTime date = Convert.ToDateTime(gradDate.Text);
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

                if (string.IsNullOrEmpty(semester) || creditHours <= 0 || date == DateTime.MinValue)
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>please enter valid inputs</h4>
                </div>";
                    lblError1.Text = formattedText;
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorCreateGP]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@Semester_code", semester);
                            cmd.Parameters.AddWithValue("@expected_graduation_date", date);
                            cmd.Parameters.AddWithValue("@sem_credit_hours", creditHours);
                            cmd.Parameters.AddWithValue("@student_id", Student_Id);
                            cmd.Parameters.AddWithValue("@advisor_id", advisorId);

                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>Created Graduation Plan Successfully!</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                            else
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Student does not have enough Assigned Hours.</h4>
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
                    <h4>please enter valid inputs</h4>
                </div>";
                lblError1.Text = formattedText;

            }
        }
    }
}