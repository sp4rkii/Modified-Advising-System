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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                int id = Int16.Parse(username.Text);
                String password = pass.Text;
                SqlCommand loginproc = new SqlCommand("[FN_AdvisorLogin]", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@advisor_Id", id));
                loginproc.Parameters.Add(new SqlParameter("@password", password));

                SqlParameter bit = loginproc.Parameters.Add(new SqlParameter("RETURN_VALUE", SqlDbType.Bit));
                bit.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                loginproc.ExecuteNonQuery();
                conn.Close();
                String formattedText;
                if (bit.Value.ToString() == "True")
                {
                    Session["LoggedInAdvisorId"] = id;

                    Response.Redirect($"Course.aspx?advisor_Id={id}");
                }
                if (bit.Value.ToString() == "False")
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a valid User ID and Password</h4>
                </div>";
                    Literal1.Text = formattedText;
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                String formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>please enter a valid User Id</h4>
                </div>";
                Literal1.Text = formattedText;
            }
        }

        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Register1.aspx");
        }
    }
}