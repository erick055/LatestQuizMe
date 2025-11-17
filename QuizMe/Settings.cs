using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class Settings : Form
    {
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";
        public Settings()
        {
            InitializeComponent();
        }



        private void btnSched_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            this.Hide();

            schedule.Show();
        }

        private void btnProg_Click(object sender, EventArgs e)
        {
            

        }

        private void btnQui_Click(object sender, EventArgs e)
        {
            Quizzes quizzes = new Quizzes();
            this.Hide();

            quizzes.Show();
        }

        private void btnFla_Click(object sender, EventArgs e)
        {
            Flashcards flashcards = new Flashcards();
            this.Hide();

            flashcards.Show();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Dashboard2 dashboard2 = new Dashboard2();
            this.Hide();

            dashboard2.Show();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            StudySets studySets = new StudySets();
            this.Hide();
            studySets.Show();
        }

        private void txtBio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadUserSettings();

            // 2. Check for notifications
            CheckForScheduledItems();
        }
        private void LoadUserSettings()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Query to get all the new settings
                    string query = "SELECT Username, FullName, Bio, PushNotificationsEnabled, SoundEffectsEnabled FROM Users WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Set the label text to the user's registered name
                            lblUsername.Text = reader["Username"].ToString();

                            // Load the FullName, Bio, and checkbox settings
                            lblFullName.Text = reader["FullName"] == DBNull.Value ? "" : reader["FullName"].ToString();
                            lblBio.Text = reader["Bio"] == DBNull.Value ? "" : reader["Bio"].ToString();

                            // Use default 'false' if the database value is NULL
                            chkPushNotifications.Checked = reader["PushNotificationsEnabled"] == DBNull.Value ? false : (bool)reader["PushNotificationsEnabled"];
                            chkSoundEffects.Checked = reader["SoundEffectsEnabled"] == DBNull.Value ? false : (bool)reader["SoundEffectsEnabled"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user settings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Query to update all the new fields
                    string query = @"UPDATE Users 
                                     SET FullName = @FullName, 
                                         Bio = @Bio, 
                                         PushNotificationsEnabled = @PushNotifications,
                                         SoundEffectsEnabled = @SoundEffects
                                     WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters (using DBNull.Value for empty text boxes)
                        cmd.Parameters.AddWithValue("@FullName", string.IsNullOrWhiteSpace(txtFullName.Text) ? (object)DBNull.Value : txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Bio", string.IsNullOrWhiteSpace(txtBio.Text) ? (object)DBNull.Value : txtBio.Text);
                        cmd.Parameters.AddWithValue("@PushNotifications", chkPushNotifications.Checked);
                        cmd.Parameters.AddWithValue("@SoundEffects", chkSoundEffects.Checked);
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckForScheduledItems()
        {
            // Only run this if the user has push notifications enabled
            if (!chkPushNotifications.Checked)
            {
                return;
            }

            int flashcardCount = 0;
            int quizCount = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1. Count scheduled flashcards for today
                    string flashcardQuery = "SELECT COUNT(*) FROM Flashcards WHERE user_id = @UserID AND CAST(schedule_date AS DATE) = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(flashcardQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        flashcardCount = (int)cmd.ExecuteScalar();
                    }

                    // 2. Count scheduled quizzes for today
                    string quizQuery = "SELECT COUNT(*) FROM Quizzes WHERE UserID = @UserID AND CAST(ScheduledDate AS DATE) = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(quizQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        quizCount = (int)cmd.ExecuteScalar();
                    }
                }

                // 3. Build and show the notification message
                if (flashcardCount > 0 || quizCount > 0)
                {
                    string message = "You have items scheduled for today!\n";
                    if (flashcardCount > 0)
                    {
                        message += $"\n• {flashcardCount} Flashcard(s)";
                    }
                    if (quizCount > 0)
                    {
                        message += $"\n• {quizCount} Quiz(zes)";
                    }
                    MessageBox.Show(message, "Schedule Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Show a non-critical error if the check fails
                Console.WriteLine("Failed to check for notifications: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form signInForm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form is SignIn)
                {
                    signInForm = form;
                    break;
                }
            }

            // 2. Show the SignIn form.
            if (signInForm != null)
            {
                signInForm.Show();
            }
            else
            {
                // As a fallback, if it was somehow closed, create a new one.
                SignIn newSignIn = new SignIn();
                newSignIn.Show();
            }

            // 3. Make a list of all forms to close (everything that is NOT SignIn)
            List<Form> formsToClose = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if (form is not SignIn)
                {
                    formsToClose.Add(form);
                }
            }

            // 4. Now, loop through the new list and close them.
            // This will close the current form (Settings) and all other hidden forms
            // (Dashboard, Quizzes, etc.).
            foreach (Form form in formsToClose)
            {
                form.Close();
            }
        }

        private void btnGlo_Click(object sender, EventArgs e)
        {
            GlossaryForm glossaryForm = new GlossaryForm();
            this.Hide();
            glossaryForm.Show();
        }
    }

}
