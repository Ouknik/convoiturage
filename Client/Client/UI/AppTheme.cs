using System.Drawing;

namespace Client.UI
{
    public static class AppTheme
    {
        public static readonly Color Primary = Color.FromArgb(88, 86, 214);
        public static readonly Color Secondary = Color.FromArgb(245, 247, 250);
        public static readonly Color Sidebar = Color.FromArgb(32, 33, 54);
        public static readonly Color TextPrimary = Color.FromArgb(33, 37, 41);
        public static readonly Color TextLight = Color.White;
        public static readonly Font DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 10F, FontStyle.Regular);
    }
}
