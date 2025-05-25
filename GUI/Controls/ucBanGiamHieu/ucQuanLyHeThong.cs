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
using QuanLyTruongHoc.DAL;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucQuanLyHeThong : UserControl
    {
        private DataTable originalData;
        public ucQuanLyHeThong()
        {
            InitializeComponent();
            LoadData();
            this.Load += ucQuanLyHeThong_Load;
            this.VisibleChanged += UcQuanLyHeThong_VisibleChanged;
        }

        private void dgvQuanLyHeThong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateStatistics()
        {
            if (dgvQuanLyHeThong.DataSource is DataTable dt)
            {
                lblStatistic.Text = $"Tổng số: {dt.Rows.Count} hoạt động hệ thống";
            }
            else if (dgvQuanLyHeThong.DataSource is DataView dv)
            {
                lblStatistic.Text = $"Tổng số: {dv.Count} hoạt động hệ thống";
            }
        }
        private bool LoadData()
        {
            try
            {
                string query = @"
                SELECT NK.MaNguoiDung, 
                CASE 
                    WHEN ND.MaVaiTro = 1 THEN 
                        (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = NK.MaNguoiDung)
                    WHEN ND.MaVaiTro = 2 THEN GV.HoTen
                    WHEN ND.MaVaiTro = 3 THEN GV.HoTen
                    WHEN ND.MaVaiTro = 4 THEN HS.HoTen
                    ELSE N'Không xác định'
                END AS NguoiHanhDong,
                VT.TenVaiTro AS VaiTro, -- Lấy tên vai trò từ bảng VaiTro
                NK.HanhDong,
                FORMAT(NK.ThoiGian, 'yyyy-MM-dd HH:mm:ss') AS ThoiGian
                FROM NhatKyHeThong NK
                LEFT JOIN NguoiDung ND ON NK.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro -- Thêm JOIN với bảng VaiTro
                LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                ORDER BY NK.ThoiGian DESC";

                DatabaseHelper db = new DatabaseHelper();
                DataTable dt = db.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    originalData = dt;
                    dgvQuanLyHeThong.AutoGenerateColumns = false;
                    dgvQuanLyHeThong.DataSource = dt;
                    dgvQuanLyHeThong.ClearSelection();
                    UpdateStatistics(); // Cập nhật thống kê
                    return true;
                }
                else
                {
                    // Không có dữ liệu hoặc bảng trống
                    lblStatistic.Text = "Tổng số: 0 hoạt động hệ thống";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UcQuanLyHeThong_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                // Căn giữa DataGridView khi UserControl hiển thị
                dgvQuanLyHeThong.Left = (this.Width - dgvQuanLyHeThong.Width) / 2;
                dgvQuanLyHeThong.ClearSelection();
            }
        }

        private void ucQuanLyHeThong_Load(object sender, EventArgs e)
        {
            // Căn giữa DataGridView và thiết lập kiểu hiển thị tiêu đề cột
            dgvQuanLyHeThong.Left = (this.Width - dgvQuanLyHeThong.Width) / 2;
            dgvQuanLyHeThong.ClearSelection();
            dgvQuanLyHeThong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvQuanLyHeThong.EnableHeadersVisualStyles = false;
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            if (LoadData())
            {
                MessageBox.Show("Đã lấy dữ liệu mới nhất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Làm mới không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpLoc_ValueChanged(object sender, EventArgs e)
        {
            if (originalData == null) return;
            // Lọc dữ liệu theo ngày được chọn
            string selectedDate = dtpLoc.Value.ToString("yyyy-MM-dd");
            DataView dv = new DataView(originalData);
            dv.RowFilter = $"ThoiGian LIKE '{selectedDate}%'";
            dgvQuanLyHeThong.DataSource = dv;
            UpdateStatistics(); // Cập nhật thống kê sau khi lọc
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (originalData == null) return;

            // Lấy từ khóa từ TextBox
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                // Hiển thị lại dữ liệu gốc nếu không có từ khóa
                dgvQuanLyHeThong.DataSource = originalData;
                UpdateStatistics(); // Cập nhật thống kê
                return;
            }

            // Lọc dữ liệu theo từ khóa
            DataView dv = new DataView(originalData);
            dv.RowFilter = $"NguoiHanhDong LIKE '%{keyword}%'";
            dgvQuanLyHeThong.DataSource = dv;
            dgvQuanLyHeThong.ClearSelection();
            UpdateStatistics(); // Cập nhật thống kê sau khi lọc
        }
    }
}
