namespace QuizMe_
{
    partial class UploadStudySetForm
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
            txtTitle = new TextBox();
            txtSubject = new TextBox();
            subject = new Label();
            btnSelectPdf = new Button();
            lblFileName = new Label();
            btnSave = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 81);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(130, 99);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(130, 156);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(100, 23);
            txtSubject.TabIndex = 3;
            // 
            // subject
            // 
            subject.AutoSize = true;
            subject.Location = new Point(130, 138);
            subject.Name = "subject";
            subject.Size = new Size(49, 15);
            subject.TabIndex = 2;
            subject.Text = "Subject:";
            // 
            // btnSelectPdf
            // 
            btnSelectPdf.Location = new Point(130, 198);
            btnSelectPdf.Name = "btnSelectPdf";
            btnSelectPdf.Size = new Size(75, 23);
            btnSelectPdf.TabIndex = 4;
            btnSelectPdf.Text = "Select Pdf";
            btnSelectPdf.UseVisualStyleBackColor = true;
            btnSelectPdf.Click += btnSelectPdf_Click;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(130, 224);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(88, 15);
            lblFileName.TabIndex = 5;
            lblFileName.Text = "No file selected";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 266);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadStudySetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 435);
            Controls.Add(btnSave);
            Controls.Add(lblFileName);
            Controls.Add(btnSelectPdf);
            Controls.Add(txtSubject);
            Controls.Add(subject);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "UploadStudySetForm";
            Text = "UploadStudySetForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private TextBox txtSubject;
        private Label subject;
        private Button btnSelectPdf;
        private Label lblFileName;
        private Button btnSave;
        private OpenFileDialog openFileDialog1;
    }
}