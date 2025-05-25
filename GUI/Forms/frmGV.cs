using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Controls;
using QuanLyTruongHoc.GUI.Controls.ucGiaoVien;
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc
{
    public partial class frmGV : Form
    {
        // Các biến màu sắc cho các nút
        private Color closeButtonColor = Color.FromArgb(255, 96, 92);
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68);
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78);
        private Color highlightColor = Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));

        // Biến lưu mã người dùng và tên giáo viên
        private int maNguoiDung;
        private string hoTen;
        private readonly DatabaseHelper db;
        private int maGV;

        // Biến theo dõi trạng thái menu con
        private bool isSubMenuVisible = false;

        public frmGV(int maNguoiDung)
        {
            InitializeComponent();

            this.maNguoiDung = maNguoiDung;
            db = new DatabaseHelper();
            maGV = GetMaGiaoVien(maNguoiDung);

            //Hiển thị tên người dùng
            LoadTenNguoiDung(maNguoiDung);

            //Load hình đại diện
            LoadAnhDaiDien();

            //Kiểm tra có phải GVCN không
            if (!KiemTraGVCN(maNguoiDung))
            {
                quanLyLopBtn.Visible = false; // Ẩn "Quản lý lớp"
            }

            // Ẩn ban đầu các nút con của menu Kiểm tra
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;

            // Ensure buttons are within the Guna2Panel
            guna2CircleButtonClose.Parent = pnlTitleBar;
            guna2CircleButtonMinimize.Parent = pnlTitleBar;
            guna2CircleButtonMaximize.Parent = pnlTitleBar;

            // Assign initial colors to buttons
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;

            // Ensure buttons are visible
            guna2CircleButtonClose.Visible = true;
            guna2CircleButtonMinimize.Visible = true;
            guna2CircleButtonMaximize.Visible = true;

            // Update button positions when the form is initialized
            UpdateButtonPositions();

            // Register Resize event
            this.Resize += new EventHandler(Form1_Resize);

            LoadThongBao();
            lblPageTitle.Text = "Thông báo";
        }

        private bool KiemTraGVCN(int maNguoiDung)
        {
            string query = $@"
                    SELECT MaLop
                    FROM LopHoc
                    WHERE MaGVChuNhiem = (SELECT MaGV FROM GiaoVien WHERE MaNguoiDung = {maNguoiDung})";

            object result = db.ExecuteScalar(query);
            return result != null && result != DBNull.Value;
        }

        private void LoadTenNguoiDung(int maNguoiDung)
        {
            try
            {
                string query = $@"
                        SELECT GiaoVien.HoTen
                        FROM GiaoVien
                        WHERE GiaoVien.MaNguoiDung = {maNguoiDung}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    hoTen = dt.Rows[0]["HoTen"].ToString();
                    lblUserName.Text = $"{hoTen}";
                }
                else
                {
                    lblUserName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị tên người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thongBaoBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Thông báo";
            LoadThongBao();

            // Ẩn menu con nếu đang hiển thị
            HideSubMenu();
        }

        private void LoadThongBao()
        {
            pnlContent.Controls.Clear();
            ucXemThongBao uc = new ucXemThongBao(maNguoiDung);
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void thongTinCaNhanBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Thông tin cá nhân";
            pnlContent.Controls.Clear();
            ucThongTinCaNhan uc = new ucThongTinCaNhan();
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            uc.LoadThongTinCaNhan(maNguoiDung);

            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private void lichDayBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Lịch dạy";
            pnlContent.Controls.Clear();
            ucThoiKhoaBieu uc = new ucThoiKhoaBieu(maNguoiDung);
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            uc.LoadLichDay(maNguoiDung);
            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }


        private void keHoachGiangDayBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Kế hoạch giảng dạy";
            pnlContent.Controls.Clear();
            ucQuanLyKeHoachGiangDay uc = new ucQuanLyKeHoachGiangDay(GetMaGiaoVien(maNguoiDung));
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();

            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private void quanLyDiemSoBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý điểm số";
            pnlContent.Controls.Clear();
            ucQuanLyDiemSo uc = new ucQuanLyDiemSo(maNguoiDung, GetMaGiaoVien(maNguoiDung));
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private void quanLyLopBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý lớp";
            pnlContent.Controls.Clear();
            int maGVChuNhiem = GetMaGiaoVien(maNguoiDung);
            ucQuanLyLop_GVCN uc = new ucQuanLyLop_GVCN(maGVChuNhiem);
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();


            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private void guiThongBaoBtn_Click(object sender, EventArgs e)
        {
            int maGV = GetMaGiaoVien(maNguoiDung);
            lblPageTitle.Text = "Gửi thông báo";
            pnlContent.Controls.Clear();
            ucGuiThongBao uc = new ucGuiThongBao(maNguoiDung, maGV);
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            // Thêm mã mới để ẩn các nút con
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private int GetMaGiaoVien(int maNguoiDung)
        {
            string query = $@"
                SELECT MaGV
                FROM GiaoVien
                WHERE MaNguoiDung = {maNguoiDung}";
            object result = db.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        private void BtnEx_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái hiển thị của các nút con
            btnTaoEx.Visible = !btnTaoEx.Visible;
            btnQuanLyEx.Visible = !btnQuanLyEx.Visible;

            // Thay đổi màu nền của nút chính khi được chọn
            btnEx.FillColor = btnTaoEx.Visible ?
                Color.FromArgb(157, 192, 239) :
                Color.FromArgb(157, 192, 239);

            // Ẩn các nút con khác nếu có
            if (pnlSubSettings.Visible)
            {
                pnlSubSettings.Visible = false;
                btnSetting.FillColor = Color.Transparent;
            }

        }

        private void AdjustSubMenuButtonsPosition()
        {
            // Điều chỉnh vị trí của các nút con dựa trên vị trí của nút chính
            if (btnEx != null && btnTaoEx != null && btnQuanLyEx != null)
            {
                int yOffset = 5; // Khoảng cách giữa các nút

                btnTaoEx.Location = new Point(btnEx.Location.X + 20, btnEx.Location.Y + btnEx.Height + yOffset);
                btnQuanLyEx.Location = new Point(btnEx.Location.X + 20, btnTaoEx.Location.Y + btnTaoEx.Height + yOffset);
            }
        }

        private void HideSubMenu()
        {
            if (isSubMenuVisible)
            {
                isSubMenuVisible = false;
                btnTaoEx.Visible = false;
                btnQuanLyEx.Visible = false;
                btnEx.FillColor = Color.Transparent;
            }
        }

        private void LoadAnhDaiDien()
        {
            try
            {
                // Query to get gender from the NguoiDung table
                string query = $@"
                        SELECT gv.GioiTinh
                        FROM GiaoVien gv
                        WHERE gv.MaGV = {GetMaGiaoVien(maNguoiDung)}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Retrieve the gender
                    string gender = dt.Rows[0]["GioiTinh"].ToString();

                    // Set the avatar based on gender
                    if (gender == "Nam")
                    {
                        picUserAvatar.Image = Properties.Resources.defautAvatar_Teacher_Male; // Replace with your male image resource
                    }
                    else
                    {
                        picUserAvatar.Image = Properties.Resources.defautAvatar_Teacher_Female; // Replace with your female image resource
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy ảnh đại diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            pnlSubSettings.Visible = !pnlSubSettings.Visible;

            // Cập nhật vị trí của panel tương đối so với nút btnSettings
            pnlSubSettings.Location = new Point(btnSetting.Location.X, btnSetting.Location.Y - pnlSubSettings.Height);

            // Thay đổi màu nút "Cài đặt" khi panel hiển thị
            btnSetting.FillColor = pnlSubSettings.Visible ? highlightColor : Color.Transparent;

            // Đảm bảo panel hiển thị trên cùng
            pnlSubSettings.BringToFront();

            // Ẩn các nút con khác
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;
            btnEx.FillColor = Color.FromArgb(157, 192, 239);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Xử lý đổi mật khẩu
            pnlSubSettings.Visible = false;
            btnSetting.FillColor = Color.Transparent;

            // Hiển thị form đổi mật khẩu
            using (GUI.Forms.frmChangePW changePwForm = new GUI.Forms.frmChangePW(maNguoiDung))
            {
                // Hiển thị form dạng dialog
                changePwForm.ShowDialog();
            }

            lblPageTitle.Text = "Đổi mật khẩu";
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


        // Hàm cập nhật vị trí nút
        private void UpdateButtonPositions()
        {
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 5);
            guna2CircleButtonMaximize.Location = new Point(pnlTitleBar.Width - 60, 5);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 5);

            // Cập nhật vị trí của các nút con nếu đang hiển thị
            if (isSubMenuVisible)
            {
                AdjustSubMenuButtonsPosition();
            }
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

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2PanelTitleBar_MouseUp(object sender, EventArgs e)
        {
            isDragging = false;
        }

        private void ucThongBaoGiaoVien1_Load(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Ẩn các nút con khi khởi động form
            btnTaoEx.Visible = false;
            btnQuanLyEx.Visible = false;

            // Đăng ký sự kiện click cho nút Ex
            btnEx.Click += BtnEx_Click;
        }

        private void btnTaoEx_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Tạo bài kiểm tra";
            pnlContent.Controls.Clear();

            // Tạo mới ucTaoBaiKiemTra
            ucTaoBaiKiemTra ucTaoEx = new ucTaoBaiKiemTra(maGV);

            // Đăng ký các sự kiện
            ucTaoEx.TestCreated += (s, args) =>
            {
                // Quay lại màn hình trước đó hoặc làm mới giao diện nếu cần
                LoadThongBao(); // Ví dụ: quay lại màn hình thông báo
                lblPageTitle.Text = "Thông báo";
            };

            ucTaoEx.TestSavedAsDraft += (s, args) =>
            {
                // Quay lại màn hình trước đó hoặc làm mới giao diện nếu cần
                LoadThongBao(); // Ví dụ: quay lại màn hình thông báo
                lblPageTitle.Text = "Thông báo";
            };

            ucTaoEx.TestCanceled += (s, args) =>
            {
                // Quay lại màn hình trước đó
                LoadThongBao(); // Ví dụ: quay lại màn hình thông báo
                lblPageTitle.Text = "Thông báo";
            };

            ucTaoEx.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ucTaoEx);
            ucTaoEx.BringToFront();

            // Ẩn menu con sau khi chọn
            HideSubMenu();
        }

        private void btnQuanLyEx_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý bài kiểm tra";

            // Hiển thị form quản lý bài kiểm tra trong tab mới
            using (frmQuanLyEx quanLyExForm = new frmQuanLyEx(maGV))
            {
                quanLyExForm.ShowDialog();
            }

            // Ẩn menu con sau khi chọn
            HideSubMenu();
        }
    }
}
