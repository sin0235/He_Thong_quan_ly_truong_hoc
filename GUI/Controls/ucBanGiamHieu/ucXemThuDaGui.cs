using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Controls.ucBanGiamHieu
{
    public partial class ucXemThuDaGui : UserControl
    {
        public ucXemThuDaGui()
        {
            InitializeComponent();
            this.Load += ucXemThuDaGui_Load;
        }

        private void UpdateStatistics()
        {
            int visibleCount = 0;
            foreach (DataGridViewRow row in dgvXemThu.Rows)
            {
                if (row.Visible)
                {
                    visibleCount++;
                }
            }

            lblStatistics.Text = $"Tổng số: {visibleCount} thư";
        }
        // Tải dữ liệu thông báo đã gửi
        private void LoadData()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.OpenConnection();
                string query = @"
                SELECT MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, TieuDe, NoiDung, NgayGui
                FROM ThongBao
                WHERE MaNguoiGui = 1
                ORDER BY NgayGui DESC"; 
                DataTable thongBaoTable = db.ExecuteQuery(query);
                dgvXemThu.Rows.Clear();
                foreach (DataRow row in thongBaoTable.Rows)
                {
                    string nguoiGui = "Ban giám hiệu";
                    string nguoiNhan = GetNguoiNhan(db, row);
                    string tieuDe = row["TieuDe"].ToString();
                    string noiDung = row["NoiDung"].ToString();
                    string thoiGian = Convert.ToDateTime(row["NgayGui"]).ToString("dd/MM/yyyy HH:mm:ss");
                    int maTB = Convert.ToInt32(row["MaTB"]);

                    dgvXemThu.Rows.Add(maTB, nguoiGui, nguoiNhan, tieuDe, noiDung, thoiGian);
                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Lấy thông tin người nhận từ cơ sở dữ liệu
        private string GetNguoiNhan(DatabaseHelper db, DataRow row)
        {
            if (row["MaNguoiNhan"] != DBNull.Value)
            {
                int maNguoiNhan = Convert.ToInt32(row["MaNguoiNhan"]);
                string query = $@"
                SELECT GV.HoTen AS TenDayDu, VT.TenVaiTro
                FROM GiaoVien GV
                INNER JOIN NguoiDung ND ON GV.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                WHERE ND.MaNguoiDung = {maNguoiNhan}";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    query = $@"
                    SELECT HS.HoTen AS TenDayDu, VT.TenVaiTro
                    FROM HocSinh HS
                    INNER JOIN NguoiDung ND ON HS.MaNguoiDung = ND.MaNguoiDung
                    LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                    WHERE ND.MaNguoiDung = {maNguoiNhan}";
                    result = db.ExecuteQuery(query);
                }

                if (result.Rows.Count == 0)
                {
                    query = $@"
                    SELECT ND.TenDangNhap, VT.TenVaiTro
                    FROM NguoiDung ND
                    INNER JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                    WHERE ND.MaNguoiDung = {maNguoiNhan} AND VT.TenVaiTro = N'Nhân viên phòng nội vụ'";
                    result = db.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        string vaiTro = result.Rows[0]["TenVaiTro"].ToString();
                        return vaiTro;
                    }
                }

                if (result.Rows.Count > 0)
                {
                    string vaiTro = result.Rows[0]["TenVaiTro"].ToString();
                    string hoTen = result.Rows[0]["TenDayDu"].ToString();
                    return $"{vaiTro} {hoTen}";
                }
                else
                {
                    return "Không xác định";
                }
            }
            else if (row["MaVaiTroNhan"] != DBNull.Value)
            {
                int maVaiTro = Convert.ToInt32(row["MaVaiTroNhan"]);
                string query = $@"
                SELECT TenVaiTro
                FROM VaiTro
                WHERE MaVaiTro = {maVaiTro}";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["TenVaiTro"].ToString(); 
                }
            }
            else if (row["MaLop"] != DBNull.Value)
            {
                string query = $@"
                SELECT TenLop
                FROM LopHoc
                WHERE MaLop IN ({row["MaLop"]})";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    return string.Join(", ", result.AsEnumerable().Select(r => r["TenLop"].ToString()));
                }
            }
            return "Không có thông tin người nhận";
        }
        private void ucXemThuDaGui_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvXemThu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvXemThu.ClearSelection();
        }

        // Xóa các thông báo đã chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvXemThu.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thư đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DatabaseHelper db = new DatabaseHelper();
                        db.OpenConnection();
                        foreach (DataGridViewRow selectedRow in dgvXemThu.SelectedRows)
                        {
                            if (selectedRow.Cells["MaTB"].Value != null)
                            {
                                int maTB = Convert.ToInt32(selectedRow.Cells["MaTB"].Value);

                                // Xóa các bản ghi liên quan trong ThongBaoNguoiDoc trước
                                string deleteNguoiDoc = $"DELETE FROM ThongBaoNguoiDoc WHERE MaTB = {maTB}";
                                db.ExecuteNonQuery(deleteNguoiDoc);

                                // Sau đó xóa ThongBao
                                string deleteQuery = $"DELETE FROM ThongBao WHERE MaTB = {maTB}";
                                db.ExecuteNonQuery(deleteQuery);

                                dgvXemThu.Rows.Remove(selectedRow);
                            }
                        }

                        MessageBox.Show("Xóa thư đã chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thư để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                MessageBox.Show("Dữ liệu đã được làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvXemThu.ClearSelection();
        }

        // Hiển thị chi tiết thông báo đã chọn
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvXemThu.SelectedRows.Count > 0)
            {
                var selectedRow = dgvXemThu.SelectedRows[0];
                string thoiGian = selectedRow.Cells["ThoiGian"].Value?.ToString() ?? "";
                string nguoiNhan = selectedRow.Cells["NguoiNhan"].Value?.ToString() ?? "";
                string noiDung = selectedRow.Cells["NoiDung"].Value?.ToString() ?? "";
                string tieuDe = selectedRow.Cells["TieuDe"].Value?.ToString() ?? "";

                var ucChiTiet = new ucXemTBChiTiet();
                ucChiTiet.SetThongBaoChiTiet(thoiGian, nguoiNhan, noiDung, tieuDe);

                var parentForm = this.FindForm() as frmBGH;
                parentForm.ShowUserControlCustomSize(ucChiTiet, DockStyle.None);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tìm kiếm thông báo theo từ khóa
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                    return;
                }
                string[] keywords = keyword.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (DataGridViewRow row in dgvXemThu.Rows)
                {
                    if (row.IsNewRow) continue;
                    string nguoiNhan = row.Cells["NguoiNhan"].Value?.ToString() ?? "";
                    bool isMatch = keywords.Any(k => nguoiNhan.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0);
                    row.Visible = isMatch;
                }
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
