using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ReservationCardControl : UserControl
    {
        private readonly ReservationCardViewModel _model;
        private readonly ToolTip _reviewToolTip = new ToolTip();
        private readonly bool _canDelete;

        public event EventHandler CancelClicked;
        public event EventHandler DetailsClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler LeaveReviewClicked;
        public event EventHandler DriverProfileClicked;

        public ReservationCardControl(ReservationCardViewModel model, bool canCancel, bool canDelete)
        {
            _model = model;
            _canDelete = canDelete;

            InitializeComponent();
            ApplyStyle();
            BindData();

            ConfigureActions(canCancel, canDelete);
            ConfigureTooltips();
        }

        private void ConfigureActions(bool canCancel, bool canDelete)
        {
            btnCancel.Visible = canCancel;
            btnCancel.Enabled = canCancel && !_model.IsTripCompleted;

            btnDelete.Visible = canDelete;
            btnDetails.Visible = canDelete;

            var isPassengerView = !canDelete;
            btnDriverProfile.Visible = true;
            btnLeaveReview.Visible = isPassengerView && !_model.HasReviewed;
            btnLeaveReview.Enabled = isPassengerView && !_model.HasReviewed;
            lblReviewedBadge.Visible = isPassengerView && _model.HasReviewed;

            if (!isPassengerView)
            {
                return;
            }

            btnCancel.Location = new Point(278, 194);
            btnCancel.Size = new Size(60, 28);
            btnDriverProfile.Location = new Point(88, 194);
            btnLeaveReview.Location = new Point(186, 194);

            if (lblReviewedBadge.Visible)
            {
                lblReviewedBadge.Location = new Point(186, 198);
            }
        }

        private void ConfigureTooltips()
        {
            _reviewToolTip.SetToolTip(lblReviewedBadge, "Review already submitted for this trip.");

            if (_canDelete)
            {
                return;
            }

            if (_model.HasReviewed)
            {
                _reviewToolTip.SetToolTip(btnLeaveReview, "You already reviewed this trip.");
                return;
            }

            _reviewToolTip.SetToolTip(
                btnLeaveReview,
                _model.IsTripCompleted
                    ? "Leave your review for this completed trip."
                    : "Review will be available once the trip is completed.");
        }

        private void ApplyStyle()
        {
            pnlCard.BackColor = Color.White;

            foreach (var b in new[] { btnCancel, btnDetails, btnDelete, btnLeaveReview, btnDriverProfile })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                b.Cursor = Cursors.Hand;
            }

            btnCancel.BackColor = Color.FromArgb(220, 38, 38);
            btnCancel.ForeColor = Color.White;

            btnDetails.BackColor = Color.FromArgb(79, 70, 229);
            btnDetails.ForeColor = Color.White;

            btnDelete.BackColor = Color.FromArgb(55, 65, 81);
            btnDelete.ForeColor = Color.White;

            btnLeaveReview.BackColor = Color.FromArgb(245, 158, 11);
            btnLeaveReview.ForeColor = Color.White;

            btnDriverProfile.BackColor = Color.FromArgb(17, 24, 39);
            btnDriverProfile.ForeColor = Color.White;
        }

        private void BindData()
        {
            lblRoute.Text = _model.Route;
            lblTripDate.Text = _model.TripDateText;
            lblSeats.Text = "Seats: " + _model.SeatsReserved;
            lblPrice.Text = "Price: " + _model.TotalPrice.ToString("0.00");
            lblTripWindow.Text = "Start: " + _model.TripStartText + "   |   End: " + _model.TripEndText;
            lblDriver.Text = "Driver: " + _model.DriverName;

            lblPaymentMethod.Text = "Payment: " + _model.PaymentMethod;
            lblPaymentStatus.Text = _model.PaymentStatusBadge;
            lblReservationStatus.Text = _model.ReservationStatusBadge;
            lblTripStatus.Text = _model.TripStatusBadge;

            lblPaymentStatus.BackColor = _model.PaymentStatusBackColor;
            lblPaymentStatus.ForeColor = _model.PaymentStatusForeColor;

            lblReservationStatus.BackColor = _model.ReservationStatusBackColor;
            lblReservationStatus.ForeColor = _model.ReservationStatusForeColor;

            lblTripStatus.BackColor = _model.TripStatusBackColor;
            lblTripStatus.ForeColor = _model.TripStatusForeColor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            DetailsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLeaveReview_Click(object sender, EventArgs e)
        {
            LeaveReviewClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDriverProfile_Click(object sender, EventArgs e)
        {
            DriverProfileClicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class ReservationCardViewModel
    {
        public int ReservationId { get; set; }
        public int TripId { get; set; }
        public int DriverId { get; set; }
        public string Route { get; set; } = "Departure → Destination";
        public DateTime TripDate { get; set; }
        public string TripDateText { get; set; } = "-";
        public string TripStartText { get; set; } = "-";
        public string TripEndText { get; set; } = "-";
        public int SeatsReserved { get; set; }
        public decimal TotalPrice { get; set; }
        public string DriverName { get; set; } = "-";
        public string PaymentMethod { get; set; } = "-";
        public string PaymentStatus { get; set; } = "Pending";
        public string ReservationStatus { get; set; } = "Confirmed";
        public string TripStatus { get; set; } = "Upcoming";
        public bool CanLeaveReview { get; set; }
        public bool HasReviewed { get; set; }
        public bool IsTripCompleted => string.Equals(TripStatus, "Completed", StringComparison.OrdinalIgnoreCase);

        public string PaymentStatusBadge =>
            string.Equals(PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase) ? "🟢 Paid" :
            string.Equals(PaymentStatus, "Failed", StringComparison.OrdinalIgnoreCase) ? "🔴 Failed" : "🟡 Pending";

        public string ReservationStatusBadge =>
            string.Equals(ReservationStatus, "Cancelled", StringComparison.OrdinalIgnoreCase) ? "🔴 Cancelled" :
            string.Equals(ReservationStatus, "Pending", StringComparison.OrdinalIgnoreCase) ? "🟡 Pending" : "🟢 Confirmed";

        public string TripStatusBadge =>
            string.Equals(TripStatus, "Completed", StringComparison.OrdinalIgnoreCase) ? "🔴 Completed" :
            string.Equals(TripStatus, "Ongoing", StringComparison.OrdinalIgnoreCase) ? "🟡 Ongoing" : "🟢 Upcoming";

        public Color PaymentStatusBackColor =>
            string.Equals(PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(220, 252, 231) :
            string.Equals(PaymentStatus, "Failed", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(254, 226, 226) :
            Color.FromArgb(254, 249, 195);

        public Color PaymentStatusForeColor =>
            string.Equals(PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(22, 101, 52) :
            string.Equals(PaymentStatus, "Failed", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(153, 27, 27) :
            Color.FromArgb(133, 77, 14);

        public Color ReservationStatusBackColor =>
            string.Equals(ReservationStatus, "Cancelled", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(254, 226, 226) :
            string.Equals(ReservationStatus, "Pending", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(254, 249, 195) :
            Color.FromArgb(220, 252, 231);

        public Color ReservationStatusForeColor =>
            string.Equals(ReservationStatus, "Cancelled", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(153, 27, 27) :
            string.Equals(ReservationStatus, "Pending", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(133, 77, 14) :
            Color.FromArgb(22, 101, 52);

        public Color TripStatusBackColor =>
            string.Equals(TripStatus, "Completed", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(254, 226, 226) :
            string.Equals(TripStatus, "Ongoing", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(254, 249, 195) :
            Color.FromArgb(220, 252, 231);

        public Color TripStatusForeColor =>
            string.Equals(TripStatus, "Completed", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(153, 27, 27) :
            string.Equals(TripStatus, "Ongoing", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(133, 77, 14) :
            Color.FromArgb(22, 101, 52);
    }
}
