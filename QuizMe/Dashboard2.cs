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
    public partial class Dashboard2 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;");
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";
        public Dashboard2()
        {
            InitializeComponent();
        }



        private void flashcardsButton_Click(object sender, EventArgs e)
        {
            Flashcards flashcards = new Flashcards();
            this.Hide();

            flashcards.Show();
        }

        private void quizzesButton_Click(object sender, EventArgs e)
        {
            Quizzes quizzes = new Quizzes();
            this.Hide();

            quizzes.Show();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            this.Hide();

            schedule.Show();
        }

        private void progressButton_Click(object sender, EventArgs e)
        {
          
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();

            settings.Show();
        }



        private void Dashboard2_Load(object sender, EventArgs e)
        {
            DashboardName();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            StudySets studyForm = new StudySets();
            studyForm.Show();
        }

        private void glossaryButton_Click(object sender, EventArgs e)
        {
            GlossaryForm glossaryForm = new GlossaryForm();
            this.Hide();
            glossaryForm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void DashboardName()
        {
            // Add try...catch for robust error handling
            try
            {
                // The 'using' block will automatically close the connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT Username FROM Users WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // 1. Assign the username to the label's Text property.
                            welcomeLabel.Text = "Welcome back, " + reader["Username"].ToString();

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error if the name can't be loaded
                MessageBox.Show("Error loading user name: " + ex.Message);
            }
        }
    }
}
