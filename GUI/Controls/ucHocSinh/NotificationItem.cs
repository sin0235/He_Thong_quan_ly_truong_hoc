using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public class NotificationItem : Guna.UI2.WinForms.Guna2Panel
    {
        // Ảnh đại diện của người gửi thông báo
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        // Tiêu đề của thông báo
        private Label lblTitle;
        // Tên người gửi thông báo
        private Label lblSender;
        // Ngày gửi thông báo
        private Label lblDate;
        // Nội dung của thông báo
        private Label lblContent;
        // Đường phân cách giữa các thông báo
        private Guna.UI2.WinForms.Guna2Separator separator;
        // Nút để xem chi tiết thông báo
        private Guna.UI2.WinForms.Guna2Button btnView;
        // Trạng thái đã đọc của thông báo
        private bool isRead = false;



        public int NotificationId { get; private set; }
        public string Title { get; private set; }
        public string Sender { get; private set; }
        public DateTime Date { get; private set; }
        public string Content { get; private set; }
        public bool IsRead
        {
            get => isRead;
            set
            {
                isRead = value;
                UpdateReadStatus();
            }
        }

        // Constructor để khởi tạo thông báo
        public NotificationItem(int maTB, string tieuDe, string nguoiGui, DateTime date, string noiDung, string avatarPath = null, bool daDoc = false)
        {
            NotificationId = maTB;
            isRead = daDoc;

            // Thiết lập giao diện của thông báo
            this.Size = new Size(1550, 130);
            this.BorderRadius = 10;
            this.FillColor = isRead ? Color.White : Color.FromArgb(240, 249, 255);
            this.BorderColor = Color.FromArgb(230, 230, 230);
            this.BorderThickness = 1;
            this.Margin = new Padding(10, 5, 10, 5);
            this.Padding = new Padding(10);
            this.Cursor = Cursors.Hand;
            this.ShadowDecoration.Depth = 5;
            this.ShadowDecoration.Enabled = true;
            this.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);

            // Khởi tạo ảnh đại diện
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Kiểm tra và tải ảnh đại diện nếu có
            if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
            {
                picAvatar.Image = Image.FromFile(avatarPath);
            }
            else
            {
                picAvatar.Image = Properties.Resources.defautAvatar;
            }

            // Khởi tạo tiêu đề thông báo
            lblTitle = new Label
            {
                AutoSize = false,
                Size = new Size(1000, 30),
                Location = new Point(100, 15),
                Text = tieuDe,
                Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
                ForeColor = isRead ? Color.FromArgb(70, 70, 70) : Color.FromArgb(0, 120, 215)
            };

            // Khởi tạo tên người gửi
            lblSender = new Label
            {
                AutoSize = true,
                Location = new Point(100, 45),
                Text = nguoiGui,
                Font = new Font("Segoe UI",11f),
                ForeColor = Color.FromArgb(100, 100, 100)
            };

            // Khởi tạo ngày gửi
            lblDate = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(1380, 15),
                Text = FormatDate(date), // Định dạng ngày gửi
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(150, 150, 150)
            };

            // Khởi tạo nội dung thông báo
            lblContent = new Label
            {
                AutoSize = false,
                Size = new Size(1300, 40),
                Location = new Point(100, 70),
                Text = noiDung,
                Font = new Font("Segoe UI",11),
                ForeColor = Color.FromArgb(90, 90, 90)
            };

            // Khởi tạo nút xem chi tiết
            btnView = new Guna.UI2.WinForms.Guna2Button
            {
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1420, 70),
                Text = "Xem",
                BorderRadius = 15,
                FillColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI",11, FontStyle.Regular),
                Cursor = Cursors.Hand
            };

            // Khởi tạo đường phân cách
            separator = new Guna.UI2.WinForms.Guna2Separator
            {
                Size = new Size(1520, 1),
                Location = new Point(15, 120),
                FillColor = Color.FromArgb(230, 230, 230)
            };

            // Thêm các thành phần vào thông báo
            this.Controls.Add(picAvatar);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSender);
            this.Controls.Add(lblDate);
            this.Controls.Add(lblContent);
            this.Controls.Add(btnView);
            this.Controls.Add(separator);

            // Gán sự kiện click cho thông báo và các thành phần
            this.Click += NotificationItem_Click;
            btnView.Click += BtnView_Click;

            foreach (Control control in this.Controls)
            {
                if (control != btnView)
                {
                    control.Click += NotificationItem_Click;
                }
            }
        }

        // Cập nhật giao diện khi trạng thái đã đọc thay đổi
        private void UpdateReadStatus()
        {
            this.FillColor = isRead ? Color.White : Color.FromArgb(240, 249, 255);
            lblTitle.ForeColor = isRead ? Color.FromArgb(70, 70, 70) : Color.FromArgb(0, 120, 215);
        }

        // Xử lý sự kiện khi người dùng nhấp vào thông báo
        private void NotificationItem_Click(object nguoiGui, EventArgs e)
        {
            if (!isRead)
            {
                IsRead = true;
                // Cập nhật trạng thái đã đọc trong cơ sở dữ liệu
                // UpdateNotificationStatusInDatabase(NotificationId);
            }

            // Mở chi tiết thông báo
            OpenNotificationDetails();
        }

        // Xử lý sự kiện khi người dùng nhấp vào nút "Xem"
        private void BtnView_Click(object nguoiGui, EventArgs e)
        {
            if (!isRead)
            {
                IsRead = true;
                // Cập nhật trạng thái đã đọc trong cơ sở dữ liệu
                // UpdateNotificationStatusInDatabase(NotificationId);
            }

            // Mở chi tiết thông báo
            OpenNotificationDetails();
        }

        // Mở chi tiết thông báo bằng cách gọi phương thức của control cha
        private void OpenNotificationDetails()
        {
            // Tìm control cha là ucThongBao
            ucThongBao parentThongBao = this.FindForm()?.Controls.Find("ucThongBao1", true).FirstOrDefault() as ucThongBao;
            if (parentThongBao == null)
            {
                // Tìm control cha theo cách khác nếu không tìm thấy
                Control parent = this.Parent;
                while (parent != null && !(parent is ucThongBao))
                {
                    parent = parent.Parent;
                }
                parentThongBao = parent as ucThongBao;
            }

            if (parentThongBao != null)
            {
                // Gọi phương thức ShowNotificationDetails của control cha
                parentThongBao.ShowNotificationDetails(
                    NotificationId,
                    lblTitle.Text,
                    lblSender.Text.StartsWith("Người gửi:") ? lblSender.Text.Substring(11).Trim() : lblSender.Text,
                    ParseDateFromText(lblDate.Text),
                    lblContent.Text
                );
            }
            else
            {
                // Hiển thị thông báo nếu không tìm thấy control cha
                MessageBox.Show($"Xem chi tiết thông báo: {lblTitle.Text}", "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Phương thức hỗ trợ để phân tích ngày từ chuỗi định dạng
        private DateTime ParseDateFromText(string dateText)
        {
            try
            {
                // Xử lý định dạng "Hôm nay, HH:mm"
                if (dateText.StartsWith("Hôm nay"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);
                    return DateTime.Today.Add(time);
                }
                // Xử lý định dạng "Hôm qua, HH:mm"
                else if (dateText.StartsWith("Hôm qua"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);
                    return DateTime.Today.AddDays(-1).Add(time);
                }
                // Xử lý định dạng "Thứ ..., HH:mm"
                else if (dateText.StartsWith("Thứ") || dateText.StartsWith("Chủ nhật"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);

                    // Ước lượng ngày dựa trên tuần trước
                    DateTime today = DateTime.Today;
                    for (int i = 1; i <= 7; i++)
                    {
                        DateTime checkDate = today.AddDays(-i);
                        if (GetDayOfWeek(checkDate).Equals(dateText.Substring(0, dateText.IndexOf(','))))
                        {
                            return checkDate.Add(time);
                        }
                    }
                    // Mặc định là hôm nay nếu không tìm thấy
                    return today.Add(time);
                }
                // Xử lý định dạng "dd/MM/yyyy HH:mm"
                else
                {
                    return DateTime.ParseExact(dateText, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch
            {
                // Trả về ngày giờ hiện tại nếu phân tích thất bại
                return DateTime.Now;
            }
        }

        // Định dạng ngày thành chuỗi hiển thị
        private string FormatDate(DateTime date)
        {
            if (date.Date == DateTime.Today)
            {
                return $"Hôm nay, {date:HH:mm}";
            }
            else if (date.Date == DateTime.Today.AddDays(-1))
            {
                return $"Hôm qua, {date:HH:mm}";
            }
            else if ((DateTime.Today - date.Date).TotalDays < 7)
            {
                return $"{GetDayOfWeek(date)}, {date:HH:mm}";
            }
            else
            {
                return date.ToString("dd/MM/yyyy HH:mm");
            }
        }

        // Lấy tên ngày trong tuần bằng tiếng Việt
        private string GetDayOfWeek(DateTime date)
        {
            string[] daysOfWeek = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
            return daysOfWeek[(int)date.DayOfWeek];
        }
    }
}
