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
    public partial class TripsControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private readonly bool _isDriver;
        private readonly bool _isPassenger;
        private readonly bool _isAdmin;

        private List<TripResponseDto> _loadedTrips = new List<TripResponseDto>();

        public TripsControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            _isDriver = string.Equals(_apiClient.CurrentUser.role, "Driver", StringComparison.OrdinalIgnoreCase);
            _isPassenger = string.Equals(_apiClient.CurrentUser.role, "Passenger", StringComparison.OrdinalIgnoreCase);
            _isAdmin = string.Equals(_apiClient.CurrentUser.role, "Admin", StringComparison.OrdinalIgnoreCase);

            InitializeComponent();
            Dock = DockStyle.Fill;
            ApplyStyle();
        }

        private async void TripsControl_Load(object sender, EventArgs e)
        {
            txtCityFilter.PlaceholderText("Search by city");

            btnCreateTrip.Visible = _isDriver || _isAdmin;
            lblReserveSeats.Visible = _isPassenger;
            numReserveSeats.Visible = _isPassenger;
            lblPaymentMethod.Visible = false;
            cmbPaymentMethod.Visible = false;

            cmbPaymentMethod.SelectedIndex = 0;

            await LoadTripsAsync();
        }

        private void ApplyStyle()
        {
            foreach (var b in new[] { btnSearch, btnCreateTrip })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.Cursor = Cursors.Hand;
            }

            btnSearch.BackColor = Color.FromArgb(55, 65, 81);
            btnSearch.ForeColor = Color.White;

            btnCreateTrip.BackColor = Color.FromArgb(79, 70, 229);
            btnCreateTrip.ForeColor = Color.White;

            flowTrips.WrapContents = true;
            flowTrips.FlowDirection = FlowDirection.LeftToRight;
            flowTrips.AutoScroll = true;

            cmbPaymentMethod.Width = 120;
            cmbPaymentMethod.Location = new Point(541, 81);
            lblPaymentMethod.Location = new Point(548, 64);
            btnCreateTrip.Location = new Point(674, 76);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadTripsAsync();
        }

        private async void btnCreateTrip_Click(object sender, EventArgs e)
        {
            using (var modal = new TripEditorForm("Create Trip", "Create"))
            {
                if (modal.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                SetLoading(true);
                try
                {
                    var response = await _apiClient.CreateTripAsync(
                        modal.DepartureText,
                        modal.DestinationText,
                        modal.StartDate,
                        modal.EndDate,
                        modal.StartTime,
                        modal.PricePerSeat,
                        modal.Seats);
                    _notify(response.success ? "Trip created successfully." : response.message, response.success);

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
        }

        private async Task LoadTripsAsync()
        {
            SetLoading(true);
            try
            {
                var city = GetInputValue(txtCityFilter, "Search by city");
                DateTime? filterDate = dtpDateFilter.Checked ? (DateTime?)dtpDateFilter.Value.Date : null;
                var response = await _apiClient.GetTripsAsync(city, filterDate, 1, 100);

                _loadedTrips = response.success && response.data != null
                    ? response.data.items
                    : new List<TripResponseDto>();

                var bookedMap = await BuildBookedSeatsMapAsync();
                var ratingsMap = await BuildDriverRatingsMapAsync(_loadedTrips);
                RenderTripCards(bookedMap, ratingsMap);

                lblTotal.Text = "Total: " + _loadedTrips.Count;
                lblEmpty.Visible = _loadedTrips.Count == 0;

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

        private async Task<Dictionary<int, int>> BuildBookedSeatsMapAsync()
        {
            var map = new Dictionary<int, int>();

            if (_isAdmin)
            {
                var reservations = await _apiClient.GetAdminReservationsAsync();
                if (reservations.success && reservations.data != null)
                {
                    foreach (var grp in reservations.data.GroupBy(x => x.tripId))
                    {
                        map[grp.Key] = grp.Sum(x => x.seatsReserved);
                    }
                }
            }

            foreach (var trip in _loadedTrips)
            {
                if (!map.ContainsKey(trip.id))
                {
                    var estimated = Math.Max(0, 8 - trip.availableSeats);
                    map[trip.id] = estimated;
                }
            }

            return map;
        }

        private void RenderTripCards(Dictionary<int, int> bookedByTrip, Dictionary<int, string> ratingsByDriver)
        {
            flowTrips.Controls.Clear();

            foreach (var trip in _loadedTrips)
            {
                var booked = bookedByTrip.ContainsKey(trip.id) ? bookedByTrip[trip.id] : 0;
                var totalSeats = Math.Max(trip.availableSeats + booked, 1);

                var viewModel = new TripCardViewModel
                {
                    Trip = trip,
                    DriverName = "Driver #" + trip.driverId,
                    DriverRatingText = ratingsByDriver.ContainsKey(trip.driverId)
                        ? ratingsByDriver[trip.driverId]
                        : "No rating yet",
                    TripWindowText = BuildTripWindowText(trip),
                    BookedSeats = booked,
                    TotalSeats = totalSeats,
                    ShowReserve = _isPassenger,
                    ShowEdit = _isDriver,
                    ShowDelete = _isDriver || _isAdmin,
                    ShowViewReservations = _isDriver || _isAdmin
                };

                var card = new TripCardControl(viewModel)
                {
                    Margin = new Padding(0, 0, 16, 16)
                };

                card.ReserveClicked += async (s, e) => await ReserveTripAsync(card.Trip);
                card.DeleteClicked += async (s, e) => await DeleteTripAsync(card.Trip);
                card.EditClicked += async (s, e) => await EditTripAsync(card.Trip);
                card.ViewReservationsClicked += async (s, e) => await ViewTripReservationsAsync(card.Trip);

                flowTrips.Controls.Add(card);
            }
        }

        private async Task ReserveTripAsync(TripResponseDto trip)
        {
            if (!_isPassenger)
            {
                return;
            }

            var isCompleted = string.Equals(trip.status, "Completed", StringComparison.OrdinalIgnoreCase);
            if (trip.availableSeats <= 0 || isCompleted)
            {
                _notify("Reserve unavailable (no seats or trip completed).", false);
                return;
            }

            string method;
            string cardHolder = null;
            string cardNumber = null;
            string expiry = null;
            string cvv = null;
            using (var paymentModal = new ReservationPaymentForm(trip.departure + " → " + trip.destination, (int)numReserveSeats.Value))
            {
                if (paymentModal.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                method = paymentModal.SelectedPaymentMethod;
                if (string.Equals(method, "Card", StringComparison.OrdinalIgnoreCase))
                {
                    cardHolder = paymentModal.CardHolderName;
                    cardNumber = paymentModal.CardNumber;
                    expiry = paymentModal.ExpiryDate;
                    cvv = paymentModal.Cvv;
                }
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.CreateReservationAsync(
                    trip.id,
                    (int)numReserveSeats.Value,
                    method,
                    cardHolder,
                    cardNumber,
                    expiry,
                    cvv);
                _notify(response.success ? "Reservation done successfully." : response.message, response.success);

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

        private async Task DeleteTripAsync(TripResponseDto trip)
        {
            if (!(_isDriver || _isAdmin))
            {
                return;
            }

            var confirm = MessageBox.Show("Delete this trip?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            SetLoading(true);
            try
            {
                ApiEnvelope<object> response;
                if (_isAdmin && !_isDriver)
                {
                    response = await _apiClient.DeleteAdminTripAsync(trip.id);
                }
                else
                {
                    response = await _apiClient.DeleteTripAsync(trip.id);
                }

                _notify(response.success ? "Trip deleted." : response.message, response.success);
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

        private async Task EditTripAsync(TripResponseDto trip)
        {
            if (!_isDriver)
            {
                return;
            }

            DateTime parsed;
            var departureTime = DateTime.TryParse(trip.departureTime, out parsed) ? parsed : DateTime.Now.AddHours(1);

            DateTime startDate;
            if (!DateTime.TryParse(trip.startDate, out startDate))
            {
                startDate = departureTime.Date;
            }

            DateTime endDate;
            if (!DateTime.TryParse(trip.endDate, out endDate))
            {
                endDate = startDate;
            }

            TimeSpan startTime;
            if (!TimeSpan.TryParse(trip.startTime, out startTime))
            {
                startTime = departureTime.TimeOfDay;
            }

            using (var modal = new TripEditorForm("Edit Trip", "Save Changes", new TripEditorModel
            {
                Departure = trip.departure,
                Destination = trip.destination,
                StartDate = startDate,
                EndDate = endDate,
                StartTime = startTime,
                PricePerSeat = trip.pricePerSeat <= 0 ? 1 : trip.pricePerSeat,
                Seats = Math.Max(1, trip.availableSeats)
            }))
            {
                if (modal.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // UI-first edit behavior: update local card model for immediate UX feedback.
                trip.departure = modal.DepartureText;
                trip.destination = modal.DestinationText;
                trip.departureTime = modal.StartDate.Date.Add(modal.StartTime).ToString("o");
                trip.startDate = modal.StartDate.ToString("o");
                trip.endDate = modal.EndDate.ToString("o");
                trip.startTime = modal.StartTime.ToString();
                trip.numberOfDays = modal.NumberOfDays;
                trip.pricePerSeat = modal.PricePerSeat;
                trip.availableSeats = modal.Seats;

                _notify("Trip updated successfully.", true);
                RenderTripCards(await BuildBookedSeatsMapAsync(), await BuildDriverRatingsMapAsync(_loadedTrips));
            }
        }

        private async Task ViewTripReservationsAsync(TripResponseDto trip)
        {
            var rows = new List<TripReservationItem>();

            if (_isAdmin || _isDriver)
            {
                var response = await _apiClient.GetTripReservationsAsync(trip.id);
                if (response.success && response.data != null)
                {
                    rows = response.data
                        .Select(x => new TripReservationItem
                        {
                            Passenger = "User #" + x.userId,
                            Seats = x.seatsReserved,
                            PaymentStatus = x.paymentStatus
                        })
                        .ToList();
                }
                else
                {
                    _notify(response.message ?? "Unable to load trip reservations.", false);
                }
            }
            else
            {
                _notify("Only drivers/admin can view trip reservations.", false);
                return;
            }

            using (var modal = new TripReservationsForm(trip.departure + " → " + trip.destination, rows))
            {
                modal.ShowDialog(this);
            }
        }

        private void SetLoading(bool loading)
        {
            progressBar.Visible = loading;
            btnSearch.Enabled = !loading;
            btnCreateTrip.Enabled = !loading && (_isDriver || _isAdmin);
        }

        private static string BuildTripWindowText(TripResponseDto trip)
        {
            DateTime start;
            DateTime end;

            var hasStart = DateTime.TryParse(trip.startDate, out start);
            var hasEnd = DateTime.TryParse(trip.endDate, out end);

            var startText = hasStart ? start.ToString("dd/MM/yyyy") : "-";
            var endText = hasEnd ? end.ToString("dd/MM/yyyy") : "-";
            var timeText = !string.IsNullOrWhiteSpace(trip.startTime) ? trip.startTime : "-";

            return "Start: " + startText + " " + timeText + " | End: " + endText + " | Days: " + Math.Max(1, trip.numberOfDays);
        }

        private async Task<Dictionary<int, string>> BuildDriverRatingsMapAsync(IEnumerable<TripResponseDto> trips)
        {
            var map = new Dictionary<int, string>();
            var driverIds = trips.Select(t => t.driverId).Distinct().ToList();

            foreach (var driverId in driverIds)
            {
                var profile = await _apiClient.GetDriverProfileAsync(driverId);
                if (!profile.success || profile.data == null)
                {
                    map[driverId] = "No rating yet";
                    continue;
                }

                var avg = profile.data.averageRating;
                var total = profile.data.totalReviews;
                map[driverId] = total <= 0
                    ? "No rating yet"
                    : BuildStars(avg) + " " + avg.ToString("0.0") + " (" + total + ")";
            }

            return map;
        }

        private static string BuildStars(double rating)
        {
            var rounded = (int)Math.Round(rating, MidpointRounding.AwayFromZero);
            if (rounded < 0) rounded = 0;
            if (rounded > 5) rounded = 5;
            return new string('★', rounded) + new string('☆', 5 - rounded);
        }

        private static string GetInputValue(TextBox textBox, string placeholder)
        {
            if (textBox.ForeColor == Color.Gray && string.Equals(textBox.Text, placeholder, StringComparison.Ordinal))
            {
                return string.Empty;
            }

            return (textBox.Text ?? string.Empty).Trim();
        }
    }

    internal static class TripsTextBoxExtensions
    {
        public static void PlaceholderText(this TextBox textBox, string value)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = value;
                textBox.ForeColor = Color.Gray;
            }

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == value)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = value;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
