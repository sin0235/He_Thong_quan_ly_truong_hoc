using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyThoiKhoaBieu : UserControl
    {
        DatabaseHelper db;

        public ucQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void LoadDanhSachLop()
        {
            string query = "SELECT MaLop, TenLop FROM LopHoc";
            DataTable dt = db.ExecuteQuery(query);
            cmbChonLop.DataSource = dt;
            cmbChonLop.DisplayMember = "TenLop";
            cmbChonLop.ValueMember = "MaLop";
            
            // Đặt lớp đầu tiên là lớp mặc định nếu có dữ liệu
            if (dt.Rows.Count > 0)
            {
                cmbChonLop.SelectedIndex = 0;
            }
        }

        private void ucQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachLop();
            dtpNgay.Value = DateTime.Today;
            dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void CmbChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void DtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void LoadThoiKhoaBieu()
        {
            if (cmbChonLop.SelectedValue == null)
            {
                dgvThoiKhoaBieu.Rows.Clear();
                return;
            }

            int maLop;
            if (cmbChonLop.SelectedValue is DataRowView rowView)
            {
                maLop = Convert.ToInt32(rowView["MaLop"]);
            }
            else
            {
                maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            }

            DateTime selectedDate = dtpNgay.Value;

            // Tính ngày bắt đầu tuần (thứ 2) và ngày kết thúc tuần (chủ nhật)
            DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1);
            if (selectedDate.DayOfWeek == DayOfWeek.Sunday)
                startOfWeek = selectedDate.AddDays(-6); // Đảm bảo chủ nhật thuộc về tuần hiện tại
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Cập nhật tiêu đề cột với ngày tương ứng
            for (int i = 0; i < dgvThoiKhoaBieu.Columns.Count; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                string thu = i == 6 ? "Chủ nhật" : $"Thứ {i + 2}";
                dgvThoiKhoaBieu.Columns[i].HeaderText = $"{thu}\r\n{currentDay:dd/MM/yyyy}";
                dgvThoiKhoaBieu.Columns[i].Tag = currentDay;  // Lưu ngày vào Tag để tham chiếu sau này
            }

            // Truy vấn lấy dữ liệu thời khóa biểu
            string query = @"
            SELECT Ngay, Thu, Tiet, TenMon, HoTen AS TenGiaoVien
            FROM ThoiKhoaBieu
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            WHERE ThoiKhoaBieu.MaLop = @MaLop AND Ngay BETWEEN @StartOfWeek AND @EndOfWeek
            ORDER BY Ngay, Thu, Tiet";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaLop", maLop },
                { "@StartOfWeek", startOfWeek },
                { "@EndOfWeek", endOfWeek }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            dgvThoiKhoaBieu.Rows.Clear();

            // Tổ chức dữ liệu theo ngày và tiết học
            Dictionary<DateTime, Dictionary<string, string>> organizedData = new Dictionary<DateTime, Dictionary<string, string>>();

            // Khởi tạo dictionary cho mỗi ngày trong tuần
            for (int i = 0; i < 7; i++)
            {
                DateTime day = startOfWeek.AddDays(i);
                organizedData[day.Date] = new Dictionary<string, string>();
            }

            // Gom nhóm dữ liệu theo ngày và tiết
            foreach (DataRow row in dt.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]).Date;
                string tiet = row["Tiet"].ToString();
                string monGV = $"Môn: {row["TenMon"]}\nGV: {row["TenGiaoVien"]}";

                if (organizedData.ContainsKey(ngay))
                {
                    organizedData[ngay][tiet] = monGV;
                }
            }

            int maxRowsNeeded = 0;
            foreach (var dayData in organizedData.Values)
            {
                maxRowsNeeded = Math.Max(maxRowsNeeded, dayData.Count);
            }

            while (dgvThoiKhoaBieu.Rows.Count < maxRowsNeeded)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            for (int columnIndex = 0; columnIndex < dgvThoiKhoaBieu.Columns.Count; columnIndex++)
            {
                DateTime currentDay = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;

                if (organizedData.ContainsKey(currentDay.Date))
                {
                    var dayData = organizedData[currentDay.Date];
                    int rowIndex = 0;

                    foreach (var tietPair in dayData)
                    {
                        string tiet = tietPair.Key;
                        string monGV = tietPair.Value;

                        if (rowIndex < dgvThoiKhoaBieu.Rows.Count)
                        {
                            dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = $"Tiết: {tiet}\n{monGV}";
                            rowIndex++;
                        }
                    }
                }
            }

            while (dgvThoiKhoaBieu.Rows.Count > maxRowsNeeded && maxRowsNeeded > 0)
            {
                dgvThoiKhoaBieu.Rows.RemoveAt(dgvThoiKhoaBieu.Rows.Count - 1);
            }

            if (dgvThoiKhoaBieu.Rows.Count == 0)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            dgvThoiKhoaBieu.AllowUserToAddRows = false;
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi thêm lịch học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            string tenLop = cmbChonLop.Text;
            DateTime selectedDate = dtpNgay.Value;

            if (dgvThoiKhoaBieu.SelectedCells.Count > 0)
            {
                int columnIndex = dgvThoiKhoaBieu.SelectedCells[0].ColumnIndex;

                string headerText = dgvThoiKhoaBieu.Columns[columnIndex].HeaderText;
                string[] headerParts = headerText.Split(new[] { "\r\n" }, StringSplitOptions.None);

                if (headerParts.Length > 1)
                {
                    if (DateTime.TryParseExact(headerParts[1], "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        selectedDate = date;
                    }
                }

                // Hoặc lấy từ Tag của cột nếu đã thiết lập 
                if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                    dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
                {
                    selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
                }
            }

            frmQuanLyThoiKhoaBieu frm = new frmQuanLyThoiKhoaBieu(maLop, tenLop, selectedDate);
            frm.Text = "Thêm lịch học";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string queryLatestSchedule = @"
                    SELECT TOP 1 
                        Thu, 
                        Tiet, 
                        MonHoc.TenMon,
                        GiaoVien.HoTen AS TenGiaoVien,
                        LopHoc.TenLop
                    FROM ThoiKhoaBieu
                    INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
                    INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
                    INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
                    WHERE ThoiKhoaBieu.MaLop = @MaLop
                    ORDER BY MaTKB DESC";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaLop", maLop }
                    };

                    DataTable latestSchedule = db.ExecuteQuery(queryLatestSchedule, parameters);

                    if (latestSchedule != null && latestSchedule.Rows.Count > 0)
                    {
                        string thu = latestSchedule.Rows[0]["Thu"].ToString();
                        string tiet = latestSchedule.Rows[0]["Tiet"].ToString();
                        string tenMon = latestSchedule.Rows[0]["TenMon"].ToString();
                        string tenGiaoVien = latestSchedule.Rows[0]["TenGiaoVien"].ToString();
                        string tenLopMoi = latestSchedule.Rows[0]["TenLop"].ToString();

                        string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 2";
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                        string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                        string hanhDong = $"Thêm thời khóa biểu của lớp {tenLopMoi} vào ngày {selectedDate:dd/MM/yyyy} với môn học {tenMon} của giáo viên {tenGiaoVien} tiết {tiet}";

                        string insertNhatKy = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                        
                        Dictionary<string, object> pr = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong }
                        };

                        db.ExecuteNonQuery(insertNhatKy, pr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ghi nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadThoiKhoaBieu();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Thay vì đặt cmbChonLop.SelectedIndex = -1, load lại danh sách lớp và chọn lớp đầu tiên
            LoadDanhSachLop();
            dtpNgay.Value = DateTime.Today;
            LoadThoiKhoaBieu();
            MessageBox.Show("Đã làm mới cửa sổ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetMaTKBFromDatabase(int maLop, DateTime ngay, string tiet)
        {
            try
            {
                string query = @"
                SELECT MaTKB 
                FROM ThoiKhoaBieu 
                WHERE MaLop = @MaLop 
                  AND CONVERT(DATE, Ngay) = CONVERT(DATE, @Ngay) 
                  AND Tiet = @Tiet";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@Ngay", ngay },
                    { "@Tiet", tiet }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["MaTKB"]);
                }

                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn MaTKB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi sửa thời khóa biểu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvThoiKhoaBieu.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một ô trong thời khóa biểu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewCell selectedCell = dgvThoiKhoaBieu.SelectedCells[0];
            int columnIndex = selectedCell.ColumnIndex;
            int rowIndex = selectedCell.RowIndex;

            if (selectedCell.Value == null || string.IsNullOrWhiteSpace(selectedCell.Value.ToString()))
            {
                MessageBox.Show("Ô được chọn không có dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate;
            if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
            {
                selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
            }
            else
            {
                selectedDate = DateTime.Today;
                MessageBox.Show("Không thể xác định ngày từ cột. Sử dụng ngày hiện tại thay thế.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                string[] cellData = selectedCell.Value.ToString().Split('\n');
                string tiet = cellData[0].Replace("Tiết: ", "").Trim();
                string mon = cellData.Length > 1 ? cellData[1].Replace("Môn: ", "").Trim() : "";
                string giaoVien = cellData.Length > 2 ? cellData[2].Replace("GV: ", "").Trim() : "";

                int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
                int maTKB = GetMaTKBFromDatabase(maLop, selectedDate, tiet);

                if (maTKB <= 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu thời khóa biểu để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tenLop = cmbChonLop.Text;
                string monHocBanDau = mon;
                string giaoVienBanDau = giaoVien;

                string queryOldData = @"
                SELECT m.MaMon, m.TenMon, g.MaGV, g.HoTen, t.Ngay, t.Thu, t.Tiet
                FROM ThoiKhoaBieu t
                INNER JOIN MonHoc m ON t.MaMon = m.MaMon
                INNER JOIN GiaoVien g ON t.MaGV = g.MaGV
                WHERE t.MaTKB = @MaTKB";

                Dictionary<string, object> parametersOld = new Dictionary<string, object>
                {
                    { "@MaTKB", maTKB }
                };

                DataTable dtOldData = db.ExecuteQuery(queryOldData, parametersOld);

                int maMon = 0;
                int maGV = 0;
                string ngayBanDau = "";
                string thuBanDau = "";
                string tietBanDau = "";

                if (dtOldData != null && dtOldData.Rows.Count > 0)
                {
                    maMon = Convert.ToInt32(dtOldData.Rows[0]["MaMon"]);
                    maGV = Convert.ToInt32(dtOldData.Rows[0]["MaGV"]);
                    monHocBanDau = dtOldData.Rows[0]["TenMon"].ToString();
                    giaoVienBanDau = dtOldData.Rows[0]["HoTen"].ToString();
                    ngayBanDau = Convert.ToDateTime(dtOldData.Rows[0]["Ngay"]).ToString("dd/MM/yyyy");
                    thuBanDau = dtOldData.Rows[0]["Thu"].ToString();
                    tietBanDau = dtOldData.Rows[0]["Tiet"].ToString();
                }

                frmQuanLyThoiKhoaBieu frm = new frmQuanLyThoiKhoaBieu(Convert.ToInt32(cmbChonLop.SelectedValue), cmbChonLop.Text, selectedDate)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = "Sửa thời khóa biểu"
                };

                try
                {
                    if (frm.Controls["cmbMonHoc"] != null)
                        frm.Controls["cmbMonHoc"].Tag = mon;

                    if (frm.Controls["cmbGiaoVien"] != null)
                        frm.Controls["cmbGiaoVien"].Tag = giaoVien;

                    if (frm.Controls["txtTietHoc"] != null)
                        frm.Controls["txtTietHoc"].Text = tiet;

                    frm.Tag = maTKB;

                    if (frm.Controls["btnXacNhan"] != null)
                        frm.Controls["btnXacNhan"].Text = "Cập nhật";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi truyền thông tin vào form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string queryUpdatedData = @"
                    SELECT m.TenMon, g.HoTen, t.Ngay, t.Thu, t.Tiet
                    FROM ThoiKhoaBieu t
                    INNER JOIN MonHoc m ON t.MaMon = m.MaMon
                    INNER JOIN GiaoVien g ON t.MaGV = g.MaGV
                    WHERE t.MaTKB = @MaTKB";

                    Dictionary<string, object> parametersUpdated = new Dictionary<string, object>
                    {
                        { "@MaTKB", maTKB }
                    };

                    DataTable dtUpdatedData = db.ExecuteQuery(queryUpdatedData, parametersUpdated);

                    if (dtUpdatedData != null && dtUpdatedData.Rows.Count > 0)
                    {
                        string monHocMoi = dtUpdatedData.Rows[0]["TenMon"].ToString();
                        string giaoVienMoi = dtUpdatedData.Rows[0]["HoTen"].ToString();
                        string ngayMoi = Convert.ToDateTime(dtUpdatedData.Rows[0]["Ngay"]).ToString("dd/MM/yyyy");
                        string thuMoi = dtUpdatedData.Rows[0]["Thu"].ToString();
                        string tietMoi = dtUpdatedData.Rows[0]["Tiet"].ToString();

                        List<string> changes = new List<string>();

                        if (monHocBanDau != monHocMoi)
                            changes.Add($"môn học từ {monHocBanDau} thành {monHocMoi}");

                        if (giaoVienBanDau != giaoVienMoi)
                            changes.Add($"giáo viên từ {giaoVienBanDau} thành {giaoVienMoi}");

                        if (ngayBanDau != ngayMoi)
                            changes.Add($"ngày từ {ngayBanDau} thành {ngayMoi}");

                        if (tietBanDau != tietMoi)
                            changes.Add($"tiết từ {tietBanDau} thành {tietMoi}");

                        string thayDoiText = string.Join(", ", changes);

                        string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 2";
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                        string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                        string hanhDong = $"Sửa thời khóa biểu của lớp {tenLop} ngày {ngayMoi} môn học {monHocMoi} tiết {tietMoi} của giáo viên {giaoVienMoi}: {thayDoiText}";

                        string insertNhatKy = "INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian) VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong }
                        };

                        db.ExecuteNonQuery(insertNhatKy, parameters);
                    }
                    LoadThoiKhoaBieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThoiKhoaBieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThoiKhoaBieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell selectedCell = dgvThoiKhoaBieu.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (selectedCell.Value != null && !string.IsNullOrWhiteSpace(selectedCell.Value.ToString()))
                    {
                        // Đánh dấu rằng cell đã được chọn (có thể làm nổi bật nó)
                        dgvThoiKhoaBieu.ClearSelection();
                        selectedCell.Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn ô: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbChonLop.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp trước khi xóa thời khóa biểu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvThoiKhoaBieu.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một buổi học trong thời khóa biểu để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewCell selectedCell = dgvThoiKhoaBieu.SelectedCells[0];
                int columnIndex = selectedCell.ColumnIndex;

                if (selectedCell.Value == null || string.IsNullOrWhiteSpace(selectedCell.Value.ToString()))
                {
                    MessageBox.Show("Ô được chọn không có dữ liệu để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime selectedDate;
                if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                    dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
                {
                    selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
                }
                else
                {
                    selectedDate = DateTime.Today;
                    MessageBox.Show("Không thể xác định ngày. Sử dụng ngày hiện tại thay thế.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                string[] cellData = selectedCell.Value.ToString().Split('\n');
                string tiet = cellData[0].Replace("Tiết: ", "").Trim();
                string mon = cellData.Length > 1 ? cellData[1].Replace("Môn: ", "").Trim() : "";
                string giaoVien = cellData.Length > 2 ? cellData[2].Replace("GV: ", "").Trim() : "";

                int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
                int maTKB = GetMaTKBFromDatabase(maLop, selectedDate, tiet);

                if (maTKB <= 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu thời khóa biểu để xóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa buổi học này?\nMôn: {mon}\nGiáo viên: {giaoVien}\nTiết: {tiet}\nNgày: {selectedDate:dd/MM/yyyy}",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool deleteSuccess = DeleteThoiKhoaBieu(maTKB);

                    if (deleteSuccess)
                    {
                        MessageBox.Show("Đã xóa buổi học thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadThoiKhoaBieu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa buổi học thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý xóa thời khóa biểu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DeleteThoiKhoaBieu(int maTKB)
        {
            try
            {
                string queryInfo = @"
                SELECT 
                    t.MaLop, 
                    l.TenLop, 
                    t.Ngay, 
                    m.TenMon, 
                    g.HoTen AS TenGiaoVien, 
                    t.Tiet
                FROM ThoiKhoaBieu t
                INNER JOIN LopHoc l ON t.MaLop = l.MaLop
                INNER JOIN MonHoc m ON t.MaMon = m.MaMon
                INNER JOIN GiaoVien g ON t.MaGV = g.MaGV
                WHERE t.MaTKB = @MaTKB";

                Dictionary<string, object> infoParams = new Dictionary<string, object>
                {
                    { "@MaTKB", maTKB }
                };

                DataTable infoTable = db.ExecuteQuery(queryInfo, infoParams);

                string query = "DELETE FROM ThoiKhoaBieu WHERE MaTKB = @MaTKB";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTKB", maTKB }
                };
                bool success = db.ExecuteNonQuery(query, parameters);

                if (success && infoTable != null && infoTable.Rows.Count > 0)
                {
                    DataRow info = infoTable.Rows[0];
                    string tenLop = info["TenLop"].ToString();
                    string ngay = Convert.ToDateTime(info["Ngay"]).ToString("dd/MM/yyyy");
                    string tenMon = info["TenMon"].ToString();
                    string tenGiaoVien = info["TenGiaoVien"].ToString();
                    string tiet = info["Tiet"].ToString();

                    string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 2";
                    int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                    string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                    int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                    string hanhDong = $"Xóa thời khóa biểu của lớp {tenLop} ngày {ngay} môn học {tenMon} của giáo viên {tenGiaoVien} tiết {tiet}";

                    string insertNhatKy = "INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian) VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                    Dictionary<string, object> logParams = new Dictionary<string, object>
                    {
                        { "@MaNK", maNK },
                        { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                        { "@HanhDong", hanhDong }
                    };

                    db.ExecuteNonQuery(insertNhatKy, logParams);
                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thời khóa biểu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
