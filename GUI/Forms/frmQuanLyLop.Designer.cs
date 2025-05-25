namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmQuanLyLop
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyLop));
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGVChuNhiem = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLop = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.cbGiaoVienChuNhiem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtLop = new Guna.UI2.WinForms.Guna2TextBox();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.ucControlBar1 = new QuanLyTruongHoc.GUI.Controls.ucControlBar();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.ucControlBar1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 560);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlContent.BorderRadius = 15;
            this.pnlContent.BorderThickness = 1;
            this.pnlContent.Controls.Add(this.lblGVChuNhiem);
            this.pnlContent.Controls.Add(this.lblLop);
            this.pnlContent.Controls.Add(this.btnXacNhan);
            this.pnlContent.Controls.Add(this.cbGiaoVienChuNhiem);
            this.pnlContent.Controls.Add(this.txtLop);
            this.pnlContent.Controls.Add(this.picAvatar);
            this.pnlContent.FillColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(20, 140);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.ShadowDecoration.BorderRadius = 15;
            this.pnlContent.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlContent.ShadowDecoration.Depth = 10;
            this.pnlContent.ShadowDecoration.Enabled = true;
            this.pnlContent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4, 4, 8, 8);
            this.pnlContent.Size = new System.Drawing.Size(560, 400);
            this.pnlContent.TabIndex = 20;
            // 
            // lblGVChuNhiem
            // 
            this.lblGVChuNhiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGVChuNhiem.BackColor = System.Drawing.Color.Transparent;
            this.lblGVChuNhiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGVChuNhiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.lblGVChuNhiem.Location = new System.Drawing.Point(76, 234);
            this.lblGVChuNhiem.Margin = new System.Windows.Forms.Padding(2);
            this.lblGVChuNhiem.Name = "lblGVChuNhiem";
            this.lblGVChuNhiem.Size = new System.Drawing.Size(207, 23);
            this.lblGVChuNhiem.TabIndex = 18;
            this.lblGVChuNhiem.Text = "Chọn giáo viên chủ nhiệm:";
            // 
            // lblLop
            // 
            this.lblLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLop.BackColor = System.Drawing.Color.Transparent;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.lblLop.Location = new System.Drawing.Point(76, 166);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(78, 23);
            this.lblLop.TabIndex = 17;
            this.lblLop.Text = "Nhập lớp:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXacNhan.BorderRadius = 15;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(120)))), ((int)(((byte)(225)))));
            this.btnXacNhan.Location = new System.Drawing.Point(210, 310);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(170, 50);
            this.btnXacNhan.TabIndex = 16;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cbGiaoVienChuNhiem
            // 
            this.cbGiaoVienChuNhiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbGiaoVienChuNhiem.BackColor = System.Drawing.Color.Transparent;
            this.cbGiaoVienChuNhiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbGiaoVienChuNhiem.BorderRadius = 15;
            this.cbGiaoVienChuNhiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGiaoVienChuNhiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGiaoVienChuNhiem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiaoVienChuNhiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiaoVienChuNhiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGiaoVienChuNhiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbGiaoVienChuNhiem.ItemHeight = 30;
            this.cbGiaoVienChuNhiem.Location = new System.Drawing.Point(290, 230);
            this.cbGiaoVienChuNhiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbGiaoVienChuNhiem.Name = "cbGiaoVienChuNhiem";
            this.cbGiaoVienChuNhiem.Size = new System.Drawing.Size(212, 36);
            this.cbGiaoVienChuNhiem.TabIndex = 15;
            // 
            // txtLop
            // 
            this.txtLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtLop.BorderRadius = 15;
            this.txtLop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLop.DefaultText = "";
            this.txtLop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLop.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtLop.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLop.Location = new System.Drawing.Point(290, 162);
            this.txtLop.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtLop.Name = "txtLop";
            this.txtLop.Padding = new System.Windows.Forms.Padding(6);
            this.txtLop.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLop.PlaceholderText = "Nhập tên lớp...";
            this.txtLop.SelectedText = "";
            this.txtLop.Size = new System.Drawing.Size(212, 36);
            this.txtLop.TabIndex = 14;
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.picAvatar.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Teacher_Male;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(230, 40);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 13;
            this.picAvatar.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.guna2Separator1);
            this.pnlHeader.Location = new System.Drawing.Point(20, 50);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 80);
            this.pnlHeader.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "QUẢN LÝ LỚP";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.guna2Separator1.Location = new System.Drawing.Point(3, 50);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(554, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // ucControlBar1
            // 
            this.ucControlBar1.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucControlBar1.Location = new System.Drawing.Point(0, 0);
            this.ucControlBar1.Name = "ucControlBar1";
            this.ucControlBar1.Size = new System.Drawing.Size(600, 40);
            this.ucControlBar1.TabIndex = 19;
            this.ucControlBar1.TitleText = "Quản lý lớp";
            this.ucControlBar1.Load += new System.EventHandler(this.ucControlBar1_Load);
            // 
            // frmQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(600, 560);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLyLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lớp";
            this.Load += new System.EventHandler(this.frmQuanLyLop_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2TextBox txtLop;
        private Guna.UI2.WinForms.Guna2ComboBox cbGiaoVienChuNhiem;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGVChuNhiem;
        private Controls.ucControlBar ucControlBar1;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
    }
}
