using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyHocSinh : Form
    {
        private int maHS;
        private bool isEditMode = false;
        private HocSinhDAO hocSinhDAL;
        private ThongTinHSDTO thongTinHS;

        public frmQuanLyHocSinh()
        {
            InitializeComponent();
            isEditMode = false;
            hocSinhDAL = new HocSinhDAO();
            thongTinHS = new ThongTinHSDTO();
        }

        public string title
        {
            set { this.ucControlBar1.TitleText = value; }
        }

        public frmQuanLyHocSinh(int maHS, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdtPhuHuynh, string tenLop)
        {
            InitializeComponent();
            this.maHS = maHS;
            isEditMode = true;
            hocSinhDAL = new HocSinhDAO();

            // Sử dụng phương thức GetStudentById của HocSinhDAL để lấy đầy đủ thông tin học sinh
            thongTinHS = hocSinhDAL.GetStudentById(maHS);

            if (thongTinHS != null)
            {
                // Điền thông tin cơ bản
                txtHoTen.Text = thongTinHS.FullName;
                txtNgaySinh.Text = thongTinHS.DateOfBirth.ToString("dd/MM/yyyy");

                // Thiết lập giới tính
                if (thongTinHS.Gender == "Nam")
                {
                    checkNam.Checked = true;
                    checkNu.Checked = false;
                }
                else
                {
                    checkNam.Checked = false;
                    checkNu.Checked = true;
                }

                // Điền thông tin liên hệ và địa chỉ
                txtDiaChi.Text = thongTinHS.PermanentAddress;
                txtTinh.Text = thongTinHS.Province;
                txtQuanHuyen.Text = thongTinHS.District;
                txtPhuongXa.Text = thongTinHS.Ward;
                txtSDT.Text = thongTinHS.Mobile;
                txtEmail.Text = thongTinHS.Email;

                // Điền thông tin nhân thân
                txtCMND.Text = thongTinHS.IdentityCode;
                txtNoiSinh.Text = thongTinHS.PlaceOfBirth;
                txtDanToc.Text = thongTinHS.Ethnicity;
                txtTonGiao.Text = thongTinHS.Religion;

                // Điền thông tin phụ huynh
                txtHoTenCha.Text = thongTinHS.FatherName;
                txtSDTCha.Text = thongTinHS.FatherPhone;
                txtHoTenMe.Text = thongTinHS.MotherName;
                txtSDTMe.Text = thongTinHS.MotherPhone;
                
                // Điền thông tin lớp học
                txtLop.Text = thongTinHS.ClassName;

            }
            else
            {
                // Nếu không tìm thấy thông tin học sinh từ DAL, sử dụng thông tin cơ bản đã truyền vào
                txtHoTen.Text = hoTen;
                txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");

                if (gioiTinh == "Nam")
                {
                    checkNam.Checked = true;
                    checkNu.Checked = false;
                }
                else
                {
                    checkNam.Checked = false;
                    checkNu.Checked = true;
                }

                txtDiaChi.Text = diaChi;
                txtLop.Text = tenLop;
            }

            // Cập nhật tiêu đề và nút xác nhận
            this.Text = "Sửa thông tin học sinh";
            btnXacNhan.Text = "Cập nhật";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nhập liệu cho các trường bắt buộc
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtLop.Text) ||
                    (!checkNam.Checked && !checkNu.Checked))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các trường nhập liệu
                string hoTen = txtHoTen.Text.Trim();
                string ngaySinhStr = txtNgaySinh.Text.Trim();
                string gioiTinh = checkNam.Checked ? "Nam" : "Nữ";
                string diaChi = txtDiaChi.Text.Trim();
                string tenLop = txtLop.Text.Trim();

                // Xử lý ngày sinh
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã lớp từ tên lớp
                DatabaseHelper db = new DatabaseHelper();
                string queryMaLop = $"SELECT MaLop FROM LopHoc WHERE TenLop = N'{tenLop}'";
                DataTable dtMaLop = db.ExecuteQuery(queryMaLop);
                if (dtMaLop.Rows.Count == 0)
                {
                    MessageBox.Show("Lớp không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maLop = Convert.ToInt32(dtMaLop.Rows[0]["MaLop"]);

                // Cập nhật thông tin học sinh vào đối tượng ThongTinHSDTO
                thongTinHS.FullName = hoTen;
                thongTinHS.DateOfBirth = ngaySinh;
                thongTinHS.Gender = gioiTinh;
                thongTinHS.PermanentAddress = diaChi;
                thongTinHS.Province = txtTinh.Text.Trim();
                thongTinHS.District = txtQuanHuyen.Text.Trim();
                thongTinHS.Ward = txtPhuongXa.Text.Trim();
                thongTinHS.Mobile = txtSDT.Text.Trim();
                thongTinHS.Email = txtEmail.Text.Trim();
                thongTinHS.IdentityCode = txtCMND.Text.Trim();
                thongTinHS.PlaceOfBirth = txtNoiSinh.Text.Trim();
                thongTinHS.Ethnicity = txtDanToc.Text.Trim();
                thongTinHS.Religion = txtTonGiao.Text.Trim();
                thongTinHS.FatherName = txtHoTenCha.Text.Trim();
                thongTinHS.FatherPhone = txtSDTCha.Text.Trim();
                thongTinHS.MotherName = txtHoTenMe.Text.Trim();
                thongTinHS.MotherPhone = txtSDTMe.Text.Trim();
                thongTinHS.ClassName = tenLop;
                thongTinHS.ClassId = maLop;

                bool success = false;
                string tenDangNhap = string.Empty;
                string matKhau = string.Empty;

                if (isEditMode)
                {
                    // Cập nhật thông tin học sinh hiện có
                    thongTinHS.StudentId = maHS.ToString();
                    success = hocSinhDAL.UpdateStudent(thongTinHS, maLop);

                    if (success)
                    {
                        // Lưu ảnh đại diện nếu có thay đổi
                        if (picAvatar.Image != null && picAvatar.Tag != null && (bool)picAvatar.Tag)
                        {
                            hocSinhDAL.SaveStudentAvatar(maHS, picAvatar.Image);
                        }

                        MessageBox.Show("Cập nhật thông tin học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin học sinh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Thêm học sinh mới
                    int newMaHS = hocSinhDAL.AddStudent(thongTinHS, maLop, out tenDangNhap, out matKhau);

                    if (newMaHS > 0)
                    {
                        // Lưu ảnh đại diện nếu có
                        if (picAvatar.Image != null)
                        {
                            hocSinhDAL.SaveStudentAvatar(newMaHS, picAvatar.Image);
                        }

                        MessageBox.Show($"Thêm học sinh thành công!\nTên đăng nhập: {tenDangNhap}\nMật khẩu: {matKhau}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm học sinh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            // Đặt giá trị mặc định cho các trường
            if (!isEditMode)
            {
                // Thiết lập giá trị mặc định cho quốc gia
                thongTinHS.Country = "Việt Nam";

                // Chọn giới tính Nam mặc định
                checkNam.Checked = true;
            }

            // Đánh dấu để biết ảnh chưa được thay đổi
            picAvatar.Tag = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy thao tác hiện tại?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void lblChangeAvatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picAvatar.Image = new Bitmap(openFileDialog.FileName);
                    // Đánh dấu ảnh đã được thay đổi
                    picAvatar.Tag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
