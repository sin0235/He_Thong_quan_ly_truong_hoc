namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    partial class ucTL
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
            this.chkWordLimit = new Guna.UI2.WinForms.Guna2CheckBox();
            this.numWordLimit = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblWordLimit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtAnswerGuide = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAnswerGuide = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblQuestionNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numQuestionScore = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.txtQuestionContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQuestionContent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestionScore)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlMain.BorderRadius = 10;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.chkWordLimit);
            this.pnlMain.Controls.Add(this.numWordLimit);
            this.pnlMain.Controls.Add(this.lblWordLimit);
            this.pnlMain.Controls.Add(this.txtAnswerGuide);
            this.pnlMain.Controls.Add(this.lblAnswerGuide);
            this.pnlMain.Controls.Add(this.guna2Separator1);
            this.pnlMain.Controls.Add(this.lblQuestionNumber);
            this.pnlMain.Controls.Add(this.numQuestionScore);
            this.pnlMain.Controls.Add(this.lblScore);
            this.pnlMain.Controls.Add(this.btnRemove);
            this.pnlMain.Controls.Add(this.txtQuestionContent);
            this.pnlMain.Controls.Add(this.lblQuestionContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(720, 500);
            this.pnlMain.TabIndex = 1;
            // 
            // chkWordLimit
            // 
            this.chkWordLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWordLimit.AutoSize = true;
            this.chkWordLimit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWordLimit.CheckedState.BorderRadius = 0;
            this.chkWordLimit.CheckedState.BorderThickness = 0;
            this.chkWordLimit.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWordLimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkWordLimit.Location = new System.Drawing.Point(388, 461);
            this.chkWordLimit.Name = "chkWordLimit";
            this.chkWordLimit.Size = new System.Drawing.Size(154, 19);
            this.chkWordLimit.TabIndex = 24;
            this.chkWordLimit.Text = "Giới hạn số từ câu trả lời";
            this.chkWordLimit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkWordLimit.UncheckedState.BorderRadius = 0;
            this.chkWordLimit.UncheckedState.BorderThickness = 0;
            this.chkWordLimit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // numWordLimit
            // 
            this.numWordLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWordLimit.BackColor = System.Drawing.Color.Transparent;
            this.numWordLimit.BorderRadius = 5;
            this.numWordLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numWordLimit.Enabled = false;
            this.numWordLimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numWordLimit.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWordLimit.Location = new System.Drawing.Point(604, 454);
            this.numWordLimit.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWordLimit.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWordLimit.Name = "numWordLimit";
            this.numWordLimit.Size = new System.Drawing.Size(96, 30);
            this.numWordLimit.TabIndex = 23;
            this.numWordLimit.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblWordLimit
            // 
            this.lblWordLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWordLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblWordLimit.Enabled = false;
            this.lblWordLimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWordLimit.Location = new System.Drawing.Point(547, 461);
            this.lblWordLimit.Name = "lblWordLimit";
            this.lblWordLimit.Size = new System.Drawing.Size(66, 17);
            this.lblWordLimit.TabIndex = 22;
            this.lblWordLimit.Text = "Số từ tối đa:";
            // 
            // txtAnswerGuide
            // 
            this.txtAnswerGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswerGuide.BorderRadius = 5;
            this.txtAnswerGuide.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAnswerGuide.DefaultText = "";
            this.txtAnswerGuide.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAnswerGuide.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAnswerGuide.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnswerGuide.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnswerGuide.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAnswerGuide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAnswerGuide.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAnswerGuide.Location = new System.Drawing.Point(20, 234);
            this.txtAnswerGuide.Multiline = true;
            this.txtAnswerGuide.Name = "txtAnswerGuide";
            this.txtAnswerGuide.PlaceholderText = "Nhập gợi ý đáp án, hướng dẫn chấm điểm hoặc đáp án mẫu...";
            this.txtAnswerGuide.SelectedText = "";
            this.txtAnswerGuide.Size = new System.Drawing.Size(680, 174);
            this.txtAnswerGuide.TabIndex = 21;
            // 
            // lblAnswerGuide
            // 
            this.lblAnswerGuide.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswerGuide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAnswerGuide.Location = new System.Drawing.Point(20, 211);
            this.lblAnswerGuide.Name = "lblAnswerGuide";
            this.lblAnswerGuide.Size = new System.Drawing.Size(159, 17);
            this.lblAnswerGuide.TabIndex = 20;
            this.lblAnswerGuide.Text = "Hướng dẫn đáp án (cho GV):";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(20, 195);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(680, 10);
            this.guna2Separator1.TabIndex = 19;
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblQuestionNumber.Location = new System.Drawing.Point(20, 15);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(83, 23);
            this.lblQuestionNumber.TabIndex = 15;
            this.lblQuestionNumber.Text = "Câu hỏi #1";
            // 
            // numQuestionScore
            // 
            this.numQuestionScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numQuestionScore.BackColor = System.Drawing.Color.Transparent;
            this.numQuestionScore.BorderRadius = 5;
            this.numQuestionScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numQuestionScore.DecimalPlaces = 1;
            this.numQuestionScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numQuestionScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numQuestionScore.Location = new System.Drawing.Point(604, 13);
            this.numQuestionScore.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQuestionScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numQuestionScore.Name = "numQuestionScore";
            this.numQuestionScore.Size = new System.Drawing.Size(84, 25);
            this.numQuestionScore.TabIndex = 14;
            this.numQuestionScore.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblScore.Location = new System.Drawing.Point(569, 17);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(34, 17);
            this.lblScore.TabIndex = 13;
            this.lblScore.Text = "Điểm:";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemove.BorderRadius = 5;
            this.btnRemove.BorderThickness = 1;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.White;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemove.Location = new System.Drawing.Point(20, 454);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Xóa câu hỏi";
            // 
            // txtQuestionContent
            // 
            this.txtQuestionContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestionContent.BorderRadius = 5;
            this.txtQuestionContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuestionContent.DefaultText = "";
            this.txtQuestionContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuestionContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuestionContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuestionContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuestionContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuestionContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuestionContent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuestionContent.Location = new System.Drawing.Point(20, 65);
            this.txtQuestionContent.Multiline = true;
            this.txtQuestionContent.Name = "txtQuestionContent";
            this.txtQuestionContent.PlaceholderText = "Nhập nội dung câu hỏi tự luận...";
            this.txtQuestionContent.SelectedText = "";
            this.txtQuestionContent.Size = new System.Drawing.Size(668, 120);
            this.txtQuestionContent.TabIndex = 10;
            // 
            // lblQuestionContent
            // 
            this.lblQuestionContent.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionContent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuestionContent.Location = new System.Drawing.Point(20, 44);
            this.lblQuestionContent.Name = "lblQuestionContent";
            this.lblQuestionContent.Size = new System.Drawing.Size(98, 17);
            this.lblQuestionContent.TabIndex = 9;
            this.lblQuestionContent.Text = "Nội dung câu hỏi:";
            // 
            // ucTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTL";
            this.Size = new System.Drawing.Size(720, 500);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestionScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionContent;
        private Guna.UI2.WinForms.Guna2TextBox txtQuestionContent;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScore;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuestionScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionNumber;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAnswerGuide;
        private Guna.UI2.WinForms.Guna2TextBox txtAnswerGuide;
        private Guna.UI2.WinForms.Guna2CheckBox chkWordLimit;
        private Guna.UI2.WinForms.Guna2NumericUpDown numWordLimit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWordLimit;
    }
}
