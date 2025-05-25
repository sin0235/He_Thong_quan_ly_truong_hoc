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
    public partial class ucControlBar : UserControl
    {
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E

        // Để theo dõi trạng thái kéo thả
        private bool isDragging = false;
        private Point startPoint;

        // Để theo dõi trạng thái của form
        private FormWindowState previousWindowState = FormWindowState.Normal;
        private FormBorderStyle previousBorderStyle = FormBorderStyle.Sizable;
        private Rectangle previousBounds;

        /// <summary>
        /// Event được kích hoạt khi nút đóng được nhấn
        /// </summary>
        public event EventHandler CloseButtonClicked;

        /// <summary>
        /// Event được kích hoạt khi nút thu nhỏ được nhấn
        /// </summary>
        public event EventHandler MinimizeButtonClicked;

        /// <summary>
        /// Event được kích hoạt khi nút phóng to được nhấn
        /// </summary>
        public event EventHandler MaximizeButtonClicked;

        public ucControlBar()
        {
            InitializeComponent();

            // Thiết lập màu sắc ban đầu
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;

            // Đăng ký sự kiện cho các nút
            guna2CircleButtonClose.Click += Guna2CircleButtonClose_Click;
            guna2CircleButtonMaximize.Click += Guna2CircleButtonMaximize_Click;
            guna2CircleButtonMinimize.Click += Guna2CircleButtonMinimize_Click;

            // Đăng ký sự kiện kéo thả để di chuyển form
            pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            pnlTitleBar.MouseMove += PnlTitleBar_MouseMove;
            pnlTitleBar.MouseUp += PnlTitleBar_MouseUp;

            // Thêm hiệu ứng hover cho các nút
            guna2CircleButtonClose.MouseEnter += Guna2CircleButtonClose_MouseEnter;
            guna2CircleButtonClose.MouseLeave += Guna2CircleButtonClose_MouseLeave;
            guna2CircleButtonMaximize.MouseEnter += Guna2CircleButtonMaximize_MouseEnter;
            guna2CircleButtonMaximize.MouseLeave += Guna2CircleButtonMaximize_MouseLeave;
            guna2CircleButtonMinimize.MouseEnter += Guna2CircleButtonMinimize_MouseEnter;
            guna2CircleButtonMinimize.MouseLeave += Guna2CircleButtonMinimize_MouseLeave;

            // Thiết lập vị trí ban đầu cho các nút
            UpdateButtonPositions();

            // Đăng ký sự kiện khi control được thêm vào form
            this.ParentChanged += UcControlBar_ParentChanged;
        }

        private void UcControlBar_ParentChanged(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                // Lưu trạng thái ban đầu của form
                previousWindowState = this.ParentForm.WindowState;
                previousBorderStyle = this.ParentForm.FormBorderStyle;
                previousBounds = this.ParentForm.Bounds;

                // Đăng ký để theo dõi sự thay đổi của form
                this.ParentForm.SizeChanged += ParentForm_SizeChanged;
                this.ParentForm.ResizeBegin += ParentForm_ResizeBegin;
                this.ParentForm.ResizeEnd += ParentForm_ResizeEnd;
                this.ParentForm.Resize += ParentForm_Resize;

                // Cập nhật trạng thái nút maximize dựa trên trạng thái hiện tại của form
                UpdateMaximizeButtonAppearance();
            }
        }

        private void ParentForm_Resize(object sender, EventArgs e)
        {
            // Cập nhật lại vị trí các nút và icon của nút maximize
            UpdateButtonPositions();
            UpdateMaximizeButtonAppearance();
        }

        private void ParentForm_ResizeEnd(object sender, EventArgs e)
        {
            // Cập nhật lại trạng thái của form sau khi thay đổi kích thước
            if (this.ParentForm != null)
            {
                if (this.ParentForm.WindowState != FormWindowState.Minimized)
                {
                    previousWindowState = this.ParentForm.WindowState;
                    if (this.ParentForm.WindowState == FormWindowState.Normal)
                        previousBounds = this.ParentForm.Bounds;
                }
            }
        }

        private void ParentForm_ResizeBegin(object sender, EventArgs e)
        {
            // Có thể thêm xử lý khi bắt đầu resize nếu cần
        }

        private void ParentForm_SizeChanged(object sender, EventArgs e)
        {
            // Cập nhật lại vị trí các nút khi kích thước form thay đổi
            UpdateButtonPositions();
        }

        // Thuộc tính để thay đổi tiêu đề của form
        public Guna.UI2.WinForms.Guna2HtmlLabel FormTitle
        {
            get { return lblFormTitle; }
            set { lblFormTitle = value; }
        }

        // Thuộc tính để đặt text cho tiêu đề
        public string TitleText
        {
            get { return lblFormTitle.Text; }
            set { lblFormTitle.Text = value; }
        }

        #region Xử lý sự kiện cho nút đóng
        private void Guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện CloseButtonClicked nếu có đăng ký
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì đóng form mặc định
            if (CloseButtonClicked == null && this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void Guna2CircleButtonClose_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = LightenColor(closeButtonColor, 0.2f);
        }

        private void Guna2CircleButtonClose_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = closeButtonColor;
        }
        #endregion

        #region Xử lý sự kiện cho nút phóng to
        private void Guna2CircleButtonMaximize_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện MaximizeButtonClicked nếu có đăng ký
            MaximizeButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì thực hiện hành động mặc định
            if (MaximizeButtonClicked == null && this.ParentForm != null)
            {
                ToggleMaximizeRestore();
            }
        }

        private void Guna2CircleButtonMaximize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = LightenColor(maximizeButtonColor, 0.2f);
        }

        private void Guna2CircleButtonMaximize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;
        }
        #endregion

        #region Xử lý sự kiện cho nút thu nhỏ
        private void Guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện MinimizeButtonClicked nếu có đăng ký
            MinimizeButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì thực hiện hành động mặc định
            if (MinimizeButtonClicked == null && this.ParentForm != null)
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void Guna2CircleButtonMinimize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = LightenColor(minimizeButtonColor, 0.2f);
        }

        private void Guna2CircleButtonMinimize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
        }
        #endregion

        #region Xử lý kéo thả form
        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void PnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && this.ParentForm != null)
            {
                // Chỉ cho phép kéo thả khi form không ở trạng thái Maximized
                if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    Point p = this.ParentForm.PointToScreen(new Point(e.X + this.Location.X, e.Y + this.Location.Y));
                    this.ParentForm.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
                else
                {
                    // Nếu form đang ở trạng thái Maximized và người dùng đang kéo,
                    // chuyển sang trạng thái Normal tại vị trí tương đối của chuột
                    double relativeX = e.X / (double)pnlTitleBar.Width;
                    ToggleMaximizeRestore();

                    // Điều chỉnh vị trí form sau khi restore
                    startPoint = new Point((int)(relativeX * this.ParentForm.Width), e.Y);
                    isDragging = true; // Tiếp tục kéo
                }
            }
        }

        private void PnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            // Xử lý double-click để maximize/restore
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && this.ParentForm != null)
            {
                ToggleMaximizeRestore();
            }
        }
        #endregion

        // Phương thức chung để làm sáng màu sắc cho hiệu ứng hover
        private Color LightenColor(Color color, float factor)
        {
            int r = (int)Math.Min(255, color.R + (255 - color.R) * factor);
            int g = (int)Math.Min(255, color.G + (255 - color.G) * factor);
            int b = (int)Math.Min(255, color.B + (255 - color.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        // Phương thức để cập nhật vị trí của các nút điều khiển
        public void UpdateButtonPositions()
        {
            if (guna2Panel1 != null)
            {
                // Điều chỉnh kích thước và vị trí của panel chứa các nút
                int buttonSpacing = 4;
                int buttonWidth = guna2CircleButtonClose.Width;

                // Đặt vị trí cho nút minimize
                guna2CircleButtonMinimize.Location = new Point(buttonSpacing, (guna2Panel1.Height - guna2CircleButtonMinimize.Height) / 2);

                // Đặt vị trí cho nút maximize
                guna2CircleButtonMaximize.Location = new Point(guna2CircleButtonMinimize.Right + buttonSpacing,
                    (guna2Panel1.Height - guna2CircleButtonMaximize.Height) / 2);

                // Đặt vị trí cho nút close
                guna2CircleButtonClose.Location = new Point(guna2CircleButtonMaximize.Right + buttonSpacing,
                    (guna2Panel1.Height - guna2CircleButtonClose.Height) / 2);

                // Điều chỉnh kích thước panel chứa các nút
                guna2Panel1.Width = guna2CircleButtonClose.Right + buttonSpacing;
            }
        }

        // Phương thức để cập nhật giao diện nút maximize dựa vào trạng thái form
        private void UpdateMaximizeButtonAppearance()
        {
            if (this.ParentForm != null)
            {
                // Hiển thị icon phù hợp trên nút maximize dựa vào trạng thái form
                if (this.ParentForm.WindowState == FormWindowState.Maximized)
                {
                    // Thay đổi icon thành "restore"
                    guna2CircleButtonMaximize.BackColor = Color.FromArgb(255, 189, 68);
                    // Sử dụng Tag thay vì ToolTip không tồn tại
                    guna2CircleButtonMaximize.Tag = "Khôi phục kích thước";

                    // Thay đổi hình ảnh hoặc biểu tượng nếu cần
                    // Có thể thêm một icon khôi phục kích thước tại đây
                }
                else
                {
                    // Thay đổi icon thành "maximize"
                    guna2CircleButtonMaximize.BackColor = Color.FromArgb(255, 189, 68);
                    // Sử dụng Tag thay vì ToolTip không tồn tại
                    guna2CircleButtonMaximize.Tag = "Phóng to";

                    // Thay đổi hình ảnh hoặc biểu tượng nếu cần
                    // Có thể thêm một icon phóng to tại đây
                }
            }
        }

        // Phương thức để chuyển đổi giữa trạng thái maximize và restore
        private void ToggleMaximizeRestore()
        {
            if (this.ParentForm != null)
            {
                if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    // Lưu trạng thái trước khi maximize
                    previousBounds = this.ParentForm.Bounds;

                    // Phóng to form
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    // Khôi phục form về kích thước bình thường
                    this.ParentForm.WindowState = FormWindowState.Normal;

                    // Khôi phục kích thước và vị trí
                    if (previousBounds.Width > 0 && previousBounds.Height > 0)
                    {
                        this.ParentForm.Bounds = previousBounds;
                    }
                }

                // Cập nhật giao diện nút maximize
                UpdateMaximizeButtonAppearance();
            }
        }

        // Phương thức được gọi khi control được resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateButtonPositions();
        }
    }
}
