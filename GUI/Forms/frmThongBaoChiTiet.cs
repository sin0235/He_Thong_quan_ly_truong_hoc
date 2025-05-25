using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmThongBaoChiTiet : Form
    {
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string NgayGui { get; set; }
        public string NguoiGui { get; set; }
        private int maNguoiGui;
        private readonly DatabaseHelper dbHelper;

        public frmThongBaoChiTiet(string tieuDe, string noiDung, string ngayGui, string nguoiGui, int maNguoiGui)
        {
            InitializeComponent();
            TieuDe = tieuDe;
            NoiDung = noiDung;
            NgayGui = ngayGui;
            NguoiGui = nguoiGui;
            this.maNguoiGui = maNguoiGui;
            dbHelper = new DatabaseHelper();
            LoadThongBaoChiTiet();
        }

        private void LoadThongBaoChiTiet()
        {
            string nguoiguitb;
            lblTieuDe.Text = $"Tiêu Đề: {TieuDe}";
            ndThongBaoTxt.Text = NoiDung;
            lblThoiGianGui.Text = $"Ngày: {NgayGui}";

            if (NguoiGui == "bgh")
            {
                nguoiguitb = "Ban Giám Hiệu";
            }
            else
            {
                nguoiguitb = NguoiGui;
            }
            lblNguoiGui.Text = nguoiguitb;

            LoadAnhDaiDien();
        }

        private void LoadAnhDaiDien()
        {
            string gioiTinh = getGioiTinh(maNguoiGui);

            try
            {
                if (!string.IsNullOrEmpty(gioiTinh) && gioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                {
                    avatarPTB.Image = Properties.Resources.defautAvatar_Teacher_Female;
                }
                else
                {
                    avatarPTB.Image = Properties.Resources.defautAvatar_Teacher_Male;
                }
                avatarPTB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải hình đại diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy giới tính dựa vào MaNguoiGui
        private string getGioiTinh(int maNguoiGui)
        {
            string gioiTinh = null;

            // Thử lấy giới tính từ giáo viên
            string queryGV = $"SELECT GioiTinh FROM GiaoVien WHERE MaNguoiDung = {maNguoiGui}";
            object resultGV = dbHelper.ExecuteScalar(queryGV);
            if (resultGV != null && resultGV != DBNull.Value)
            {
                gioiTinh = resultGV.ToString();
            }

            return gioiTinh;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
