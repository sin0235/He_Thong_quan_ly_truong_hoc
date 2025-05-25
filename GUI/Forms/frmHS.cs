using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc
{
    public partial class frmHS : Form
    {
        // Lưu trữ màu gốc của các nút
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E
        private Color highlightColor = Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));



        private int maNguoiDung;


        private string hoTen;
        private int maHS = -1;


        public int ID
        {
            get { return maNguoiDung; }
        }
        public frmHS(int ID)
        {
            maNguoiDung = ID;
            getHSInfo();

            InitializeComponent();
            lblUserName.Text = hoTen;


            // Đảm bảo các nút nằm trong Guna2Panel
            guna2CircleButtonClose.Parent = pnlTitleBar;
            guna2CircleButtonMinimize.Parent = pnlTitleBar;
            guna2CircleButtonMaximize.Parent = pnlTitleBar;

            // Gán màu ban đầu cho các nút
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;


            // Mặc định hiển thị ucThongBao khi khởi động
            btnThongBao_Click(btnThongBao, EventArgs.Empty);
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 5);
            guna2CircleButtonMaximize.Location = new Point(pnlTitleBar.Width - 60, 5);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 5);

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

        // Phương thức để ẩn tất cả các user control
        private void HideAllUserControls()
        {
            // Ẩn tất cả các user control
            ucThongBao1.Visible = false;
            ucInfoHS1.Visible = false;
            ucTKB1.Visible = false;
            ucKQHT1.Visible = false;
            ucXinNghi1.Visible = false;
            ucKiemTra1.Visible = false;

            // Đặt lại màu của tất cả các nút
            btnThongBao.FillColor = Color.Transparent;
            btnInfo.FillColor = Color.Transparent;
            btnTKB.FillColor = Color.Transparent;
            btnKQHT.FillColor = Color.Transparent;
            btnReports.FillColor = Color.Transparent;
            btnBT.FillColor = Color.Transparent;
        }

        // Phương thức unLightButton được cập nhật
        private void unLightButton()
        {
            HideAllUserControls();
        }

        // Xử lý sự kiện click cho các nút menu
        private void btnThongBao_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucThongBao1.Visible = true;
            btnThongBao.FillColor = highlightColor;
            lblPageTitle.Text = "Thông báo";
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucInfoHS1.Visible = true;
            btnInfo.FillColor = highlightColor;
            lblPageTitle.Text = "Thông tin cá nhân";
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucTKB1.Visible = true;
            btnTKB.FillColor = highlightColor;
            lblPageTitle.Text = "Thời khóa biểu";
        }

        private void btnKQHT_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucKQHT1.Visible = true;
            btnKQHT.FillColor = highlightColor;
            lblPageTitle.Text = "Kết quả học tập";
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucXinNghi1.Visible = true;
            btnReports.FillColor = highlightColor;
            lblPageTitle.Text = "Đơn xin phép";
        }

        private void btnBT_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucKiemTra1.Visible = true;
            btnBT.FillColor = highlightColor;
            lblPageTitle.Text = "Kiểm tra - đánh giá";
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            // Phương thức này được thay thế bởi btnInfo_Click
            btnInfo.FillColor = highlightColor;
        }
        // Sửa phương thức btnSettings_Click
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

        // Xử lý các nút trong menu cài đặt
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Xử lý xem hồ sơ học sinh
            pnlSubSettings.Visible = false;
            btnSettings.FillColor = Color.Transparent;

            // Chuyển đổi sang user control thông tin học sinh
            HideAllUserControls();
            ucInfoHS1.Visible = true;
            btnInfo.FillColor = highlightColor;
            lblPageTitle.Text = "Hồ sơ học sinh";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Xử lý đổi mật khẩu
            pnlSubSettings.Visible = false;
            btnSettings.FillColor = Color.Transparent;

            // Hiển thị form đổi mật khẩu
            using (GUI.Forms.frmChangePW changePwForm = new GUI.Forms.frmChangePW(maNguoiDung))
            {
                // Hiển thị form dạng dialog
                changePwForm.ShowDialog();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                 "Xác nhận đăng xuất",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tạo và hiển thị form đăng nhập
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                // Đóng form hiện tại
                this.Hide(); // Ẩn form hiện tại thay vì đóng để tránh đóng ứng dụng

                // Đăng ký sự kiện FormClosed cho form đăng nhập
                loginForm.FormClosed += (s, args) =>
                {
                    // Nếu form đăng nhập đóng (không đăng nhập thành công), thoát ứng dụng
                    this.Close();
                };
            }
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            // Xử lý đổi mật khẩu
            pnlSubSettings.Visible = false;
            btnSettings.FillColor = Color.Transparent;

            // Hiển thị form đổi mật khẩu
            using (GUI.Forms.frmChangePW changePwForm = new GUI.Forms.frmChangePW(maNguoiDung))
            {
                // Hiển thị form dạng dialog
                changePwForm.ShowDialog();
            }

            lblPageTitle.Text = "Đổi mật khẩu";
        }
        private void getHSInfo()
        {
            // Tạo một đối tượng ThongTinHSDTO mới
            DatabaseHelper db = new DatabaseHelper();
            string query = $@"SELECT MaHS, HoTen FROM HocSinh WHERE MaNguoiDung = {this.maNguoiDung}";
            DataTable dt = db.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                maHS = Convert.ToInt32(dt.Rows[0]["MaHS"]);
                hoTen = dt.Rows[0]["HoTen"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin học sinh.");
                return;
            }
        }
    }
}