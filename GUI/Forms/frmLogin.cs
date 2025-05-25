using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc
{

    public partial class frmLogin : Form
    {
        public static int LoggedInTeacherId { get; private set; }
        public static int LoggedInStudentId { get; private set; }

        private readonly DatabaseHelper db;

        public frmLogin()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }
        private int GetNextMaNK()
        {
            string query = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
            DataTable result = db.ExecuteQuery(query);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0][0]) : 1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPW.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Username và Password không được để trống.";
                lblError.Visible = true;
                return;
            }

            try
            {
                string query = @"
                SELECT NguoiDung.MaNguoiDung, NguoiDung.MaVaiTro, VaiTro.TenVaiTro
                FROM NguoiDung
                INNER JOIN VaiTro ON NguoiDung.MaVaiTro = VaiTro.MaVaiTro
                WHERE NguoiDung.TenDangNhap = @Username AND NguoiDung.MatKhau = @Password";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Username", username },
                    { "@Password", password }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    int maNguoiDung = Convert.ToInt32(dt.Rows[0]["MaNguoiDung"]);
                    int maVaiTro = Convert.ToInt32(dt.Rows[0]["MaVaiTro"]);
                    string tenVaiTro = dt.Rows[0]["TenVaiTro"].ToString();
                    int newMaNK = GetNextMaNK();

                    // Ghi nhật ký đăng nhập sử dụng tham số
                    string insertLogQuery = @"
                    INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                    VALUES (@MaNK, @MaNguoiDung, @HanhDong, GETDATE())";
                    
                    Dictionary<string, object> logParameters = new Dictionary<string, object>
                    {
                        { "@MaNK", newMaNK },
                        { "@MaNguoiDung", maNguoiDung },
                        { "@HanhDong", "Đăng nhập" }
                    };
                    
                    db.ExecuteNonQuery(insertLogQuery, logParameters);

                    // Tạo hiệu ứng mờ dần cho form hiện tại
                    System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer
                    {
                        Interval = 10
                    };
                    double opacity = 1.0;

                    fadeTimer.Tick += (s, args) =>
                    {
                        opacity -= 0.05;
                        if (opacity <= 0)
                        {
                            fadeTimer.Stop();
                            this.Hide();

                            var newForm = OpenFormByRole(maVaiTro, tenVaiTro, maNguoiDung);

                            // Hiệu ứng hiện dần form mới
                            System.Windows.Forms.Timer fadeInTimer = new System.Windows.Forms.Timer
                            {
                                Interval = 10
                            };
                            double newOpacity = 0;

                            fadeInTimer.Tick += (s2, args2) =>
                            {
                                newOpacity += 0.05;
                                newForm.Opacity = newOpacity;
                                if (newOpacity >= 1)
                                {
                                    fadeInTimer.Stop();
                                }
                            };

                            fadeInTimer.Start();
                        }
                        else
                        {
                            this.Opacity = opacity;
                        }
                    };

                    fadeTimer.Start();
                }
                else
                {
                    lblError.Text = "Username hoặc Password không đúng.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form OpenFormByRole(int maVaiTro, string tenVaiTro, int maNguoiDung)
        {
            Form nextForm = null;

            switch (maVaiTro)
            {
                case 1: // Ban giám hiệu
                    nextForm = new frmBGH(maNguoiDung);
                    ((frmBGH)nextForm).lblUserName.Text = "Ban giám hiệu";
                    break;
                case 3: // Giáo viên
                    nextForm = new frmGV(maNguoiDung); // Pass maNguoiDung to frmGV
                    LoggedInTeacherId = maNguoiDung; // Save the logged-in teacher's ID
                    break;
                case 4: // Học sinh
                    nextForm = new frmHS(maNguoiDung);
                    LoggedInStudentId = maNguoiDung; // Lưu mã học sinh đã đăng nhập
                    break;
                case 2: // Nhân viên phòng nội vụ
                    nextForm = new frmPhongNoiVu(maNguoiDung);
                    
                    break;
                default:
                    MessageBox.Show($"Vai trò '{tenVaiTro}' chưa được hỗ trợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Show();
                    return null;
            }

            if (nextForm != null)
            {
                nextForm.Opacity = 0;
                nextForm.Show();
            }

            return nextForm;
        }


        // Các phương thức khác giữ nguyên
        private void chbShowPw_CheckedChanged(object sender, EventArgs e)
        {
            txtPW.UseSystemPasswordChar = !chkShowPw.Checked;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (lblError.Visible)
            {
                lblError.Visible = false;
            }
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            if (lblError.Visible)
            {
                lblError.Visible = false;
            }
        }

        private void guna2CircleButtonCloseLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlMainScreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}