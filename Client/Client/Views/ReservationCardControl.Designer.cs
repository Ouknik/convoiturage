namespace Client.Views
{
    partial class ReservationCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblTripDate;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTripWindow;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblReservationStatus;
        private System.Windows.Forms.Label lblTripStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLeaveReview;
        private System.Windows.Forms.Button btnDriverProfile;
        private System.Windows.Forms.Label lblReviewedBadge;

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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDriverProfile = new System.Windows.Forms.Button();
            this.btnLeaveReview = new System.Windows.Forms.Button();
            this.lblReviewedBadge = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTripStatus = new System.Windows.Forms.Label();
            this.lblReservationStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblTripWindow = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblTripDate = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnDelete);
            this.pnlCard.Controls.Add(this.btnDriverProfile);
            this.pnlCard.Controls.Add(this.btnLeaveReview);
            this.pnlCard.Controls.Add(this.lblReviewedBadge);
            this.pnlCard.Controls.Add(this.btnDetails);
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Controls.Add(this.lblTripStatus);
            this.pnlCard.Controls.Add(this.lblReservationStatus);
            this.pnlCard.Controls.Add(this.lblPaymentStatus);
            this.pnlCard.Controls.Add(this.lblPaymentMethod);
            this.pnlCard.Controls.Add(this.lblDriver);
            this.pnlCard.Controls.Add(this.lblTripWindow);
            this.pnlCard.Controls.Add(this.lblPrice);
            this.pnlCard.Controls.Add(this.lblSeats);
            this.pnlCard.Controls.Add(this.lblTripDate);
            this.pnlCard.Controls.Add(this.lblRoute);
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(342, 232);
            this.pnlCard.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(14, 194);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDriverProfile
            // 
            this.btnDriverProfile.Location = new System.Drawing.Point(95, 194);
            this.btnDriverProfile.Name = "btnDriverProfile";
            this.btnDriverProfile.Size = new System.Drawing.Size(95, 28);
            this.btnDriverProfile.TabIndex = 12;
            this.btnDriverProfile.Text = "Driver Profile";
            this.btnDriverProfile.UseVisualStyleBackColor = true;
            this.btnDriverProfile.Click += new System.EventHandler(this.btnDriverProfile_Click);
            // 
            // btnLeaveReview
            // 
            this.btnLeaveReview.Location = new System.Drawing.Point(196, 194);
            this.btnLeaveReview.Name = "btnLeaveReview";
            this.btnLeaveReview.Size = new System.Drawing.Size(90, 28);
            this.btnLeaveReview.TabIndex = 11;
            this.btnLeaveReview.Text = "Leave Review";
            this.btnLeaveReview.UseVisualStyleBackColor = true;
            this.btnLeaveReview.Click += new System.EventHandler(this.btnLeaveReview_Click);
            // 
            // lblReviewedBadge
            // 
            this.lblReviewedBadge.AutoSize = true;
            this.lblReviewedBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblReviewedBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblReviewedBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.lblReviewedBadge.Location = new System.Drawing.Point(196, 201);
            this.lblReviewedBadge.Name = "lblReviewedBadge";
            this.lblReviewedBadge.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblReviewedBadge.Size = new System.Drawing.Size(103, 21);
            this.lblReviewedBadge.TabIndex = 13;
            this.lblReviewedBadge.Text = "Already reviewed";
            this.lblReviewedBadge.Visible = false;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(292, 194);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(46, 28);
            this.btnDetails.TabIndex = 9;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTripStatus
            // 
            this.lblTripStatus.AutoSize = true;
            this.lblTripStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTripStatus.Location = new System.Drawing.Point(14, 163);
            this.lblTripStatus.Name = "lblTripStatus";
            this.lblTripStatus.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lblTripStatus.Size = new System.Drawing.Size(93, 23);
            this.lblTripStatus.TabIndex = 7;
            this.lblTripStatus.Text = "🟢 Upcoming";
            // 
            // lblReservationStatus
            // 
            this.lblReservationStatus.AutoSize = true;
            this.lblReservationStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblReservationStatus.Location = new System.Drawing.Point(136, 163);
            this.lblReservationStatus.Name = "lblReservationStatus";
            this.lblReservationStatus.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lblReservationStatus.Size = new System.Drawing.Size(96, 23);
            this.lblReservationStatus.TabIndex = 6;
            this.lblReservationStatus.Text = "🟢 Confirmed";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPaymentStatus.Location = new System.Drawing.Point(250, 163);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lblPaymentStatus.Size = new System.Drawing.Size(78, 23);
            this.lblPaymentStatus.TabIndex = 5;
            this.lblPaymentStatus.Text = "🟡 Pending";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.DimGray;
            this.lblPaymentMethod.Location = new System.Drawing.Point(14, 138);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(76, 13);
            this.lblPaymentMethod.TabIndex = 4;
            this.lblPaymentMethod.Text = "Payment: Cash";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.ForeColor = System.Drawing.Color.DimGray;
            this.lblDriver.Location = new System.Drawing.Point(14, 114);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(47, 13);
            this.lblDriver.TabIndex = 3;
            this.lblDriver.Text = "Driver: -";
            // 
            // lblTripWindow
            // 
            this.lblTripWindow.AutoSize = true;
            this.lblTripWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTripWindow.Location = new System.Drawing.Point(14, 91);
            this.lblTripWindow.Name = "lblTripWindow";
            this.lblTripWindow.Size = new System.Drawing.Size(121, 13);
            this.lblTripWindow.TabIndex = 12;
            this.lblTripWindow.Text = "Start: - | End: -";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrice.Location = new System.Drawing.Point(170, 63);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(48, 13);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Price: 0";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeats.Location = new System.Drawing.Point(14, 63);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(44, 13);
            this.lblSeats.TabIndex = 2;
            this.lblSeats.Text = "Seats: -";
            // 
            // lblTripDate
            // 
            this.lblTripDate.AutoSize = true;
            this.lblTripDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTripDate.Location = new System.Drawing.Point(14, 41);
            this.lblTripDate.Name = "lblTripDate";
            this.lblTripDate.Size = new System.Drawing.Size(80, 13);
            this.lblTripDate.TabIndex = 1;
            this.lblTripDate.Text = "Date and time";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblRoute.Location = new System.Drawing.Point(13, 14);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(167, 20);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Departure → Destination";
            // 
            // ReservationCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCard);
            this.Name = "ReservationCardControl";
            this.Size = new System.Drawing.Size(342, 232);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
