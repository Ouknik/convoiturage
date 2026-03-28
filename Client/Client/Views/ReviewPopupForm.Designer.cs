namespace Client.Views
{
    partial class ReviewPopupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblStar1;
        private System.Windows.Forms.Label lblStar2;
        private System.Windows.Forms.Label lblStar3;
        private System.Windows.Forms.Label lblStar4;
        private System.Windows.Forms.Label lblStar5;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;

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
            this.lblError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblStar5 = new System.Windows.Forms.Label();
            this.lblStar4 = new System.Windows.Forms.Label();
            this.lblStar3 = new System.Windows.Forms.Label();
            this.lblStar2 = new System.Windows.Forms.Label();
            this.lblStar1 = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Controls.Add(this.btnSubmit);
            this.pnlCard.Controls.Add(this.txtComment);
            this.pnlCard.Controls.Add(this.lblStar5);
            this.pnlCard.Controls.Add(this.lblStar4);
            this.pnlCard.Controls.Add(this.lblStar3);
            this.pnlCard.Controls.Add(this.lblStar2);
            this.pnlCard.Controls.Add(this.lblStar1);
            this.pnlCard.Controls.Add(this.lblRoute);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Location = new System.Drawing.Point(22, 22);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(420, 306);
            this.pnlCard.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(20, 246);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(379, 18);
            this.lblError.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(285, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(165, 265);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(114, 30);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit Review";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(23, 111);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(376, 130);
            this.txtComment.TabIndex = 7;
            // 
            // lblStar5
            // 
            this.lblStar5.AutoSize = true;
            this.lblStar5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStar5.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblStar5.Location = new System.Drawing.Point(212, 72);
            this.lblStar5.Name = "lblStar5";
            this.lblStar5.Size = new System.Drawing.Size(31, 32);
            this.lblStar5.TabIndex = 6;
            this.lblStar5.Tag = "5";
            this.lblStar5.Text = "★";
            this.lblStar5.Click += new System.EventHandler(this.Star_Click);
            // 
            // lblStar4
            // 
            this.lblStar4.AutoSize = true;
            this.lblStar4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStar4.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblStar4.Location = new System.Drawing.Point(175, 72);
            this.lblStar4.Name = "lblStar4";
            this.lblStar4.Size = new System.Drawing.Size(31, 32);
            this.lblStar4.TabIndex = 5;
            this.lblStar4.Tag = "4";
            this.lblStar4.Text = "★";
            this.lblStar4.Click += new System.EventHandler(this.Star_Click);
            // 
            // lblStar3
            // 
            this.lblStar3.AutoSize = true;
            this.lblStar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStar3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblStar3.Location = new System.Drawing.Point(138, 72);
            this.lblStar3.Name = "lblStar3";
            this.lblStar3.Size = new System.Drawing.Size(31, 32);
            this.lblStar3.TabIndex = 4;
            this.lblStar3.Tag = "3";
            this.lblStar3.Text = "★";
            this.lblStar3.Click += new System.EventHandler(this.Star_Click);
            // 
            // lblStar2
            // 
            this.lblStar2.AutoSize = true;
            this.lblStar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStar2.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblStar2.Location = new System.Drawing.Point(101, 72);
            this.lblStar2.Name = "lblStar2";
            this.lblStar2.Size = new System.Drawing.Size(31, 32);
            this.lblStar2.TabIndex = 3;
            this.lblStar2.Tag = "2";
            this.lblStar2.Text = "★";
            this.lblStar2.Click += new System.EventHandler(this.Star_Click);
            // 
            // lblStar1
            // 
            this.lblStar1.AutoSize = true;
            this.lblStar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStar1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblStar1.Location = new System.Drawing.Point(64, 72);
            this.lblStar1.Name = "lblStar1";
            this.lblStar1.Size = new System.Drawing.Size(31, 32);
            this.lblStar1.TabIndex = 2;
            this.lblStar1.Tag = "1";
            this.lblStar1.Text = "★";
            this.lblStar1.Click += new System.EventHandler(this.Star_Click);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoute.Location = new System.Drawing.Point(20, 48);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(83, 13);
            this.lblRoute.TabIndex = 1;
            this.lblRoute.Text = "Route placeholder";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Leave a review";
            // 
            // ReviewPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(464, 350);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Review";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
