using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    /// <summary>
    /// Control hiển thị chi tiết thông báo
    /// </summary>
    public partial class ucTBChiTiet : UserControl
    {
        // Các sự kiện để giao tiếp với control cha
        public event EventHandler OnClose;     // Sự kiện khi đóng chi tiết thông báo
        public event EventHandler OnReply;     // Sự kiện khi trả lời thông báo
        public event EventHandler OnForward;   // Sự kiện khi chuyển tiếp thông báo

        /// <summary>
        /// Lớp chứa thông tin về tệp đính kèm
        /// </summary>
        public class AttachmentInfo
        {
            public string FileName { get; set; }   // Tên tệp
            public string FilePath { get; set; }   // Đường dẫn đến tệp
            public long FileSize { get; set; }     // Kích thước tệp (byte)
        }

        // Danh sách các tệp đính kèm của thông báo hiện tại
        private List<AttachmentInfo> attachments = new List<AttachmentInfo>();

        /// <summary>
        /// Khởi tạo control chi tiết thông báo
        /// </summary>
        public ucTBChiTiet()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        /// <summary>
        /// Thiết lập các xử lý sự kiện cho các nút trên giao diện
        /// </summary>
        private void SetupEventHandlers()
        {
            // Gán các sự kiện cho các nút chức năng
            btnClose.Click += (sender, e) => OnClose?.Invoke(this, EventArgs.Empty);
            btnReply.Click += (sender, e) => OnReply?.Invoke(this, EventArgs.Empty);
            btnForward.Click += (sender, e) => OnForward?.Invoke(this, EventArgs.Empty);
            btnPrint.Click += BtnPrint_Click;
            btnDownloadAll.Click += BtnDownloadAll_Click;
        }

        /// <summary>
        /// Tải thông tin của thông báo vào control
        /// </summary>
        /// <param name="thongBaoId">Mã thông báo</param>
        /// <param name="title">Tiêu đề thông báo</param>
        /// <param name="sender">Người gửi thông báo</param>
        /// <param name="receiver">Người nhận thông báo</param>
        /// <param name="date">Ngày gửi thông báo</param>
        /// <param name="content">Nội dung thông báo</param>
        /// <param name="senderAvatar">Ảnh đại diện người gửi (tùy chọn)</param>
        /// <param name="attachmentList">Danh sách tệp đính kèm (tùy chọn)</param>
        public void LoadThongBao(int thongBaoId, string title, string sender, string receiver,
                         DateTime date, string content, Image senderAvatar = null,
                         List<AttachmentInfo> attachmentList = null)
        {
            // Gán các thông tin cơ bản của thông báo vào các điều khiển tương ứng
            lblTitle.Text = title;
            lblNguoiGui.Text = $"Người gửi: {sender}";
            lblNgayGui.Text = $"Ngày gửi: {FormatDate(date)}";
            lblNguoiNhan.Text = $"Người nhận: {receiver}"; // Hiển thị người nhận
            rtbContent.Text = content;

            // Gán ảnh đại diện nếu có
            if (senderAvatar != null)
            {
                picAvatar.Image = senderAvatar;
            }
            else
            {
                senderAvatar =  Properties.Resources.defautAvatar;
            }

                // Tải các tệp đính kèm nếu có
                LoadAttachments(attachmentList);
        }

        private void LoadAttachments(List<AttachmentInfo> attachmentList)
        {
            // Xóa các tệp đính kèm cũ
            flpAttachments.Controls.Clear();
            attachments.Clear();

            if (attachmentList != null && attachmentList.Count > 0)
            {
                // Thêm các tệp mới vào danh sách
                attachments.AddRange(attachmentList);
                lblAttachmentTitle.Text = $"Tệp đính kèm ({attachmentList.Count})";
                pnlAttachment.Visible = true;

                // Tạo control hiển thị cho từng tệp đính kèm
                foreach (var attachment in attachmentList)
                {
                    AddAttachmentControl(attachment);
                }
            }
            else
            {
                // Không có tệp đính kèm
                lblAttachmentTitle.Text = "Tệp đính kèm (0)";
                pnlAttachment.Visible = false;
            }
        }

        /// <summary>
        /// Tạo điều khiển hiển thị cho một tệp đính kèm
        /// </summary>
        /// <param name="attachment">Thông tin tệp đính kèm</param>
        private void AddAttachmentControl(AttachmentInfo attachment)
        {
            // Tạo nút hiển thị thông tin tệp
            var btnAttachment = new Guna.UI2.WinForms.Guna2Button
            {
                Text = $"{attachment.FileName} ({FormatFileSize(attachment.FileSize)})",
                Size = new Size(180, 30),
                BorderRadius = 5,
                FillColor = Color.FromArgb(245, 248, 250),
                ForeColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 11),
                TextAlign = HorizontalAlignment.Left,
                Margin = new Padding(5, 0, 5, 0),
                Cursor = Cursors.Hand,
                Tag = attachment  // Lưu thông tin tệp vào Tag để sử dụng sau này
            };

            // Thêm biểu tượng dựa vào phần mở rộng của tệp
            string extension = Path.GetExtension(attachment.FileName).ToLower();
            Image icon = GetFileIcon(extension);
            if (icon != null)
            {
                btnAttachment.Image = icon;
                btnAttachment.ImageAlign = HorizontalAlignment.Left;
                btnAttachment.ImageSize = new Size(16, 16);
                btnAttachment.TextOffset = new Point(5, 0);
            }

            // Thêm sự kiện click để mở tệp
            btnAttachment.Click += BtnAttachment_Click;
            flpAttachments.Controls.Add(btnAttachment);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng click vào một tệp đính kèm
        /// </summary>
        private void BtnAttachment_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button btn && btn.Tag is AttachmentInfo attachment)
            {
                // Xử lý tải xuống hoặc mở tệp
                try
                {
                    // Kiểm tra xem tệp có tồn tại không
                    if (File.Exists(attachment.FilePath))
                    {
                        // Mở tệp bằng ứng dụng mặc định
                        System.Diagnostics.Process.Start(attachment.FilePath);
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi nếu không tìm thấy tệp
                        MessageBox.Show($"Không tìm thấy file: {attachment.FileName}",
                                      "Lỗi mở file",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khác nếu có
                    MessageBox.Show($"Lỗi khi mở file: {ex.Message}",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút tải xuống tất cả tệp đính kèm
        /// </summary>
        private void BtnDownloadAll_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có tệp đính kèm không
            if (attachments.Count == 0)
            {
                MessageBox.Show("Không có tệp đính kèm nào để tải xuống.",
                              "Thông báo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            // Hiển thị hộp thoại chọn thư mục lưu tệp
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục lưu tệp đính kèm";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = folderDialog.SelectedPath;
                    int successCount = 0;

                    // Sao chép từng tệp vào thư mục đã chọn
                    foreach (var attachment in attachments)
                    {
                        try
                        {
                            string targetPath = Path.Combine(targetFolder, attachment.FileName);
                            File.Copy(attachment.FilePath, targetPath, true);  // Ghi đè nếu tệp đã tồn tại
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            // Hiển thị thông báo lỗi nếu không thể sao chép tệp
                            MessageBox.Show($"Lỗi khi tải file {attachment.FileName}: {ex.Message}",
                                          "Lỗi",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }

                    // Hiển thị thông báo hoàn tất
                    MessageBox.Show($"Đã tải xuống {successCount}/{attachments.Count} tệp đính kèm.",
                                  "Hoàn tất",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút in thông báo
        /// </summary>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng in
            PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += PrintDocument_PrintPage;

            // Hiển thị hộp thoại in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();  // Thực hiện in
            }
        }

        /// <summary>
        /// Xử lý việc vẽ nội dung thông báo lên trang in
        /// </summary>
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Thiết lập font chữ cho các phần khác nhau của trang in
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12);
            Font contentFont = new Font("Segoe UI", 11);

            // Thiết lập vị trí và khoảng cách
            int y = 100;
            int leftMargin = 50;
            int rightMargin = e.MarginBounds.Right - 50;
            int width = rightMargin - leftMargin;

            // In tiêu đề
            e.Graphics.DrawString(lblTitle.Text, titleFont, Brushes.Navy, leftMargin, y);
            y += 50;

            // In thông tin người gửi
            e.Graphics.DrawString(lblNguoiGui.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 30;

            // In thông tin ngày gửi
            e.Graphics.DrawString(lblNgayGui.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 30;

            // In thông tin người nhận
            e.Graphics.DrawString(lblNguoiNhan.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 50;

            // In đường phân cách
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), leftMargin, y, rightMargin, y);
            y += 20;

            // In nội dung thông báo
            e.Graphics.DrawString(rtbContent.Text, contentFont, Brushes.Black,
                                new RectangleF(leftMargin, y, width, e.MarginBounds.Bottom - y));

            // In thông tin tệp đính kèm nếu có
            if (attachments.Count > 0)
            {
                y = e.MarginBounds.Bottom - 100;
                e.Graphics.DrawLine(new Pen(Color.Gray, 1), leftMargin, y, rightMargin, y);
                y += 20;
                e.Graphics.DrawString($"Tệp đính kèm ({attachments.Count}):", headerFont, Brushes.Black, leftMargin, y);
                y += 25;

                // In tên và kích thước của từng tệp đính kèm
                foreach (var attachment in attachments)
                {
                    e.Graphics.DrawString($"- {attachment.FileName} ({FormatFileSize(attachment.FileSize)})",
                                        contentFont, Brushes.Black, leftMargin, y);
                    y += 20;
                }
            }
        }

        /// <summary>
        /// Định dạng ngày giờ thành chuỗi hiển thị
        /// </summary>
        /// <param name="date">Đối tượng DateTime cần định dạng</param>
        /// <returns>Chuỗi ngày giờ đã định dạng</returns>
        private string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// Định dạng kích thước tệp thành chuỗi dễ đọc (B, KB, MB, GB, TB)
        /// </summary>
        /// <param name="bytes">Kích thước tệp tính bằng byte</param>
        /// <returns>Chuỗi kích thước tệp đã định dạng</returns>
        private string FormatFileSize(long bytes)
        {
            // Mảng chứa các đơn vị kích thước
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            double size = bytes;

            // Chuyển đổi sang đơn vị lớn hơn nếu kích thước > 1024
            while (size > 1024 && counter < suffixes.Length - 1)
            {
                size /= 1024;
                counter++;
            }

            // Trả về chuỗi đã định dạng với tối đa 2 chữ số thập phân
            return $"{size:0.##} {suffixes[counter]}";
        }

        private Image GetFileIcon(string extension)
        {
            // Phương thức này cần được thay thế bằng mã thực tế để lấy biểu tượng phù hợp
            // Ví dụ, sử dụng câu lệnh switch để trả về biểu tượng khác nhau
            // dựa trên các loại tệp thông dụng (PDF, DOC, XLS, v.v.)

            // Tạm thời, trả về null để sử dụng biểu tượng mặc định
            return null; // Thay thế bằng tài nguyên biểu tượng thực tế
        }
    }

}
