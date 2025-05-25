namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTLItem
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
            this.pnlOptions = new Guna.UI2.WinForms.Guna2Panel();
            this.txtEssayAnswer = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCharCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAttachFile = new Guna.UI2.WinForms.Guna2Button();
            this.lblAttachedFile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRemoveFile = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlQuestionContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQuestionText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlQuestionHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.imgQuestion = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblQuestionNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlQuestionContent.SuspendLayout();
            this.pnlQuestionHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMain.BorderRadius = 12;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.pnlOptions);
            this.pnlMain.Controls.Add(this.guna2Separator1);
            this.pnlMain.Controls.Add(this.pnlQuestionContent);
            this.pnlMain.Controls.Add(this.pnlQuestionHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.BorderRadius = 12;
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMain.ShadowDecoration.Depth = 5;
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.Size = new System.Drawing.Size(700, 378);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Controls.Add(this.txtEssayAnswer);
            this.pnlOptions.Controls.Add(this.lblCharCount);
            this.pnlOptions.Controls.Add(this.btnAttachFile);
            this.pnlOptions.Controls.Add(this.lblAttachedFile);
            this.pnlOptions.Controls.Add(this.btnRemoveFile);
            this.pnlOptions.Location = new System.Drawing.Point(25, 160);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(650, 203);
            this.pnlOptions.TabIndex = 3;
            // 
            // txtEssayAnswer
            // 
            this.txtEssayAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEssayAnswer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.txtEssayAnswer.BorderRadius = 8;
            this.txtEssayAnswer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEssayAnswer.DefaultText = "";
            this.txtEssayAnswer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEssayAnswer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEssayAnswer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEssayAnswer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEssayAnswer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.txtEssayAnswer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEssayAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEssayAnswer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.txtEssayAnswer.Location = new System.Drawing.Point(3, 3);
            this.txtEssayAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEssayAnswer.Multiline = true;
            this.txtEssayAnswer.Name = "txtEssayAnswer";
            this.txtEssayAnswer.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtEssayAnswer.PlaceholderText = "Nhập câu trả lời của bạn tại đây...";
            this.txtEssayAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEssayAnswer.SelectedText = "";
            this.txtEssayAnswer.Size = new System.Drawing.Size(644, 160);
            this.txtEssayAnswer.TabIndex = 0;
            this.txtEssayAnswer.TextChanged += new System.EventHandler(this.txtEssayAnswer_TextChanged);
            // 
            // lblCharCount
            // 
            this.lblCharCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCharCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCharCount.Location = new System.Drawing.Point(587, 180);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(50, 19);
            this.lblCharCount.TabIndex = 1;
            this.lblCharCount.Text = "0/10000";
            this.lblCharCount.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttachFile.BorderRadius = 6;
            this.btnAttachFile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAttachFile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAttachFile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAttachFile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAttachFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.btnAttachFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.ForeColor = System.Drawing.Color.White;
            this.btnAttachFile.Image = global::QuanLyTruongHoc.Properties.Resources.attach;
            this.btnAttachFile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAttachFile.ImageSize = new System.Drawing.Size(15, 15);
            this.btnAttachFile.Location = new System.Drawing.Point(12, 169);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(139, 30);
            this.btnAttachFile.TabIndex = 2;
            this.btnAttachFile.Text = "Đính kèm file";
            this.btnAttachFile.TextOffset = new System.Drawing.Point(-5, 0);
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // lblAttachedFile
            // 
            this.lblAttachedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAttachedFile.BackColor = System.Drawing.Color.Transparent;
            this.lblAttachedFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblAttachedFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.lblAttachedFile.Location = new System.Drawing.Point(135, 186);
            this.lblAttachedFile.Name = "lblAttachedFile";
            this.lblAttachedFile.Size = new System.Drawing.Size(3, 2);
            this.lblAttachedFile.TabIndex = 3;
            this.lblAttachedFile.Text = null;
            this.lblAttachedFile.Visible = false;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveFile.BorderRadius = 6;
            this.btnRemoveFile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveFile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveFile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveFile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRemoveFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveFile.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFile.Location = new System.Drawing.Point(168, 169);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(38, 30);
            this.btnRemoveFile.TabIndex = 4;
            this.btnRemoveFile.Text = "X";
            this.btnRemoveFile.Visible = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2Separator1.Location = new System.Drawing.Point(25, 145);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(650, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // pnlQuestionContent
            // 
            this.pnlQuestionContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuestionContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuestionContent.Controls.Add(this.lblQuestionText);
            this.pnlQuestionContent.Location = new System.Drawing.Point(25, 60);
            this.pnlQuestionContent.Name = "pnlQuestionContent";
            this.pnlQuestionContent.Size = new System.Drawing.Size(650, 80);
            this.pnlQuestionContent.TabIndex = 1;
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestionText.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionText.Location = new System.Drawing.Point(3, 3);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(131, 23);
            this.lblQuestionText.TabIndex = 0;
            this.lblQuestionText.Text = "Nội dung câu hỏi...";
            // 
            // pnlQuestionHeader
            // 
            this.pnlQuestionHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuestionHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuestionHeader.Controls.Add(this.imgQuestion);
            this.pnlQuestionHeader.Controls.Add(this.lblQuestionNumber);
            this.pnlQuestionHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlQuestionHeader.Location = new System.Drawing.Point(25, 15);
            this.pnlQuestionHeader.Name = "pnlQuestionHeader";
            this.pnlQuestionHeader.Size = new System.Drawing.Size(650, 40);
            this.pnlQuestionHeader.TabIndex = 0;
            // 
            // imgQuestion
            // 
            this.imgQuestion.Image = global::QuanLyTruongHoc.Properties.Resources.question_icon;
            this.imgQuestion.ImageRotate = 0F;
            this.imgQuestion.Location = new System.Drawing.Point(3, 3);
            this.imgQuestion.Name = "imgQuestion";
            this.imgQuestion.Size = new System.Drawing.Size(32, 32);
            this.imgQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgQuestion.TabIndex = 1;
            this.imgQuestion.TabStop = false;
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.lblQuestionNumber.Location = new System.Drawing.Point(41, 8);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(70, 25);
            this.lblQuestionNumber.TabIndex = 0;
            this.lblQuestionNumber.Text = "Câu 1/20";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Document files (*.doc;*.docx;*.pdf;*.txt)|*.doc;*.docx;*.pdf;*.txt|All files (*.*" +
    ")|*.*";
            this.openFileDialog1.Title = "Chọn file đính kèm";
            // 
            // ucTLItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTLItem";
            this.Size = new System.Drawing.Size(700, 378);
            this.pnlMain.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlQuestionContent.ResumeLayout(false);
            this.pnlQuestionContent.PerformLayout();
            this.pnlQuestionHeader.ResumeLayout(false);
            this.pnlQuestionHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlQuestionHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionNumber;
        private Guna.UI2.WinForms.Guna2PictureBox imgQuestion;
        private Guna.UI2.WinForms.Guna2Panel pnlQuestionContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionText;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel pnlOptions;
        private Guna.UI2.WinForms.Guna2TextBox txtEssayAnswer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCharCount;
        private Guna.UI2.WinForms.Guna2Button btnAttachFile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttachedFile;
        private Guna.UI2.WinForms.Guna2Button btnRemoveFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
