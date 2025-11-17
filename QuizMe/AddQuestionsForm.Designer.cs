namespace QuizMe_
{
    partial class AddQuestionsForm
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
            txtQuestion = new TextBox();
            label2 = new Label();
            txtOptionA = new TextBox();
            label3 = new Label();
            txtOptionB = new TextBox();
            label4 = new Label();
            txtOptionC = new TextBox();
            label5 = new Label();
            txtOptionD = new TextBox();
            label6 = new Label();
            txtAnswer = new TextBox();
            btnSaveQuestion = new Button();
            btnDone = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 16);
            label1.TabIndex = 0;
            label1.Text = "Question:";
            // 
            // txtQuestion
            // 
            txtQuestion.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuestion.Location = new Point(38, 45);
            txtQuestion.Margin = new Padding(4, 3, 4, 3);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(510, 80);
            txtQuestion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 148);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 16);
            label2.TabIndex = 2;
            label2.Text = "Option A:";
            // 
            // txtOptionA
            // 
            txtOptionA.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOptionA.Location = new Point(38, 170);
            txtOptionA.Margin = new Padding(4, 3, 4, 3);
            txtOptionA.Name = "txtOptionA";
            txtOptionA.Size = new Size(510, 22);
            txtOptionA.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 211);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 16);
            label3.TabIndex = 4;
            label3.Text = "Option B:";
            // 
            // txtOptionB
            // 
            txtOptionB.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOptionB.Location = new Point(38, 233);
            txtOptionB.Margin = new Padding(4, 3, 4, 3);
            txtOptionB.Name = "txtOptionB";
            txtOptionB.Size = new Size(510, 22);
            txtOptionB.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(35, 275);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(61, 16);
            label4.TabIndex = 6;
            label4.Text = "Option C:";
            // 
            // txtOptionC
            // 
            txtOptionC.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOptionC.Location = new Point(38, 297);
            txtOptionC.Margin = new Padding(4, 3, 4, 3);
            txtOptionC.Name = "txtOptionC";
            txtOptionC.Size = new Size(510, 22);
            txtOptionC.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 338);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 16);
            label5.TabIndex = 8;
            label5.Text = "Option D:";
            // 
            // txtOptionD
            // 
            txtOptionD.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOptionD.Location = new Point(38, 360);
            txtOptionD.Margin = new Padding(4, 3, 4, 3);
            txtOptionD.Name = "txtOptionD";
            txtOptionD.Size = new Size(510, 22);
            txtOptionD.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(35, 415);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(111, 16);
            label6.TabIndex = 10;
            label6.Text = "Correct Answer";
            // 
            // txtAnswer
            // 
            txtAnswer.CharacterCasing = CharacterCasing.Upper;
            txtAnswer.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAnswer.Location = new Point(38, 437);
            txtAnswer.Margin = new Padding(4, 3, 4, 3);
            txtAnswer.MaxLength = 1;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(124, 22);
            txtAnswer.TabIndex = 11;
            // 
            // btnSaveQuestion
            // 
            btnSaveQuestion.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveQuestion.Location = new Point(340, 503);
            btnSaveQuestion.Margin = new Padding(4, 3, 4, 3);
            btnSaveQuestion.Name = "btnSaveQuestion";
            btnSaveQuestion.Size = new Size(210, 52);
            btnSaveQuestion.TabIndex = 12;
            btnSaveQuestion.Text = "Save and Add Another";
            btnSaveQuestion.UseVisualStyleBackColor = true;
            btnSaveQuestion.Click += btnSaveQuestion_Click;
            // 
            // btnDone
            // 
            btnDone.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(38, 503);
            btnDone.Margin = new Padding(4, 3, 4, 3);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(210, 52);
            btnDone.TabIndex = 13;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(170, 443);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(116, 13);
            label7.TabIndex = 14;
            label7.Text = "(Enter 'A', 'B', 'C', or 'D')";
            // 
            // AddQuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 587);
            Controls.Add(label7);
            Controls.Add(btnDone);
            Controls.Add(btnSaveQuestion);
            Controls.Add(txtAnswer);
            Controls.Add(label6);
            Controls.Add(txtOptionD);
            Controls.Add(label5);
            Controls.Add(txtOptionC);
            Controls.Add(label4);
            Controls.Add(txtOptionB);
            Controls.Add(label3);
            Controls.Add(txtOptionA);
            Controls.Add(label2);
            Controls.Add(txtQuestion);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddQuestionsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Questions";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOptionA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOptionB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOptionC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOptionD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label7;
    }
}