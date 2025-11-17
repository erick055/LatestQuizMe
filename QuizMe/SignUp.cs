using System;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace QuizMe_
{
    public partial class SignUp : Form
    {
        // Connection string to your database
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";

        public SignUp()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) // Note: Your button seems to be named btnLogin
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.");
                return;
            }

            // --- Database Logic ---
            try
            {
                // 1. Hash the password
                string passwordHash = PasswordHelper.HashPassword(password);

                // 2. Create SQL connection and command
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // 3. Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        // 4. Execute the command
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sign up successful! You can now log in.");

                SignIn signInForm = new SignIn();
                signInForm.Show();
                this.Hide();
            }
            catch (SqlException ex)
            {
                // Handle errors, like a duplicate username
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    MessageBox.Show("This username is already taken. Please choose another.");
                }
                else
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            this.Hide();
            signin.Show();
        }
    }
}