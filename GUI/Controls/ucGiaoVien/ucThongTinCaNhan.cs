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
    public partial class ucThongTinCaNhan : UserControl
    {
        private readonly DatabaseHelper db;

        public ucThongTinCaNhan()
        {
            InitializeComponent();
            db = new DatabaseHelper();

        }
        public void LoadThongTinCaNhan(int maNguoiDung)
        {
            try
            {
                //Tải thông tin cá nhân giáo viên từ cơ sở dữ liệu
                string query = $@"
                    SELECT gv.HoTen, gv.GioiTinh, gv.SDT, gv.Email, gv.MaMon, mh.TenMon, 
                           gv.ChuNhiem, gv.NgaySinh, gv.DiaChi, nd.NgayTao
                    FROM GiaoVien gv
                    INNER JOIN MonHoc mh ON gv.MaMon = mh.MaMon
                    INNER JOIN NguoiDung nd ON gv.MaNguoiDung = nd.MaNguoiDung
                    WHERE gv.MaNguoiDung = {maNguoiDung}";
                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    //Tải thông tin cá nhân vào các textbox
                    DataRow row = dt.Rows[0];
                    hoTenTxt.Text = row["HoTen"].ToString();
                    tenUserLbl.Text = hoTenTxt.Text;
                    gioiTinhCmb.SelectedItem = row["GioiTinh"].ToString();
                    sdtTxt.Text = row["SDT"].ToString();
                    emailTxt.Text = row["Email"].ToString();
                    diaChiTxt.Text = row["DiaChi"].ToString();
                    chyenMonCmb.SelectedIndex = chyenMonCmb.FindStringExact(row["TenMon"].ToString());

                    //Set combobox cho Chủ nhiệm
                    chuNhiemCmb.Items.Clear();
                    chuNhiemCmb.Items.Add("Có");
                    chuNhiemCmb.Items.Add("Không");
                    chuNhiemCmb.SelectedItem = Convert.ToBoolean(row["ChuNhiem"]) ? "Có" : "Không";

                    ngaySinhDTP.Value = Convert.ToDateTime(row["NgaySinh"]);
                    ngaySinhDTP.Format = DateTimePickerFormat.Custom;
                    ngaySinhDTP.CustomFormat = "dd/MM/yyyy";

                    //Tính toán ngày công tác (từ ngày tạo tài khoản)
                    DateTime ngayTao = Convert.ToDateTime(row["NgayTao"]);
                    int soNgayCongTac = (DateTime.Now - ngayTao).Days;
                    congTacTxt.Text = $"{soNgayCongTac} ngày";

                    //Load ảnh đại diện theo giới tính
                    string gioiTinh = row["GioiTinh"].ToString();
                    if (gioiTinh == "Nam")
                    {
                        anhDaiDienPictureBox.Image = Properties.Resources.defautAvatar_Teacher_Male;
                    }
                    else
                    {
                        anhDaiDienPictureBox.Image = Properties.Resources.defautAvatar_Teacher_Female;
                    }
                    //Hiển thị trạng thái đang hoạt động
                    trangThai.Text = "Trạng thái: Đang hoạt động";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin giáo viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin cá nhân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
