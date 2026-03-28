using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class TripReservationsForm : Form
    {
        public TripReservationsForm(string tripTitle, IReadOnlyList<TripReservationItem> items)
        {
            InitializeComponent();
            lblTitle.Text = "Reservations - " + tripTitle;
            ApplyStyle();

            var rows = items ?? new List<TripReservationItem>();
            gridReservations.DataSource = rows.ToList();
            lblEmpty.Visible = rows.Count == 0;
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlCard.BackColor = Color.White;

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.FromArgb(79, 70, 229);
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }

    public class TripReservationItem
    {
        public string Passenger { get; set; }
        public int Seats { get; set; }
        public string PaymentStatus { get; set; }
    }
}
