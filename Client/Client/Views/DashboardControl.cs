using Client.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class DashboardControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private readonly string _role;
        private readonly Dictionary<string, Label> _statLabels = new Dictionary<string, Label>();

        public DashboardControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            _role = (_apiClient.CurrentUser.role ?? string.Empty).Trim();

            InitializeComponent();
            Dock = DockStyle.Fill;
            ApplySaasStyle();
            BuildRoleLayout();
        }

        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _apiClient.CurrentUser.name;
            lblRoleBadge.Text = _role;
            await RefreshSummaryAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshSummaryAsync();
        }

        private void ApplySaasStyle()
        {
            btnRefresh.BackColor = Color.FromArgb(79, 70, 229);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatAppearance.BorderSize = 0;

            btnQuickAction.BackColor = Color.FromArgb(79, 70, 229);
            btnQuickAction.ForeColor = Color.White;
            btnQuickAction.FlatAppearance.BorderSize = 0;

            flowStats.WrapContents = true;
            flowStats.AutoScroll = false;

            listActivities.Items.Clear();
            listActivities.Items.Add("No activity loaded.");
        }

        private void BuildRoleLayout()
        {
            flowStats.Controls.Clear();
            _statLabels.Clear();

            if (string.Equals(_role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                AddStatCard("Total Users", "users");
                AddStatCard("Total Trips", "trips");
                AddStatCard("Total Reservations", "reservations");
                AddStatCard("Total Payments", "payments");

                lblOverviewTitle.Text = "System Overview";
                lblOverviewText.Text = "Monitor platform health, usage growth, and payment flow from this admin dashboard.";
                btnQuickAction.Text = "Open Admin Panel";
                listActivities.Items.Clear();
                listActivities.Items.Add("• Review new user signups.");
                listActivities.Items.Add("• Check payment statuses.");
                listActivities.Items.Add("• Monitor reservation activity.");
            }
            else if (string.Equals(_role, "Driver", StringComparison.OrdinalIgnoreCase))
            {
                AddStatCard("My Trips", "trips");
                AddStatCard("Active Trips", "activeTrips");
                AddStatCard("Total Earnings", "earnings");

                lblOverviewTitle.Text = "Driver Overview";
                lblOverviewText.Text = "Track your trips and occupancy quickly. Keep your schedule fresh and seats updated.";
                btnQuickAction.Text = "Create Trip";
                listActivities.Items.Clear();
                listActivities.Items.Add("• Add upcoming trips to attract passengers.");
                listActivities.Items.Add("• Keep seat availability accurate.");
                listActivities.Items.Add("• Check reservation updates regularly.");
            }
            else
            {
                AddStatCard("My Reservations", "reservations");
                AddStatCard("Upcoming Trips", "upcomingTrips");
                AddStatCard("Payment Status", "paymentStatus");

                lblOverviewTitle.Text = "Passenger Overview";
                lblOverviewText.Text = "Manage your bookings and follow payment state from one place.";
                btnQuickAction.Text = "Find Trip";
                listActivities.Items.Clear();
                listActivities.Items.Add("• Search trips matching your city and date.");
                listActivities.Items.Add("• Reserve seats and choose payment method.");
                listActivities.Items.Add("• Track pending/paid status.");
            }
        }

        private void AddStatCard(string title, string key)
        {
            var card = new Panel
            {
                BackColor = Color.White,
                Width = 160,
                Height = 132,
                Margin = new Padding(0, 0, 16, 0)
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(75, 85, 99),
                AutoSize = false,
                Width = 130,
                Height = 40,
                Location = new Point(14, 14)
            };

            var lblValue = new Label
            {
                Text = "-",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                AutoSize = false,
                Width = 130,
                Height = 60,
                Location = new Point(14, 56)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            flowStats.Controls.Add(card);
            _statLabels[key] = lblValue;
        }

        private async Task RefreshSummaryAsync()
        {
            SetLoading(true);
            try
            {
                var trips = await _apiClient.GetTripsAsync(string.Empty, null, 1, 50);
                var reservations = await _apiClient.GetReservationsAsync();

                var totalTrips = trips.success && trips.data != null ? trips.data.totalCount : 0;
                var myReservations = reservations.success && reservations.data != null ? reservations.data.Count : 0;

                SetStat("trips", totalTrips.ToString());
                SetStat("reservations", myReservations.ToString());

                if (_statLabels.ContainsKey("activeTrips"))
                {
                    var active = trips.success && trips.data != null
                        ? trips.data.items.Count(x => string.Equals(x.status, "Upcoming", StringComparison.OrdinalIgnoreCase) || string.Equals(x.status, "Ongoing", StringComparison.OrdinalIgnoreCase))
                        : 0;
                    SetStat("activeTrips", active.ToString());
                }

                if (_statLabels.ContainsKey("earnings"))
                {
                    SetStat("earnings", "$" + (myReservations * 50));
                }

                if (_statLabels.ContainsKey("upcomingTrips"))
                {
                    var upcoming = trips.success && trips.data != null
                        ? trips.data.items.Count(x => string.Equals(x.status, "Upcoming", StringComparison.OrdinalIgnoreCase))
                        : 0;
                    SetStat("upcomingTrips", upcoming.ToString());
                }

                if (_statLabels.ContainsKey("paymentStatus"))
                {
                    var pending = reservations.success && reservations.data != null
                        ? reservations.data.Count(x => string.Equals(x.paymentStatus, "Pending", StringComparison.OrdinalIgnoreCase))
                        : 0;
                    SetStat("paymentStatus", pending > 0 ? "🟡 Pending" : "🟢 Paid");
                }

                if (string.Equals(_role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var users = await _apiClient.GetAdminUsersAsync();
                    var payments = await _apiClient.GetAdminPaymentsAsync();

                    SetStat("users", users.success && users.data != null ? users.data.Count.ToString() : "0");
                    SetStat("payments", payments.success && payments.data != null ? payments.data.Count.ToString() : "0");
                }
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

        private void SetStat(string key, string value)
        {
            if (_statLabels.TryGetValue(key, out var label))
            {
                label.Text = value;
            }
        }

        private void SetLoading(bool loading)
        {
            progressBar.Visible = loading;
            btnRefresh.Enabled = !loading;
            btnQuickAction.Enabled = !loading;
        }
    }
}
