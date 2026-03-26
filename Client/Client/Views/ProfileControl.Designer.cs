namespace Client.Views
{
    partial class ProfileControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblEmailTitle;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.PictureBox pictureProfile;
        private System.Windows.Forms.Button btnSave;
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
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblEmailTitle = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblImageUrl = new System.Windows.Forms.Label();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.pictureProfile = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Location = new System.Drawing.Point(20, 22);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(38, 13);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "Name:";
            // 
            // lblNameValue
            // 
            this.lblNameValue.AutoSize = true;
            this.lblNameValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameValue.Location = new System.Drawing.Point(86, 18);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(45, 19);
            this.lblNameValue.TabIndex = 1;
            this.lblNameValue.Text = "name";
            // 
            // lblEmailTitle
            // 
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Location = new System.Drawing.Point(20, 50);
            this.lblEmailTitle.Name = "lblEmailTitle";
            this.lblEmailTitle.Size = new System.Drawing.Size(35, 13);
            this.lblEmailTitle.TabIndex = 2;
            this.lblEmailTitle.Text = "Email:";
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.AutoSize = true;
            this.lblEmailValue.Location = new System.Drawing.Point(87, 50);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(31, 13);
            this.lblEmailValue.TabIndex = 3;
            this.lblEmailValue.Text = "email";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Location = new System.Drawing.Point(20, 88);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(25, 13);
            this.lblBio.TabIndex = 4;
            this.lblBio.Text = "Bio:";
            // 
            // txtBio
            // 
            this.txtBio.Location = new System.Drawing.Point(90, 85);
            this.txtBio.Multiline = true;
            this.txtBio.Name = "txtBio";
            this.txtBio.Size = new System.Drawing.Size(430, 82);
            this.txtBio.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 187);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 184);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(20, 219);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(90, 216);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(240, 20);
            this.txtCity.TabIndex = 9;
            // 
            // lblImageUrl
            // 
            this.lblImageUrl.AutoSize = true;
            this.lblImageUrl.Location = new System.Drawing.Point(20, 251);
            this.lblImageUrl.Name = "lblImageUrl";
            this.lblImageUrl.Size = new System.Drawing.Size(59, 13);
            this.lblImageUrl.TabIndex = 10;
            this.lblImageUrl.Text = "Image URL:";
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(90, 248);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(430, 20);
            this.txtImageUrl.TabIndex = 11;
            // 
            // pictureProfile
            // 
            this.pictureProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureProfile.Location = new System.Drawing.Point(540, 85);
            this.pictureProfile.Name = "pictureProfile";
            this.pictureProfile.Size = new System.Drawing.Size(180, 180);
            this.pictureProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProfile.TabIndex = 12;
            this.pictureProfile.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(90, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Profile";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 339);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(697, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureProfile);
            this.Controls.Add(this.txtImageUrl);
            this.Controls.Add(this.lblImageUrl);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtBio);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.lblEmailValue);
            this.Controls.Add(this.lblEmailTitle);
            this.Controls.Add(this.lblNameValue);
            this.Controls.Add(this.lblNameTitle);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(770, 470);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
