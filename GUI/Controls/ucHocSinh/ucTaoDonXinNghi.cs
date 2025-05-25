using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTaoDonXinNghi : UserControl
    {
        private DatabaseHelper dbHelper;
        private int maHS = -1;
        // Khai báo class để lưu thông tin giáo viên
        private class GiaoVienInfo
        {
            public int MaGV { get; set; }
            public string HoTen { get; set; }
            public override string ToString() => HoTen;
        }

        // Event để thông báo khi đơn được gửi thành công
        public event EventHandler OnSubmitSuccess;

        // Event để thông báo khi người dùng muốn hủy
        public event EventHandler OnCancel;

        public ucTaoDonXinNghi(int M)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            maHS = M;
        }

        private void ucTaoDonXinNghi_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtpBatDau.Value = DateTime.Today;
            dtpKetThuc.Value = DateTime.Today;

            // Chọn loại đơn mặc định
            cboLoaiDon.SelectedIndex = 0;

            // Tải danh sách giáo viên
            LoadTeachers();
        }

        /// <summary>
        /// Tải danh sách giáo viên để hiển thị trong combobox
        /// </summary>
        private void LoadTeachers()
        {
            try
            {
                // Truy vấn lấy danh sách giáo viên
                string query = @"
                        SELECT MaGV, HoTen 
                        FROM GiaoVien 
                        ORDER BY HoTen";

                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Thêm option "Gửi cho giáo viên chủ nhiệm" làm mục đầu tiên
                    GiaoVienInfo gvcnOption = new GiaoVienInfo { MaGV = -1, HoTen = "GVCN" };
                    cboGiaoVien.Items.Add(gvcnOption);

                    // Thêm các giáo viên từ database
                    foreach (DataRow row in dt.Rows)
                    {
                        GiaoVienInfo gv = new GiaoVienInfo
                        {
                            MaGV = Convert.ToInt32(row["MaGV"]),
                            HoTen = row["HoTen"].ToString()
                        };

                        cboGiaoVien.Items.Add(gv);
                    }

                    // Chọn giáo viên chủ nhiệm là mặc định
                    cboGiaoVien.SelectedIndex = 0;
                }
                else
                {
                    // Nếu không tìm thấy giáo viên, hiển thị thông báo
                    MessageBox.Show("Không tìm thấy thông tin giáo viên trong hệ thống.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách giáo viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn loại đơn khác nhau
        /// </summary>
        private void cboLoaiDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiDon = cboLoaiDon.SelectedItem.ToString();
            txtTieuDe.Text = loaiDon; // Tự động điền tiêu đề theo loại đơn
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút gửi đơn
        /// </summary>
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SubmitLeaveRequest();
            }
        }

        /// <summary>
        /// Xác thực thông tin đầu vào
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra nội dung
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do nghỉ học", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            // Kiểm tra ngày bắt đầu không được là ngày trong quá khứ
            if (dtpBatDau.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không thể tạo đơn xin nghỉ cho ngày đã qua", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBatDau.Focus();
                return false;
            }

            // Kiểm tra ngày nghỉ
            if (dtpKetThuc.Value < dtpBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpKetThuc.Focus();
                return false;
            }

            // Kiểm tra đã chọn giáo viên chưa
            if (cboGiaoVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giáo viên để gửi đơn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGiaoVien.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gửi đơn xin nghỉ học
        /// </summary>
        private void SubmitLeaveRequest()
        {
            try
            {
                string lyDo = txtNoiDung.Text.Trim();
                DateTime ngayGui = DateTime.Now;

                // Lấy thông tin giáo viên được chọn
                int maGV = -1;
                if (cboGiaoVien.SelectedItem is GiaoVienInfo selectedTeacher)
                {
                    if (selectedTeacher.MaGV == -1) // Là giáo viên chủ nhiệm
                    {
                        // Lấy mã giáo viên chủ nhiệm từ lớp của học sinh
                        string gvcnQuery = @"
                                SELECT L.MaGVChuNhiem
                                FROM HocSinh HS
                                JOIN LopHoc L ON HS.MaLop = L.MaLop
                                WHERE HS.MaHS = @MaHS";

                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaHS", maHS }
                        };

                        object gvcnResult = dbHelper.ExecuteScalar(gvcnQuery, parameters);
                        if (gvcnResult != null && gvcnResult != DBNull.Value)
                        {
                            maGV = Convert.ToInt32(gvcnResult);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin giáo viên chủ nhiệm cho lớp của bạn.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else // Là giáo viên cụ thể
                    {
                        maGV = selectedTeacher.MaGV;
                    }
                }

                if (maGV == -1)
                {
                    MessageBox.Show("Không thể xác định giáo viên để gửi đơn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xử lý trường hợp xin nghỉ nhiều ngày
                if (dtpKetThuc.Value > dtpBatDau.Value)
                {
                    List<int> danhSachDonId = new List<int>();
                    DateTime ngayNghi = dtpBatDau.Value.Date;

                    while (ngayNghi <= dtpKetThuc.Value.Date)
                    {
                        // Kiểm tra xem đã có đơn cho ngày này chưa
                        if (!KiemTraDonTonTai(maHS, ngayNghi))
                        {
                            // Lấy mã đơn mới
                            int maDon = TaoMaDonXinNghi(ngayNghi);
                            if (maDon <= 0)
                            {
                                // Bỏ qua ngày này nếu không tạo được mã đơn
                                ngayNghi = ngayNghi.AddDays(1);
                                continue;
                            }

                            // Thực hiện thêm mới vào bảng DonXinNghi với MaGV được chọn
                            string query = @"
                                    INSERT INTO DonXinNghi (MaDon, MaHS, NgayGui, NgayNghi, LyDo, MaGV, TrangThai)
                                    VALUES (@MaDon, @MaHS, @NgayGui, @NgayNghi, @LyDo, @MaGV, @TrangThai);";

                            Dictionary<string, object> parameters = new Dictionary<string, object>
                            {
                                { "@MaDon", maDon },
                                { "@MaHS", maHS },
                                { "@NgayGui", ngayGui },
                                { "@NgayNghi", ngayNghi },
                                { "@LyDo", lyDo },
                                { "@MaGV", maGV },
                                { "@TrangThai", "Chờ duyệt" }
                            };

                            // Thực hiện câu lệnh SQL
                            bool success = dbHelper.ExecuteNonQuery(query, parameters);

                            if (success)
                            {
                                danhSachDonId.Add(maDon);
                            }
                        }

                        ngayNghi = ngayNghi.AddDays(1);
                    }

                    if (danhSachDonId.Count > 0)
                    {
                        // Lấy tên giáo viên
                        string teacherName = "";
                        if (cboGiaoVien.SelectedItem is GiaoVienInfo teacher)
                        {
                            teacherName = teacher.MaGV == -1 ? "GVCN" : teacher.HoTen;
                        }

                        MessageBox.Show($"Đã tạo thành công {danhSachDonId.Count} đơn xin nghỉ học từ ngày " +
                            $"{dtpBatDau.Value.ToString("dd/MM/yyyy")} đến ngày {dtpKetThuc.Value.ToString("dd/MM/yyyy")} " +
                            $"gửi đến {teacherName}!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Thông báo thành công
                        OnSubmitSuccess?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Không có đơn xin nghỉ nào được tạo! Có thể các ngày đã có đơn hoặc có lỗi xảy ra.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Trường hợp chỉ xin nghỉ 1 ngày
                    DateTime ngayNghi = dtpBatDau.Value.Date;

                    // Kiểm tra xem đã có đơn cho ngày này chưa
                    if (KiemTraDonTonTai(maHS, ngayNghi))
                    {
                        MessageBox.Show($"Đã tồn tại đơn xin nghỉ cho ngày {ngayNghi:dd/MM/yyyy}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy mã đơn mới
                    int maDon = TaoMaDonXinNghi(ngayNghi);
                    if (maDon <= 0)
                    {
                        return;
                    }

                    // Thêm MaGV và maDon vào câu truy vấn
                    string query = @"
                            INSERT INTO DonXinNghi (MaDon, MaHS, NgayGui, NgayNghi, LyDo, MaGV, TrangThai)
                            VALUES (@MaDon, @MaHS, @NgayGui, @NgayNghi, @LyDo, @MaGV, @TrangThai);";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon },
                        { "@MaHS", maHS },
                        { "@NgayGui", ngayGui },
                        { "@NgayNghi", ngayNghi },
                        { "@LyDo", lyDo },
                        { "@MaGV", maGV },
                        { "@TrangThai", "Chờ duyệt" }
                    };

                    // Thực hiện câu lệnh SQL
                    bool success = dbHelper.ExecuteNonQuery(query, parameters);

                    if (success)
                    {
                        // Lấy tên giáo viên
                        string teacherName = "";
                        if (cboGiaoVien.SelectedItem is GiaoVienInfo teacher)
                        {
                            teacherName = teacher.MaGV == -1 ? "giáo viên chủ nhiệm" : teacher.HoTen;
                        }

                        MessageBox.Show($"Đơn xin nghỉ học ngày {ngayNghi.ToString("dd/MM/yyyy")} đã được gửi thành công đến {teacherName}!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Thông báo thành công
                        OnSubmitSuccess?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi tạo đơn xin nghỉ học. Vui lòng thử lại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kiểm tra xem học sinh đã có đơn nghỉ cho ngày cụ thể chưa
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="ngayNghi">Ngày nghỉ cần kiểm tra</param>
        /// <returns>True nếu đã tồn tại đơn, False nếu chưa</returns>
        private bool KiemTraDonTonTai(int maHS, DateTime ngayNghi)
        {
            try
            {
                string query = @"
            SELECT COUNT(1) AS Count
            FROM DonXinNghi
            WHERE MaHS = @MaHS 
              AND CONVERT(date, NgayNghi) = CONVERT(date, @NgayNghi)
              AND TrangThai <> N'Từ chối'";

                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaHS", maHS },
            { "@NgayNghi", ngayNghi.Date }
        };

                object result = dbHelper.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra đơn trùng: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy viết đơn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Kích hoạt sự kiện hủy
                OnCancel?.Invoke(this, EventArgs.Empty);
            }
        }

        private void lblLoaiDon_Click(object sender, EventArgs e)
        {
            // Không xử lý sự kiện này
        }

        private void lblTuNgay_Click(object sender, EventArgs e)
        {
            // Không xử lý sự kiện này
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            // Không xử lý sự kiện này
        }
        /// <summary>
        /// Tạo mã đơn xin nghỉ duy nhất dựa trên thông tin học sinh và ngày nghỉ
        /// </summary>
        /// <param name="ngayNghi">Ngày xin nghỉ</param>
        /// <returns>Mã đơn dạng số nguyên đảm bảo tính duy nhất</returns>
        private int TaoMaDonXinNghi(DateTime ngayNghi)
        {
            try
            {
                // Kiểm tra xem học sinh đã có đơn nghỉ cho ngày này chưa
                string checkQuery = @"
                    SELECT COUNT(1) AS Count
                    FROM DonXinNghi
                    WHERE MaHS = @MaHS 
                      AND CONVERT(date, NgayNghi) = CONVERT(date, @NgayNghi)
                      AND TrangThai <> N'Từ chối'";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS },
                    { "@NgayNghi", ngayNghi.Date }
                };

                object result = dbHelper.ExecuteScalar(checkQuery, parameters);
                if (result != null && Convert.ToInt32(result) > 0)
                {
                    // Học sinh đã có đơn nghỉ cho ngày này
                    MessageBox.Show($"Đã tồn tại đơn xin nghỉ cho ngày {ngayNghi:dd/MM/yyyy}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                // Lấy mã đơn lớn nhất trong hệ thống và tăng lên 1
                string maxIdQuery = @"
                    SELECT ISNULL(MAX(MaDon), 0)
                    FROM DonXinNghi";

                object maxIdResult = dbHelper.ExecuteScalar(maxIdQuery);
                int nextId = Convert.ToInt32(maxIdResult) + 1;

                return nextId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo mã đơn xin nghỉ: {ex.Message}");
                MessageBox.Show($"Lỗi khi tạo mã đơn xin nghỉ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }

    /// <summary>
    /// Lớp lưu trữ thông tin tệp đính kèm
    /// </summary>
    public class FileAttachment
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

        public string FormattedFileSize
        {
            get
            {
                string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
                int suffixIndex = 0;
                double size = FileSize;

                while (size >= 1024 && suffixIndex < suffixes.Length - 1)
                {
                    size /= 1024;
                    suffixIndex++;
                }

                return $"{size:0.##} {suffixes[suffixIndex]}";
            }
        }
    }
}
