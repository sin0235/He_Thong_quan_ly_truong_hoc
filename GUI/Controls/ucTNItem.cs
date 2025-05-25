using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI.Controls
{
    public class ucTNItem
    {
        // Show the correct answers
        public void ShowCorrectAnswers()
        {
            ShowAnswers = true;
            UpdateUI();
        }
        
        // Method to get the currently selected options
        public List<int> GetSelectedOptions()
        {
            if (AllowMultipleAnswers)
            {
                // For multiple answer questions, return all checked options
                return checkBoxes
                    .Where(cb => cb.Checked)
                    .Select(cb => (int)cb.Tag)
                    .ToList();
            }
            else
            {
                // For single answer questions, return the selected option or empty list
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