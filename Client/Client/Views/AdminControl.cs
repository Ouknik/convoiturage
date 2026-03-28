using System.Drawing;
using System.Windows.Forms;

namespace Client.Views
{
    public partial class AdminControl : UserControl
    {
        public AdminControl(string sectionTitle, string subtitle)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            lblTitle.Text = sectionTitle;
            lblSubtitle.Text = subtitle;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(249, 250, 251);
            pnlCard.BackColor = Color.White;
            pnlActivity.BackColor = Color.White;
        }
    }
}
