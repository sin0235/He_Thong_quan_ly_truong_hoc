namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucQuanLyHeThong
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvQuanLyHeThong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.NguoiHanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpLoc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblLocTheoNgay = new System.Windows.Forms.Label();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.panelSearch = new Guna.UI2.WinForms.Guna2Panel();
            this.panelDate = new Guna.UI2.WinForms.Guna2Panel();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblStatistic = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyHeThong)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuanLyHeThong
            // 
            this.dgvQuanLyHeThong.AllowUserToAddRows = false;
            this.dgvQuanLyHeThong.AllowUserToDeleteRows = false;
            this.dgvQuanLyHeThong.AllowUserToResizeRows = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyHeThong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvQuanLyHeThong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyHeThong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvQuanLyHeThong.ColumnHeadersHeight = 40;
            this.dgvQuanLyHeThong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvQuanLyHeThong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NguoiHanhDong,
            this.VaiTro,
            this.HanhDong,
            this.ThoiGian});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyHeThong.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgvQuanLyHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanLyHeThong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvQuanLyHeThong.Location = new System.Drawing.Point(20, 20);
            this.dgvQuanLyHeThong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvQuanLyHeThong.MultiSelect = false;
            this.dgvQuanLyHeThong.Name = "dgvQuanLyHeThong";
            this.dgvQuanLyHeThong.ReadOnly = true;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyHeThong.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvQuanLyHeThong.RowHeadersVisible = false;
            this.dgvQuanLyHeThong.RowHeadersWidth = 51;
            this.dgvQuanLyHeThong.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyHeThong.RowTemplate.Height = 30;
            this.dgvQuanLyHeThong.RowTemplate.ReadOnly = true;
            this.dgvQuanLyHeThong.Size = new System.Drawing.Size(1502, 584);
            this.dgvQuanLyHeThong.TabIndex = 1;
            this.dgvQuanLyHeThong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyHeThong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvQuanLyHeThong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvQuanLyHeThong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvQuanLyHeThong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvQuanLyHeThong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyHeThong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvQuanLyHeThong.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvQuanLyHeThong.ThemeStyle.ReadOnly = true;
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.Height = 30;
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuanLyHeThong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQuanLyHeThong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyHeThong_CellContentClick);
            // 
            // NguoiHanhDong
            // 
            this.NguoiHanhDong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NguoiHanhDong.DataPropertyName = "NguoiHanhDong";
            this.NguoiHanhDong.FillWeight = 20F;
            this.NguoiHanhDong.HeaderText = "Người hành động";
            this.NguoiHanhDong.MinimumWidth = 6;
            this.NguoiHanhDong.Name = "NguoiHanhDong";
            this.NguoiHanhDong.ReadOnly = true;
            // 
            // VaiTro
            // 
            this.VaiTro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VaiTro.DataPropertyName = "VaiTro";
            this.VaiTro.FillWeight = 15F;
            this.VaiTro.HeaderText = "Vai trò";
            this.VaiTro.MinimumWidth = 6;
            this.VaiTro.Name = "VaiTro";
            this.VaiTro.ReadOnly = true;
            // 
            // HanhDong
            // 
            this.HanhDong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HanhDong.DataPropertyName = "HanhDong";
            this.HanhDong.FillWeight = 40F;
            this.HanhDong.HeaderText = "Hành động";
            this.HanhDong.MinimumWidth = 6;
            this.HanhDong.Name = "HanhDong";
            this.HanhDong.ReadOnly = true;
            // 
            // ThoiGian
            // 
            this.ThoiGian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThoiGian.DataPropertyName = "ThoiGian";
            this.ThoiGian.FillWeight = 25F;
            this.ThoiGian.HeaderText = "Thời gian";
            this.ThoiGian.MinimumWidth = 6;
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            // 
            // dtpLoc
            // 
            this.dtpLoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dtpLoc.BorderRadius = 15;
            this.dtpLoc.BorderThickness = 1;
            this.dtpLoc.Checked = true;
            this.dtpLoc.FillColor = System.Drawing.Color.White;
            this.dtpLoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.dtpLoc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpLoc.Location = new System.Drawing.Point(207, 12);
            this.dtpLoc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLoc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLoc.Name = "dtpLoc";
            this.dtpLoc.Size = new System.Drawing.Size(250, 40);
            this.dtpLoc.TabIndex = 2;
            this.toolTip.SetToolTip(this.dtpLoc, "Chọn ngày để lọc nhật ký");
            this.dtpLoc.Value = new System.DateTime(2025, 5, 6, 19, 36, 0, 173);
            this.dtpLoc.ValueChanged += new System.EventHandler(this.DtpLoc_ValueChanged);
            // 
            // lblLocTheoNgay
            // 
            this.lblLocTheoNgay.AutoSize = true;
            this.lblLocTheoNgay.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocTheoNgay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLocTheoNgay.Location = new System.Drawing.Point(20, 22);
            this.lblLocTheoNgay.Name = "lblLocTheoNgay";
            this.lblLocTheoNgay.Size = new System.Drawing.Size(133, 19);
            this.lblLocTheoNgay.TabIndex = 5;
            this.lblLocTheoNgay.Text = "Lọc theo thời gian:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTimKiem.BorderRadius = 15;
            this.btnTimKiem.BorderThickness = 1;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Image = global::QuanLyTruongHoc.Properties.Resources.search;
            this.btnTimKiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTimKiem.ImageOffset = new System.Drawing.Point(3, 0);
            this.btnTimKiem.Location = new System.Drawing.Point(307, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(140, 40);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.BorderRadius = 15;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.IconLeft = global::QuanLyTruongHoc.Properties.Resources.search;
            this.txtTimKiem.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtTimKiem.Location = new System.Drawing.Point(20, 12);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm theo tên người thực hiện";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(282, 40);
            this.txtTimKiem.TabIndex = 10;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLamMoi.BorderRadius = 15;
            this.btnLamMoi.BorderThickness = 1;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.White;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Image = global::QuanLyTruongHoc.Properties.Resources.refresh;
            this.btnLamMoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLamMoi.ImageOffset = new System.Drawing.Point(3, 0);
            this.btnLamMoi.Location = new System.Drawing.Point(653, 35);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 40);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click_1);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.Controls.Add(this.txtTimKiem);
            this.panelSearch.Controls.Add(this.btnTimKiem);
            this.panelSearch.Location = new System.Drawing.Point(984, 23);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(472, 65);
            this.panelSearch.TabIndex = 13;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.picCalendar);
            this.panelDate.Controls.Add(this.dtpLoc);
            this.panelDate.Controls.Add(this.lblLocTheoNgay);
            this.panelDate.Location = new System.Drawing.Point(72, 23);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(484, 65);
            this.panelDate.TabIndex = 14;
            // 
            // picCalendar
            // 
            this.picCalendar.Image = global::QuanLyTruongHoc.Properties.Resources.calendar;
            this.picCalendar.Location = new System.Drawing.Point(181, 20);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(24, 24);
            this.picCalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCalendar.TabIndex = 0;
            this.picCalendar.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderColor = System.Drawing.Color.LightGray;
            this.panelMain.BorderRadius = 15;
            this.panelMain.BorderThickness = 1;
            this.panelMain.Controls.Add(this.dgvQuanLyHeThong);
            this.panelMain.Location = new System.Drawing.Point(3, 162);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1542, 624);
            this.panelMain.TabIndex = 15;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.Silver;
            this.guna2Separator1.Location = new System.Drawing.Point(23, 126);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1502, 10);
            this.guna2Separator1.TabIndex = 16;
            // 
            // lblStatistic
            // 
            this.lblStatistic.AutoSize = true;
            this.lblStatistic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistic.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStatistic.Location = new System.Drawing.Point(26, 104);
            this.lblStatistic.Name = "lblStatistic";
            this.lblStatistic.Size = new System.Drawing.Size(214, 19);
            this.lblStatistic.TabIndex = 17;
            this.lblStatistic.Text = "Tổng số: 0 hoạt động hệ thống";
            // 
            // ucQuanLyHeThong
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatistic);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "ucQuanLyHeThong";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1542, 759);
            this.Load += new System.EventHandler(this.ucQuanLyHeThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyHeThong)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuanLyHeThong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiHanhDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLoc;
        private System.Windows.Forms.Label lblLocTheoNgay;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Panel panelSearch;
        private Guna.UI2.WinForms.Guna2Panel panelDate;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblStatistic;

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox picCalendar;
    }
}
