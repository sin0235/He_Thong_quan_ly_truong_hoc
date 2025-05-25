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

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucGuiThu : UserControl
    {
        public ucGuiThu()
        {
            InitializeComponent();
        }

        // Lấy mã nhật ký tiếp theo
        private int GetNextMaNK(DatabaseHelper db)
        {
            string query = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
            DataTable result = db.ExecuteQuery(query);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0][0]) : 1;
        }

        // Ghi nhật ký hệ thống
        private void GhiNhatKy(DatabaseHelper db, string hanhDong)
        {
            try
            {
                int maNK = GetNextMaNK(db);
                // Sử dụng tham số để tránh SQL Injection
                string query = @"
                INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNK", maNK },
                    { "@MaNguoiDung", 1 }, // Giả sử là người dùng với MaNguoiDung = 1 (Ban giám hiệu)
                    { "@HanhDong", hanhDong }
                };
                
                db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi nhật ký: {ex.Message}");
                // Không hiển thị lỗi cho người dùng vì đây là chức năng phụ
            }
        }

        private void cbLopCụThe_CheckedChanged(object sender, EventArgs e)
        {
            lblNhapLop.Visible = cbLopCuThe.Checked;
            txtNhapLop.Visible = cbLopCuThe.Checked;
            if (cbLopCuThe.Checked)
            {
                cbTatCa.Checked = false; 
            }
        }

        private void cbCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            lblNhapMaCaNhan.Visible = cbCaNhan.Checked;
            txtNhapMaCaNhan.Visible = cbCaNhan.Checked;
            if (cbCaNhan.Checked)
            {
                cbTatCa.Checked = false;
            }
        }


        private void btnHuyBo_Click(object sender, EventArgs e)
 {
     txtTieuDe.Text = "";
    txtNoiDung.Text = "";
    txtNhapLop.Text = "";
    txtNhapMaCaNhan.Text = "";
     cbTatCa.Checked = false;
     cbLopCuThe.Checked = false;
    cbGiaoVien.Checked = false;
    cbHocSinh.Checked = false;
     cbPhongNoiVu.Checked = false;
     cbCaNhan.Checked = false;
 }
 
        private void cbPhongNoiVu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPhongNoiVu.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        public void cbGiaoVien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGiaoVien.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        private void cbHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHocSinh.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        private void cbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTatCa.Checked)
            {
                cbGiaoVien.Checked = false;
                cbHocSinh.Checked = false;
                cbLopCuThe.Checked = false;
                cbPhongNoiVu.Checked = false;
                cbCaNhan.Checked = false;
                lblNhapLop.Visible = false;
                txtNhapLop.Visible = false;
                lblNhapMaCaNhan.Visible = false;
                txtNhapMaCaNhan.Visible = false;
            }
        }
        private void ucGuiThu_Load(object sender, EventArgs e)
        {

        }

        private void btnGuiThu_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề và nội dung.");
                return;
            }

            DatabaseHelper db = null;
            bool isSuccess = true;

            try
            {
                db = new DatabaseHelper();
                db.OpenConnection();

                if (cbTatCa.Checked)
                {
                    isSuccess = GuiThuTatCa(db, tieuDe, noiDung) && isSuccess;
                }
                else
                {
                    isSuccess = GuiThuTheoLuaChon(db, tieuDe, noiDung) && isSuccess;
                }

                if (isSuccess)
                {
                    MessageBox.Show("Gửi thư thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Một số thư không được gửi thành công. Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi thư: " + ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    db.CloseConnection();
                }
            }
        }

        // Gửi thư đến tất cả người dùng
        private bool GuiThuTatCa(DatabaseHelper db, string tieuDe, string noiDung)
        {
            bool isSuccess = true;

            string query = "SELECT MaNguoiDung FROM NguoiDung WHERE MaNguoiDung != 1";
            DataTable nguoiDungTable = db.ExecuteQuery(query);

            foreach (DataRow row in nguoiDungTable.Rows)
            {
                int maNguoiNhan = Convert.ToInt32(row["MaNguoiDung"]);
                string insertQuery = $@"
                INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, TieuDe, NoiDung, NgayGui)
                VALUES (1, {maNguoiNhan}, N'{tieuDe}', N'{noiDung}', GETDATE());";

                if (!db.ExecuteNonQuery(insertQuery))
                {
                    isSuccess = false;
                }
            }

            GhiNhatKy(db, "Gửi thư cho tất cả mọi người");
            return isSuccess;
        }

        // Gửi thư theo lựa chọn
        private bool GuiThuTheoLuaChon(DatabaseHelper db, string tieuDe, string noiDung)
        {
            bool isSuccess = true;

            if (cbGiaoVien.Checked)
            {
                isSuccess = GuiThuTheoVaiTro(db, 3, tieuDe, noiDung) && isSuccess;
                GhiNhatKy(db, "Gửi thư cho giáo viên");
            }

            if (cbHocSinh.Checked)
            {
                isSuccess = GuiThuTheoVaiTro(db, 4, tieuDe, noiDung) && isSuccess;
                GhiNhatKy(db, "Gửi thư cho học sinh");
            }

            if (cbLopCuThe.Checked)
            {
                string[] lopList = txtNhapLop.Text.Split(',');
                foreach (string lop in lopList)
                {
                    string insertQuery = $@"
                    INSERT INTO ThongBao (MaNguoiGui, MaLop, TieuDe, NoiDung, NgayGui)
                    SELECT 1, MaLop, N'{tieuDe}', N'{noiDung}', GETDATE()
                    FROM LopHoc
                    WHERE TenLop = '{lop.Trim()}';";

                    if (!db.ExecuteNonQuery(insertQuery))
                    {
                        isSuccess = false;
                    }
                }
                GhiNhatKy(db, "Gửi thư cho lớp cụ thể");
            }

            if (cbPhongNoiVu.Checked)
            {
                isSuccess = GuiThuTheoVaiTro(db, 2, tieuDe, noiDung) && isSuccess;
                GhiNhatKy(db, "Gửi thư cho phòng nội vụ");
            }

            if (cbCaNhan.Checked)
            {
                string danhSachMaCaNhan = txtNhapMaCaNhan.Text.Trim();
                List<string> nguoiNhanList = GuiThuCaNhan(db, danhSachMaCaNhan, tieuDe, noiDung);

                if (nguoiNhanList.Count == 0)
                {
                    isSuccess = false;
                }
            }

            return isSuccess;
        }

        // Gửi thư theo vai trò
        private bool GuiThuTheoVaiTro(DatabaseHelper db, int maVaiTro, string tieuDe, string noiDung)
        {
            string query = $@"
            INSERT INTO ThongBao (MaNguoiGui, MaVaiTroNhan, TieuDe, NoiDung, NgayGui)
            VALUES (1, {maVaiTro}, N'{tieuDe}', N'{noiDung}', GETDATE());";
            return db.ExecuteNonQuery(query);
        }

        // Gửi thư đến cá nhân
        private List<string> GuiThuCaNhan(DatabaseHelper db, string danhSachMaCaNhan, string tieuDe, string noiDung)
        {
            string[] maCaNhanList = danhSachMaCaNhan.Split(',');
            List<string> danhSachNguoiNhan = new List<string>();

            foreach (string maCaNhan in maCaNhanList)
            {
                string maCaNhanTrimmed = maCaNhan.Trim();
                string query = $@"
                SELECT ND.MaNguoiDung, ND.TenDangNhap, VT.TenVaiTro, GV.HoTen AS TenDayDu
                FROM GiaoVien GV
                INNER JOIN NguoiDung ND ON GV.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                WHERE GV.MaGV = {maCaNhanTrimmed}";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    query = $@"
                    SELECT ND.MaNguoiDung, ND.TenDangNhap, VT.TenVaiTro, HS.HoTen AS TenDayDu
                    FROM HocSinh HS
                    INNER JOIN NguoiDung ND ON HS.MaNguoiDung = ND.MaNguoiDung
                    LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                    WHERE HS.MaHS = {maCaNhanTrimmed}";
                    result = db.ExecuteQuery(query);
                }

                if (result.Rows.Count > 0)
                {
                    int maNguoiNhan = Convert.ToInt32(result.Rows[0]["MaNguoiDung"]);
                    string tenNguoiNhan = result.Rows[0]["TenDayDu"].ToString();
                    string vaiTro = result.Rows[0]["TenVaiTro"].ToString();

                    string insertQuery = $@"
                    INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, TieuDe, NoiDung, NgayGui)
                    VALUES (1, {maNguoiNhan}, N'{tieuDe}', N'{noiDung}', GETDATE());";
                    db.ExecuteNonQuery(insertQuery);
                    GhiNhatKy(db, $"Gửi thư cho cá nhân: {vaiTro} {tenNguoiNhan}");

                    danhSachNguoiNhan.Add($"{vaiTro} {tenNguoiNhan}");
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy người nhận với mã: {maCaNhanTrimmed}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return danhSachNguoiNhan;
        }
    }
}
