namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmQuanLyThoiKhoaBieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyThoiKhoaBieu));
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.cmbMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbGiaoVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpNgayHoc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTietHoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.ucControlBar1 = new QuanLyTruongHoc.GUI.Controls.ucControlBar();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXacNhan.BorderRadius = 12;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(90)))), ((int)(((byte)(195)))));
            this.btnXacNhan.Location = new System.Drawing.Point(243, 434);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(170, 51);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.cmbMonHoc.BorderRadius = 8;
            this.cmbMonHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMonHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMonHoc.ItemHeight = 30;
            this.cmbMonHoc.Location = new System.Drawing.Point(338, 191);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(220, 36);
            this.cmbMonHoc.TabIndex = 9;
            this.cmbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cmbMonHoc_SelectedIndexChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(133, 194);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(118, 23);
            this.guna2HtmlLabel1.TabIndex = 10;
            this.guna2HtmlLabel1.Text = "Chọn môn học:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(133, 254);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(122, 23);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "Chọn giáo viên:";
            // 
            // cmbGiaoVien
            // 
            this.cmbGiaoVien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGiaoVien.BackColor = System.Drawing.Color.Transparent;
            this.cmbGiaoVien.BorderRadius = 8;
            this.cmbGiaoVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiaoVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGiaoVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGiaoVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGiaoVien.ItemHeight = 30;
            this.cmbGiaoVien.Location = new System.Drawing.Point(338, 251);
            this.cmbGiaoVien.Name = "cmbGiaoVien";
            this.cmbGiaoVien.Size = new System.Drawing.Size(220, 36);
            this.cmbGiaoVien.TabIndex = 12;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(133, 314);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(121, 23);
            this.guna2HtmlLabel3.TabIndex = 13;
            this.guna2HtmlLabel3.Text = "Chọn ngày học:";
            // 
            // dtpNgayHoc
            // 
            this.dtpNgayHoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpNgayHoc.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpNgayHoc.BorderRadius = 8;
            this.dtpNgayHoc.Checked = true;
            this.dtpNgayHoc.FillColor = System.Drawing.Color.White;
            this.dtpNgayHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayHoc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayHoc.Location = new System.Drawing.Point(338, 311);
            this.dtpNgayHoc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayHoc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayHoc.Name = "dtpNgayHoc";
            this.dtpNgayHoc.Size = new System.Drawing.Size(220, 36);
            this.dtpNgayHoc.TabIndex = 14;
            this.dtpNgayHoc.Value = new System.DateTime(2025, 5, 3, 20, 34, 12, 641);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(133, 374);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(111, 23);
            this.guna2HtmlLabel4.TabIndex = 15;
            this.guna2HtmlLabel4.Text = "Nhập tiết học:";
            // 
            // txtTietHoc
            // 
            this.txtTietHoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTietHoc.BackColor = System.Drawing.Color.Transparent;
            this.txtTietHoc.BorderRadius = 8;
            this.txtTietHoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTietHoc.DefaultText = "";
            this.txtTietHoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTietHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTietHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTietHoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTietHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTietHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTietHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTietHoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTietHoc.Location = new System.Drawing.Point(338, 371);
            this.txtTietHoc.Name = "txtTietHoc";
            this.txtTietHoc.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.txtTietHoc.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTietHoc.PlaceholderText = "Ví dụ: 1,2,3";
            this.txtTietHoc.SelectedText = "";
            this.txtTietHoc.Size = new System.Drawing.Size(220, 36);
            this.txtTietHoc.TabIndex = 16;
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.picAvatar.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Teacher_Male;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(298, 75);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(96, 88);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 8;
            this.picAvatar.TabStop = false;
            // 
            // ucControlBar1
            // 
            this.ucControlBar1.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucControlBar1.Location = new System.Drawing.Point(0, 0);
            this.ucControlBar1.Name = "ucControlBar1";
            this.ucControlBar1.Size = new System.Drawing.Size(720, 40);
            this.ucControlBar1.TabIndex = 17;
            this.ucControlBar1.TitleText = "Quản lý thời khóa biểu";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlContainer.BorderRadius = 16;
            this.pnlContainer.BorderThickness = 1;
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.picAvatar);
            this.pnlContainer.Controls.Add(this.btnXacNhan);
            this.pnlContainer.Controls.Add(this.guna2HtmlLabel1);
            this.pnlContainer.Controls.Add(this.txtTietHoc);
            this.pnlContainer.Controls.Add(this.cmbMonHoc);
            this.pnlContainer.Controls.Add(this.guna2HtmlLabel4);
            this.pnlContainer.Controls.Add(this.guna2HtmlLabel2);
            this.pnlContainer.Controls.Add(this.dtpNgayHoc);
            this.pnlContainer.Controls.Add(this.cmbGiaoVien);
            this.pnlContainer.Controls.Add(this.guna2HtmlLabel3);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(15, 50);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContainer.ShadowDecoration.BorderRadius = 16;
            this.pnlContainer.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pnlContainer.ShadowDecoration.Depth = 10;
            this.pnlContainer.ShadowDecoration.Enabled = true;
            this.pnlContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 3, 5, 8);
            this.pnlContainer.Size = new System.Drawing.Size(690, 493);
            this.pnlContainer.TabIndex = 18;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.lblTitle.Location = new System.Drawing.Point(197, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 34);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "THIẾT LẬP LỊCH HỌC MỚI";
            // 
            // frmQuanLyThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(720, 558);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.ucControlBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuanLyThoiKhoaBieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thời khóa biểu";
            this.Load += new System.EventHandler(this.frmQuanLyThoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMonHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGiaoVien;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox txtTietHoc;
        private Controls.ucControlBar ucControlBar1;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

    }
}