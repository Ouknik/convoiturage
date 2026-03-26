using Client.Services;
using Client.UI;
using System;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _apiClient;
        private DashboardControl _dashboardControl;
        private TripsControl _tripsControl;
        private ReservationsControl _reservationsControl;
        private ProfileControl _profileControl;

        public MainForm(ApiClient apiClient)
        {
            _apiClient = apiClient;
            InitializeComponent();
            ApplyTheme();
            lblHeaderUser.Text = _apiClient.CurrentUser.name;
            lblHeaderRole.Text = _apiClient.CurrentUser.role;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            _dashboardControl = new DashboardControl(_apiClient, ShowToast);
            _tripsControl = new TripsControl(_apiClient, ShowToast);
            _reservationsControl = new ReservationsControl(_apiClient, ShowToast);
            _profileControl = new ProfileControl(_apiClient, ShowToast);

            NavigateTo(_dashboardControl);
            await System.Threading.Tasks.Task.CompletedTask;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            NavigateTo(_dashboardControl);
        }

        private void btnTrips_Click(object sender, EventArgs e)
        {
            NavigateTo(_tripsControl);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            NavigateTo(_reservationsControl);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            NavigateTo(_profileControl);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Close();
            }
        }

        private void NavigateTo(Control control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
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
            BackColor = AppTheme.Secondary;
            pnlSidebar.BackColor = AppTheme.Sidebar;
            pnlHeader.BackColor = System.Drawing.Color.White;
        }
    }
}
