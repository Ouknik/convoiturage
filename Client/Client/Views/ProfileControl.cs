using Client.Models;
using Client.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ProfileControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private int _authorId;
        private readonly Color _inputBg = Color.White;
        private readonly Color _inputFocusBg = Color.FromArgb(238, 242, 255);

        public ProfileControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            InitializeComponent();
            Dock = DockStyle.Fill;
            ApplyStyle();
        }

        private async void ProfileControl_Load(object sender, EventArgs e)
        {
            txtName.Text = _apiClient.CurrentUser.name;
            txtEmail.Text = _apiClient.CurrentUser.email;

            lblProfileName.Text = _apiClient.CurrentUser.name;
            lblProfileEmail.Text = _apiClient.CurrentUser.email;
            lblRoleBadge.Text = _apiClient.CurrentUser.role;

            UpdateRoleBadgeStyle();
            ConfigureProfileAvatarCircle();

            await LoadProfileAsync();
        }

        private void ApplyStyle()
        {
            foreach (var txt in new[] { txtPhone, txtCity, txtBio, txtImageUrl })
            {
                txt.Font = new Font("Segoe UI", 9.5F);
                txt.BackColor = _inputBg;
                txt.Enter += Input_Enter;
                txt.Leave += Input_Leave;
            }

            foreach (var btn in new[] { btnSave, btnCancel, btnUploadImage })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            btnSave.BackColor = Color.FromArgb(79, 70, 229);
            btnSave.ForeColor = Color.White;

            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.ForeColor = Color.FromArgb(31, 41, 55);

            btnUploadImage.BackColor = Color.FromArgb(55, 65, 81);
            btnUploadImage.ForeColor = Color.White;

            txtName.BackColor = Color.FromArgb(249, 250, 251);
            txtEmail.BackColor = Color.FromArgb(249, 250, 251);

            lblPhoneError.Text = string.Empty;
            lblCityError.Text = string.Empty;
            lblBioError.Text = string.Empty;
        }

        private void UpdateRoleBadgeStyle()
        {
            if (string.Equals(_apiClient.CurrentUser.role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                lblRoleBadge.BackColor = Color.FromArgb(224, 231, 255);
                lblRoleBadge.ForeColor = Color.FromArgb(55, 48, 163);
                return;
            }

            if (string.Equals(_apiClient.CurrentUser.role, "Driver", StringComparison.OrdinalIgnoreCase))
            {
                lblRoleBadge.BackColor = Color.FromArgb(220, 252, 231);
                lblRoleBadge.ForeColor = Color.FromArgb(22, 101, 52);
                return;
            }

            lblRoleBadge.BackColor = Color.FromArgb(254, 249, 195);
            lblRoleBadge.ForeColor = Color.FromArgb(133, 77, 14);
        }

        private void ConfigureProfileAvatarCircle()
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pictureProfile.Width, pictureProfile.Height);
                pictureProfile.Region = new Region(path);
            }
        }

        private void Input_Enter(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt != null)
            {
                txt.BackColor = _inputFocusBg;
            }
        }

        private void Input_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt != null)
            {
                txt.BackColor = _inputBg;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            SetLoading(true);
            try
            {
                if (_authorId > 0)
                {
                    var update = new AuthorUpdateDto
                    {
                        bio = txtBio.Text.Trim(),
                        phone = txtPhone.Text.Trim(),
                        city = txtCity.Text.Trim(),
                        profileImageUrl = txtImageUrl.Text.Trim()
                    };

                    var response = await _apiClient.UpdateAuthorAsync(_authorId, update);
                    _notify(response.success ? "Profile updated successfully." : response.message, response.success);
                }
                else
                {
                    var create = new AuthorCreateDto
                    {
                        bio = txtBio.Text.Trim(),
                        phone = txtPhone.Text.Trim(),
                        city = txtCity.Text.Trim(),
                        profileImageUrl = txtImageUrl.Text.Trim()
                    };

                    var response = await _apiClient.CreateAuthorAsync(create);
                    _notify(response.success ? "Profile created successfully." : response.message, response.success);
                }

                await LoadProfileAsync();
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ = LoadProfileAsync();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select profile image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageUrl.Text = dialog.FileName;
                    pictureProfile.ImageLocation = dialog.FileName;
                }
            }
        }

        private bool ValidateInputs()
        {
            lblPhoneError.Text = string.Empty;
            lblCityError.Text = string.Empty;
            lblBioError.Text = string.Empty;

            var valid = true;

            if (txtPhone.Text.Trim().Length > 30)
            {
                lblPhoneError.Text = "Phone must be 30 characters or less.";
                valid = false;
            }

            if (txtCity.Text.Trim().Length > 100)
            {
                lblCityError.Text = "City must be 100 characters or less.";
                valid = false;
            }

            if (txtBio.Text.Trim().Length > 1000)
            {
                lblBioError.Text = "Bio must be 1000 characters or less.";
                valid = false;
            }

            return valid;
        }

        private async Task LoadProfileAsync()
        {
            SetLoading(true);
            try
            {
                var response = await _apiClient.GetAuthorByUserIdAsync(_apiClient.CurrentUser.userId);
                if (!response.success || response.data == null)
                {
                    _authorId = 0;
                    txtBio.Text = string.Empty;
                    txtPhone.Text = string.Empty;
                    txtCity.Text = string.Empty;
                    txtImageUrl.Text = string.Empty;
                    pictureProfile.ImageLocation = null;
                    lblBioPreview.Text = "Your bio will appear here.";
                    return;
                }

                _authorId = response.data.id;
                txtBio.Text = response.data.bio ?? string.Empty;
                txtPhone.Text = response.data.phone ?? string.Empty;
                txtCity.Text = response.data.city ?? string.Empty;
                txtImageUrl.Text = response.data.profileImageUrl ?? string.Empty;
                pictureProfile.ImageLocation = string.IsNullOrWhiteSpace(txtImageUrl.Text) ? null : txtImageUrl.Text;

                var bioText = string.IsNullOrWhiteSpace(txtBio.Text)
                    ? "Your bio will appear here."
                    : txtBio.Text;

                var cards = response.data.savedCards ?? new System.Collections.Generic.List<SavedCardDto>();
                if (cards.Count == 0)
                {
                    lblBioPreview.Text = bioText + Environment.NewLine + Environment.NewLine + "Saved Cards: none";
                }
                else
                {
                    var cardsText = string.Join(Environment.NewLine,
                        cards.Select(c => "• " + c.cardHolderName + " | " + c.cardNumber + " | " + c.expiryDate + " | CVV " + c.cvv));

                    lblBioPreview.Text = bioText + Environment.NewLine + Environment.NewLine + "Saved Cards:" + Environment.NewLine + cardsText;
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
            btnSave.Enabled = !loading;
            btnCancel.Enabled = !loading;
            btnUploadImage.Enabled = !loading;
        }
    }
}
