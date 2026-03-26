using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ReservationsControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;

        public ReservationsControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private async void ReservationsControl_Load(object sender, EventArgs e)
        {
            await LoadReservationsAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadReservationsAsync();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            var selected = gridReservations.CurrentRow?.DataBoundItem as ReservationRowModel;
            if (selected == null)
            {
                _notify("Select reservation first.", false);
                return;
            }

            SetLoading(true);
            try
            {
                var response = await _apiClient.DeleteReservationAsync(selected.id);
                _notify(response.success ? "Reservation canceled." : response.message, response.success);
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

        private async Task LoadReservationsAsync()
        {
            SetLoading(true);
            try
            {
                var response = await _apiClient.GetReservationsAsync();
                var rows = response.success && response.data != null
                    ? response.data.Select(x => new ReservationRowModel
                    {
                        id = x.id,
                        tripId = x.tripId,
                        userId = x.userId,
                        seatsReserved = x.seatsReserved,
                        status = "Active"
                    }).ToList()
                    : new List<ReservationRowModel>();

                gridReservations.DataSource = rows;
                lblEmpty.Visible = rows.Count == 0;
                lblCount.Text = "Reservations: " + rows.Count;

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
            btnRefresh.Enabled = !loading;
            btnCancel.Enabled = !loading;
        }

        private class ReservationRowModel : ReservationResponseDto
        {
            public string status { get; set; }
        }
    }
}
