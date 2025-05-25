namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    partial class ucTN
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
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuestionNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numQuestionScore = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlOptions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddOption = new Guna.UI2.WinForms.Guna2Button();
            this.lblOptions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboCorrectAnswer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCorrectAnswer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtQuestionContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQuestionContent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestionScore)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlMain.BorderRadius = 10;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.btnRemove);
            this.pnlMain.Controls.Add(this.lblQuestionNumber);
            this.pnlMain.Controls.Add(this.numQuestionScore);
            this.pnlMain.Controls.Add(this.lblScore);
            this.pnlMain.Controls.Add(this.pnlOptions);
            this.pnlMain.Controls.Add(this.btnAddOption);
            this.pnlMain.Controls.Add(this.lblOptions);
            this.pnlMain.Controls.Add(this.cboCorrectAnswer);
            this.pnlMain.Controls.Add(this.lblCorrectAnswer);
            this.pnlMain.Controls.Add(this.txtQuestionContent);
            this.pnlMain.Controls.Add(this.lblQuestionContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(720, 500);
            this.pnlMain.TabIndex = 0;
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
            this.btnRemove.Location = new System.Drawing.Point(146, 454);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Xóa câu hỏi";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblQuestionNumber.Location = new System.Drawing.Point(20, 15);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(83, 23);
            this.lblQuestionNumber.TabIndex = 8;
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
            this.numQuestionScore.TabIndex = 7;
            this.numQuestionScore.Value = new decimal(new int[] {
            1,
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
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Điểm:";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.AutoScroll = true;
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Location = new System.Drawing.Point(20, 236);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlOptions.Size = new System.Drawing.Size(680, 212);
            this.pnlOptions.TabIndex = 5;
            // 
            // btnAddOption
            // 
            this.btnAddOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOption.BorderRadius = 5;
            this.btnAddOption.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddOption.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddOption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddOption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddOption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddOption.ForeColor = System.Drawing.Color.White;
            this.btnAddOption.Location = new System.Drawing.Point(20, 454);
            this.btnAddOption.Name = "btnAddOption";
            this.btnAddOption.Size = new System.Drawing.Size(120, 30);
            this.btnAddOption.TabIndex = 4;
            this.btnAddOption.Text = "Thêm lựa chọn";
            this.btnAddOption.Click += new System.EventHandler(this.btnAddOption_Click);
            // 
            // lblOptions
            // 
            this.lblOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOptions.Location = new System.Drawing.Point(20, 215);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(65, 17);
            this.lblOptions.TabIndex = 3;
            this.lblOptions.Text = "Các đáp án:";
            // 
            // cboCorrectAnswer
            // 
            this.cboCorrectAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCorrectAnswer.BackColor = System.Drawing.Color.Transparent;
            this.cboCorrectAnswer.BorderRadius = 5;
            this.cboCorrectAnswer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCorrectAnswer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorrectAnswer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCorrectAnswer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCorrectAnswer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCorrectAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCorrectAnswer.ItemHeight = 30;
            this.cboCorrectAnswer.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cboCorrectAnswer.Location = new System.Drawing.Point(580, 454);
            this.cboCorrectAnswer.Name = "cboCorrectAnswer";
            this.cboCorrectAnswer.Size = new System.Drawing.Size(120, 36);
            this.cboCorrectAnswer.TabIndex = 2;
            // 
            // lblCorrectAnswer
            // 
            this.lblCorrectAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCorrectAnswer.BackColor = System.Drawing.Color.Transparent;
            this.lblCorrectAnswer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCorrectAnswer.Location = new System.Drawing.Point(494, 464);
            this.lblCorrectAnswer.Name = "lblCorrectAnswer";
            this.lblCorrectAnswer.Size = new System.Drawing.Size(74, 17);
            this.lblCorrectAnswer.TabIndex = 1;
            this.lblCorrectAnswer.Text = "Đáp án đúng:";
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
            this.txtQuestionContent.PlaceholderText = "Nhập nội dung câu hỏi...";
            this.txtQuestionContent.SelectedText = "";
            this.txtQuestionContent.Size = new System.Drawing.Size(668, 120);
            this.txtQuestionContent.TabIndex = 0;
            // 
            // lblQuestionContent
            // 
            this.lblQuestionContent.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionContent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuestionContent.Location = new System.Drawing.Point(20, 44);
            this.lblQuestionContent.Name = "lblQuestionContent";
            this.lblQuestionContent.Size = new System.Drawing.Size(98, 17);
            this.lblQuestionContent.TabIndex = 0;
            this.lblQuestionContent.Text = "Nội dung câu hỏi:";
            // 
            // ucTN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTN";
            this.Size = new System.Drawing.Size(720, 500);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestionScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionContent;
        private Guna.UI2.WinForms.Guna2TextBox txtQuestionContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCorrectAnswer;
        private Guna.UI2.WinForms.Guna2ComboBox cboCorrectAnswer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOptions;
        private Guna.UI2.WinForms.Guna2Button btnAddOption;
        private Guna.UI2.WinForms.Guna2Panel pnlOptions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScore;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuestionScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionNumber;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}
