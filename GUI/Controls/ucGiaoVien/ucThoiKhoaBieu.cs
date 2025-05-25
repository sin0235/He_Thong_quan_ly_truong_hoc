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
    public partial class ucThoiKhoaBieu : UserControl
    {
        private readonly DatabaseHelper db;
        private int maNguoiDung;
        public ucThoiKhoaBieu(int maNguoiDung)
        {
            InitializeComponent();
            db = new DatabaseHelper();

            // Đặt giá trị mặc định cho DateTimePicker là ngày hiện tại ở Việt Nam
            DateTime vietnamNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
            ngayChonDTP.Value = vietnamNow;
            this.maNguoiDung = maNguoiDung;
            
            // Load dữ liệu thời khóa biểu ngay khi khởi tạo
            this.Load += (s, e) => LoadLichDay(maNguoiDung);
        }

        public void LoadLichDay(int maNguoiDung)
        {
            try
            {
                // Lấy ngày được chọn từ DateTimePicker
                DateTime selectedDate = ngayChonDTP.Value;

                // Tính ngày bắt đầu tuần (Thứ Hai) và ngày kết thúc tuần (Chủ Nhật)
                DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1); // Thứ Hai
                DateTime endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật

                // SQL query để lấy thời khóa biểu trong tuần
                string query = $@"
                    SELECT 
                        ThoiKhoaBieu.Ngay,
                        ThoiKhoaBieu.Thu,
                        ThoiKhoaBieu.Tiet,
                        MonHoc.TenMon,
                        LopHoc.TenLop
                    FROM ThoiKhoaBieu
                    INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
                    INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
                    INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
                    WHERE GiaoVien.MaNguoiDung = {maNguoiDung}
                      AND ThoiKhoaBieu.Ngay BETWEEN '{startOfWeek:yyyy-MM-dd}' AND '{endOfWeek:yyyy-MM-dd}'
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
                    string tenLop = row["TenLop"].ToString(); // Tên lớp

                    // Định dạng thông tin thời khóa biểu
                    string scheduleEntry = $"Tiết: {tiet}\nMôn: {tenMon}\nLớp: {tenLop}";
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

                // Tính tổng số tiết trong tuần
                int totalPeriods = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string tiet = row["Tiet"].ToString(); // Ví dụ: "1-3"
                    if (tiet.Contains("-"))
                    {
                        // Tách tiết bắt đầu và kết thúc
                        int startPeriod = int.Parse(tiet.Split('-')[0]);
                        int endPeriod = int.Parse(tiet.Split('-')[1]);
                        totalPeriods += (endPeriod - startPeriod + 1); // Tính số tiết
                    }
                    else
                    {
                        // Tiết đơn lẻ (ví dụ: "1")
                        totalPeriods += 1;
                    }
                }
                thongKeSoTietTxt.Text = $"{totalPeriods} Tiết";

                // Highlight cột của ngày hôm nay
                HightlightNgay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HightlightNgay()
        {
            // Lấy ngày hiện tại ở Việt Nam
            DateTime vietnamNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
            int today = (int)vietnamNow.DayOfWeek; // Chủ Nhật = 0, Thứ Hai = 1, ..., Thứ Bảy = 6

            // Nếu hôm nay là Chủ Nhật, thì chọn cột 6 (Chủ Nhật)
            int columnIndex = today == 0 ? 6 : today - 1;

            // Highlight cột của ngày hôm nay
            if (columnIndex >= 0 && columnIndex < dgvThoiKhoaBieu.Columns.Count)
            {
                dgvThoiKhoaBieu.Columns[columnIndex].HeaderCell.Style.BackColor = Color.YellowGreen; // Highlight màu
                dgvThoiKhoaBieu.Columns[columnIndex].HeaderCell.Style.ForeColor = Color.White; // Highlight chữ
            }

            dgvThoiKhoaBieu.Refresh();
        }

        private void ngayChonDTP_ValueChanged(object sender, EventArgs e)
        {
            LoadLichDay(maNguoiDung);
        }

        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadLichDay(maNguoiDung);
        }
    }
}


        