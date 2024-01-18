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
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void register(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String name = username.Text;
            String mail = email.Text;
            String office = location.Text;
            String password = pass.Text;
            String formattedText;
            if (string.IsNullOrWhiteSpace(name))
            {
                formattedText = $@"
            <script>
            alert('please enter a name');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(mail))
            {
                formattedText = $@"
            <script>
            alert('please enter an email');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(office))
            {
                formattedText = $@"
            <script>
            alert('please enter an office');
            </script>";
                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(password))
            {
                formattedText = $@"
            <script>
            alert('please enter a password');
            </script>";
                Response.Write(formattedText);
                return;

            }

            SqlCommand signup = new SqlCommand("[Procedures_AdvisorRegistration]", conn);
            signup.CommandType = CommandType.StoredProcedure;
            signup.Parameters.Add(new SqlParameter("@advisor_name", name));
            signup.Parameters.Add(new SqlParameter("@password", password));
            signup.Parameters.Add(new SqlParameter("@email", mail));
            signup.Parameters.Add(new SqlParameter("@office", office));

            SqlParameter id = signup.Parameters.Add(new SqlParameter("@Advisor_id", SqlDbType.Int));
            id.Direction = ParameterDirection.Output;

            conn.Open();
            signup.ExecuteNonQuery();
            conn.Close();
            int advisorId = Convert.ToInt32(id.Value);
            formattedText = $@"
         <script>
    var username = '{name}';
    var userId = '{advisorId}';
    var alertMessage = 'Welcome, ' + username + '!\nYour user ID is: ' + userId + '\nThank you for registering with us.' + '\nPlease log in below.';
    alert(alertMessage);
    window.location.href = 'Login1.aspx';
</script>";

            RegistrationResponseLiteral.Text = formattedText;

            // Use Response.Write to output the HTML




        }
        protected void login(object sender, EventArgs e)
        {
            Response.Redirect("Login1.aspx");
        }
    }
}