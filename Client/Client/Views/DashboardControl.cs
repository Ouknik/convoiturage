using Client.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class DashboardControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;

        public DashboardControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _apiClient.CurrentUser.name;
            await RefreshSummaryAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshSummaryAsync();
        }

        private async Task RefreshSummaryAsync()
        {
            SetLoading(true);
            try
            {
                var trips = await _apiClient.GetTripsAsync(string.Empty, null, 1, 10);
                var reservations = await _apiClient.GetReservationsAsync();

                lblTripsValue.Text = trips.success && trips.data != null ? trips.data.totalCount.ToString() : "-";
                lblReservationsValue.Text = reservations.success && reservations.data != null ? reservations.data.Count.ToString() : "-";
            }
            catch (Exception ex)
            {
                _notify("Dashboard load failed: " + ex.Message, false);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void SetLoading(bool loading)
        {
            progressBar.Visible = loading;
            btnRefresh.Enabled = !loading;
        }
    }
}
