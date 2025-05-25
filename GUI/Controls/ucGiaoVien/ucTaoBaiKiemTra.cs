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
    public partial class ucTaoBaiKiemTra : UserControl
    {

        // Định nghĩa các sự kiện cho UserControl
        public event EventHandler TestCreated; // Khi tạo bài kiểm tra thành công
        public event EventHandler TestSavedAsDraft; // Khi lưu nháp thành công
        public event EventHandler TestCanceled; // Khi hủy tạo bài kiểm tra

        // Phương thức kích hoạt các sự kiện
        protected virtual void OnTestCreated()
        {
            TestCreated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTestSavedAsDraft()
        {
            TestSavedAsDraft?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTestCanceled()
        {
            TestCanceled?.Invoke(this, EventArgs.Empty);
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            if (ValidateTest())
            {
                try
                {
                    // Get the test data
                    TestData testData = CreateTestData();
                    testData.Status = "Published";

                    // Save test to database
                    bool success = SaveTestToDatabase(testData);

                    if (success)
                    {
                        MessageBox.Show("Bài kiểm tra đã được đăng thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Kích hoạt sự kiện thành công
                        OnTestCreated();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu bài kiểm tra. Vui lòng thử lại.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đăng bài kiểm tra: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveDraft_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the test data
                TestData testData = CreateTestData();
                testData.Status = "Draft";

                // Save test to database
                bool success = SaveTestToDatabase(testData);

                if (success)
                {
                    MessageBox.Show("Bài kiểm tra đã được lưu nháp thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Kích hoạt sự kiện lưu nháp
                    OnTestSavedAsDraft();
                }
                else
                {
                    MessageBox.Show("Không thể lưu bài kiểm tra. Vui lòng thử lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu nháp: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (questionCount > 0 || !string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ bài kiểm tra này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Kích hoạt sự kiện hủy
                    OnTestCanceled();
                }
            }
            else
            {
                // Kích hoạt sự kiện hủy
                OnTestCanceled();
            }
        }
        private int teacherId;
        private List<object> questionList = new List<object>(); // Can contain both ucTN and ucTL
        private int questionCount = 0;

        // Constructor that accepts a teacher ID
        public ucTaoBaiKiemTra(int teacherId)
        {
            InitializeComponent();
            this.teacherId = teacherId;
        }

        // Default constructor
        public ucTaoBaiKiemTra()
        {
            InitializeComponent();
            // Assume we have a static property to store logged-in teacher ID
            this.teacherId = AppSettings.LoggedInTeacherId;
        }

        private void ucTaoBaiKiemTra_Load(object sender, EventArgs e)
        {
            // Initialize form controls
            LoadSubjects();
            LoadClasses();
            SetupEventHandlers();

            // Set default values
            if (cboTestType.Items.Count > 0)
                cboTestType.SelectedIndex = 0;

            // Initialize the lblNoQuestions visibility
            lblNoQuestions.Visible = true;
        }

        private void LoadSubjects()
        {
            try
            {

                string query = $@"
                    SELECT DISTINCT m.MaMon AS MaMH, m.TenMon AS TenMonHoc 
                    FROM MonHoc m 
                    INNER JOIN GiaoVien g ON m.MaMon = g.MaMon 
                    WHERE g.MaNguoiDung = {teacherId}";

                DataTable dt = new DatabaseHelper().ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboSubject.DataSource = dt;
                    cboSubject.DisplayMember = "TenMonHoc";
                    cboSubject.ValueMember = "MaMH";
                }
                else
                {
                    // If no subjects found, add some default values for testing
                    cboSubject.Items.Clear();
                    cboSubject.Items.AddRange(new object[] { "Toán", "Văn", "Anh", "Lý", "Hóa", "Sinh" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Add default values in case of error
                cboSubject.Items.Clear();
                cboSubject.Items.AddRange(new object[] { "Toán", "Văn", "Anh", "Lý", "Hóa", "Sinh" });
            }
        }

        private void LoadClasses()
        {
            try
            {
                // Lấy mã giáo viên từ teacherId (mã người dùng)
                int maGV = GetMaGV(teacherId);

                if (maGV <= 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin giáo viên. Vui lòng đăng nhập lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Truy vấn tất cả các lớp được phân công
                string query = $@"
                    SELECT DISTINCT lh.MaLop, lh.TenLop 
                    FROM LopHoc lh 
                    INNER JOIN ThoiKhoaBieu tkb ON lh.MaLop = tkb.MaLop
                    WHERE tkb.MaGV = {maGV}";

                DataTable dt = new DatabaseHelper().ExecuteQuery(query);

                // Log thông tin để debug
                Console.WriteLine($"Tìm thấy {dt.Rows.Count} lớp học cho giáo viên có MaGV = {maGV}");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"MaLop: {row["MaLop"]}, TenLop: {row["TenLop"]}");
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboClass.DataSource = dt;
                    cboClass.DisplayMember = "TenLop";
                    cboClass.ValueMember = "MaLop";
                }
                else
                {
                    // Nếu không có lớp học phân công trong ThoiKhoaBieu, thử lấy lớp chủ nhiệm
                    query = $@"
                        SELECT DISTINCT lh.MaLop, lh.TenLop 
                        FROM LopHoc lh 
                        WHERE lh.MaGVChuNhiem = {maGV}";

                    dt = new DatabaseHelper().ExecuteQuery(query);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        cboClass.DataSource = dt;
                        cboClass.DisplayMember = "TenLop";
                        cboClass.ValueMember = "MaLop";
                    }
                    else
                    {
                        // Nếu vẫn không có lớp nào, thêm giá trị mẫu
                        cboClass.Items.Clear();
                        cboClass.Items.AddRange(new object[] { "10A1", "10A2", "11A1", "11A2", "12A1", "12A2" });
                        MessageBox.Show("Không tìm thấy lớp được phân công dạy cho giáo viên này.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Thêm giá trị mặc định trong trường hợp lỗi
                cboClass.Items.Clear();
                cboClass.Items.AddRange(new object[] { "10A1", "10A2", "11A1", "11A2", "12A1", "12A2" });
            }
        }

        private void SetupEventHandlers()
        {
            // Set up event handlers
            btnAddMultipleChoiceQuestion.Click += BtnAddMultipleChoiceQuestion_Click;
            btnAddEssayQuestion.Click += BtnAddEssayQuestion_Click;
            btnImportQuestions.Click += BtnImportQuestions_Click;
            btnPreviewTest.Click += BtnPreviewTest_Click;
            btnPublish.Click += BtnPublish_Click;
            btnSaveDraft.Click += BtnSaveDraft_Click;
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            chkPassword.CheckedChanged += ChkPassword_CheckedChanged;
        }

        private void BtnAddMultipleChoiceQuestion_Click(object sender, EventArgs e)
        {
            // Create new instance of multiple choice question control
            ucTN multipleChoiceQuestion = new ucTN(++questionCount);
            multipleChoiceQuestion.RemoveQuestionRequested += Question_RemoveRequested;
            multipleChoiceQuestion.QuestionDataChanged += Question_DataChanged;

            // Hide the "no questions" label if this is the first question
            if (questionCount == 1)
            {
                lblNoQuestions.Visible = false;
            }

            // Add the question to the panel
            AddQuestionToPanel(multipleChoiceQuestion);

            // Add to the question list
            questionList.Add(multipleChoiceQuestion);
        }

        private void BtnAddEssayQuestion_Click(object sender, EventArgs e)
        {
            // Create new instance of essay question control
            ucTL essayQuestion = new ucTL(++questionCount);
            essayQuestion.RemoveQuestionRequested += Question_RemoveRequested;
            essayQuestion.QuestionDataChanged += Question_DataChanged;

            // Hide the "no questions" label if this is the first question
            if (questionCount == 1)
            {
                lblNoQuestions.Visible = false;
            }

            // Add the question to the panel
            AddQuestionToPanel(essayQuestion);

            // Add to the question list
            questionList.Add(essayQuestion);
        }

        private void AddQuestionToPanel(UserControl questionControl)
        {
            // Set the size and dock style
            questionControl.Width = panelQuestions.Width - 20;
            questionControl.Dock = DockStyle.Top;

            // Add to panel
            panelQuestions.Controls.Add(questionControl);
            questionControl.BringToFront();

            // Scroll to the new question
            panelQuestions.ScrollControlIntoView(questionControl);
        }

        private void Question_RemoveRequested(object sender, EventArgs e)
        {
            // Remove the question from the list and panel
            UserControl question = sender as UserControl;
            if (question != null)
            {
                panelQuestions.Controls.Remove(question);
                questionList.Remove(question);
                question.Dispose();

                // Decrease question count
                questionCount--;

                // Update question numbers
                ReorderQuestions();

                // Show the "no questions" label if no questions left
                if (questionCount == 0)
                {
                    lblNoQuestions.Visible = true;
                }
            }
        }

        private void Question_DataChanged(object sender, EventArgs e)
        {
            // This can be used to update something when a question is modified
            // For now, we'll just leave it empty
        }

        private void ReorderQuestions()
        {
            // Update question numbers for all questions
            int newNumber = 1;

            // Process controls in reverse order because they are docked to top
            foreach (Control control in panelQuestions.Controls.Cast<Control>().Reverse())
            {
                if (control is ucTN multipleChoiceQuestion)
                {
                    multipleChoiceQuestion.SetQuestionNumber(newNumber++);
                }
                else if (control is ucTL essayQuestion)
                {
                    essayQuestion.SetQuestionNumber(newNumber++);
                }
            }
        }

        private void BtnImportQuestions_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|CSV Files|*.csv|All Files|*.*";
                openFileDialog.Title = "Chọn tệp câu hỏi";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // TODO: Implement actual import logic
                        MessageBox.Show("Chức năng nhập câu hỏi từ tệp đang được phát triển.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi nhập câu hỏi: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validate as needed when switching tabs
            if (tabControlMain.SelectedIndex > 0 && string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài kiểm tra trước khi tiếp tục.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 0;
                txtTestName.Focus();
                return;
            }

            // Check if questions are added when going to score configuration
            if (tabControlMain.SelectedIndex == 2 && questionCount == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một câu hỏi trước khi cấu hình điểm số.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 1;
                return;
            }
        }

        private void ChkPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable password textbox based on checkbox state
            txtPassword.Enabled = chkPassword.Checked;
            if (!chkPassword.Checked)
                txtPassword.Text = "";
        }
        private void BtnPreviewTest_Click(object sender, EventArgs e)
        {
            if (ValidateTest())
            {
                // Create a simplified preview of the test
                StringBuilder preview = new StringBuilder();
                preview.AppendLine($"Bài kiểm tra: {txtTestName.Text}");
                preview.AppendLine($"Môn học: {cboSubject.Text}");
                preview.AppendLine($"Lớp: {cboClass.Text}");
                preview.AppendLine($"Thời gian làm bài: {numDuration.Value} phút");
                preview.AppendLine($"Số câu hỏi: {questionCount}");
                preview.AppendLine();
                preview.AppendLine("=== CÁC CÂU HỎI ===");

                // Add each question
                int questionNumber = 1;
                foreach (var item in questionList)
                {
                    if (item is ucTN tnQuestion)
                    {
                        var data = tnQuestion.GetQuestionData();
                        preview.AppendLine($"Câu {questionNumber}: (Trắc nghiệm - {data.Score} điểm)");
                        preview.AppendLine(data.QuestionContent);

                        // Add options
                        for (int i = 0; i < data.Options.Count; i++)
                        {
                            string label = ((char)('A' + i)).ToString();
                            preview.AppendLine($"{label}. {data.Options[i]}");
                        }

                        preview.AppendLine($"Đáp án đúng: {data.CorrectAnswer}");
                        preview.AppendLine();
                    }
                    else if (item is ucTL tlQuestion)
                    {
                        var data = tlQuestion.GetQuestionData();
                        preview.AppendLine($"Câu {questionNumber}: (Tự luận - {data.Score} điểm)");
                        preview.AppendLine(data.QuestionContent);
                        if (data.HasWordLimit)
                            preview.AppendLine($"(Giới hạn: {data.WordLimit} từ)");
                        preview.AppendLine();
                    }

                    questionNumber++;
                }

                // Show the preview
                using (Form previewForm = new Form())
                {
                    previewForm.Text = "Xem trước bài kiểm tra";
                    previewForm.Size = new Size(600, 600);
                    previewForm.StartPosition = FormStartPosition.CenterParent;

                    TextBox txtPreview = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        Text = preview.ToString(),
                        Font = new Font("Segoe UI", 10)
                    };

                    previewForm.Controls.Add(txtPreview);
                    previewForm.ShowDialog();
                }
            }
        }


      
  
       
        private bool ValidateTest()
        {
            // Validate general information
            if (string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài kiểm tra.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 0;
                txtTestName.Focus();
                return false;
            }

            if (cboSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn môn học.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 0;
                cboSubject.Focus();
                return false;
            }

            if (cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 0;
                cboClass.Focus();
                return false;
            }

            // Validate start and end dates
            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 0;
                dtpStartDate.Focus();
                return false;
            }

            // Validate questions
            if (questionCount == 0)
            {
                MessageBox.Show("Bài kiểm tra phải có ít nhất một câu hỏi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 1;
                return false;
            }

            // Validate each question
            foreach (var item in questionList)
            {
                if (item is ucTN tnQuestion)
                {
                    if (!tnQuestion.ValidateQuestion())
                    {
                        MessageBox.Show($"Câu hỏi trắc nghiệm #{tnQuestion.GetQuestionData().QuestionNumber} chưa được hoàn thành.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControlMain.SelectedIndex = 1;
                        panelQuestions.ScrollControlIntoView(tnQuestion);
                        return false;
                    }
                }
                else if (item is ucTL tlQuestion)
                {
                    if (!tlQuestion.ValidateQuestion())
                    {
                        MessageBox.Show($"Câu hỏi tự luận #{tlQuestion.GetQuestionData().QuestionNumber} chưa được hoàn thành.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControlMain.SelectedIndex = 1;
                        panelQuestions.ScrollControlIntoView(tlQuestion);
                        return false;
                    }
                }
            }

            // Validate password if required
            if (chkPassword.Checked && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho bài kiểm tra.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControlMain.SelectedIndex = 3;
                txtPassword.Focus();
                return false;
            }

            return true;
        }


        private TestData CreateTestData()
        {
            // Create a test data object with all information
            TestData test = new TestData
            {
                TeacherId = this.teacherId,
                TestName = txtTestName.Text.Trim(),
                Subject = cboSubject.Text,
                SubjectId = cboSubject.SelectedValue != null ? Convert.ToInt32(cboSubject.SelectedValue) : 0,
                Class = cboClass.Text,
                ClassId = cboClass.SelectedValue != null ? Convert.ToInt32(cboClass.SelectedValue) : 0,
                TestType = cboTestType.SelectedItem.ToString(),
                Duration = (int)numDuration.Value,
                AttemptsAllowed = (int)numAttemptsAllowed.Value,
                Description = txtDescription.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                PassingScore = (double)numPassingScore.Value,
                ShowResultImmediately = chkShowResultImmediately.Checked,
                RandomizeQuestions = chkRandomizeQuestions.Checked,
                GradingNotes = txtGradingNotes.Text.Trim(),
                PasswordProtected = chkPassword.Checked,
                Password = chkPassword.Checked ? txtPassword.Text : null,
                Questions = new List<QuestionData>(),
                CreatedDate = DateTime.Now
            };

            // Add questions
            foreach (var item in questionList)
            {
                if (item is ucTN tnQuestion)
                {
                    var tnData = tnQuestion.GetQuestionData();
                    test.Questions.Add(new QuestionData
                    {
                        QuestionNumber = tnData.QuestionNumber,
                        QuestionType = "MultipleChoice",
                        QuestionContent = tnData.QuestionContent,
                        Options = tnData.Options,
                        CorrectAnswer = tnData.CorrectAnswer,
                        Score = tnData.Score,
                        HasImage = false, // Always set to false since image functionality is removed
                        ImagePath = null  // Always set to null since image functionality is removed
                    });
                }
                else if (item is ucTL tlQuestion)
                {
                    var tlData = tlQuestion.GetQuestionData();
                    test.Questions.Add(new QuestionData
                    {
                        QuestionNumber = tlData.QuestionNumber,
                        QuestionType = "Essay",
                        QuestionContent = tlData.QuestionContent,
                        AnswerGuide = tlData.AnswerGuide,
                        Score = tlData.Score,
                        HasImage = false, // Always set to false since image functionality is removed
                        ImagePath = null, // Always set to null since image functionality is removed
                        HasWordLimit = tlData.HasWordLimit,
                        WordLimit = tlData.WordLimit
                    });
                }
            }

            return test;
        }

        private bool SaveTestToDatabase(TestData testData)
        {
            try
            {
                // Đảm bảo không có giá trị SubjectId là 0
                if (testData.SubjectId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn một môn học hợp lệ.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Convert TestData to BaiKiemTraDTO
                BaiKiemTraDTO baiKiemTraDTO = new BaiKiemTraDTO
                {
                    MaGV = GetMaGV(teacherId),
                    TenBaiKT = testData.TestName,
                    MoTa = testData.Description,
                    ThoiGianLamBai = testData.Duration,
                    ThoiGianBatDau = testData.StartDate,
                    ThoiGianKetThuc = testData.EndDate,
                    DiemDatYeuCau = testData.PassingScore,
                    SoLanLamToiDa = testData.AttemptsAllowed,
                    MaLop = testData.ClassId,
                    MaMH = testData.SubjectId,  // Đảm bảo đây không phải là 0
                    LoaiBaiKT = testData.TestType,
                    HienThiKetQuaNgay = testData.ShowResultImmediately,
                    XaoTronCauHoi = testData.RandomizeQuestions,
                    GhiChuChamDiem = testData.GradingNotes,
                    CoMatKhau = testData.PasswordProtected,
                    MatKhau = testData.PasswordProtected ? testData.Password : null,
                    TrangThai = testData.Status
                };

                // Initialize collection if it doesn't exist
                if (baiKiemTraDTO.DanhSachCauHoi == null)
                    baiKiemTraDTO.DanhSachCauHoi = new List<CauHoiDTO>();

                // Convert each question
                foreach (var questionData in testData.Questions)
                {
                    if (questionData.QuestionType == "MultipleChoice")
                    {
                        CauHoiTracNghiemDTO question = new CauHoiTracNghiemDTO
                        {
                            NoiDung = questionData.QuestionContent,
                            DiemSo = questionData.Score,

                            DapAnDung = questionData.CorrectAnswer
                        };

                        // Initialize collection if it doesn't exist
                        if (question.DanhSachLuaChon == null)
                            question.DanhSachLuaChon = new List<LuaChonDTO>();

                        // Add options
                        for (int i = 0; i < questionData.Options.Count; i++)
                        {
                            string optionLabel = ((char)('A' + i)).ToString();
                            LuaChonDTO option = new LuaChonDTO
                            {
                                NoiDung = questionData.Options[i],
                                NhanDang = optionLabel,
                                LaDapAnDung = (optionLabel == questionData.CorrectAnswer)
                            };

                            question.DanhSachLuaChon.Add(option);
                        }

                        baiKiemTraDTO.DanhSachCauHoi.Add(question);
                    }
                    else if (questionData.QuestionType == "Essay")
                    {
                        CauHoiTuLuanDTO question = new CauHoiTuLuanDTO
                        {
                            NoiDung = questionData.QuestionContent,
                            DiemSo = questionData.Score,
                            
                            HuongDanTraLoi = questionData.AnswerGuide,
                            CoGioiHanTu = questionData.HasWordLimit,
                            GioiHanTu = questionData.WordLimit
                        };

                        baiKiemTraDTO.DanhSachCauHoi.Add(question);
                    }
                }

                // Use the DAL to save the test
                BaiKiemTraDAO baiKiemTraDAL = new BaiKiemTraDAO();
                int maBaiKT = baiKiemTraDAL.CreateBaiKiemTra(baiKiemTraDTO);

                return maBaiKT > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu bài kiểm tra: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int GetMaGV(int maNguoiDung)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = $"SELECT MaGV FROM GiaoVien WHERE MaNguoiDung = {maNguoiDung}";
                object result = db.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch
            {
                // Return a default value in case of error
                return -1;
            }
        }

    }

    // Classes to hold data

    public class TestData
    {
        public int TeacherId { get; set; }
        public string TestName { get; set; }
        public string Subject { get; set; }
        public int SubjectId { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
        public string TestType { get; set; }
        public int Duration { get; set; }
        public int AttemptsAllowed { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PassingScore { get; set; }
        public bool ShowResultImmediately { get; set; }
        public bool RandomizeQuestions { get; set; }
        public string GradingNotes { get; set; }
        public bool PasswordProtected { get; set; }
        public string Password { get; set; }
        public List<QuestionData> Questions { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class QuestionData
    {
        public int QuestionNumber { get; set; }
        public string QuestionType { get; set; } // "MultipleChoice" or "Essay"
        public string QuestionContent { get; set; }
        public double Score { get; set; }
        public bool HasImage { get; set; }
        public string ImagePath { get; set; }

        // Multiple choice specific fields
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        // Essay specific fields
        public string AnswerGuide { get; set; }
        public bool HasWordLimit { get; set; }
        public int WordLimit { get; set; }
    }

    public static class AppSettings
    {
        public static int LoggedInTeacherId { get; set; }
    }
}

