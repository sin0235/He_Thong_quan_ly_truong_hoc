using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;
using QuanLyTruongHoc.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmKiemTra : Form
    {
        // Danh sách các câu hỏi (có thể là trắc nghiệm hoặc tự luận)
        private List<UserControl> questionItems = new List<UserControl>();
        private int currentQuestionIndex = 0;
        private TimeSpan remainingTime = TimeSpan.FromMinutes(30); // Mặc định 30 phút
        private List<bool> answeredQuestions; // Theo dõi câu hỏi đã trả lời
        private List<bool> markedQuestions; // Theo dõi câu hỏi đã đánh dấu
        private List<Guna2Button> questionButtons = new List<Guna2Button>();

        private Timer animationTimer;
        private double opacity = 0;
        private int tID;
        private int maHS;

        // DAO objects
        private BaiKiemTraDAO baiKiemTraDAO;
        private BaiLamDAO baiLamDAO;
        private BaiKiemTraDTO currentBaiKT;
        private DateTime startTime; // Thời gian bắt đầu làm bài

        // Event handlers for question interaction
        private void Question_AnswerSelected(object sender, AnswerSelectedEventArgs e)
        {
            // Mark the question as answered
            if (currentQuestionIndex >= 0 && currentQuestionIndex < answeredQuestions.Count)
            {
                MarkQuestionAsAnswered(currentQuestionIndex);
            }
        }

        private void Question_AnswerChanged(object sender, EssayAnswerChangedEventArgs e)
        {
            // Mark the question as answered if there's text
            if (!string.IsNullOrWhiteSpace(e.Answer) && currentQuestionIndex >= 0 && currentQuestionIndex < answeredQuestions.Count)
            {
                MarkQuestionAsAnswered(currentQuestionIndex);
            }
        }

        public frmKiemTra(int testId, int studentId)
        {
            InitializeComponent();
            tID = testId;
            maHS = studentId;

            // Initialize DAOs
            baiKiemTraDAO = new BaiKiemTraDAO();
            baiLamDAO = new BaiLamDAO();

            // Thiết lập hiệu ứng mở form
            this.Opacity = 0;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo timer cho hiệu ứng mở form
            animationTimer = new Timer();
            animationTimer.Interval = 15; // milliseconds
            animationTimer.Tick += AnimationTimer_Tick;

            // Đăng ký sự kiện
            this.Load += FrmKiemTra_Load;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnSubmit.Click += BtnSubmit_Click;
            chkMarkForReview.CheckedChanged += ChkMarkForReview_CheckedChanged;
            timer.Interval = 1000; // 1 giây
            timer.Tick += Timer_Tick;
            
            // Ghi lại thời gian bắt đầu làm bài
            startTime = DateTime.Now;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Tăng dần opacity để tạo hiệu ứng fade-in
            opacity += 0.075;
            if (opacity >= 1)
            {
                this.Opacity = 1;
                animationTimer.Stop();
            }
            else
            {
                this.Opacity = opacity;
            }
        }

        private void FrmKiemTra_Load(object sender, EventArgs e)
        {
            // Load test details
            LoadTestData();

            // Load questions
            LoadQuestions();

            // Initialize tracking arrays
            answeredQuestions = new List<bool>(questionItems.Count);
            markedQuestions = new List<bool>(questionItems.Count);

            // Initialize all questions as unanswered and unmarked
            for (int i = 0; i < questionItems.Count; i++)
            {
                answeredQuestions.Add(false);
                markedQuestions.Add(false);
            }

            // Set progress bar maximum
            progressExam.Maximum = questionItems.Count;
            progressExam.Value = 0;

            // Bắt đầu hiệu ứng mở form
            animationTimer.Start();

            // Tạo các nút câu hỏi trong sidebar
            CreateQuestionButtons();

            // Hiển thị câu hỏi đầu tiên
            ShowQuestion(0);

            // Bắt đầu đếm thời gian
            timer.Start();
        }

        private void LoadTestData()
        {
            try
            {
                // Get test details using the student-specific method
                currentBaiKT = baiKiemTraDAO.GetBaiKiemTraForStudent(tID, maHS);

                if (currentBaiKT != null)
                {
                    // Update form title
                    lblExamTitle.Text = currentBaiKT.TenBaiKT;

                    // Create a safe summary that handles null values
                    string className = string.IsNullOrEmpty(currentBaiKT.TenLop) ? "[Lớp học]" : currentBaiKT.TenLop;
                    int questionCount = 0;
                    double totalPoints = 0;

                    if (currentBaiKT.DanhSachCauHoi != null)
                    {
                        questionCount = currentBaiKT.DanhSachCauHoi.Count;
                        totalPoints = currentBaiKT.DanhSachCauHoi.Sum(q => q.DiemSo);
                    }

                    // Update summary with safe values
                    string summary = $"{className} | {questionCount} câu hỏi | " +
                                    $"{currentBaiKT.ThoiGianLamBai} phút | {totalPoints} điểm";
                    lblExamSummary.Text = summary;

                    // Set timer
                    remainingTime = TimeSpan.FromMinutes(currentBaiKT.ThoiGianLamBai);
                    UpdateTimerDisplay();
                }
                else
                {
                    string errorMsg = "Không thể tải thông tin bài kiểm tra. Kiểm tra các nguyên nhân sau:\n" +
                                    "- Bài kiểm tra không tồn tại\n" +
                                    "- Bài kiểm tra không được gán cho lớp của bạn\n" +
                                    "- Bài kiểm tra chưa được công bố";
                    
                    MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu bài kiểm tra: {ex.Message}\n\nChi tiết: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadQuestions()
        {
            try
            {
                // Clear existing question list
                questionItems.Clear();

                // Check if we have a valid test ID
                if (tID <= 0)
                {
                    MessageBox.Show("Mã bài kiểm tra không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure we have test data
                if (currentBaiKT == null)
                {
                    // Try to load the test data first if not already loaded
                    currentBaiKT = baiKiemTraDAO.GetBaiKiemTraById(tID);

                    if (currentBaiKT == null)
                    {
                        MessageBox.Show("Không thể tải thông tin bài kiểm tra!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Ensure we have question data
                if (currentBaiKT.DanhSachCauHoi == null || currentBaiKT.DanhSachCauHoi.Count == 0)
                {
                    // Explicitly load questions if they weren't loaded with the test
                    currentBaiKT.DanhSachCauHoi = baiKiemTraDAO.GetQuestionsByTestId(tID);

                    if (currentBaiKT.DanhSachCauHoi == null || currentBaiKT.DanhSachCauHoi.Count == 0)
                    {
                        MessageBox.Show("Bài kiểm tra không có câu hỏi nào!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Get the question list
                List<CauHoiDTO> questions = currentBaiKT.DanhSachCauHoi;

                // Option to randomize questions if the test requires it
                if (currentBaiKT.XaoTronCauHoi)
                {
                    Random rng = new Random();
                    questions = questions.OrderBy(q => rng.Next()).ToList();
                }

                int questionNumber = 1;

                foreach (var question in questions)
                {
                    if (question is CauHoiTracNghiemDTO)
                    {
                        var mcQuestion = question as CauHoiTracNghiemDTO;
                        ucTNItem tnItem = new ucTNItem();

                        try
                        {

                      

                            // Initialize the options list if null
                            if (mcQuestion.DanhSachLuaChon == null)
                            {
                                Console.WriteLine($"Danh sách lựa chọn null cho câu hỏi {mcQuestion.MaCauHoi}");
                                mcQuestion.DanhSachLuaChon = new List<LuaChonDTO>();
                            }

                            // Get options and correct answers
                            List<string> options = mcQuestion.DanhSachLuaChon.Select(o => o.NoiDung).ToList();
                            List<int> correctOptions = mcQuestion.DanhSachLuaChon
                                .Where(o => o.LaDapAnDung)
                                .Select(o => mcQuestion.DanhSachLuaChon.IndexOf(o))
                                .ToList();

                            bool isMultipleAnswer = correctOptions.Count > 1;

                            // Load the question data
                            tnItem.LoadQuestion(
                                mcQuestion.MaCauHoi,
                                questionNumber,
                                mcQuestion.NoiDung,
                                options,
                                correctOptions,
                                isMultipleAnswer
                            );

                            // Set the size and dock style
                            tnItem.Dock = DockStyle.Fill;

                            // Register for answer selection events
                            tnItem.AnswerSelected += Question_AnswerSelected;

                            // Add to question list
                            questionItems.Add(tnItem);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi tạo câu hỏi trắc nghiệm #{questionNumber}: {ex.Message}");
                            continue;
                        }
                    }
                    else if (question is CauHoiTuLuanDTO)
                    {
                        var essayQuestion = question as CauHoiTuLuanDTO;
                        ucTLItem tlItem = new ucTLItem();

                        try
                        {

                           

                            // Load the question data
                            tlItem.LoadQuestion(
                                essayQuestion.MaCauHoi,
                                questionNumber,
                                essayQuestion.NoiDung,
                                essayQuestion.HuongDanTraLoi ?? "",
                                essayQuestion.CoGioiHanTu ? essayQuestion.GioiHanTu : 10000

                            );

                            // Set the size and dock style
                            tlItem.Dock = DockStyle.Fill;

                            // Register for answer changed events
                            tlItem.AnswerChanged += Question_AnswerChanged;

                            // Add to question list
                            questionItems.Add(tlItem);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi tạo câu hỏi tự luận #{questionNumber}: {ex.Message}");
                            continue;
                        }
                    }

                    questionNumber++;
                }

                Console.WriteLine($"Đã tải {questionItems.Count} câu hỏi thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải câu hỏi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
            }
        }

        private void CreateQuestionButtons()
        {
            flowQuestionButtons.Controls.Clear();
            questionButtons.Clear();

            for (int i = 0; i < questionItems.Count; i++)
            {
                Guna2Button btnQuestion = new Guna2Button();
                btnQuestion.Text = (i + 1).ToString();
                btnQuestion.Width = 40;
                btnQuestion.Height = 40;
                btnQuestion.BorderRadius = 8;
                btnQuestion.FillColor = Color.FromArgb(240, 240, 240);
                btnQuestion.ForeColor = Color.Black;
                btnQuestion.Margin = new Padding(5);
                btnQuestion.Tag = i;

                btnQuestion.Click += (s, e) =>
                {
                    ShowQuestion((int)(s as Guna2Button).Tag);
                };

                flowQuestionButtons.Controls.Add(btnQuestion);
                questionButtons.Add(btnQuestion);
            }
        }

        private void UpdateQuestionButtonStyles()
        {
            for (int i = 0; i < questionButtons.Count; i++)
            {
                Guna2Button btn = questionButtons[i];

                // Kiểm tra xem câu hỏi đã được trả lời chưa
                if (answeredQuestions[i])
                {
                    btn.FillColor = Color.FromArgb(230, 245, 255);
                    btn.BorderColor = Color.FromArgb(0, 110, 220);
                    btn.BorderThickness = 1;
                }
                else
                {
                    btn.FillColor = Color.FromArgb(240, 240, 240);
                    btn.BorderThickness = 0;
                }

                // Kiểm tra xem câu hỏi đã được đánh dấu xem lại chưa
                if (markedQuestions[i])
                {
                    btn.BorderColor = Color.FromArgb(220, 180, 0);
                    btn.BorderThickness = 2;
                    btn.FillColor = Color.FromArgb(255, 248, 230);
                }

                // Nếu là câu hỏi hiện tại
                if (i == currentQuestionIndex)
                {
                    btn.FillColor = Color.FromArgb(0, 110, 220);
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= questionItems.Count)
                return;

            // Ẩn tất cả các câu hỏi
            foreach (UserControl question in questionItems)
            {
                question.Visible = false;
                if (pnlMain.Controls.Contains(question))
                    pnlMain.Controls.Remove(question);
            }

            // Hiển thị câu hỏi được chọn
            UserControl selectedQuestion = questionItems[index];
            pnlMain.Controls.Add(selectedQuestion);
            selectedQuestion.Visible = true;

            // Cập nhật chỉ số câu hỏi hiện tại
            currentQuestionIndex = index;

            // Cập nhật trạng thái checkbox đánh dấu xem lại
            chkMarkForReview.Checked = markedQuestions[currentQuestionIndex];

            // Cập nhật trạng thái các nút điều hướng
            btnPrev.Enabled = (index > 0);
            btnNext.Enabled = (index < questionItems.Count - 1);

            // Cập nhật kiểu dáng các nút câu hỏi
            UpdateQuestionButtonStyles();
        }

        private void UpdateTimerDisplay()
        {
            lblTimerValue.Text = string.Format("{0:00}:{1:00}:{2:00}",
                remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);

            // Đổi màu khi thời gian sắp hết (dưới 5 phút)
            if (remainingTime.TotalMinutes < 5)
            {
                lblTimerValue.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void UpdateProgressBar()
        {
            int answeredCount = 0;
            foreach (bool answered in answeredQuestions)
            {
                if (answered) answeredCount++;
            }

            progressExam.Value = answeredCount;
        }

        private void MarkQuestionAsAnswered(int questionIndex)
        {
            if (questionIndex >= 0 && questionIndex < answeredQuestions.Count)
            {
                answeredQuestions[questionIndex] = true;
                UpdateProgressBar();
                UpdateQuestionButtonStyles();
            }
        }

        #region Event Handlers

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                ShowQuestion(currentQuestionIndex - 1);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < questionItems.Count - 1)
            {
                ShowQuestion(currentQuestionIndex + 1);
            }
        }

        private void ChkMarkForReview_CheckedChanged(object sender, EventArgs e)
        {
            markedQuestions[currentQuestionIndex] = chkMarkForReview.Checked;
            UpdateQuestionButtonStyles();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            if (remainingTime.TotalSeconds <= 0)
            {
                // Hết thời gian
                timer.Stop();
                MessageBox.Show("Hết thời gian làm bài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Có thể thêm code để tự động nộp bài
                return;
            }

            UpdateTimerDisplay();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn nộp bài không?",
                "Xác nhận nộp bài",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Dừng đồng hồ
                timer.Stop();

                try
                {
                    // Tính thời gian làm bài (phút)
                    int thoiGianLamBai = (int)(DateTime.Now - startTime).TotalMinutes;
                    if (thoiGianLamBai < 1) thoiGianLamBai = 1; // Tối thiểu 1 phút

                    DatabaseHelper db = new DatabaseHelper();
                    int maBaiLam;

                    // Phương pháp 1: Sử dụng ExecuteInsertAndGetId thay vì ExecuteScalar
                    string insertBaiLamQuery = @"
                INSERT INTO BaiLam (MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DaNop)
                VALUES (@MaBaiKT, @MaHS, GETDATE(), @ThoiGianLamBai, 1);
                SELECT SCOPE_IDENTITY();";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaBaiKT", tID },
                { "@MaHS", maHS },
                { "@ThoiGianLamBai", thoiGianLamBai }
            };

                    maBaiLam = db.ExecuteInsertAndGetId(insertBaiLamQuery, parameters);

                    // Kiểm tra nếu không lấy được ID
                    if (maBaiLam <= 0)
                    {
                        // Phương pháp 2: Tìm bài làm vừa tạo dựa vào thông tin học sinh và bài kiểm tra
                        string findQuery = @"
                    SELECT TOP 1 MaBaiLam 
                    FROM BaiLam 
                    WHERE MaBaiKT = @MaBaiKT AND MaHS = @MaHS 
                    ORDER BY NgayLam DESC";

                        object rs = db.ExecuteScalar(findQuery, parameters);

                        if (rs != null && rs != DBNull.Value)
                        {
                            maBaiLam = Convert.ToInt32(rs);
                        }
                        else
                        {
                            throw new Exception("Không thể tạo hoặc tìm bài làm mới");
                        }
                    }

                    // 2. Lưu các câu trả lời trắc nghiệm
                    foreach (UserControl questionItem in questionItems)
                    {
                        if (questionItem is ucTNItem tnItem)
                        {
                            List<int> selectedOptions = tnItem.GetSelectedOptions();
                            string cauTraLoi = null;

                            if (selectedOptions != null && selectedOptions.Count > 0)
                            {
                                int optionIndex = selectedOptions[0];
                                // Mở rộng hỗ trợ nhiều lựa chọn
                                string[] optionLabels = { "A", "B", "C", "D", "E", "F", "G", "H" };

                                if (optionIndex >= 0 && optionIndex < optionLabels.Length)
                                {
                                    cauTraLoi = optionLabels[optionIndex];
                                }
                            }

                            if (!string.IsNullOrEmpty(cauTraLoi))
                            {
                                string insertTNQuery = @"
                            INSERT INTO BaiLam_TracNghiem (MaBaiLam, MaCauHoiTN, CauTraLoi)
                            VALUES (@MaBaiLam, @MaCauHoiTN, @CauTraLoi);";

                                Dictionary<string, object> tnParameters = new Dictionary<string, object>
                        {
                            { "@MaBaiLam", maBaiLam },
                            { "@MaCauHoiTN", tnItem.QuestionId },
                            { "@CauTraLoi", cauTraLoi } // Đã kiểm tra null ở trên
                        };

                                db.ExecuteNonQuery(insertTNQuery, tnParameters);
                            }
                        }
                        else if (questionItem is ucTLItem tlItem)
                        {
                            string cauTraLoi = tlItem.GetAnswer();
                            // Loại bỏ hoặc bỏ qua việc lấy filePath
                            // string filePath = tlItem.AttachedFilePath;

                            if (!string.IsNullOrEmpty(cauTraLoi))
                            {
                                string insertTLQuery = @"
                                INSERT INTO BaiLam_TuLuan (MaBaiLam, MaCauHoiTL, CauTraLoi)
                                VALUES (@MaBaiLam, @MaCauHoiTL, @CauTraLoi);";

                                Dictionary<string, object> tlParameters = new Dictionary<string, object>
                            {
                                { "@MaBaiLam", maBaiLam },
                                { "@MaCauHoiTL", tlItem.QuestionId },
                                { "@CauTraLoi", cauTraLoi }
                            };

                                db.ExecuteNonQuery(insertTLQuery, tlParameters);
                            }
                        }
                    }

                    // 3. Tự động chấm điểm các câu hỏi trắc nghiệm
                    if (maBaiLam > 0)
                    {
                        baiLamDAO.AutoGradeMultipleChoice(maBaiLam);

                        // Tính tổng điểm và cập nhật vào bảng BaiLam
                        baiLamDAO.CalculateTotalScore(maBaiLam);
                    }

                    MessageBox.Show("Bài làm của bạn đã được nộp thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nộp bài: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
                }

                // Đóng form
                this.Close();
            }
        }


        #endregion


        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblQuestionMap_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }
    }
}
