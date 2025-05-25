using QuanLyTruongHoc.GUI.Forms;
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
    public partial class ucDonXinNghiItem : UserControl
    {
        // Properties để lưu trữ thông tin đơn xin nghỉ
        private int _maDon;
        private string _tieuDe;
        private string _noiDung;
        private DateTime _ngayBatDau;
        private DateTime _ngayKetThuc;
        private DateTime _ngayTao;
        private int _trangThai; // 0: Đang chờ, 1: Đã duyệt, 2: Từ chối
        private string _phanHoi;
        private string _nguoiDuyet;

        // Properties với getter và setter
        public int MaDon
        {
            get { return _maDon; }
            set { _maDon = value; }
        }

        public string TieuDe
        {
            get { return _tieuDe; }
            set
            {
                _tieuDe = value;
                lblTitle.Text = value;
            }
        }

        public string NoiDung
        {
            get { return _noiDung; }
            set
            {
                _noiDung = value;
                lblNoiDung.Text = value;
            }
        }

        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
            set
            {
                _ngayBatDau = value;
                UpdateNgayNghi();
            }
        }

        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set
            {
                _ngayKetThuc = value;
                UpdateNgayNghi();
            }
        }

        public DateTime NgayTao
        {
            get { return _ngayTao; }
            set
            {
                _ngayTao = value;
                lblNgayTao.Text = $"Ngày tạo: {value.ToString("dd/MM/yyyy")}";
            }
        }

        public int TrangThai
        {
            get { return _trangThai; }
            set
            {
                _trangThai = value;
                UpdateTrangThai();
            }
        }

        public string PhanHoi
        {
            get { return _phanHoi; }
            set
            {
                _phanHoi = value;

                if (string.IsNullOrEmpty(value))
                {
                    lblPhanHoiTitle.Visible = false;
                    lblPhanHoi.Visible = false;
                }
                else
                {
                    lblPhanHoiTitle.Visible = true;
                    lblPhanHoi.Visible = true;
                    lblPhanHoi.Text = value;
                }
            }
        }

        public string NguoiDuyet
        {
            get { return _nguoiDuyet; }
            set { _nguoiDuyet = value; }
        }

        public ucDonXinNghiItem()
        {
            InitializeComponent();

            // Khởi tạo giá trị mặc định
            lblPhanHoiTitle.Visible = false;
            lblPhanHoi.Visible = false;
        }

        /// <summary>
        /// Constructor với tham số để khởi tạo đầy đủ thông tin
        /// </summary>
        public ucDonXinNghiItem(int maDon, string tieuDe, string noiDung,
            DateTime ngayBatDau, DateTime ngayKetThuc, DateTime ngayTao,
            int trangThai, string phanHoi = "", string nguoiDuyet = "")
        {
            InitializeComponent();

            // Khởi tạo giá trị từ tham số
            MaDon = maDon;
            TieuDe = tieuDe;
            NoiDung = noiDung;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            PhanHoi = phanHoi;
            NguoiDuyet = nguoiDuyet;
        }

        /// <summary>
        /// Cập nhật hiển thị ngày nghỉ
        /// </summary>
        private void UpdateNgayNghi()
        {
            if (_ngayBatDau == DateTime.MinValue || _ngayKetThuc == DateTime.MinValue)
                return;

            string ngayBD = _ngayBatDau.ToString("dd/MM/yyyy");
            string ngayKT = _ngayKetThuc.ToString("dd/MM/yyyy");

            if (ngayBD == ngayKT)
                lblNgayNghi.Text = $"Ngày nghỉ: {ngayBD}";
            else
                lblNgayNghi.Text = $"Ngày nghỉ: {ngayBD} - {ngayKT}";
        }

        /// <summary>
        /// Cập nhật hiển thị trạng thái đơn
        /// </summary>
        private void UpdateTrangThai()
        {
            switch (_trangThai)
            {
                case 0: // Đang chờ
                    lblStatus.Text = "Đang chờ";
                    lblStatus.ForeColor = Color.FromArgb(255, 171, 64); // Orange
                    break;
                case 1: // Đã duyệt
                    lblStatus.Text = "Đã duyệt";
                    lblStatus.ForeColor = Color.FromArgb(60, 180, 100); // Green
                    break;
                case 2: // Từ chối
                    lblStatus.Text = "Từ chối";
                    lblStatus.ForeColor = Color.FromArgb(235, 77, 77); // Red
                    break;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xem chi tiết
        /// </summary>
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị thông tin chi tiết đơn xin nghỉ
                using (var frm = new frmChiTietDonXinNghi(_maDon))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi hiển thị chi tiết đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật màu nền tùy thuộc vào trạng thái
        /// </summary>
        public void UpdateBackgroundColor()
        {
            switch (_trangThai)
            {
                case 0: // Đang chờ
                    pnlMain.FillColor = Color.White;
                    break;
                case 1: // Đã duyệt
                    pnlMain.FillColor = Color.FromArgb(245, 255, 245); // Light green
                    break;
                case 2: // Từ chối
                    pnlMain.FillColor = Color.FromArgb(255, 245, 245); // Light red
                    break;
            }
        }

        /// <summary>
        /// Đặt chiều cao động dựa trên nội dung
        /// </summary>
        public void AdjustHeight()
        {
            // Tính toán chiều cao cần thiết dựa trên nội dung
            int baseHeight = 150; // Chiều cao cơ bản

            // Tính chiều cao của nội dung
            int contentHeight = TextRenderer.MeasureText(
                lblNoiDung.Text,
                lblNoiDung.Font,
                new Size(lblNoiDung.Width, 0),
                TextFormatFlags.WordBreak
            ).Height;

            // Thêm chiều cao cho phản hồi nếu có
            if (!string.IsNullOrEmpty(_phanHoi))
            {
                int feedbackHeight = TextRenderer.MeasureText(
                    lblPhanHoi.Text,
                    lblPhanHoi.Font,
                    new Size(lblPhanHoi.Width, 0),
                    TextFormatFlags.WordBreak
                ).Height;

                contentHeight += feedbackHeight + 20; // 20 là khoảng cách giữa nội dung và phản hồi
            }

            // Giới hạn chiều cao tối đa
            int maxContentHeight = 300;
            contentHeight = Math.Min(contentHeight, maxContentHeight);

            // Đặt chiều cao mới
            int newHeight = baseHeight + contentHeight - 42; // 42 là chiều cao mặc định của lblNoiDung

            // Đặt lại chiều cao cho control
            this.Height = newHeight;
        }
    }
}
