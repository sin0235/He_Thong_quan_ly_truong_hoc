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
    public partial class ucXinNghi : UserControl
    {
        private DatabaseHelper dbHelper;
        private DonXinNghiDAO donXinNghiDAL;
        private int currentStudentId = -1; // ID người dùng
        private int maHS = -1; // Mã học sinh trong database
        private string currentFilter = "all";
        public string currentTimeFilter = "all"; // all, month, 6months, year
        private ucTaoDonXinNghi ucTaoDon;

        public ucXinNghi(int ID, int M)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            donXinNghiDAL = new DonXinNghiDAO();
            currentStudentId = ID;
            maHS = M;
        }

        private void ucXinNghi_Load(object sender, EventArgs e)
        {
            // Khởi tạo user control tạo đơn xin nghỉ
            InitializeNewRequestForm();

            // Mặc định hiển thị tất cả đơn xin nghỉ
            LoadLeaveRequests();
        }

        private void InitializeNewRequestForm()
        {
            ucTaoDon = new ucTaoDonXinNghi(maHS);
            ucTaoDon.OnSubmitSuccess += UcTaoDon_OnSubmitSuccess;
            ucTaoDon.OnCancel += UcTaoDon_OnCancel;
            ucTaoDon.Dock = DockStyle.Fill;
            pnlTaoDonMoi.Controls.Add(ucTaoDon);
        }

        private void UcTaoDon_OnCancel(object sender, EventArgs e)
        {
            // Trở lại danh sách đơn
            SwitchToListView();
        }

        private void UcTaoDon_OnSubmitSuccess(object sender, EventArgs e)
        {
            // Trở lại danh sách đơn và làm mới
            SwitchToListView();
            LoadLeaveRequests();
        }

        private void SwitchToListView()
        {
            pnlTaoDonMoi.Visible = false;
            pnlDonXinNghi.Visible = true;
        }

        private void SwitchToCreateView()
        {
            pnlDonXinNghi.Visible = false;
            pnlTaoDonMoi.Visible = true;
        }

        private void LoadLeaveRequests()
        {
            // Xóa tất cả các đơn cũ trừ panel thông báo không có dữ liệu
            foreach (Control ctrl in pnlDonXinNghi.Controls)
            {
                if (ctrl != pnlNoData)
                    pnlDonXinNghi.Controls.Remove(ctrl);
            }

            try
            {
                // Thực hiện truy vấn trực tiếp vì cấu trúc DonXinNghiDTO khác với cấu trúc bảng DonXinNghi
                string query = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Điều kiện thời gian
                string timeCondition = "";
                switch (currentTimeFilter)
                {
                    case "month":
                        timeCondition = " AND d.NgayGui >= @StartDate";
                        parameters.Add("@StartDate", DateTime.Now.AddMonths(-1));
                        break;
                    case "6months":
                        timeCondition = " AND d.NgayGui >= @StartDate";
                        parameters.Add("@StartDate", DateTime.Now.AddMonths(-6));
                        break;
                    case "year":
                        timeCondition = " AND d.NgayGui >= @StartDate";
                        parameters.Add("@StartDate", DateTime.Now.AddYears(-1));
                        break;
                }

                // Điều kiện trạng thái
                string statusCondition = "";
                switch (currentFilter)
                {
                    case "approved":
                        statusCondition = " AND d.TrangThai = N'Đã duyệt'";
                        break;
                    case "pending":
                        statusCondition = " AND d.TrangThai = N'Chờ duyệt'";
                        break;
                    case "rejected":
                        statusCondition = " AND d.TrangThai = N'Từ chối'";
                        break;
                }

                // Xây dựng truy vấn SQL phù hợp với cấu trúc bảng
                query = $@"
                    SELECT 
                        d.MaDon, 
                        d.MaHS,
                        d.NgayGui,
                        d.NgayNghi, 
                        d.LyDo, 
                        d.TrangThai,
                        d.MaGV,
                        gv.HoTen as TenGiaoVien
                    FROM DonXinNghi d
                    LEFT JOIN GiaoVien gv ON d.MaGV = gv.MaGV
                    WHERE d.MaHS = @MaHS
                    {timeCondition}
                    {statusCondition}
                    ORDER BY d.NgayGui DESC";

                parameters.Add("@MaHS", maHS);

                DataTable data = dbHelper.ExecuteQuery(query, parameters);

                if (data != null && data.Rows.Count > 0)
                {
                    pnlNoData.Visible = false;

                    int yPos = 20;
                    foreach (DataRow row in data.Rows)
                    {
                        // Tạo đối tượng hiển thị đơn xin nghỉ
                        ucDonXinNghiItem donItem = new ucDonXinNghiItem();

                        // Thiết lập dữ liệu
                        donItem.MaDon = Convert.ToInt32(row["MaDon"]);
                        donItem.TieuDe = "Đơn xin nghỉ học"; // Tiêu đề mặc định vì bảng không có trường TieuDe
                        donItem.NoiDung = row["LyDo"].ToString();

                        // Ngày bắt đầu và kết thúc là cùng một ngày (NgayNghi)
                        DateTime ngayNghi = Convert.ToDateTime(row["NgayNghi"]);
                        donItem.NgayBatDau = ngayNghi;
                        donItem.NgayKetThuc = ngayNghi;

                        // Ngày tạo là NgayGui
                        donItem.NgayTao = Convert.ToDateTime(row["NgayGui"]);

                        // Chuyển đổi trạng thái từ chuỗi sang số
                        string trangThaiText = row["TrangThai"] != DBNull.Value ? row["TrangThai"].ToString() : "Chờ duyệt";
                        int trangThaiSo = 0; // Mặc định là đang chờ
                        switch (trangThaiText)
                        {
                            case "Đã duyệt":
                                trangThaiSo = 1;
                                break;
                            case "Từ chối":
                                trangThaiSo = 2;
                                break;
                            default: // "Chờ duyệt" hoặc giá trị khác
                                trangThaiSo = 0;
                                break;
                        }
                        donItem.TrangThai = trangThaiSo;

                        // Thông tin người duyệt
                        donItem.NguoiDuyet = row["TenGiaoVien"] != DBNull.Value ? row["TenGiaoVien"].ToString() : "";

                        // Phản hồi - bảng không có trường này, để trống
                        donItem.PhanHoi = "";

                        // Thiết lập vị trí và kích thước
                        donItem.Location = new Point(20, yPos);
                        donItem.Width = pnlDonXinNghi.Width - 60; // Trừ padding 2 bên
                        donItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                        // Thêm vào panel hiển thị
                        pnlDonXinNghi.Controls.Add(donItem);

                        // Cập nhật vị trí cho đơn tiếp theo
                        yPos += donItem.Height + 15;
                    }
                }
                else
                {
                    // Hiển thị thông báo không có đơn
                    pnlNoData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn xin nghỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            SwitchToCreateView();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnAll);
            currentFilter = "all";
            LoadLeaveRequests();
        }

        private void btnDaDuyet_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnDaDuyet);
            currentFilter = "approved";
            LoadLeaveRequests();
        }

        private void btnDangCho_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnDangCho);
            currentFilter = "pending";
            LoadLeaveRequests();
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnTuChoi);
            currentFilter = "rejected";
            LoadLeaveRequests();
        }

        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboThoiGian.SelectedIndex)
            {
                case 0:
                    currentTimeFilter = "all";
                    break;
                case 1:
                    currentTimeFilter = "month";
                    break;
                case 2:
                    currentTimeFilter = "6months";
                    break;
                case 3:
                    currentTimeFilter = "year";
                    break;
            }

            LoadLeaveRequests();
        }

        #endregion

        #region Helper Methods

        private void SetActiveFilterButton(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            // Đặt độ sáng cho tất cả các nút
            foreach (Control control in pnlFilter.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button && button != activeButton)
                {
                    button.FillColor = Color.FromArgb(button.FillColor.R, button.FillColor.G, button.FillColor.B);
                    button.ForeColor = Color.White;
                }
            }

            // Làm nổi bật nút được chọn
            activeButton.ForeColor = Color.White;
        }

        #endregion

        private void pnlTaoDonMoi_Paint(object sender, PaintEventArgs e)
        {
            // Để trống, chỉ sử dụng cho sự kiện Paint
        }
    }
}
