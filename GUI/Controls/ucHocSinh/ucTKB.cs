// GUI/Controls/ucHocSinh/ucTKB.cs
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

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTKB : UserControl
    {
        private DatabaseHelper dbHelper;
        private TKBDAO tkbDAL;
        private int currentWeek = 0;
        private int maxWeek = 0;
        private int id;
        private int maHS;
        private List<KhoangThoiGianDTO> periods;
        private int maLop;

        // Constructor với loading indicator
        public ucTKB(int maHS, int id)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            tkbDAL = new TKBDAO();
            this.id = id;
            this.maHS = maHS;

            // Khởi tạo loading indicator
            loadingIndicator = new Guna.UI2.WinForms.Guna2ProgressIndicator
            {
                AutoStart = false,
                Size = new Size(60, 60),
                Location = new Point((pnlContent.Width - 60) / 2, (pnlContent.Height - 60) / 2),
                Anchor = AnchorStyles.None,
                UseTransparentBackground = true,
                Visible = false
            };
            pnlContent.Controls.Add(loadingIndicator);
            loadingIndicator.BringToFront();
        }

        private void ucTKB_Load(object sender, EventArgs e)
        {
            // Lấy thông tin lớp của học sinh
            DataRow classInfo = tkbDAL.GetClassInfo(maHS);
            if (classInfo != null)
            {
                maLop = Convert.ToInt32(classInfo["MaLop"]);
                LoadSchoolYears();
                InitializeTimetableLayout(); // Đảm bảo bảng được khởi tạo
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin lớp của học sinh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.BeginInvoke(new Action(() =>
            {
                TableLayoutPanel1_Resize(tableLayoutPanel1, EventArgs.Empty);
            }));
        }

        // Override OnResize để giữ loading indicator ở giữa
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (loadingIndicator != null)
            {
                loadingIndicator.Location = new Point(
                    (pnlContent.Width - loadingIndicator.Width) / 2,
                    (pnlContent.Height - loadingIndicator.Height) / 2);
            }
        }

        #region Các phương thức xử lý sự kiện

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimePeriods();
        }

        private void cboTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuan.SelectedIndex >= 0)
            {
                currentWeek = cboTuan.SelectedIndex;
                LoadTimetable();
            }
        }

        private void btnTuanTruoc_Click(object sender, EventArgs e)
        {
            if (currentWeek > 0)
            {
                currentWeek--;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần đầu tiên của năm học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTuanHienTai_Click(object sender, EventArgs e)
        {
            SetCurrentPeriod();
        }

        private void btnTuanTiepTheo_Click(object sender, EventArgs e)
        {
            if (currentWeek < maxWeek - 1)
            {
                currentWeek++;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần cuối cùng của năm học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            // Duyệt qua tất cả các panel tiêu đề và cập nhật vị trí căn giữa của labels
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                Control header = tableLayoutPanel1.GetControlFromPosition(col, 0);
                if (header != null && header is Guna.UI2.WinForms.Guna2Panel headerPanel)
                {
                    foreach (Control ctrl in headerPanel.Controls)
                    {
                        if (ctrl is Guna.UI2.WinForms.Guna2HtmlLabel dayLabel)
                        {
                            // Đảm bảo label luôn căn giữa
                            dayLabel.TextAlignment = ContentAlignment.MiddleCenter;
                        }
                    }
                }
            }

            // Cập nhật kích thước cho các FlowLayoutPanel trong các ngày
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                Control dayPanel = tableLayoutPanel1.GetControlFromPosition(col, 1);
                if (dayPanel != null && dayPanel is Guna.UI2.WinForms.Guna2Panel panel)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is FlowLayoutPanel flowPanel)
                        {
                            // Với các item trong FlowLayoutPanel, cập nhật chiều rộng của chúng
                            foreach (Control item in flowPanel.Controls)
                            {
                                if (item is ucTKBItem tkbItem)
                                {
                                    tkbItem.Width = flowPanel.Width - 20; // Giữ lại khoảng trống bên lề
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Các phương thức xử lý dữ liệu

        private void LoadSchoolYears()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<string> years = tkbDAL.GetSchoolYears();

                cboNamHoc.Items.Clear();
                foreach (string year in years)
                {
                    cboNamHoc.Items.Add(year);
                }

                // Lấy năm học hiện tại
                string currentYear;
                if (tkbDAL.SetupCurrentSchoolYear(out currentYear) && !string.IsNullOrEmpty(currentYear))
                {
                    int index = cboNamHoc.Items.IndexOf(currentYear);
                    if (index >= 0)
                    {
                        cboNamHoc.SelectedIndex = index;
                    }
                    else if (cboNamHoc.Items.Count > 0)
                    {
                        cboNamHoc.SelectedIndex = 0;
                    }
                }
                else if (cboNamHoc.Items.Count > 0)
                {
                    cboNamHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadTimePeriods()
        {
            try
            {
                if (cboNamHoc.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn năm học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedYear = cboNamHoc.SelectedItem.ToString();

                // Gọi phương thức GetTimePeriods từ TKBDAO
                periods = tkbDAL.GetTimePeriods(selectedYear);

                if (periods == null || periods.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu thời gian cho năm học này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTuan.Items.Clear();
                    return;
                }

                // Cập nhật maxWeek
                maxWeek = periods.Count;

                // Xóa các mục cũ và thêm khoảng thời gian mới vào combo box
                cboTuan.Items.Clear();
                foreach (var period in periods)
                {
                    cboTuan.Items.Add(period.ToString());
                }

                // Xác định khoảng thời gian hiện tại
                currentWeek = tkbDAL.GetCurrentPeriodIndex(periods);
                if (cboTuan.Items.Count > 0)
                {
                    cboTuan.SelectedIndex = currentWeek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thời gian: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCurrentPeriod()
        {
            try
            {
                if (periods != null && periods.Count > 0)
                {
                    currentWeek = tkbDAL.GetCurrentPeriodIndex(periods);
                    if (currentWeek >= 0 && currentWeek < cboTuan.Items.Count)
                    {
                        cboTuan.SelectedIndex = currentWeek;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác định thời gian hiện tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTimetable()
        {
            if (periods == null || currentWeek < 0 || currentWeek >= periods.Count)
                return;

            // Hiển thị loading indicator
            pnlNoData.Visible = false;
            tableLayoutPanel1.Visible = false;
            loadingIndicator.Visible = true;
            loadingIndicator.Start();

            // Sử dụng BeginInvoke để cho phép UI cập nhật trước khi xử lý
            BeginInvoke(new Action(() =>
            {
                try
                {
                    KhoangThoiGianDTO selectedPeriod = periods[currentWeek];
                    List<TKBDTO> timetable = tkbDAL.GetTimetable(maLop, selectedPeriod.NgayBatDau, selectedPeriod.NgayKetThuc);

                    // Xóa dữ liệu thời khóa biểu cũ
                    ClearTimetable();

                    // Hiển thị thời khóa biểu mới
                    DisplayTimetable(timetable);

                    // Hiển thị UI phù hợp dựa trên dữ liệu
                    tableLayoutPanel1.Visible = true;
                    pnlNoData.Visible = timetable.Count == 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnlNoData.Visible = true;
                    tableLayoutPanel1.Visible = true;
                }
                finally
                {
                    // Ẩn loading indicator
                    loadingIndicator.Stop();
                    loadingIndicator.Visible = false;

                    // Đảm bảo UI được làm mới
                    Refresh();
                }
            }));
        }

        #endregion

        #region Phương thức hiển thị thời khóa biểu

        private void InitializeTimetableLayout()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 1; // Chỉ 1 hàng cho tiêu đề
            tableLayoutPanel1.ColumnCount = 6; // Tổng số cột (6 ngày từ thứ 2 đến thứ 7)

            // Thiết lập lại row styles
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            // Thiết lập lại column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 6));
            }

            // Tên các ngày trong tuần
            string[] dayNames = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };

            // Thêm các tiêu đề ngày
            for (int col = 0; col < dayNames.Length; col++)
            {
                Guna.UI2.WinForms.Guna2Panel headerPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Dock = DockStyle.Fill,
                    FillColor = Color.FromArgb(100, 120, 230),
                    BorderRadius = 5,
                    Margin = new Padding(2),
                    Tag = col, // Lưu trữ chỉ số cột để tham chiếu
                };

                Guna.UI2.WinForms.Guna2HtmlLabel dayLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = dayNames[col],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    TextAlignment = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                };

                headerPanel.Controls.Add(dayLabel);
                tableLayoutPanel1.Controls.Add(headerPanel, col, 0);
            }

            // Thêm một hàng cho nội dung
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Thêm các panel cho các ngày trong tuần
            for (int col = 0; col < 6; col++)
            {
                Guna.UI2.WinForms.Guna2Panel dayPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Dock = DockStyle.Fill,
                    FillColor = Color.FromArgb(250, 250, 250),
                    BorderRadius = 5,
                    BorderColor = Color.FromArgb(230, 230, 230),
                    BorderThickness = 1,
                    Margin = new Padding(3),
                    Padding = new Padding(5),
                };

                // Tạo FlowLayoutPanel để chứa các môn học
                FlowLayoutPanel flowLayout = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    BackColor = Color.Transparent,
                };

                dayPanel.Controls.Add(flowLayout);
                tableLayoutPanel1.Controls.Add(dayPanel, col, 1);
            }

            // Đăng ký sự kiện resize cho tableLayoutPanel
            tableLayoutPanel1.Resize += TableLayoutPanel1_Resize;
        }

        private void DisplayTimetable(List<TKBDTO> timetable)
        {
            // Đảm bảo bảng được khởi tạo đúng
            if (tableLayoutPanel1.RowStyles.Count < 2)
            {
                InitializeTimetableLayout();
            }

            // Xóa dữ liệu cũ
            ClearDayPanels();

            // Nhóm các lớp học theo ngày
            var timetableByDay = timetable.GroupBy(t => t.Thu)
                    .ToDictionary(g => g.Key, g => g.ToList());

            // Sắp xếp các môn học theo tiết bắt đầu
            foreach (var dayGroup in timetableByDay)
            {
                int thu = dayGroup.Key;
                List<TKBDTO> monHocTrongNgay = dayGroup.Value
                    .OrderBy(m => ParseTietInfo(m.Tiet).Item1)
                    .ToList();

                if (thu >= 2 && thu <= 7) // Thứ 2 đến thứ 7
                {
                    int columnIndex = thu - 2; // Điều chỉnh chỉ số cột (2-7 -> 0-5)

                    // Lấy FlowLayoutPanel của ngày
                    FlowLayoutPanel dayFlow = GetDayFlowPanel(columnIndex);
                    if (dayFlow != null)
                    {
                        // Thêm các môn học vào panel
                        foreach (var item in monHocTrongNgay)
                        {
                            ucTKBItem tkbItem = new ucTKBItem
                            {
                                MonHoc = item.TenMon,
                                GiaoVien = item.TenGiaoVien,
                                ThoiGian = GetThoiGianTuTiet(ParseTietInfo(item.Tiet).Item1),
                                NoiDung = $"Tiết {item.Tiet}",
                                Tiet = ParseTietInfo(item.Tiet).Item1,
                                Width = dayFlow.Width - 20, // Chiều rộng phù hợp với flow panel
                                Margin = new Padding(0, 0, 0, 5),
                            };

                            dayFlow.Controls.Add(tkbItem);
                        }
                    }
                }
            }
        }

        // Phương thức để lấy FlowLayoutPanel cho mỗi ngày
        private FlowLayoutPanel GetDayFlowPanel(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= tableLayoutPanel1.ColumnCount)
                return null;

            Control dayPanel = tableLayoutPanel1.GetControlFromPosition(columnIndex, 1);
            if (dayPanel != null && dayPanel is Guna.UI2.WinForms.Guna2Panel)
            {
                foreach (Control ctrl in dayPanel.Controls)
                {
                    if (ctrl is FlowLayoutPanel)
                        return ctrl as FlowLayoutPanel;
                }
            }
            return null;
        }

        // Xóa dữ liệu cũ từ các panel ngày
        private void ClearDayPanels()
        {
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                FlowLayoutPanel dayFlow = GetDayFlowPanel(col);
                if (dayFlow != null)
                {
                    dayFlow.Controls.Clear();
                }
            }
        }

        // Phương thức xóa thời khóa biểu
        private void ClearTimetable()
        {
            ClearDayPanels();
        }

        #endregion

        #region Các phương thức phụ trợ

        private Tuple<int, int> ParseTietInfo(string tiet)
        {
            // Phân tích chuỗi tiết học (ví dụ: "1-3")
            try
            {
                string[] parts = tiet.Split('-');
                if (parts.Length == 2)
                {
                    int start = int.Parse(parts[0]);
                    int end = int.Parse(parts[1]);
                    return new Tuple<int, int>(start, end);
                }
                else
                {
                    int singleTiet = int.Parse(tiet);
                    return new Tuple<int, int>(singleTiet, singleTiet);
                }
            }
            catch
            {
                return new Tuple<int, int>(1, 1); // Giá trị mặc định
            }
        }

        private string GetThoiGianTuTiet(int tiet)
        {
            switch (tiet)
            {
                case 1: return "07:30 - 08:15";
                case 2: return "08:20 - 09:05";
                case 3: return "09:20 - 10:05";
                case 4: return "10:10 - 10:55";
                case 5: return "11:00 - 11:45";
                // Nghỉ trưa
                case 7: return "13:30 - 14:15";
                case 8: return "14:20 - 15:05";
                case 9: return "15:15 - 16:00";
                case 10: return "16:05 - 16:50";
                default: return $"Tiết {tiet}";
            }
        }

        private Color GetSubjectColor(int maMon)
        {
            // Tạo màu ngẫu nhiên nhưng ổn định cho từng môn học
            Random rnd = new Random(maMon);
            return Color.FromArgb(rnd.Next(180, 240), rnd.Next(180, 240), rnd.Next(180, 240));
        }

        #endregion

        // Biến loading indicator
        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingIndicator;
    }
}
