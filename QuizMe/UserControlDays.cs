using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class UserControlDays : UserControl
    {
        public UserControlDays()
        {
            InitializeComponent();
        }

        // This sets the day number (e.g., "1", "15")
        public void days(int numday)
        {
            lbDays.Text = numday.ToString();
        }

        // --- NEW METHODS ---

        // Call this to reset the control before use
        public void ClearEvents()
        {
            lblFlashcard.Visible = false;
            lblQuiz.Visible = false;
            this.BackColor = Color.White; // Reset background color
        }

        // Call this if a flashcard is scheduled for this day
        public void SetFlashcardEvent(string time)
        {
            lblFlashcard.Text = $"Flashcard: {time}";
            lblFlashcard.Visible = true;
            this.BackColor = Color.LightCyan; // Give the day a slight tint
        }

        // Call this if a quiz is scheduled for this day
        public void SetQuizEvent(string time)
        {
            lblQuiz.Text = $"Quiz: {time}";
            lblQuiz.Visible = true;
            this.BackColor = Color.LightCyan; // Give the day a slight tint
        }

    }
}