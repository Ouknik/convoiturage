using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ReservationsControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private readonly bool _isAdmin;

        private List<ReservationCardViewModel> _cards = new List<ReservationCardViewModel>();

        public ReservationsControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            _isAdmin = string.Equals(_apiClient.CurrentUser.role, "Admin", StringComparison.OrdinalIgnoreCase);

            InitializeComponent();
            Dock = DockStyle.Fill;
            ApplyStyle();
        }

        private async void ReservationsControl_Load(object sender, EventArgs e)
        {
            txtSearch.PlaceholderText("Search by destination or driver");
            cmbStatusFilter.SelectedIndex = 0;
            await LoadReservationsAsync();
        }

        private void ApplyStyle()
        {
            foreach (var button in new[] { btnRefresh, btnFindTrips })
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(79, 70, 229);
                button.ForeColor = Color.White;
            }

            flowReservations.WrapContents = true;
            flowReservations.FlowDirection = FlowDirection.LeftToRight;
            flowReservations.AutoScroll = true;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadReservationsAsync();
        }

        private async Task LoadReservationsAsync()
        {
            SetLoading(true);

            try
            {
                var trips = _isAdmin
                    ? await _apiClient.GetAdminTripsAsync()
                    : await _apiClient.GetTripsAsync(string.Empty, null, 1, 500).ContinueWith(t =>
                    {
                        var r = t.Result;
                        return new ApiEnvelope<List<TripResponseDto>>
                        {
                            success = r.success,
                            message = r.message,
                            data = r.data != null ? r.data.items : new List<TripResponseDto>()
                        };
                    });

                var tripMap = (trips.success && trips.data != null)
                    ? trips.data.ToDictionary(t => t.id, t => t)
                    : new Dictionary<int, TripResponseDto>();

                if (_isAdmin)
                {
                    var response = await _apiClient.GetAdminReservationsAsync();
                    _cards = response.success && response.data != null
                        ? response.data.Select(x => BuildCardFromAdmin(x, tripMap)).ToList()
                        : new List<ReservationCardViewModel>();

                    if (!response.success)
                    {
                        _notify(response.message, false);
                    }
                }
                else
                {
                    var response = await _apiClient.GetReservationsAsync();
                    _cards = response.success && response.data != null
                        ? response.data.Select(x => BuildCardFromPassenger(x, tripMap)).ToList()
                        : new List<ReservationCardViewModel>();

                    await PopulateReviewEligibilityAsync(_cards);

                    if (!response.success)
                    {
                        _notify(response.message, false);
                    }
                }

                RenderCards(ApplyFilters(_cards));
            }
            finally
            {
                SetLoading(false);
            }
        }

        private List<ReservationCardViewModel> ApplyFilters(List<ReservationCardViewModel> source)
        {
            var query = source.AsEnumerable();

            var search = GetInputValue(txtSearch, "Search by destination or driver");
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    (!string.IsNullOrWhiteSpace(x.Route) && x.Route.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrWhiteSpace(x.DriverName) && x.DriverName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            if (dtpDateFilter.Checked)
            {
                var date = dtpDateFilter.Value.Date;
                query = query.Where(x => x.TripDate.Date == date);
            }

            var status = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
            if (!string.Equals(status, "All", StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(status, "Completed", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => string.Equals(x.TripStatus, "Completed", StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    query = query.Where(x => string.Equals(x.PaymentStatus, status, StringComparison.OrdinalIgnoreCase));
                }
            }

            return query.ToList();
        }

        private void RenderCards(List<ReservationCardViewModel> cards)
        {
            flowReservations.Controls.Clear();

            foreach (var vm in cards)
            {
                var card = new ReservationCardControl(vm, !_isAdmin, _isAdmin)
                {
                    Margin = new Padding(0, 0, 16, 16)
                };

                card.CancelClicked += async (s, e) => await CancelReservationAsync(vm);
                card.DetailsClicked += (s, e) => ShowDetails(vm);
                card.DeleteClicked += async (s, e) => await DeleteReservationAsync(vm);
                card.LeaveReviewClicked += async (s, e) => await LeaveReviewAsync(vm);
                card.DriverProfileClicked += async (s, e) => await OpenDriverProfileAsync(vm);

                flowReservations.Controls.Add(card);
            }

            lblCount.Text = "Reservations: " + cards.Count;
            var empty = cards.Count == 0;
            lblEmpty.Visible = empty;
            btnFindTrips.Visible = empty;
        }

        private async Task CancelReservationAsync(ReservationCardViewModel vm)
        {
            if (vm.IsTripCompleted)
            {
                _notify("Cannot cancel completed trip reservation.", false);
                return;
            }

            var confirm = MessageBox.Show("Cancel this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.DeleteReservationAsync(vm.ReservationId);
                _notify(response.success ? "Reservation canceled successfully." : response.message, response.success);
                if (response.success)
                {
                    await LoadReservationsAsync();
                }
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async Task DeleteReservationAsync(ReservationCardViewModel vm)
        {
            var confirm = MessageBox.Show("Delete this reservation as admin?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.DeleteAdminReservationAsync(vm.ReservationId);
                _notify(response.success ? "Reservation deleted." : response.message, response.success);
                if (response.success)
                {
                    await LoadReservationsAsync();
                }
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void ShowDetails(ReservationCardViewModel vm)
        {
            var details = "Route: " + vm.Route + Environment.NewLine
                + "Trip: " + vm.TripDateText + Environment.NewLine
                + "Trip Start: " + vm.TripStartText + Environment.NewLine
                + "Trip End: " + vm.TripEndText + Environment.NewLine
                + "Seats: " + vm.SeatsReserved + Environment.NewLine
                + "Total Price: " + vm.TotalPrice.ToString("0.00") + Environment.NewLine
                + "Driver: " + vm.DriverName + Environment.NewLine
                + "Payment: " + vm.PaymentMethod + " / " + vm.PaymentStatus + Environment.NewLine
                + "Reservation Status: " + vm.ReservationStatus + Environment.NewLine
                + "Trip Status: " + vm.TripStatus;

            MessageBox.Show(details, "Reservation Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindTrips_Click(object sender, EventArgs e)
        {
            _notify("Go to Trips screen and reserve your first trip.", true);
        }

        private async Task PopulateReviewEligibilityAsync(List<ReservationCardViewModel> cards)
        {
            var byDriver = cards
                .Where(c => c.DriverId > 0)
                .Select(c => c.DriverId)
                .Distinct()
                .ToList();

            var reviewedTripIds = new HashSet<int>();

            foreach (var driverId in byDriver)
            {
                var response = await _apiClient.GetDriverReviewsAsync(driverId);
                if (!response.success || response.data == null)
                {
                    continue;
                }

                foreach (var review in response.data.Where(r => r.passengerId == _apiClient.CurrentUser.userId))
                {
                    reviewedTripIds.Add(review.tripId);
                }
            }

            foreach (var vm in cards)
            {
                vm.CanLeaveReview = vm.IsTripCompleted && !reviewedTripIds.Contains(vm.TripId);
                vm.HasReviewed = reviewedTripIds.Contains(vm.TripId);
            }
        }

        private async Task LeaveReviewAsync(ReservationCardViewModel vm)
        {
            if (!vm.IsTripCompleted)
            {
                _notify("You can only leave a review after trip completion.", false);
                return;
            }

            if (vm.HasReviewed)
            {
                _notify("You already reviewed this trip.", false);
                return;
            }

            using (var popup = new ReviewPopupForm(vm.Route))
            {
                if (popup.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                SetLoading(true);
                try
                {
                    var response = await _apiClient.CreateReviewAsync(vm.TripId, popup.SelectedRating, popup.ReviewComment);
                    _notify(response.success ? "Review submitted successfully." : response.message, response.success);
                    if (response.success)
                    {
                        await LoadReservationsAsync();
                    }
                }
                finally
                {
                    SetLoading(false);
                }
            }
        }

        private async Task OpenDriverProfileAsync(ReservationCardViewModel vm)
        {
            if (vm.DriverId <= 0)
            {
                _notify("Driver profile is unavailable.", false);
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.GetDriverProfileAsync(vm.DriverId);
                if (!response.success || response.data == null)
                {
                    _notify(response.message ?? "Cannot open driver profile.", false);
                    return;
                }

                using (var profile = new DriverProfileForm(response.data))
                {
                    profile.ShowDialog(this);
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
            btnRefresh.Enabled = !loading;
            btnFindTrips.Enabled = !loading;
        }

        private static string GetInputValue(TextBox textBox, string placeholder)
        {
            if (textBox.ForeColor == Color.Gray && string.Equals(textBox.Text, placeholder, StringComparison.Ordinal))
            {
                return string.Empty;
            }

            return (textBox.Text ?? string.Empty).Trim();
        }

        private static ReservationCardViewModel BuildCardFromPassenger(ReservationResponseDto row, Dictionary<int, TripResponseDto> tripMap)
        {
            tripMap.TryGetValue(row.tripId, out var trip);

            var tripDate = ParseDate(trip != null ? trip.departureTime : null);
            var tripStatus = trip != null ? (trip.status ?? "Upcoming") : "Upcoming";
            var timeWindow = BuildTripTimeWindow(trip, tripDate);

            return new ReservationCardViewModel
            {
                ReservationId = row.id,
                TripId = row.tripId,
                DriverId = trip != null ? trip.driverId : 0,
                Route = (trip != null ? trip.departure : "Unknown") + " → " + (trip != null ? trip.destination : "Unknown"),
                TripDate = tripDate,
                TripDateText = tripDate.ToString("ddd, dd MMM yyyy - HH:mm"),
                TripStartText = timeWindow.start,
                TripEndText = timeWindow.end,
                SeatsReserved = row.seatsReserved,
                TotalPrice = row.paymentAmount,
                DriverName = trip != null ? ("Driver #" + trip.driverId) : "Driver -",
                PaymentMethod = string.IsNullOrWhiteSpace(row.paymentMethod) ? "Cash" : row.paymentMethod,
                PaymentStatus = string.IsNullOrWhiteSpace(row.paymentStatus) ? "Pending" : row.paymentStatus,
                ReservationStatus = "Confirmed",
                TripStatus = tripStatus,
                CanLeaveReview = false,
                HasReviewed = false
            };
        }

        private static ReservationCardViewModel BuildCardFromAdmin(AdminReservationDto row, Dictionary<int, TripResponseDto> tripMap)
        {
            tripMap.TryGetValue(row.tripId, out var trip);

            var tripDate = ParseDate(trip != null ? trip.departureTime : null);
            var tripStatus = trip != null ? (trip.status ?? "Upcoming") : "Upcoming";
            var timeWindow = BuildTripTimeWindow(trip, tripDate);

            return new ReservationCardViewModel
            {
                ReservationId = row.id,
                TripId = row.tripId,
                DriverId = trip != null ? trip.driverId : 0,
                Route = (trip != null ? trip.departure : "Unknown") + " → " + (trip != null ? trip.destination : "Unknown"),
                TripDate = tripDate,
                TripDateText = tripDate.ToString("ddd, dd MMM yyyy - HH:mm"),
                TripStartText = timeWindow.start,
                TripEndText = timeWindow.end,
                SeatsReserved = row.seatsReserved,
                TotalPrice = 0,
                DriverName = trip != null ? ("Driver #" + trip.driverId) : "Driver -",
                PaymentMethod = string.IsNullOrWhiteSpace(row.paymentMethod) ? "Cash" : row.paymentMethod,
                PaymentStatus = string.IsNullOrWhiteSpace(row.paymentStatus) ? "Pending" : row.paymentStatus,
                ReservationStatus = "Confirmed",
                TripStatus = tripStatus,
                CanLeaveReview = false,
                HasReviewed = false
            };
        }

        private static DateTime ParseDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DateTime.MinValue;
            }

            DateTime parsed;
            if (DateTime.TryParse(value, out parsed))
            {
                return parsed;
            }

            return DateTime.MinValue;
        }

        private static (string start, string end) BuildTripTimeWindow(TripResponseDto trip, DateTime fallbackTripDate)
        {
            var startDate = ParseDate(trip != null ? trip.startDate : null);
            var endDate = ParseDate(trip != null ? trip.endDate : null);

            var startTimeText = trip != null ? trip.startTime : null;
            var startText = startDate != DateTime.MinValue
                ? startDate.ToString("dd/MM/yyyy") + " " + (string.IsNullOrWhiteSpace(startTimeText) ? "-" : startTimeText)
                : fallbackTripDate.ToString("dd/MM/yyyy HH:mm");

            var endText = endDate != DateTime.MinValue ? endDate.ToString("dd/MM/yyyy") : "N/A";
            return (startText, endText);
        }
    }
}
