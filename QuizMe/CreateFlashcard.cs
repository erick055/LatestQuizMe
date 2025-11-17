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
using static QuizMe_.Flashcards;

namespace QuizMe_
{
    public partial class CreateFlashcard : Form
    {
        SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;");

        private List<StudySetItem> studySets = new List<StudySetItem>();

        private int? _preselectedStudySetID = null;
        public CreateFlashcard()
        {
            InitializeComponent();
            LoadStudySets();
        }
        public CreateFlashcard(int studySetID)
        {
            InitializeComponent();
            _preselectedStudySetID = studySetID; // Store the passed-in ID
            LoadStudySets(); // Load the sets
        }
        private class StudySetItem
        {
            public int StudySetID { get; set; }
            public string Title { get; set; }
            public override string ToString()
            {
                return Title;
            }
        }

        // --- FIX #1 IS IN THIS METHOD ---
        private void LoadStudySets()
        {
            try
            {
                // (All your existing code to load 'studySets' from the database...)
                cmbStudySets.DataSource = null;
                studySets.Clear();
                studySets.Add(new StudySetItem { StudySetID = 0, Title = "None (General Flashcard)" });
                string query = "SELECT StudySetID, Title FROM StudySets WHERE UserID = @UserID";
                using (SqlConnection studySetCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, studySetCon))
                    {
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        studySetCon.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            studySets.Add(new StudySetItem
                            {
                                StudySetID = (int)reader["StudySetID"],
                                Title = reader["Title"].ToString()
                            });
                        }
                    }
                }

                // --- REPLACE the end of this method with this ---
                cmbStudySets.DataSource = studySets;
                cmbStudySets.DisplayMember = "Title";
                cmbStudySets.ValueMember = "StudySetID";

                if (_preselectedStudySetID.HasValue)
                {
                    // Find and select the item that matches the pre-selected ID
                    StudySetItem itemToSelect = studySets.FirstOrDefault(item => item.StudySetID == _preselectedStudySetID.Value);
                    if (itemToSelect != null)
                    {
                        cmbStudySets.SelectedItem = itemToSelect;
                    }
                }
                else
                {
                    // Default to "None"
                    cmbStudySets.SelectedIndex = 0;
                }
                // --- END of replacement ---
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading study sets: " + ex.Message);
            }
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            Flashcards flashcards;
            if (_preselectedStudySetID.HasValue)
            {
                // --- NEW ---
                // Go back to the specific study set we were in
                flashcards = new Flashcards(_preselectedStudySetID.Value);
            }
            else
            {
                // This is the normal behavior
                flashcards = new Flashcards();
            }

            this.Hide();
            flashcards.Show();
        }

        // --- FIX #2 IS IN THIS METHOD ---
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) || string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("Please enter both a question and an answer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();
                string query = "INSERT INTO Flashcards (user_id, question, answer, schedule_date, StudySetID, Status) VALUES (@user_id, @question, @answer, @schedule_date, @StudySetID, 0)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user_id", QuizMe_.SignIn.staticUserID);
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text);
                    cmd.Parameters.AddWithValue("@answer", txtAnswer.Text);
                    cmd.Parameters.AddWithValue("@schedule_date", dtpScheduleDate.Value);

                    StudySetItem selectedSet = (StudySetItem)cmbStudySets.SelectedItem;

                    // --- THIS IS THE FIX ---
                    // We check if selectedSet is null BEFORE we use it
                    if (selectedSet == null)
                    {
                        MessageBox.Show("Error: No study set was selected. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        con.Close(); // Close connection before returning
                        return; // Stop the method
                    }
                    // --- END OF FIX ---

                    if (selectedSet.StudySetID == 0)
                    {
                        cmd.Parameters.AddWithValue("@StudySetID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@StudySetID", selectedSet.StudySetID);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Flashcard saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtQuestion.Clear();
                txtAnswer.Clear();
                dtpScheduleDate.Value = DateTime.Now;
                cmbStudySets.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}