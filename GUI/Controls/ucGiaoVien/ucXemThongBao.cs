using QuanLyTruongHoc.DAL;
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

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucXemThongBao : UserControl
    {
        private readonly DatabaseHelper db;
        private int maNguoiDung;
        public ucXemThongBao(int maNguoiDung)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.maNguoiDung = maNguoiDung;
            LoadThongBaoChung();
        }


        // Hiển thị thông báo chung
        private void LoadThongBaoChung()
        {
            // Lấy danh sách thông báo chung từ cơ sở dữ liệu
            string query = @"
                SELECT 
                    ThongBao.MaNguoiGui,
                    ThongBao.TieuDe, 
                    ThongBao.NoiDung, 
                    ThongBao.NgayGui, 
                    CASE 
                        WHEN GiaoVien.HoTen IS NOT NULL THEN GiaoVien.HoTen
                        WHEN ND.MaVaiTro = 1 THEN (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = ThongBao.MaNguoiGui)
                        ELSE N'Không xác định'
                    END AS NguoiGui
                FROM 
                    ThongBao
                LEFT JOIN 
                    NguoiDung ND ON ThongBao.MaNguoiGui = ND.MaNguoiDung
                LEFT JOIN 
                    GiaoVien ON ND.MaNguoiDung = GiaoVien.MaNguoiDung
                WHERE 
                    ThongBao.MaNguoiNhan IS NULL AND (ThongBao.MaVaiTroNhan IS NULL OR ThongBao.MaVaiTroNhan = 2)
                ORDER BY 
                    ThongBao.NgayGui DESC";
            DataTable dt = db.ExecuteQuery(query);
            thongBaoDgv.DataSource = dt;
        }

        // Tìm kiếm thông báo
        private void TimKiemThongBao()
        {
            string keyword = timKiemTBTxt.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm kiếm thông báo theo tiêu đề hoặc nội dung
            string query = @"
                SELECT 
                    ThongBao.TieuDe, 
                    ThongBao.NoiDung, 
                    ThongBao.NgayGui, 
                    CASE 
                        WHEN GiaoVien.HoTen IS NOT NULL THEN GiaoVien.HoTen
                        WHEN ND.MaVaiTro = 1 THEN (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = ThongBao.MaNguoiGui)
                        ELSE N'Không xác định'
                    END AS NguoiGui
                FROM 
                    ThongBao
                LEFT JOIN 
                    NguoiDung ND ON ThongBao.MaNguoiGui = ND.MaNguoiDung
                LEFT JOIN 
                    GiaoVien ON ND.MaNguoiDung = GiaoVien.MaNguoiDung
                WHERE 
                    (ThongBao.TieuDe LIKE @Keyword OR ThongBao.NoiDung LIKE @Keyword)
                ORDER BY 
                    ThongBao.NgayGui DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Keyword", $"%{keyword}%" }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            thongBaoDgv.DataSource = dt;
        }

        private void thongBaoChungBtn_Click(object sender, EventArgs e)
        {
            LoadThongBaoChung();
        }

        private void timKiemTBBtn_Click(object sender, EventArgs e)
        {
            TimKiemThongBao();
        }

        private void lamMoiTBBtn_Click(object sender, EventArgs e)
        {
            LoadThongBaoChung();

        }

        private void thongBaoDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được chọn
                int maNguoiGui = Convert.ToInt32(thongBaoDgv.Rows[e.RowIndex].Cells["MaNguoiGui"].Value);
                string tieuDe = thongBaoDgv.Rows[e.RowIndex].Cells["TieuDe"].Value.ToString();
                string noiDung = thongBaoDgv.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                string ngayGui = thongBaoDgv.Rows[e.RowIndex].Cells["NgayGui"].Value.ToString();
                string nguoiGui = thongBaoDgv.Rows[e.RowIndex].Cells["NguoiGui"].Value.ToString();
                // Tạo và hiển thị Form chi tiết
                var frmChiTiet = new frmThongBaoChiTiet(tieuDe, noiDung, ngayGui, nguoiGui, maNguoiGui);
                frmChiTiet.ShowDialog();
            }
        }
    }
}
