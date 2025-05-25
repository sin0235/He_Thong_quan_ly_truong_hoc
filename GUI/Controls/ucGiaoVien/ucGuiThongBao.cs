using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
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
    public partial class ucGuiThongBao : UserControl
    {
        private int maNguoiDung;
        private int maGV;
        private readonly DatabaseHelper db;
        public ucGuiThongBao(int maNguoiDung, int maGV)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.maGV = maGV;
            this.maNguoiDung = maNguoiDung;
            LoadLopHoc();
            LoadThongBao();
        }

        public void LoadThongBao(int? selectedMaLop = null)
        {
            try
            {
                // Lấy danh sách thông báo từ cơ sở dữ liệu
                string query = selectedMaLop.HasValue
                    ? $@"
                        SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, lh.TenLop
                        FROM ThongBao tb
                        LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
                        WHERE tb.MaNguoiGui = {maNguoiDung} AND tb.MaLop = {selectedMaLop}"
                    : $@"
                        SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, lh.TenLop
                        FROM ThongBao tb
                        LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
                        WHERE tb.MaNguoiGui = {maNguoiDung}";

                dgvGuiThongBao.DataSource = db.ExecuteQuery(query);
                lblThongBao.Text = $"Thông báo ({(selectedMaLop.HasValue ? $"Lọc theo lớp: {lopCmb.Text}" : "Tất cả các lớp")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLopHoc()
        {
            try
            {
                // Lấy danh sách lớp học từ cơ sở dữ liệu
                string query = $@"
                    SELECT DISTINCT lh.MaLop, lh.TenLop 
                    FROM LopHoc lh
                    INNER JOIN GiaoVien gv ON gv.MaGV = {maGV}
                    INNER JOIN MonHoc mh ON gv.MaMon = mh.MaMon";

                DataTable dt = db.ExecuteQuery(query);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lớp nào được phân công cho giáo viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lopCmb.DataSource = null;
                    return;
                }

                lopCmb.DataSource = dt;
                lopCmb.DisplayMember = "TenLop";
                lopCmb.ValueMember = "MaLop";
                
                // Chọn lớp đầu tiên trong danh sách
                if (lopCmb.Items.Count > 0)
                {
                    lopCmb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lopCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một lớp học trước khi gửi thông báo.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra tiêu đề và nội dung thông báo
                string tieuDe = tieuDeTxt.Text.Trim();
                string noiDung = thongBaoTxt.Text.Trim();
                if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                {
                    MessageBox.Show("Tiêu đề và nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lấy mã lớp từ combobox
                int maLop = Convert.ToInt32(lopCmb.SelectedValue);
                // Thực hiện thêm thông báo vào cơ sở dữ liệu
                string query = $@"
                    INSERT INTO ThongBao (MaNguoiGui, MaLop, TieuDe, NoiDung, NgayGui, isActive)
                    VALUES ({maNguoiDung}, {maLop}, N'{tieuDe.Replace("'", "''")}', N'{noiDung.Replace("'", "''")}', GETDATE(), 1)";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Thêm thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tieuDeTxt.Clear();
                    thongBaoTxt.Clear();
                    LoadThongBao();
                }
                else
                {
                    MessageBox.Show("Thêm thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuiThongBao.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một thông báo để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lấy mã thông báo từ dòng được chọn
                int maTB = Convert.ToInt32(dgvGuiThongBao.SelectedRows[0].Cells["MaTB"].Value);
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông báo này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = $"DELETE FROM ThongBao WHERE MaTB = {maTB}";
                    if (db.ExecuteNonQuery(query))
                    {
                        MessageBox.Show("Xóa thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongBao();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuiThongBao.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một thông báo để chỉnh sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maTB = Convert.ToInt32(dgvGuiThongBao.SelectedRows[0].Cells["MaTB"].Value);
                string tieuDe = tieuDeTxt.Text.Trim();
                string noiDung = thongBaoTxt.Text.Trim();
                if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                {
                    MessageBox.Show("Tiêu đề và nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Thực hiện cập nhật thông báo vào cơ sở dữ liệu
                string query = $@"
                    UPDATE ThongBao
                    SET TieuDe = N'{tieuDe.Replace("'", "''")}', NoiDung = N'{noiDung.Replace("'", "''")}'
                    WHERE MaTB = {maTB}";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Cập nhật thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThongBao();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (lopCmb.SelectedValue != null)
                {
                    int selectedMaLop = Convert.ToInt32(lopCmb.SelectedValue);
                    LoadThongBao(selectedMaLop);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một lớp để lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadThongBao(null);
        }

        private void lopCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvGuiThongBao_SelectionChanged(object sender, EventArgs e)
        {
        }

        

        private void dgvGuiThongBao_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvGuiThongBao.Rows[e.RowIndex];
                // Hiển thị thông tin thông báo vào các textbox
                tieuDeTxt.Text = row.Cells["TieuDe"].Value?.ToString() ?? string.Empty;
                thongBaoTxt.Text = row.Cells["NoiDung"].Value?.ToString() ?? string.Empty;

                if (int.TryParse(row.Cells["MaTB"].Value?.ToString(), out int maTB))
                {
                    string query = $"SELECT MaLop FROM ThongBao WHERE MaTB = {maTB}";
                    DataTable dt = db.ExecuteQuery(query);
                    // Lấy mã lớp từ thông báo
                    if (dt?.Rows.Count > 0 && int.TryParse(dt.Rows[0]["MaLop"].ToString(), out int maLop))
                    {
                        // Tìm chỉ số của lớp trong combobox
                        lopCmb.SelectedIndex = lopCmb.Items.Cast<DataRowView>()
                            .ToList()
                            .FindIndex(item => Convert.ToInt32(item["MaLop"]) == maLop);
                    }
                }

                dgvGuiThongBao.CurrentCell = row.Cells[e.ColumnIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
