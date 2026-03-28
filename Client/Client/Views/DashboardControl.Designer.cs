namespace Client.Views
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FlowLayoutPanel flowStats;
        private System.Windows.Forms.Panel pnlActivities;
        private System.Windows.Forms.Label lblActivitiesTitle;
        private System.Windows.Forms.ListBox listActivities;
        private System.Windows.Forms.Panel pnlOverview;
        private System.Windows.Forms.Label lblOverviewTitle;
        private System.Windows.Forms.Label lblOverviewText;
        private System.Windows.Forms.Button btnQuickAction;

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
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.flowStats = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlActivities = new System.Windows.Forms.Panel();
            this.listActivities = new System.Windows.Forms.ListBox();
            this.lblActivitiesTitle = new System.Windows.Forms.Label();
            this.pnlOverview = new System.Windows.Forms.Panel();
            this.lblOverviewText = new System.Windows.Forms.Label();
            this.lblOverviewTitle = new System.Windows.Forms.Label();
            this.btnQuickAction = new System.Windows.Forms.Button();
            this.pnlActivities.SuspendLayout();
            this.pnlOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(24, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(129, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome...";
            // 
            // lblRoleBadge
            // 
            this.lblRoleBadge.AutoSize = true;
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblRoleBadge.Location = new System.Drawing.Point(29, 60);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.lblRoleBadge.Size = new System.Drawing.Size(83, 23);
            this.lblRoleBadge.TabIndex = 1;
            this.lblRoleBadge.Text = "Passenger";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(617, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 95);
            this.progressBar.MarqueeAnimationSpeed = 24;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(699, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // flowStats
            // 
            this.flowStats.Location = new System.Drawing.Point(29, 120);
            this.flowStats.Name = "flowStats";
            this.flowStats.Size = new System.Drawing.Size(699, 160);
            this.flowStats.TabIndex = 4;
            // 
            // pnlActivities
            // 
            this.pnlActivities.BackColor = System.Drawing.Color.White;
            this.pnlActivities.Controls.Add(this.listActivities);
            this.pnlActivities.Controls.Add(this.lblActivitiesTitle);
            this.pnlActivities.Location = new System.Drawing.Point(29, 297);
            this.pnlActivities.Name = "pnlActivities";
            this.pnlActivities.Size = new System.Drawing.Size(338, 210);
            this.pnlActivities.TabIndex = 5;
            // 
            // listActivities
            // 
            this.listActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listActivities.FormattingEnabled = true;
            this.listActivities.Location = new System.Drawing.Point(20, 46);
            this.listActivities.Name = "listActivities";
            this.listActivities.Size = new System.Drawing.Size(298, 143);
            this.listActivities.TabIndex = 1;
            // 
            // lblActivitiesTitle
            // 
            this.lblActivitiesTitle.AutoSize = true;
            this.lblActivitiesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActivitiesTitle.Location = new System.Drawing.Point(16, 16);
            this.lblActivitiesTitle.Name = "lblActivitiesTitle";
            this.lblActivitiesTitle.Size = new System.Drawing.Size(111, 19);
            this.lblActivitiesTitle.TabIndex = 0;
            this.lblActivitiesTitle.Text = "Recent Activity";
            // 
            // pnlOverview
            // 
            this.pnlOverview.BackColor = System.Drawing.Color.White;
            this.pnlOverview.Controls.Add(this.btnQuickAction);
            this.pnlOverview.Controls.Add(this.lblOverviewText);
            this.pnlOverview.Controls.Add(this.lblOverviewTitle);
            this.pnlOverview.Location = new System.Drawing.Point(390, 297);
            this.pnlOverview.Name = "pnlOverview";
            this.pnlOverview.Size = new System.Drawing.Size(338, 210);
            this.pnlOverview.TabIndex = 6;
            // 
            // lblOverviewText
            // 
            this.lblOverviewText.ForeColor = System.Drawing.Color.DimGray;
            this.lblOverviewText.Location = new System.Drawing.Point(18, 46);
            this.lblOverviewText.Name = "lblOverviewText";
            this.lblOverviewText.Size = new System.Drawing.Size(302, 89);
            this.lblOverviewText.TabIndex = 1;
            this.lblOverviewText.Text = "System overview and quick summary go here.";
            // 
            // lblOverviewTitle
            // 
            this.lblOverviewTitle.AutoSize = true;
            this.lblOverviewTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOverviewTitle.Location = new System.Drawing.Point(16, 16);
            this.lblOverviewTitle.Name = "lblOverviewTitle";
            this.lblOverviewTitle.Size = new System.Drawing.Size(111, 19);
            this.lblOverviewTitle.TabIndex = 0;
            this.lblOverviewTitle.Text = "System Overview";
            // 
            // btnQuickAction
            // 
            this.btnQuickAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickAction.Location = new System.Drawing.Point(21, 149);
            this.btnQuickAction.Name = "btnQuickAction";
            this.btnQuickAction.Size = new System.Drawing.Size(152, 36);
            this.btnQuickAction.TabIndex = 2;
            this.btnQuickAction.Text = "Quick Action";
            this.btnQuickAction.UseVisualStyleBackColor = true;
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.pnlOverview);
            this.Controls.Add(this.pnlActivities);
            this.Controls.Add(this.flowStats);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblRoleBadge);
            this.Controls.Add(this.lblWelcome);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(760, 520);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.pnlActivities.ResumeLayout(false);
            this.pnlActivities.PerformLayout();
            this.pnlOverview.ResumeLayout(false);
            this.pnlOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
