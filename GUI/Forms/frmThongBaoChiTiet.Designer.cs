namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmThongBaoChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBaoChiTiet));
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.ndThongBaoTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblThoiGianGui = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoiGui = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.avatarPTB = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.ucControlBar = new QuanLyTruongHoc.GUI.Controls.ucControlBar();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPTB)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlMain.BorderRadius = 20;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.ucControlBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlMain.Size = new System.Drawing.Size(1339, 706);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlContent.BorderRadius = 16;
            this.pnlContent.BorderThickness = 1;
            this.pnlContent.Controls.Add(this.ndThongBaoTxt);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(13, 246);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlContent.ShadowDecoration.BorderRadius = 16;
            this.pnlContent.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlContent.ShadowDecoration.Depth = 8;
            this.pnlContent.ShadowDecoration.Enabled = true;
            this.pnlContent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 6);
            this.pnlContent.Size = new System.Drawing.Size(1313, 386);
            this.pnlContent.TabIndex = 4;
            // 
            // ndThongBaoTxt
            // 
            this.ndThongBaoTxt.BackColor = System.Drawing.Color.Transparent;
            this.ndThongBaoTxt.BorderColor = System.Drawing.Color.Transparent;
            this.ndThongBaoTxt.BorderRadius = 10;
            this.ndThongBaoTxt.BorderThickness = 0;
            this.ndThongBaoTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ndThongBaoTxt.DefaultText = "";
            this.ndThongBaoTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ndThongBaoTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ndThongBaoTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ndThongBaoTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ndThongBaoTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ndThongBaoTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ndThongBaoTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ndThongBaoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ndThongBaoTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ndThongBaoTxt.Location = new System.Drawing.Point(20, 18);
            this.ndThongBaoTxt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ndThongBaoTxt.Multiline = true;
            this.ndThongBaoTxt.Name = "ndThongBaoTxt";
            this.ndThongBaoTxt.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.ndThongBaoTxt.PlaceholderText = "";
            this.ndThongBaoTxt.ReadOnly = true;
            this.ndThongBaoTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ndThongBaoTxt.SelectedText = "";
            this.ndThongBaoTxt.Size = new System.Drawing.Size(1273, 350);
            this.ndThongBaoTxt.TabIndex = 5;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(13, 632);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1313, 62);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BorderRadius = 10;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1113, 6);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(187, 49);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlHeader.BorderRadius = 16;
            this.pnlHeader.BorderThickness = 1;
            this.pnlHeader.Controls.Add(this.lblThoiGianGui);
            this.pnlHeader.Controls.Add(this.lblNguoiGui);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.avatarPTB);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.pnlHeader.Location = new System.Drawing.Point(13, 61);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlHeader.ShadowDecoration.BorderRadius = 16;
            this.pnlHeader.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlHeader.ShadowDecoration.Depth = 8;
            this.pnlHeader.ShadowDecoration.Enabled = true;
            this.pnlHeader.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 6);
            this.pnlHeader.Size = new System.Drawing.Size(1313, 185);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblThoiGianGui
            // 
            this.lblThoiGianGui.BackColor = System.Drawing.Color.Transparent;
            this.lblThoiGianGui.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblThoiGianGui.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblThoiGianGui.Location = new System.Drawing.Point(849, 102);
            this.lblThoiGianGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblThoiGianGui.Name = "lblThoiGianGui";
            this.lblThoiGianGui.Size = new System.Drawing.Size(123, 39);
            this.lblThoiGianGui.TabIndex = 6;
            this.lblThoiGianGui.Text = "Thời gian";
            // 
            // lblNguoiGui
            // 
            this.lblNguoiGui.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiGui.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblNguoiGui.ForeColor = System.Drawing.Color.Coral;
            this.lblNguoiGui.Location = new System.Drawing.Point(301, 102);
            this.lblNguoiGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblNguoiGui.Name = "lblNguoiGui";
            this.lblNguoiGui.Size = new System.Drawing.Size(192, 39);
            this.lblNguoiGui.TabIndex = 4;
            this.lblNguoiGui.Text = "Ban Giám Hiệu";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(301, 34);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(100, 39);
            this.lblTieuDe.TabIndex = 8;
            this.lblTieuDe.Text = "Tiêu Đề";
            // 
            // avatarPTB
            // 
            this.avatarPTB.BackColor = System.Drawing.Color.Transparent;
            this.avatarPTB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.avatarPTB.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Teacher_Male;
            this.avatarPTB.ImageRotate = 0F;
            this.avatarPTB.Location = new System.Drawing.Point(97, 52);
            this.avatarPTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.avatarPTB.Name = "avatarPTB";
            this.avatarPTB.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.avatarPTB.Size = new System.Drawing.Size(133, 123);
            this.avatarPTB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPTB.TabIndex = 0;
            this.avatarPTB.TabStop = false;
            // 
            // ucControlBar
            // 
            this.ucControlBar.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucControlBar.Location = new System.Drawing.Point(13, 12);
            this.ucControlBar.Margin = new System.Windows.Forms.Padding(4);
            this.ucControlBar.Name = "ucControlBar";
            this.ucControlBar.Size = new System.Drawing.Size(1313, 49);
            this.ucControlBar.TabIndex = 1;
            this.ucControlBar.TitleText = "Chi Tiết Thông Báo";
            // 
            // frmThongBaoChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 706);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmThongBaoChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết";
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPTB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Controls.ucControlBar ucControlBar;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2CirclePictureBox avatarPTB;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguoiGui;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThoiGianGui;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2TextBox ndThongBaoTxt;
    }
}
