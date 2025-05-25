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
    public partial class ucQuanLyKeHoachGiangDay : UserControl
    {
        private readonly DatabaseHelper db;
        private int selectedMaKH = -1;
        private int maGV;
        public ucQuanLyKeHoachGiangDay(int maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
            db = new DatabaseHelper();
            LoadMonHoc();
            LoadLopHoc();
            LoadKeHoachGiangDay();
            LoadWeeks();
        }

        private void LoadMonHoc()
        {
            string query = "SELECT MaMon, TenMon FROM MonHoc";
            DataTable dt = db.ExecuteQuery(query);
            cbMonHoc.DataSource = dt;
            cbMonHoc.DisplayMember = "TenMon";
            cbMonHoc.ValueMember = "MaMon";
        }

        private void LoadLopHoc()
        {
            string query = "SELECT MaLop, TenLop FROM LopHoc";
            DataTable dt = db.ExecuteQuery(query);
            cbLopHoc.DataSource = dt;
            cbLopHoc.DisplayMember = "TenLop";
            cbLopHoc.ValueMember = "MaLop";
        }
        private void LoadWeeks()
        {
            cbTuan.Items.Clear();
            for (int i = 1; i <= 52; i++) // Giả sử có 52 tuần trong năm
            {
                cbTuan.Items.Add($"Tuần {i}");
            }
            cbTuan.SelectedIndex = 0; // Chọn tuần đầu tiên mặc định
        }

        private void LoadKeHoachGiangDay()
        {
            try
            {
                string query = $@"
            SELECT kh.MaKH, mh.TenMon, lh.TenLop, kh.Tuan, kh.NoiDungGiangDay
            FROM KeHoachGiangDay kh
            JOIN MonHoc mh ON kh.MaMon = mh.MaMon
            JOIN LopHoc lh ON kh.MaLop = lh.MaLop
            WHERE kh.MaGV = {maGV}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt == null)
                {
                    MessageBox.Show("Lỗi: DataTable is null", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvKeHoach.AutoGenerateColumns = false;
                dgvKeHoach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nội dung không được trống
                if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
                {
                    MessageBox.Show("Vui lòng nhập nội dung kế hoạch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maMon = Convert.ToInt32(cbMonHoc.SelectedValue);
                int maLop = Convert.ToInt32(cbLopHoc.SelectedValue);
                int tuan = cbTuan.SelectedIndex + 1;
                string noiDung = txtNoiDung.Text;

                // Lấy MaKH mới
                string getMaxIDQuery = "SELECT ISNULL(MAX(MaKH), 0) + 1 FROM KeHoachGiangDay";
                int maKH = Convert.ToInt32(db.ExecuteScalar(getMaxIDQuery));

                string query = $@"
                    INSERT INTO KeHoachGiangDay (MaKH, MaGV, MaMon, MaLop, Tuan, NoiDungGiangDay)
                    VALUES ({maKH}, {maGV}, {maMon}, {maLop}, {tuan}, N'{noiDung.Replace("'", "''")}')";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Thêm kế hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKeHoachGiangDay();
                    txtNoiDung.Clear();
                    cbTuan.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Thêm kế hoạch thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (selectedMaKH == -1)
            {
                MessageBox.Show("Vui lòng chọn kế hoạch để chỉnh sửa!");
                return;
            }

            try
            {
                int maMon = Convert.ToInt32(cbMonHoc.SelectedValue);
                int maLop = Convert.ToInt32(cbLopHoc.SelectedValue);
                string noiDung = txtNoiDung.Text;
                
                string query = $@"
                    UPDATE KeHoachGiangDay
                    SET MaMon = {maMon}, MaLop = {maLop}, NoiDungGiangDay = N'{noiDung.Replace("'", "''")}'
                    WHERE MaKH = {selectedMaKH}";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Chỉnh sửa kế hoạch thành công!");
                    LoadKeHoachGiangDay();
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa kế hoạch thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaKH == -1)
            {
                MessageBox.Show("Vui lòng chọn kế hoạch để xóa!");
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa kế hoạch này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string query = $@"
                DELETE FROM KeHoachGiangDay
                WHERE MaKH = {selectedMaKH}";

                    if (db.ExecuteNonQuery(query))
                    {
                        MessageBox.Show("Xóa kế hoạch thành công!");
                        LoadKeHoachGiangDay();
                    }
                    else
                    {
                        MessageBox.Show("Xóa kế hoạch thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void dgvKeHoach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKeHoach.Rows[e.RowIndex];
                    selectedMaKH = Convert.ToInt32(row.Cells["MaKH"].Value);

                    // Lấy MaMon và MaLop từ database dựa vào MaKH
                    string query = $@"
                        SELECT MaMon, MaLop, Tuan, NoiDungGiangDay 
                        FROM KeHoachGiangDay 
                        WHERE MaKH = {selectedMaKH}";

                    DataTable dt = db.ExecuteQuery(query);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Load dữ liệu cho cho combobox
                        cbMonHoc.SelectedValue = dt.Rows[0]["MaMon"];
                        cbLopHoc.SelectedValue = dt.Rows[0]["MaLop"];

                        // Set tuần
                        int tuan = Convert.ToInt32(dt.Rows[0]["Tuan"]);
                        cbTuan.SelectedIndex = tuan - 1; // Trừ 1 vì index bắt đầu từ 0

                        // Set nội dung
                        txtNoiDung.Text = dt.Rows[0]["NoiDungGiangDay"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


