namespace Client.Views
{
    partial class ReservationsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gridReservations;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblCount;
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gridReservations = new System.Windows.Forms.DataGridView();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(20, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(156, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel Selected";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridReservations
            // 
            this.gridReservations.AllowUserToAddRows = false;
            this.gridReservations.AllowUserToDeleteRows = false;
            this.gridReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReservations.Location = new System.Drawing.Point(20, 64);
            this.gridReservations.MultiSelect = false;
            this.gridReservations.Name = "gridReservations";
            this.gridReservations.ReadOnly = true;
            this.gridReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReservations.Size = new System.Drawing.Size(730, 330);
            this.gridReservations.TabIndex = 2;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpty.Location = new System.Drawing.Point(305, 216);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(163, 19);
            this.lblEmpty.TabIndex = 3;
            this.lblEmpty.Text = "No reservations found.";
            this.lblEmpty.Visible = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(635, 27);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(82, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Reservations: 0";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 411);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(730, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // ReservationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.gridReservations);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Name = "ReservationsControl";
            this.Size = new System.Drawing.Size(770, 470);
            this.Load += new System.EventHandler(this.ReservationsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
