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
    public partial class UpdateDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmClick(object sender, EventArgs e)
        {
            String formattedText;
            lblError1.Text = null;
            try
            {
                // Get form data



                DateTime date = Convert.ToDateTime(gradDate.Text);


                int Student_Id = Convert.ToInt32(studentid1.Text);
                // Validate data (additional validation can be added)
                if (date == DateTime.MinValue)
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Invalid inputs</h4>
                </div>";
                    lblError1.Text = formattedText;
                }
                else
                {
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("[Procedures_AdvisorUpdateGP]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@expected_grad_date", date);
                            cmd.Parameters.AddWithValue("@studentID", Student_Id);


                            conn.Open();

                            // Execute the stored procedure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>Updated Graduation Date Successfully!</h4>
                </div>";
                                lblError1.Text = formattedText;
                            }
                            else
                            {
                                formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Error Updating Date, Please Try Agian</h4>
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
        <h5>Please enter  valid inputs</h5>
    </div>";
                lblError1.Text = formattedText;
            }
        }
    }
}