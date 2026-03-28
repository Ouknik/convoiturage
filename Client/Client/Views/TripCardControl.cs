using Client.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class TripCardControl : UserControl
    {
        private readonly TripCardViewModel _model;

        public event EventHandler ReserveClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler EditClicked;
        public event EventHandler ViewReservationsClicked;

        public TripCardControl(TripCardViewModel model)
        {
            _model = model;
            InitializeComponent();
            ApplyStyle();
            BindData();
            ApplyRoleActions();
        }

        public TripResponseDto Trip => _model.Trip;

        private void ApplyStyle()
        {
            BackColor = Color.Transparent;
            pnlCard.BackColor = Color.White;

            foreach (var b in new[] { btnReserve, btnDelete, btnEdit, btnViewReservations })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                b.Cursor = Cursors.Hand;
            }

            btnReserve.BackColor = Color.FromArgb(79, 70, 229);
            btnReserve.ForeColor = Color.White;

            btnEdit.BackColor = Color.FromArgb(79, 70, 229);
            btnEdit.ForeColor = Color.White;

            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.ForeColor = Color.White;

            btnViewReservations.BackColor = Color.FromArgb(55, 65, 81);
            btnViewReservations.ForeColor = Color.White;
        }

        private void BindData()
        {
            lblRoute.Text = _model.Trip.departure + "  →  " + _model.Trip.destination;

            DateTime parsed;
            if (DateTime.TryParse(_model.Trip.departureTime, out parsed))
            {
                lblDate.Text = parsed.ToString("ddd, dd MMM yyyy - HH:mm");
            }
            else
            {
                lblDate.Text = _model.Trip.departureTime;
            }

            lblSeats.Text = "Seats available: " + _model.Trip.availableSeats;
            lblPrice.Text = "Price: " + _model.Trip.pricePerSeat.ToString("0.00");
            lblWindow.Text = _model.TripWindowText;
            lblDriver.Text = "Driver: " + _model.DriverName;
            lblDriverRating.Text = _model.DriverRatingText;
            lblBookedInfo.Text = "👥 " + _model.BookedSeats + " / " + _model.TotalSeats + " seats booked";

            SetStatusBadge(_model.Trip.status);
        }

        private void ApplyRoleActions()
        {
            btnReserve.Visible = _model.ShowReserve;
            btnEdit.Visible = _model.ShowEdit;
            btnDelete.Visible = _model.ShowDelete;
            btnViewReservations.Visible = _model.ShowViewReservations;

            var completed = string.Equals(_model.Trip.status, "Completed", StringComparison.OrdinalIgnoreCase);
            btnReserve.Enabled = _model.ShowReserve && _model.Trip.availableSeats > 0 && !completed;
        }

        private void SetStatusBadge(string status)
        {
            var s = (status ?? string.Empty).Trim();

            if (string.Equals(s, "Upcoming", StringComparison.OrdinalIgnoreCase))
            {
                lblStatus.Text = "🟢 Upcoming";
                lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                return;
            }

            if (string.Equals(s, "Ongoing", StringComparison.OrdinalIgnoreCase))
            {
                lblStatus.Text = "🟡 Ongoing";
                lblStatus.BackColor = Color.FromArgb(254, 249, 195);
                lblStatus.ForeColor = Color.FromArgb(133, 77, 14);
                return;
            }

            lblStatus.Text = "🔴 Completed";
            lblStatus.BackColor = Color.FromArgb(254, 226, 226);
            lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            ReserveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnViewReservations_Click(object sender, EventArgs e)
        {
            ViewReservationsClicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class TripCardViewModel
    {
        public TripResponseDto Trip { get; set; }
        public string DriverName { get; set; }
        public string DriverRatingText { get; set; } = "No rating yet";
        public string TripWindowText { get; set; }
        public int BookedSeats { get; set; }
        public int TotalSeats { get; set; }
        public bool ShowReserve { get; set; }
        public bool ShowEdit { get; set; }
        public bool ShowDelete { get; set; }
        public bool ShowViewReservations { get; set; }
    }
}
