using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class QuizTakerForm : Form
    {
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";
        private int _quizID;

        // This list will hold all the questions from the DB
        private List<QuizQuestion> allQuestions = new List<QuizQuestion>();

        // This list will store the user's selected answers (e.g., "A", "C", "B")
        private List<string> userAnswers = new List<string>();

        private int currentQuestionIndex = 0;

        // A helper class to store one question
        private class QuizQuestion
        {
            public string QuestionText { get; set; }
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public string OptionC { get; set; }
            public string OptionD { get; set; }
            public string CorrectAnswer { get; set; } // "A", "B", "C", or "D"
        }

        public QuizTakerForm(int quizID)
        {
            InitializeComponent();
            _quizID = quizID;
        }
        private void SaveScoreToDatabase(int score, int totalQuestions)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO QuizResults 
                                     (QuizID, UserID, Score, TotalQuestions, DateTaken) 
                                     VALUES 
                                     (@QuizID, @UserID, @Score, @TotalQuestions, @DateTaken)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@QuizID", _quizID);
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID); // Using the static user ID
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@TotalQuestions", totalQuestions);
                        cmd.Parameters.AddWithValue("@DateTaken", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // It's good to log this, but maybe don't bother the user
                // MessageBox.Show("Could not save score: " + ex.Message); 
                Console.WriteLine("Error saving score: " + ex.Message);
            }
        }
        private void QuizTakerForm_Load(object sender, EventArgs e)
        {
            LoadQuestions();
            if (allQuestions.Count > 0)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                MessageBox.Show("This quiz has no questions! Please add questions first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadQuestions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectAnswer FROM QuizQuestions WHERE QuizID = @QuizID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@QuizID", _quizID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            allQuestions.Add(new QuizQuestion
                            {
                                QuestionText = reader["QuestionText"].ToString(),
                                OptionA = reader["OptionA"].ToString(),
                                OptionB = reader["OptionB"].ToString(),
                                OptionC = reader["OptionC"].ToString(),
                                OptionD = reader["OptionD"].ToString(),
                                CorrectAnswer = reader["CorrectAnswer"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading questions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (currentQuestionIndex < allQuestions.Count)
            {
                QuizQuestion q = allQuestions[currentQuestionIndex];

                lblQuestionNumber.Text = $"Question {currentQuestionIndex + 1} of {allQuestions.Count}";
                lblQuestionText.Text = q.QuestionText;
                rbOptionA.Text = q.OptionA;
                rbOptionB.Text = q.OptionB;
                rbOptionC.Text = q.OptionC;
                rbOptionD.Text = q.OptionD;

                // Clear any previous selection
                rbOptionA.Checked = false;
                rbOptionB.Checked = false;
                rbOptionC.Checked = false;
                rbOptionD.Checked = false;

                // Change button text on the last question
                if (currentQuestionIndex == allQuestions.Count - 1)
                {
                    btnNext.Text = "Finish";
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // 1. Record the user's answer
            string selectedAnswer = "";
            if (rbOptionA.Checked) selectedAnswer = "A";
            else if (rbOptionB.Checked) selectedAnswer = "B";
            else if (rbOptionC.Checked) selectedAnswer = "C";
            else if (rbOptionD.Checked) selectedAnswer = "D";

            if (string.IsNullOrEmpty(selectedAnswer))
            {
                MessageBox.Show("Please select an answer.", "Wait", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            userAnswers.Add(selectedAnswer);

            // 2. Move to the next question
            currentQuestionIndex++;

            if (currentQuestionIndex < allQuestions.Count)
            {
                // If there are more questions, display the next one
                DisplayCurrentQuestion();
            }
            else
            {
                // If that was the last question, grade the quiz
                CalculateAndShowScore();
            }
        }

        private void CalculateAndShowScore()
        {
            int score = 0;
            for (int i = 0; i < allQuestions.Count; i++)
            {
                if (userAnswers[i] == allQuestions[i].CorrectAnswer)
                {
                    score++;
                }
            }

            double percentage = ((double)score / allQuestions.Count) * 100;

            SaveScoreToDatabase(score, allQuestions.Count);

            MessageBox.Show($"Quiz Complete!\n\nYou scored: {score} out of {allQuestions.Count} ({percentage:F0}%)",
                "Quiz Results", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // Close the quiz form
        }
    }
}