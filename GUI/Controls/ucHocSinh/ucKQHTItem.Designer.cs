namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucKQHTItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTeacherComment = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTeacherComment = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCommentHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlScoreDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.prgAverage = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.prgFinalExam = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblFinalExam = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFinalExamScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.prgMidtermExam = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblMidtermExam = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMidtermExamScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.prgAssignment = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblAssignment = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAssignmentScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblAvgScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDetails = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubjectName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMain.SuspendLayout();
            this.pnlTeacherComment.SuspendLayout();
            this.pnlScoreDetails.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.pnlMain.BorderRadius = 15;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.pnlTeacherComment);
            this.pnlMain.Controls.Add(this.pnlScoreDetails);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.BorderRadius = 15;
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlMain.ShadowDecoration.Depth = 5;
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(493, 316);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTeacherComment
            // 
            this.pnlTeacherComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTeacherComment.Controls.Add(this.txtTeacherComment);
            this.pnlTeacherComment.Controls.Add(this.lblCommentHeader);
            this.pnlTeacherComment.Location = new System.Drawing.Point(0, 189);
            this.pnlTeacherComment.Name = "pnlTeacherComment";
            this.pnlTeacherComment.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.pnlTeacherComment.Size = new System.Drawing.Size(490, 91);
            this.pnlTeacherComment.TabIndex = 2;
            // 
            // txtTeacherComment
            // 
            this.txtTeacherComment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.txtTeacherComment.BorderRadius = 10;
            this.txtTeacherComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTeacherComment.DefaultText = "Học sinh đạt kết quả tốt, có nhiều tiến bộ. Cần chú ý thêm về phần thực hành.";
            this.txtTeacherComment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTeacherComment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTeacherComment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.txtTeacherComment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTeacherComment.Enabled = false;
            this.txtTeacherComment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTeacherComment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTeacherComment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacherComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.txtTeacherComment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTeacherComment.Location = new System.Drawing.Point(15, 22);
            this.txtTeacherComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTeacherComment.Multiline = true;
            this.txtTeacherComment.Name = "txtTeacherComment";
            this.txtTeacherComment.Padding = new System.Windows.Forms.Padding(10);
            this.txtTeacherComment.PlaceholderText = "";
            this.txtTeacherComment.ReadOnly = true;
            this.txtTeacherComment.SelectedText = "";
            this.txtTeacherComment.Size = new System.Drawing.Size(449, 54);
            this.txtTeacherComment.TabIndex = 1;
            // 
            // lblCommentHeader
            // 
            this.lblCommentHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.lblCommentHeader.Location = new System.Drawing.Point(15, 0);
            this.lblCommentHeader.Name = "lblCommentHeader";
            this.lblCommentHeader.Size = new System.Drawing.Size(133, 22);
            this.lblCommentHeader.TabIndex = 0;
            this.lblCommentHeader.Text = "Nhận xét giáo viên";
            // 
            // pnlScoreDetails
            // 
            this.pnlScoreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScoreDetails.Controls.Add(this.prgAverage);
            this.pnlScoreDetails.Controls.Add(this.prgFinalExam);
            this.pnlScoreDetails.Controls.Add(this.lblFinalExam);
            this.pnlScoreDetails.Controls.Add(this.lblFinalExamScore);
            this.pnlScoreDetails.Controls.Add(this.prgMidtermExam);
            this.pnlScoreDetails.Controls.Add(this.lblMidtermExam);
            this.pnlScoreDetails.Controls.Add(this.lblMidtermExamScore);
            this.pnlScoreDetails.Controls.Add(this.prgAssignment);
            this.pnlScoreDetails.Controls.Add(this.lblAssignment);
            this.pnlScoreDetails.Controls.Add(this.lblAssignmentScore);
            this.pnlScoreDetails.Location = new System.Drawing.Point(0, 54);
            this.pnlScoreDetails.Name = "pnlScoreDetails";
            this.pnlScoreDetails.Padding = new System.Windows.Forms.Padding(15);
            this.pnlScoreDetails.Size = new System.Drawing.Size(490, 119);
            this.pnlScoreDetails.TabIndex = 1;
            // 
            // prgAverage
            // 
            this.prgAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prgAverage.BackColor = System.Drawing.Color.Transparent;
            this.prgAverage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.prgAverage.FillOffset = 5;
            this.prgAverage.FillThickness = 12;
            this.prgAverage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.prgAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.prgAverage.Location = new System.Drawing.Point(386, 14);
            this.prgAverage.Minimum = 0;
            this.prgAverage.Name = "prgAverage";
            this.prgAverage.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.prgAverage.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.prgAverage.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.prgAverage.ProgressOffset = 5;
            this.prgAverage.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.prgAverage.ProgressThickness = 12;
            this.prgAverage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.prgAverage.Size = new System.Drawing.Size(86, 86);
            this.prgAverage.TabIndex = 9;
            this.prgAverage.Text = "8.2";
            this.prgAverage.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Value;
            this.prgAverage.Value = 82;
            // 
            // prgFinalExam
            // 
            this.prgFinalExam.BackColor = System.Drawing.Color.Transparent;
            this.prgFinalExam.BorderRadius = 5;
            this.prgFinalExam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.prgFinalExam.Location = new System.Drawing.Point(196, 76);
            this.prgFinalExam.Maximum = 10;
            this.prgFinalExam.Name = "prgFinalExam";
            this.prgFinalExam.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgFinalExam.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.prgFinalExam.Size = new System.Drawing.Size(165, 12);
            this.prgFinalExam.TabIndex = 7;
            this.prgFinalExam.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.prgFinalExam.Value = 9;
            // 
            // lblFinalExam
            // 
            this.lblFinalExam.BackColor = System.Drawing.Color.Transparent;
            this.lblFinalExam.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalExam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.lblFinalExam.Location = new System.Drawing.Point(18, 68);
            this.lblFinalExam.Name = "lblFinalExam";
            this.lblFinalExam.Size = new System.Drawing.Size(89, 22);
            this.lblFinalExam.TabIndex = 6;
            this.lblFinalExam.Text = "Điểm cuối kỳ";
            // 
            // lblFinalExamScore
            // 
            this.lblFinalExamScore.BackColor = System.Drawing.Color.Transparent;
            this.lblFinalExamScore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalExamScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFinalExamScore.Location = new System.Drawing.Point(162, 71);
            this.lblFinalExamScore.Name = "lblFinalExamScore";
            this.lblFinalExamScore.Size = new System.Drawing.Size(12, 22);
            this.lblFinalExamScore.TabIndex = 5;
            this.lblFinalExamScore.Text = "9";
            // 
            // prgMidtermExam
            // 
            this.prgMidtermExam.BackColor = System.Drawing.Color.Transparent;
            this.prgMidtermExam.BorderRadius = 5;
            this.prgMidtermExam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.prgMidtermExam.Location = new System.Drawing.Point(196, 48);
            this.prgMidtermExam.Maximum = 10;
            this.prgMidtermExam.Name = "prgMidtermExam";
            this.prgMidtermExam.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.prgMidtermExam.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(220)))));
            this.prgMidtermExam.Size = new System.Drawing.Size(165, 12);
            this.prgMidtermExam.TabIndex = 4;
            this.prgMidtermExam.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.prgMidtermExam.Value = 8;
            // 
            // lblMidtermExam
            // 
            this.lblMidtermExam.BackColor = System.Drawing.Color.Transparent;
            this.lblMidtermExam.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMidtermExam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.lblMidtermExam.Location = new System.Drawing.Point(18, 41);
            this.lblMidtermExam.Name = "lblMidtermExam";
            this.lblMidtermExam.Size = new System.Drawing.Size(91, 22);
            this.lblMidtermExam.TabIndex = 3;
            this.lblMidtermExam.Text = "Điểm giữa kỳ";
            // 
            // lblMidtermExamScore
            // 
            this.lblMidtermExamScore.BackColor = System.Drawing.Color.Transparent;
            this.lblMidtermExamScore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMidtermExamScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(220)))));
            this.lblMidtermExamScore.Location = new System.Drawing.Point(162, 44);
            this.lblMidtermExamScore.Name = "lblMidtermExamScore";
            this.lblMidtermExamScore.Size = new System.Drawing.Size(12, 22);
            this.lblMidtermExamScore.TabIndex = 2;
            this.lblMidtermExamScore.Text = "8";
            // 
            // prgAssignment
            // 
            this.prgAssignment.BackColor = System.Drawing.Color.Transparent;
            this.prgAssignment.BorderRadius = 5;
            this.prgAssignment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.prgAssignment.Location = new System.Drawing.Point(196, 17);
            this.prgAssignment.Maximum = 10;
            this.prgAssignment.Name = "prgAssignment";
            this.prgAssignment.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.prgAssignment.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.prgAssignment.Size = new System.Drawing.Size(165, 12);
            this.prgAssignment.TabIndex = 1;
            this.prgAssignment.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.prgAssignment.Value = 7;
            // 
            // lblAssignment
            // 
            this.lblAssignment.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.lblAssignment.Location = new System.Drawing.Point(18, 14);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(133, 22);
            this.lblAssignment.TabIndex = 0;
            this.lblAssignment.Text = "Điểm thường xuyên";
            // 
            // lblAssignmentScore
            // 
            this.lblAssignmentScore.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignmentScore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignmentScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.lblAssignmentScore.Location = new System.Drawing.Point(162, 14);
            this.lblAssignmentScore.Name = "lblAssignmentScore";
            this.lblAssignmentScore.Size = new System.Drawing.Size(12, 22);
            this.lblAssignmentScore.TabIndex = 0;
            this.lblAssignmentScore.Text = "7";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BorderRadius = 15;
            this.pnlHeader.Controls.Add(this.lblAvgScore);
            this.pnlHeader.Controls.Add(this.btnDetails);
            this.pnlHeader.Controls.Add(this.lblSubjectName);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeader.Size = new System.Drawing.Size(490, 54);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAvgScore
            // 
            this.lblAvgScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgScore.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgScore.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblAvgScore.Location = new System.Drawing.Point(345, 8);
            this.lblAvgScore.Name = "lblAvgScore";
            this.lblAvgScore.Size = new System.Drawing.Size(33, 32);
            this.lblAvgScore.TabIndex = 3;
            this.lblAvgScore.Text = "8.2";
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Animated = true;
            this.btnDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(130)))), ((int)(((byte)(225)))));
            this.btnDetails.BorderRadius = 12;
            this.btnDetails.BorderThickness = 1;
            this.btnDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetails.FillColor = System.Drawing.Color.White;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(130)))), ((int)(((byte)(225)))));
            this.btnDetails.Location = new System.Drawing.Point(395, 8);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(80, 36);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "Chi tiết";
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.lblSubjectName.Location = new System.Drawing.Point(15, 17);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(41, 23);
            this.lblSubjectName.TabIndex = 1;
            this.lblSubjectName.Text = "Toán";
            // 
            // ucKQHTItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ucKQHTItem";
            this.Size = new System.Drawing.Size(493, 316);
            this.pnlMain.ResumeLayout(false);
            this.pnlTeacherComment.ResumeLayout(false);
            this.pnlTeacherComment.PerformLayout();
            this.pnlScoreDetails.ResumeLayout(false);
            this.pnlScoreDetails.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubjectName;
        private Guna.UI2.WinForms.Guna2Button btnDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlScoreDetails;
        private Guna.UI2.WinForms.Guna2ProgressBar prgAssignment;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAssignment;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAssignmentScore;
        private Guna.UI2.WinForms.Guna2ProgressBar prgMidtermExam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMidtermExam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMidtermExamScore;
        private Guna.UI2.WinForms.Guna2ProgressBar prgFinalExam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFinalExam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFinalExamScore;
        private Guna.UI2.WinForms.Guna2Panel pnlTeacherComment;
        private Guna.UI2.WinForms.Guna2TextBox txtTeacherComment;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCommentHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvgScore;
        private Guna.UI2.WinForms.Guna2CircleProgressBar prgAverage;
    }
}
