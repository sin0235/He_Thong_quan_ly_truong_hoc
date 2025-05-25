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
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyHocSinh : UserControl
    {
        private DatabaseHelper db;
        private HocSinhDAO hocSinhDAL; // Sử dụng DAL cho các thao tác CRUD

        public ucQuanLyHocSinh()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            hocSinhDAL = new HocSinhDAO(); // Khởi tạo DAL
            LoadHocSinhData();
            LoadLop();
            this.Load += ucQuanLyHocSinh_Load;
        }

        private void UpdateStatistics()
        {
            // Kiểm tra số lượng dòng trong DataGridView sau khi đã áp dụng bộ lọc
            int studentCount = dgvHocSinh.Rows.Count;
            
            // Hiển thị tổng số học sinh trên lblStatistics
            lblStatistics.Text = $"Tổng số: {studentCount} học sinh";
            
            // Nếu đang lọc theo lớp, hiển thị thêm thông tin lớp
            if (cbLop.SelectedIndex > 0) // Không phải "Tất cả lớp"
            {
                string tenLop = cbLop.Text;
                lblStatistics.Text = $"Lớp {tenLop}: {studentCount} học sinh";
            }
            
            // Nếu đang tìm kiếm
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text) && txtTimKiem.Text != "Nhập họ và tên để tìm kiếm")
            {
                lblStatistics.Text = $"Kết quả tìm kiếm: {studentCount} học sinh";
            }
        }

        private void LoadHocSinhData()
        {
            try
            {
                string query = @"
                    SELECT 
                        hs.MaHS, 
                        hs.MaNguoiDung, 
                        hs.HoTen, 
                        CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh, 
                        hs.GioiTinh,
                        hs.MaDinhDanh,
                        hs.DanToc,
                        hs.DiaChiThuongTru,
                        hs.TinhThanh,
                        hs.SDT,
                        ph.HoTenCha,
                        ph.SoDienThoaiCha,
                        ph.HoTenMe,
                        ph.SoDienThoaiMe,
                        lh.TenLop
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    LEFT JOIN PhuHuynh ph ON hs.MaHS = ph.MaHS";

                DataTable dataTable = db.ExecuteQuery(query);
                dgvHocSinh.DataSource = dataTable;

                // Tự động điều chỉnh kích thước cột
                dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                // Cập nhật thống kê
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvHocSinh.ClearSelection();
        }

        private void LoadLop()
        {
            try
            {
                // Sử dụng DAL để lấy danh sách lớp
                DataTable dt = hocSinhDAL.GetClasses();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Thêm một hàng "Tất cả lớp" vào đầu danh sách
                    DataRow allClassesRow = dt.NewRow();
                    allClassesRow["MaLop"] = -1;
                    allClassesRow["TenLop"] = "Tất cả lớp";
                    dt.Rows.InsertAt(allClassesRow, 0);

                    cbLop.DataSource = dt;
                    cbLop.DisplayMember = "TenLop";
                    cbLop.ValueMember = "MaLop";
                    cbLop.SelectedIndex = 0; // Mặc định chọn "Tất cả lớp"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHocSinhData(int? maLop = null)
        {
            try
            {
                // Nếu chọn "Tất cả lớp" hoặc không chọn lớp nào
                if (maLop == null || maLop <= 0)
                {
                    LoadHocSinhData();
                    return;
                }

                string query = @"
                    SELECT 
                        hs.MaHS, 
                        hs.MaNguoiDung, 
                        hs.HoTen, 
                        CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh, 
                        hs.GioiTinh,
                        hs.MaDinhDanh,
                        hs.DanToc,
                        hs.DiaChiThuongTru,
                        hs.TinhThanh,
                        hs.SDT,
                        ph.HoTenCha,
                        ph.SoDienThoaiCha,
                        ph.HoTenMe,
                        ph.SoDienThoaiMe,
                        lh.TenLop
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    LEFT JOIN PhuHuynh ph ON hs.MaHS = ph.MaHS
                    WHERE hs.MaLop = @MaLop";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaLop", maLop }
                    };

                DataTable dataTable = db.ExecuteQuery(query, parameters);
                dgvHocSinh.DataSource = dataTable;

                // Tự động điều chỉnh kích thước cột
                dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                // Cập nhật thống kê
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvHocSinh.ClearSelection();
        }

        private void ucQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            dgvHocSinh.ClearSelection();
            // Điều chỉnh kích thước phông chữ phù hợp
            dgvHocSinh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvHocSinh.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            // Thiết lập màu sắc cho các hàng luân phiên
            dgvHocSinh.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvHocSinh.RowsDefaultCellStyle.BackColor = Color.White;

            // Tự động điều chỉnh kích thước cột theo nội dung
            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập sự kiện khi click vào ô
            dgvHocSinh.CellClick += dgvHocSinh_CellClick;

            // Xóa text tìm kiếm khi click vào
            txtTimKiem.Enter += (s, args) =>
            {
                if (txtTimKiem.Text == "Nhập họ và tên để tìm kiếm")
                    txtTimKiem.Text = "";
            };

            txtTimKiem.Leave += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                    txtTimKiem.Text = "Nhập họ và tên để tìm kiếm";
            };
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chọn dòng khi click vào ô
            if (e.RowIndex >= 0)
            {
                dgvHocSinh.Rows[e.RowIndex].Selected = true;
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedValue != null && int.TryParse(cbLop.SelectedValue.ToString(), out int maLop))
            {
                // Nếu chọn "Tất cả lớp"
                if (maLop == -1)
                {
                    LoadHocSinhData();
                }
                else
                {
                    LoadHocSinhData(maLop);
                }
            }
            else
            {
                LoadHocSinhData();
            }
        }

        private void btnThemHocSinh_Click(object sender, EventArgs e)
        {
            frmQuanLyHocSinh frm = new frmQuanLyHocSinh();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.title = "Thêm học sinh mới";
            if (frm.ShowDialog() == DialogResult.OK) // Chỉ thực hiện nếu thêm học sinh thành công
            {
                try
                {
                    // Lấy danh sách học sinh mới nhất để xác định học sinh vừa thêm
                    var latestStudents = hocSinhDAL.GetAllStudents().OrderByDescending(s => Convert.ToInt32(s.StudentId)).FirstOrDefault();

                    if (latestStudents != null)
                    {
                        int maHS = Convert.ToInt32(latestStudents.StudentId);
                        string hoTenHocSinh = latestStudents.FullName;
                        string tenLop = latestStudents.ClassName;

                        // Ghi nhật ký hệ thống
                        GhiNhatKyHeThong($"Thêm học sinh {hoTenHocSinh} vào lớp {tenLop}");

                        // Hiển thị thông báo thành công
                        MessageBox.Show($"Thêm học sinh {hoTenHocSinh} vào lớp {tenLop} thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Tải lại dữ liệu sau khi thêm
                    LoadHocSinhData();

                    // Nếu combobox đang chọn một lớp cụ thể, cập nhật lại dữ liệu cho lớp đó
                    if (cbLop.SelectedValue != null && int.TryParse(cbLop.SelectedValue.ToString(), out int maLop) && maLop > 0)
                    {
                        LoadHocSinhData(maLop);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ghi nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = dgvHocSinh.SelectedRows[0];
                int maHS = Convert.ToInt32(selectedRow.Cells["MaHS"].Value);

                // Lấy thông tin học sinh từ DAL
                ThongTinHSDTO hocSinh = hocSinhDAL.GetStudentById(maHS);

                if (hocSinh != null)
                {
                    // Sử dụng constructor hiện có với dữ liệu đầy đủ
                    frmQuanLyHocSinh frm = new frmQuanLyHocSinh(
                        maHS,
                        hocSinh.FullName,
                        hocSinh.DateOfBirth,
                        hocSinh.Gender,
                        hocSinh.PermanentAddress,
                        !string.IsNullOrEmpty(hocSinh.FatherPhone) ? hocSinh.FatherPhone : hocSinh.MotherPhone,
                        hocSinh.ClassName
                    );
                    frm.title = "Sửa thông tin học sinh";
                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Lấy thông tin học sinh sau khi cập nhật
                            ThongTinHSDTO updatedHocSinh = hocSinhDAL.GetStudentById(maHS);

                            if (updatedHocSinh != null)
                            {
                                // Ghi nhật ký hệ thống
                                GhiNhatKyHeThong($"Sửa thông tin học sinh {updatedHocSinh.FullName} của lớp {updatedHocSinh.ClassName}");

                                // Hiển thị thông báo thành công
                                MessageBox.Show($"Cập nhật thông tin học sinh {updatedHocSinh.FullName} thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // Tải lại dữ liệu sau khi sửa
                            if (cbLop.SelectedValue != null && int.TryParse(cbLop.SelectedValue.ToString(), out int maLop) && maLop > 0)
                            {
                                LoadHocSinhData(maLop);
                            }
                            else
                            {
                                LoadHocSinhData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin học sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học sinh cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maHS = Convert.ToInt32(dgvHocSinh.SelectedRows[0].Cells["MaHS"].Value);
            int maNguoiDung = Convert.ToInt32(dgvHocSinh.SelectedRows[0].Cells["MaNguoiDung"].Value);
            string hoTen = dgvHocSinh.SelectedRows[0].Cells["HoTen"].Value.ToString();

            // Check if the TenLop column exists in the DataGridView
            string tenLop = "Không xác định";
            if (dgvHocSinh.Columns.Contains("TenLop") && dgvHocSinh.SelectedRows[0].Cells["TenLop"].Value != null)
            {
                tenLop = dgvHocSinh.SelectedRows[0].Cells["TenLop"].Value.ToString();
            }
            else
            {
                // If TenLop doesn't exist in the current view, fetch it from the database
                int maLop = hocSinhDAL.GetMaLopByMaHS(maHS);
                string queryGetTenLop = "SELECT TenLop FROM LopHoc WHERE MaLop = @MaLop";
                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaLop", maLop }
        };
                object rs = db.ExecuteScalar(queryGetTenLop, parameters);
                if (rs != null && rs != DBNull.Value)
                {
                    tenLop = rs.ToString();
                }
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh {hoTen} khỏi hệ thống không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Danh sách các lệnh xóa sẽ được thực hiện theo thứ tự
                    List<string> deleteCommands = new List<string>();

                    // Kiểm tra các ràng buộc trước khi xóa
                    string checkQuery = @"
                        SELECT
                            (SELECT COUNT(*) FROM PhuHuynh WHERE MaHS = @MaHS) AS HasPhuHuynh,
                            (SELECT COUNT(*) FROM DiemSo WHERE MaHS = @MaHS) AS HasDiemSo,
                            (SELECT COUNT(*) FROM DiemDanh WHERE MaHS = @MaHS) AS HasDiemDanh,
                            (SELECT COUNT(*) FROM DonXinNghi WHERE MaHS = @MaHS) AS HasDonXinNghi,
                            (SELECT COUNT(*) FROM ThongBao WHERE MaNguoiGui = @MaNguoiDung 
                                OR MaNguoiNhan = @MaNguoiDung) AS HasThongBao,
                            (SELECT COUNT(*) FROM NhatKyHeThong WHERE MaNguoiDung = @MaNguoiDung) AS HasNhatKyHeThong,
                            (SELECT COUNT(*) FROM BaiLam WHERE MaHS = @MaHS) AS HasBaiLam";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", maHS },
                        { "@MaNguoiDung", maNguoiDung }
                    };

                    DataTable dt = db.ExecuteQuery(checkQuery, parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // 1. Xóa các dữ liệu liên kết với học sinh và người dùng theo thứ tự hợp lý
                        // Kiểm tra kỹ từng ràng buộc

                        // Kiểm tra và xóa dữ liệu BaiLam liên quan
                        if (Convert.ToBoolean(row["HasBaiLam"]))
                        {
                            // Lấy danh sách MaBaiLam của học sinh
                            string getBaiLamQuery = $"SELECT MaBaiLam FROM BaiLam WHERE MaHS = {maHS}";
                            DataTable dtBaiLam = db.ExecuteQuery(getBaiLamQuery);
                            
                            if (dtBaiLam != null && dtBaiLam.Rows.Count > 0)
                            {
                                foreach (DataRow baiLamRow in dtBaiLam.Rows)
                                {
                                    int maBaiLam = Convert.ToInt32(baiLamRow["MaBaiLam"]);
                                    
                                    // Xóa dữ liệu trong BaiLam_TracNghiem
                                    deleteCommands.Add($"DELETE FROM BaiLam_TracNghiem WHERE MaBaiLam = {maBaiLam}");
                                    
                                    // Xóa dữ liệu trong BaiLam_TuLuan
                                    deleteCommands.Add($"DELETE FROM BaiLam_TuLuan WHERE MaBaiLam = {maBaiLam}");
                                }
                            }
                            
                            // Sau khi đã xóa các bảng con, xóa bảng BaiLam
                            deleteCommands.Add($"DELETE FROM BaiLam WHERE MaHS = {maHS}");
                        }

                        // Kiểm tra và xóa các thông báo liên quan
                        if (Convert.ToBoolean(row["HasThongBao"]))
                        {
                            // Xóa thông báo người đọc trước
                            deleteCommands.Add($"DELETE FROM ThongBaoNguoiDoc WHERE MaNguoiDung = {maNguoiDung}");
                            
                            // Xóa các thông báo mà học sinh là người gửi
                            deleteCommands.Add($"DELETE FROM ThongBao WHERE MaNguoiGui = {maNguoiDung}");
                        }

                        // Xóa nhật ký hệ thống liên quan (nếu có)
                        if (Convert.ToBoolean(row["HasNhatKyHeThong"]))
                        {
                            deleteCommands.Add($"DELETE FROM NhatKyHeThong WHERE MaNguoiDung = {maNguoiDung}");
                        }

                        // Xóa thông tin phụ huynh (nếu có)
                        if (Convert.ToBoolean(row["HasPhuHuynh"]))
                        {
                            deleteCommands.Add($"DELETE FROM PhuHuynh WHERE MaHS = {maHS}");
                        }

                        // Xóa điểm số (nếu có)
                        if (Convert.ToBoolean(row["HasDiemSo"]))
                        {
                            deleteCommands.Add($"DELETE FROM DiemSo WHERE MaHS = {maHS}");
                        }

                        // Xóa điểm danh (nếu có)
                        if (Convert.ToBoolean(row["HasDiemDanh"]))
                        {
                            deleteCommands.Add($"DELETE FROM DiemDanh WHERE MaHS = {maHS}");
                        }

                        // Xóa đơn xin nghỉ (nếu có)
                        if (Convert.ToBoolean(row["HasDonXinNghi"]))
                        {
                            deleteCommands.Add($"DELETE FROM DonXinNghi WHERE MaHS = {maHS}");
                        }
                    }

                    // 2. Kiểm tra thêm các bảng không xác định khác
                    string queryForeignKeys = @"
                        SELECT 
                            OBJECT_NAME(f.parent_object_id) AS TableName,
                            COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName
                        FROM 
                            sys.foreign_keys AS f
                        INNER JOIN 
                            sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id
                        WHERE 
                            OBJECT_NAME(f.referenced_object_id) IN ('HocSinh', 'NguoiDung')";

                    DataTable foreignKeysResult = db.ExecuteQuery(queryForeignKeys);

                    if (foreignKeysResult != null && foreignKeysResult.Rows.Count > 0)
                    {
                        foreach (DataRow fkRow in foreignKeysResult.Rows)
                        {
                            string tableName = fkRow["TableName"].ToString();
                            string columnName = fkRow["ColumnName"].ToString();

                            // Xác định giá trị ID cần xóa (maHS hoặc maNguoiDung)
                            int valueToDelete = columnName.Contains("MaNguoiDung") ? maNguoiDung : maHS;

                            // Thêm lệnh xóa nếu bảng chưa được xử lý
                            if (!deleteCommands.Any(cmd => cmd.Contains($"DELETE FROM {tableName}")))
                            {
                                deleteCommands.Add($"DELETE FROM {tableName} WHERE {columnName} = {valueToDelete}");
                            }
                        }
                    }

                    // 3. Cuối cùng, xóa học sinh và người dùng
                    deleteCommands.Add($"DELETE FROM HocSinh WHERE MaHS = {maHS}");
                    deleteCommands.Add($"DELETE FROM NguoiDung WHERE MaNguoiDung = {maNguoiDung}");

                    // Thực hiện các lệnh xóa theo trình tự
                    bool success = db.ExecuteTransaction(deleteCommands);

                    if (success)
                    {
                        // Ghi nhật ký hệ thống
                        try
                        {
                            GhiNhatKyHeThong($"Xóa học sinh {hoTen} ra khỏi lớp {tenLop}");
                        }
                        catch
                        {
                            // Bỏ qua lỗi ghi nhật ký vì đây là chức năng phụ
                        }

                        MessageBox.Show($"Đã xóa học sinh {hoTen} thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu sau khi xóa
                        if (cbLop.SelectedValue != null && int.TryParse(cbLop.SelectedValue.ToString(), out int maLop) && maLop > 0)
                        {
                            LoadHocSinhData(maLop);
                        }
                        else
                        {
                            LoadHocSinhData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa học sinh thất bại! Có thể còn ràng buộc khóa ngoại chưa được xử lý.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Hiển thị thông tin chi tiết về các ràng buộc
                        string constraintsQuery = @"
                            SELECT 
                                OBJECT_NAME(f.parent_object_id) AS TableName,
                                OBJECT_NAME(f.object_id) AS ConstraintName,
                                COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName,
                                OBJECT_NAME(f.referenced_object_id) AS ReferencedTable,
                                COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferencedColumn
                            FROM 
                                sys.foreign_keys AS f
                            INNER JOIN 
                                sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id
                            WHERE 
                                OBJECT_NAME(f.referenced_object_id) IN ('HocSinh', 'NguoiDung')
                            ORDER BY
                                TableName";

                        DataTable constraints = db.ExecuteQuery(constraintsQuery);

                        if (constraints != null && constraints.Rows.Count > 0)
                        {
                            StringBuilder constraintInfo = new StringBuilder("Các ràng buộc hiện có:\n");

                            foreach (DataRow constRow in constraints.Rows)
                            {
                                constraintInfo.AppendLine(
                                    $"- Bảng: {constRow["TableName"]}, " +
                                    $"Cột: {constRow["ColumnName"]}, " +
                                    $"Tham chiếu: {constRow["ReferencedTable"]}.{constRow["ReferencedColumn"]}");
                            }

                            MessageBox.Show(constraintInfo.ToString(), "Thông tin ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset các điều khiển
                dgvHocSinh.ClearSelection();
                cbLop.SelectedIndex = 0; // Chọn "Tất cả lớp"
                txtTimKiem.Text = "Nhập họ và tên để tìm kiếm";

                // Tải lại dữ liệu
                LoadHocSinhData();

                // Hiển thị thông báo ngắn gọn
                MessageBox.Show("Dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();

                // Kiểm tra xem có nhập từ khóa tìm kiếm chưa
                if (string.IsNullOrWhiteSpace(searchText) || searchText == "Nhập họ và tên để tìm kiếm")
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sử dụng DAL để tìm kiếm học sinh
                var searchResults = hocSinhDAL.SearchStudents(searchText);

                if (searchResults != null && searchResults.Count > 0)
                {
                    // Chuyển kết quả tìm kiếm thành DataTable để hiển thị
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MaHS", typeof(int));
                    dataTable.Columns.Add("MaNguoiDung", typeof(int));
                    dataTable.Columns.Add("HoTen", typeof(string));
                    dataTable.Columns.Add("NgaySinh", typeof(string));
                    dataTable.Columns.Add("GioiTinh", typeof(string));
                    dataTable.Columns.Add("MaDinhDanh", typeof(string));
                    dataTable.Columns.Add("DanToc", typeof(string));
                    dataTable.Columns.Add("DiaChiThuongTru", typeof(string));
                    dataTable.Columns.Add("TinhThanh", typeof(string));
                    dataTable.Columns.Add("SDT", typeof(string));
                    dataTable.Columns.Add("HoTenCha", typeof(string));
                    dataTable.Columns.Add("SoDienThoaiCha", typeof(string));
                    dataTable.Columns.Add("HoTenMe", typeof(string));
                    dataTable.Columns.Add("SoDienThoaiMe", typeof(string));
                    dataTable.Columns.Add("TenLop", typeof(string));

                    foreach (var student in searchResults)
                    {
                        dataTable.Rows.Add(
                            Convert.ToInt32(student.StudentId),
                            0, // MaNguoiDung không quan trọng hiển thị
                            student.FullName,
                            student.DateOfBirth.ToString("dd/MM/yyyy"),
                            student.Gender,
                            student.IdentityCode,
                            student.Ethnicity,
                            student.PermanentAddress,
                            student.Province,
                            student.Mobile,
                            student.FatherName,
                            student.FatherPhone,
                            student.MotherName,
                            student.MotherPhone,
                            student.ClassName
                        );
                    }

                    dgvHocSinh.DataSource = dataTable;
                    dgvHocSinh.ClearSelection();
                    
                    // Cập nhật thống kê
                    UpdateStatistics();

                    MessageBox.Show($"Tìm thấy {searchResults.Count} học sinh phù hợp với từ khóa tìm kiếm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy học sinh nào phù hợp với từ khóa tìm kiếm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức ghi nhật ký hệ thống
        private void GhiNhatKyHeThong(string hanhDong)
        {
            try
            {
                // Truy vấn để lấy MaNguoiDung của người dùng hiện tại
                string queryPhongNoiVu = "SELECT TOP 1 MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 2";
                object result = db.ExecuteScalar(queryPhongNoiVu);
                
                // Kiểm tra kết quả trả về
                if (result == null || result == DBNull.Value)
                {
                    // Không tìm thấy người dùng phòng nội vụ, dùng mặc định là 1 hoặc tạo log với ID khác
                    Console.WriteLine("Không tìm thấy người dùng phòng nội vụ");
                    return; // Có thể xử lý khác, như tạo người dùng mới hoặc dùng ID mặc định
                }
                
                int maNguoiDungPhongNoiVu = Convert.ToInt32(result);

                // Truy vấn để lấy MaNK lớn nhất trong bảng NhatKyHeThong
                string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                result = db.ExecuteScalar(queryMaxMaNK);
                
                // Kiểm tra kết quả trả về
                if (result == null || result == DBNull.Value)
                {
                    Console.WriteLine("Lỗi khi lấy mã nhật ký mới");
                    return;
                }
                
                int maNK = Convert.ToInt32(result);

                // Thêm vào bảng NhatKyHeThong sử dụng tham số để tránh SQL Injection
                string insertNhatKy = @"
                    INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                    VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNK", maNK },
                    { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                    { "@HanhDong", hanhDong }
                };

                db.ExecuteNonQuery(insertNhatKy, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi nhật ký: {ex.Message}");
                // Không hiển thị thông báo lỗi vì đây là chức năng phụ
            }
        }
    }
}
