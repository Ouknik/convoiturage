using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ReviewPopupForm : Form
    {
        private int _selectedRating = 5;

        public int SelectedRating => _selectedRating;
        public string ReviewComment => txtComment.Text.Trim();

        public ReviewPopupForm(string routeText)
        {
            InitializeComponent();
            lblRoute.Text = routeText;
            ApplyStyle();
            SelectRating(5);
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlCard.BackColor = Color.White;

            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.BackColor = Color.FromArgb(79, 70, 229);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.ForeColor = Color.FromArgb(31, 41, 55);
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void SelectRating(int rating)
        {
            _selectedRating = rating;

            var labels = new[] { lblStar1, lblStar2, lblStar3, lblStar4, lblStar5 };
            for (var i = 0; i < labels.Length; i++)
            {
                labels[i].ForeColor = i < rating ? Color.Goldenrod : Color.Silver;
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            if (sender is Label star && int.TryParse(star.Tag?.ToString(), out var rating))
            {
                SelectRating(rating);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_selectedRating < 1 || _selectedRating > 5)
            {
                lblError.Text = "Select rating from 1 to 5.";
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
    }
}
