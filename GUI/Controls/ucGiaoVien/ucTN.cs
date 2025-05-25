using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms;

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucTN : UserControl
    {
        private int questionNumber = 1;
        private List<Guna2TextBox> optionTextBoxes = new List<Guna2TextBox>();
        private string imagePath = "";

        // Event for when the question is requested to be removed
        public event EventHandler RemoveQuestionRequested;

        // Event for when any data in the question changes
        public event EventHandler QuestionDataChanged;

        public ucTN()
        {
            InitializeComponent();
            SetupInitialOptions();
        }

        // Constructor that sets the question number
        public ucTN(int questionNumber)
        {
            InitializeComponent();
            this.questionNumber = questionNumber;
            lblQuestionNumber.Text = $"Câu hỏi #{questionNumber}";
            SetupInitialOptions();
        }

        private void SetupInitialOptions()
        {
            // Add initial 4 options (A, B, C, D)
            for (int i = 0; i < 4; i++)
            {
                AddOptionControl(((char)('A' + i)).ToString());
            }

            // Set default selected value for correct answer
            if (cboCorrectAnswer.Items.Count > 0)
                cboCorrectAnswer.SelectedIndex = 0;
        }

        private void btnAddOption_Click(object sender, EventArgs e)
        {
            // Get next option letter (E, F, G, etc.)
            string nextOption = ((char)('A' + optionTextBoxes.Count)).ToString();

            // Only allow up to 10 options (A to J)
            if (optionTextBoxes.Count < 10)
            {
                AddOptionControl(nextOption);
                cboCorrectAnswer.Items.Add(nextOption);

                // Notify that question data has changed
                OnQuestionDataChanged();
            }
            else
            {
                MessageBox.Show("Không thể thêm quá 10 lựa chọn cho một câu hỏi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddOptionControl(string optionLabel)
        {
            // Create a panel to hold the option label and textbox
            Panel optionPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(0, 5, 0, 5)
            };

            // Create a label for the option (A, B, C, etc.)
            Guna.UI2.WinForms.Guna2HtmlLabel lblOption = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Text = optionLabel + ":",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(5, 10),
                Size = new Size(20, 17),
                BackColor = Color.Transparent
            };

            // Create a textbox for the option content
            Guna.UI2.WinForms.Guna2TextBox txtOption = new Guna.UI2.WinForms.Guna2TextBox
            {
                Location = new Point(30, 5),
                Size = new Size(pnlOptions.Width - 90, 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                BorderRadius = 5,
                PlaceholderText = $"Nội dung lựa chọn {optionLabel}...",
                Tag = optionLabel // Store the option letter in the Tag property
            };

            // Add event handler for when the option text changes
            txtOption.TextChanged += TxtOption_TextChanged;

            // Create a button to remove this option
            Guna.UI2.WinForms.Guna2Button btnRemoveOption = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "X",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(30, 30),
                BorderRadius = 5,
                FillColor = Color.FromArgb(255, 128, 128),
                Location = new Point(pnlOptions.Width - 50, 5),
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Tag = txtOption // Store reference to the textbox
            };

            // Only enable remove button if there are more than 2 options
            btnRemoveOption.Enabled = optionTextBoxes.Count >= 2;
            btnRemoveOption.Click += BtnRemoveOption_Click;

            // Add controls to the panel
            optionPanel.Controls.Add(lblOption);
            optionPanel.Controls.Add(txtOption);
            optionPanel.Controls.Add(btnRemoveOption);

            // Add panel to options panel
            pnlOptions.Controls.Add(optionPanel);
            optionPanel.BringToFront(); // Ensure newest option is at the top

            // Add textbox to our list for easier referencing
            optionTextBoxes.Add(txtOption);
        }

        private void TxtOption_TextChanged(object sender, EventArgs e)
        {
            // Notify that question data has changed
            OnQuestionDataChanged();
        }

        private void BtnRemoveOption_Click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Guna.UI2.WinForms.Guna2Button btnRemove = sender as Guna.UI2.WinForms.Guna2Button;
            if (btnRemove == null) return;

            // Get the textbox associated with this button
            Guna.UI2.WinForms.Guna2TextBox txtToRemove = btnRemove.Tag as Guna.UI2.WinForms.Guna2TextBox;
            if (txtToRemove == null) return;

            // Don't allow removing if there are only 2 options left
            if (optionTextBoxes.Count <= 2)
            {
                MessageBox.Show("Câu hỏi trắc nghiệm phải có ít nhất 2 lựa chọn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the option letter
            string optionLetter = txtToRemove.Tag.ToString();

            // Remove the option from the combo box
            cboCorrectAnswer.Items.Remove(optionLetter);

            // If we're removing the currently selected correct answer, select the first option instead
            if (cboCorrectAnswer.Text == optionLetter && cboCorrectAnswer.Items.Count > 0)
                cboCorrectAnswer.SelectedIndex = 0;

            // Remove the textbox from our list
            optionTextBoxes.Remove(txtToRemove);

            // Remove the panel containing the option
            Panel panelToRemove = txtToRemove.Parent as Panel;
            if (panelToRemove != null)
            {
                pnlOptions.Controls.Remove(panelToRemove);
                panelToRemove.Dispose();
            }

            // Re-label remaining options (A, B, C, etc.)
            RelabelOptions();

            // Notify that question data has changed
            OnQuestionDataChanged();
        }

        private void RelabelOptions()
        {
            // Clear the items in the combo box
            cboCorrectAnswer.Items.Clear();

            // Re-label options from A to whatever
            for (int i = 0; i < optionTextBoxes.Count; i++)
            {
                string newLabel = ((char)('A' + i)).ToString();

                // Find the panel and label for this option
                Panel optionPanel = optionTextBoxes[i].Parent as Panel;
                if (optionPanel != null)
                {
                    foreach (Control ctrl in optionPanel.Controls)
                    {
                        if (ctrl is Guna.UI2.WinForms.Guna2HtmlLabel lbl)
                        {
                            lbl.Text = newLabel + ":";
                        }
                    }
                }

                // Update the tag for the textbox
                optionTextBoxes[i].Tag = newLabel;
                optionTextBoxes[i].PlaceholderText = $"Nội dung lựa chọn {newLabel}...";

                // Add the new label to the combo box
                cboCorrectAnswer.Items.Add(newLabel);
            }

            // Ensure correct answer is selected
            if (cboCorrectAnswer.Items.Count > 0 && cboCorrectAnswer.SelectedIndex == -1)
                cboCorrectAnswer.SelectedIndex = 0;
        }

       

        private void btnRemove_Click(object sender, EventArgs e)
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
        public QuestionData GetQuestionData()
        {
            List<string> options = new List<string>();
            foreach (var textBox in optionTextBoxes)
            {
                options.Add(textBox.Text);
            }

            return new QuestionData
            {
                QuestionNumber = questionNumber,
                QuestionContent = txtQuestionContent.Text,
                Options = options,
                CorrectAnswer = cboCorrectAnswer.Text,
                Score = (double)numQuestionScore.Value,
                ImagePath = imagePath
            };
        }

        // Method to validate if the question has all required data
        public bool ValidateQuestion()
        {
            // Check if question content is provided
            if (string.IsNullOrWhiteSpace(txtQuestionContent.Text))
                return false;

            // Check if all options have content
            foreach (var textBox in optionTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                    return false;
            }

            // Check if correct answer is selected
            if (string.IsNullOrWhiteSpace(cboCorrectAnswer.Text))
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

}
