using Client.Services;
using Client.UI;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class LoginForm : Form
    {
        private readonly Color _primary = Color.FromArgb(79, 70, 229);
        private readonly Color _primaryHover = Color.FromArgb(67, 56, 202);
        private readonly Color _inputBg = Color.White;
        private readonly Color _inputFocusBg = Color.FromArgb(238, 242, 255);

        public LoginForm()
        {
            InitializeComponent();
            Font = new Font("Segoe UI", 9F);
            BackColor = AppTheme.Secondary;

            cmbRegisterRole.SelectedIndex = 0;

            ApplyStyling();
            SetPlaceholders();
            BindInputFocusEffects();
            BindButtonHoverEffects(btnLogin, btnRegister, btnTabLogin, btnTabRegister);

            ShowLoginView();
            CenterCard();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void CenterCard()
        {
            pnlCard.Left = Math.Max((ClientSize.Width - pnlCard.Width) / 2, 12);
            pnlCard.Top = Math.Max((ClientSize.Height - pnlCard.Height) / 2, 12);
        }

        private void ApplyStyling()
        {
            lblAppName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            pnlCard.Padding = new Padding(0);

            StylePrimaryButton(btnLogin);
            StylePrimaryButton(btnRegister);

            StyleTabButton(btnTabLogin);
            StyleTabButton(btnTabRegister);

            StyleInput(txtLoginEmail);
            StyleInput(txtLoginPassword);
            StyleInput(txtRegisterName);
            StyleInput(txtRegisterEmail);
            StyleInput(txtRegisterPassword);
            StyleInput(txtRegisterConfirmPassword);
            StyleCombo(cmbRegisterRole);

            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 24;
        }

        private void StylePrimaryButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = _primary;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void StyleTabButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void StyleInput(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = _inputBg;
        }

        private void StyleCombo(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = _inputBg;
        }

        private void SetPlaceholders()
        {
            SetCueBanner(txtLoginEmail, "Email");
            SetCueBanner(txtLoginPassword, "Password");
            SetCueBanner(txtRegisterName, "Full name");
            SetCueBanner(txtRegisterEmail, "Email");
            SetCueBanner(txtRegisterPassword, "Password");
            SetCueBanner(txtRegisterConfirmPassword, "Confirm password");
            SetCueBanner(txtBaseUrl, "API URL");
        }

        private void BindInputFocusEffects()
        {
            BindFocus(txtLoginEmail);
            BindFocus(txtLoginPassword);
            BindFocus(txtRegisterName);
            BindFocus(txtRegisterEmail);
            BindFocus(txtRegisterPassword);
            BindFocus(txtRegisterConfirmPassword);
        }

        private void BindFocus(TextBox textBox)
        {
            textBox.Enter += (s, e) => textBox.BackColor = _inputFocusBg;
            textBox.Leave += (s, e) => textBox.BackColor = _inputBg;
        }

        private void BindButtonHoverEffects(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.MouseEnter += (s, e) =>
                {
                    if (button == btnLogin || button == btnRegister)
                    {
                        button.BackColor = _primaryHover;
                    }
                };

                button.MouseLeave += (s, e) =>
                {
                    if (button == btnLogin || button == btnRegister)
                    {
                        button.BackColor = _primary;
                    }
                };
            }
        }

        private void ShowLoginView()
        {
            pnlLoginForm.Visible = true;
            pnlRegisterForm.Visible = false;

            btnTabLogin.BackColor = _primary;
            btnTabLogin.ForeColor = Color.White;
            btnTabRegister.BackColor = Color.FromArgb(243, 244, 246);
            btnTabRegister.ForeColor = Color.FromArgb(55, 65, 81);

            lblSubtitle.Text = "Welcome back";
            lblLoginError.Text = string.Empty;
            lblRegisterError.Text = string.Empty;
        }

        private void ShowRegisterView()
        {
            pnlLoginForm.Visible = false;
            pnlRegisterForm.Visible = true;

            btnTabRegister.BackColor = _primary;
            btnTabRegister.ForeColor = Color.White;
            btnTabLogin.BackColor = Color.FromArgb(243, 244, 246);
            btnTabLogin.ForeColor = Color.FromArgb(55, 65, 81);

            lblSubtitle.Text = "Create your account";
            lblLoginError.Text = string.Empty;
            lblRegisterError.Text = string.Empty;
        }

        private void btnTabLogin_Click(object sender, EventArgs e)
        {
            ShowLoginView();
        }

        private void btnTabRegister_Click(object sender, EventArgs e)
        {
            ShowRegisterView();
        }

        private void linkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRegisterView();
        }

        private void linkToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLoginView();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            lblLoginError.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtLoginEmail.Text) || string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                lblLoginError.Text = "Email and password are required.";
                return;
            }

            await ExecuteAuthActionAsync(async api =>
            {
                var result = await api.LoginAsync(txtLoginEmail.Text.Trim(), txtLoginPassword.Text);
                if (!result.success || result.data == null)
                {
                    lblLoginError.Text = result.message ?? "Login failed.";
                    return;
                }

                Hide();
                using (var main = new MainForm(api))
                {
                    main.ShowDialog();

                    if (main.LogoutRequested)
                    {
                        txtLoginPassword.Clear();
                        lblStatus.Text = "Logged out successfully.";
                        ShowLoginView();
                        Show();
                        Activate();
                        return;
                    }
                }

                Close();
            });
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            lblRegisterError.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtRegisterName.Text)
                || string.IsNullOrWhiteSpace(txtRegisterEmail.Text)
                || string.IsNullOrWhiteSpace(txtRegisterPassword.Text)
                || string.IsNullOrWhiteSpace(txtRegisterConfirmPassword.Text))
            {
                lblRegisterError.Text = "All fields are required.";
                return;
            }

            if (!string.Equals(txtRegisterPassword.Text, txtRegisterConfirmPassword.Text, StringComparison.Ordinal))
            {
                lblRegisterError.Text = "Passwords do not match.";
                return;
            }

            await ExecuteAuthActionAsync(async api =>
            {
                var roleValue = cmbRegisterRole.SelectedItem.ToString() == "Driver" ? 1 : 2;
                var result = await api.RegisterAsync(
                    txtRegisterName.Text.Trim(),
                    txtRegisterEmail.Text.Trim(),
                    txtRegisterPassword.Text,
                    roleValue);

                if (!result.success)
                {
                    lblRegisterError.Text = result.message ?? "Register failed.";
                    return;
                }

                lblStatus.Text = "Account created. You can login now.";
                txtRegisterPassword.Clear();
                txtRegisterConfirmPassword.Clear();
                ShowLoginView();
            });
        }

        private async Task ExecuteAuthActionAsync(Func<ApiClient, Task> action)
        {
            SetLoading(true);

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
                SetLoading(false);
            }
        }

        private void SetLoading(bool loading)
        {
            btnLogin.Enabled = !loading;
            btnRegister.Enabled = !loading;
            btnTabLogin.Enabled = !loading;
            btnTabRegister.Enabled = !loading;
            progressBar.Visible = loading;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private static void SetCueBanner(TextBox textBox, string cue)
        {
            const int emSetCueBanner = 0x1501;
            SendMessage(textBox.Handle, emSetCueBanner, (IntPtr)1, cue);
        }
    }
}
