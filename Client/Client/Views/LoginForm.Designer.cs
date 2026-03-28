namespace Client.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlToggle;
        private System.Windows.Forms.Button btnTabLogin;
        private System.Windows.Forms.Button btnTabRegister;

        private System.Windows.Forms.Panel pnlLoginForm;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label lblLoginError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkToRegister;

        private System.Windows.Forms.Panel pnlRegisterForm;
        private System.Windows.Forms.TextBox txtRegisterName;
        private System.Windows.Forms.TextBox txtRegisterEmail;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.TextBox txtRegisterConfirmPassword;
        private System.Windows.Forms.ComboBox cmbRegisterRole;
        private System.Windows.Forms.Label lblRegisterError;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel linkToLogin;

        private System.Windows.Forms.Label lblBaseUrl;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.lblBaseUrl = new System.Windows.Forms.Label();
            this.pnlRegisterForm = new System.Windows.Forms.Panel();
            this.linkToLogin = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegisterError = new System.Windows.Forms.Label();
            this.cmbRegisterRole = new System.Windows.Forms.ComboBox();
            this.txtRegisterConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.txtRegisterEmail = new System.Windows.Forms.TextBox();
            this.txtRegisterName = new System.Windows.Forms.TextBox();
            this.pnlLoginForm = new System.Windows.Forms.Panel();
            this.linkToRegister = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.pnlToggle = new System.Windows.Forms.Panel();
            this.btnTabRegister = new System.Windows.Forms.Button();
            this.btnTabLogin = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlCard.SuspendLayout();
            this.pnlRegisterForm.SuspendLayout();
            this.pnlLoginForm.SuspendLayout();
            this.pnlToggle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.progressBar);
            this.pnlCard.Controls.Add(this.lblStatus);
            this.pnlCard.Controls.Add(this.txtBaseUrl);
            this.pnlCard.Controls.Add(this.lblBaseUrl);
            this.pnlCard.Controls.Add(this.pnlRegisterForm);
            this.pnlCard.Controls.Add(this.pnlLoginForm);
            this.pnlCard.Controls.Add(this.pnlToggle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblAppName);
            this.pnlCard.Controls.Add(this.pnlLogo);
            this.pnlCard.Location = new System.Drawing.Point(92, 24);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(500, 640);
            this.pnlCard.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(24, 610);
            this.progressBar.MarqueeAnimationSpeed = 24;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(452, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStatus.Location = new System.Drawing.Point(24, 582);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(452, 22);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(98, 548);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(378, 20);
            this.txtBaseUrl.TabIndex = 7;
            this.txtBaseUrl.Text = "https://localhost:58842";
            // 
            // lblBaseUrl
            // 
            this.lblBaseUrl.AutoSize = true;
            this.lblBaseUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblBaseUrl.Location = new System.Drawing.Point(24, 551);
            this.lblBaseUrl.Name = "lblBaseUrl";
            this.lblBaseUrl.Size = new System.Drawing.Size(57, 13);
            this.lblBaseUrl.TabIndex = 6;
            this.lblBaseUrl.Text = "API URL";
            // 
            // pnlRegisterForm
            // 
            this.pnlRegisterForm.Controls.Add(this.linkToLogin);
            this.pnlRegisterForm.Controls.Add(this.btnRegister);
            this.pnlRegisterForm.Controls.Add(this.lblRegisterError);
            this.pnlRegisterForm.Controls.Add(this.cmbRegisterRole);
            this.pnlRegisterForm.Controls.Add(this.txtRegisterConfirmPassword);
            this.pnlRegisterForm.Controls.Add(this.txtRegisterPassword);
            this.pnlRegisterForm.Controls.Add(this.txtRegisterEmail);
            this.pnlRegisterForm.Controls.Add(this.txtRegisterName);
            this.pnlRegisterForm.Location = new System.Drawing.Point(24, 214);
            this.pnlRegisterForm.Name = "pnlRegisterForm";
            this.pnlRegisterForm.Size = new System.Drawing.Size(452, 320);
            this.pnlRegisterForm.TabIndex = 5;
            this.pnlRegisterForm.Visible = false;
            // 
            // linkToLogin
            // 
            this.linkToLogin.AutoSize = true;
            this.linkToLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.linkToLogin.Location = new System.Drawing.Point(123, 284);
            this.linkToLogin.Name = "linkToLogin";
            this.linkToLogin.Size = new System.Drawing.Size(205, 13);
            this.linkToLogin.TabIndex = 7;
            this.linkToLogin.TabStop = true;
            this.linkToLogin.Text = "Already have an account? Login";
            this.linkToLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToLogin_LinkClicked);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Location = new System.Drawing.Point(20, 242);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(412, 36);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblRegisterError
            // 
            this.lblRegisterError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRegisterError.Location = new System.Drawing.Point(20, 220);
            this.lblRegisterError.Name = "lblRegisterError";
            this.lblRegisterError.Size = new System.Drawing.Size(412, 18);
            this.lblRegisterError.TabIndex = 5;
            // 
            // cmbRegisterRole
            // 
            this.cmbRegisterRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegisterRole.FormattingEnabled = true;
            this.cmbRegisterRole.Items.AddRange(new object[] {
            "Passenger",
            "Driver"});
            this.cmbRegisterRole.Location = new System.Drawing.Point(20, 180);
            this.cmbRegisterRole.Name = "cmbRegisterRole";
            this.cmbRegisterRole.Size = new System.Drawing.Size(412, 21);
            this.cmbRegisterRole.TabIndex = 4;
            // 
            // txtRegisterConfirmPassword
            // 
            this.txtRegisterConfirmPassword.Location = new System.Drawing.Point(20, 136);
            this.txtRegisterConfirmPassword.Name = "txtRegisterConfirmPassword";
            this.txtRegisterConfirmPassword.Size = new System.Drawing.Size(412, 20);
            this.txtRegisterConfirmPassword.TabIndex = 3;
            this.txtRegisterConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtRegisterPassword
            // 
            this.txtRegisterPassword.Location = new System.Drawing.Point(20, 92);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.Size = new System.Drawing.Size(412, 20);
            this.txtRegisterPassword.TabIndex = 2;
            this.txtRegisterPassword.UseSystemPasswordChar = true;
            // 
            // txtRegisterEmail
            // 
            this.txtRegisterEmail.Location = new System.Drawing.Point(20, 48);
            this.txtRegisterEmail.Name = "txtRegisterEmail";
            this.txtRegisterEmail.Size = new System.Drawing.Size(412, 20);
            this.txtRegisterEmail.TabIndex = 1;
            // 
            // txtRegisterName
            // 
            this.txtRegisterName.Location = new System.Drawing.Point(20, 4);
            this.txtRegisterName.Name = "txtRegisterName";
            this.txtRegisterName.Size = new System.Drawing.Size(412, 20);
            this.txtRegisterName.TabIndex = 0;
            // 
            // pnlLoginForm
            // 
            this.pnlLoginForm.Controls.Add(this.linkToRegister);
            this.pnlLoginForm.Controls.Add(this.btnLogin);
            this.pnlLoginForm.Controls.Add(this.lblLoginError);
            this.pnlLoginForm.Controls.Add(this.txtLoginPassword);
            this.pnlLoginForm.Controls.Add(this.txtLoginEmail);
            this.pnlLoginForm.Location = new System.Drawing.Point(24, 214);
            this.pnlLoginForm.Name = "pnlLoginForm";
            this.pnlLoginForm.Size = new System.Drawing.Size(452, 320);
            this.pnlLoginForm.TabIndex = 4;
            // 
            // linkToRegister
            // 
            this.linkToRegister.AutoSize = true;
            this.linkToRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.linkToRegister.Location = new System.Drawing.Point(116, 238);
            this.linkToRegister.Name = "linkToRegister";
            this.linkToRegister.Size = new System.Drawing.Size(219, 13);
            this.linkToRegister.TabIndex = 4;
            this.linkToRegister.TabStop = true;
            this.linkToRegister.Text = "Don\'t have an account? Register";
            this.linkToRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToRegister_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(20, 194);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(412, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginError
            // 
            this.lblLoginError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblLoginError.Location = new System.Drawing.Point(20, 172);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Size = new System.Drawing.Size(412, 18);
            this.lblLoginError.TabIndex = 2;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(20, 54);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(412, 20);
            this.txtLoginPassword.TabIndex = 1;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.Location = new System.Drawing.Point(20, 10);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(412, 20);
            this.txtLoginEmail.TabIndex = 0;
            // 
            // pnlToggle
            // 
            this.pnlToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlToggle.Controls.Add(this.btnTabRegister);
            this.pnlToggle.Controls.Add(this.btnTabLogin);
            this.pnlToggle.Location = new System.Drawing.Point(24, 160);
            this.pnlToggle.Name = "pnlToggle";
            this.pnlToggle.Size = new System.Drawing.Size(452, 40);
            this.pnlToggle.TabIndex = 3;
            // 
            // btnTabRegister
            // 
            this.btnTabRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabRegister.Location = new System.Drawing.Point(226, 3);
            this.btnTabRegister.Name = "btnTabRegister";
            this.btnTabRegister.Size = new System.Drawing.Size(223, 34);
            this.btnTabRegister.TabIndex = 1;
            this.btnTabRegister.Text = "Register";
            this.btnTabRegister.UseVisualStyleBackColor = true;
            this.btnTabRegister.Click += new System.EventHandler(this.btnTabRegister_Click);
            // 
            // btnTabLogin
            // 
            this.btnTabLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabLogin.Location = new System.Drawing.Point(3, 3);
            this.btnTabLogin.Name = "btnTabLogin";
            this.btnTabLogin.Size = new System.Drawing.Size(223, 34);
            this.btnTabLogin.TabIndex = 0;
            this.btnTabLogin.Text = "Login";
            this.btnTabLogin.UseVisualStyleBackColor = true;
            this.btnTabLogin.Click += new System.EventHandler(this.btnTabLogin_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 120);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(452, 20);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Welcome back";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblAppName.Location = new System.Drawing.Point(24, 86);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(452, 32);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "CoMove";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlLogo.Location = new System.Drawing.Point(226, 32);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(48, 48);
            this.pnlLogo.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(684, 686);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoMove - Authentication";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Resize += new System.EventHandler(this.LoginForm_Resize);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlRegisterForm.ResumeLayout(false);
            this.pnlRegisterForm.PerformLayout();
            this.pnlLoginForm.ResumeLayout(false);
            this.pnlLoginForm.PerformLayout();
            this.pnlToggle.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
