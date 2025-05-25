using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Controls.ucGiaoVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmNhapDiem : Form
    {
        private readonly DatabaseHelper db;
        private readonly int maGV;
        private DataGridView dgvDanhSachHocSinh;

        private readonly int maMon;

        public frmNhapDiem(int maGV, int maMon, DataGridView dgvDanhSachHocSinh)
        {
            InitializeComponent();
            this.maGV = maGV;
            this.maMon = maMon;
            db = new DatabaseHelper();
            this.dgvDanhSachHocSinh = dgvDanhSachHocSinh;
        }

        private void LoadComboBoxData()
        {
            try
            {

                // Load HocKy từ bảng DiemSo
                string queryHocKy = "SELECT DISTINCT HocKy FROM DiemSo";
                DataTable dtHocKy = db.ExecuteQuery(queryHocKy);

                if (dtHocKy.Rows.Count > 0)
                {
                    foreach (DataRow row in dtHocKy.Rows)
                    {
                        string hocKy = "Kỳ " + row["HocKy"].ToString();
                        if (!cmbHocKi.Items.Contains(hocKy))
                        {
                            cmbHocKi.Items.Add(hocKy);
                        }
                    }
                }

                // Đặt giá trị mặc định
                cmbHocKi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDiemHS(int maHS)
        {
            try
            {
                // Kiểm tra nếu không có giá trị trong ComboBox
                if (string.IsNullOrWhiteSpace(cmbHocKi.Text))
                {
                    MessageBox.Show("Vui lòng chọn học kỳ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi giá trị học kỳ từ "Kỳ 1", "Kỳ 2" thành số nguyên
                string hocKyText = cmbHocKi.Text;
                if (!hocKyText.StartsWith("Kỳ") || !int.TryParse(hocKyText.Replace("Kỳ ", ""), out int hocKy))
                {
                    MessageBox.Show("Học kỳ không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Truy vấn để lấy thông tin điểm chi tiết của học sinh
                string query = $@"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY DS.LoaiDiem ASC) AS STT,
                DS.HocKy AS HocKy,
                M.TenMon AS TenMon,
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Miệng' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemMieng,
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'15 phút' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS Diem15Phut,
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemGiuaKy,
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemCuoiKy
            FROM DiemSo DS
            INNER JOIN MonHoc M ON DS.MaMon = M.MaMon
            WHERE DS.MaHS = {maHS} AND DS.MaMon = {maMon} AND DS.MaGV = {maGV} AND DS.HocKy = {hocKy}
            GROUP BY DS.HocKy, M.TenMon, DS.LoaiDiem";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin điểm của học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemChiTietHocSinh.DataSource = null;
                    return;
                }

                // Bind data to DataGridView
                dgvDiemChiTietHocSinh.AutoGenerateColumns = false;
                dgvDiemChiTietHocSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Tìm kiếm trong dgvDanhSachHocSinh
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
                {
                    if (row.Cells["STT"].Value != null && int.Parse(row.Cells["STT"].Value.ToString()) == stt)
                    {
                        // Điền tên học sinh vào textbox
                        string hoTen = row.Cells["HoTen"].Value.ToString();
                        hoTenTxt.Text = hoTen;

                        // Truy vấn để lấy mã học sinh từ tên
                        string query = $@"
                            SELECT MaHS
                            FROM HocSinh
                            WHERE HoTen = N'{hoTen}'";

                        object maHSObj = db.ExecuteScalar(query);

                        if (maHSObj == null)
                        {
                            MessageBox.Show("Không tìm thấy học sinh với tên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        int maHS = Convert.ToInt32(maHSObj);

                        // Tải thông tin điểm chi tiết của học sinh
                        LoadDiemHS(maHS);
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

        //private void addBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Kiểm tra các trường đầu vào
        //        if (string.IsNullOrWhiteSpace(sttTxt.Text) || string.IsNullOrWhiteSpace(hoTenTxt.Text) ||
        //            string.IsNullOrWhiteSpace(loaiDiemCmb.Text) || string.IsNullOrWhiteSpace(diemTxt.Text) ||
        //            string.IsNullOrWhiteSpace(cmbHocKi.Text))
        //        {
        //            MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (!int.TryParse(sttTxt.Text, out int stt))
        //        {
        //            MessageBox.Show("STT phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        string loaiDiem = loaiDiemCmb.Text;
        //        if (!float.TryParse(diemTxt.Text, out float diem))
        //        {
        //            MessageBox.Show("Điểm phải là số thực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Chuyển đổi giá trị học kỳ từ "Kỳ 1", "Kỳ 2" thành số nguyên
        //        string hocKyText = cmbHocKi.Text;
        //        if (!hocKyText.StartsWith("Kỳ") || !int.TryParse(hocKyText.Replace("Kỳ ", ""), out int hocKy))
        //        {
        //            MessageBox.Show("Học kỳ không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Kiểm tra giá trị điểm hợp lệ
        //        if (diem < 0 || diem > 10)
        //        {
        //            MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Lấy mã học sinh từ Họ Tên
        //        string layMaHS = $@"
        //    SELECT MaHS
        //    FROM HocSinh
        //    WHERE HoTen = N'{hoTenTxt.Text}'";

        //        object maHSObj = db.ExecuteScalar(layMaHS);
        //        if (maHSObj == null)
        //        {
        //            MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        int maHS = Convert.ToInt32(maHSObj);

        //        // Thêm điểm mới
        //        string themMaxMaDiem = "SELECT ISNULL(MAX(MaDiem), 0) + 1 FROM DiemSo";
        //        int maDiemMoi = Convert.ToInt32(db.ExecuteScalar(themMaxMaDiem));

        //        string themDiem = $@"
        //    INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem)
        //    VALUES ({maDiemMoi}, {maHS}, {maMon}, {maGV}, {hocKy}, N'{loaiDiem}', {diem})";

        //        bool daThem = db.ExecuteNonQuery(themDiem);

        //        if (daThem)
        //        {
        //            MessageBox.Show("Thêm điểm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm điểm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        // Tải lại danh sách điểm chi tiết của học sinh
        //        LoadDiemHS(maHS);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường đầu vào
                if (string.IsNullOrWhiteSpace(sttTxt.Text) || string.IsNullOrWhiteSpace(hoTenTxt.Text) ||
                    string.IsNullOrWhiteSpace(loaiDiemCmb.Text) || string.IsNullOrWhiteSpace(diemTxt.Text) ||
                    string.IsNullOrWhiteSpace(cmbHocKi.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(sttTxt.Text, out int stt))
                {
                    MessageBox.Show("STT phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string loaiDiem = loaiDiemCmb.Text;
                if (!float.TryParse(diemTxt.Text, out float diem))
                {
                    MessageBox.Show("Điểm phải là số thực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi giá trị học kỳ từ "Kỳ 1", "Kỳ 2" thành số nguyên
                string hocKyText = cmbHocKi.Text;
                if (!hocKyText.StartsWith("Kỳ") || !int.TryParse(hocKyText.Replace("Kỳ ", ""), out int hocKy))
                {
                    MessageBox.Show("Học kỳ không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá trị điểm hợp lệ
                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã học sinh từ Họ Tên
                string layMaHS = $@"
            SELECT MaHS
            FROM HocSinh
            WHERE HoTen = N'{hoTenTxt.Text}'";

                object maHSObj = db.ExecuteScalar(layMaHS);
                if (maHSObj == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maHS = Convert.ToInt32(maHSObj);

                // Giới hạn số lượng điểm cho từng loại
                int maxSoLuong = 0;
                switch (loaiDiem)
                {
                    case "Miệng":
                        maxSoLuong = 4;
                        break;
                    case "15 phút":
                        maxSoLuong = 3;
                        break;
                    case "Giữa kỳ":
                        maxSoLuong = 1;
                        break;
                    case "Cuối kỳ":
                        maxSoLuong = 1;
                        break;
                    default:
                        maxSoLuong = 0;
                        break;
                }

                string countQuery = $@"
            SELECT COUNT(*) FROM DiemSo
            WHERE MaHS = {maHS} AND MaMon = {maMon} AND MaGV = {maGV} AND HocKy = {hocKy} AND LoaiDiem = N'{loaiDiem}'";
                int soLuongHienTai = Convert.ToInt32(db.ExecuteScalar(countQuery));

                if (soLuongHienTai >= maxSoLuong)
                {
                    MessageBox.Show($"Đã đạt số lượng điểm tối đa cho loại điểm \"{loaiDiem}\" (tối đa {maxSoLuong}).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm điểm mới
                string themMaxMaDiem = "SELECT ISNULL(MAX(MaDiem), 0) + 1 FROM DiemSo";
                int maDiemMoi = Convert.ToInt32(db.ExecuteScalar(themMaxMaDiem));

                string themDiem = $@"
            INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem)
            VALUES ({maDiemMoi}, {maHS}, {maMon}, {maGV}, {hocKy}, N'{loaiDiem}', {diem})";

                bool daThem = db.ExecuteNonQuery(themDiem);

                if (daThem)
                {
                    MessageBox.Show("Thêm điểm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Tải lại danh sách điểm chi tiết của học sinh
                LoadDiemHS(maHS);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
    }
}
