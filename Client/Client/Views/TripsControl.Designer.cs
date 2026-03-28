namespace Client.Views
{
    partial class TripsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtCityFilter;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCreateTrip;
        private System.Windows.Forms.Label lblReserveSeats;
        private System.Windows.Forms.NumericUpDown numReserveSeats;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.FlowLayoutPanel flowTrips;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblTotal;
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
            this.txtCityFilter = new System.Windows.Forms.TextBox();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateTrip = new System.Windows.Forms.Button();
            this.lblReserveSeats = new System.Windows.Forms.Label();
            this.numReserveSeats = new System.Windows.Forms.NumericUpDown();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.flowTrips = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numReserveSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(22, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trips";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(25, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(107, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Find or manage trips";
            // 
            // txtCityFilter
            // 
            this.txtCityFilter.Location = new System.Drawing.Point(28, 81);
            this.txtCityFilter.Name = "txtCityFilter";
            this.txtCityFilter.Size = new System.Drawing.Size(198, 20);
            this.txtCityFilter.TabIndex = 2;
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Checked = false;
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(232, 81);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.ShowCheckBox = true;
            this.dtpDateFilter.Size = new System.Drawing.Size(130, 20);
            this.dtpDateFilter.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(368, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateTrip
            // 
            this.btnCreateTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTrip.Location = new System.Drawing.Point(674, 76);
            this.btnCreateTrip.Name = "btnCreateTrip";
            this.btnCreateTrip.Size = new System.Drawing.Size(106, 30);
            this.btnCreateTrip.TabIndex = 5;
            this.btnCreateTrip.Text = "+ Create Trip";
            this.btnCreateTrip.UseVisualStyleBackColor = true;
            this.btnCreateTrip.Click += new System.EventHandler(this.btnCreateTrip_Click);
            // 
            // lblReserveSeats
            // 
            this.lblReserveSeats.AutoSize = true;
            this.lblReserveSeats.ForeColor = System.Drawing.Color.DimGray;
            this.lblReserveSeats.Location = new System.Drawing.Point(458, 84);
            this.lblReserveSeats.Name = "lblReserveSeats";
            this.lblReserveSeats.Size = new System.Drawing.Size(32, 13);
            this.lblReserveSeats.TabIndex = 6;
            this.lblReserveSeats.Text = "Seats";
            // 
            // numReserveSeats
            // 
            this.numReserveSeats.Location = new System.Drawing.Point(496, 82);
            this.numReserveSeats.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numReserveSeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReserveSeats.Name = "numReserveSeats";
            this.numReserveSeats.Size = new System.Drawing.Size(44, 20);
            this.numReserveSeats.TabIndex = 7;
            this.numReserveSeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.DimGray;
            this.lblPaymentMethod.Location = new System.Drawing.Point(548, 84);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(87, 13);
            this.lblPaymentMethod.TabIndex = 8;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(641, 81);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(27, 21);
            this.cmbPaymentMethod.TabIndex = 9;
            // 
            // flowTrips
            // 
            this.flowTrips.AutoScroll = true;
            this.flowTrips.Location = new System.Drawing.Point(28, 119);
            this.flowTrips.Name = "flowTrips";
            this.flowTrips.Size = new System.Drawing.Size(752, 378);
            this.flowTrips.TabIndex = 10;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpty.Location = new System.Drawing.Point(327, 290);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(120, 19);
            this.lblEmpty.TabIndex = 11;
            this.lblEmpty.Text = "No trips available";
            this.lblEmpty.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(712, 56);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total: 0";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 507);
            this.progressBar.MarqueeAnimationSpeed = 26;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(752, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 13;
            this.progressBar.Visible = false;
            // 
            // TripsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.flowTrips);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.numReserveSeats);
            this.Controls.Add(this.lblReserveSeats);
            this.Controls.Add(this.btnCreateTrip);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.txtCityFilter);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "TripsControl";
            this.Size = new System.Drawing.Size(810, 530);
            this.Load += new System.EventHandler(this.TripsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numReserveSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
