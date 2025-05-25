namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTNItem
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
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlQuestionContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQuestionText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlQuestionHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.imgQuestion = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblQuestionNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMain.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(700, 350);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Location = new System.Drawing.Point(25, 160);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(650, 175);
            this.pnlOptions.TabIndex = 3;
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
            this.lblQuestionNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.lblQuestionNumber.Location = new System.Drawing.Point(41, 8);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(61, 22);
            this.lblQuestionNumber.TabIndex = 0;
            this.lblQuestionNumber.Text = "Câu 1/20";
            // 
            // ucTNItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTNItem";
            this.Size = new System.Drawing.Size(700, 350);
            this.pnlMain.ResumeLayout(false);
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
    }
}
