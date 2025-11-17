using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class AddQuestionsForm : Form
    {
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";
        private int _quizID; // This stores the quiz we are adding to

        // This new constructor *requires* a QuizID
        public AddQuestionsForm(int quizID)
        {
            InitializeComponent();
            _quizID = quizID;
            this.Text = "Add Questions to Quiz"; // Set the window title
        }

        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) ||
                string.IsNullOrWhiteSpace(txtOptionA.Text) || string.IsNullOrWhiteSpace(txtOptionB.Text) ||
                string.IsNullOrWhiteSpace(txtOptionC.Text) || string.IsNullOrWhiteSpace(txtOptionD.Text) ||
                string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string correctAnswer = txtAnswer.Text.ToUpper();
            if (correctAnswer != "A" && correctAnswer != "B" && correctAnswer != "C" && correctAnswer != "D")
            {
                MessageBox.Show("The answer must be 'A', 'B', 'C', or 'D'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO QuizQuestions (QuizID, QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) " +
                                   "VALUES (@QuizID, @Question, @A, @B, @C, @D, @Answer)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@QuizID", _quizID); // Use the ID
                        cmd.Parameters.AddWithValue("@Question", txtQuestion.Text);
                        cmd.Parameters.AddWithValue("@A", txtOptionA.Text);
                        cmd.Parameters.AddWithValue("@B", txtOptionB.Text);
                        cmd.Parameters.AddWithValue("@C", txtOptionC.Text);
                        cmd.Parameters.AddWithValue("@D", txtOptionD.Text);
                        cmd.Parameters.AddWithValue("@Answer", correctAnswer);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Question saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear text boxes for the next question
                txtQuestion.Clear();
                txtOptionA.Clear();
                txtOptionB.Clear();
                txtOptionC.Clear();
                txtOptionD.Clear();
                txtAnswer.Clear();
                txtQuestion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving question: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close(); // Just close the form
        }
    }
}