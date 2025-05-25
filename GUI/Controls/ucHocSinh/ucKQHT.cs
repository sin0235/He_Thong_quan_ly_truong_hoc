using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucKQHT : UserControl
    {
        private DatabaseHelper dbHelper;
        private DiemSoDAO diemSoDAL;
        private int id;
        private int maNguoiDung;
        private string currentSchoolYear;
        private int currentSemester = 1;

        public ucKQHT(int MaHS, int ID)
        {
            InitializeComponent();
            id = MaHS;          // Mã học sinh
            maNguoiDung = ID;   // Mã người dùng

            dbHelper = new DatabaseHelper();
            diemSoDAL = new DiemSoDAO();

            this.Load += ucKQHT_Load;
        }

        private void ucKQHT_Load(object sender, EventArgs e)
        {
            try
            {
                if (id <= 0)
                {
                    MessageBox.Show("Không thể tải dữ liệu vì mã học sinh không hợp lệ!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadSchoolYears();
                SetupButtonEvents();
                InitializeUI();
                SetupEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            btnHK1.FillColor = Color.FromArgb(94, 148, 255);
            btnHK1.ForeColor = Color.White;
            btnHK2.FillColor = Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.FillColor = Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.Text = "Cả năm";

            if (cboNamHoc.Items.Count > 0)
                cboNamHoc.SelectedIndex = 0;
        }

        private void SetupButtonEvents()
        {
            btnHK1.Click += (sender, e) => SwitchSemester(1);
            btnHK2.Click += (sender, e) => SwitchSemester(2);
            btnCaNam.Click += (sender, e) => SwitchSemester(0);
            cboNamHoc.SelectedIndexChanged += CboNamHoc_SelectedIndexChanged;
        }

        private void LoadSchoolYears()
        {
            try
            {
                string query = @"
                        SELECT LH.NamHoc
                        FROM HocSinh HS
                        JOIN LopHoc LH ON HS.MaLop = LH.MaLop
                        WHERE HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", id }
                    };

                DataTable dtCurrentYear = dbHelper.ExecuteQuery(query, parameters);
                string currentYear = null;

                if (dtCurrentYear != null && dtCurrentYear.Rows.Count > 0)
                {
                    currentYear = dtCurrentYear.Rows[0]["NamHoc"].ToString();
                }

                string queryAllYears = "SELECT DISTINCT NamHoc FROM LopHoc ORDER BY NamHoc DESC";
                DataTable dt = dbHelper.ExecuteQuery(queryAllYears);

                List<string> schoolYears = new List<string>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        schoolYears.Add(row["NamHoc"].ToString());
                    }
                }
                else
                {
                    schoolYears = new List<string> { "2024-2025", "2023-2024", "2022-2023" };
                }

                cboNamHoc.DataSource = schoolYears;

                if (!string.IsNullOrEmpty(currentYear) && schoolYears.Contains(currentYear))
                {
                    cboNamHoc.SelectedItem = currentYear;
                }
                else if (schoolYears.Count > 0)
                {
                    cboNamHoc.SelectedIndex = 0;
                }

                currentSchoolYear = cboNamHoc.SelectedItem?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách năm học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                List<string> defaultYears = new List<string> { "2024-2025", "2023-2024", "2022-2023" };
                cboNamHoc.DataSource = defaultYears;
                currentSchoolYear = defaultYears[0];
            }
        }

        private void CboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedValue != null)
            {
                currentSchoolYear = cboNamHoc.SelectedValue.ToString();
                LoadSemesterData();
            }
        }

        private void SwitchSemester(int semester)
        {
            currentSemester = semester;

            btnHK1.FillColor = (semester == 1) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK1.ForeColor = (semester == 1) ? Color.White : Color.FromArgb(100, 100, 100);

            btnHK2.FillColor = (semester == 2) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = (semester == 2) ? Color.White : Color.FromArgb(100, 100, 100);

            btnCaNam.FillColor = (semester == 0) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = (semester == 0) ? Color.White : Color.FromArgb(100, 100, 100);

            lblSummaryTitle.Text = (semester == 0) ? "Tổng kết năm học" : $"Tổng kết học kỳ {semester}";

            LoadSemesterData();
        }

        private void LoadSemesterData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Lấy điểm số của học sinh cho các môn học
                List<MonHocScoreDTO> subjectScores = diemSoDAL.GetStudentSubjectsScore(
                    id, currentSemester, currentSchoolYear);

                // Làm sạch dữ liệu mặc định của các ucKQHTItem có sẵn trong thiết kế
                ResetExistingSubjectItems();

                // Lấy danh sách tất cả các môn học từ cơ sở dữ liệu
                List<MonHocDTO> allSubjects = GetAllSubjects();

                // Nếu không có môn học hoặc điểm số nào
                if ((allSubjects == null || allSubjects.Count == 0) && (subjectScores == null || subjectScores.Count == 0))
                {
                    flpSubject.Visible = false;

                    Label lblNoData = new Label
                    {
                        Text = "Không có dữ liệu môn học cho học kỳ này.",
                        Font = new Font("Segoe UI", 12, FontStyle.Regular),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Padding = new Padding(0, 80, 0, 0)
                    };

                    pnlSubjects.Controls.Add(lblNoData);
                    lblNoData.BringToFront();
                }
                else
                {
                    flpSubject.Visible = true;

                    // Tạo từ điển để dễ dàng tìm kiếm môn học đã có điểm
                    Dictionary<int, MonHocScoreDTO> scoresBySubjectId = new Dictionary<int, MonHocScoreDTO>();
                    if (subjectScores != null)
                    {
                        foreach (var score in subjectScores)
                        {
                            scoresBySubjectId[score.MaMon] = score;
                        }
                    }

                    // Lưu trữ ucKQHTItem đã được tìm thấy để tránh hiển thị trùng lặp
                    List<string> processedSubjects = new List<string>();

                    // Hiển thị tất cả các môn học, có điểm hoặc không có điểm
                    foreach (var subject in allSubjects)
                    {
                        // Tìm control ucKQHTItem tương ứng với tên môn học
                        ucKQHTItem subjectItem = FindSubjectItemByName(subject.TenMon);

                        if (subjectItem == null)
                        {
                            // Nếu không tìm thấy control, tạo mới
                            if (scoresBySubjectId.ContainsKey(subject.MaMon))
                            {
                                var score = scoresBySubjectId[subject.MaMon];
                                subjectItem = new ucKQHTItem(
                                    score.TenMon,
                                    score.DiemMiengList,
                                    score.Diem15PhutList,
                                    score.DiemGiuaKyList,
                                    score.DiemCuoiKyList,
                                    score.NhanXet
                                );
                            }
                            else
                            {
                                subjectItem = new ucKQHTItem(
                                    subject.TenMon,
                                    new List<float>(),
                                    new List<float>(),
                                    new List<float>(),
                                    new List<float>(),
                                    "Chưa có điểm"
                                );
                            }

                            subjectItem.AdjustToContainerWidth(flpSubject.ClientSize.Width);
                            subjectItem.AutoSetColor();
                            subjectItem.Margin = new Padding(10);
                            flpSubject.Controls.Add(subjectItem);
                        }
                        else
                        {
                            // Nếu tìm thấy control, cập nhật dữ liệu
                            if (scoresBySubjectId.ContainsKey(subject.MaMon))
                            {
                                var score = scoresBySubjectId[subject.MaMon];
                                subjectItem.SubjectName = score.TenMon;
                                subjectItem.DiemMiengList = score.DiemMiengList;
                                subjectItem.Diem15PhutList = score.Diem15PhutList;
                                subjectItem.DiemGiuaKyList = score.DiemGiuaKyList;
                                subjectItem.DiemCuoiKyList = score.DiemCuoiKyList;
                                subjectItem.NhanXet = score.NhanXet;
                            }
                            else
                            {
                                subjectItem.SubjectName = subject.TenMon;
                                subjectItem.DiemMiengList = new List<float>();
                                subjectItem.Diem15PhutList = new List<float>();
                                subjectItem.DiemGiuaKyList = new List<float>();
                                subjectItem.DiemCuoiKyList = new List<float>();
                                subjectItem.NhanXet = "Chưa có điểm";
                            }

                            subjectItem.AutoSetColor();
                            subjectItem.AdjustToContainerWidth(flpSubject.ClientSize.Width);
                        }

                        processedSubjects.Add(subject.TenMon.ToLower());
                    }

                    // Ẩn các ucKQHTItem không có trong danh sách môn học
                    foreach (Control ctrl in flpSubject.Controls)
                    {
                        if (ctrl is ucKQHTItem item)
                        {
                            if (!processedSubjects.Contains(item.SubjectName.ToLower()) && !string.IsNullOrEmpty(item.SubjectName))
                            {
                                item.Visible = false;
                            }
                            else
                            {
                                item.Visible = true;
                            }
                        }
                    }
                }

                LoadSummaryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu học kỳ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Làm sạch dữ liệu mặc định của các ucKQHTItem có sẵn
        private void ResetExistingSubjectItems()
        {
            foreach (Control ctrl in flpSubject.Controls)
            {
                if (ctrl is ucKQHTItem item)
                {
                    item.SubjectName = "";
                    item.DiemMiengList = new List<float>();
                    item.Diem15PhutList = new List<float>();
                    item.DiemGiuaKyList = new List<float>();
                    item.DiemCuoiKyList = new List<float>();
                    item.NhanXet = "";
                    item.Visible = false;
                }
            }
        }

        // Tìm control ucKQHTItem theo tên môn học
        private ucKQHTItem FindSubjectItemByName(string subjectName)
        {


            // Ánh xạ tên môn học đến tên control trong designer
            Dictionary<string, string> subjectToControlMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Toán", "Toan" },
                { "Vật lý", "Ly" },
                { "Ngữ văn", "Van" },
                { "Hóa học", "Hoa" },
                { "Địa lý", "Dia" },
                { "Lịch sử", "Su" },
                { "Tiếng Anh", "AnhVan" },
                { "Công nghệ", "CN" },
                { "Giáo dục công dân", "GDCD" },
                { "Tin học", "Tin" },
                { "Sinh học", "Sinh" }
            };

            // Trước tiên kiểm tra xem có ánh xạ nào cho tên môn học này không
            string controlName = null;
            if (subjectToControlMap.TryGetValue(subjectName, out controlName))
            {
                Control[] controls = this.flpSubject.Controls.Find(controlName, true);
                if (controls.Length > 0 && controls[0] is ucKQHTItem)
                    return (ucKQHTItem)controls[0];
            }

            // Nếu không có ánh xạ, tìm kiếm trong tất cả các control
            foreach (Control ctrl in flpSubject.Controls)
            {
                if (ctrl is ucKQHTItem item)
                {
                    if (string.Equals(item.SubjectName, subjectName, StringComparison.OrdinalIgnoreCase) ||
                        string.IsNullOrEmpty(item.SubjectName))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        // Phương thức để lấy tất cả các môn học từ cơ sở dữ liệu
        private List<MonHocDTO> GetAllSubjects()
        {
            List<MonHocDTO> subjects = new List<MonHocDTO>();

            try
            {
                string query = "SELECT MaMon, TenMon FROM MonHoc ORDER BY MaMon";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        subjects.Add(new MonHocDTO
                        {
                            MaMon = Convert.ToInt32(row["MaMon"]),
                            TenMon = row["TenMon"].ToString()
                        });

                           }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong GetAllSubjects: {ex.Message}");                // Tạo danh sách môn học mặc định với ID chính xác như trong CSDL
                subjects.Add(new MonHocDTO { MaMon = 1, TenMon = "Toán" });
                subjects.Add(new MonHocDTO { MaMon = 2, TenMon = "Vật Lý" });
                subjects.Add(new MonHocDTO { MaMon = 3, TenMon = "Hóa Học" });
                subjects.Add(new MonHocDTO { MaMon = 4, TenMon = "Sinh Học" });
                subjects.Add(new MonHocDTO { MaMon = 5, TenMon = "Ngữ Văn" });
                subjects.Add(new MonHocDTO { MaMon = 6, TenMon = "Lịch Sử" });
                subjects.Add(new MonHocDTO { MaMon = 7, TenMon = "Địa Lý" });
                subjects.Add(new MonHocDTO { MaMon = 8, TenMon = "Tiếng Anh" });
                subjects.Add(new MonHocDTO { MaMon = 9, TenMon = "Giáo Dục Công Dân" });
                subjects.Add(new MonHocDTO { MaMon = 10, TenMon = "Thể Dục" });
                subjects.Add(new MonHocDTO { MaMon = 11, TenMon = "Tin Học" });
                subjects.Add(new MonHocDTO { MaMon = 12, TenMon = "Công Nghệ" });
            }

            return subjects;
        }

        private void LoadSummaryData()
        {
            try
            {
                lblGPAValue.Text = "...";
                lblConductValue.Text = "...";
                lblRankValue.Text = "...";
                lblAbsentValue.Text = "...";
                lblAcademicPerformanceValue.Text = "...";
                lblAwardsValue.Text = "...";
                txtTeacherComment.Text = "Đang tải thông tin tổng kết...";

                Task.Run(() => diemSoDAL.GetSemesterSummary(id, currentSemester, currentSchoolYear))
                    .ContinueWith(task =>
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {
                                try
                                {
                                    HocKySummaryDTO summary = task.Result;

                                    if (summary != null)
                                    {
                                        lblGPAValue.Text = summary.DiemTrungBinh.ToString("0.0");
                                        lblConductValue.Text = summary.HanhKiem;
                                        lblRankValue.Text = summary.XepHang.ToString();
                                        lblAbsentValue.Text = summary.SoBuoiNghi.ToString();
                                        lblAcademicPerformanceValue.Text = summary.XepLoai;
                                        txtTeacherComment.Text = summary.NhanXet ?? "Không có nhận xét.";

                                        if (!string.IsNullOrEmpty(summary.XepLoai))
                                        {
                                            if (summary.XepLoai == "Giỏi" && summary.HanhKiem == "Tốt")
                                                lblAwardsValue.Text = "Học sinh Giỏi";
                                            else if (summary.XepLoai == "Khá" && (summary.HanhKiem == "Tốt" || summary.HanhKiem == "Khá"))
                                                lblAwardsValue.Text = "Học sinh Tiên tiến";
                                            else
                                                lblAwardsValue.Text = "Không có";
                                        }

                                        if (summary.DiemTrungBinh >= 8.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 150, 60);
                                        else if (summary.DiemTrungBinh >= 7.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 180, 80);
                                        else if (summary.DiemTrungBinh >= 5.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(230, 130, 0);
                                        else
                                            lblGPAValue.ForeColor = Color.FromArgb(220, 53, 69);
                                    }
                                    else
                                    {
                                        lblGPAValue.Text = "---";
                                        lblConductValue.Text = "---";
                                        lblRankValue.Text = "---";
                                        lblAbsentValue.Text = "---";
                                        lblAcademicPerformanceValue.Text = "---";
                                        lblAwardsValue.Text = "---";
                                        txtTeacherComment.Text = "Chưa có thông tin tổng kết cho học kỳ này.";
                                        lblGPAValue.ForeColor = Color.Gray;
                                    }
                                }
                                catch (Exception)
                                {
                                    lblGPAValue.Text = "---";
                                    lblConductValue.Text = "---";
                                    lblRankValue.Text = "---";
                                    lblAbsentValue.Text = "---";
                                    lblAcademicPerformanceValue.Text = "---";
                                    lblAwardsValue.Text = "---";
                                    txtTeacherComment.Text = "Lỗi khi tải dữ liệu tổng kết.";
                                }
                            }));
                        }
                    });
            }
            catch (Exception)
            {
                lblGPAValue.Text = "---";
                lblConductValue.Text = "---";
                lblRankValue.Text = "---";
                lblAbsentValue.Text = "---";
                lblAcademicPerformanceValue.Text = "---";
                lblAwardsValue.Text = "---";
                txtTeacherComment.Text = "Lỗi khi tải dữ liệu tổng kết.";
            }
        }

        public void RefreshData()
        {
            try
            {
                LoadSemesterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEvents()
        {
            pnlSubjects.Resize += pnlSubjects_Resize;
        }

        private void pnlSubjects_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlSubjects.Controls)
            {
                if (ctrl is FlowLayoutPanel flowPanel)
                {
                    foreach (Control item in flowPanel.Controls)
                    {
                        if (item is ucKQHTItem scoreItem)
                        {
                            scoreItem.AdjustToContainerWidth(flowPanel.ClientSize.Width);
                        }
                    }
                }
            }
        }
    }

    // Lớp DTO để lưu trữ thông tin môn học cơ bản
    public class MonHocDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
    }
}
