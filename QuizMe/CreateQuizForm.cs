using System;
using System.Data.SqlClient; // Required for database operations
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class CreateQuizForm : Form
    {
        // Connection string (use your existing one)
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";

        // Property to indicate if a quiz was successfully created
        public bool QuizCreatedSuccessfully { get; private set; } = false;
        public int NewQuizID { get; private set; } // To store the ID of the newly created quiz

        public CreateQuizForm()
        {
            InitializeComponent();
        }

        // This was an empty method, so I removed its contents
        private void btnSaveQuiz_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Simply close the form
        }

        private void btnSaveQuiz_Click_1(object sender, EventArgs e)
        {
            string title = txtQuizTitle.Text.Trim();
            string description = txtQuizDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title for the quiz.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // This query is correct
                    string query = @"INSERT INTO Quizzes (UserID, Title, Description, CreatedDate, ScheduledDate) 
                                     VALUES (@UserID, @Title, @Description, @CreatedDate, @ScheduledDate)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                        // This correctly saves the date from your DateTimePicker
                        cmd.Parameters.AddWithValue("@ScheduledDate", dtpScheduledDate.Value);

                        cmd.ExecuteNonQuery();
                        QuizCreatedSuccessfully = true;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                QuizCreatedSuccessfully = false; // Make sure we set this to false on error
                MessageBox.Show("Error creating quiz: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This was an empty method, so I removed its contents
        private void CreateQuizForm_Load(object sender, EventArgs e)
        {
        }

        // This was an empty method, so I removed its contents
        private void chkEnableSchedule_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}