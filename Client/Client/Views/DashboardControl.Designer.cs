namespace Client.Views
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel cardTrips;
        private System.Windows.Forms.Panel cardReservations;
        private System.Windows.Forms.Label lblTripsTitle;
        private System.Windows.Forms.Label lblReservationsTitle;
        private System.Windows.Forms.Label lblTripsValue;
        private System.Windows.Forms.Label lblReservationsValue;
        private System.Windows.Forms.Button btnRefresh;
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cardTrips = new System.Windows.Forms.Panel();
            this.lblTripsValue = new System.Windows.Forms.Label();
            this.lblTripsTitle = new System.Windows.Forms.Label();
            this.cardReservations = new System.Windows.Forms.Panel();
            this.lblReservationsValue = new System.Windows.Forms.Label();
            this.lblReservationsTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cardTrips.SuspendLayout();
            this.cardReservations.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(24, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(129, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome...";
            // 
            // cardTrips
            // 
            this.cardTrips.BackColor = System.Drawing.Color.White;
            this.cardTrips.Controls.Add(this.lblTripsValue);
            this.cardTrips.Controls.Add(this.lblTripsTitle);
            this.cardTrips.Location = new System.Drawing.Point(29, 88);
            this.cardTrips.Name = "cardTrips";
            this.cardTrips.Size = new System.Drawing.Size(260, 130);
            this.cardTrips.TabIndex = 1;
            // 
            // lblTripsValue
            // 
            this.lblTripsValue.AutoSize = true;
            this.lblTripsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTripsValue.Location = new System.Drawing.Point(15, 53);
            this.lblTripsValue.Name = "lblTripsValue";
            this.lblTripsValue.Size = new System.Drawing.Size(38, 45);
            this.lblTripsValue.TabIndex = 1;
            this.lblTripsValue.Text = "-";
            // 
            // lblTripsTitle
            // 
            this.lblTripsTitle.AutoSize = true;
            this.lblTripsTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTripsTitle.Location = new System.Drawing.Point(19, 20);
            this.lblTripsTitle.Name = "lblTripsTitle";
            this.lblTripsTitle.Size = new System.Drawing.Size(78, 19);
            this.lblTripsTitle.TabIndex = 0;
            this.lblTripsTitle.Text = "Total Trips";
            // 
            // cardReservations
            // 
            this.cardReservations.BackColor = System.Drawing.Color.White;
            this.cardReservations.Controls.Add(this.lblReservationsValue);
            this.cardReservations.Controls.Add(this.lblReservationsTitle);
            this.cardReservations.Location = new System.Drawing.Point(316, 88);
            this.cardReservations.Name = "cardReservations";
            this.cardReservations.Size = new System.Drawing.Size(260, 130);
            this.cardReservations.TabIndex = 2;
            // 
            // lblReservationsValue
            // 
            this.lblReservationsValue.AutoSize = true;
            this.lblReservationsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblReservationsValue.Location = new System.Drawing.Point(15, 53);
            this.lblReservationsValue.Name = "lblReservationsValue";
            this.lblReservationsValue.Size = new System.Drawing.Size(38, 45);
            this.lblReservationsValue.TabIndex = 1;
            this.lblReservationsValue.Text = "-";
            // 
            // lblReservationsTitle
            // 
            this.lblReservationsTitle.AutoSize = true;
            this.lblReservationsTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReservationsTitle.Location = new System.Drawing.Point(19, 20);
            this.lblReservationsTitle.Name = "lblReservationsTitle";
            this.lblReservationsTitle.Size = new System.Drawing.Size(125, 19);
            this.lblReservationsTitle.TabIndex = 0;
            this.lblReservationsTitle.Text = "My Reservations";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(597, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 31);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 239);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(547, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cardReservations);
            this.Controls.Add(this.cardTrips);
            this.Controls.Add(this.lblWelcome);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(760, 520);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.cardTrips.ResumeLayout(false);
            this.cardTrips.PerformLayout();
            this.cardReservations.ResumeLayout(false);
            this.cardReservations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
