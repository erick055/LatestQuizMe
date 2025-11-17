namespace QuizMe_
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            Smallsteps = new Label();
            learning = new Label();
            Make = new Label();
            button1 = new Button();
            Sign = new Label();
            lblUsername = new Label();
            CreatePass = new Label();
            ConfirmPass = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            btnSignup = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Smallsteps);
            panel1.Controls.Add(learning);
            panel1.Controls.Add(Make);
            panel1.Location = new Point(1, 3);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 1136);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(166, 456);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(528, 585);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Smallsteps
            // 
            Smallsteps.AutoSize = true;
            Smallsteps.Font = new Font("Microsoft Sans Serif", 15F);
            Smallsteps.ForeColor = SystemColors.ButtonHighlight;
            Smallsteps.Location = new Point(51, 239);
            Smallsteps.Name = "Smallsteps";
            Smallsteps.Size = new Size(431, 29);
            Smallsteps.TabIndex = 2;
            Smallsteps.Text = "Small Steps today, big win tomorrow!";
            // 
            // learning
            // 
            learning.AutoSize = true;
            learning.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            learning.Location = new Point(39, 143);
            learning.Name = "learning";
            learning.Size = new Size(551, 89);
            learning.TabIndex = 1;
            learning.Text = "LEARNING FUN!";
            // 
            // Make
            // 
            Make.AutoSize = true;
            Make.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            Make.Location = new Point(39, 47);
            Make.Name = "Make";
            Make.Size = new Size(228, 89);
            Make.TabIndex = 0;
            Make.Text = "MAKE";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(729, 28);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(61, 65);
            button1.TabIndex = 1;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            // 
            // Sign
            // 
            Sign.AutoSize = true;
            Sign.Font = new Font("Segoe UI", 15F);
            Sign.Location = new Point(763, 167);
            Sign.Name = "Sign";
            Sign.Size = new Size(109, 35);
            Sign.TabIndex = 2;
            Sign.Text = "SIGN UP";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(763, 243);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // CreatePass
            // 
            CreatePass.AutoSize = true;
            CreatePass.Font = new Font("Segoe UI", 10F);
            CreatePass.Location = new Point(763, 347);
            CreatePass.Name = "CreatePass";
            CreatePass.Size = new Size(150, 23);
            CreatePass.TabIndex = 4;
            CreatePass.Text = "Create a password";
            // 
            // ConfirmPass
            // 
            ConfirmPass.AutoSize = true;
            ConfirmPass.Font = new Font("Segoe UI", 10F);
            ConfirmPass.Location = new Point(763, 451);
            ConfirmPass.Name = "ConfirmPass";
            ConfirmPass.Size = new Size(146, 23);
            ConfirmPass.TabIndex = 5;
            ConfirmPass.Text = "Confirm Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(774, 273);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(348, 30);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(774, 376);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(348, 30);
            txtPassword.TabIndex = 7;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(774, 492);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(348, 30);
            txtConfirmPassword.TabIndex = 8;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaptionText;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(763, 697);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(457, 57);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Register";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(843, 893);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 10;
            label1.Text = "Already have an account?";
            // 
            // btnSignup
            // 
            btnSignup.AutoSize = true;
            btnSignup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSignup.Location = new Point(1013, 893);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(56, 20);
            btnSignup.TabIndex = 11;
            btnSignup.Text = "Sign in";
            btnSignup.Click += btnSignup_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1255, 16);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(74, 77);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 1135);
            Controls.Add(pictureBox2);
            Controls.Add(btnSignup);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(button1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(ConfirmPass);
            Controls.Add(CreatePass);
            Controls.Add(lblUsername);
            Controls.Add(Sign);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SignUp";
            Text = "SignUp";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label learning;
        private Label Make;
        private Label Smallsteps;
        private Button button1;
        private Label Sign;
        private Label lblUsername;
        private Label CreatePass;
        private Label ConfirmPass;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnLogin;
        private Label label1;
        private PictureBox pictureBox1;
        private Label btnSignup;
        private PictureBox pictureBox2;
    }
}