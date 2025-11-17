using iText.Kernel.Pdf;
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
    public partial class UploadStudySetForm : Form
    {
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuizMeDB;Trusted_Connection=True;";

        // This will hold the PDF data
        private byte[] pdfData;
        private string selectedFileName;

        public bool IsUploadSuccessful { get; private set; } = false;
        public UploadStudySetForm()
        {
            InitializeComponent();
        }

        private void btnSelectPdf_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedFileName = openFileDialog1.FileName;
                    pdfData = File.ReadAllBytes(selectedFileName);
                    lblFileName.Text = Path.GetFileName(selectedFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pdfData = null;
                    lblFileName.Text = "No file selected.";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a Title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please enter a Subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pdfData == null || pdfData.Length == 0)
            {
                MessageBox.Show("Please select a PDF file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Save to Database ---
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO StudySets (UserID, Title, Subject, PdfData, Progress) VALUES (@UserID, @Title, @Subject, @PdfData, 0)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Use the static user ID from your SignIn class
                        cmd.Parameters.AddWithValue("@UserID", QuizMe_.SignIn.staticUserID);
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                        cmd.Parameters.AddWithValue("@PdfData", pdfData);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                IsUploadSuccessful = true; // Set flag
                this.Close(); // Close this form
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsUploadSuccessful = false;
            }
        }
    }
    
}
