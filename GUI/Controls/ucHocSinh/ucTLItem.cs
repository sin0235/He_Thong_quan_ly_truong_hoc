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

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTLItem : UserControl
    {
        // Event để thông báo khi câu trả lời thay đổi
        public event EventHandler<EssayAnswerChangedEventArgs> AnswerChanged;

        // Properties
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        // Add these properties to ucTLItem.cs class
        public string AttachedFilePath { get; private set; } = "";
        public string AttachedFileName { get; private set; } = "";

        // Add this to EssayAnswerChangedEventArgs class


        // Add these methods to ucTLItem.cs class

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetAttachedFile(openFileDialog1.FileName);
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            RemoveAttachedFile();
        }

        public void SetAttachedFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            AttachedFilePath = filePath;
            AttachedFileName = System.IO.Path.GetFileName(filePath);

            // Update UI
            lblAttachedFile.Text = AttachedFileName;
            lblAttachedFile.Visible = true;
            btnRemoveFile.Visible = true;

            // Notify change
            AnswerChanged?.Invoke(this, new EssayAnswerChangedEventArgs
            {
                QuestionId = QuestionId,
                Answer = EssayAnswer,
                AttachedFilePath = AttachedFilePath,
                AttachedFileName = AttachedFileName
            });
        }

        public void RemoveAttachedFile()
        {
            AttachedFilePath = "";
            AttachedFileName = "";

            // Update UI
            lblAttachedFile.Text = "";
            lblAttachedFile.Visible = false;
            btnRemoveFile.Visible = false;

            // Notify change
            AnswerChanged?.Invoke(this, new EssayAnswerChangedEventArgs
            {
                QuestionId = QuestionId,
                Answer = EssayAnswer,
                AttachedFilePath = "",
                AttachedFileName = ""
            });
        }

        // Update these existing methods to handle file attachments

        // Modify ResetAnswer() method
        public void ResetAnswer()
        {
            txtEssayAnswer.Text = string.Empty;
            EssayAnswer = string.Empty;
            RemoveAttachedFile();
            UpdateCharCount();
        }

        // Modify ShowModelAnswer() method to handle attachments correctly
        public void ShowModelAnswer()
        {
            ShowAnswers = true;
            // Don't hide file attachment controls when showing model answers
            btnAttachFile.Visible = false;
            btnRemoveFile.Visible = false;
            UpdateUI();
        }

        // Modify txtEssayAnswer_TextChanged to include file attachment info when raising event
        private void txtEssayAnswer_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật câu trả lời
            EssayAnswer = txtEssayAnswer.Text;

            // Cập nhật số lượng ký tự
            UpdateCharCount();

            // Gọi event AnswerChanged với cả thông tin file
            AnswerChanged?.Invoke(this, new EssayAnswerChangedEventArgs
            {
                QuestionId = QuestionId,
                Answer = EssayAnswer,
                AttachedFilePath = AttachedFilePath,
                AttachedFileName = AttachedFileName
            });

            // Giới hạn số lượng ký tự
            if (txtEssayAnswer.Text.Length > MaxCharacters)
            {
                txtEssayAnswer.Text = txtEssayAnswer.Text.Substring(0, MaxCharacters);
                txtEssayAnswer.SelectionStart = MaxCharacters;
            }
        }
        public Image QuestionImage { get; set; }
        public string EssayAnswer { get; set; } = "";
        public string ModelAnswer { get; set; } = ""; // Đáp án mẫu
        public int MaxCharacters { get; set; } = 10000; // Giới hạn ký tự mặc định
        public int Points { get; set; } = 1;
        public bool ShowAnswers { get; set; } = false;

        // Constructor
        public ucTLItem()
        {
            InitializeComponent();
            UpdateCharCount();
        }

        // Tải dữ liệu câu hỏi
        public void LoadQuestion(int id, int number, string text, string modelAnswer = "",
            int maxChars = 10000, Image image = null, int points = 1, bool showAnswers = false)
        {
            // Lưu thuộc tính
            QuestionId = id;
            QuestionNumber = number;
            QuestionText = text;
            ModelAnswer = modelAnswer;
            MaxCharacters = maxChars;
            QuestionImage = image;
            Points = points;
            ShowAnswers = showAnswers;

            // Cập nhật giao diện
            UpdateUI();
        }

        // Cập nhật giao diện dựa trên thuộc tính
        private void UpdateUI()
        {
            // Cập nhật số thứ tự câu hỏi và điểm
            lblQuestionNumber.Text = $"Câu {QuestionNumber}";
            if (Points > 1)
                lblQuestionNumber.Text += $" ({Points} điểm)";

            // Cập nhật nội dung câu hỏi
            lblQuestionText.Text = QuestionText;

            // Đặt hình ảnh nếu có
            if (QuestionImage != null)
                imgQuestion.Image = QuestionImage;

            // Cập nhật giới hạn ký tự
            lblCharCount.Text = $"0/{MaxCharacters}";

            // Hiển thị đáp án mẫu nếu đang ở chế độ xem đáp án
            if (ShowAnswers && !string.IsNullOrEmpty(ModelAnswer))
            {
                txtEssayAnswer.Text = ModelAnswer;
                txtEssayAnswer.ReadOnly = true;
                txtEssayAnswer.BorderColor = Color.FromArgb(0, 150, 60);
                txtEssayAnswer.FillColor = Color.FromArgb(240, 255, 240);
            }
        }

        // Cập nhật hiển thị số lượng ký tự
        private void UpdateCharCount()
        {
            int currentLength = txtEssayAnswer.Text.Length;
            lblCharCount.Text = $"{currentLength}/{MaxCharacters}";

            // Đổi màu khi vượt quá 90% số ký tự cho phép
            if (currentLength > MaxCharacters * 0.9)
                lblCharCount.ForeColor = Color.FromArgb(220, 53, 69);
            else
                lblCharCount.ForeColor = Color.Gray;
        }

        // Đặt câu trả lời
        public void SetAnswer(string answer)
        {
            txtEssayAnswer.Text = answer;
            EssayAnswer = answer;
        }

        // Lấy câu trả lời
        public string GetAnswer()
        {
            return EssayAnswer;
        }

       
    }

    // Add the missing properties to the EssayAnswerChangedEventArgs class
    public class EssayAnswerChangedEventArgs : EventArgs
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string AttachedFilePath { get; set; } // Added property
        public string AttachedFileName { get; set; } // Added property
    }
}
