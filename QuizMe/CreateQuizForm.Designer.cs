namespace QuizMe_
{
    partial class CreateQuizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtQuizTitle = new TextBox();
            btnSaveQuiz = new Button();
            label2 = new Label();
            label3 = new Label();
            txtQuizDescription = new TextBox();
            btnCancel = new Button();
            dtpScheduledDate = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 27);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "Create New Quiz";
            // 
            // txtQuizTitle
            // 
            txtQuizTitle.Location = new Point(60, 113);
            txtQuizTitle.Name = "txtQuizTitle";
            txtQuizTitle.Size = new Size(236, 23);
            txtQuizTitle.TabIndex = 1;
            // 
            // btnSaveQuiz
            // 
            btnSaveQuiz.Location = new Point(80, 333);
            btnSaveQuiz.Name = "btnSaveQuiz";
            btnSaveQuiz.Size = new Size(203, 23);
            btnSaveQuiz.TabIndex = 2;
            btnSaveQuiz.Text = "Save Quiz & Add Questions";
            btnSaveQuiz.UseVisualStyleBackColor = true;
            btnSaveQuiz.Click += btnSaveQuiz_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 95);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Quiz Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 148);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 4;
            label3.Text = "Description (Optional):";
            // 
            // txtQuizDescription
            // 
            txtQuizDescription.Location = new Point(60, 176);
            txtQuizDescription.Multiline = true;
            txtQuizDescription.Name = "txtQuizDescription";
            txtQuizDescription.ScrollBars = ScrollBars.Vertical;
            txtQuizDescription.Size = new Size(236, 99);
            txtQuizDescription.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(80, 362);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(203, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Back";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpScheduledDate
            // 
            dtpScheduledDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpScheduledDate.Format = DateTimePickerFormat.Custom;
            dtpScheduledDate.Location = new Point(83, 304);
            dtpScheduledDate.Name = "dtpScheduledDate";
            dtpScheduledDate.Size = new Size(200, 23);
            dtpScheduledDate.TabIndex = 8;
            dtpScheduledDate.Value = new DateTime(2025, 11, 15, 9, 46, 0, 0);
            // 
            // CreateQuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 462);
            Controls.Add(dtpScheduledDate);
            Controls.Add(btnCancel);
            Controls.Add(txtQuizDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnSaveQuiz);
            Controls.Add(txtQuizTitle);
            Controls.Add(label1);
            Name = "CreateQuizForm";
            Text = "CreateQuizForm";
            Load += CreateQuizForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtQuizTitle;
        private Button btnSaveQuiz;
        private Label label2;
        private Label label3;
        private TextBox txtQuizDescription;
        private Button btnCancel;
        private DateTimePicker dtpScheduledDate;
    }
}