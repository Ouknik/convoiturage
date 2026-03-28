using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class TripEditorForm : Form
    {
        public string DepartureText => txtDeparture.Text.Trim();
        public string DestinationText => txtDestination.Text.Trim();
        public DateTime StartDate => dtpDate.Value.Date;
        public DateTime EndDate => dtpEndDate.Value.Date;
        public TimeSpan StartTime => dtpTime.Value.TimeOfDay;
        public int Seats => (int)numSeats.Value;
        public decimal PricePerSeat => numPrice.Value;
        public int NumberOfDays => Math.Max(1, (EndDate.Date - StartDate.Date).Days + 1);

        public TripEditorForm(string title, string submitText, TripEditorModel model = null)
        {
            InitializeComponent();
            Text = title;
            lblTitle.Text = title;
            btnSubmit.Text = submitText;
            ApplyStyle();

            if (model != null)
            {
                txtDeparture.Text = model.Departure;
                txtDestination.Text = model.Destination;
                dtpDate.Value = model.StartDate.Date;
                dtpEndDate.Value = model.EndDate.Date;
                dtpTime.Value = DateTime.Today.Add(model.StartTime);
                numSeats.Value = Math.Max(numSeats.Minimum, Math.Min(numSeats.Maximum, model.Seats));
                numPrice.Value = Math.Max(numPrice.Minimum, Math.Min(numPrice.Maximum, model.PricePerSeat));
            }

            dtpDate.ValueChanged += (s, e) => RefreshDays();
            dtpEndDate.ValueChanged += (s, e) => RefreshDays();
            RefreshDays();
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlCard.BackColor = Color.White;

            foreach (var b in new[] { btnSubmit, btnCancel })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.Cursor = Cursors.Hand;
            }

            btnSubmit.BackColor = Color.FromArgb(79, 70, 229);
            btnSubmit.ForeColor = Color.White;

            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.ForeColor = Color.FromArgb(31, 41, 55);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtDeparture.Text) || string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                lblError.Text = "Departure and destination are required.";
                return;
            }

            if (StartDate.Date.Add(StartTime) <= DateTime.Now)
            {
                lblError.Text = "Departure date/time must be in the future.";
                return;
            }

            if (EndDate.Date < StartDate.Date)
            {
                lblError.Text = "End date must be after start date.";
                return;
            }

            if (Seats <= 0)
            {
                lblError.Text = "Seats must be greater than 0.";
                return;
            }

            if (PricePerSeat <= 0)
            {
                lblError.Text = "Price must be greater than 0.";
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RefreshDays()
        {
            txtNumberOfDays.Text = NumberOfDays.ToString();
        }
    }

    public class TripEditorModel
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal PricePerSeat { get; set; }
        public decimal Seats { get; set; }
    }
}
