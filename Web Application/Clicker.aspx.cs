using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application
{
    public partial class Clicker : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(FindUsername() == 0)
            {
                string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO Stats (username, lvl, points) VALUES (@UserName, 1, 0)"; ;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", FetchActiveUser());
                        command.ExecuteNonQuery();
                    }
                }
            }
            LevelNumber.Text = FetchLevel().ToString();
            LevelCost.Text = (FetchLevel()*FetchLevel() * 50).ToString();
            ScoreLabel.Text = FetchScore().ToString();
            if(FetchScore() >= FetchLevel()*FetchLevel()*50)
            {
                LevelButton.Enabled = true;
            }
            else
            {
                LevelButton.Enabled = false;
            }
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ClickButton_Click(object sender, EventArgs e)
        {
            UploadScore();
            ScoreLabel.Text = FetchScore().ToString();
        }

        protected void LevelButton_Click(object sender, EventArgs e)
        {
            if(FetchScore() >= FetchLevel()*FetchLevel()*50)
            {
                string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"UPDATE Stats SET lvl = @NewLevel, points = @NewPoints WHERE username = @UserName";
                    int newLevel = FetchLevel() + 1;
                    int newPoints = FetchScore() - FetchLevel()*FetchLevel()*50;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", FetchActiveUser());
                        command.Parameters.AddWithValue("@NewLevel", newLevel);
                        command.Parameters.AddWithValue("@NewPoints", newPoints);
                        command.ExecuteNonQuery();
                    }
                }
                Response.Redirect("Clicker.aspx");
            }
        }


        private int FetchScore()
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT points FROM Stats WHERE username = '{FetchActiveUser()}';";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private int FetchLevel()
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT lvl FROM Stats WHERE username = '{FetchActiveUser()}';";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private int FindUsername()
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM Stats WHERE username = '{FetchActiveUser()}';";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int counter = (int)command.ExecuteScalar();
                    return counter;
                }
            }
        }

        private string FetchActiveUser()
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT username FROM LoggedIn;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (string)command.ExecuteScalar();
                }
            }
        }

        private void UploadScore()
        {
            string connectionString = "Data Source=DESKTOP-UBN63ES\\SQLEXPRESS;Initial Catalog=WebFormsLabos;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE Stats SET points = @NewPoints WHERE username = @UserName";
                int newPoints = FetchScore() + FetchLevel();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", FetchActiveUser());
                    command.Parameters.AddWithValue("@NewPoints", newPoints);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}