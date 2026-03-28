using Client.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class DriverProfileForm : Form
    {
        public DriverProfileForm(DriverProfileDto profile)
        {
            InitializeComponent();
            ApplyStyle();
            Bind(profile);
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlTop.BackColor = Color.White;
            pnlStats.BackColor = Color.White;

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.FromArgb(79, 70, 229);
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            flowReviews.WrapContents = false;
            flowReviews.FlowDirection = FlowDirection.TopDown;
            flowReviews.AutoScroll = true;
        }

        private void Bind(DriverProfileDto profile)
        {
            lblName.Text = profile.name;
            lblEmail.Text = profile.email;
            lblBio.Text = string.IsNullOrWhiteSpace(profile.bio) ? "No bio yet" : profile.bio;
            lblCity.Text = string.IsNullOrWhiteSpace(profile.city) ? "-" : profile.city;

            lblRating.Text = BuildStars(profile.averageRating) + "  " + profile.averageRating.ToString("0.0") + " / 5";
            lblReviewsCount.Text = profile.totalReviews + " reviews";

            lblTrips.Text = profile.totalTripsCreated.ToString();
            lblPassengers.Text = profile.totalReservationsReceived.ToString();

            flowReviews.Controls.Clear();

            var reviews = profile.reviews ?? new System.Collections.Generic.List<ReviewResponseDto>();
            if (reviews.Count == 0)
            {
                var empty = new Label
                {
                    Text = "No reviews yet",
                    AutoSize = true,
                    ForeColor = Color.DimGray,
                    Margin = new Padding(8)
                };

                flowReviews.Controls.Add(empty);
                return;
            }

            foreach (var r in reviews.OrderByDescending(x => ParseDate(x.createdAt)))
            {
                flowReviews.Controls.Add(CreateReviewCard(r));
            }
        }

        private Control CreateReviewCard(ReviewResponseDto review)
        {
            var panel = new Panel
            {
                BackColor = Color.White,
                Width = 700,
                Height = 112,
                Margin = new Padding(0, 0, 0, 12)
            };

            var lblHeader = new Label
            {
                Text = review.passengerName + "  •  " + BuildStars(review.rating),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(14, 12)
            };

            var lblDate = new Label
            {
                Text = ParseDate(review.createdAt).ToString("dd/MM/yyyy"),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(590, 14)
            };

            var lblComment = new Label
            {
                Text = string.IsNullOrWhiteSpace(review.comment) ? "No comment" : review.comment,
                AutoSize = false,
                Width = 670,
                Height = 60,
                Location = new Point(14, 40)
            };

            panel.Controls.Add(lblHeader);
            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblComment);
            return panel;
        }

        private static string BuildStars(double rating)
        {
            var rounded = (int)Math.Round(rating, MidpointRounding.AwayFromZero);
            if (rounded < 0) rounded = 0;
            if (rounded > 5) rounded = 5;
            return new string('★', rounded) + new string('☆', 5 - rounded);
        }

        private static DateTime ParseDate(string value)
        {
            DateTime dt;
            if (DateTime.TryParse(value, out dt))
            {
                return dt;
            }

            return DateTime.MinValue;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
