using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class Schedule : Form
    {
        int month, year;
        SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;");

        // --- CHANGED (Step 1) ---
        // We create a helper class to store a
        private class ScheduledEvent
        {
            public DateTime EventTime { get; set; }
            public string EventType { get; set; } // "Flashcard" or "Quiz"
        }

        // --- CHANGED (Step 2) ---
        // The dictionary now stores the new ScheduledEvent object
        Dictionary<DateTime, List<ScheduledEvent>> scheduledEvents = new Dictionary<DateTime, List<ScheduledEvent>>();


        public Schedule()
        {
            InitializeComponent();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            displayDays();
        }


        // --- CHANGED (Step 3) ---
        // This method is updated to be simpler and store the event type.
        private void LoadScheduledDates(int year, int month)
        {
            scheduledEvents.Clear();
            try
            {
                con.Open();

                // This query gets ALL events, their times, and their types
                string query = @"
            SELECT CAST(schedule_date AS DATE) as schedule_day, schedule_date as event_time, 'Flashcard' as event_type
            FROM Flashcards 
            WHERE user_id = @user_id AND YEAR(schedule_date) = @year AND MONTH(schedule_date) = @month
            
            UNION ALL 
            
            SELECT CAST(ScheduledDate AS DATE) as schedule_day, ScheduledDate as event_time, 'Quiz' as event_type
            FROM Quizzes 
            WHERE UserID = @user_id AND YEAR(ScheduledDate) = @year AND MONTH(ScheduledDate) = @month
            
            ORDER BY schedule_day ASC, event_time ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user_id", SignIn.staticUserID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@month", month);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime day = Convert.ToDateTime(reader["schedule_day"]);
                            DateTime eventTime = Convert.ToDateTime(reader["event_time"]);
                            string eventType = reader["event_type"].ToString();

                            // If this is the first event for this day, create the list
                            if (!scheduledEvents.ContainsKey(day))
                            {
                                scheduledEvents[day] = new List<ScheduledEvent>();
                            }

                            // Add this event to this day's list
                            scheduledEvents[day].Add(new ScheduledEvent { EventTime = eventTime, EventType = eventType });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        // --- CHANGED (Step 4) ---
        // Updated to use the new scheduledEvents dictionary
        private void displayDays()
        {
            flpDayContainer.Controls.Clear();

            DateTime now = DateTime.Now;
            if (month == 0) month = now.Month;
            if (year == 0) year = now.Year;

            LoadScheduledDates(year, month);

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime StartOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int daysofWeek = Convert.ToInt32(StartOfTheMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysofWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                flpDayContainer.Controls.Add(ucBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);

                DateTime currentDay = new DateTime(year, month, i);
                ucDays.Tag = currentDay;
                ucDays.ClearEvents(); // <-- Call our new reset method

                // Check if this day has any events in the dictionary
                if (scheduledEvents.ContainsKey(currentDay.Date))
                {
                    // Get the list of all events for this day
                    List<ScheduledEvent> eventsToday = scheduledEvents[currentDay.Date];

                    // Find the first flashcard event (if any)
                    var flashcardEvent = eventsToday.FirstOrDefault(e => e.EventType == "Flashcard");
                    if (flashcardEvent != null)
                    {
                        ucDays.SetFlashcardEvent(flashcardEvent.EventTime.ToString("hh:mm tt"));
                    }

                    // Find the first quiz event (if any)
                    var quizEvent = eventsToday.FirstOrDefault(e => e.EventType == "Quiz");
                    if (quizEvent != null)
                    {
                        ucDays.SetQuizEvent(quizEvent.EventTime.ToString("hh:mm tt"));
                    }
                }

                ucDays.Click += UcDays_Click;
                flpDayContainer.Controls.Add(ucDays);
            }
        }

        // --- CHANGED (Step 5) ---
        // This click event now correctly opens the Flashcard or Quiz form
        private void UcDays_Click(object sender, EventArgs e)
        {
            UserControlDays ucDay = (UserControlDays)sender;
            DateTime clickedDate = ((DateTime)ucDay.Tag).Date;

            // Check if this date has any events
            if (scheduledEvents.ContainsKey(clickedDate))
            {
                List<ScheduledEvent> eventsToday = scheduledEvents[clickedDate];

                // Get the unique types of events
                var eventTypes = eventsToday.Select(ev => ev.EventType).Distinct().ToList();

                // Case 1: Both "Flashcard" and "Quiz"
                if (eventTypes.Count > 1)
                {
                    MessageBox.Show("You have multiple items scheduled. Opening flashcards first.", "Multiple Events", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Flashcards viewDayCards = new Flashcards(clickedDate);
                    viewDayCards.ShowDialog();
                    displayDays(); // Refresh calendar
                }
                // Case 2: Only "Flashcard"
                else if (eventTypes.Contains("Flashcard"))
                {
                    Flashcards viewDayCards = new Flashcards(clickedDate);
                    viewDayCards.ShowDialog();
                    displayDays(); // Refresh calendar
                }
                // Case 3: Only "Quiz"
                else if (eventTypes.Contains("Quiz"))
                {
                    Quizzes quizzesForm = new Quizzes();
                    this.Hide();
                    quizzesForm.Show();
                }
            }
            // else: user clicked an empty day, do nothing
        }




        private void btnNext_Click(object sender, EventArgs e)
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            displayDays();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }
            displayDays();
        }

        private void button7_Click(object sender, EventArgs e)
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
            // Already on this form
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
            Dashboard2 dashboard = new Dashboard2();
            this.Hide();
            dashboard.Show();
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