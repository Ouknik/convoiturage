using Client.Models;
using Client.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class ProfileControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly Action<string, bool> _notify;
        private int _authorId;

        public ProfileControl(ApiClient apiClient, Action<string, bool> notify)
        {
            _apiClient = apiClient;
            _notify = notify;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private async void ProfileControl_Load(object sender, EventArgs e)
        {
            lblNameValue.Text = _apiClient.CurrentUser.name;
            lblEmailValue.Text = _apiClient.CurrentUser.email;
            await LoadProfileAsync();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length > 30)
            {
                _notify("Phone length should be <= 30.", false);
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
                    _notify(response.success ? "Profile updated." : response.message, response.success);
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
                    _notify(response.success ? "Profile created." : response.message, response.success);
                }

                await LoadProfileAsync();
            }
            finally
            {
                SetLoading(false);
            }
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
                    return;
                }

                _authorId = response.data.id;
                txtBio.Text = response.data.bio ?? string.Empty;
                txtPhone.Text = response.data.phone ?? string.Empty;
                txtCity.Text = response.data.city ?? string.Empty;
                txtImageUrl.Text = response.data.profileImageUrl ?? string.Empty;
                pictureProfile.ImageLocation = string.IsNullOrWhiteSpace(txtImageUrl.Text) ? null : txtImageUrl.Text;
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
        }
    }
}
