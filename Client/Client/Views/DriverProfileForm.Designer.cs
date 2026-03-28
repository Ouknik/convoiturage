namespace Client.Views
{
    partial class DriverProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblReviewsCount;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTripsTitle;
        private System.Windows.Forms.Label lblTrips;
        private System.Windows.Forms.Label lblPassengersTitle;
        private System.Windows.Forms.Label lblPassengers;
        private System.Windows.Forms.FlowLayoutPanel flowReviews;
        private System.Windows.Forms.Button btnClose;

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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblReviewsCount = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblPassengers = new System.Windows.Forms.Label();
            this.lblPassengersTitle = new System.Windows.Forms.Label();
            this.lblTrips = new System.Windows.Forms.Label();
            this.lblTripsTitle = new System.Windows.Forms.Label();
            this.flowReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblReviewsCount);
            this.pnlTop.Controls.Add(this.lblRating);
            this.pnlTop.Controls.Add(this.lblBio);
            this.pnlTop.Controls.Add(this.lblCity);
            this.pnlTop.Controls.Add(this.lblEmail);
            this.pnlTop.Controls.Add(this.lblName);
            this.pnlTop.Location = new System.Drawing.Point(20, 18);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(732, 126);
            this.pnlTop.TabIndex = 0;
            // 
            // lblReviewsCount
            // 
            this.lblReviewsCount.AutoSize = true;
            this.lblReviewsCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblReviewsCount.Location = new System.Drawing.Point(23, 96);
            this.lblReviewsCount.Name = "lblReviewsCount";
            this.lblReviewsCount.Size = new System.Drawing.Size(51, 13);
            this.lblReviewsCount.TabIndex = 5;
            this.lblReviewsCount.Text = "0 reviews";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRating.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblRating.Location = new System.Drawing.Point(22, 72);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(75, 19);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "★★★★★ 0.0";
            // 
            // lblBio
            // 
            this.lblBio.ForeColor = System.Drawing.Color.DimGray;
            this.lblBio.Location = new System.Drawing.Point(359, 20);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(350, 90);
            this.lblBio.TabIndex = 3;
            this.lblBio.Text = "Bio";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.Color.DimGray;
            this.lblCity.Location = new System.Drawing.Point(23, 52);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "City";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmail.Location = new System.Drawing.Point(23, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(22, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Driver";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.lblPassengers);
            this.pnlStats.Controls.Add(this.lblPassengersTitle);
            this.pnlStats.Controls.Add(this.lblTrips);
            this.pnlStats.Controls.Add(this.lblTripsTitle);
            this.pnlStats.Location = new System.Drawing.Point(20, 150);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(732, 74);
            this.pnlStats.TabIndex = 1;
            // 
            // lblPassengers
            // 
            this.lblPassengers.AutoSize = true;
            this.lblPassengers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPassengers.Location = new System.Drawing.Point(470, 30);
            this.lblPassengers.Name = "lblPassengers";
            this.lblPassengers.Size = new System.Drawing.Size(23, 25);
            this.lblPassengers.TabIndex = 3;
            this.lblPassengers.Text = "0";
            // 
            // lblPassengersTitle
            // 
            this.lblPassengersTitle.AutoSize = true;
            this.lblPassengersTitle.Location = new System.Drawing.Point(471, 11);
            this.lblPassengersTitle.Name = "lblPassengersTitle";
            this.lblPassengersTitle.Size = new System.Drawing.Size(60, 13);
            this.lblPassengersTitle.TabIndex = 2;
            this.lblPassengersTitle.Text = "Passengers";
            // 
            // lblTrips
            // 
            this.lblTrips.AutoSize = true;
            this.lblTrips.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrips.Location = new System.Drawing.Point(120, 30);
            this.lblTrips.Name = "lblTrips";
            this.lblTrips.Size = new System.Drawing.Size(23, 25);
            this.lblTrips.TabIndex = 1;
            this.lblTrips.Text = "0";
            // 
            // lblTripsTitle
            // 
            this.lblTripsTitle.AutoSize = true;
            this.lblTripsTitle.Location = new System.Drawing.Point(121, 11);
            this.lblTripsTitle.Name = "lblTripsTitle";
            this.lblTripsTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTripsTitle.TabIndex = 0;
            this.lblTripsTitle.Text = "Trips";
            // 
            // flowReviews
            // 
            this.flowReviews.Location = new System.Drawing.Point(20, 230);
            this.flowReviews.Name = "flowReviews";
            this.flowReviews.Size = new System.Drawing.Size(732, 270);
            this.flowReviews.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(658, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DriverProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 553);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.flowReviews);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driver Profile";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
