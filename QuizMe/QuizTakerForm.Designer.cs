namespace QuizMe_
{
    partial class QuizTakerForm
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
            lblQuestionNumber = new Label();
            lblQuestionText = new Label();
            groupBoxOptions = new GroupBox();
            rbOptionD = new RadioButton();
            rbOptionC = new RadioButton();
            rbOptionB = new RadioButton();
            rbOptionA = new RadioButton();
            btnNext = new Button();
            groupBoxOptions.SuspendLayout();
            SuspendLayout();
            // 
            // lblQuestionNumber
            // 
            lblQuestionNumber.AutoSize = true;
            lblQuestionNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuestionNumber.Location = new Point(33, 25);
            lblQuestionNumber.Margin = new Padding(4, 0, 4, 0);
            lblQuestionNumber.Name = "lblQuestionNumber";
            lblQuestionNumber.Size = new Size(121, 20);
            lblQuestionNumber.TabIndex = 0;
            lblQuestionNumber.Text = "Question 1/10";
            // 
            // lblQuestionText
            // 
            lblQuestionText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionText.Location = new Point(37, 68);
            lblQuestionText.Margin = new Padding(4, 0, 4, 0);
            lblQuestionText.Name = "lblQuestionText";
            lblQuestionText.Size = new Size(572, 115);
            lblQuestionText.TabIndex = 1;
            lblQuestionText.Text = "This is where the text of the quiz question will appear. It can be multiple lines long if necessary.";
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.Controls.Add(rbOptionD);
            groupBoxOptions.Controls.Add(rbOptionC);
            groupBoxOptions.Controls.Add(rbOptionB);
            groupBoxOptions.Controls.Add(rbOptionA);
            groupBoxOptions.Location = new Point(37, 198);
            groupBoxOptions.Margin = new Padding(4, 3, 4, 3);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Padding = new Padding(4, 3, 4, 3);
            groupBoxOptions.Size = new Size(572, 247);
            groupBoxOptions.TabIndex = 2;
            groupBoxOptions.TabStop = false;
            // 
            // rbOptionD
            // 
            rbOptionD.AutoSize = true;
            rbOptionD.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOptionD.Location = new Point(22, 196);
            rbOptionD.Margin = new Padding(4, 3, 4, 3);
            rbOptionD.Name = "rbOptionD";
            rbOptionD.Size = new Size(77, 20);
            rbOptionD.TabIndex = 3;
            rbOptionD.TabStop = true;
            rbOptionD.Text = "Option D";
            rbOptionD.UseVisualStyleBackColor = true;
            // 
            // rbOptionC
            // 
            rbOptionC.AutoSize = true;
            rbOptionC.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOptionC.Location = new Point(22, 142);
            rbOptionC.Margin = new Padding(4, 3, 4, 3);
            rbOptionC.Name = "rbOptionC";
            rbOptionC.Size = new Size(76, 20);
            rbOptionC.TabIndex = 2;
            rbOptionC.TabStop = true;
            rbOptionC.Text = "Option C";
            rbOptionC.UseVisualStyleBackColor = true;
            // 
            // rbOptionB
            // 
            rbOptionB.AutoSize = true;
            rbOptionB.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOptionB.Location = new Point(22, 88);
            rbOptionB.Margin = new Padding(4, 3, 4, 3);
            rbOptionB.Name = "rbOptionB";
            rbOptionB.Size = new Size(76, 20);
            rbOptionB.TabIndex = 1;
            rbOptionB.TabStop = true;
            rbOptionB.Text = "Option B";
            rbOptionB.UseVisualStyleBackColor = true;
            // 
            // rbOptionA
            // 
            rbOptionA.AutoSize = true;
            rbOptionA.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOptionA.Location = new Point(22, 33);
            rbOptionA.Margin = new Padding(4, 3, 4, 3);
            rbOptionA.Name = "rbOptionA";
            rbOptionA.Size = new Size(76, 20);
            rbOptionA.TabIndex = 0;
            rbOptionA.TabStop = true;
            rbOptionA.Text = "Option A";
            rbOptionA.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(463, 463);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(146, 52);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // QuizTakerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 541);
            Controls.Add(btnNext);
            Controls.Add(groupBoxOptions);
            Controls.Add(lblQuestionText);
            Controls.Add(lblQuestionNumber);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "QuizTakerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quiz";
            Load += QuizTakerForm_Load;
            groupBoxOptions.ResumeLayout(false);
            groupBoxOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton rbOptionD;
        private System.Windows.Forms.RadioButton rbOptionC;
        private System.Windows.Forms.RadioButton rbOptionB;
        private System.Windows.Forms.RadioButton rbOptionA;
        private System.Windows.Forms.Button btnNext;
    }
}