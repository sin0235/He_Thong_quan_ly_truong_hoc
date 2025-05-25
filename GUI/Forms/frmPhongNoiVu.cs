using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.GUI.Controls;
using QuanLyTruongHoc.GUI.Controls.ucBanGiamHieu;
using QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu;
namespace QuanLyTruongHoc
{
    public partial class frmPhongNoiVu : Form
    {
        // Lưu trữ màu gốc của các nút
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E
        private Color highlightColor = Color.FromArgb(214, 228, 255);
        private int id;
        public frmPhongNoiVu(int maNguoiDung)
        {
            InitializeComponent();
            id = maNguoiDung;

            // Đảm bảo các nút nằm trong Guna2Panel
            guna2CircleButtonClose.Parent = pnlTitleBar;
            guna2CircleButtonMinimize.Parent = pnlTitleBar;
            guna2CircleButtonMaximize.Parent = pnlTitleBar;

            // Gán màu ban đầu cho các nút
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;

            // Đảm bảo các nút hiển thị
            guna2CircleButtonClose.Visible = true;
            guna2CircleButtonMinimize.Visible = true;
            guna2CircleButtonMaximize.Visible = true;

            // Cập nhật vị trí nút ngay khi Form khởi tạo
            UpdateButtonPositions();

            // Đăng ký sự kiện Resize
            this.Resize += new EventHandler(Form1_Resize);


            // Hiển thị giao diện quản lý học sinh mặc định
            pnlContent.Controls.Clear();
            ucQuanLyHocSinh uc = new ucQuanLyHocSinh();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            btnQuanLyHocSinh.FillColor = Color.FromArgb(214, 228, 255);
            btnQuanLyThoiKhoaBieu.FillColor = Color.Transparent;
            lblPageTitle.Text = "Quản lý học sinh";
        }

        // Hàm cập nhật vị trí nút
        private void UpdateButtonPositions()
        {
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 5);
            guna2CircleButtonMaximize.Location = new Point(pnlTitleBar.Width - 60, 5);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 5);
        }

        // Sự kiện Resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateButtonPositions();
        }

        // Hiệu ứng hover cho nút Close
        private void guna2CircleButtonClose_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = LightenColor(closeButtonColor, 0.2f);
        }

        private void guna2CircleButtonClose_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = closeButtonColor;
        }

        // Hiệu ứng hover cho nút Minimize
        private void guna2CircleButtonMinimize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = LightenColor(minimizeButtonColor, 0.2f);
        }

        private void guna2CircleButtonMinimize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
        }

        // Hiệu ứng hover cho nút Maximize
        private void guna2CircleButtonMaximize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = LightenColor(maximizeButtonColor, 0.2f);
        }

        private void guna2CircleButtonMaximize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;
        }

        // Hàm làm sáng màu
        private Color LightenColor(Color color, float factor)
        {
            int r = (int)Math.Min(255, color.R + (255 - color.R) * factor);
            int g = (int)Math.Min(255, color.G + (255 - color.G) * factor);
            int b = (int)Math.Min(255, color.B + (255 - color.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        // Các sự kiện điều khiển nút
        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButtonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        // Di chuyển Form bằng Guna2Panel
        private bool isDragging = false;
        private Point startPoint;

        private void guna2PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void guna2PanelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void guna2PanelTitleBar_MouseUp(object sender, EventArgs e)
        {
            isDragging = false;
        }

        // Hiển thị giao diện quản lý thời khóa biểu
        private void btnQuanLyThoiKhoaBieu_Click(object sender, EventArgs e)
        {
            ShowUserControl(new ucQuanLyThoiKhoaBieu());
            btnQuanLyThoiKhoaBieu.FillColor = Color.FromArgb(214, 228, 255);
            btnQuanLyHocSinh.FillColor = Color.Transparent;
            lblPageTitle.Text = "Quản lý thời khóa biểu";
            btnQuanLyLop.FillColor = Color.Transparent;
        }

        // Hiển thị giao diện quản lý học sinh
        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            ShowUserControl(new ucQuanLyHocSinh());
            btnQuanLyHocSinh.FillColor = Color.FromArgb(214, 228, 255);
            btnQuanLyThoiKhoaBieu.FillColor = Color.Transparent;
            btnQuanLyLop.FillColor = Color.Transparent;
            lblPageTitle.Text = "Quản lý học sinh";
        }

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hiển thị UserControl trong panel
        public void ShowUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        // Hiển thị UserControl với kích thước tùy chỉnh
        public void ShowUserControlCustomSize(UserControl uc, DockStyle dockStyle = DockStyle.None, int width = 0, int height = 0)
        {
            pnlContent.Controls.Clear();
            if (width > 0 && height > 0)
            {
                uc.Size = new Size(width, height);
            }
            uc.Dock = dockStyle;
            if (dockStyle == DockStyle.None)
            {
                uc.Location = new Point(
                    (pnlContent.Width - uc.Width) / 2,
                    (pnlContent.Height - uc.Height) / 2
                );
                pnlContent.Resize += (sender, e) => {
                    uc.Location = new Point(
                        (pnlContent.Width - uc.Width) / 2,
                        (pnlContent.Height - uc.Height) / 2
                    );
                };
            }
            pnlContent.Controls.Add(uc);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSubSettings.Visible = !pnlSubSettings.Visible;

            // Cập nhật vị trí của panel tương đối so với nút btnSettings
            pnlSubSettings.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - pnlSubSettings.Height);

            // Thay đổi màu nút "Cài đặt" khi panel hiển thị
            btnSettings.FillColor = pnlSubSettings.Visible ? highlightColor : Color.Transparent;

            // Đảm bảo panel hiển thị trên cùng
            pnlSubSettings.BringToFront();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //// Xử lý đổi mật khẩu
            //pnlSubSettings.Visible = false;
            //btnSettings.FillColor = Color.Transparent;

            // Hiển thị form đổi mật khẩu
            using (GUI.Forms.frmChangePW changePwForm = new GUI.Forms.frmChangePW(id))
            {
                // Hiển thị form dạng dialog
                changePwForm.ShowDialog();
            }

            //lblPageTitle.Text = "Đổi mật khẩu";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                         "Xác nhận đăng xuất",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide(); 
                loginForm.FormClosed += (s, args) =>
                {
                    this.Close();
                };
            }
        }

        // Hiển thị giao diện quản lý lớp
        private void btnQuanLyLop_Click(object sender, EventArgs e)
        {
            ShowUserControl(new ucQuanLyLop());
            btnQuanLyLop.FillColor = Color.FromArgb(214, 228, 255);
            btnQuanLyHocSinh.FillColor = Color.Transparent;
            btnQuanLyThoiKhoaBieu.FillColor = Color.Transparent;
            lblPageTitle.Text = "Quản lý lớp";
        }
    }
}