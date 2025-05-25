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
    public partial class ucTestItem : UserControl
    {
        // Properties to store test information
        public int TestId { get; set; }
        public string Subject { get; set; }
        public string TestName { get; set; }
        public int Duration { get; set; } // in minutes
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AttemptsAllowed { get; set; }
        public int AttemptsUsed { get; set; }
        public string Notes { get; set; }
        public bool IsHomework { get; set; }

        // Event to notify when the test is started
        public event EventHandler TestStarted;

        public ucTestItem()
        {
            InitializeComponent();
            SetupControl();
        }

        private void SetupControl()
        {
            // Apply modern style
            this.BackColor = Color.Transparent;
            guna2Panel1.ShadowDecoration.Enabled = true;
            guna2Panel1.ShadowDecoration.Depth = 5;
            guna2Panel1.ShadowDecoration.Color = Color.FromArgb(230, 230, 230);
            guna2Panel1.BorderRadius = 10;

            // Set up start button click event
            btnBegin.Click += Guna2Button1_Click;
        }

        // Load test data into the control
        public void LoadTestData(int id, string subject, string testName, int duration,
            DateTime startTime, DateTime endTime, int attemptsAllowed, int attemptsUsed,
            string notes, bool isHomework = false)
        {
            TestId = id;
            Subject = subject;
            TestName = testName;
            Duration = duration;
            StartTime = startTime;
            EndTime = endTime;
            AttemptsAllowed = attemptsAllowed;
            AttemptsUsed = attemptsUsed;
            Notes = notes;
            IsHomework = isHomework;

            UpdateDisplay();
        }

        // Update the display with current data
        private void UpdateDisplay()
        {
            guna2HtmlLabel1.Text = Subject;
            guna2HtmlLabel2.Text = TestName;
            guna2HtmlLabel3.Text = $"Thời gian làm bài: {Duration} phút";
            guna2HtmlLabel4.Text = $"Bắt đầu: {StartTime:dd/MM/yyyy HH:mm}";
            guna2HtmlLabel5.Text = $"Kết thúc: {EndTime:dd/MM/yyyy HH:mm}";
            
            // Calculate remaining attempts
            int remainingAttempts = AttemptsAllowed - AttemptsUsed;
            string attemptsText = remainingAttempts > 0 
                ? $"Còn lại {remainingAttempts}/{AttemptsAllowed} lần làm bài" 
                : "Đã hết lượt làm bài";
            
            guna2HtmlLabel6.Text = attemptsText;
            
            // Add color coding for remaining attempts
            if (remainingAttempts == 0)
                guna2HtmlLabel6.ForeColor = Color.Red;
            else if (remainingAttempts == 1)
                guna2HtmlLabel6.ForeColor = Color.Orange;
            else
                guna2HtmlLabel6.ForeColor = Color.Green;
                
            guna2TextBox1.Text = Notes ?? "";

            // Change button text based on whether it's a test or homework
            btnBegin.Text = IsHomework ? "Bắt đầu làm bài tập" : "Bắt đầu làm bài kiểm tra";

            // Adjust button visibility based on availability
            bool isAvailable = DateTime.Now >= StartTime && DateTime.Now <= EndTime && AttemptsUsed < AttemptsAllowed;
            btnBegin.Enabled = isAvailable;

            // Update color scheme based on status
            if (!isAvailable)
            {
                btnBegin.FillColor = Color.Gray;
                guna2Panel1.FillColor = Color.FromArgb(245, 245, 245);
            }
            else
            {
                btnBegin.FillColor = Color.FromArgb(0, 120, 215);
                guna2Panel1.FillColor = Color.FromArgb(248, 250, 255);
            }
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            // Check if the test is available
            if (DateTime.Now < StartTime)
            {
                MessageBox.Show("Bài kiểm tra chưa bắt đầu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DateTime.Now > EndTime)
            {
                MessageBox.Show("Bài kiểm tra đã kết thúc.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (AttemptsUsed >= AttemptsAllowed)
            {
                MessageBox.Show("Bạn đã sử dụng hết số lần làm bài cho phép.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open test form
            ShowTestForm();
        }

        private void ShowTestForm()
        {
            try
            {
                // Chỉ thông báo cho người nghe (ucKiemTra) rằng bài thi đã được bắt đầu
                // ucKiemTra sẽ xử lý việc tạo form với TestId và maHS
                TestStarted?.Invoke(this, EventArgs.Empty);

                // Tăng số lần thử sau khi hoàn thành bài kiểm tra
                AttemptsUsed++;
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở bài kiểm tra: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // This can be used if you want to update the Notes property
            Notes = guna2TextBox1.Text;
        }
    }
}
