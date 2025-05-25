using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTKBItem : UserControl
    {
        // Properties to store data
        private string _monHoc = "Môn học";
        private string _giaoVien = "Giáo viên";
        private string _thoiGian = "Thời gian";
        private string _noiDung = "Nội dung";
        private int _tiet = 1;
        private Color _color = Color.FromArgb(94, 148, 255); // Default blue color

        // Dictionary to store subject icons based on subject type
        private static Dictionary<string, Image> subjectIcons = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        // Improved color scheme with better contrast and visual distinction
        private static readonly Color[] subjectColors = new Color[]
        {
                    Color.FromArgb(25, 118, 210),   // Xanh dương đậm
                    Color.FromArgb(136, 14, 79),    // Đỏ mận đậm
                    Color.FromArgb(0, 121, 107),    // Xanh lá đậm
                    Color.FromArgb(255, 111, 0),    // Cam đậm
                    Color.FromArgb(74, 20, 140),    // Tím đậm
                    Color.FromArgb(0, 131, 143),    // Xanh ngọc đậm
                    Color.FromArgb(230, 74, 25),    // Đỏ cam
                    Color.FromArgb(46, 125, 50)     // Xanh lá
        };

        // Text colors for better readability against the background
        private static readonly Color darkTextColor = Color.FromArgb(40, 40, 40);
        private static readonly Color lightTextColor = Color.FromArgb(250, 250, 250);

        public string MonHoc
        {
            get { return _monHoc; }
            set
            {
                _monHoc = value;
                lblMonHoc.Text = value;
            }
        }

        public string GiaoVien
        {
            get { return _giaoVien; }
            set { _giaoVien = value; lblGiaoVien.Text = value; }
        }

        public string ThoiGian
        {
            get { return _thoiGian; }
            set { _thoiGian = value; lblThoigian.Text = value; }
        }

        public string NoiDung
        {
            get { return _noiDung; }
            set { _noiDung = value; lblNoidung.Text = value; }
        }

        public int Tiet
        {
            get { return _tiet; }
            set
            {
                _tiet = value;
                lblTiet.Text = $"#{value}";

                // Update color based on period number
                SetColorByTiet(value);
            }
        }

        public Color TietColor
        {
            get { return _color; }
            set
            {
                _color = value;
                pnlColor.FillColor = value;

                // Adjust the main panel background color to a lighter shade of the subject color
                Color lightBg = LightenColor(value, 0.9f);
                pnlMain.FillColor = lightBg;

                // Set appropriate text colors based on background brightness
                bool isDarkColor = IsDarkColor(value);
                lblTiet.ForeColor = isDarkColor ? lightTextColor : darkTextColor;
            }
        }

        public ucTKBItem()
        {
            InitializeComponent();

            // Initialize subject icons on first creation
            if (subjectIcons.Count == 0)
            {
                InitializeSubjectIcons();
            }

            // Add hover effects
            this.pnlMain.MouseEnter += PnlMain_MouseEnter;
            this.pnlMain.MouseLeave += PnlMain_MouseLeave;

            // Improve shadow effect
            pnlMain.ShadowDecoration.Depth = 5;
            pnlMain.ShadowDecoration.Shadow = new Padding(1, 1, 3, 3);
        }

        /// <summary>
        /// Constructor with parameters to initialize the control
        /// </summary>
        public ucTKBItem(string monHoc, string giaoVien, string phongHoc, string thoiGian, string noiDung, int tiet)
        {
            InitializeComponent();

            // Initialize subject icons on first creation
            if (subjectIcons.Count == 0)
            {
                InitializeSubjectIcons();
            }

            MonHoc = monHoc;
            GiaoVien = giaoVien;
            ThoiGian = thoiGian;
            NoiDung = noiDung;
            Tiet = tiet;

            // Add hover effects
            this.pnlMain.MouseEnter += PnlMain_MouseEnter;
            this.pnlMain.MouseLeave += PnlMain_MouseLeave;

            // Improve shadow effect
            pnlMain.ShadowDecoration.Depth = 5;
            pnlMain.ShadowDecoration.Shadow = new Padding(1, 1, 3, 3);
        }

        private void PnlMain_MouseEnter(object sender, EventArgs e)
        {
            // Enhance shadow on hover
            pnlMain.ShadowDecoration.Depth = 10;
            pnlMain.ShadowDecoration.Shadow = new Padding(2, 2, 5, 5);

            // Slightly enlarge the panel
            pnlMain.Padding = new Padding(2);

            // Make text slightly bolder on hover
            lblMonHoc.Font = new Font(lblMonHoc.Font, FontStyle.Bold);
        }

        private void PnlMain_MouseLeave(object sender, EventArgs e)
        {
            // Restore normal shadow
            pnlMain.ShadowDecoration.Depth = 5;
            pnlMain.ShadowDecoration.Shadow = new Padding(1, 1, 3, 3);

            // Restore original size
            pnlMain.Padding = new Padding(0);
        }

        /// <summary>
        /// Initialize dictionary of subject icons based on subject keywords
        /// </summary>
        private void InitializeSubjectIcons()
        {
            // Map common subject types to their respective icons
            // You may need to add these images to your resources
            try
            {
                subjectIcons["toán"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["văn"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["anh"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["lý"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["hóa"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["sinh"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["sử"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["địa"] = QuanLyTruongHoc.Properties.Resources.book;
                subjectIcons["tin"] = QuanLyTruongHoc.Properties.Resources.book;
                // Add more subject mappings as needed
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading subject icons: " + ex.Message);
            }
        }

       
        /// <summary>
        /// Set color based on period number
        /// </summary>
        private void SetColorByTiet(int tiet)
        {
            // Use the improved color scheme
            int colorIndex = (tiet - 1) % subjectColors.Length;
            TietColor = subjectColors[colorIndex];
        }

        /// <summary>
        /// Create a lighter version of a color (for backgrounds)
        /// </summary>
        private Color LightenColor(Color color, float brightnessFactor)
        {
            // Create a lighter version of the color for panel backgrounds
            float h, s, b;
            ColorToHSB(color, out h, out s, out b);

            // Reduce saturation and increase brightness
            s *= 0.3f;
            b = Math.Min(1f, b + brightnessFactor);

            return ColorFromHSB(h, s, b);
        }

        /// <summary>
        /// Check if a color is dark (for determining text color)
        /// </summary>
        private bool IsDarkColor(Color color)
        {
            // Calculate relative luminance using the formula
            // Luminance = 0.299*R + 0.587*G + 0.114*B
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminance < 0.5;
        }

        #region Color Utility Methods
        // Convert RGB to HSB
        private static void ColorToHSB(Color color, out float hue, out float saturation, out float brightness)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            brightness = (float)max / 255.0f;
            saturation = (max == 0) ? 0 : 1.0f - (float)min / max;

            if (max == min)
            {
                hue = 0; // achromatic
            }
            else
            {
                float delta = max - min;
                if (max == color.R)
                {
                    hue = (color.G - color.B) / delta;
                }
                else if (max == color.G)
                {
                    hue = 2 + (color.B - color.R) / delta;
                }
                else
                {
                    hue = 4 + (color.R - color.G) / delta;
                }
                hue *= 60;
                if (hue < 0)
                    hue += 360;
                hue /= 360.0f;
            }
        }

        // Convert HSB to RGB
        private static Color ColorFromHSB(float hue, float saturation, float brightness)
        {
            int hi = Convert.ToInt32(Math.Floor(hue * 6)) % 6;
            float f = hue * 6 - (float)Math.Floor(hue * 6);

            brightness = brightness * 255;
            int v = Convert.ToInt32(brightness);
            int p = Convert.ToInt32(brightness * (1 - saturation));
            int q = Convert.ToInt32(brightness * (1 - f * saturation));
            int t = Convert.ToInt32(brightness * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0:
                    return Color.FromArgb(255, v, t, p);
                case 1:
                    return Color.FromArgb(255, q, v, p);
                case 2:
                    return Color.FromArgb(255, p, v, t);
                case 3:
                    return Color.FromArgb(255, p, q, v);
                case 4:
                    return Color.FromArgb(255, t, p, v);
                default:
                    return Color.FromArgb(255, v, p, q);
            }
        }
        #endregion

        private void lblGiaoVien_Click(object sender, EventArgs e)
        {

        }

        private void lblThoigian_Click(object sender, EventArgs e)
        {

        }
    }
}
