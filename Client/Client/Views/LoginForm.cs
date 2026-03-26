using Client.Services;
using Client.UI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            cmbRegisterRole.SelectedIndex = 0;
            Font = AppTheme.DefaultFont;
            BackColor = AppTheme.Secondary;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoginEmail.Text) || string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                lblStatus.Text = "Email and password are required.";
                return;
            }

            await ExecuteAuthActionAsync(async api =>
            {
                var result = await api.LoginAsync(txtLoginEmail.Text.Trim(), txtLoginPassword.Text);
                if (!result.success || result.data == null)
                {
                    lblStatus.Text = result.message ?? "Login failed";
                    return;
                }

                Hide();
                using (var main = new MainForm(api))
                {
                    main.ShowDialog();
                }
                Close();
            });
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegisterName.Text)
                || string.IsNullOrWhiteSpace(txtRegisterEmail.Text)
                || string.IsNullOrWhiteSpace(txtRegisterPassword.Text))
            {
                lblStatus.Text = "All register fields are required.";
                return;
            }

            await ExecuteAuthActionAsync(async api =>
            {
                var roleValue = cmbRegisterRole.SelectedItem.ToString() == "Driver" ? 1 : 2;
                var result = await api.RegisterAsync(txtRegisterName.Text.Trim(), txtRegisterEmail.Text.Trim(), txtRegisterPassword.Text, roleValue);

                if (!result.success)
                {
                    lblStatus.Text = result.message ?? "Register failed";
                    return;
                }

                lblStatus.Text = "Register success. You can login now.";
                tabAuth.SelectedTab = tabLogin;
            });
        }

        private async Task ExecuteAuthActionAsync(Func<ApiClient, Task> action)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            progressBar.Visible = true;
            lblStatus.Text = "";

            try
            {
                var api = new ApiClient(txtBaseUrl.Text.Trim());
                await action(api);
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
                progressBar.Visible = false;
            }
        }
    }
}
