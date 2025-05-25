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
    public partial class ucTNItem : UserControl
    {
        // Event to notify when an answer is selected
        public event EventHandler<AnswerSelectedEventArgs> AnswerSelected;

        // Properties
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public Image QuestionImage { get; set; }
        public List<string> Options { get; set; }
        public int SelectedOption { get; set; } = -1;
        public bool AllowMultipleAnswers { get; set; } = false;
        public List<int> CorrectOptions { get; set; }
        public int Points { get; set; } = 1;
        public bool ShowAnswers { get; set; } = false;

        // UI components for options
        private List<Guna2RadioButton> radioButtons = new List<Guna2RadioButton>();
        private List<Guna2CheckBox> checkBoxes = new List<Guna2CheckBox>();

        // Constructor
        public ucTNItem()
        {
            InitializeComponent();
            Options = new List<string>();
            CorrectOptions = new List<int>();
        }

        // Load question data
        public void LoadQuestion(int id, int number, string text, List<string> options,
            List<int> correctOptions = null, bool allowMultiple = false,
            Image image = null, int points = 1, bool showAnswers = false)
        {
            // Store properties
            QuestionId = id;
            QuestionNumber = number;
            QuestionText = text;
            Options = options ?? new List<string>();
            CorrectOptions = correctOptions ?? new List<int>();
            AllowMultipleAnswers = allowMultiple;
            QuestionImage = image;
            Points = points;
            ShowAnswers = showAnswers;

            // Update UI
            UpdateUI();
        }

        // Update UI based on properties
        private void UpdateUI()
        {
            // Update question number and text
            lblQuestionNumber.Text = $"Câu {QuestionNumber}";
            if (Points > 1)
                lblQuestionNumber.Text += $" ({Points} điểm)";

            lblQuestionText.Text = QuestionText;

            // Set image if available
            if (QuestionImage != null)
                imgQuestion.Image = QuestionImage;

            // Clear existing options
            pnlOptions.Controls.Clear();
            radioButtons.Clear();
            checkBoxes.Clear();

            // Create options
            if (AllowMultipleAnswers)
                CreateCheckBoxOptions();
            else
                CreateRadioOptions();
        }

        // Create radio buttons for single-answer questions
        private void CreateRadioOptions()
        {
            string[] optionLabels = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int yPos = 5;

            for (int i = 0; i < Options.Count; i++)
            {
                Guna2RadioButton radioButton = new Guna2RadioButton();
                radioButton.AutoSize = false;
                radioButton.Width = pnlOptions.Width - 20;
                radioButton.Height = 35;
                radioButton.Location = new Point(10, yPos);
                radioButton.Text = $"{optionLabels[i]}. {Options[i]}";
                radioButton.Tag = i;
                radioButton.Font = new Font("Segoe UI", 9.75f);
                radioButton.ForeColor = Color.FromArgb(64, 64, 64);
                radioButton.CheckedState.FillColor = Color.FromArgb(0, 110, 220);
                radioButton.UncheckedState.FillColor = Color.White;
                radioButton.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);

                // Set checked if this is the selected option
                if (i == SelectedOption)
                    radioButton.Checked = true;

                // If showing answers, highlight correct option
                if (ShowAnswers)
                {
                    if (CorrectOptions.Contains(i))
                    {
                        radioButton.ForeColor = Color.FromArgb(0, 150, 60);
                        radioButton.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                    }
                    // If this was selected incorrectly
                    else if (i == SelectedOption)
                    {
                        radioButton.ForeColor = Color.FromArgb(220, 20, 60);
                        radioButton.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                    }
                }

                // Add event handler
                radioButton.CheckedChanged += RadioButton_CheckedChanged;

                // Add to container and list
                pnlOptions.Controls.Add(radioButton);
                radioButtons.Add(radioButton);

                yPos += 40;
            }
        }

        // Create checkboxes for multiple-answer questions
        private void CreateCheckBoxOptions()
        {
            string[] optionLabels = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int yPos = 5;

            for (int i = 0; i < Options.Count; i++)
            {
                Guna2CheckBox checkBox = new Guna2CheckBox();
                checkBox.AutoSize = false;
                checkBox.Width = pnlOptions.Width - 20;
                checkBox.Height = 35;
                checkBox.Location = new Point(10, yPos);
                checkBox.Text = $"{optionLabels[i]}. {Options[i]}";
                checkBox.Tag = i;
                checkBox.Font = new Font("Segoe UI", 9.75f);
                checkBox.ForeColor = Color.FromArgb(64, 64, 64);
                checkBox.CheckedState.FillColor = Color.FromArgb(0, 110, 220);
                checkBox.UncheckedState.FillColor = Color.White;
                checkBox.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);

                // If showing answers, highlight correct options
                if (ShowAnswers)
                {
                    if (CorrectOptions.Contains(i))
                    {
                        checkBox.ForeColor = Color.FromArgb(0, 150, 60);
                        checkBox.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                    }
                    // If this was selected incorrectly (was selected but is not correct)
                    else if (SelectedOption == i)
                    {
                        checkBox.ForeColor = Color.FromArgb(220, 20, 60);
                        checkBox.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                    }
                }

                // Add event handler
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                // Add to container and list
                pnlOptions.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);

                yPos += 40;
            }
        }

        // Handle radio button selection
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Guna2RadioButton radioButton = sender as Guna2RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                SelectedOption = (int)radioButton.Tag;

                // Raise event
                AnswerSelected?.Invoke(this, new AnswerSelectedEventArgs
                {
                    QuestionId = QuestionId,
                    SelectedOptions = new List<int> { SelectedOption }
                });
            }
        }

        // Handle checkbox selection
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<int> selectedOptions = new List<int>();

            // Gather all checked options
            foreach (Guna2CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked)
                    selectedOptions.Add((int)checkBox.Tag);
            }

            // Raise event
            AnswerSelected?.Invoke(this, new AnswerSelectedEventArgs
            {
                QuestionId = QuestionId,
                SelectedOptions = selectedOptions
            });
        }

        // Reset the selected option
        public void ResetSelection()
        {
            SelectedOption = -1;
            foreach (var radioButton in radioButtons)
                radioButton.Checked = false;

            foreach (var checkBox in checkBoxes)
                checkBox.Checked = false;
        }

        // Mark the answer as correct or incorrect
        public bool IsCorrect()
        {
            if (AllowMultipleAnswers)
            {
                List<int> selectedOptions = checkBoxes
                    .Where(cb => cb.Checked)
                    .Select(cb => (int)cb.Tag)
                    .ToList();

                // All correct options must be selected, and no incorrect ones
                return CorrectOptions.Count == selectedOptions.Count &&
                       CorrectOptions.All(o => selectedOptions.Contains(o));
            }
            else
            {
                return CorrectOptions.Contains(SelectedOption);
            }
        }

        // Show the correct answers
        public void ShowCorrectAnswers()
        {
            ShowAnswers = true;
            UpdateUI();
        }
        
        // Get the currently selected options
        public List<int> GetSelectedOptions()
        {
            if (AllowMultipleAnswers)
            {
                // For multiple-answer questions, return all checked boxes
                return checkBoxes
                    .Where(cb => cb.Checked)
                    .Select(cb => (int)cb.Tag)
                    .ToList();
            }
            else
            {
                // For single-answer questions, return the selected option or empty list
                return SelectedOption >= 0 ? new List<int> { SelectedOption } : new List<int>();
            }
        }
    }

    // Event arguments for answer selection
    public class AnswerSelectedEventArgs : EventArgs
    {
        public int QuestionId { get; set; }
        public List<int> SelectedOptions { get; set; }
    }
}
