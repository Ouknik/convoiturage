namespace Client.Views
{
    partial class ProfileControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel layoutRoot;
        private System.Windows.Forms.Panel pnlSummaryCard;
        private System.Windows.Forms.PictureBox pictureProfile;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblProfileEmail;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Label lblBioPreview;

        private System.Windows.Forms.Panel pnlEditCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneError;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCityError;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.Label lblBioError;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
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
            this.layoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSummaryCard = new System.Windows.Forms.Panel();
            this.lblBioPreview = new System.Windows.Forms.Label();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.lblProfileEmail = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.pictureProfile = new System.Windows.Forms.PictureBox();
            this.pnlEditCard = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.lblImageUrl = new System.Windows.Forms.Label();
            this.lblBioError = new System.Windows.Forms.Label();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblCityError = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPhoneError = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.layoutRoot.SuspendLayout();
            this.pnlSummaryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).BeginInit();
            this.pnlEditCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutRoot
            // 
            this.layoutRoot.ColumnCount = 2;
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.layoutRoot.Controls.Add(this.pnlSummaryCard, 0, 0);
            this.layoutRoot.Controls.Add(this.pnlEditCard, 1, 0);
            this.layoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutRoot.Name = "layoutRoot";
            this.layoutRoot.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.layoutRoot.RowCount = 1;
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.Size = new System.Drawing.Size(920, 620);
            this.layoutRoot.TabIndex = 0;
            // 
            // pnlSummaryCard
            // 
            this.pnlSummaryCard.BackColor = System.Drawing.Color.White;
            this.pnlSummaryCard.Controls.Add(this.lblBioPreview);
            this.pnlSummaryCard.Controls.Add(this.lblRoleBadge);
            this.pnlSummaryCard.Controls.Add(this.lblProfileEmail);
            this.pnlSummaryCard.Controls.Add(this.lblProfileName);
            this.pnlSummaryCard.Controls.Add(this.pictureProfile);
            this.pnlSummaryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummaryCard.Location = new System.Drawing.Point(27, 23);
            this.pnlSummaryCard.Name = "pnlSummaryCard";
            this.pnlSummaryCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlSummaryCard.Size = new System.Drawing.Size(290, 574);
            this.pnlSummaryCard.TabIndex = 0;
            // 
            // lblBioPreview
            // 
            this.lblBioPreview.ForeColor = System.Drawing.Color.DimGray;
            this.lblBioPreview.Location = new System.Drawing.Point(24, 280);
            this.lblBioPreview.Name = "lblBioPreview";
            this.lblBioPreview.Size = new System.Drawing.Size(240, 120);
            this.lblBioPreview.TabIndex = 4;
            this.lblBioPreview.Text = "Your bio will appear here.";
            // 
            // lblRoleBadge
            // 
            this.lblRoleBadge.AutoSize = true;
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblRoleBadge.Location = new System.Drawing.Point(103, 244);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.lblRoleBadge.Size = new System.Drawing.Size(82, 23);
            this.lblRoleBadge.TabIndex = 3;
            this.lblRoleBadge.Text = "Passenger";
            // 
            // lblProfileEmail
            // 
            this.lblProfileEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblProfileEmail.Location = new System.Drawing.Point(24, 215);
            this.lblProfileEmail.Name = "lblProfileEmail";
            this.lblProfileEmail.Size = new System.Drawing.Size(240, 20);
            this.lblProfileEmail.TabIndex = 2;
            this.lblProfileEmail.Text = "email@domain.com";
            this.lblProfileEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfileName
            // 
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProfileName.Location = new System.Drawing.Point(24, 186);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(240, 24);
            this.lblProfileName.TabIndex = 1;
            this.lblProfileName.Text = "User Name";
            this.lblProfileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureProfile
            // 
            this.pictureProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pictureProfile.Location = new System.Drawing.Point(79, 36);
            this.pictureProfile.Name = "pictureProfile";
            this.pictureProfile.Size = new System.Drawing.Size(130, 130);
            this.pictureProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProfile.TabIndex = 0;
            this.pictureProfile.TabStop = false;
            // 
            // pnlEditCard
            // 
            this.pnlEditCard.BackColor = System.Drawing.Color.White;
            this.pnlEditCard.Controls.Add(this.progressBar);
            this.pnlEditCard.Controls.Add(this.btnCancel);
            this.pnlEditCard.Controls.Add(this.btnSave);
            this.pnlEditCard.Controls.Add(this.btnUploadImage);
            this.pnlEditCard.Controls.Add(this.txtImageUrl);
            this.pnlEditCard.Controls.Add(this.lblImageUrl);
            this.pnlEditCard.Controls.Add(this.lblBioError);
            this.pnlEditCard.Controls.Add(this.txtBio);
            this.pnlEditCard.Controls.Add(this.lblBio);
            this.pnlEditCard.Controls.Add(this.lblCityError);
            this.pnlEditCard.Controls.Add(this.txtCity);
            this.pnlEditCard.Controls.Add(this.lblCity);
            this.pnlEditCard.Controls.Add(this.lblPhoneError);
            this.pnlEditCard.Controls.Add(this.txtPhone);
            this.pnlEditCard.Controls.Add(this.lblPhone);
            this.pnlEditCard.Controls.Add(this.txtEmail);
            this.pnlEditCard.Controls.Add(this.lblEmail);
            this.pnlEditCard.Controls.Add(this.txtName);
            this.pnlEditCard.Controls.Add(this.lblName);
            this.pnlEditCard.Controls.Add(this.lblSubtitle);
            this.pnlEditCard.Controls.Add(this.lblTitle);
            this.pnlEditCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditCard.Location = new System.Drawing.Point(323, 23);
            this.pnlEditCard.Name = "pnlEditCard";
            this.pnlEditCard.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlEditCard.Size = new System.Drawing.Size(570, 574);
            this.pnlEditCard.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 542);
            this.progressBar.MarqueeAnimationSpeed = 26;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(514, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 20;
            this.progressBar.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(418, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 36);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(281, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 36);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Location = new System.Drawing.Point(420, 443);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(122, 30);
            this.btnUploadImage.TabIndex = 17;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(31, 447);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(383, 20);
            this.txtImageUrl.TabIndex = 16;
            // 
            // lblImageUrl
            // 
            this.lblImageUrl.AutoSize = true;
            this.lblImageUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblImageUrl.Location = new System.Drawing.Point(28, 430);
            this.lblImageUrl.Name = "lblImageUrl";
            this.lblImageUrl.Size = new System.Drawing.Size(99, 13);
            this.lblImageUrl.TabIndex = 15;
            this.lblImageUrl.Text = "Profile Image URL";
            // 
            // lblBioError
            // 
            this.lblBioError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblBioError.Location = new System.Drawing.Point(28, 407);
            this.lblBioError.Name = "lblBioError";
            this.lblBioError.Size = new System.Drawing.Size(514, 17);
            this.lblBioError.TabIndex = 14;
            // 
            // txtBio
            // 
            this.txtBio.Location = new System.Drawing.Point(31, 292);
            this.txtBio.Multiline = true;
            this.txtBio.Name = "txtBio";
            this.txtBio.Size = new System.Drawing.Size(511, 112);
            this.txtBio.TabIndex = 13;
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblBio.Location = new System.Drawing.Point(28, 275);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(24, 13);
            this.lblBio.TabIndex = 12;
            this.lblBio.Text = "Bio";
            // 
            // lblCityError
            // 
            this.lblCityError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCityError.Location = new System.Drawing.Point(291, 252);
            this.lblCityError.Name = "lblCityError";
            this.lblCityError.Size = new System.Drawing.Size(251, 17);
            this.lblCityError.TabIndex = 11;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(294, 229);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(248, 20);
            this.txtCity.TabIndex = 10;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCity.Location = new System.Drawing.Point(291, 212);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "City";
            // 
            // lblPhoneError
            // 
            this.lblPhoneError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPhoneError.Location = new System.Drawing.Point(28, 252);
            this.lblPhoneError.Name = "lblPhoneError";
            this.lblPhoneError.Size = new System.Drawing.Size(248, 17);
            this.lblPhoneError.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(31, 229);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(245, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblPhone.Location = new System.Drawing.Point(28, 212);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(31, 170);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(511, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblEmail.Location = new System.Drawing.Point(28, 153);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(31, 112);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(511, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblName.Location = new System.Drawing.Point(28, 95);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(28, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(199, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Update your personal and contact details";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(26, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit your profile";
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.Controls.Add(this.layoutRoot);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(920, 620);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            this.layoutRoot.ResumeLayout(false);
            this.pnlSummaryCard.ResumeLayout(false);
            this.pnlSummaryCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).EndInit();
            this.pnlEditCard.ResumeLayout(false);
            this.pnlEditCard.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
