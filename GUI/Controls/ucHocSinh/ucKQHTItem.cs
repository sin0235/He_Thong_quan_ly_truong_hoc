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
    public partial class ucKQHTItem : UserControl
    {
        #region Layout và Hiển thị

        /// <summary>
        /// Điều chỉnh kích thước ucKQHTItem theo chiều rộng của container
        /// </summary>
        /// <param name="containerWidth">Chiều rộng của container</param>
        public void AdjustToContainerWidth(int containerWidth)
        {
            try
            {
                if (containerWidth <= 0) return;

                // Tính toán kích thước mới, trừ đi lề phù hợp
                int newWidth = containerWidth - 30;

                // Chỉ cập nhật khi kích thước thực sự thay đổi
                if (this.Width != newWidth)
                {
                    this.Width = newWidth;

                    // Áp dụng kích thước mới cho pnlMain
                    pnlMain.Width = newWidth - 20;

                    // Đảm bảo kích thước tối thiểu cho các thành phần
                    if (pnlMain.Width < 600)
                        pnlMain.Width = 600;

                    // Cập nhật vị trí và kích thước của tất cả các thành phần
                    UpdateLayoutOnResize();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi điều chỉnh kích thước: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật lại giao diện khi kích thước thay đổi
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateLayoutOnResize();
        }

        /// <summary>
        /// Cập nhật vị trí các control khi kích thước thay đổi
        /// </summary>
        private void UpdateLayoutOnResize()
        {
            try
            {
                // Cập nhật kích thước pnlMain để lấp đầy không gian có sẵn
                pnlMain.Width = this.Width - 20;

                // Cập nhật kích thước các panel con để phù hợp với pnlMain
                if (pnlHeader != null)
                    pnlHeader.Width = pnlMain.Width;

                if (pnlScoreDetails != null)
                    pnlScoreDetails.Width = pnlMain.Width;

                if (pnlTeacherComment != null)
                    pnlTeacherComment.Width = pnlMain.Width;

                // Điều chỉnh vị trí của vòng tròn hiển thị điểm trung bình
                if (prgAverage != null)
                {
                    prgAverage.Left = pnlScoreDetails.Width - prgAverage.Width - 30;
                }

                // Điều chỉnh nút chi tiết và nhãn điểm trung bình
                if (btnDetails != null)
                {
                    btnDetails.Left = pnlHeader.Width - btnDetails.Width - 30;
                }

                if (lblAvgScore != null)
                {
                    lblAvgScore.Left = btnDetails.Left - lblAvgScore.Width - 20;
                }

                // Tính toán chiều rộng hợp lý cho các progress bar
                int maxProgressBarWidth = pnlScoreDetails.Width - 250 - prgAverage.Width;
                int progressBarWidth = Math.Min(maxProgressBarWidth, 600); // Giới hạn chiều rộng tối đa

                // Cập nhật chiều rộng của các progress bar
                if (prgAssignment != null)
                    prgAssignment.Width = progressBarWidth;

                if (prgMidtermExam != null)
                    prgMidtermExam.Width = progressBarWidth;

                if (prgFinalExam != null)
                    prgFinalExam.Width = progressBarWidth;

                // Điều chỉnh txtTeacherComment để sử dụng hết không gian
                if (txtTeacherComment != null)
                {
                    txtTeacherComment.Width = pnlTeacherComment.Width - 30;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật layout: {ex.Message}");
            }
        }

        /// <summary>
        /// Đặt margin cho control để tạo khoảng cách giữa các item
        /// </summary>
        public void SetItemMargin(int top = 0, int bottom = 10)
        {
            this.Margin = new Padding(0, top, 0, bottom);
        }

        #endregion

        #region Thuộc tính và Dữ liệu

        // Thông tin môn học
        private string _subjectName = "";

        // Điểm miệng
        private List<float> _diemMiengList = new List<float>();
        private float _diemMiengTB = 0;

        // Điểm 15 phút
        private List<float> _diem15PhutList = new List<float>();
        private float _diem15PhutTB = 0;

        // Điểm thường xuyên (trung bình của điểm miệng và 15 phút)
        private float _diemThuongXuyen = 0;

        // Điểm giữa kỳ
        private List<float> _diemGiuaKyList = new List<float>();
        private float _diemGiuaKyTB = 0;

        // Điểm cuối kỳ
        private List<float> _diemCuoiKyList = new List<float>();
        private float _diemCuoiKyTB = 0;

        // Điểm trung bình
        private float _diemTrungBinh = 0;

        // Nhận xét giáo viên
        private string _nhanXet = "";

        #endregion

        #region Thuộc tính công khai

        // Tên môn học
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = value;
                lblSubjectName.Text = value;
            }
        }

        // Danh sách điểm miệng
        public List<float> DiemMiengList
        {
            get { return _diemMiengList; }
            set
            {
                _diemMiengList = value ?? new List<float>();
                TinhDiemMiengTB();
            }
        }

        // Danh sách điểm 15 phút
        public List<float> Diem15PhutList
        {
            get { return _diem15PhutList; }
            set
            {
                _diem15PhutList = value ?? new List<float>();
                TinhDiem15PhutTB();
            }
        }

        // Điểm thường xuyên (trung bình của điểm miệng và 15 phút)
        public float DiemThuongXuyen
        {
            get { return _diemThuongXuyen; }
            private set
            {
                _diemThuongXuyen = value;
                lblAssignmentScore.Text = value.ToString("0.0");

                // Cập nhật progress bar
                if (prgAssignment.Maximum != 100) prgAssignment.Maximum = 100;
                prgAssignment.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);

                // Cập nhật điểm trung bình
                TinhDiemTrungBinh();
            }
        }

        // Danh sách điểm giữa kỳ
        public List<float> DiemGiuaKyList
        {
            get { return _diemGiuaKyList; }
            set
            {
                _diemGiuaKyList = value ?? new List<float>();
                TinhDiemGiuaKyTB();
            }
        }

        // Điểm giữa kỳ trung bình
        public float DiemGiuaKyTB
        {
            get { return _diemGiuaKyTB; }
            private set
            {
                _diemGiuaKyTB = value;
                lblMidtermExamScore.Text = value.ToString("0.0");

                // Cập nhật progress bar
                prgMidtermExam.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);

                // Cập nhật điểm trung bình
                TinhDiemTrungBinh();
            }
        }

        // Danh sách điểm cuối kỳ
        public List<float> DiemCuoiKyList
        {
            get { return _diemCuoiKyList; }
            set
            {
                _diemCuoiKyList = value ?? new List<float>();
                TinhDiemCuoiKyTB();
            }
        }

        // Điểm cuối kỳ trung bình
        public float DiemCuoiKyTB
        {
            get { return _diemCuoiKyTB; }
            private set
            {
                _diemCuoiKyTB = value;
                lblFinalExamScore.Text = value.ToString("0.0");

                // Cập nhật progress bar
                prgFinalExam.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);

                // Cập nhật điểm trung bình
                TinhDiemTrungBinh();
            }
        }

        // Điểm trung bình
        public float DiemTrungBinh
        {
            get { return _diemTrungBinh; }
            set
            {
                _diemTrungBinh = value;
                lblAvgScore.Text = value.ToString("0.0");

                // Cập nhật progress bar vòng tròn
                prgAverage.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);
                prgAverage.Text = value.ToString("0.0");

                // Cập nhật màu sắc dựa trên điểm
                CapNhatMauDiem();
            }
        }

        // Nhận xét giáo viên
        public string NhanXet
        {
            get { return _nhanXet; }
            set
            {
                _nhanXet = value;
                txtTeacherComment.Text = value;
            }
        }

        #endregion

        #region Phương thức tính điểm

        // Tính điểm trung bình của điểm miệng
        private void TinhDiemMiengTB()
        {
            _diemMiengTB = TinhDiemTrungBinhDanhSach(_diemMiengList);
            TinhDiemThuongXuyen();
        }

        // Tính điểm trung bình của điểm 15 phút
        private void TinhDiem15PhutTB()
        {
            _diem15PhutTB = TinhDiemTrungBinhDanhSach(_diem15PhutList);
            TinhDiemThuongXuyen();
        }

        // Tính điểm thường xuyên (trung bình của điểm miệng và 15 phút)
        private void TinhDiemThuongXuyen()
        {
            if (_diemMiengList.Count > 0 || _diem15PhutList.Count > 0)
            {
                if (_diemMiengList.Count > 0 && _diem15PhutList.Count > 0)
                {
                    // Nếu có cả 2 loại điểm, tính trung bình cộng
                    DiemThuongXuyen = (_diemMiengTB + _diem15PhutTB) / 2;
                }
                else if (_diemMiengList.Count > 0)
                {
                    // Nếu chỉ có điểm miệng
                    DiemThuongXuyen = _diemMiengTB;
                }
                else
                {
                    // Nếu chỉ có điểm 15 phút
                    DiemThuongXuyen = _diem15PhutTB;
                }
            }
            else
            {
                DiemThuongXuyen = 0;
            }
        }

        // Tính điểm trung bình của điểm giữa kỳ
        private void TinhDiemGiuaKyTB()
        {
            DiemGiuaKyTB = TinhDiemTrungBinhDanhSach(_diemGiuaKyList);
        }

        // Tính điểm trung bình của điểm cuối kỳ
        private void TinhDiemCuoiKyTB()
        {
            DiemCuoiKyTB = TinhDiemTrungBinhDanhSach(_diemCuoiKyList);
        }

        // Tính điểm trung bình chung theo tỷ trọng mới
        private void TinhDiemTrungBinh()
        {
            // Theo yêu cầu mới: 30% điểm thường xuyên, 30% điểm giữa kỳ, 40% điểm cuối kỳ
            float diemTB = (_diemThuongXuyen * 0.3f) + (_diemGiuaKyTB * 0.3f) + (_diemCuoiKyTB * 0.4f);
            DiemTrungBinh = (float)Math.Round(diemTB, 1);
        }

        // Phương thức hỗ trợ tính điểm trung bình của một danh sách điểm
        private float TinhDiemTrungBinhDanhSach(List<float> danhSachDiem)
        {
            if (danhSachDiem == null || danhSachDiem.Count == 0)
                return 0;

            float tong = 0;
            foreach (float diem in danhSachDiem)
            {
                tong += diem;
            }
            return (float)Math.Round(tong / danhSachDiem.Count, 1);
        }

        #endregion

        #region Hiển thị và màu sắc

        // Cập nhật nhãn với tỷ trọng điểm mới
        private void CapNhatNhanTyTrong()
        {
            lblAssignment.Text = "Điểm thường xuyên";
            lblMidtermExam.Text = "Điểm giữa kỳ";
            lblFinalExam.Text = "Điểm cuối kỳ";
        }

        // Cập nhật hiển thị progress bar
        private void CapNhatProgressBar()
        {
            try
            {

                // Đảm bảo các progress bar có Maximum = 100
                if (prgAssignment.Maximum != 100) prgAssignment.Maximum = 100;
                if (prgMidtermExam.Maximum != 100) prgMidtermExam.Maximum = 100;
                if (prgFinalExam.Maximum != 100) prgFinalExam.Maximum = 100;
                if (prgAverage.Maximum != 100) prgAverage.Maximum = 100;

                // Cập nhật progress bar
                prgAverage.Value = Math.Min(Math.Max((int)(DiemTrungBinh * 10), 0), 100);
                prgAverage.Text = DiemTrungBinh.ToString("0.0");

                prgAssignment.Value = Math.Min((int)(DiemThuongXuyen * 10), 100);
                prgMidtermExam.Value = Math.Min((int)(DiemGiuaKyTB * 10), 100);
                prgFinalExam.Value = Math.Min((int)(DiemCuoiKyTB * 10), 100);

                // Cập nhật màu sắc
                CapNhatMauDiem();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật progress bar: {ex.Message}");
            }
        }

        // Cập nhật màu sắc dựa trên điểm số
        private void CapNhatMauDiem()
        {
            // Đặt màu cho các progress bar dựa trên điểm số
            prgAssignment.ProgressColor = LayMauTheoDiem(DiemThuongXuyen);
            prgAssignment.ProgressColor2 = LayMauPhuTheoDiem(DiemThuongXuyen);
            lblAssignmentScore.ForeColor = LayMauTheoDiem(DiemThuongXuyen);

            prgMidtermExam.ProgressColor = LayMauTheoDiem(DiemGiuaKyTB);
            prgMidtermExam.ProgressColor2 = LayMauPhuTheoDiem(DiemGiuaKyTB);
            lblMidtermExamScore.ForeColor = LayMauTheoDiem(DiemGiuaKyTB);

            prgFinalExam.ProgressColor = LayMauTheoDiem(DiemCuoiKyTB);
            prgFinalExam.ProgressColor2 = LayMauPhuTheoDiem(DiemCuoiKyTB);
            lblFinalExamScore.ForeColor = LayMauTheoDiem(DiemCuoiKyTB);

            // Đặt màu cho điểm trung bình
            prgAverage.ProgressColor = LayMauTheoDiem(DiemTrungBinh);
            prgAverage.ProgressColor2 = LayMauPhuTheoDiem(DiemTrungBinh);
            lblAvgScore.ForeColor = LayMauTheoDiem(DiemTrungBinh);
        }

        // Lấy màu dựa trên điểm số
        private Color LayMauTheoDiem(float diem)
        {
            // Thang màu dựa trên điểm số
            if (diem >= 8.5f)
                return Color.FromArgb(0, 180, 60);  // Xanh lá đậm - điểm xuất sắc
            else if (diem >= 7.0f)
                return Color.FromArgb(90, 180, 100); // Xanh lá - điểm khá giỏi
            else if (diem >= 5.0f)
                return Color.FromArgb(240, 180, 0);  // Vàng cam - điểm trung bình
            else if (diem >= 3.5f)
                return Color.FromArgb(255, 140, 0);  // Cam - điểm yếu
            else if (diem > 0)
                return Color.FromArgb(220, 53, 69);  // Đỏ - điểm kém
            else
                return Color.FromArgb(180, 180, 180); // Xám - chưa có điểm
        }

        // Lấy màu phụ dựa trên màu chính
        private Color LayMauPhuTheoDiem(float diem)
        {
            Color mauChinh = LayMauTheoDiem(diem);
            return Color.FromArgb(
                mauChinh.A,
                Math.Min(mauChinh.R + 30, 255),
                Math.Min(mauChinh.G + 30, 255),
                Math.Min(mauChinh.B + 30, 255)
            );
        }

        #endregion

        #region Constructors & Initialization

        // Constructor mặc định
        public ucKQHTItem()
        {
            InitializeComponent();

            // Đảm bảo các progress bar có giá trị Maximum đúng
            prgAssignment.Maximum = 100;
            prgMidtermExam.Maximum = 100;
            prgFinalExam.Maximum = 100;
            prgAverage.Maximum = 100;

            // Cập nhật nhãn với tỷ trọng điểm mới
            CapNhatNhanTyTrong();

            // Đăng ký sự kiện
            this.Resize += (sender, e) => UpdateLayoutOnResize();
            btnDetails.Click += BtnDetails_Click;

            // Đặt giá trị mặc định
            lblAssignmentScore.Text = "0.0";
            lblMidtermExamScore.Text = "0.0";
            lblFinalExamScore.Text = "0.0";
            lblAvgScore.Text = "0.0";

            // Cập nhật hiển thị
            CapNhatProgressBar();
            FixProgressBars();
        }

        // Constructor với danh sách điểm đầy đủ
        public ucKQHTItem(string tenMon, List<float> diemMiengList, List<float> diem15PhutList,
                          List<float> diemGiuaKyList, List<float> diemCuoiKyList, string nhanXet = "")
        {
            InitializeComponent();

            // Khởi tạo các thuộc tính
            SubjectName = tenMon;
            DiemMiengList = diemMiengList ?? new List<float>();
            Diem15PhutList = diem15PhutList ?? new List<float>();
            DiemGiuaKyList = diemGiuaKyList ?? new List<float>();
            DiemCuoiKyList = diemCuoiKyList ?? new List<float>();
            NhanXet = nhanXet;

            // Cập nhật nhãn với tỷ trọng điểm mới
            CapNhatNhanTyTrong();

            // Đăng ký sự kiện
            btnDetails.Click += BtnDetails_Click;

            // Cập nhật hiển thị
            CapNhatProgressBar();
        }

        // Constructor tương thích ngược với hệ thống cũ
        public ucKQHTItem(string tenMon, float diemThuongXuyen, List<float> diemGiuaKyList,
                          float diemCuoiKy, string nhanXet = "")
        {
            InitializeComponent();

            SubjectName = tenMon;

            // Gán giá trị trực tiếp cho điểm thường xuyên
            _diemThuongXuyen = diemThuongXuyen;
            lblAssignmentScore.Text = diemThuongXuyen.ToString("0.0");

            // Xử lý điểm giữa kỳ
            DiemGiuaKyList = diemGiuaKyList ?? new List<float>();

            // Đối với điểm cuối kỳ, tạo một danh sách chỉ có 1 phần tử
            DiemCuoiKyList = new List<float> { diemCuoiKy };

            NhanXet = nhanXet;

            // Cập nhật nhãn tỷ trọng
            CapNhatNhanTyTrong();

            // Đăng ký sự kiện
            btnDetails.Click += BtnDetails_Click;

            // Cập nhật hiển thị
            TinhDiemTrungBinh();
            CapNhatProgressBar();
        }

        // Constructor đơn giản nhất cho tương thích
        public ucKQHTItem(string tenMon, float diemThuongXuyen, float diemGiuaKy,
                          float diemCuoiKy, string nhanXet = "")
        {
            InitializeComponent();

            SubjectName = tenMon;

            // Gán giá trị trực tiếp
            _diemThuongXuyen = diemThuongXuyen;
            lblAssignmentScore.Text = diemThuongXuyen.ToString("0.0");

            // Tạo danh sách chỉ có 1 phần tử cho điểm giữa kỳ và cuối kỳ
            DiemGiuaKyList = new List<float> { diemGiuaKy };
            DiemCuoiKyList = new List<float> { diemCuoiKy };

            NhanXet = nhanXet;

            // Cập nhật nhãn tỷ trọng
            CapNhatNhanTyTrong();

            // Đăng ký sự kiện
            btnDetails.Click += BtnDetails_Click;

            // Cập nhật hiển thị
            CapNhatProgressBar();
        }

        #endregion

        #region Events & Actions

        // Hiển thị chi tiết điểm khi nhấn nút chi tiết
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dữ liệu
            if (_diemMiengList.Count == 0 && _diem15PhutList.Count == 0 &&
                _diemGiuaKyList.Count == 0 && _diemCuoiKyList.Count == 0 &&
                _diemThuongXuyen == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm số cho môn học này.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder chiTietDiem = new StringBuilder();
            chiTietDiem.AppendLine($"Chi tiết điểm môn {SubjectName}:");

            // Chi tiết điểm miệng
            chiTietDiem.AppendLine($"- Điểm miệng:");
            if (_diemMiengList.Count > 0)
            {
                for (int i = 0; i < _diemMiengList.Count; i++)
                {
                    chiTietDiem.AppendLine($"  + Lần {i + 1}: {_diemMiengList[i]}");
                }
                chiTietDiem.AppendLine($"  => Trung bình: {_diemMiengTB:0.0}");
            }
            else
            {
                chiTietDiem.AppendLine("  (Chưa có điểm)");
            }

            // Chi tiết điểm 15 phút
            chiTietDiem.AppendLine($"- Điểm 15 phút:");
            if (_diem15PhutList.Count > 0)
            {
                for (int i = 0; i < _diem15PhutList.Count; i++)
                {
                    chiTietDiem.AppendLine($"  + Lần {i + 1}: {_diem15PhutList[i]}");
                }
                chiTietDiem.AppendLine($"  => Trung bình: {_diem15PhutTB:0.0}");
            }
            else
            {
                chiTietDiem.AppendLine("  (Chưa có điểm)");
            }

            // Điểm thường xuyên
            chiTietDiem.AppendLine($"- Điểm thường xuyên (30%): {_diemThuongXuyen:0.0}");

            // Chi tiết điểm giữa kỳ
            chiTietDiem.AppendLine($"- Điểm giữa kỳ (30%):");
            if (_diemGiuaKyList.Count > 0)
            {
                for (int i = 0; i < _diemGiuaKyList.Count; i++)
                {
                    chiTietDiem.AppendLine($"  + Lần {i + 1}: {_diemGiuaKyList[i]}");
                }
                chiTietDiem.AppendLine($"  => Trung bình: {_diemGiuaKyTB:0.0}");
            }
            else
            {
                chiTietDiem.AppendLine("  (Chưa có điểm)");
            }

            // Chi tiết điểm cuối kỳ
            chiTietDiem.AppendLine($"- Điểm cuối kỳ (40%):");
            if (_diemCuoiKyList.Count > 0)
            {
                for (int i = 0; i < _diemCuoiKyList.Count; i++)
                {
                    chiTietDiem.AppendLine($"  + Lần {i + 1}: {_diemCuoiKyList[i]}");
                }
                chiTietDiem.AppendLine($"  => Trung bình: {_diemCuoiKyTB:0.0}");
            }
            else
            {
                chiTietDiem.AppendLine("  (Chưa có điểm)");
            }

            // Điểm trung bình
            chiTietDiem.AppendLine($"- Điểm trung bình: {_diemTrungBinh:0.0}");

            MessageBox.Show(chiTietDiem.ToString(), "Chi tiết điểm số",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Utility Methods

        // Đặt màu chủ đề cho môn học
        public void SetSubjectColor(Color mauChinh, Color mauPhu)
        {
            prgAverage.ProgressColor = mauChinh;
            prgAverage.ProgressColor2 = mauPhu;
        }

        // Tự động đặt màu dựa trên tên môn học
        public void AutoSetColor()
        {
            // Nếu tên môn học trống, sử dụng màu mặc định
            if (string.IsNullOrEmpty(SubjectName))
            {
                SetSubjectColor(Color.FromArgb(94, 148, 255), Color.FromArgb(120, 170, 255));
                return;
            }

            // Tạo màu nhất quán dựa trên tên môn học
            Color mauChinh = GetSubjectColor(SubjectName);
            Color mauPhu = Color.FromArgb(mauChinh.A,
                                       Math.Min(mauChinh.R + 30, 255),
                                       Math.Min(mauChinh.G + 30, 255),
                                       Math.Min(mauChinh.B + 30, 255));

            SetSubjectColor(mauChinh, mauPhu);
        }

        // Lấy màu phù hợp cho từng môn học
        private Color GetSubjectColor(string tenMon)
        {
            // Màu được định nghĩa sẵn cho các môn học phổ biến
            tenMon = tenMon.ToLower();

            if (tenMon.Contains("toán"))
                return Color.FromArgb(94, 148, 255);

            if (tenMon.Contains("lý") || tenMon.Contains("physics"))
                return Color.FromArgb(240, 120, 80);

            if (tenMon.Contains("hóa") || tenMon.Contains("chemistry"))
                return Color.FromArgb(180, 90, 210);

            if (tenMon.Contains("sinh") || tenMon.Contains("biology"))
                return Color.FromArgb(90, 180, 100);

            if (tenMon.Contains("văn") || tenMon.Contains("literature"))
                return Color.FromArgb(230, 150, 70);

            if (tenMon.Contains("anh") || tenMon.Contains("english"))
                return Color.FromArgb(60, 170, 210);

            if (tenMon.Contains("sử") || tenMon.Contains("history"))
                return Color.FromArgb(200, 110, 80);

            if (tenMon.Contains("địa") || tenMon.Contains("geography"))
                return Color.FromArgb(80, 150, 120);

            // Màu mặc định cho các môn khác - tạo dựa trên mã băm tên
            int maBam = tenMon.GetHashCode();
            return Color.FromArgb(
                Math.Abs((maBam) % 156) + 100,  // Thành phần R (100-255)
                Math.Abs((maBam >> 8) % 156) + 100,  // Thành phần G (100-255)
                Math.Abs((maBam >> 16) % 156) + 100  // Thành phần B (100-255)
            );
        }

        // Đặt lại toàn bộ dữ liệu về giá trị mặc định
        public void Reset()
        {
            // Đặt lại giá trị về mặc định
            SubjectName = "";
            DiemMiengList = new List<float>();
            Diem15PhutList = new List<float>();
            DiemGiuaKyList = new List<float>();
            DiemCuoiKyList = new List<float>();
            NhanXet = "";

            // Cập nhật giao diện
            CapNhatProgressBar();
        }

        // Lấy kích thước lý tưởng của control
        public Size GetIdealSize()
        {
            return new Size(this.Width, 344); // Giữ nguyên chiều cao
        }

        // Sửa các progress bar
        public void FixProgressBars()
        {
            // Đảm bảo tất cả progress bar có Maximum = 100
            prgAssignment.Maximum = 100;
            prgMidtermExam.Maximum = 100;
            prgFinalExam.Maximum = 100;
            prgAverage.Maximum = 100;

            // Cập nhật lại giá trị của các progress bar
            prgAssignment.Value = Math.Min((int)(_diemThuongXuyen * 10), 100);
            prgMidtermExam.Value = Math.Min((int)(_diemGiuaKyTB * 10), 100);
            prgFinalExam.Value = Math.Min((int)(_diemCuoiKyTB * 10), 100);
            prgAverage.Value = Math.Min((int)(_diemTrungBinh * 10), 100);
        }

        #endregion
    }
}
