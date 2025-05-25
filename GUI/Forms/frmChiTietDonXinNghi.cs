using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChiTietDonXinNghi : Form
    {
        private readonly int _maDon;
        private readonly DatabaseHelper _dbHelper;
        private readonly List<int> _attachmentIds = new List<int>();

        // Variables for dragging the form
        private bool isDragging = false;
        private Point startPoint;

        public frmChiTietDonXinNghi(int maDon)
        {
            InitializeComponent();
            _maDon = maDon;
            _dbHelper = new DatabaseHelper();

            // Apply shadow to form
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void frmChiTietDonXinNghi_Load(object sender, EventArgs e)
        {
            LoadDonXinNghi();

            pnlDinhKem.Visible = true;
        }

        /// <summary>
        /// Tải thông tin đơn xin nghỉ
        /// </summary>
        private void LoadDonXinNghi()
        {
            try
            {
                // Điều chỉnh truy vấn SQL để phù hợp với cấu trúc bảng DonXinNghi
                string query = $@"
                        SELECT 
                            d.MaDon, 
                            d.MaHS,
                            d.NgayGui, 
                            d.NgayNghi, 
                            d.LyDo, 
                            d.TrangThai,
                            d.MaGV,
                            hs.HoTen as TenHocSinh,
                            gv.HoTen as NguoiDuyet
                        FROM DonXinNghi d
                        INNER JOIN HocSinh hs ON d.MaHS = hs.MaHS
                        LEFT JOIN GiaoVien gv ON d.MaGV = gv.MaGV
                        WHERE d.MaDon = {_maDon}";

                DataTable data = _dbHelper.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];

                    // Hiển thị thông tin đơn xin nghỉ
                    this.Text = $"Chi tiết đơn xin nghỉ #{_maDon}";
                    lblFormTitle.Text = $"Chi tiết đơn xin nghỉ #{_maDon}";

                    // Thêm thông tin học sinh
                    string tenHocSinh = row["TenHocSinh"].ToString();
                    lblTieuDe.Text = $"Đơn xin nghỉ học - {tenHocSinh}";

                    // Hiển thị ngày tạo đơn
                    lblNgayTao.Text = $"Ngày gửi: {Convert.ToDateTime(row["NgayGui"]).ToString("dd/MM/yyyy HH:mm")}";

                    // Hiển thị ngày nghỉ - bảng DonXinNghi chỉ có 1 ngày nên không có ngày kết thúc
                    DateTime ngayNghi = Convert.ToDateTime(row["NgayNghi"]);
                    lblThoiGianNghi.Text = $"Ngày nghỉ: {ngayNghi.ToString("dd/MM/yyyy")}";

                    // Hiển thị lý do nghỉ
                    txtNoiDung.Text = row["LyDo"].ToString();

                    // Hiển thị trạng thái
                    string trangThai = row["TrangThai"].ToString();
                    switch (trangThai)
                    {
                        case "Chờ duyệt":
                            lblTrangThai.Text = "Trạng thái: Đang chờ duyệt";
                            lblTrangThai.ForeColor = Color.FromArgb(255, 240, 150); // Light Yellow
                            break;
                        case "Đã duyệt":
                            lblTrangThai.Text = "Trạng thái: Đã duyệt";
                            lblTrangThai.ForeColor = Color.FromArgb(180, 255, 180); // Light Green
                            break;
                        case "Từ chối":
                            lblTrangThai.Text = "Trạng thái: Từ chối";
                            lblTrangThai.ForeColor = Color.FromArgb(255, 160, 160); // Light Red
                            break;
                        default:
                            lblTrangThai.Text = "Trạng thái: " + trangThai;
                            lblTrangThai.ForeColor = Color.FromArgb(255, 240, 150); // Light Yellow
                            break;
                    }

                    // Hiển thị thông tin người duyệt và phản hồi
                    if (row["MaGV"] != DBNull.Value)
                    {
                        string nguoiDuyet = row["NguoiDuyet"].ToString();
                        if (!string.IsNullOrEmpty(nguoiDuyet))
                            lblNguoiDuyet.Text = $"Người duyệt: {nguoiDuyet}";
                        else
                            lblNguoiDuyet.Visible = true; // Vẫn hiển thị để tránh giao diện trống
                    }
                    else
                    {
                        lblNguoiDuyet.Text = "Người duyệt: Chưa có";
                    }
                    lblPhanHoiTitle.Visible = true;
                    txtPhanHoi.Visible = true;
                    txtPhanHoi.Text = "";
                    txtPhanHoi.Enabled = false;
                    txtPhanHoi.ForeColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin đơn xin nghỉ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải thông tin đơn xin nghỉ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tạo control hiển thị tệp đính kèm
        /// </summary>
        private void AddAttachmentControl(int maDinhKem, string tenFile, long kichThuoc)
        {
            // Giữ lại phương thức cho các tương thích trong tương lai
            // nhưng không triển khai chức năng hiện tại
        }

        /// <summary>
        /// Tải xuống tệp đính kèm
        /// </summary>
        private void DownloadAttachment(int maDinhKem, string tenFile)
        {
            // Giữ lại phương thức cho các tương thích trong tương lai
            // nhưng hiển thị thông báo chức năng không khả dụng
            MessageBox.Show("Chức năng tải xuống tệp đính kèm hiện không khả dụng.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Format kích thước tệp
        /// </summary>
        private string FormatFileSize(long fileSize)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            double size = fileSize;

            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }

            return $"{size:0.##} {suffixes[suffixIndex]}";
        }

        /// <summary>
        /// Lấy icon tương ứng với loại tệp
        /// </summary>
        private Image GetFileIcon(string extension)
        {
            // Sử dụng SystemIcons.Application thay vì SystemIcons.Document
            return System.Drawing.SystemIcons.Application.ToBitmap();
        }

        #region Form Control Methods

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút đóng
        /// </summary>
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Handle form dragging
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        #endregion
    }
}
