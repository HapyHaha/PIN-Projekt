using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Web_Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM LoggedIn;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            
            if (ValidateUser(username, password))
            {
                string query1 = $"INSERT INTO LoggedIn (username) VALUES ('{txtUsername.Text}');";
                string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.ExecuteNonQuery();
                    }
                }
                Response.Redirect("~/Clicker.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid username or password.";
            }
        }

        private bool ValidateUser(string username, string password)
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";

            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
