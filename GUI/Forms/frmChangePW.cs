using Guna.UI2.WinForms;
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

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChangePW : Form
    {
        private readonly DatabaseHelper db;
        private int currentUserId;

        public frmChangePW(int userId)
        {
            InitializeComponent();

            db = new DatabaseHelper();

            currentUserId = userId;

            CustomizeDesign();
        }


        private void CustomizeDesign()
        {
            // Thiết lập khả năng di chuyển form
            pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            lblFormTitle.MouseDown += PnlTitleBar_MouseDown;

            // Gán sự kiện cho các nút điều khiển
            guna2CircleButtonClose.Click += (s, e) => this.Close();
            guna2CircleButtonMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Gán sự kiện cho nút đổi mật khẩu
            btnChangePassword.Click += btnChangePassword_Click;

            // Hiệu ứng hover cho nút đổi mật khẩu
            btnChangePassword.MouseEnter += (s, e) =>
            {
                btnChangePassword.FillColor = System.Drawing.Color.FromArgb(69, 130, 222);
                btnChangePassword.FillColor2 = System.Drawing.Color.FromArgb(110, 158, 255);
            };

            btnChangePassword.MouseLeave += (s, e) =>
            {
                btnChangePassword.FillColor = System.Drawing.Color.FromArgb(58, 123, 213);
                btnChangePassword.FillColor2 = System.Drawing.Color.FromArgb(94, 148, 255);
            };

            // Thiết lập sự kiện cho các nút hiển thị/ẩn mật khẩu
            SetupPasswordToggle();

            // Thiết lập sự kiện khi người dùng nhập liệu
            txtNewPassword.TextChanged += TxtNewPassword_TextChanged;
            txtConfirmPassword.TextChanged += TxtConfirmPassword_TextChanged;
            txtCurrentPassword.TextChanged += TxtCurrentPassword_TextChanged;

            // Thiết lập thông tin ban đầu
            lblPasswordHint.Text = "Mật khẩu phải có ít nhất 8 ký tự bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt";
            passwordStrengthBar.Value = 0;
        }

        private void TxtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            // Xóa dấu hiệu lỗi khi người dùng nhập lại
            txtCurrentPassword.BorderColor = Color.FromArgb(210, 218, 226);
        }

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Cho phép kéo thả form
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        // Hàm hỗ trợ di chuyển form
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void SetupPasswordToggle()
        {
            // Thiết lập sự kiện hiển thị/ẩn mật khẩu hiện tại
            bool currentPasswordVisible = false;
            btnShowCurrentPassword.Click += (s, e) =>
            {
                currentPasswordVisible = !currentPasswordVisible;
                txtCurrentPassword.PasswordChar = currentPasswordVisible ? '\0' : '●';
                btnShowCurrentPassword.Image = currentPasswordVisible ?
                    Properties.Resources.eye_open : Properties.Resources.eye_closed;
            };

            // Thiết lập sự kiện hiển thị/ẩn mật khẩu mới
            bool newPasswordVisible = false;
            btnShowNewPassword.Click += (s, e) =>
            {
                newPasswordVisible = !newPasswordVisible;
                txtNewPassword.PasswordChar = newPasswordVisible ? '\0' : '●';
                btnShowNewPassword.Image = newPasswordVisible ?
                    Properties.Resources.eye_open : Properties.Resources.eye_closed;
            };

            // Thiết lập sự kiện hiển thị/ẩn xác nhận mật khẩu
            bool confirmPasswordVisible = false;
            btnShowConfirmPassword.Click += (s, e) =>
            {
                confirmPasswordVisible = !confirmPasswordVisible;
                txtConfirmPassword.PasswordChar = confirmPasswordVisible ? '\0' : '●';
                btnShowConfirmPassword.Image = confirmPasswordVisible ?
                    Properties.Resources.eye_open : Properties.Resources.eye_closed;
            };
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xác nhận mật khẩu
            if (txtConfirmPassword.Text.Length > 0)
            {
                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận không khớp";
                    lblPasswordHint.ForeColor = Color.Red;
                    txtConfirmPassword.BorderColor = Color.Red;
                }
                else
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận khớp";
                    lblPasswordHint.ForeColor = Color.Green;
                    txtConfirmPassword.BorderColor = Color.Green;
                }
            }
            else
            {
                txtConfirmPassword.BorderColor = Color.FromArgb(210, 218, 226);
            }
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra độ mạnh của mật khẩu
            string password = txtNewPassword.Text;

            if (password.Length == 0)
            {
                lblPasswordHint.Text = "Mật khẩu phải có ít nhất 8 ký tự bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt";
                lblPasswordHint.ForeColor = Color.Gray;
                passwordStrengthBar.Value = 0;
                passwordStrengthBar.ProgressColor = passwordStrengthBar.ProgressColor2 = Color.Red;
                txtNewPassword.BorderColor = Color.FromArgb(210, 218, 226);
                return;
            }

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(c => !char.IsLetterOrDigit(c));
            bool hasMinLength = password.Length >= 8;

            int strength = 0;
            if (hasUpperCase) strength++;
            if (hasLowerCase) strength++;
            if (hasDigit) strength++;
            if (hasSpecialChar) strength++;
            if (hasMinLength) strength++;

            // Cập nhật thanh đo độ mạnh mật khẩu
            passwordStrengthBar.Value = strength * 20; // 5 tiêu chí, mỗi tiêu chí 20%

            // Đổi màu theo độ mạnh
            if (strength <= 2)
            {
                passwordStrengthBar.ProgressColor = passwordStrengthBar.ProgressColor2 = Color.Red;
                lblPasswordHint.Text = "Mật khẩu yếu";
                lblPasswordHint.ForeColor = Color.Red;
                txtNewPassword.BorderColor = Color.Red;
            }
            else if (strength <= 3)
            {
                passwordStrengthBar.ProgressColor = passwordStrengthBar.ProgressColor2 = Color.Orange;
                lblPasswordHint.Text = "Mật khẩu trung bình";
                lblPasswordHint.ForeColor = Color.Orange;
                txtNewPassword.BorderColor = Color.Orange;
            }
            else if (strength <= 4)
            {
                passwordStrengthBar.ProgressColor = passwordStrengthBar.ProgressColor2 = Color.YellowGreen;
                lblPasswordHint.Text = "Mật khẩu khá mạnh";
                lblPasswordHint.ForeColor = Color.YellowGreen;
                txtNewPassword.BorderColor = Color.YellowGreen;
            }
            else
            {
                passwordStrengthBar.ProgressColor = passwordStrengthBar.ProgressColor2 = Color.Green;
                lblPasswordHint.Text = "Mật khẩu mạnh";
                lblPasswordHint.ForeColor = Color.Green;
                txtNewPassword.BorderColor = Color.Green;
            }

            // Kiểm tra lại với xác nhận mật khẩu
            if (txtConfirmPassword.Text.Length > 0)
            {
                if (txtConfirmPassword.Text != password)
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận không khớp";
                    lblPasswordHint.ForeColor = Color.Red;
                    txtConfirmPassword.BorderColor = Color.Red;
                }
                else
                {
                    txtConfirmPassword.BorderColor = Color.Green;
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Hiện hộp thoại xác nhận
            if (string.IsNullOrEmpty(txtCurrentPassword.Text) ||
                string.IsNullOrEmpty(txtNewPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ mạnh mật khẩu
            if (passwordStrengthBar.Value < 60) // Ít nhất là mức trung bình
            {
                DialogResult result = MessageBox.Show(
                    "Mật khẩu mới khá yếu. Bạn có chắc chắn muốn sử dụng mật khẩu này?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }

            // Kiểm tra mật khẩu cũ trước khi đổi
            if (CheckOldPassword(txtCurrentPassword.Text))
            {
                // Thực hiện đổi mật khẩu
                if (ChangePassword(txtNewPassword.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.BorderColor = Color.Red;
                txtCurrentPassword.Focus();
            }
        }

        // Phương thức kiểm tra mật khẩu cũ
        private bool CheckOldPassword(string password)
        {
            try
            {
                // Chuẩn bị truy vấn
                string query = "SELECT COUNT(*) FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung AND MatKhau = @MatKhau";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", currentUserId },
                    { "@MatKhau", password }
                };

                // Thực thi truy vấn
                object result = db.ExecuteScalar(query, parameters);

                if (result != null)
                {
                    return Convert.ToInt32(result) > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Phương thức thay đổi mật khẩu
        private bool ChangePassword(string newPassword)
        {
            try
            {
                // Chuẩn bị truy vấn cập nhật
                string query = "UPDATE NguoiDung SET MatKhau = @MatKhau WHERE MaNguoiDung = @MaNguoiDung";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", currentUserId },
                    { "@MatKhau", newPassword }
                };

                // Thực thi truy vấn
                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnShowCurrentPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void frmChangePW_Load(object sender, EventArgs e)
        {

        }
    }
}
