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

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyThoiKhoaBieu : Form
    {
        private int maLop;
        private string tenLop;
        private DateTime ngayHoc;
        private DatabaseHelper db;
        public frmQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
        }
        public frmQuanLyThoiKhoaBieu(int maLop, string tenLop, DateTime ngayHoc)
        {
            InitializeComponent();
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.ngayHoc = ngayHoc;
            db = new DatabaseHelper();
        }

        private void LoadMonHoc()
        {
            string query = "SELECT MaMon, TenMon FROM MonHoc";
            DataTable dt = db.ExecuteQuery(query);
            cmbMonHoc.DataSource = dt;
            cmbMonHoc.DisplayMember = "TenMon";
            cmbMonHoc.ValueMember = "MaMon";
        }

        private void LoadGiaoVien(int maMon)
        {
            string query = @"
            SELECT MaGV, HoTen
            FROM GiaoVien
            WHERE MaMon = @MaMon";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMon", maMon }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            cmbGiaoVien.DataSource = dt;
            cmbGiaoVien.DisplayMember = "HoTen";
            cmbGiaoVien.ValueMember = "MaGV";

            if (!string.IsNullOrEmpty(cmbGiaoVien.Tag?.ToString()))
            {
                cmbGiaoVien.SelectedIndex = cmbGiaoVien.FindStringExact(cmbGiaoVien.Tag.ToString());
            }
        }

        private bool IsValidTietHocFormat(string tietHoc)
        {
            // Kiểm tra định dạng của chuỗi tiết học
            if (string.IsNullOrWhiteSpace(tietHoc))
                return false;

            string pattern = @"^(\d+(-\d+)?)(,\d+(-\d+)?)*$";
            return System.Text.RegularExpressions.Regex.IsMatch(tietHoc, pattern);
        }

        private List<int> ParseTietHoc(string tietHoc)
        {
            List<int> result = new List<int>();

            if (string.IsNullOrWhiteSpace(tietHoc))
                return result;

            string[] ranges = tietHoc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string range in ranges)
            {
                string trimmedRange = range.Trim();
                if (trimmedRange.Contains("-"))
                {
                    string[] bounds = trimmedRange.Split('-');
                    if (bounds.Length == 2 && int.TryParse(bounds[0], out int start) && int.TryParse(bounds[1], out int end))
                    {
                        // Đảm bảo start <= end
                        if (start > end)
                        {
                            int temp = start;
                            start = end;
                            end = temp;
                        }

                        for (int i = start; i <= end; i++)
                        {
                            if (!result.Contains(i)) // Tránh thêm trùng lặp
                                result.Add(i);
                        }
                    }
                }
                else if (int.TryParse(trimmedRange, out int singleTiet))
                {
                    if (!result.Contains(singleTiet)) // Tránh thêm trùng lặp
                        result.Add(singleTiet);
                }
            }

            return result;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int maMon = Convert.ToInt32(cmbMonHoc.SelectedValue);
                int maGV = Convert.ToInt32(cmbGiaoVien.SelectedValue);
                string tietHoc = txtTietHoc.Text.Trim();
                DateTime ngay = dtpNgayHoc.Value.Date;

                // Xác định thứ dựa trên ngày đã lấy
                int thu = (int)ngay.DayOfWeek;
                thu = thu == 0 ? 8 : thu + 1; // Chuyển đổi Sunday (0) thành 8, Monday (1) thành 2, ...

                // Kiểm tra định dạng tiết học
                if (!IsValidTietHocFormat(tietHoc))
                {
                    MessageBox.Show("Định dạng tiết học không hợp lệ! Vui lòng nhập theo định dạng: 1-3 hoặc 1,2,3",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<int> tietHocList = ParseTietHoc(tietHoc);

                // Kiểm tra xem đây là chế độ sửa hay thêm mới
                bool isEditMode = this.Tag != null && this.Tag is int && (int)this.Tag > 0;
                int maTKB = isEditMode ? (int)this.Tag : -1;

                // Nếu đang ở chế độ sửa, lấy thông tin tiết học cũ để không kiểm tra trùng với chính nó
                List<int> oldTiets = new List<int>();
                if (isEditMode)
                {
                    string queryOldTiet = "SELECT Tiet FROM ThoiKhoaBieu WHERE MaTKB = @MaTKB";
                    Dictionary<string, object> paramsOldTiet = new Dictionary<string, object> { { "@MaTKB", maTKB } };
                    DataTable dtOldTiet = db.ExecuteQuery(queryOldTiet, paramsOldTiet);

                    if (dtOldTiet.Rows.Count > 0)
                    {
                        string oldTiet = dtOldTiet.Rows[0]["Tiet"].ToString();
                        oldTiets = ParseTietHoc(oldTiet);
                    }
                }

                // Truy vấn tất cả các bản ghi thời khóa biểu trong cùng ngày của lớp đó
                string queryConflict = @"
                SELECT TKB.MaTKB, TKB.Tiet, MH.TenMon, GV.HoTen 
                FROM ThoiKhoaBieu TKB
                JOIN MonHoc MH ON TKB.MaMon = MH.MaMon
                JOIN GiaoVien GV ON TKB.MaGV = GV.MaGV
                WHERE TKB.MaLop = @MaLop 
                  AND CONVERT(DATE, TKB.Ngay) = CONVERT(DATE, @Ngay)";

                if (isEditMode)
                {
                    // Nếu đang sửa, loại trừ bản ghi hiện tại
                    queryConflict += " AND TKB.MaTKB <> @MaTKB";
                }

                Dictionary<string, object> parametersConflict = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@Ngay", ngay }
                };

                if (isEditMode)
                {
                    parametersConflict.Add("@MaTKB", maTKB);
                }

                DataTable dtConflict = db.ExecuteQuery(queryConflict, parametersConflict);

                // Kiểm tra xung đột tiết học
                bool hasConflict = false;
                List<int> conflictTiets = new List<int>();
                string conflictDetails = "";

                foreach (DataRow row in dtConflict.Rows)
                {
                    List<int> existingTiets = ParseTietHoc(row["Tiet"].ToString());
                    string monHoc = row["TenMon"].ToString();
                    string giaoVien = row["HoTen"].ToString();
                    int rowMaTKB = Convert.ToInt32(row["MaTKB"]);

                    foreach (int tiet in tietHocList)
                    {
                        // Kiểm tra nếu tiết này không thuộc về tiết cũ của bản ghi đang sửa và có xung đột với các tiết khác
                        if (existingTiets.Contains(tiet) && (rowMaTKB != maTKB || !isEditMode))
                        {
                            hasConflict = true;
                            if (!conflictTiets.Contains(tiet))
                            {
                                conflictTiets.Add(tiet);
                                conflictDetails += $"Tiết {tiet}: Môn {monHoc}, GV {giaoVien}\n";
                            }
                        }
                    }
                }

                if (hasConflict)
                {
                    conflictTiets.Sort();
                    string tietTrung = string.Join(", ", conflictTiets);
                    MessageBox.Show($"Không thể {(isEditMode ? "cập nhật" : "thêm")} thời khóa biểu vì tiết {tietTrung} đã bị trùng với lịch học hiện có!\nChi tiết:\n{conflictDetails}",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success;

                if (isEditMode)
                {
                    // Cập nhật bản ghi hiện có
                    string queryUpdate = @"
                    UPDATE ThoiKhoaBieu 
                    SET MaMon = @MaMon, MaGV = @MaGV, Ngay = @Ngay, Thu = @Thu, Tiet = @Tiet
                    WHERE MaTKB = @MaTKB";

                    Dictionary<string, object> parametersUpdate = new Dictionary<string, object>
                    {
                        { "@MaTKB", maTKB },
                        { "@MaMon", maMon },
                        { "@MaGV", maGV },
                        { "@Ngay", ngay },
                        { "@Thu", thu },
                        { "@Tiet", tietHoc }
                    };

                    success = db.ExecuteNonQuery(queryUpdate, parametersUpdate);
                }
                else
                {
                    // Thêm mới bản ghi
                    string queryInsert = @"
                    INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet)
                    VALUES ((SELECT ISNULL(MAX(MaTKB), 0) + 1 FROM ThoiKhoaBieu), @MaLop, @MaMon, @MaGV, @Ngay, @Thu, @Tiet)";

                    Dictionary<string, object> parametersInsert = new Dictionary<string, object>
                    {
                        { "@MaLop", maLop },
                        { "@MaMon", maMon },
                        { "@MaGV", maGV },
                        { "@Ngay", ngay },
                        { "@Thu", thu },
                        { "@Tiet", tietHoc }
                    };

                    success = db.ExecuteNonQuery(queryInsert, parametersInsert);
                }

                if (success)
                {
                    MessageBox.Show($"Thời khóa biểu đã được {(isEditMode ? "cập nhật" : "thêm")} thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"{(isEditMode ? "Cập nhật" : "Thêm")} thời khóa biểu thất bại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null) return;

            int maMon;
            if (cmbMonHoc.SelectedValue is DataRowView rowView)
            {
                maMon = Convert.ToInt32(rowView["MaMon"]);
            }
            else
            {
                maMon = Convert.ToInt32(cmbMonHoc.SelectedValue);
            }
            LoadGiaoVien(maMon);
        }

        private void frmQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            dtpNgayHoc.Value = ngayHoc;
            LoadMonHoc();
            
            // Đăng ký sự kiện
            cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;

            // Kiểm tra nếu đang sửa (tag chứa mã TKB)
            bool isEditMode = this.Tag != null && this.Tag is int && (int)this.Tag > 0;
            
            if (isEditMode)
            {
                int maTKB = (int)this.Tag;
                
                // Truy vấn thông tin thời khóa biểu cần sửa
                string query = @"
                SELECT t.MaMon, t.MaGV, t.Tiet, m.TenMon, g.HoTen
                FROM ThoiKhoaBieu t
                INNER JOIN MonHoc m ON t.MaMon = m.MaMon
                INNER JOIN GiaoVien g ON t.MaGV = g.MaGV
                WHERE t.MaTKB = @MaTKB";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTKB", maTKB }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int maMon = Convert.ToInt32(row["MaMon"]);
                    string tenMon = row["TenMon"].ToString();
                    
                    // Đặt giá trị mặc định cho ComboBox môn học
                    for (int i = 0; i < cmbMonHoc.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cmbMonHoc.Items[i];
                        if (Convert.ToInt32(drv["MaMon"]) == maMon)
                        {
                            cmbMonHoc.SelectedIndex = i;
                            break;
                        }
                    }
                    
                    // Load danh sách giáo viên theo môn
                    LoadGiaoVien(maMon);
                    
                    // Đặt giá trị mặc định cho ComboBox giáo viên
                    int maGV = Convert.ToInt32(row["MaGV"]);
                    string tenGV = row["HoTen"].ToString();
                    
                    for (int i = 0; i < cmbGiaoVien.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cmbGiaoVien.Items[i];
                        if (Convert.ToInt32(drv["MaGV"]) == maGV)
                        {
                            cmbGiaoVien.SelectedIndex = i;
                            break;
                        }
                    }
                    
                    // Đặt giá trị tiết học
                    txtTietHoc.Text = row["Tiet"].ToString();
                }
            }
            else
            {
                // Đặt môn học mặc định là môn đầu tiên nếu có dữ liệu
                if (cmbMonHoc.Items.Count > 0)
                {
                    cmbMonHoc.SelectedIndex = 0;
                    // LoadGiaoVien sẽ được gọi tự động thông qua sự kiện SelectedIndexChanged
                }
            }
        }
    }
}
