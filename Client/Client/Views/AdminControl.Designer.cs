namespace Client.Views
{
    partial class AdminControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblCardValue;
        private System.Windows.Forms.Panel pnlActivity;
        private System.Windows.Forms.Label lblActivityTitle;
        private System.Windows.Forms.ListBox listActivity;

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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblCardValue = new System.Windows.Forms.Label();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.pnlActivity = new System.Windows.Forms.Panel();
            this.listActivity = new System.Windows.Forms.ListBox();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Panel";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(30, 58);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(147, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage and monitor section";
            // 
            // pnlCard
            // 
            this.pnlCard.Controls.Add(this.lblCardValue);
            this.pnlCard.Controls.Add(this.lblCardTitle);
            this.pnlCard.Location = new System.Drawing.Point(33, 96);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(280, 130);
            this.pnlCard.TabIndex = 2;
            // 
            // lblCardValue
            // 
            this.lblCardValue.AutoSize = true;
            this.lblCardValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCardValue.Location = new System.Drawing.Point(17, 52);
            this.lblCardValue.Name = "lblCardValue";
            this.lblCardValue.Size = new System.Drawing.Size(38, 45);
            this.lblCardValue.TabIndex = 1;
            this.lblCardValue.Text = "-";
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardTitle.Location = new System.Drawing.Point(21, 20);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(120, 19);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "Section Overview";
            // 
            // pnlActivity
            // 
            this.pnlActivity.Controls.Add(this.listActivity);
            this.pnlActivity.Controls.Add(this.lblActivityTitle);
            this.pnlActivity.Location = new System.Drawing.Point(33, 246);
            this.pnlActivity.Name = "pnlActivity";
            this.pnlActivity.Size = new System.Drawing.Size(680, 210);
            this.pnlActivity.TabIndex = 3;
            // 
            // listActivity
            // 
            this.listActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listActivity.FormattingEnabled = true;
            this.listActivity.Items.AddRange(new object[] {
            "No recent activity.",
            "Use admin endpoints to load real-time data.",
            "This panel is ready for advanced widgets."});
            this.listActivity.Location = new System.Drawing.Point(24, 48);
            this.listActivity.Name = "listActivity";
            this.listActivity.Size = new System.Drawing.Size(632, 143);
            this.listActivity.TabIndex = 1;
            // 
            // lblActivityTitle
            // 
            this.lblActivityTitle.AutoSize = true;
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActivityTitle.Location = new System.Drawing.Point(20, 16);
            this.lblActivityTitle.Name = "lblActivityTitle";
            this.lblActivityTitle.Size = new System.Drawing.Size(111, 19);
            this.lblActivityTitle.TabIndex = 0;
            this.lblActivityTitle.Text = "Recent Activity";
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlActivity);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(780, 520);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlActivity.ResumeLayout(false);
            this.pnlActivity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
