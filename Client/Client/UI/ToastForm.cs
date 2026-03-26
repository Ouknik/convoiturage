using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.UI
{
    public partial class ToastForm : Form
    {
        private readonly Timer _timer;

        public ToastForm(string message, bool success)
        {
            InitializeComponent();

            BackColor = success ? Color.FromArgb(46, 125, 50) : Color.FromArgb(198, 40, 40);
            lblMessage.Text = message;

            _timer = new Timer { Interval = 2400 };
            _timer.Tick += (s, e) =>
            {
                _timer.Stop();
                Close();
            };
        }

        public void ShowToast(Form parent)
        {
            StartPosition = FormStartPosition.Manual;
            var x = parent.Left + parent.Width - Width - 24;
            var y = parent.Top + parent.Height - Height - 48;
            Location = new Point(x, y);
            Show(parent);
            _timer.Start();
        }
    }
}
