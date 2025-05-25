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
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyEx : Form
    {
        private BaiKiemTraDAO bktDAO;
        private BaiLamDAO baiLamDAO;
        private int currentMaGV; // Mã giáo viên hiện tại
        private int currentMaBaiKT; // Mã bài kiểm tra được chọn
        private int currentMaBaiLam; // Mã bài làm được chọn
        private BaiLamDTO currentBaiLam; // Bài làm hiện tại đang xem
        private int currentQuestionIndex; // Chỉ số câu hỏi hiện tại
        private List<object> danhSachCauHoi; // Danh sách kết hợp câu hỏi trắc nghiệm và tự luận

        // Biến theo dõi di chuyển form
        private bool isDragging = false;
        private Point startPoint;

        public frmQuanLyEx(int maGV = 0)
        {
            InitializeComponent();
            bktDAO = new BaiKiemTraDAO();
            baiLamDAO = new BaiLamDAO();
            currentMaGV = maGV;
            ucControlBar1.TitleText = "Quản lý bài kiểm tra";

            // Áp dụng bo tròn cho form
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;

            // Thiết lập cho việc di chuyển form
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlMain;
            this.guna2DragControl1.UseTransparentDrag = true;

            // Hiệu ứng khi mở form
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.guna2AnimateWindow1.Interval = 300;
            this.guna2AnimateWindow1.TargetForm = this;

            // Các thiết lập về vị trí và kích thước
            this.StartPosition = FormStartPosition.CenterScreen;
            // Đăng ký sự kiện cho form
            this.SizeChanged += FrmQuanLyEx_SizeChanged;
            this.Resize += FrmQuanLyEx_Resize;
        }

        private void FrmQuanLyEx_Resize(object sender, EventArgs e)
        {
            // Điều chỉnh vị trí của ucControlBar khi form được resize
            ucControlBar1.Width = this.Width;
        }

        private void FrmQuanLyEx_SizeChanged(object sender, EventArgs e)
        {
            // Cập nhật lại layout khi form thay đổi kích thước
            pnlMain.Location = new Point(0, ucControlBar1.Bottom);
            pnlMain.Width = this.ClientSize.Width;
            pnlMain.Height = this.ClientSize.Height - ucControlBar1.Height;
        }

        // Sửa lại phương thức frmQuanLyEx_Load để không xóa tab bài làm khỏi parent
        private void frmQuanLyEx_Load(object sender, EventArgs e)
        {
            // Thiết lập sự kiện cho các nút và điều khiển
            SetupEventHandlers();

            // Tải danh sách bài kiểm tra của giáo viên
            LoadDanhSachBaiKiemTra();

            // Thiết lập tab mặc định
            tabPanels.SelectedTab = tabBaiKiemTra;
            tabChiTiet.SelectedTab = tabThongKe;

            // CHỈ ẨN TAB BÀI LÀM KHỎI TABCONTROL (KHÔNG XÓA KHỎI PARENT)
            if (tabPanels.TabPages.Contains(tabBaiLam))
            {
                tabPanels.TabPages.Remove(tabBaiLam);
            }

            // Cập nhật lại giao diện
            ApplyUISettings();
        }

        private void ApplyUISettings()
        {
            // Thiết lập UI cho DataGridView
            ConfigureDataGridViewStyle(grdBaiKiemTra);
            ConfigureDataGridViewStyle(grdBaiLam);

            // Thiết lập màu cho các nút
            btnRefresh.ForeColor = Color.White;
            btnChamAll.ForeColor = Color.White;
            btnQuayLai.ForeColor = Color.White;
            btnChamDiem.ForeColor = Color.White;
            btnLuu.ForeColor = Color.White;
            btnCauTruoc.ForeColor = Color.White;
            btnCauTiepTheo.ForeColor = Color.White;

            // Thiết lập hover effect cho các nút
            ConfigureButtonHoverEffects();
        }

        private void ConfigureDataGridViewStyle(Guna2DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.RowTemplate.Height = 28;
            dataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
            dataGridView.BackgroundColor = Color.WhiteSmoke;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;
        }

        private void ConfigureButtonHoverEffects()
        {
            // Thiết lập hiệu ứng hover cho các nút
            Guna2Button[] buttons = new Guna2Button[]
            {
                    btnRefresh, btnChamAll, btnQuayLai,
                    btnChamDiem, btnLuu, btnCauTruoc,
                    btnCauTiepTheo
            };

            foreach (var button in buttons)
            {
                button.HoverState.FillColor = Color.FromArgb(40, 52, 70);
                button.HoverState.ForeColor = Color.White;
            }
        }

        private void SetupEventHandlers()
        {
            // Sự kiện cho các nút
            btnRefresh.Click += BtnRefresh_Click;
            btnChamAll.Click += BtnChamAll_Click;
            btnQuayLai.Click += BtnQuayLai_Click;
            btnChamDiem.Click += BtnChamDiem_Click;
            btnLuu.Click += BtnLuu_Click;
            btnCauTruoc.Click += BtnCauTruoc_Click;
            btnCauTiepTheo.Click += BtnCauTiepTheo_Click;

            // Sự kiện cho DataGridView
            grdBaiKiemTra.CellClick += GrdBaiKiemTra_CellClick;
            grdBaiKiemTra.CellDoubleClick += GrdBaiKiemTra_CellDoubleClick; // Thêm sự kiện double-click
            grdBaiLam.CellClick += GrdBaiLam_CellClick;
            // Có thể thêm sự kiện double-click cho grdBaiLam nếu cần
            grdBaiLam.CellDoubleClick += GrdBaiLam_CellDoubleClick;

            // Sự kiện thay đổi tab
            tabPanels.SelectedIndexChanged += TabPanels_SelectedIndexChanged;
            tabChiTiet.SelectedIndexChanged += TabChiTiet_SelectedIndexChanged;
        }
        private void GrdBaiLam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdBaiLam.Rows.Count)
            {
                DataGridViewRow row = grdBaiLam.Rows[e.RowIndex];

                // Lấy mã bài làm từ hàng được chọn
                if (int.TryParse(row.Cells["MaBaiLam"].Value.ToString(), out int maBaiLam))
                {
                    currentMaBaiLam = maBaiLam;

                    // Double-click trực tiếp chuyển sang chấm điểm
                    BtnChamDiem_Click(sender, e);
                }
            }
        }

        private void TabPanels_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị hiệu ứng loading
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Xử lý khi chuyển tab chính
                if (tabPanels.SelectedTab == tabBaiKiemTra)
                {
                    // Chỉ tải lại nếu cần thiết (điều kiện có thể thêm)
                    if (currentMaGV > 0)
                        LoadDanhSachBaiKiemTra();
                }
                else if (tabPanels.SelectedTab == tabBaiLam)
                {
                    // Chỉ tải lại nếu cần thiết và đã có bài kiểm tra được chọn
                    if (currentMaBaiKT > 0)
                        LoadDanhSachBaiLam(currentMaBaiKT);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void TabChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị hiệu ứng loading
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Xử lý khi chuyển tab chi tiết
                if (tabChiTiet.SelectedTab == tabThongKe)
                {
                    // Luôn cập nhật thống kê khi chuyển tới tab
                    if (currentMaBaiKT > 0)
                        LoadThongKe(currentMaBaiKT);
                }
                else if (tabChiTiet.SelectedTab == tabChamBai)
                {
                    // Chỉ tải bài làm nếu đã chọn một bài làm và nút chấm điểm không khả dụng
                    // (nghĩa là chúng ta đang ở trong quá trình chấm bài)
                    if (currentMaBaiLam > 0 && !btnChamDiem.Enabled)
                        LoadBaiLam(currentMaBaiLam);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải dữ liệu chi tiết: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshFormData()
        {
            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Xác định tab hiện tại và làm mới dữ liệu phù hợp
                if (tabPanels.SelectedTab == tabBaiKiemTra)
                {
                    // Làm mới danh sách bài kiểm tra
                    if (currentMaGV > 0)
                        LoadDanhSachBaiKiemTra();
                }
                else if (tabPanels.SelectedTab == tabBaiLam)
                {
                    // Làm mới danh sách bài làm
                    if (currentMaBaiKT > 0)
                        LoadDanhSachBaiLam(currentMaBaiKT);

                    // Cập nhật thống kê nếu đang hiển thị
                    if (tabChiTiet.SelectedTab == tabThongKe && currentMaBaiKT > 0)
                        LoadThongKe(currentMaBaiKT);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        // Sửa lại BtnRefresh_Click để tránh gọi hàm load dữ liệu hai lần
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // Chỉ gọi RefreshFormData() vì nó đã bao gồm việc làm mới dữ liệu theo tab hiện tại
            RefreshFormData();
        }

        private void BtnChamAll_Click(object sender, EventArgs e)
        {
            if (currentMaBaiKT <= 0)
            {
                ShowMessage("Vui lòng chọn một bài kiểm tra để chấm!", "Thông báo", MessageBoxIcon.Information);
                return;
            }

            // Lấy danh sách các bài làm của bài kiểm tra
            List<BaiLamDTO> danhSachBaiLam = baiLamDAO.GetSubmissionsByTestId(currentMaBaiKT);

            int successCount = 0;
            int savedToDiemSo = 0;
            foreach (var baiLam in danhSachBaiLam)
            {
                // Ensure we're calling the method with the correct parameter
                if (baiLamDAO.AutoGradeMultipleChoice(baiLam.MaBaiLam))
                {
                    // Also calculate the total score
                    baiLamDAO.CalculateTotalScore(baiLam.MaBaiLam);
                    successCount++;

                    // If the submission only has multiple choice questions or all essay questions are graded
                    if (baiLamDAO.AreAllEssayQuestionsGraded(baiLam.MaBaiLam))
                    {
                        // Save to DiemSo table
                        if (baiLamDAO.SaveTestScoreToDiemSo(baiLam.MaBaiLam))
                        {
                            savedToDiemSo++;
                        }
                    }
                }
            }

            ShowMessage($"Đã chấm tự động {successCount}/{danhSachBaiLam.Count} bài và cập nhật {savedToDiemSo} bài vào bảng điểm số!", "Thông báo", MessageBoxIcon.Information);

            // Refresh the display
            if (currentMaBaiKT > 0)
            {
                LoadThongKe(currentMaBaiKT);
                // Also refresh the submissions list if it's currently visible
                if (tabPanels.SelectedTab == tabBaiLam)
                {
                    LoadDanhSachBaiLam(currentMaBaiKT);
                }
            }
        }

        // Sửa lại phương thức BtnQuayLai_Click để không xóa tab bài làm khỏi parent
        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            // Chỉ chuyển tab mà không xóa nó khỏi TabControl
            tabPanels.SelectedTab = tabBaiKiemTra;
        }

        private void BtnChamDiem_Click(object sender, EventArgs e)
        {
            if (currentMaBaiLam <= 0)
            {
                ShowMessage("Vui lòng chọn một bài làm để chấm!", "Thông báo", MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Chấm tự động các câu trắc nghiệm
                baiLamDAO.AutoGradeMultipleChoice(currentMaBaiLam);

                // Cập nhật tổng điểm
                baiLamDAO.CalculateTotalScore(currentMaBaiLam);

                // Check if all questions are already graded (e.g., only multiple choice)
                if (baiLamDAO.AreAllEssayQuestionsGraded(currentMaBaiLam))
                {
                    // Save to DiemSo table
                    baiLamDAO.SaveTestScoreToDiemSo(currentMaBaiLam);
                    ShowMessage("Điểm đã được tự động lưu vào bảng điểm số!", "Thông báo", MessageBoxIcon.Information);
                }

                // Chuyển sang tab chấm bài
                tabChiTiet.SelectedTab = tabChamBai;

                // Tải thông tin bài làm
                LoadBaiLam(currentMaBaiLam);
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi chấm điểm: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (currentBaiLam == null || danhSachCauHoi == null || currentQuestionIndex < 0 || currentQuestionIndex >= danhSachCauHoi.Count)
            {
                ShowMessage("Không có câu hỏi nào để lưu điểm!", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra loại câu hỏi hiện tại
            var currentQuestion = danhSachCauHoi[currentQuestionIndex];

            if (currentQuestion is BaiLamTuLuanDTO)
            {
                BaiLamTuLuanDTO cauHoiTL = (BaiLamTuLuanDTO)currentQuestion;

                // Kiểm tra và chuyển đổi điểm
                if (!double.TryParse(txtDiem.Text, out double diem))
                {
                    ShowMessage("Vui lòng nhập điểm hợp lệ!", "Lỗi", MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra giới hạn điểm
                if (diem < 0 || diem > cauHoiTL.DiemToiDa)
                {
                    ShowMessage($"Điểm phải nằm trong khoảng từ 0 đến {cauHoiTL.DiemToiDa}!", "Lỗi", MessageBoxIcon.Error);
                    return;
                }

                // Lưu điểm và nhận xét cho câu hỏi tự luận
                bool success = baiLamDAO.UpdateEssayGrade(currentBaiLam.MaBaiLam, cauHoiTL.MaCauHoiTL, diem, txtNhanXet.Text);

                if (success)
                {
                    // Cập nhật lại điểm trong đối tượng hiện tại
                    cauHoiTL.Diem = diem;
                    cauHoiTL.NhanXet = txtNhanXet.Text;

                    // Cập nhật tổng điểm
                    double totalScore = baiLamDAO.CalculateTotalScore(currentBaiLam.MaBaiLam);

                    // Check if all essay questions are graded
                    bool allGraded = baiLamDAO.AreAllEssayQuestionsGraded(currentBaiLam.MaBaiLam);

                    // If all questions are graded, save to DiemSo table
                    if (allGraded)
                    {
                        try
                        {
                            if (baiLamDAO.SaveTestScoreToDiemSo(currentBaiLam.MaBaiLam))
                            {
                                ShowMessage("Đã lưu điểm và cập nhật vào bảng điểm số của học sinh!", "Thông báo", MessageBoxIcon.Information);
                            }
                            else
                            {
                                ShowMessage("Đã lưu điểm nhưng không thể cập nhật vào bảng điểm số!", "Cảnh báo", MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowMessage($"Đã lưu điểm nhưng gặp lỗi khi cập nhật vào bảng điểm số: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        ShowMessage("Đã lưu điểm thành công! Điểm sẽ được cập nhật vào bảng điểm số khi tất cả câu hỏi được chấm.", "Thông báo", MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ShowMessage("Lỗi khi lưu điểm!", "Lỗi", MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowMessage("Câu hỏi trắc nghiệm được chấm tự động!", "Thông báo", MessageBoxIcon.Information);
            }
        }

        private void BtnCauTruoc_Click(object sender, EventArgs e)
        {
            if (danhSachCauHoi != null && danhSachCauHoi.Count > 0)
            {
                // Giảm chỉ số câu hỏi hiện tại
                currentQuestionIndex--;
                if (currentQuestionIndex < 0)
                {
                    currentQuestionIndex = 0;
                }

                // Hiển thị câu hỏi mới
                DisplayQuestion(currentQuestionIndex);

                // Cập nhật trạng thái nút
                UpdateNavigationButtonState();
            }
        }

        private void BtnCauTiepTheo_Click(object sender, EventArgs e)
        {
            if (danhSachCauHoi != null && danhSachCauHoi.Count > 0)
            {
                // Tăng chỉ số câu hỏi hiện tại
                currentQuestionIndex++;
                if (currentQuestionIndex >= danhSachCauHoi.Count)
                {
                    currentQuestionIndex = danhSachCauHoi.Count - 1;
                }

                // Hiển thị câu hỏi mới
                DisplayQuestion(currentQuestionIndex);

                // Cập nhật trạng thái nút
                UpdateNavigationButtonState();
            }
        }

        private void GrdBaiKiemTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdBaiKiemTra.Rows.Count)
            {
                DataGridViewRow row = grdBaiKiemTra.Rows[e.RowIndex];

                // Lấy mã bài kiểm tra từ hàng được chọn
                if (int.TryParse(row.Cells["MaBaiKT"].Value.ToString(), out int maBaiKT))
                {
                    currentMaBaiKT = maBaiKT;

                    // Chỉ tải thông kê của bài kiểm tra khi click
                    LoadThongKe(maBaiKT);

                    // Highlight dòng được chọn
                    grdBaiKiemTra.ClearSelection();
                    row.Selected = true;
                }
            }
        }
        private void GrdBaiKiemTra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdBaiKiemTra.Rows.Count)
            {
                DataGridViewRow row = grdBaiKiemTra.Rows[e.RowIndex];

                // Lấy mã bài kiểm tra từ hàng được chọn
                if (int.TryParse(row.Cells["MaBaiKT"].Value.ToString(), out int maBaiKT))
                {
                    currentMaBaiKT = maBaiKT;

                    // Tải thông kê của bài kiểm tra
                    LoadThongKe(maBaiKT);

                    // Tải danh sách bài làm khi double-click
                    LoadDanhSachBaiLam(maBaiKT);
                }
            }
        }

        private void GrdBaiLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdBaiLam.Rows.Count)
            {
                DataGridViewRow row = grdBaiLam.Rows[e.RowIndex];

                // Lấy mã bài làm từ hàng được chọn
                if (int.TryParse(row.Cells["MaBaiLam"].Value.ToString(), out int maBaiLam))
                {
                    currentMaBaiLam = maBaiLam;

                    // Hiển thị nút chấm điểm
                    btnChamDiem.Enabled = true;
                }
            }
        }

        // Sửa phương thức LoadDanhSachBaiKiemTra để không xóa tab bài làm
        private void LoadDanhSachBaiKiemTra()
        {
            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Lấy danh sách bài kiểm tra của giáo viên
                List<BaiKiemTraDTO> danhSachBaiKT = bktDAO.GetTestsByTeacher(currentMaGV);

                // Tạo DataTable để hiển thị
                DataTable dt = new DataTable();
                dt.Columns.Add("MaBaiKT", typeof(int));
                dt.Columns.Add("TenBaiKT", typeof(string));
                dt.Columns.Add("TenMonHoc", typeof(string));
                dt.Columns.Add("TenLop", typeof(string));
                dt.Columns.Add("NgayTao", typeof(DateTime));
                dt.Columns.Add("TrangThai", typeof(string));

                // Thêm dữ liệu vào DataTable
                foreach (var bkt in danhSachBaiKT)
                {
                    dt.Rows.Add(bkt.MaBaiKT, bkt.TenBaiKT, bkt.TenMonHoc, bkt.TenLop, bkt.NgayTao, bkt.TrangThai);
                }

                // Hiển thị dữ liệu trên DataGridView
                grdBaiKiemTra.DataSource = dt;

                // Định dạng lại các cột
                grdBaiKiemTra.Columns["MaBaiKT"].HeaderText = "Mã";
                grdBaiKiemTra.Columns["TenBaiKT"].HeaderText = "Tên bài kiểm tra";
                grdBaiKiemTra.Columns["TenMonHoc"].HeaderText = "Môn học";
                grdBaiKiemTra.Columns["TenLop"].HeaderText = "Lớp";
                grdBaiKiemTra.Columns["NgayTao"].HeaderText = "Ngày tạo";
                grdBaiKiemTra.Columns["TrangThai"].HeaderText = "Trạng thái";

                // Xóa lựa chọn hiện tại
                currentMaBaiKT = 0;

                // Xóa thông tin thống kê
                ClearThongKe();

                // CHỈ ẨN TAB BÀI LÀM KHỎI TABCONTROL NẾU ĐANG HIỂN THỊ
                // THAY VÌ XÓA NÓ KHỎI COLLECTION
                if (tabPanels.TabPages.Contains(tabBaiLam))
                {
                    // Tạm ẩn tab bài làm (không xóa khỏi collection)
                    tabPanels.TabPages.Remove(tabBaiLam);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải danh sách bài kiểm tra: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadThongKe(int maBaiKT)
        {
            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Lấy thống kê của bài kiểm tra
                Dictionary<string, object> stats = baiLamDAO.GetTestStatistics(maBaiKT);

                // Hiển thị thông tin
                if (stats.ContainsKey("TenBaiKT"))
                    lblTenBaiKT.Text = $"Tên bài kiểm tra: {stats["TenBaiKT"]}";

                if (stats.ContainsKey("DiemDatYeuCau"))
                    lblDiemDatYeuCau.Text = $"Điểm đạt yêu cầu: {stats["DiemDatYeuCau"]}";

                if (stats.ContainsKey("TongBaiLam"))
                    lblTongBaiLam.Text = $"Tổng bài làm: {stats["TongBaiLam"]}";

                if (stats.ContainsKey("SoBaiDaCham"))
                    lblSoBaiDaCham.Text = $"Số bài đã chấm: {stats["SoBaiDaCham"]}";

                if (stats.ContainsKey("DiemTrungBinh"))
                    lblDiemTrungBinh.Text = $"Điểm trung bình: {Math.Round((double)stats["DiemTrungBinh"], 2)}";

                if (stats.ContainsKey("DiemCaoNhat"))
                    lblDiemCaoNhat.Text = $"Điểm cao nhất: {stats["DiemCaoNhat"]}";

                if (stats.ContainsKey("DiemThapNhat"))
                    lblDiemThapNhat.Text = $"Điểm thấp nhất: {stats["DiemThapNhat"]}";

                if (stats.ContainsKey("SoLuongDat"))
                    lblSoLuongDat.Text = $"Số lượng đạt: {stats["SoLuongDat"]}";

                if (stats.ContainsKey("TyLeDat"))
                    lblTyLeDat.Text = $"Tỷ lệ đạt: {Math.Round((double)stats["TyLeDat"] * 100, 2)}%";
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ClearThongKe()
        {
            lblTenBaiKT.Text = "Tên bài kiểm tra: ";
            lblDiemDatYeuCau.Text = "Điểm đạt yêu cầu: ";
            lblTongBaiLam.Text = "Tổng bài làm: ";
            lblSoBaiDaCham.Text = "Số bài đã chấm: ";
            lblDiemTrungBinh.Text = "Điểm trung bình: ";
            lblDiemCaoNhat.Text = "Điểm cao nhất: ";
            lblDiemThapNhat.Text = "Điểm thấp nhất: ";
            lblSoLuongDat.Text = "Số lượng đạt: ";
            lblTyLeDat.Text = "Tỷ lệ đạt: ";
        }

        // Sửa lại phương thức LoadDanhSachBaiLam để thêm tab một cách nhất quán
        private void LoadDanhSachBaiLam(int maBaiKT)
        {
            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Lấy danh sách bài làm của bài kiểm tra
                List<BaiLamDTO> danhSachBaiLam = baiLamDAO.GetSubmissionsByTestId(maBaiKT);

                // Tạo DataTable để hiển thị
                DataTable dt = new DataTable();
                dt.Columns.Add("MaBaiLam", typeof(int));
                dt.Columns.Add("TenHocSinh", typeof(string));
                dt.Columns.Add("TenLop", typeof(string));
                dt.Columns.Add("NgayLam", typeof(DateTime));
                dt.Columns.Add("ThoiGianLamBai", typeof(int));
                dt.Columns.Add("DiemSo", typeof(string));
                dt.Columns.Add("TrangThai", typeof(string));

                // Thêm dữ liệu vào DataTable
                foreach (var baiLam in danhSachBaiLam)
                {
                    string diemSo = baiLam.DiemSo.HasValue ? baiLam.DiemSo.Value.ToString() : "Chưa chấm";
                    string trangThai = baiLam.DaNop ? "Đã nộp" : "Chưa nộp";

                    dt.Rows.Add(
                        baiLam.MaBaiLam,
                        baiLam.TenHocSinh,
                        baiLam.TenLop,
                        baiLam.NgayLam,
                        baiLam.ThoiGianLamBai,
                        diemSo,
                        trangThai);
                }

                // Hiển thị dữ liệu trên DataGridView
                grdBaiLam.DataSource = dt;

                // Chỉ định dạng lại các cột khi có dữ liệu
                if (dt.Rows.Count > 0 && grdBaiLam.Columns.Count > 0)
                {
                    grdBaiLam.Columns["MaBaiLam"].HeaderText = "Mã";
                    grdBaiLam.Columns["TenHocSinh"].HeaderText = "Họ tên";
                    grdBaiLam.Columns["TenLop"].HeaderText = "Lớp";
                    grdBaiLam.Columns["NgayLam"].HeaderText = "Ngày làm";
                    grdBaiLam.Columns["ThoiGianLamBai"].HeaderText = "Thời gian (phút)";
                    grdBaiLam.Columns["DiemSo"].HeaderText = "Điểm số";
                    grdBaiLam.Columns["TrangThai"].HeaderText = "Trạng thái";
                }

                // ĐẢM BẢO TAB BÀI LÀM ĐƯỢC THÊM VÀO TABCONTROL ĐÚNG CÁCH
                // Chỉ thêm tab nếu nó chưa có trong TabControl
                if (!tabPanels.TabPages.Contains(tabBaiLam))
                {
                    tabPanels.TabPages.Add(tabBaiLam);
                }

                // Chuyển đến tab bài làm
                tabPanels.SelectedTab = tabBaiLam;

                // Xóa lựa chọn hiện tại
                currentMaBaiLam = 0;
                btnChamDiem.Enabled = false;
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải danh sách bài làm: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadBaiLam(int maBaiLam)
        {
            try
            {
                // Hiển thị hiệu ứng loading
                Cursor = Cursors.WaitCursor;

                // Lấy thông tin chi tiết bài làm
                currentBaiLam = baiLamDAO.GetSubmissionById(maBaiLam);

                if (currentBaiLam != null)
                {
                    // Hiển thị thông tin học sinh
                    lblHoTen.Text = $"Học sinh: {currentBaiLam.TenHocSinh}";
                    lblLop.Text = $"Lớp: {currentBaiLam.TenLop}";
                    lblNgayLam.Text = $"Ngày làm: {currentBaiLam.NgayLam:dd/MM/yyyy HH:mm}";
                    lblThoiGianLamBai.Text = $"Thời gian làm bài: {currentBaiLam.ThoiGianLamBai} phút";

                    // Kết hợp câu hỏi trắc nghiệm và tự luận, sắp xếp theo thứ tự
                    danhSachCauHoi = new List<object>();

                    // Thêm các câu trắc nghiệm
                    foreach (var tn in currentBaiLam.CauTraLoiTracNghiem.OrderBy(q => q.ThuTu))
                    {
                        danhSachCauHoi.Add(tn);
                    }

                    // Thêm các câu tự luận
                    foreach (var tl in currentBaiLam.CauTraLoiTuLuan.OrderBy(q => q.ThuTu))
                    {
                        danhSachCauHoi.Add(tl);
                    }

                    // Hiển thị câu hỏi đầu tiên
                    if (danhSachCauHoi.Count > 0)
                    {
                        currentQuestionIndex = 0;
                        DisplayQuestion(currentQuestionIndex);
                    }
                    else
                    {
                        ShowMessage("Bài làm không có câu hỏi nào!", "Thông báo", MessageBoxIcon.Information);
                    }

                    // Cập nhật trạng thái nút điều hướng
                    UpdateNavigationButtonState();
                }
                else
                {
                    ShowMessage("Không tìm thấy thông tin bài làm!", "Lỗi", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải bài làm: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DisplayQuestion(int index)
        {
            if (danhSachCauHoi == null || index < 0 || index >= danhSachCauHoi.Count)
            {
                return;
            }

            // Lấy câu hỏi hiện tại
            var question = danhSachCauHoi[index];

            // Hiển thị nội dung chung của câu hỏi
            txtNoiDungCauHoi.Clear();

            // Hiển thị dựa trên loại câu hỏi
            if (question is BaiLamTracNghiemDTO)
            {
                BaiLamTracNghiemDTO tn = (BaiLamTracNghiemDTO)question;

                // Hiển thị nội dung câu hỏi
                txtNoiDungCauHoi.Text = $"Câu {index + 1} (Trắc nghiệm): {tn.NoiDungCauHoi}";

                // Hiển thị đáp án của học sinh
                lblDapAnHS.Text = $"Đáp án của học sinh: {(string.IsNullOrEmpty(tn.CauTraLoi) ? "Không trả lời" : tn.CauTraLoi)}";

                // Hiển thị đáp án đúng
                lblDapAnDung.Text = $"Đáp án đúng: {tn.DapAnDung}";

                // Hiển thị các lựa chọn
                rdbA.Text = tn.DanhSachLuaChon.FirstOrDefault(o => o.NhanDang == "A")?.NoiDung ?? "A";
                rdbB.Text = tn.DanhSachLuaChon.FirstOrDefault(o => o.NhanDang == "B")?.NoiDung ?? "B";
                rdbC.Text = tn.DanhSachLuaChon.FirstOrDefault(o => o.NhanDang == "C")?.NoiDung ?? "C";
                rdbD.Text = tn.DanhSachLuaChon.FirstOrDefault(o => o.NhanDang == "D")?.NoiDung ?? "D";

                // Chọn đáp án của học sinh
                rdbA.Checked = tn.CauTraLoi == "A";
                rdbB.Checked = tn.CauTraLoi == "B";
                rdbC.Checked = tn.CauTraLoi == "C";
                rdbD.Checked = tn.CauTraLoi == "D";

                // Hiển thị điểm
                txtDiem.Text = tn.Diem?.ToString() ?? "";
                txtDiem.ReadOnly = true;

                // Hiển thị hướng dẫn đáp án
                txtHuongDanDapAn.Text = $"Câu hỏi trắc nghiệm được chấm tự động.\nĐiểm: {tn.DiemToiDa} điểm.";

                // Không cho phép nhập nhận xét cho câu trắc nghiệm
                txtNhanXet.Text = "Không có nhận xét cho câu trắc nghiệm";
                txtNhanXet.ReadOnly = true;

                // Hiển thị panel trắc nghiệm, ẩn panel tự luận
                pnlTracNghiem.Visible = true;
                pnlTuLuan.Visible = false;
            }
            else if (question is BaiLamTuLuanDTO)
            {
                BaiLamTuLuanDTO tl = (BaiLamTuLuanDTO)question;

                // Hiển thị nội dung câu hỏi
                txtNoiDungCauHoi.Text = $"Câu {index + 1} (Tự luận): {tl.NoiDungCauHoi}";

                // Hiển thị câu trả lời của học sinh
                txtCauTraLoiHS.Text = string.IsNullOrEmpty(tl.CauTraLoi) ? "Học sinh không trả lời" : tl.CauTraLoi;

                // Hiển thị điểm
                txtDiem.Text = tl.Diem?.ToString() ?? "";
                txtDiem.ReadOnly = false;

                // Hiển thị hướng dẫn đáp án
                txtHuongDanDapAn.Text = string.IsNullOrEmpty(tl.HuongDanTraLoi) ?
                    "Không có hướng dẫn đáp án" : tl.HuongDanTraLoi;

                // Hiển thị nhận xét
                txtNhanXet.Text = tl.NhanXet ?? "";
                txtNhanXet.ReadOnly = false;

                // Hiển thị panel tự luận, ẩn panel trắc nghiệm
                pnlTracNghiem.Visible = false;
                pnlTuLuan.Visible = true;
            }
        }

        private void UpdateNavigationButtonState()
        {
            // Cập nhật trạng thái của các nút điều hướng
            btnCauTruoc.Enabled = currentQuestionIndex > 0;
            btnCauTiepTheo.Enabled = danhSachCauHoi != null && currentQuestionIndex < danhSachCauHoi.Count - 1;

            // Cập nhật trạng thái nút Lưu
            if (danhSachCauHoi != null && currentQuestionIndex >= 0 && currentQuestionIndex < danhSachCauHoi.Count)
            {
                var question = danhSachCauHoi[currentQuestionIndex];
                btnLuu.Enabled = question is BaiLamTuLuanDTO;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }


        #region Tiện ích

        private void ShowMessage(string message, string caption, MessageBoxIcon icon)
        {
            // Tạo và hiển thị thông báo tùy chỉnh
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        #endregion

        private void btnChamAll_Click_1(object sender, EventArgs e)
        {

        }


    }
}
