namespace Client.Views
{
    partial class TripCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblWindow;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblDriverRating;
        private System.Windows.Forms.Label lblBookedInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewReservations;

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
            this.btnViewReservations = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBookedInfo = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblWindow = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblDriverRating = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnViewReservations);
            this.pnlCard.Controls.Add(this.btnDelete);
            this.pnlCard.Controls.Add(this.btnEdit);
            this.pnlCard.Controls.Add(this.btnReserve);
            this.pnlCard.Controls.Add(this.lblStatus);
            this.pnlCard.Controls.Add(this.lblBookedInfo);
            this.pnlCard.Controls.Add(this.lblDriver);
            this.pnlCard.Controls.Add(this.lblWindow);
            this.pnlCard.Controls.Add(this.lblPrice);
            this.pnlCard.Controls.Add(this.lblSeats);
            this.pnlCard.Controls.Add(this.lblDate);
            this.pnlCard.Controls.Add(this.lblRoute);
            this.pnlCard.Controls.Add(this.lblDriverRating);
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(352, 224);
            this.pnlCard.TabIndex = 0;
            // 
            // btnViewReservations
            // 
            this.btnViewReservations.Location = new System.Drawing.Point(14, 187);
            this.btnViewReservations.Name = "btnViewReservations";
            this.btnViewReservations.Size = new System.Drawing.Size(108, 28);
            this.btnViewReservations.TabIndex = 9;
            this.btnViewReservations.Text = "View Reservations";
            this.btnViewReservations.UseVisualStyleBackColor = true;
            this.btnViewReservations.Click += new System.EventHandler(this.btnViewReservations_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(188, 187);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(264, 187);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 28);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit Trip";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(264, 187);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(72, 28);
            this.btnReserve.TabIndex = 6;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(14, 152);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lblStatus.Size = new System.Drawing.Size(93, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "🟢 Upcoming";
            // 
            // lblBookedInfo
            // 
            this.lblBookedInfo.AutoSize = true;
            this.lblBookedInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblBookedInfo.Location = new System.Drawing.Point(14, 130);
            this.lblBookedInfo.Name = "lblBookedInfo";
            this.lblBookedInfo.Size = new System.Drawing.Size(104, 13);
            this.lblBookedInfo.TabIndex = 4;
            this.lblBookedInfo.Text = "👥 0 / 0 seats booked";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.ForeColor = System.Drawing.Color.DimGray;
            this.lblDriver.Location = new System.Drawing.Point(181, 107);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(47, 13);
            this.lblDriver.TabIndex = 3;
            this.lblDriver.Text = "Driver: -";
            // 
            // lblDriverRating
            // 
            this.lblDriverRating.AutoSize = true;
            this.lblDriverRating.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblDriverRating.Location = new System.Drawing.Point(181, 130);
            this.lblDriverRating.Name = "lblDriverRating";
            this.lblDriverRating.Size = new System.Drawing.Size(58, 13);
            this.lblDriverRating.TabIndex = 12;
            this.lblDriverRating.Text = "★★★★☆ 4.0";
            // 
            // lblWindow
            // 
            this.lblWindow.AutoSize = true;
            this.lblWindow.ForeColor = System.Drawing.Color.DimGray;
            this.lblWindow.Location = new System.Drawing.Point(14, 107);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(87, 13);
            this.lblWindow.TabIndex = 11;
            this.lblWindow.Text = "Start - End / Days";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrice.Location = new System.Drawing.Point(181, 77);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(45, 13);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "Price: -";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeats.Location = new System.Drawing.Point(14, 77);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(44, 13);
            this.lblSeats.TabIndex = 2;
            this.lblSeats.Text = "Seats: -";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblDate.Location = new System.Drawing.Point(14, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date and time";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblRoute.Location = new System.Drawing.Point(13, 18);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(167, 20);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Departure → Destination";
            // 
            // TripCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCard);
            this.Name = "TripCardControl";
            this.Size = new System.Drawing.Size(352, 224);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
