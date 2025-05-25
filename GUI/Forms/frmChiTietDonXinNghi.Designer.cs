namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmChiTietDonXinNghi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietDonXinNghi));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblNgayTao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblThoiGianNghi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTrangThai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoiDuyet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoiDungTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhanHoiTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPhanHoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlDinhKem = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDinhKemTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpDinhKem = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDinhKem.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BorderColor = System.Drawing.Color.Black;
            this.pnlHeader.BorderThickness = 1;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Controls.Add(this.guna2CircleButtonClose);
            this.pnlHeader.Controls.Add(this.guna2CircleButtonMinimize);
            this.pnlHeader.Controls.Add(this.lblNgayTao);
            this.pnlHeader.Controls.Add(this.lblThoiGianNghi);
            this.pnlHeader.Controls.Add(this.lblTrangThai);
            this.pnlHeader.Controls.Add(this.lblNguoiDuyet);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(165)))), ((int)(((byte)(230)))));
            this.pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeader.Size = new System.Drawing.Size(669, 147);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 36);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(132, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Đơn xin nghỉ";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(12, 8);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(179, 27);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Chi tiết đơn xin nghỉ";
            // 
            // guna2CircleButtonClose
            // 
            this.guna2CircleButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonClose.BorderThickness = 1;
            this.guna2CircleButtonClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.guna2CircleButtonClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonClose.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonClose.Location = new System.Drawing.Point(631, 12);
            this.guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            this.guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonClose.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonClose.TabIndex = 3;
            this.guna2CircleButtonClose.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // guna2CircleButtonMinimize
            // 
            this.guna2CircleButtonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonMinimize.BorderThickness = 1;
            this.guna2CircleButtonMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.guna2CircleButtonMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonMinimize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMinimize.Location = new System.Drawing.Point(605, 12);
            this.guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            this.guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonMinimize.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonMinimize.TabIndex = 2;
            this.guna2CircleButtonMinimize.Click += new System.EventHandler(this.guna2CircleButtonMinimize_Click);
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayTao.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.ForeColor = System.Drawing.Color.White;
            this.lblNgayTao.Location = new System.Drawing.Point(18, 72);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(147, 22);
            this.lblNgayTao.TabIndex = 1;
            this.lblNgayTao.Text = "Ngày tạo: 23/04/2023";
            // 
            // lblThoiGianNghi
            // 
            this.lblThoiGianNghi.BackColor = System.Drawing.Color.Transparent;
            this.lblThoiGianNghi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianNghi.ForeColor = System.Drawing.Color.White;
            this.lblThoiGianNghi.Location = new System.Drawing.Point(18, 96);
            this.lblThoiGianNghi.Name = "lblThoiGianNghi";
            this.lblThoiGianNghi.Size = new System.Drawing.Size(271, 22);
            this.lblThoiGianNghi.TabIndex = 2;
            this.lblThoiGianNghi.Text = "Thời gian nghỉ: 24/04/2023 - 25/04/2023";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.lblTrangThai.Location = new System.Drawing.Point(400, 72);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(149, 22);
            this.lblTrangThai.TabIndex = 3;
            this.lblTrangThai.Text = "Trạng thái: Đang chờ";
            // 
            // lblNguoiDuyet
            // 
            this.lblNguoiDuyet.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDuyet.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDuyet.Location = new System.Drawing.Point(400, 96);
            this.lblNguoiDuyet.Name = "lblNguoiDuyet";
            this.lblNguoiDuyet.Size = new System.Drawing.Size(187, 22);
            this.lblNguoiDuyet.TabIndex = 4;
            this.lblNguoiDuyet.Text = "Người duyệt: Nguyễn Văn A";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.pnlContent.BorderColor = System.Drawing.Color.Black;
            this.pnlContent.BorderRadius = 5;
            this.pnlContent.BorderThickness = 1;
            this.pnlContent.Controls.Add(this.lblNoiDungTitle);
            this.pnlContent.Controls.Add(this.txtNoiDung);
            this.pnlContent.Controls.Add(this.lblPhanHoiTitle);
            this.pnlContent.Controls.Add(this.txtPhanHoi);
            this.pnlContent.Controls.Add(this.pnlDinhKem);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 147);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.ShadowDecoration.BorderRadius = 5;
            this.pnlContent.Size = new System.Drawing.Size(669, 476);
            this.pnlContent.TabIndex = 1;
            // 
            // lblNoiDungTitle
            // 
            this.lblNoiDungTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNoiDungTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoiDungTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblNoiDungTitle.Location = new System.Drawing.Point(20, 20);
            this.lblNoiDungTitle.Name = "lblNoiDungTitle";
            this.lblNoiDungTitle.Size = new System.Drawing.Size(75, 23);
            this.lblNoiDungTitle.TabIndex = 1;
            this.lblNoiDungTitle.Text = "Nội dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtNoiDung.BorderRadius = 8;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtNoiDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNoiDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNoiDung.Location = new System.Drawing.Point(20, 45);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PlaceholderText = "";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.Size = new System.Drawing.Size(560, 120);
            this.txtNoiDung.TabIndex = 2;
            // 
            // lblPhanHoiTitle
            // 
            this.lblPhanHoiTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPhanHoiTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhanHoiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblPhanHoiTitle.Location = new System.Drawing.Point(20, 175);
            this.lblPhanHoiTitle.Name = "lblPhanHoiTitle";
            this.lblPhanHoiTitle.Size = new System.Drawing.Size(69, 23);
            this.lblPhanHoiTitle.TabIndex = 3;
            this.lblPhanHoiTitle.Text = "Phản hồi:";
            // 
            // txtPhanHoi
            // 
            this.txtPhanHoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtPhanHoi.BorderRadius = 8;
            this.txtPhanHoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhanHoi.DefaultText = "";
            this.txtPhanHoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhanHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtPhanHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtPhanHoi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhanHoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtPhanHoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhanHoi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhanHoi.Location = new System.Drawing.Point(20, 200);
            this.txtPhanHoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhanHoi.Multiline = true;
            this.txtPhanHoi.Name = "txtPhanHoi";
            this.txtPhanHoi.PlaceholderText = "";
            this.txtPhanHoi.ReadOnly = true;
            this.txtPhanHoi.SelectedText = "";
            this.txtPhanHoi.Size = new System.Drawing.Size(560, 70);
            this.txtPhanHoi.TabIndex = 4;
            // 
            // pnlDinhKem
            // 
            this.pnlDinhKem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.pnlDinhKem.BorderRadius = 8;
            this.pnlDinhKem.BorderThickness = 1;
            this.pnlDinhKem.Controls.Add(this.lblDinhKemTitle);
            this.pnlDinhKem.Controls.Add(this.flpDinhKem);
            this.pnlDinhKem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlDinhKem.Location = new System.Drawing.Point(20, 280);
            this.pnlDinhKem.Name = "pnlDinhKem";
            this.pnlDinhKem.Size = new System.Drawing.Size(560, 120);
            this.pnlDinhKem.TabIndex = 5;
            this.pnlDinhKem.Visible = false;
            // 
            // lblDinhKemTitle
            // 
            this.lblDinhKemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDinhKemTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDinhKemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblDinhKemTitle.Location = new System.Drawing.Point(10, 5);
            this.lblDinhKemTitle.Name = "lblDinhKemTitle";
            this.lblDinhKemTitle.Size = new System.Drawing.Size(106, 23);
            this.lblDinhKemTitle.TabIndex = 0;
            this.lblDinhKemTitle.Text = "Tệp đính kèm:";
            // 
            // flpDinhKem
            // 
            this.flpDinhKem.AutoScroll = true;
            this.flpDinhKem.BackColor = System.Drawing.Color.Transparent;
            this.flpDinhKem.Location = new System.Drawing.Point(3, 27);
            this.flpDinhKem.Name = "flpDinhKem";
            this.flpDinhKem.Size = new System.Drawing.Size(554, 90);
            this.flpDinhKem.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderColor = System.Drawing.Color.Black;
            this.pnlBottom.BorderThickness = 1;
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.pnlBottom.Location = new System.Drawing.Point(0, 623);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(669, 60);
            this.pnlBottom.TabIndex = 6;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BorderRadius = 8;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(549, 15);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChiTietDonXinNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(669, 683);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChiTietDonXinNghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đơn xin nghỉ";
            this.Load += new System.EventHandler(this.frmChiTietDonXinNghi_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlDinhKem.ResumeLayout(false);
            this.pnlDinhKem.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgayTao;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThoiGianNghi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTrangThai;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguoiDuyet;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoiDungTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPhanHoiTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtPhanHoi;
        private Guna.UI2.WinForms.Guna2Panel pnlDinhKem;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDinhKemTitle;
        private System.Windows.Forms.FlowLayoutPanel flpDinhKem;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}