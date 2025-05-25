using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;
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
    public partial class ucQuanLyLop_GVCN : UserControl
    {
        private readonly DatabaseHelper db = new DatabaseHelper();
        private int maGVChuNhiem;
        private int selectedMaDon = 0;
        public ucQuanLyLop_GVCN(int maGVChuNhiem)
        {
            InitializeComponent();
            this.maGVChuNhiem = maGVChuNhiem;
            LoadDanhSachHS();
            // Mặc định hiển thị thời khóa biểu của tuần hiện tại
            ngayChonTKBDTP.Value = DateTime.Today;
            LoadThoiKhoaBieuLop();
            tabQuanLy.SelectedIndexChanged += tabQuanLy_SelectedIndexChanged;
        }

        /// <summary>
        /// Quản lý việc chuyển TAB
        /// </summary>
        private void tabQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tab hiện tại
            var selectedTab = tabQuanLy.SelectedTab;

            if (selectedTab == null) return;

            switch (selectedTab.Name)
            {
                case "tabDanhSachHocSinh": // Tên tab "Danh sách học sinh"
                    LoadDanhSachHS();
                    break;
                case "tabDonNghi": // Tên tab "Đơn nghỉ"
                    LoadDonNghi();
                    break;
                case "tabDiemDanh": // Tên tab "Điểm danh"
                    chonNgayDTP.Value = DateTime.Today; // Đặt ngày mặc định là hôm nay
                    LoadDanhSachCoMat(DateTime.Today); // Tải danh sách điểm danh của ngày hôm nay
                    break;
                case "tabThoiKhoaBieu": // Tên tab "Thời khóa biểu"
                    LoadThoiKhoaBieuLop();
                    break;
                case "tabDiemSo": // Tên tab "Điểm số"
                    LoadDiemHS();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Xem Danh Sách Học Sinh Của GVCN
        /// </summary>
        private void LoadDanhSachHS()
        {
            try
            {
                // Truy vấn danh sách học sinh trong lớp của GVCN với thông tin chi tiết
                string query = $@"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STT, -- Tự đánh số thứ tự
                        hs.HoTen,
                        CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh,
                        hs.GioiTinh,
                        hs.MaDinhDanh,
                        hs.DanToc,
                        hs.DiaChiThuongTru,
                        hs.TinhThanh,
                        hs.SoDienThoai AS SDTHocSinh,
                        ph.HoTenCha,
                        ph.SoDienThoaiCha,
                        ph.HoTenMe,
                        ph.SoDienThoaiMe
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    LEFT JOIN PhuHuynh ph ON hs.MaHS = ph.MaHS
                    WHERE lh.MaGVChuNhiem = {maGVChuNhiem}
                    ORDER BY hs.HoTen";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    dgvHocSinh.AutoGenerateColumns = false;
                    dgvHocSinh.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có học sinh nào trong lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHocSinh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin học sinh từ hàng được chọn
                DataGridViewRow row = dgvHocSinh.Rows[e.RowIndex];

                txtSTT.Text = row.Cells["STT"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtNgaySinh.Text = row.Cells["NgaySinh"].Value?.ToString();
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtMaDinhDanh.Text = row.Cells["MaDinhDanh"].Value?.ToString();
                txtDanToc.Text = row.Cells["DanToc"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChiThuongTru"].Value?.ToString();
                txtTinhThanh.Text = row.Cells["TinhThanh"].Value?.ToString();
                txtSDT.Text = row.Cells["SDTHS"].Value?.ToString();
                txtTenCha.Text = row.Cells["HoTenCha"].Value?.ToString();
                txtSDTCha.Text = row.Cells["SoDienThoaiCha"].Value?.ToString();
                txtTenMe.Text = row.Cells["Me"].Value?.ToString();
                txtSDTMe.Text = row.Cells["SoDienThoaiMe"].Value?.ToString();
            }
        }

        /// <summary>
        /// Duyệt đơn nghỉ
        /// </summary>
        private void LoadDonNghi()
        {
            try
            {
                string query = $@"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY dn.MaDon) AS STTDonNghi,
                        hs.HoTen AS HoTenDonNghi,
                        dn.LyDo,
                        dn.NgayNghi,
                        dn.TrangThai,
                        dn.MaDon,
                        hs.MaLop
                    FROM DonXinNghi dn
                    INNER JOIN HocSinh hs ON dn.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    WHERE dn.TrangThai = N'Chờ duyệt'
                    AND lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có đơn nghỉ nào cần duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDonNghi.DataSource = null;
                    return;
                }

                dgvDonNghi.AutoGenerateColumns = false;
                dgvDonNghi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaDon == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đơn nghỉ để phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật trạng thái đơn nghỉ
                string updateQuery = $@"
                    UPDATE DonXinNghi
                    SET TrangThai = N'Đã duyệt'
                    WHERE MaDon = {selectedMaDon}";

                db.ExecuteNonQuery(updateQuery);

                // Lấy thông tin học sinh và ngày nghỉ
                string fetchQuery = $@"
                    SELECT MaHS, NgayNghi
                    FROM DonXinNghi
                    WHERE MaDon = {selectedMaDon}";

                DataTable dt = db.ExecuteQuery(fetchQuery);
                if (dt.Rows.Count > 0)
                {
                    int maHS = Convert.ToInt32(dt.Rows[0]["MaHS"]);
                    DateTime ngayNghi = Convert.ToDateTime(dt.Rows[0]["NgayNghi"]);

                    // Cập nhật trạng thái "Vắng có phép" trong bảng DiemDanh
                    string insertOrUpdateQuery = $@"
                        IF EXISTS (
                            SELECT 1 FROM DiemDanh 
                            WHERE MaHS = {maHS} AND Ngay = '{ngayNghi:yyyy-MM-dd}'
                        )
                        BEGIN
                            UPDATE DiemDanh
                            SET TrangThai = N'Vắng có phép'
                            WHERE MaHS = {maHS} AND Ngay = '{ngayNghi:yyyy-MM-dd}'
                        END
                        ELSE
                        BEGIN
                            INSERT INTO DiemDanh (MaHS, MaLop, Ngay, TrangThai, GhiChu)
                            VALUES ({maHS}, (SELECT MaLop FROM HocSinh WHERE MaHS = {maHS}), '{ngayNghi:yyyy-MM-dd}', N'Vắng có phép', N'Đơn nghỉ đã duyệt')
                        END";

                    db.ExecuteNonQuery(insertOrUpdateQuery);
                }
                MessageBox.Show("Đơn nghỉ đã được phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonNghi();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phê duyệt đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaDon == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đơn nghỉ để từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật trạng thái đơn nghỉ
                string updateQuery = $@"
                    UPDATE DonXinNghi
                    SET TrangThai = N'Từ chối'
                    WHERE MaDon = {selectedMaDon}";

                db.ExecuteNonQuery(updateQuery);
                MessageBox.Show("Đơn nghỉ đã bị từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonNghi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi từ chối đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonNghi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonNghi.Rows[e.RowIndex];

                txtDonNghiSTT.Text = row.Cells["STTDonNghi"].Value.ToString();
                txtDonNghiHoTen.Text = row.Cells["HoTenDonNghi"].Value.ToString();
                txtDonNghiNgay.Text = Convert.ToDateTime(row.Cells["NgayNghi"].Value).ToString("dd/MM/yyyy");
                txtDonNghiLyDo.Text = row.Cells["LyDo"].Value.ToString();

                // Lưu mã đơn để xử lý duyệt hoặc từ chối
                selectedMaDon = Convert.ToInt32(row.Cells["MaDon"].Value);
            }
        }

        private void dgvDonNghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// Điểm danh học sinh
        /// </summary>
        private void LoadDanhSachCoMat(DateTime selectedDate)
        {

            try
            {
                // Truy vấn danh sách học sinh và trạng thái điểm danh theo ngày
                string query = $@"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STTDiemDanh,
                        hs.MaHS,
                        hs.HoTen AS HoTenDiemDanh,
                        ISNULL(dd.TrangThai, N'Có mặt') AS TrangThaiDiemDanh
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    LEFT JOIN DiemDanh dd 
                        ON hs.MaHS = dd.MaHS AND dd.Ngay = '{selectedDate:yyyy-MM-dd}'
                    WHERE lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Tự động thêm trạng thái "Có mặt" nếu chưa có trong bảng DiemDanh
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TrangThaiDiemDanh"].ToString() == "Có mặt")
                        {
                            int maHS = Convert.ToInt32(row["MaHS"]);
                            string insertQuery = $@"
                                IF NOT EXISTS (
                                    SELECT 1 FROM DiemDanh 
                                    WHERE MaHS = {maHS} AND Ngay = '{selectedDate:yyyy-MM-dd}'
                                )
                                BEGIN
                                    INSERT INTO DiemDanh (MaHS, MaLop, Ngay, TrangThai)
                                    VALUES ({maHS}, (SELECT MaLop FROM HocSinh WHERE MaHS = {maHS}), '{selectedDate:yyyy-MM-dd}', N'Có mặt')
                                END";
                            db.ExecuteNonQuery(insertQuery);
                        }
                    }

                    dgvDiemDanh.AutoGenerateColumns = false;
                    dgvDiemDanh.DataSource = dt;

                    DiemDanhSiSoCoMat(dt);
                }
                else
                {
                    MessageBox.Show("Không có học sinh nào trong lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điểm danh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DiemDanhSiSoCoMat(DataTable dt)
        {
            int totalPresent = dt.AsEnumerable().Count(row => row["TrangThaiDiemDanh"].ToString() == "Có mặt");
            int totalAbsent = dt.AsEnumerable().Count(row => row["TrangThaiDiemDanh"].ToString() == "Vắng có phép");

            lblCoMat.Text = $"Có mặt: {totalPresent}";
            lblVang.Text = $"Vắng: {totalAbsent}";
        }
        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = chonNgayDTP.Value; // Lấy ngày được chọn từ DateTimePicker
            LoadDanhSachCoMat(selectedDate); // Gọi phương thức để tải danh sách điểm danh
        }

        /// <summary>
        /// Thời khóa biểu của lớp chủ nhiệm
        /// </summary>

        private void LoadThoiKhoaBieuLop()
        {
            try
            {
                // Lấy ngày được chọn từ DateTimePicker
                DateTime selectedDate = ngayChonTKBDTP.Value;

                // Tính ngày bắt đầu tuần (Thứ Hai) và ngày kết thúc tuần (Chủ Nhật)
                DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1); // Thứ Hai
                DateTime endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật

                // Truy vấn thời khóa biểu của lớp chủ nhiệm
                string query = $@"
                    SELECT 
                        ThoiKhoaBieu.Thu,
                        ThoiKhoaBieu.Tiet,
                        MonHoc.TenMon,
                        COUNT(ThoiKhoaBieu.Tiet) AS SoTiet
                    FROM ThoiKhoaBieu
                    INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
                    INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
                    WHERE LopHoc.MaGVChuNhiem = {maGVChuNhiem}
                      AND ThoiKhoaBieu.Ngay BETWEEN '{startOfWeek:yyyy-MM-dd}' AND '{endOfWeek:yyyy-MM-dd}'
                    GROUP BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet, MonHoc.TenMon
                    ORDER BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet";

                DataTable dt = db.ExecuteQuery(query);
                // Xóa các hàng cũ trong DataGridView
                dgvThoiKhoaBieu.Rows.Clear();

                // Tạo dictionary để lưu dữ liệu thời khóa biểu theo thứ
                var scheduleData = new Dictionary<int, List<string>>();
                for (int i = 2; i <= 8; i++) // Khởi tạo cho các ngày từ Thứ Hai (2) đến Chủ Nhật (8)
                {
                    scheduleData[i] = new List<string>();
                }

                // Điền dữ liệu vào dictionary
                foreach (DataRow row in dt.Rows)
                {
                    int thu = Convert.ToInt32(row["Thu"]); // Thứ trong tuần
                    string tiet = row["Tiet"].ToString(); // Tiết học
                    string tenMon = row["TenMon"].ToString(); // Tên môn học

                    // Định dạng thông tin thời khóa biểu
                    string scheduleEntry = $"Tiết: {tiet}\nMôn: {tenMon}";
                    scheduleData[thu].Add(scheduleEntry);
                }

                // Tìm số hàng tối đa cần thiết
                int maxRows = scheduleData.Values.Max(list => list.Count);

                // Thêm hàng vào DataGridView
                for (int i = 0; i < maxRows; i++)
                {
                    dgvThoiKhoaBieu.Rows.Add();
                }

                // Điền dữ liệu vào DataGridView
                for (int thu = 2; thu <= 8; thu++) // Từ Thứ Hai (2) đến Chủ Nhật (8)
                {
                    int columnIndex = thu - 2; // Map "2 = Thứ Hai" thành cột 0
                    for (int rowIndex = 0; rowIndex < scheduleData[thu].Count; rowIndex++)
                    {
                        dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = scheduleData[thu][rowIndex];
                    }
                }

                // Tính tổng số tiết trong tuần và số tiết mỗi môn
                var subjectSummary = dt.AsEnumerable()
                    .GroupBy(row => row["TenMon"].ToString())
                    .Select(group => new
                    {
                        TenMon = group.Key,
                        SoTiet = group.Sum(row => Convert.ToInt32(row["SoTiet"]))
                    });

                // Hiển thị tổng số tiết trong tuần và số tiết mỗi môn
                StringBuilder summaryText = new StringBuilder();
                int totalPeriods = 0;
                foreach (var subject in subjectSummary)
                {
                    summaryText.AppendLine($"{subject.SoTiet} Tiết {subject.TenMon}");
                    totalPeriods += subject.SoTiet;
                }
                thongKeSoTietTxt.Text = summaryText.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thời khóa biểu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadThoiKhoaBieuLop();
        }

        private void ngayChonTKBDTP_ValueChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieuLop();
        }

        /// <summary>
        /// Xem điểm số của học sinh
        /// </summary>
        private void LoadDiemHS(int? maMon = null)
        {
            try
            {
                // Load danh sách môn học nếu combobox chưa có dữ liệu
                if (monCmb.Items.Count == 0)
                {
                    LoadMonHoc();
                }

                string query = $@"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STTDiemSo,
                hs.HoTen AS HoTenDiemSo,
                STRING_AGG(CASE WHEN ds.LoaiDiem = N'Miệng' THEN CAST(ds.Diem AS NVARCHAR) ELSE NULL END, ', ') AS DiemMieng,
                STRING_AGG(CASE WHEN ds.LoaiDiem = N'15 phút' THEN CAST(ds.Diem AS NVARCHAR) ELSE NULL END, ', ') AS Diem15Phut,
                STRING_AGG(CASE WHEN ds.LoaiDiem = N'Giữa kỳ' THEN CAST(ds.Diem AS NVARCHAR) ELSE NULL END, ', ') AS DiemGiuaKy,
                STRING_AGG(CASE WHEN ds.LoaiDiem = N'Cuối kỳ' THEN CAST(ds.Diem AS NVARCHAR) ELSE NULL END, ', ') AS DiemCuoiKy,
                ISNULL(ROUND(AVG(ds.Diem), 2), 0) AS DiemTrungBinh
            FROM HocSinh hs
            INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
            LEFT JOIN DiemSo ds ON hs.MaHS = ds.MaHS";

                // Thêm điều kiện lọc theo môn học nếu được chọn
                if (maMon.HasValue && maMon.Value > 0)
                {
                    query += $" AND ds.MaMon = {maMon.Value}";
                }

                query += $@" WHERE lh.MaGVChuNhiem = {maGVChuNhiem}
            GROUP BY hs.HoTen";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    dgvDiemSo.AutoGenerateColumns = false;
                    dgvDiemSo.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có điểm số nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemSo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điểm số: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách môn học cho combobox
        /// </summary>
        private void LoadMonHoc()
        {
            try
            {
                string query = "SELECT MaMon, TenMon FROM MonHoc ORDER BY MaMon";
                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow allSubjectsRow = dt.NewRow();
                    allSubjectsRow["MaMon"] = 0;
                    allSubjectsRow["TenMon"] = "Tất cả môn";
                    dt.Rows.InsertAt(allSubjectsRow, 0);

                    monCmb.DisplayMember = "TenMon";
                    monCmb.ValueMember = "MaMon";
                    monCmb.DataSource = dt;

                    monCmb.SelectedIndexChanged += monCmb_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monCmb.SelectedValue != null)
            {
                int maMon = Convert.ToInt32(monCmb.SelectedValue);
                // Nếu chọn "Tất cả môn", truyền null để hiển thị tất cả
                LoadDiemHS(maMon == 0 ? (int?)null : maMon);
            }
        }

        private void dgvDiemSo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy hàng được chọn
                    DataGridViewRow row = dgvDiemSo.Rows[e.RowIndex];

                    // Hiển thị thông tin cơ bản
                    txtSTTDiemSo.Text = row.Cells["STTDiemSo"].Value?.ToString();
                    txtHoTenDiemSo.Text = row.Cells["HoTenDiemSo"].Value?.ToString();

                    // Tính trung bình cho các cột nhiều điểm
                    txtDiemMieng.Text = TinhTrungBinh(row.Cells["DiemMieng"].Value?.ToString());
                    txtDiem15Phut.Text = TinhTrungBinh(row.Cells["Diem15Phut"].Value?.ToString());
                    txtDiemGiuaKy.Text = TinhTrungBinh(row.Cells["DiemGiuaKy"].Value?.ToString());
                    txtDiemCuoiKy.Text = TinhTrungBinh(row.Cells["DiemCuoiKy"].Value?.ToString());

                    // Hiển thị điểm trung bình
                    txtDiemTB.Text = row.Cells["DiemTrungBinh"].Value?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm tính trung bình từ chuỗi các điểm
        private string TinhTrungBinh(string scores)
        {
            if (string.IsNullOrEmpty(scores)) return "0";

            try
            {
                var scoreList = scores.Split(',')
                                      .Select(s => float.Parse(s.Trim()))
                                      .ToList();

                if (scoreList.Count == 0) return "0";

                float average = scoreList.Average();
                return average.ToString("0.00"); // Hiển thị 2 chữ số thập phân
            }
            catch
            {
                return "0"; // Trả về 0 nếu có lỗi
            }
        }


    }
}
