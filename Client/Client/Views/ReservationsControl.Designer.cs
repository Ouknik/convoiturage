namespace Client.Views
{
    partial class ReservationsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flowReservations;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Button btnFindTrips;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.flowReservations = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.btnFindTrips = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(22, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Reservations";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(25, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(130, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage your booked trips";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(28, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Checked = false;
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(294, 82);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.ShowCheckBox = true;
            this.dtpDateFilter.Size = new System.Drawing.Size(120, 20);
            this.dtpDateFilter.TabIndex = 3;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Paid",
            "Completed"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(420, 81);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(115, 21);
            this.cmbStatusFilter.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(541, 76);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Apply";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(666, 85);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(82, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Reservations: 0";
            // 
            // flowReservations
            // 
            this.flowReservations.AutoScroll = true;
            this.flowReservations.Location = new System.Drawing.Point(28, 116);
            this.flowReservations.Name = "flowReservations";
            this.flowReservations.Size = new System.Drawing.Size(744, 370);
            this.flowReservations.TabIndex = 7;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpty.Location = new System.Drawing.Point(298, 268);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(186, 19);
            this.lblEmpty.TabIndex = 8;
            this.lblEmpty.Text = "🚫 You have no reservations yet";
            this.lblEmpty.Visible = false;
            // 
            // btnFindTrips
            // 
            this.btnFindTrips.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindTrips.Location = new System.Drawing.Point(333, 296);
            this.btnFindTrips.Name = "btnFindTrips";
            this.btnFindTrips.Size = new System.Drawing.Size(112, 30);
            this.btnFindTrips.TabIndex = 9;
            this.btnFindTrips.Text = "Find Trips";
            this.btnFindTrips.UseVisualStyleBackColor = true;
            this.btnFindTrips.Visible = false;
            this.btnFindTrips.Click += new System.EventHandler(this.btnFindTrips_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 496);
            this.progressBar.MarqueeAnimationSpeed = 28;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(744, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // ReservationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnFindTrips);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.flowReservations);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReservationsControl";
            this.Size = new System.Drawing.Size(800, 520);
            this.Load += new System.EventHandler(this.ReservationsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
