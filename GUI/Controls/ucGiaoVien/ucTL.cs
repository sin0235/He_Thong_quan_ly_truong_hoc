using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucTL : UserControl
    {
        private int questionNumber = 1;
        private string imagePath = "";

        // Event for when the question is requested to be removed
        public event EventHandler RemoveQuestionRequested;

        // Event for when any data in the question changes
        public event EventHandler QuestionDataChanged;

        public ucTL()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // Constructor that sets the question number
        public ucTL(int questionNumber)
        {
            InitializeComponent();
            this.questionNumber = questionNumber;
            lblQuestionNumber.Text = $"Câu hỏi #{questionNumber}";
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            // Set up event handlers
            txtQuestionContent.TextChanged += Control_ValueChanged;
            txtAnswerGuide.TextChanged += Control_ValueChanged;
            numQuestionScore.ValueChanged += Control_ValueChanged;
            
            btnRemove.Click += BtnRemove_Click;
            chkWordLimit.CheckedChanged += ChkWordLimit_CheckedChanged;
            numWordLimit.ValueChanged += Control_ValueChanged;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            // Notify that question data has changed
            OnQuestionDataChanged();
        }

 

        private void ChkWordLimit_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable word limit controls based on checkbox
            lblWordLimit.Enabled = chkWordLimit.Checked;
            numWordLimit.Enabled = chkWordLimit.Checked;

            // Notify that question data has changed
            OnQuestionDataChanged();
        }


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa câu hỏi #{questionNumber}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Trigger the remove event
                RemoveQuestionRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        // Trigger the QuestionDataChanged event
        protected void OnQuestionDataChanged()
        {
            QuestionDataChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Public Methods to Get Question Data

        // Method to retrieve the complete question data
        public EssayQuestionData GetQuestionData()
        {
            return new EssayQuestionData
            {
                QuestionNumber = questionNumber,
                QuestionContent = txtQuestionContent.Text,
                AnswerGuide = txtAnswerGuide.Text,
                Score = (double)numQuestionScore.Value,
                ImagePath = imagePath,
                HasWordLimit = chkWordLimit.Checked,
                WordLimit = (int)numWordLimit.Value
            };
        }

        // Method to validate if the question has all required data
        public bool ValidateQuestion()
        {
            // Check if question content is provided
            if (string.IsNullOrWhiteSpace(txtQuestionContent.Text))
                return false;

            return true;
        }

        // Method to set the question number (useful when reordering questions)
        public void SetQuestionNumber(int number)
        {
            questionNumber = number;
            lblQuestionNumber.Text = $"Câu hỏi #{number}";
        }

        #endregion
    }

    // Class to hold essay question data
    public class EssayQuestionData
    {
        public int QuestionNumber { get; set; }
        public string QuestionContent { get; set; }
        public string AnswerGuide { get; set; }
        public double Score { get; set; }
        public bool HasImage { get; set; }
        public string ImagePath { get; set; }
        public bool HasWordLimit { get; set; }
        public int WordLimit { get; set; }
    }
}
