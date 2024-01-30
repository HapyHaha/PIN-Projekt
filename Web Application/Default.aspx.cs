using System;
using System.Data.SqlClient;

namespace Web_Application
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string fullName = txtFullName.Text;
            string password = txtPassword.Text;
            string repeatPassword = txtRepeatPassword.Text;

            if (password != repeatPassword)
            {
                lblErrorMessage.Text = "Passwords do not match.";
                return;
            }


            if (!UserExists(username))
            {
                if (RegisterUser(username, fullName, password))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Registration failed. Please try again.";
                }
            }
            else
            {
                lblErrorMessage.Text = "Username already exists. Please choose a different username.";
            }
        }

        private bool UserExists(string username)
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool RegisterUser(string username, string fullName, string password)
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (UserName, Password, FullName) VALUES (@UserName, @Password, @FullName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
