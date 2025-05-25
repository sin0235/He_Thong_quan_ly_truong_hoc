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

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyLop : Form
    {
        private DatabaseHelper db;
        private string namHocHienTai;
        private string tenLop;
        private string tenGVChuNhiemCu;
        private bool isEditMode = false;

        public frmQuanLyLop()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            isEditMode = false;

            btnXacNhan.Text = "Cập nhật";
            TKBDAO tkbDAO = new TKBDAO();
            namHocHienTai = tkbDAO.GetCurrentSchoolYear();
            if (string.IsNullOrEmpty(namHocHienTai))
            {
                namHocHienTai = "2024-2025";
            }
        }

        public frmQuanLyLop(string tenLop, string tenGVChuNhiemCu)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            isEditMode = true;

            this.tenLop = tenLop;
            this.tenGVChuNhiemCu = tenGVChuNhiemCu;

            TKBDAO tkbDAO = new TKBDAO();
            namHocHienTai = tkbDAO.GetCurrentSchoolYear();

            if (string.IsNullOrEmpty(namHocHienTai))
            {
                namHocHienTai = "2024-2025";
            }
        }

        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                btnXacNhan.Text = "Cập nhật";
                txtLop.Text = tenLop;
                txtLop.Enabled = false; 
                LoadGiaoVienChoSua();
            }
            else
            {
                btnXacNhan.Text = "Thêm";
                LoadGiaoVienChuaLamChuNhiem();
            }
        }

        private void LoadGiaoVienChoSua()
        {
            try
            {
                // Truy vấn để lấy thông tin lớp học (bao gồm MaLop và MaGVChuNhiem)
                string getLopInfoQuery = "SELECT MaLop, MaGVChuNhiem FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                Dictionary<string, object> lopParams = new Dictionary<string, object>
                {
                    { "@TenLop", tenLop },
                    { "@NamHoc", namHocHienTai }
                };

                DataTable lopInfo = db.ExecuteQuery(getLopInfoQuery, lopParams);
                int maLop = 0;
                int maGVChuNhiemCu = 0;

                if (lopInfo != null && lopInfo.Rows.Count > 0)
                {
                    maLop = Convert.ToInt32(lopInfo.Rows[0]["MaLop"]);
                    maGVChuNhiemCu = Convert.ToInt32(lopInfo.Rows[0]["MaGVChuNhiem"]);
                }

                // Truy vấn lấy danh sách giáo viên có thể làm chủ nhiệm lớp này, bao gồm:
                // 1. Giáo viên hiện tại của lớp
                // 2. Giáo viên chưa được phân công làm chủ nhiệm
                string query = @"
                SELECT gv.MaGV, gv.HoTen
                FROM GiaoVien gv
                WHERE gv.MaGV = @MaGVCu  -- Giáo viên hiện tại của lớp
                   OR gv.ChuNhiem = 0    -- Giáo viên chưa được phân công làm chủ nhiệm
                   OR gv.MaGV NOT IN (   -- Giáo viên không chủ nhiệm lớp khác trong năm học hiện tại
                       SELECT DISTINCT MaGVChuNhiem 
                       FROM LopHoc 
                       WHERE NamHoc = @NamHoc AND MaLop <> @MaLop
                   )
                ORDER BY 
                   CASE WHEN gv.MaGV = @MaGVCu THEN 0 ELSE 1 END,  -- Đặt giáo viên hiện tại lên đầu
                   gv.HoTen
                ";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaGVCu", maGVChuNhiemCu },
                    { "@NamHoc", namHocHienTai },
                    { "@MaLop", maLop }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbGiaoVienChuNhiem.DisplayMember = "HoTen";
                    cbGiaoVienChuNhiem.ValueMember = "MaGV";
                    cbGiaoVienChuNhiem.DataSource = dt;
                    cbGiaoVienChuNhiem.SelectedValue = maGVChuNhiemCu;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên nào có thể làm chủ nhiệm cho lớp này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbGiaoVienChuNhiem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGiaoVienChuaLamChuNhiem()
        {
            try
            {
                // Truy vấn để lấy danh sách giáo viên chưa được phân công làm chủ nhiệm
                string query = @"
                SELECT gv.MaGV, gv.HoTen
                FROM GiaoVien gv
                WHERE gv.ChuNhiem = 0 AND gv.MaGV NOT IN (
                    SELECT DISTINCT MaGVChuNhiem 
                    FROM LopHoc 
                    WHERE NamHoc = @NamHoc
                )
                ORDER BY gv.HoTen
                ";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NamHoc", namHocHienTai }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbGiaoVienChuNhiem.DisplayMember = "HoTen";
                    cbGiaoVienChuNhiem.ValueMember = "MaGV";
                    cbGiaoVienChuNhiem.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không còn giáo viên nào chưa được phân công chủ nhiệm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbGiaoVienChuNhiem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu chung cho cả hai chế độ
            if (cbGiaoVienChuNhiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giáo viên chủ nhiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isEditMode)
                {
                    int maGVChuNhiemMoi = (int)cbGiaoVienChuNhiem.SelectedValue;
                    string tenGVChuNhiemMoi = cbGiaoVienChuNhiem.Text;

                    // Lấy thông tin của lớp học cần cập nhật từ MaLop
                    string checkClassQuery = "SELECT MaLop, TenLop FROM LopHoc WHERE TenLop = @TenLop";
                    Dictionary<string, object> checkParams = new Dictionary<string, object>
                    {
                        { "@TenLop", tenLop.Trim() }
                    };

                    DataTable allMatchingClasses = db.ExecuteQuery(checkClassQuery, checkParams);
                    if (allMatchingClasses == null || allMatchingClasses.Rows.Count == 0)
                    {
                        MessageBox.Show($"Không tìm thấy lớp {tenLop} trong cơ sở dữ liệu!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy thông tin chính xác của lớp học
                    string getLopInfoQuery = "SELECT MaLop, MaGVChuNhiem FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> lopParams = new Dictionary<string, object>
                    {
                        { "@TenLop", tenLop.Trim() },
                        { "@NamHoc", namHocHienTai }
                    };

                    DataTable lopInfo = db.ExecuteQuery(getLopInfoQuery, lopParams);
                    int maLop = 0;
                    int maGVChuNhiemCu = 0;

                    if (lopInfo != null && lopInfo.Rows.Count > 0)
                    {
                        maLop = Convert.ToInt32(lopInfo.Rows[0]["MaLop"]);
                        maGVChuNhiemCu = Convert.ToInt32(lopInfo.Rows[0]["MaGVChuNhiem"]);
                    }
                    else
                    {
                        string directQuery = $"SELECT MaLop, MaGVChuNhiem, NamHoc FROM LopHoc WHERE TenLop = '{tenLop.Trim()}'";
                        DataTable directResult = db.ExecuteQuery(directQuery);

                        if (directResult != null && directResult.Rows.Count > 0)
                        {
                            maLop = Convert.ToInt32(directResult.Rows[0]["MaLop"]);
                            maGVChuNhiemCu = Convert.ToInt32(directResult.Rows[0]["MaGVChuNhiem"]);
                            namHocHienTai = directResult.Rows[0]["NamHoc"].ToString();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy thông tin lớp {tenLop} trong năm học {namHocHienTai}!\n" +
                                "Vui lòng kiểm tra lại tên lớp và năm học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Nếu giáo viên chủ nhiệm không thay đổi
                    if (maGVChuNhiemMoi == maGVChuNhiemCu)
                    {
                        MessageBox.Show("Không có thay đổi nào được thực hiện!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Kiểm tra xem giáo viên mới có đang chủ nhiệm lớp khác không
                    string checkGVMoiQuery = "SELECT COUNT(*) FROM LopHoc WHERE MaGVChuNhiem = @MaGV AND MaLop <> @MaLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> checkGVMoiParams = new Dictionary<string, object>
                    {
                        { "@MaGV", maGVChuNhiemMoi },
                        { "@MaLop", maLop },
                        { "@NamHoc", namHocHienTai }
                    };
                    int otherClassCountGVMoi = Convert.ToInt32(db.ExecuteScalar(checkGVMoiQuery, checkGVMoiParams));

                    if (otherClassCountGVMoi > 0)
                    {
                        // Nếu giáo viên mới đã chủ nhiệm lớp khác, hiển thị cảnh báo nhưng vẫn cho phép cập nhật
                        DialogResult confirmResult = MessageBox.Show(
                            $"Giáo viên {tenGVChuNhiemMoi} đã là chủ nhiệm của lớp khác. Bạn vẫn muốn phân công làm chủ nhiệm lớp này?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (confirmResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    // Cập nhật trạng thái của giáo viên chủ nhiệm cũ
                    if (maGVChuNhiemCu > 0)
                    {
                        // Kiểm tra xem giáo viên cũ có còn chủ nhiệm lớp nào khác không
                        string checkOtherClassQuery = "SELECT COUNT(*) FROM LopHoc WHERE MaGVChuNhiem = @MaGV AND MaLop <> @MaLop AND NamHoc = @NamHoc";
                        Dictionary<string, object> checkParams2 = new Dictionary<string, object>
                        {
                            { "@MaGV", maGVChuNhiemCu },
                            { "@MaLop", maLop },
                            { "@NamHoc", namHocHienTai }
                        };
                        int otherClassCount = Convert.ToInt32(db.ExecuteScalar(checkOtherClassQuery, checkParams2));

                        if (otherClassCount == 0)
                        {
                            // Nếu không còn chủ nhiệm lớp nào khác, cập nhật trạng thái ChuNhiem = 0
                            string updateOldGVQuery = "UPDATE GiaoVien SET ChuNhiem = 0 WHERE MaGV = @MaGV";
                            Dictionary<string, object> updateOldParams = new Dictionary<string, object>
                    {
                        { "@MaGV", maGVChuNhiemCu }
                    };
                            db.ExecuteNonQuery(updateOldGVQuery, updateOldParams);
                        }
                    }

                    // Cập nhật trạng thái của giáo viên chủ nhiệm mới
                    string updateNewGVQuery = "UPDATE GiaoVien SET ChuNhiem = 1 WHERE MaGV = @MaGV";
                    Dictionary<string, object> updateNewParams = new Dictionary<string, object>
                    {
                        { "@MaGV", maGVChuNhiemMoi }
                    };
                    db.ExecuteNonQuery(updateNewGVQuery, updateNewParams);

                    // Cập nhật thông tin lớp học
                    string updateLopQuery = "UPDATE LopHoc SET MaGVChuNhiem = @MaGVMoi WHERE MaLop = @MaLop";
                    Dictionary<string, object> updateLopParams = new Dictionary<string, object>
                    {
                        { "@MaGVMoi", maGVChuNhiemMoi },
                        { "@MaLop", maLop }
                    };
                    bool updateResult = db.ExecuteNonQuery(updateLopQuery, updateLopParams);

                    if (updateResult)
                    {
                        // Ghi nhật ký hoạt động
                        string getMaxMaNKQuery = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(getMaxMaNKQuery));

                        string getMaNguoiDungPhongNoiVuQuery = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = @MaVaiTro";
                        Dictionary<string, object> vaiTroParams = new Dictionary<string, object>
                        {
                            { "@MaVaiTro", 2 }
                        };
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(getMaNguoiDungPhongNoiVuQuery, vaiTroParams));

                        string hanhDong = $"Sửa thông tin lớp {tenLop} của giáo viên {tenGVChuNhiemCu} chủ nhiệm thành giáo viên {tenGVChuNhiemMoi} chủ nhiệm";

                        string insertNhatKyQuery = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, @ThoiGian)
                        ";

                        Dictionary<string, object> nhatKyParams = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong },
                            { "@ThoiGian", DateTime.Now }
                        };

                        db.ExecuteNonQuery(insertNhatKyQuery, nhatKyParams);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin giáo viên chủ nhiệm cho lớp học. Vui lòng thử lại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else  
                {
                    if (string.IsNullOrWhiteSpace(txtLop.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLop.Focus();
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> checkParams = new Dictionary<string, object>
                    {
                        { "@TenLop", txtLop.Text.Trim() },
                        { "@NamHoc", namHocHienTai }
                    };

                    int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show("Tên lớp này đã tồn tại trong năm học hiện tại!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLop.Focus();
                        return;
                    }

                    string getMaQuery = "SELECT ISNULL(MAX(MaLop), 0) + 1 FROM LopHoc";
                    int maLopMoi = Convert.ToInt32(db.ExecuteScalar(getMaQuery));

                    int maGV = (int)cbGiaoVienChuNhiem.SelectedValue;

                    string insertQuery = @"
                    INSERT INTO LopHoc (MaLop, TenLop, MaGVChuNhiem, NamHoc)
                    VALUES (@MaLop, @TenLop, @MaGVChuNhiem, @NamHoc)
                    ";

                    Dictionary<string, object> insertParams = new Dictionary<string, object>
                    {
                        { "@MaLop", maLopMoi },
                        { "@TenLop", txtLop.Text.Trim() },
                        { "@MaGVChuNhiem", maGV },
                        { "@NamHoc", namHocHienTai }
                    };

                    bool insertResult = db.ExecuteNonQuery(insertQuery, insertParams);

                    if (insertResult)
                    {
                        // Cập nhật trạng thái chủ nhiệm của giáo viên
                        string updateQuery = "UPDATE GiaoVien SET ChuNhiem = 1 WHERE MaGV = @MaGV";
                        Dictionary<string, object> updateParams = new Dictionary<string, object>
                        {
                            { "@MaGV", maGV }
                        };

                        db.ExecuteNonQuery(updateQuery, updateParams);

                        // Ghi nhật ký hệ thống
                        string getMaxMaNKQuery = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(getMaxMaNKQuery));

                        string getMaNguoiDungPhongNoiVuQuery = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = @MaVaiTro";
                        Dictionary<string, object> vaiTroParams = new Dictionary<string, object>
                        {
                            { "@MaVaiTro", 2 }
                        };
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(getMaNguoiDungPhongNoiVuQuery, vaiTroParams));

                        string tenGiaoVien = cbGiaoVienChuNhiem.Text;
                        string hanhDong = $"Thêm lớp {txtLop.Text.Trim()} với sự phân công cho giáo viên {tenGiaoVien} chủ nhiệm";

                        string insertNhatKyQuery = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, @ThoiGian)
                        ";

                        Dictionary<string, object> nhatKyParams = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong },
                            { "@ThoiGian", DateTime.Now }
                        };

                        db.ExecuteNonQuery(insertNhatKyQuery, nhatKyParams);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm lớp học mới. Vui lòng thử lại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucControlBar1_Load(object sender, EventArgs e)
        {

        }
    }
}
