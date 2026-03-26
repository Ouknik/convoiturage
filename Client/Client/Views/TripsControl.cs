using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class TripsControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private readonly bool _isDriver;
        private readonly bool _isPassenger;

        public TripsControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            _isDriver = string.Equals(_apiClient.CurrentUser.role, "Driver", StringComparison.OrdinalIgnoreCase);
            _isPassenger = string.Equals(_apiClient.CurrentUser.role, "Passenger", StringComparison.OrdinalIgnoreCase);

            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private async void TripsControl_Load(object sender, EventArgs e)
        {
            btnCreateTrip.Enabled = _isDriver;
            btnReserveSeat.Enabled = _isPassenger;
            await LoadTripsAsync();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadTripsAsync();
        }

        private async void btnCreateTrip_Click(object sender, EventArgs e)
        {
            if (!_isDriver)
            {
                _notify("Only drivers can create trips.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDeparture.Text) || string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                _notify("Departure and destination are required.", false);
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.CreateTripAsync(txtDeparture.Text.Trim(), txtDestination.Text.Trim(), dtpCreateDate.Value, (int)numCreateSeats.Value);
                _notify(response.success ? "Trip created successfully." : response.message, response.success);

                if (response.success)
                {
                    txtDeparture.Clear();
                    txtDestination.Clear();
                    await LoadTripsAsync();
                }
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async void btnReserveSeat_Click(object sender, EventArgs e)
        {
            if (!_isPassenger)
            {
                _notify("Only passengers can reserve seats.", false);
                return;
            }

            var trip = gridTrips.CurrentRow?.DataBoundItem as TripResponseDto;
            if (trip == null)
            {
                _notify("Select a trip first.", false);
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.CreateReservationAsync(trip.id, (int)numReserveSeats.Value);
                _notify(response.success ? "Reservation created." : response.message, response.success);
                if (response.success)
                {
                    await LoadTripsAsync();
                }
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async Task LoadTripsAsync()
        {
            SetLoading(true);
            try
            {
                DateTime? filterDate = dtpDateFilter.Checked ? (DateTime?)dtpDateFilter.Value.Date : null;
                var response = await _apiClient.GetTripsAsync(txtCityFilter.Text.Trim(), filterDate, (int)numPage.Value, (int)numPageSize.Value);

                var trips = response.success && response.data != null
                    ? response.data.items
                    : new List<TripResponseDto>();

                gridTrips.DataSource = trips;
                lblEmpty.Visible = trips.Count == 0;
                lblTotal.Text = "Total: " + (response.data != null ? response.data.totalCount : 0);

                if (!response.success)
                {
                    _notify(response.message, false);
                }
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void SetLoading(bool loading)
        {
            progressBar.Visible = loading;
            btnSearch.Enabled = !loading;
            btnCreateTrip.Enabled = !loading && _isDriver;
            btnReserveSeat.Enabled = !loading && _isPassenger;
        }
    }
}
