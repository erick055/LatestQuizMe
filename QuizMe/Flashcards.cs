using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq; // Make sure this 'using' is at the top
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuizMe_
{
    public partial class Flashcards : Form
    {
        // Your existing connection string
        SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;");

        private List<Flashcard> allFlashcards = new List<Flashcard>();
        private int currentCardIndex = 0;
        private DateTime? _filterDate = null;

        // This will hold the ID of the set we are studying
        private int? _studySetID = null;

        // --- CONSTRUCTOR 1: For Dashboard/Buttons ---
        public Flashcards()
        {
            InitializeComponent();
        }

        // --- CONSTRUCTOR 2: For Schedule ---
        public Flashcards(DateTime filterDate)
        {
            InitializeComponent();
            _filterDate = filterDate.Date;
        }

        // --- CONSTRUCTOR 3: For Study Sets ---
        public Flashcards(int studySetID)
        {
            InitializeComponent();
            _studySetID = studySetID;


            btnDelete.Visible = false;
        }

        private void Flashcards_Load(object sender, EventArgs e)
        {
            // Only delete expired cards if we are in "general" mode
            if (!_studySetID.HasValue)
            {
                DeleteExpiredFlashcards();
            }

            LoadFlashcardsFromDB();

            // Shuffle the cards for a better study session
            if (allFlashcards.Count > 0)
            {
                var rnd = new Random();
                allFlashcards = allFlashcards.OrderBy(c => rnd.Next()).ToList();
            }

            DisplayCurrentCard();
        }

        // --- THIS METHOD IS NOW FULLY UPDATED ---
        private void LoadFlashcardsFromDB()
        {
            allFlashcards.Clear();
            try
            {
                con.Open();

                // We add the 'Status' column to the query
                string query = "SELECT flashcard_id, question, answer, schedule_date, Status FROM Flashcards WHERE user_id = @user_id";

                // --- NEW LOGIC ---
                if (_studySetID.HasValue)
                {
                    // 1. If we are studying a set, load ONLY that set's cards
                    query += " AND StudySetID = @StudySetID";
                }
                else if (_filterDate.HasValue)
                {
                    // 2. This is your existing logic for the schedule
                    query += " AND CAST(schedule_date AS DATE) = @schedule_date_filter";
                }
                else
                {
                    // 3. If no set AND no date, load "general" cards (those not in any set)
                    query += " AND StudySetID IS NULL";
                }
                // --- END OF NEW LOGIC ---

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user_id", QuizMe_.SignIn.staticUserID);

                    // --- NEW LOGIC ---
                    if (_studySetID.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@StudySetID", _studySetID.Value);
                    }
                    else if (_filterDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@schedule_date_filter", _filterDate.Value);
                    }
                    // --- END OF NEW LOGIC ---

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allFlashcards.Add(new Flashcard
                            {
                                FlashcardId = Convert.ToInt32(reader["flashcard_id"]),
                                Question = reader["question"].ToString(),
                                Answer = reader["answer"].ToString(),
                                ScheduleDate = reader["schedule_date"] == DBNull.Value
                                            ? (DateTime?)null
                                            : Convert.ToDateTime(reader["schedule_date"]),

                                // Add the new Status property
                                Status = Convert.ToInt32(reader["Status"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading flashcards: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        // --- THIS METHOD CONTAINS FIX #1 ---
        private void DeleteExpiredFlashcards()
        {
            using (SqlConnection deleteCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;"))
            {
                try
                {
                    deleteCon.Open();

                    // --- THIS IS THE CORRECTED QUERY ---
                    // We compare the full schedule_date (including time) to the current full time (GETDATE())
                    string query = "DELETE FROM Flashcards WHERE user_id = @user_id AND schedule_date < GETDATE()";

                    using (SqlCommand cmd = new SqlCommand(query, deleteCon))
                    {
                        cmd.Parameters.AddWithValue("@user_id", QuizMe_.SignIn.staticUserID);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting expired cards: " + ex.Message);
                }
            }
        }

        // --- THIS METHOD IS NOW FULLY UPDATED ---
        private void DisplayCurrentCard()
        {
            // Check if we still have cards to study
            if (allFlashcards.Count > 0 && currentCardIndex < allFlashcards.Count)
            {
                // Safety check
                if (currentCardIndex >= allFlashcards.Count)
                {
                    currentCardIndex = allFlashcards.Count - 1;
                }

                Flashcard currentCard = allFlashcards[currentCardIndex];
                lblQuestion.Text = currentCard.Question;
                lblAnswer.Text = currentCard.Answer;
                lblAnswer.Visible = false;
                lblSeeAnswer.Visible = true;
                lblCardNo.Text = $"card {currentCardIndex + 1} of {allFlashcards.Count}";

                if (currentCard.ScheduleDate.HasValue)
                {
                    string timeString = currentCard.ScheduleDate.Value.ToString("hh:mm tt");
                    lblScheduledIdentifier.Text = $"📅 Scheduled for {timeString}";
                    lblScheduledIdentifier.Visible = true;
                }
                else
                {
                    lblScheduledIdentifier.Visible = false;
                }
            }
            else
            {
                // --- MODIFIED "DECK COMPLETE" MESSAGE ---
                if (_studySetID.HasValue)
                {
                    lblQuestion.Text = "Study session complete! You can close this form.";
                }
                else if (_filterDate.HasValue)
                {
                    lblQuestion.Text = "No flashcards scheduled for this day.";
                }
                else
                {
                    lblQuestion.Text = "No flashcards found.";
                }

                lblAnswer.Text = "";
                lblAnswer.Visible = false;
                lblSeeAnswer.Visible = false;
                lblCardNo.Text = "card 0 of 0";
                lblScheduledIdentifier.Visible = false;

                // Disable buttons when the deck is empty
                btnKnew.Enabled = false;
                btnDontKnow.Enabled = false;
            }
        }

        // --- This REPLACES 'prevBtn_Click' ---
        private void btnDontKnow_Click(object sender, EventArgs e)
        {
            if (allFlashcards.Count == 0 || currentCardIndex >= allFlashcards.Count) return;

            // Update status in DB to 1 (Learning)
            UpdateCardStatus(allFlashcards[currentCardIndex].FlashcardId, 1);
            allFlashcards[currentCardIndex].Status = 1;

            // Move this card to the end of the list to see it again
            Flashcard cardToReview = allFlashcards[currentCardIndex];
            allFlashcards.RemoveAt(currentCardIndex);
            allFlashcards.Add(cardToReview);

            // Display the next card (which is at the same index)
            DisplayCurrentCard();
        }

        // --- This REPLACES 'nextBtn_Click' ---
        private void btnKnew_Click(object sender, EventArgs e)
        {
            if (allFlashcards.Count == 0 || currentCardIndex >= allFlashcards.Count) return;

            // Update status in DB to 2 (Known)
            UpdateCardStatus(allFlashcards[currentCardIndex].FlashcardId, 2);
            allFlashcards[currentCardIndex].Status = 2; // Update local list

            // Move to the next card
            currentCardIndex++;

            // If we are in a study set, update the progress bar
            if (_studySetID.HasValue)
            {
                UpdateStudySetProgress();
            }

            DisplayCurrentCard();
        }

        // --- NEW METHOD ---
        private void UpdateCardStatus(int flashcardId, int status)
        {
            try
            {
                using (SqlConnection updateCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;"))
                {
                    string query = "UPDATE Flashcards SET Status = @Status WHERE FlashcardId = @FlashcardId AND user_id = @user_id";
                    using (SqlCommand cmd = new SqlCommand(query, updateCon))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@FlashcardId", flashcardId);
                        cmd.Parameters.AddWithValue("@user_id", QuizMe_.SignIn.staticUserID);
                        updateCon.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update card status: " + ex.Message);
            }
        }

        // --- NEW METHOD ---
        private void UpdateStudySetProgress()
        {
            if (!_studySetID.HasValue) return;

            try
            {
                // 1. Calculate progress from our local list
                int totalCards = allFlashcards.Count;
                if (totalCards == 0) return;

                // Count all cards that are marked as "Known" (Status = 2)
                int knownCards = allFlashcards.Count(c => c.Status == 2);

                // 2. Calculate percentage
                int progress = (int)(((double)knownCards / totalCards) * 100);

                // 3. Update the StudySets table in the database
                using (SqlConnection progressCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;"))
                {
                    string query = "UPDATE StudySets SET Progress = @Progress WHERE StudySetID = @StudySetID AND UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, progressCon))
                    {
                        cmd.Parameters.AddWithValue("@Progress", progress);
                        cmd.Parameters.AddWithValue("@StudySetID", _studySetID.Value);
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        progressCon.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update study set progress: " + ex.Message);
            }
        }

        // --- Your existing navigation buttons ---
        private void btnSet_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.Show();
        }

        private void btnProg_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSched_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            this.Hide();
            schedule.Show();
        }

        private void btnQui_Click(object sender, EventArgs e)
        {
            Quizzes quizzes = new Quizzes();
            this.Hide();
            quizzes.Show();
        }

        private void btnFla_Click(object sender, EventArgs e)
        {
            // Already here
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Dashboard2 dashboard = new Dashboard2();
            this.Hide();
            dashboard.Show();
        }

        private void createFlashcardButton_Click(object sender, EventArgs e)
        {
            CreateFlashcard createFlashcard;

            if (_studySetID.HasValue)
            {
                // --- NEW ---
                // If we are in "study mode", pass the active Study Set ID
                createFlashcard = new CreateFlashcard(_studySetID.Value);
            }
            else
            {
                // This is the normal behavior
                createFlashcard = new CreateFlashcard();
            }

            this.Hide();
            createFlashcard.Show();
        }

        private void lblSeeAnswer_Click(object sender, EventArgs e)
        {
            lblAnswer.Visible = true;
            lblSeeAnswer.Visible = false;
        }

        // This is your existing delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (allFlashcards.Count == 0)
            {
                MessageBox.Show("There are no flashcards to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to permanently delete this flashcard?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int cardIdToDelete = allFlashcards[currentCardIndex].FlashcardId;
                    using (SqlConnection deleteCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;"))
                    {
                        deleteCon.Open();
                        string query = "DELETE FROM Flashcards WHERE flashcard_id = @flashcard_id AND user_id = @user_id";
                        using (SqlCommand cmd = new SqlCommand(query, deleteCon))
                        {
                            cmd.Parameters.AddWithValue("@flashcard_id", cardIdToDelete);
                            cmd.Parameters.AddWithValue("@user_id", QuizMe_.SignIn.staticUserID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    allFlashcards.RemoveAt(currentCardIndex);
                    DisplayCurrentCard();
                    MessageBox.Show("Flashcard deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting flashcard: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // This is your existing (but unused?) button
        private void button11_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = "";
        }

        // --- THIS CLASS IS NOW UPDATED ---
        public class Flashcard
        {
            public int FlashcardId { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public DateTime? ScheduleDate { get; set; }

            // Add the new Status property
            public int Status { get; set; } // 0=New, 1=Learning, 2=Known
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            StudySets studySets = new StudySets();
            this.Hide();
            studySets.Show();
        }

        private void btnGlo_Click(object sender, EventArgs e)
        {
            GlossaryForm glossaryForm = new GlossaryForm();
            this.Hide();
            glossaryForm.Show();
        }
    }
}