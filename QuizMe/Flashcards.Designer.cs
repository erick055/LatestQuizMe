namespace QuizMe_
{
    partial class Flashcards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Flashcards));
            panel1 = new Panel();
            lblAnswer = new Label();
            lblSeeAnswer = new Label();
            lblQuestion = new Label();
            label1 = new Label();
            panel3 = new Panel();
            lblScheduledIdentifier = new Label();
            pictureBox1 = new PictureBox();
            lblCardNo = new Label();
            btnDontKnow = new Button();
            btnKnew = new Button();
            refBtn = new Button();
            panel4 = new Panel();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            label5 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            btnStudy = new Button();
            pictureBox9 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox10 = new PictureBox();
            btnSet = new Button();
            btnSched = new Button();
            btnGlo = new Button();
            btnQui = new Button();
            btnFla = new Button();
            btnDash = new Button();
            createFlashcardButton = new Button();
            btnDelete = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(lblAnswer);
            panel1.Controls.Add(lblSeeAnswer);
            panel1.Controls.Add(lblQuestion);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(60, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(824, 427);
            panel1.TabIndex = 0;
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Lucida Sans Unicode", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAnswer.Location = new Point(400, 350);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(0, 35);
            lblAnswer.TabIndex = 3;
            // 
            // lblSeeAnswer
            // 
            lblSeeAnswer.AutoSize = true;
            lblSeeAnswer.BackColor = Color.ForestGreen;
            lblSeeAnswer.Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeeAnswer.ForeColor = Color.Snow;
            lblSeeAnswer.Location = new Point(342, 278);
            lblSeeAnswer.Name = "lblSeeAnswer";
            lblSeeAnswer.Size = new Size(134, 20);
            lblSeeAnswer.TabIndex = 2;
            lblSeeAnswer.Text = "Click to see answer";
            lblSeeAnswer.Click += lblSeeAnswer_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(150, 174);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(511, 39);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "What does an event listener do?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SeaShell;
            label1.Location = new Point(373, 116);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "QUESTION";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(lblScheduledIdentifier);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(lblCardNo);
            panel3.Controls.Add(panel1);
            panel3.Location = new Point(259, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(935, 524);
            panel3.TabIndex = 2;
            // 
            // lblScheduledIdentifier
            // 
            lblScheduledIdentifier.AutoSize = true;
            lblScheduledIdentifier.Location = new Point(144, 24);
            lblScheduledIdentifier.Name = "lblScheduledIdentifier";
            lblScheduledIdentifier.Size = new Size(62, 15);
            lblScheduledIdentifier.TabIndex = 4;
            lblScheduledIdentifier.Text = "Scheduled";
            lblScheduledIdentifier.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.icons8_star_64;
            pictureBox1.Location = new Point(831, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblCardNo
            // 
            lblCardNo.AutoSize = true;
            lblCardNo.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardNo.Location = new Point(57, 24);
            lblCardNo.Name = "lblCardNo";
            lblCardNo.Size = new Size(70, 13);
            lblCardNo.TabIndex = 1;
            lblCardNo.Text = "Card 1 of 3";
            // 
            // btnDontKnow
            // 
            btnDontKnow.BackColor = Color.White;
            btnDontKnow.Location = new Point(319, 580);
            btnDontKnow.Name = "btnDontKnow";
            btnDontKnow.Size = new Size(116, 49);
            btnDontKnow.TabIndex = 3;
            btnDontKnow.Text = "Review Again";
            btnDontKnow.UseVisualStyleBackColor = false;
            btnDontKnow.Click += btnDontKnow_Click;
            // 
            // btnKnew
            // 
            btnKnew.BackColor = Color.White;
            btnKnew.Location = new Point(1027, 580);
            btnKnew.Name = "btnKnew";
            btnKnew.Size = new Size(116, 49);
            btnKnew.TabIndex = 4;
            btnKnew.Text = "I Knew This";
            btnKnew.UseVisualStyleBackColor = false;
            btnKnew.Click += btnKnew_Click;
            // 
            // refBtn
            // 
            refBtn.BackColor = Color.White;
            refBtn.Location = new Point(661, 580);
            refBtn.Name = "refBtn";
            refBtn.Size = new Size(116, 49);
            refBtn.TabIndex = 5;
            refBtn.Text = "Refresh";
            refBtn.UseVisualStyleBackColor = false;
            refBtn.Click += button11_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(button14);
            panel4.Controls.Add(button13);
            panel4.Controls.Add(button12);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(442, 654);
            panel4.Name = "panel4";
            panel4.Size = new Size(598, 112);
            panel4.TabIndex = 6;
            // 
            // button14
            // 
            button14.BackColor = Color.PaleGreen;
            button14.Location = new Point(403, 50);
            button14.Name = "button14";
            button14.Size = new Size(140, 34);
            button14.TabIndex = 3;
            button14.Text = "Easy";
            button14.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            button13.BackColor = Color.PapayaWhip;
            button13.Location = new Point(232, 50);
            button13.Name = "button13";
            button13.Size = new Size(140, 34);
            button13.TabIndex = 2;
            button13.Text = "Hard";
            button13.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.BackColor = Color.Violet;
            button12.Location = new Point(50, 50);
            button12.Name = "button12";
            button12.Size = new Size(140, 34);
            button12.TabIndex = 1;
            button12.Text = "Again";
            button12.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 14);
            label5.Name = "label5";
            label5.Size = new Size(187, 15);
            label5.TabIndex = 0;
            label5.Text = "How well did you know this?";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(241, 27);
            label6.Name = "label6";
            label6.Size = new Size(272, 15);
            label6.TabIndex = 7;
            label6.Text = "Practice with spaced repetition for better retention";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnStudy);
            panel2.Controls.Add(pictureBox9);
            panel2.Controls.Add(pictureBox7);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(pictureBox10);
            panel2.Controls.Add(btnSet);
            panel2.Controls.Add(btnSched);
            panel2.Controls.Add(btnGlo);
            panel2.Controls.Add(btnQui);
            panel2.Controls.Add(btnFla);
            panel2.Controls.Add(btnDash);
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(11, 11);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 769);
            panel2.TabIndex = 29;
            // 
            // btnStudy
            // 
            btnStudy.Location = new Point(47, 343);
            btnStudy.Margin = new Padding(2);
            btnStudy.Name = "btnStudy";
            btnStudy.Size = new Size(145, 63);
            btnStudy.TabIndex = 33;
            btnStudy.Text = "Study Set";
            btnStudy.UseVisualStyleBackColor = true;
            btnStudy.Click += btnStudy_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.White;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(10, 424);
            pictureBox9.Margin = new Padding(2);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(31, 32);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 15;
            pictureBox9.TabStop = false;
            pictureBox9.UseWaitCursor = true;
            pictureBox9.Visible = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(10, 292);
            pictureBox7.Margin = new Padding(2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(31, 32);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            pictureBox7.UseWaitCursor = true;
            pictureBox7.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(10, 228);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            pictureBox2.UseWaitCursor = true;
            pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(10, 167);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.UseWaitCursor = true;
            pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(10, 107);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(31, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            pictureBox4.UseWaitCursor = true;
            pictureBox4.Visible = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.White;
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(10, 51);
            pictureBox10.Margin = new Padding(2);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(31, 32);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 9;
            pictureBox10.TabStop = false;
            pictureBox10.UseWaitCursor = true;
            // 
            // btnSet
            // 
            btnSet.Location = new Point(47, 410);
            btnSet.Margin = new Padding(2);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(145, 63);
            btnSet.TabIndex = 6;
            btnSet.Text = "Settings";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // btnSched
            // 
            btnSched.Location = new Point(47, 282);
            btnSched.Margin = new Padding(2);
            btnSched.Name = "btnSched";
            btnSched.Size = new Size(145, 57);
            btnSched.TabIndex = 4;
            btnSched.Text = "Schedule";
            btnSched.UseVisualStyleBackColor = true;
            btnSched.Click += btnSched_Click;
            // 
            // btnGlo
            // 
            btnGlo.Location = new Point(47, 218);
            btnGlo.Margin = new Padding(2);
            btnGlo.Name = "btnGlo";
            btnGlo.Size = new Size(145, 58);
            btnGlo.TabIndex = 3;
            btnGlo.Text = "Glossary";
            btnGlo.UseVisualStyleBackColor = true;
            btnGlo.Click += btnGlo_Click;
            // 
            // btnQui
            // 
            btnQui.Location = new Point(47, 157);
            btnQui.Margin = new Padding(2);
            btnQui.Name = "btnQui";
            btnQui.Size = new Size(145, 53);
            btnQui.TabIndex = 2;
            btnQui.Text = "Quizzes";
            btnQui.UseVisualStyleBackColor = true;
            btnQui.Click += btnQui_Click;
            // 
            // btnFla
            // 
            btnFla.Location = new Point(47, 98);
            btnFla.Margin = new Padding(2);
            btnFla.Name = "btnFla";
            btnFla.Size = new Size(145, 54);
            btnFla.TabIndex = 1;
            btnFla.Text = "Flashcards";
            btnFla.UseVisualStyleBackColor = true;
            btnFla.Click += btnFla_Click;
            // 
            // btnDash
            // 
            btnDash.Location = new Point(47, 38);
            btnDash.Margin = new Padding(2);
            btnDash.Name = "btnDash";
            btnDash.Size = new Size(145, 54);
            btnDash.TabIndex = 0;
            btnDash.Text = "Dashboard";
            btnDash.UseVisualStyleBackColor = true;
            btnDash.Click += btnDash_Click;
            // 
            // createFlashcardButton
            // 
            createFlashcardButton.Location = new Point(1251, 50);
            createFlashcardButton.Name = "createFlashcardButton";
            createFlashcardButton.Size = new Size(118, 23);
            createFlashcardButton.TabIndex = 30;
            createFlashcardButton.Text = "Create Flashcards";
            createFlashcardButton.UseVisualStyleBackColor = true;
            createFlashcardButton.Click += createFlashcardButton_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MistyRose;
            btnDelete.Location = new Point(844, 580);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 49);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // Flashcards
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1381, 1061);
            Controls.Add(btnDelete);
            Controls.Add(createFlashcardButton);
            Controls.Add(panel2);
            Controls.Add(label6);
            Controls.Add(panel4);
            Controls.Add(refBtn);
            Controls.Add(btnKnew);
            Controls.Add(btnDontKnow);
            Controls.Add(panel3);
            Name = "Flashcards";
            Text = "Flashcards";
            Load += Flashcards_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSeeAnswer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDontKnow;
        private System.Windows.Forms.Button btnKnew;
        private System.Windows.Forms.Button refBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label6;
        private Panel panel2;
        private PictureBox pictureBox9;
        private PictureBox pictureBox7;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox10;
        private Button btnSet;
        private Button btnSched;
        private Button btnGlo;
        private Button btnQui;
        private Button btnFla;
        private Button btnDash;
        private Button createFlashcardButton;
        private Label lblAnswer;
        private Label lblScheduledIdentifier;
        private Button btnDelete;
        private Button btnStudy;
    }
}