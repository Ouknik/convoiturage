namespace Client.Views
{
    partial class ReservationPaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblRouteValue;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblSeatsValue;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.Label lblCashHint;
        private System.Windows.Forms.Panel pnlCardPayment;
        private System.Windows.Forms.Label lblCardHolder;
        private System.Windows.Forms.TextBox txtCardHolder;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.MaskedTextBox mtbCardNumber;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.MaskedTextBox mtbExpiry;
        private System.Windows.Forms.Label lblCvv;
        private System.Windows.Forms.MaskedTextBox mtbCvv;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;

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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlCardPayment = new System.Windows.Forms.Panel();
            this.mtbCvv = new System.Windows.Forms.MaskedTextBox();
            this.lblCvv = new System.Windows.Forms.Label();
            this.mtbExpiry = new System.Windows.Forms.MaskedTextBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.mtbCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardHolder = new System.Windows.Forms.TextBox();
            this.lblCardHolder = new System.Windows.Forms.Label();
            this.lblCashHint = new System.Windows.Forms.Label();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.lblSeatsValue = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblRouteValue = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlCardPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Controls.Add(this.btnConfirm);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.pnlCardPayment);
            this.pnlCard.Controls.Add(this.lblCashHint);
            this.pnlCard.Controls.Add(this.rbCard);
            this.pnlCard.Controls.Add(this.rbCash);
            this.pnlCard.Controls.Add(this.lblSeatsValue);
            this.pnlCard.Controls.Add(this.lblSeats);
            this.pnlCard.Controls.Add(this.lblRouteValue);
            this.pnlCard.Controls.Add(this.lblRoute);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Location = new System.Drawing.Point(24, 24);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(472, 432);
            this.pnlCard.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(211, 384);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(116, 32);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm Reservation";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(23, 361);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(426, 18);
            this.lblError.TabIndex = 10;
            // 
            // pnlCardPayment
            // 
            this.pnlCardPayment.Controls.Add(this.mtbCvv);
            this.pnlCardPayment.Controls.Add(this.lblCvv);
            this.pnlCardPayment.Controls.Add(this.mtbExpiry);
            this.pnlCardPayment.Controls.Add(this.lblExpiry);
            this.pnlCardPayment.Controls.Add(this.mtbCardNumber);
            this.pnlCardPayment.Controls.Add(this.lblCardNumber);
            this.pnlCardPayment.Controls.Add(this.txtCardHolder);
            this.pnlCardPayment.Controls.Add(this.lblCardHolder);
            this.pnlCardPayment.Location = new System.Drawing.Point(23, 178);
            this.pnlCardPayment.Name = "pnlCardPayment";
            this.pnlCardPayment.Size = new System.Drawing.Size(426, 174);
            this.pnlCardPayment.TabIndex = 9;
            this.pnlCardPayment.Visible = false;
            // 
            // mtbCvv
            // 
            this.mtbCvv.Location = new System.Drawing.Point(333, 128);
            this.mtbCvv.Mask = "000";
            this.mtbCvv.Name = "mtbCvv";
            this.mtbCvv.Size = new System.Drawing.Size(70, 20);
            this.mtbCvv.TabIndex = 7;
            this.mtbCvv.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCvv
            // 
            this.lblCvv.AutoSize = true;
            this.lblCvv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCvv.Location = new System.Drawing.Point(330, 111);
            this.lblCvv.Name = "lblCvv";
            this.lblCvv.Size = new System.Drawing.Size(29, 13);
            this.lblCvv.TabIndex = 6;
            this.lblCvv.Text = "CVV";
            // 
            // mtbExpiry
            // 
            this.mtbExpiry.Location = new System.Drawing.Point(20, 128);
            this.mtbExpiry.Mask = "00/00";
            this.mtbExpiry.Name = "mtbExpiry";
            this.mtbExpiry.Size = new System.Drawing.Size(80, 20);
            this.mtbExpiry.TabIndex = 5;
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblExpiry.Location = new System.Drawing.Point(17, 111);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(74, 13);
            this.lblExpiry.TabIndex = 4;
            this.lblExpiry.Text = "Expiry (MM/YY)";
            // 
            // mtbCardNumber
            // 
            this.mtbCardNumber.Location = new System.Drawing.Point(20, 82);
            this.mtbCardNumber.Mask = "0000 0000 0000 0000";
            this.mtbCardNumber.Name = "mtbCardNumber";
            this.mtbCardNumber.Size = new System.Drawing.Size(383, 20);
            this.mtbCardNumber.TabIndex = 3;
            this.mtbCardNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCardNumber.Location = new System.Drawing.Point(17, 65);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(69, 13);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "Card Number";
            // 
            // txtCardHolder
            // 
            this.txtCardHolder.Location = new System.Drawing.Point(20, 36);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Size = new System.Drawing.Size(383, 20);
            this.txtCardHolder.TabIndex = 1;
            // 
            // lblCardHolder
            // 
            this.lblCardHolder.AutoSize = true;
            this.lblCardHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCardHolder.Location = new System.Drawing.Point(17, 19);
            this.lblCardHolder.Name = "lblCardHolder";
            this.lblCardHolder.Size = new System.Drawing.Size(88, 13);
            this.lblCardHolder.TabIndex = 0;
            this.lblCardHolder.Text = "Card Holder Name";
            // 
            // lblCashHint
            // 
            this.lblCashHint.Location = new System.Drawing.Point(23, 184);
            this.lblCashHint.Name = "lblCashHint";
            this.lblCashHint.Size = new System.Drawing.Size(426, 34);
            this.lblCashHint.TabIndex = 8;
            this.lblCashHint.Text = "You will pay directly to the driver.";
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(104, 148);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(47, 17);
            this.rbCard.TabIndex = 7;
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            this.rbCard.CheckedChanged += new System.EventHandler(this.rbCard_CheckedChanged);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(26, 148);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(49, 17);
            this.rbCash.TabIndex = 6;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // lblSeatsValue
            // 
            this.lblSeatsValue.AutoSize = true;
            this.lblSeatsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeatsValue.Location = new System.Drawing.Point(72, 111);
            this.lblSeatsValue.Name = "lblSeatsValue";
            this.lblSeatsValue.Size = new System.Drawing.Size(14, 15);
            this.lblSeatsValue.TabIndex = 5;
            this.lblSeatsValue.Text = "1";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeats.Location = new System.Drawing.Point(23, 111);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(37, 13);
            this.lblSeats.TabIndex = 4;
            this.lblSeats.Text = "Seats:";
            // 
            // lblRouteValue
            // 
            this.lblRouteValue.AutoSize = true;
            this.lblRouteValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRouteValue.Location = new System.Drawing.Point(72, 88);
            this.lblRouteValue.Name = "lblRouteValue";
            this.lblRouteValue.Size = new System.Drawing.Size(120, 15);
            this.lblRouteValue.TabIndex = 3;
            this.lblRouteValue.Text = "City A → City B";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoute.Location = new System.Drawing.Point(23, 88);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(39, 13);
            this.lblRoute.TabIndex = 2;
            this.lblRoute.Text = "Route:";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(23, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(200, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Choose payment method to confirm booking";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(21, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reservation Payment";
            // 
            // ReservationPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(520, 480);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlCardPayment.ResumeLayout(false);
            this.pnlCardPayment.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
