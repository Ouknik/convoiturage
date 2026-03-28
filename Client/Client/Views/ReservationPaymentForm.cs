using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ReservationPaymentForm : Form
    {
        public string SelectedPaymentMethod { get; private set; } = "Cash";
        public string CardHolderName => txtCardHolder.Text.Trim();
        public string CardNumber => mtbCardNumber.Text.Replace(" ", string.Empty).Trim();
        public string ExpiryDate => mtbExpiry.Text.Trim();
        public string Cvv => mtbCvv.Text.Trim();

        public ReservationPaymentForm(string routeText, int seats)
        {
            InitializeComponent();
            ApplyStyle();

            lblRouteValue.Text = routeText;
            lblSeatsValue.Text = seats.ToString();
            rbCash.Checked = true;
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlCard.BackColor = Color.White;

            foreach (var btn in new[] { btnConfirm, btnCancel })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            btnConfirm.BackColor = Color.FromArgb(79, 70, 229);
            btnConfirm.ForeColor = Color.White;

            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.ForeColor = Color.FromArgb(31, 41, 55);

            pnlCardPayment.BackColor = Color.FromArgb(243, 244, 246);
            lblCashHint.ForeColor = Color.FromArgb(75, 85, 99);
            lblError.Text = string.Empty;
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            TogglePaymentPanels();
        }

        private void rbCard_CheckedChanged(object sender, EventArgs e)
        {
            TogglePaymentPanels();
        }

        private void TogglePaymentPanels()
        {
            var isCard = rbCard.Checked;
            pnlCardPayment.Visible = isCard;
            lblCashHint.Visible = !isCard;
            SelectedPaymentMethod = isCard ? "Card" : "Cash";
            lblError.Text = string.Empty;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            if (rbCard.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCardHolder.Text))
                {
                    lblError.Text = "Card holder name is required.";
                    return;
                }

                if (!mtbCardNumber.MaskCompleted)
                {
                    lblError.Text = "Card number must be 16 digits.";
                    return;
                }

                if (!mtbExpiry.MaskCompleted || !IsValidExpiry(mtbExpiry.Text))
                {
                    lblError.Text = "Expiry date is invalid (MM/YY).";
                    return;
                }

                if (!mtbCvv.MaskCompleted)
                {
                    lblError.Text = "CVV must be 3 digits.";
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static bool IsValidExpiry(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 5 || value[2] != '/')
            {
                return false;
            }

            int month;
            int year;
            if (!int.TryParse(value.Substring(0, 2), out month) || !int.TryParse(value.Substring(3, 2), out year))
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            var now = DateTime.Now;
            var fullYear = 2000 + year;
            var lastDay = DateTime.DaysInMonth(fullYear, month);
            var expiry = new DateTime(fullYear, month, lastDay, 23, 59, 59);
            return expiry >= now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
