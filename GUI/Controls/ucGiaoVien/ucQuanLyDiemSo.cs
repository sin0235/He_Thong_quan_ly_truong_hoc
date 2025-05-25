using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;
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
    public partial class ucQuanLyDiemSo : UserControl
    {
        private int MaNguoiDung;
        private int MaGiaoVien;
        private readonly DatabaseHelper db;

        public ucQuanLyDiemSo(int maNguoiDung, int maGiaoVien)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            MaNguoiDung = maNguoiDung;
            MaGiaoVien = maGiaoVien;
            
            // Thêm sự kiện Load để đảm bảo form được khởi tạo hoàn tất trước khi load dữ liệu
            this.Load += (s, e) => lamMoiBtn_Click(this, EventArgs.Empty);
        }
        private void LoadDiem()
        {
            try
            {
                if (lopCmb.SelectedValue == null || monCmb.SelectedValue == null || hocKyCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp, môn học và học kỳ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lấy giá trị từ các ComboBox
                int maLop = Convert.ToInt32(lopCmb.SelectedValue);
                int maMon = Convert.ToInt32(monCmb.SelectedValue);
                int hocKy = ((KeyValuePair<int, string>)hocKyCmb.SelectedItem).Key;
                // Truy vấn để lấy danh sách học sinh và điểm số
                string queryDiem = $@"
                    SELECT 
                        HS.MaHS, 
                        ROW_NUMBER() OVER (ORDER BY HS.HoTen ASC) AS STT,
                        HS.HoTen AS HoTen,
                        DS.HocKy AS HocKy,
                        STRING_AGG(CASE WHEN DS.LoaiDiem = N'Miệng' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemMieng,
                        STRING_AGG(CASE WHEN DS.LoaiDiem = N'15 phút' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS Diem15Phut,
                        STRING_AGG(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemGiuaKy,
                        STRING_AGG(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS DiemCuoiKy,
                        ROUND(
                            (
                                ISNULL(SUM(CASE WHEN DS.LoaiDiem IN (N'Miệng', N'15 phút') THEN DS.Diem END), 0) + 
                                2 * ISNULL(AVG(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN DS.Diem END), 0) + 
                                3 * ISNULL(AVG(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN DS.Diem END), 0)
                            ) / 
                            (
                                NULLIF(COUNT(CASE WHEN DS.LoaiDiem IN (N'Miệng', N'15 phút') THEN 1 END), 0) + 5
                            ), 2
                        ) AS DiemTB
                    FROM HocSinh HS
                    LEFT JOIN DiemSo DS ON HS.MaHS = DS.MaHS AND DS.MaMon = {maMon} AND DS.HocKy = {hocKy}
                    WHERE HS.MaLop = {maLop}
                    GROUP BY HS.MaHS, HS.HoTen, DS.HocKy";


                DataTable dtDiem = db.ExecuteQuery(queryDiem);

                if (dtDiem.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu điểm cho lớp, môn học và học kỳ đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvDanhSachHocSinh.AutoGenerateColumns = false;
                dgvDanhSachHocSinh.DataSource = dtDiem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void themDiemBtn_Click(object sender, EventArgs e)
        {
            if (monCmb.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một môn học trước khi thêm điểm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = Convert.ToInt32(monCmb.SelectedValue);
            frmNhapDiem frm = new frmNhapDiem(MaGiaoVien, maMon, this.dgvDanhSachHocSinh);
            frm.ShowDialog();
        }


        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách lớp và môn học từ cơ sở dữ liệu
                string queryLopMon = $@"
                    SELECT DISTINCT LH.MaLop, LH.TenLop, MH.MaMon, MH.TenMon
                    FROM LopHoc LH
                    INNER JOIN ThoiKhoaBieu TKB ON LH.MaLop = TKB.MaLop
                    INNER JOIN MonHoc MH ON TKB.MaMon = MH.MaMon
                    WHERE TKB.MaGV = {MaGiaoVien}";

                DataTable dtLopMon = db.ExecuteQuery(queryLopMon);

                if (dtLopMon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lớp hoặc môn học nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lọc danh sách lớp và môn học
                lopCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaLop", "TenLop");
                lopCmb.DisplayMember = "TenLop";
                lopCmb.ValueMember = "MaLop";

                monCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaMon", "TenMon");
                monCmb.DisplayMember = "TenMon";
                monCmb.ValueMember = "MaMon";

                // Tạo danh sách học kỳ
                var hocKyOptions = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Kỳ 1"),
                    new KeyValuePair<int, string>(2, "Kỳ 2")
                };

                // Gán danh sách học kỳ vào ComboBox
                hocKyCmb.DataSource = hocKyOptions;
                hocKyCmb.DisplayMember = "Value";
                hocKyCmb.ValueMember = "Key";

                // Đặt giá trị mặc định cho các ComboBox
                if (lopCmb.Items.Count > 0) lopCmb.SelectedIndex = 0;
                if (monCmb.Items.Count > 0) monCmb.SelectedIndex = 0;
                if (hocKyCmb.Items.Count > 0) hocKyCmb.SelectedIndex = 0;

                LoadDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void locBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedLop = lopCmb.SelectedValue;
                var selectedMon = monCmb.SelectedValue;

                // Lọc danh sách lớp và môn học
                string queryLop = $@"
                    SELECT DISTINCT LH.MaLop, LH.TenLop
                    FROM LopHoc LH
                    INNER JOIN ThoiKhoaBieu TKB ON LH.MaLop = TKB.MaLop
                    WHERE TKB.MaGV = {MaGiaoVien}";
                DataTable dtLop = db.ExecuteQuery(queryLop);

                if (dtLop.Rows.Count > 0)
                {
                    lopCmb.DataSource = dtLop;
                    lopCmb.DisplayMember = "TenLop";
                    lopCmb.ValueMember = "MaLop";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Lớp phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Lọc danh sách môn học
                string queryMon = $@"
                    SELECT DISTINCT MH.MaMon, MH.TenMon
                    FROM MonHoc MH
                    INNER JOIN ThoiKhoaBieu TKB ON MH.MaMon = TKB.MaMon
                    WHERE TKB.MaGV = {MaGiaoVien}";
                DataTable dtMon = db.ExecuteQuery(queryMon);

                if (dtMon.Rows.Count > 0)
                {
                    monCmb.DataSource = dtMon;
                    monCmb.DisplayMember = "TenMon";
                    monCmb.ValueMember = "MaMon";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Môn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
                if (selectedLop != null && dtLop.AsEnumerable().Any(row => row.Field<int>("MaLop") == (int)selectedLop))
                {
                    //  Nếu lớp đã chọn tồn tại trong danh sách lớp, chọn lớp đó
                    lopCmb.SelectedValue = selectedLop;
                }
                else if (lopCmb.Items.Count > 0)
                {
                    // Nếu lớp đã chọn không tồn tại trong danh sách lớp, chọn lớp đầu tiên
                    lopCmb.SelectedIndex = 0;
                }

                if (selectedMon != null && dtMon.AsEnumerable().Any(row => row.Field<int>("MaMon") == (int)selectedMon))
                {
                    monCmb.SelectedValue = selectedMon;
                }
                else if (monCmb.Items.Count > 0)
                {
                    monCmb.SelectedIndex = 0;
                }

                LoadDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void chinhSuaDiemBtn_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.SelectedRows.Count > 0)
            {
                var maHSCell = dgvDanhSachHocSinh.SelectedRows[0].Cells["MaHS"];
                if (maHSCell == null || maHSCell.Value == null)
                {
                    MessageBox.Show("Không thể lấy mã học sinh. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy mã học sinh từ ô được chọn
                int maHS = Convert.ToInt32(maHSCell.Value);

                if (monCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một môn học.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maMon = Convert.ToInt32(monCmb.SelectedValue);

                frmChinhSuaDiem frm = new frmChinhSuaDiem(maHS, maMon, this.dgvDanhSachHocSinh);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh để chỉnh sửa điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hocKyCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hocKyCmb.SelectedValue != null)
            {
                LoadDiem();
            }
        }

        private void lopCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loaiDiemCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}
