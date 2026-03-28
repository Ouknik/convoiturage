using Client.Services;
using Client.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _apiClient;
        public bool LogoutRequested { get; private set; }
        private DashboardControl _dashboardControl;
        private TripsControl _tripsControl;
        private ReservationsControl _reservationsControl;
        private ProfileControl _profileControl;
        private AdminControl _usersControl;
        private AdminControl _paymentsControl;
        private AdminControl _adminPanelControl;
        private readonly List<Button> _menuButtons = new List<Button>();
        private readonly bool _isAdmin;

        public MainForm(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _isAdmin = string.Equals(_apiClient.CurrentUser.role, "Admin", StringComparison.OrdinalIgnoreCase);
            InitializeComponent();
            ApplyTheme();
            lblHeaderUser.Text = _apiClient.CurrentUser.name;
            lblHeaderRole.Text = _apiClient.CurrentUser.role;
            ConfigureRoleMenus();
            ConfigureAvatar();
            RegisterMenuButtons();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            _dashboardControl = new DashboardControl(_apiClient, ShowToast);
            _tripsControl = new TripsControl(_apiClient, ShowToast);
            _reservationsControl = new ReservationsControl(_apiClient, ShowToast);
            _profileControl = new ProfileControl(_apiClient, ShowToast);
            _usersControl = new AdminControl("Users", "Manage platform users and access levels.");
            _paymentsControl = new AdminControl("Payments", "Monitor all payment operations and statuses.");
            _adminPanelControl = new AdminControl("Admin Panel", "System-wide controls and operations.");

            NavigateTo(_dashboardControl, btnDashboard, "Dashboard");
            await System.Threading.Tasks.Task.CompletedTask;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            NavigateTo(_dashboardControl, btnDashboard, "Dashboard");
        }

        private void btnTrips_Click(object sender, EventArgs e)
        {
            NavigateTo(_tripsControl, btnTrips, "Trips");
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            NavigateTo(_reservationsControl, btnReservations, "Reservations");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            NavigateTo(_profileControl, btnProfile, "Profile");
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            NavigateTo(_usersControl, btnUsers, "Users");
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            NavigateTo(_paymentsControl, btnPayments, "Payments");
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            NavigateTo(_adminPanelControl, btnAdminPanel, "Admin Panel");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                LogoutRequested = true;
                Close();
            }
        }

        private void NavigateTo(Control control, Button activeButton, string pageTitle)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            lblHeaderTitle.Text = pageTitle;
            SetActiveMenu(activeButton);
        }

        private void ShowToast(string message, bool success)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            var toast = new ToastForm(message, success);
            toast.ShowToast(this);
        }

        private void ApplyTheme()
        {
            Font = AppTheme.DefaultFont;
            BackColor = Color.FromArgb(249, 250, 251);
            pnlSidebar.BackColor = Color.FromArgb(31, 41, 55);
            pnlHeader.BackColor = Color.White;
            pnlContent.BackColor = Color.FromArgb(249, 250, 251);

            lblAppTitle.Text = "CoMove";
            lblAppTitle.ForeColor = Color.White;
            lblHeaderRole.ForeColor = Color.FromArgb(79, 70, 229);

            foreach (var btn in new[] { btnDashboard, btnTrips, btnReservations, btnProfile, btnUsers, btnPayments, btnAdminPanel, btnLogout })
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(16, 0, 0, 0);
                btn.BackColor = Color.FromArgb(31, 41, 55);
                btn.Cursor = Cursors.Hand;
            }

            btnDashboard.Text = "🏠  Dashboard";
            btnTrips.Text = "🚗  Trips";
            btnReservations.Text = "📅  Reservations";
            btnProfile.Text = "👤  Profile";
            btnUsers.Text = "👥  Users";
            btnPayments.Text = "💳  Payments";
            btnAdminPanel.Text = "🛠  Admin Panel";
            btnLogout.Text = "↩  Logout";

            lblHeaderRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeaderUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        }

        private void ConfigureRoleMenus()
        {
            btnUsers.Visible = _isAdmin;
            btnPayments.Visible = _isAdmin;
            btnAdminPanel.Visible = _isAdmin;
        }

        private void RegisterMenuButtons()
        {
            _menuButtons.Clear();
            _menuButtons.Add(btnDashboard);
            _menuButtons.Add(btnTrips);
            _menuButtons.Add(btnReservations);
            _menuButtons.Add(btnProfile);

            if (_isAdmin)
            {
                _menuButtons.Add(btnUsers);
                _menuButtons.Add(btnPayments);
                _menuButtons.Add(btnAdminPanel);
            }
        }

        private void SetActiveMenu(Button activeButton)
        {
            foreach (var btn in _menuButtons)
            {
                btn.BackColor = Color.FromArgb(31, 41, 55);
                btn.ForeColor = Color.White;
            }

            activeButton.BackColor = Color.FromArgb(79, 70, 229);
            activeButton.ForeColor = Color.White;
        }

        private void ConfigureAvatar()
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, picHeader.Width, picHeader.Height);
                picHeader.Region = new Region(path);
            }

            var bmp = new Bitmap(picHeader.Width, picHeader.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(79, 70, 229));

                var initials = string.IsNullOrWhiteSpace(_apiClient.CurrentUser.name)
                    ? "U"
                    : _apiClient.CurrentUser.name.Substring(0, 1).ToUpperInvariant();

                using (var brush = new SolidBrush(Color.White))
                using (var f = new Font("Segoe UI", 16F, FontStyle.Bold))
                {
                    var size = g.MeasureString(initials, f);
                    g.DrawString(initials, f, brush, (bmp.Width - size.Width) / 2, (bmp.Height - size.Height) / 2 - 1);
                }
            }

            picHeader.Image = bmp;
        }
    }
}
