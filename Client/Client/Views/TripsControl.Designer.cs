namespace Client.Views
{
    partial class TripsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCityFilter;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.NumericUpDown numPage;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView gridTrips;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtDeparture;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.NumericUpDown numCreateSeats;
        private System.Windows.Forms.Button btnCreateTrip;
        private System.Windows.Forms.NumericUpDown numReserveSeats;
        private System.Windows.Forms.Button btnReserveSeat;
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
            this.txtCityFilter = new System.Windows.Forms.TextBox();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.numPage = new System.Windows.Forms.NumericUpDown();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridTrips = new System.Windows.Forms.DataGridView();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtDeparture = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.numCreateSeats = new System.Windows.Forms.NumericUpDown();
            this.btnCreateTrip = new System.Windows.Forms.Button();
            this.numReserveSeats = new System.Windows.Forms.NumericUpDown();
            this.btnReserveSeat = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCreateSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReserveSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCityFilter
            // 
            this.txtCityFilter.Location = new System.Drawing.Point(20, 18);
            this.txtCityFilter.Name = "txtCityFilter";
            this.txtCityFilter.Size = new System.Drawing.Size(190, 20);
            this.txtCityFilter.TabIndex = 0;
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Checked = false;
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(227, 18);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.ShowCheckBox = true;
            this.dtpDateFilter.Size = new System.Drawing.Size(160, 20);
            this.dtpDateFilter.TabIndex = 1;
            // 
            // numPage
            // 
            this.numPage.Location = new System.Drawing.Point(402, 19);
            this.numPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPage.Name = "numPage";
            this.numPage.Size = new System.Drawing.Size(60, 20);
            this.numPage.TabIndex = 2;
            this.numPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(470, 19);
            this.numPageSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(60, 20);
            this.numPageSize.TabIndex = 3;
            this.numPageSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(547, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 27);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridTrips
            // 
            this.gridTrips.AllowUserToAddRows = false;
            this.gridTrips.AllowUserToDeleteRows = false;
            this.gridTrips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTrips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrips.Location = new System.Drawing.Point(20, 56);
            this.gridTrips.MultiSelect = false;
            this.gridTrips.Name = "gridTrips";
            this.gridTrips.ReadOnly = true;
            this.gridTrips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTrips.Size = new System.Drawing.Size(730, 272);
            this.gridTrips.TabIndex = 5;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpty.Location = new System.Drawing.Point(322, 182);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(126, 19);
            this.lblEmpty.TabIndex = 6;
            this.lblEmpty.Text = "No trips available.";
            this.lblEmpty.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(667, 23);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: 0";
            // 
            // txtDeparture
            // 
            this.txtDeparture.Location = new System.Drawing.Point(20, 347);
            this.txtDeparture.Name = "txtDeparture";
            this.txtDeparture.Size = new System.Drawing.Size(145, 20);
            this.txtDeparture.TabIndex = 8;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(180, 347);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(145, 20);
            this.txtDestination.TabIndex = 9;
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDate.Location = new System.Drawing.Point(340, 347);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(160, 20);
            this.dtpCreateDate.TabIndex = 10;
            // 
            // numCreateSeats
            // 
            this.numCreateSeats.Location = new System.Drawing.Point(515, 347);
            this.numCreateSeats.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numCreateSeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCreateSeats.Name = "numCreateSeats";
            this.numCreateSeats.Size = new System.Drawing.Size(60, 20);
            this.numCreateSeats.TabIndex = 11;
            this.numCreateSeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCreateTrip
            // 
            this.btnCreateTrip.Location = new System.Drawing.Point(590, 341);
            this.btnCreateTrip.Name = "btnCreateTrip";
            this.btnCreateTrip.Size = new System.Drawing.Size(160, 31);
            this.btnCreateTrip.TabIndex = 12;
            this.btnCreateTrip.Text = "Create Trip";
            this.btnCreateTrip.UseVisualStyleBackColor = true;
            this.btnCreateTrip.Click += new System.EventHandler(this.btnCreateTrip_Click);
            // 
            // numReserveSeats
            // 
            this.numReserveSeats.Location = new System.Drawing.Point(20, 387);
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
            this.numReserveSeats.Size = new System.Drawing.Size(80, 20);
            this.numReserveSeats.TabIndex = 13;
            this.numReserveSeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnReserveSeat
            // 
            this.btnReserveSeat.Location = new System.Drawing.Point(110, 381);
            this.btnReserveSeat.Name = "btnReserveSeat";
            this.btnReserveSeat.Size = new System.Drawing.Size(160, 31);
            this.btnReserveSeat.TabIndex = 14;
            this.btnReserveSeat.Text = "Reserve Seat";
            this.btnReserveSeat.UseVisualStyleBackColor = true;
            this.btnReserveSeat.Click += new System.EventHandler(this.btnReserveSeat_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 426);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(730, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 15;
            this.progressBar.Visible = false;
            // 
            // TripsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnReserveSeat);
            this.Controls.Add(this.numReserveSeats);
            this.Controls.Add(this.btnCreateTrip);
            this.Controls.Add(this.numCreateSeats);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtDeparture);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.gridTrips);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.numPage);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.txtCityFilter);
            this.Name = "TripsControl";
            this.Size = new System.Drawing.Size(770, 470);
            this.Load += new System.EventHandler(this.TripsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCreateSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReserveSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
