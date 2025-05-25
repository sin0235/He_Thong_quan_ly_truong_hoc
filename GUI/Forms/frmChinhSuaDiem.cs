using QuanLyTruongHoc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChinhSuaDiem : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int selectedMaHS;
        private int selectedMaMon;
        private DataGridView dgvDanhSachHocSinh;

        public frmChinhSuaDiem(int maHS, int maMon, DataGridView dgvDanhSachHocSinh)
        {
            InitializeComponent();
            selectedMaHS = maHS;
            selectedMaMon = maMon;

            this.dgvDanhSachHocSinh = dgvDanhSachHocSinh;

        }

        private void LoadDanhSachHS()
        {

            try
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY HS.MaHS) AS STT,
                        HS.MaHS,
                        HS.HoTen,
                        L.TenLop
                    FROM HocSinh HS
                    INNER JOIN LopHoc L ON HS.MaLop = L.MaLop";

                DataTable dt = db.ExecuteQuery(query);
                dgvDanhSachHocSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDiemHS(int maHS, int maMon)
        {
            try
            {
                string query = $@"
                    SELECT 
                        DS.MaDiem AS MaDiem,
                        ROW_NUMBER() OVER (ORDER BY DS.LoaiDiem) AS STT,
                        DS.LoaiDiem AS LoaiDiem,
                        DS.Diem AS Diem,
                        DS.HocKy AS HocKy
                    FROM DiemSo DS
                    WHERE DS.MaHS = {maHS} AND DS.MaMon = {maMon}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy điểm của học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemChiTietHocSinh.DataSource = null;
                    return;
                }

                dgvDiemChiTietHocSinh.AutoGenerateColumns = false;
                dgvDiemChiTietHocSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvDiemChiTietHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDiemChiTietHocSinh.Rows[e.RowIndex];
                loaiDiemCmb.Text = row.Cells["LoaiDiem"].Value.ToString();
                diemTxt.Text = row.Cells["Diem"].Value.ToString();

                // Chuyển đổi giá trị học kỳ thành chuỗi tương ứng
                string hocKyValue = $"Học kỳ {row.Cells["HocKy"].Value}";
                cmbHocKi.SelectedItem = hocKyValue;
            }
        }

        private void chinhSuaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiDiem = loaiDiemCmb.Text;
                float diem = float.Parse(diemTxt.Text);
                int hocKy = int.Parse(cmbHocKi.Text.Replace("Học kỳ ", ""));

                string query = $@"
                UPDATE DiemSo
                SET Diem = {diem}
                WHERE MaHS = {selectedMaHS} AND MaMon = {selectedMaMon} 
                AND LoaiDiem = N'{loaiDiem}' AND HocKy = {hocKy}";

                bool success = db.ExecuteNonQuery(query);
                if (success)
                {
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDiemHS(selectedMaHS, selectedMaMon); // Tải lại danh sách điểm
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy STT từ textbox
                if (string.IsNullOrWhiteSpace(sttTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập STT.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(sttTxt.Text, out int stt))
                {
                    MessageBox.Show("STT phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm kiếm trong DataGridView danh sách học sinh
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
                {
                    if (row.Cells["STT"].Value != null && int.Parse(row.Cells["STT"].Value.ToString()) == stt)
                    {
                        // Điền thông tin học sinh vào các trường
                        string hoTen = row.Cells["HoTen"].Value.ToString();
                        hoTenTxt.Text = hoTen;

                        selectedMaHS = Convert.ToInt32(row.Cells["MaHS"].Value);

                        // Tải thông tin điểm của học sinh
                        LoadDiemHS(selectedMaHS, selectedMaMon);
                        return;
                    }
                }

                MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmChinhSuaDiem_Load(object sender, EventArgs e)
        {
            LoadDanhSachHS();
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            if (dgvDiemChiTietHocSinh.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDiemChiTietHocSinh.SelectedRows[0];

                // Lấy MaDiem từ hàng được chọn
                if (selectedRow.Cells["MaDiem"].Value == null)
                {
                    MessageBox.Show("Không thể xác định điểm cần xóa. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maDiem = Convert.ToInt32(selectedRow.Cells["MaDiem"].Value);

                var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm này không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    string deleteQuery = $@"
            DELETE FROM DiemSo
            WHERE MaDiem = {maDiem}"; // Xóa dựa trên MaDiem

                    if (db.ExecuteNonQuery(deleteQuery))
                    {
                        MessageBox.Show("Xóa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDiemHS(selectedMaHS, selectedMaMon); // Tải lại danh sách điểm
                    }
                    else
                    {
                        MessageBox.Show("Xóa điểm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
