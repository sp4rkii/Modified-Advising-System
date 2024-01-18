using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class Login : System.Web.UI.Page
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
                String id = username.Text;
                String password = pass.Text;
                String adminId = "admin";
                string adminPassword = "GUCadmin99";
                if (id == adminId && password == adminPassword)
                {
                    Response.Redirect("AdminDashBoard.aspx");
                }
                else
                {
                    String formattedText = $@"
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
                    <h4>please enter a valid User Id and Password</h4>
                </div>";
                Literal1.Text = formattedText;
            }
        }
    }
}