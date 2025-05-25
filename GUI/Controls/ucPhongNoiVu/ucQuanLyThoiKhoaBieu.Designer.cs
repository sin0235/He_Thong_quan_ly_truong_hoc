namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    partial class ucQuanLyThoiKhoaBieu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLopVaNgay = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChonNgay = new System.Windows.Forms.Label();
            this.lblChonLop = new System.Windows.Forms.Label();
            this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbChonLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.panelDataGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThoiKhoaBieu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTuanHoc = new System.Windows.Forms.Label();
            this.panelLopVaNgay.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLopVaNgay
            // 
            this.panelLopVaNgay.BackColor = System.Drawing.Color.White;
            this.panelLopVaNgay.Controls.Add(this.lblChonNgay);
            this.panelLopVaNgay.Controls.Add(this.lblChonLop);
            this.panelLopVaNgay.Controls.Add(this.dtpNgay);
            this.panelLopVaNgay.Controls.Add(this.cmbChonLop);
            this.panelLopVaNgay.Location = new System.Drawing.Point(112, 30);
            this.panelLopVaNgay.Name = "panelLopVaNgay";
            this.panelLopVaNgay.Size = new System.Drawing.Size(600, 55);
            this.panelLopVaNgay.TabIndex = 3;
            // 
            // lblChonNgay
            // 
            this.lblChonNgay.AutoSize = true;
            this.lblChonNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChonNgay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblChonNgay.Location = new System.Drawing.Point(300, 19);
            this.lblChonNgay.Name = "lblChonNgay";
            this.lblChonNgay.Size = new System.Drawing.Size(84, 19);
            this.lblChonNgay.TabIndex = 7;
            this.lblChonNgay.Text = "Chọn ngày:";
            // 
            // lblChonLop
            // 
            this.lblChonLop.AutoSize = true;
            this.lblChonLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChonLop.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblChonLop.Location = new System.Drawing.Point(15, 19);
            this.lblChonLop.Name = "lblChonLop";
            this.lblChonLop.Size = new System.Drawing.Size(73, 19);
            this.lblChonLop.TabIndex = 6;
            this.lblChonLop.Text = "Chọn lớp:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Animated = true;
            this.dtpNgay.AutoRoundedCorners = true;
            this.dtpNgay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dtpNgay.BorderRadius = 17;
            this.dtpNgay.BorderThickness = 1;
            this.dtpNgay.Checked = true;
            this.dtpNgay.FillColor = System.Drawing.Color.White;
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgay.ForeColor = System.Drawing.Color.Black;
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgay.IndicateFocus = true;
            this.dtpNgay.Location = new System.Drawing.Point(385, 10);
            this.dtpNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 36);
            this.dtpNgay.TabIndex = 5;
            this.dtpNgay.Value = new System.DateTime(2025, 5, 3, 19, 51, 58, 495);
            this.dtpNgay.ValueChanged += new System.EventHandler(this.DtpNgay_ValueChanged);
            // 
            // cmbChonLop
            // 
            this.cmbChonLop.BackColor = System.Drawing.Color.Transparent;
            this.cmbChonLop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonLop.BorderRadius = 20;
            this.cmbChonLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChonLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChonLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonLop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChonLop.ForeColor = System.Drawing.Color.Black;
            this.cmbChonLop.ItemHeight = 30;
            this.cmbChonLop.Location = new System.Drawing.Point(94, 10);
            this.cmbChonLop.Name = "cmbChonLop";
            this.cmbChonLop.Size = new System.Drawing.Size(175, 36);
            this.cmbChonLop.TabIndex = 3;
            this.cmbChonLop.SelectedIndexChanged += new System.EventHandler(this.CmbChonLop_SelectedIndexChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnLamMoi);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Controls.Add(this.btnSua);
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Location = new System.Drawing.Point(901, 30);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(600, 55);
            this.panelButtons.TabIndex = 7;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLamMoi.BorderRadius = 20;
            this.btnLamMoi.BorderThickness = 1;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.White;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Image = global::QuanLyTruongHoc.Properties.Resources.refresh;
            this.btnLamMoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLamMoi.Location = new System.Drawing.Point(455, 10);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(135, 36);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Animated = true;
            this.btnXoa.AutoRoundedCorners = true;
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.BorderRadius = 17;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnXoa.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = global::QuanLyTruongHoc.Properties.Resources.delete;
            this.btnXoa.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXoa.IndicateFocus = true;
            this.btnXoa.Location = new System.Drawing.Point(310, 10);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(125, 36);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSua.BorderRadius = 20;
            this.btnSua.BorderThickness = 1;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Gold;
            this.btnSua.HoverState.BorderColor = System.Drawing.Color.Gold;
            this.btnSua.HoverState.FillColor = System.Drawing.Color.Gold;
            this.btnSua.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSua.Image = global::QuanLyTruongHoc.Properties.Resources.edit;
            this.btnSua.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSua.Location = new System.Drawing.Point(165, 10);
            this.btnSua.Margin = new System.Windows.Forms.Padding(10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(125, 36);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThem.BorderRadius = 20;
            this.btnThem.BorderThickness = 1;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThem.HoverState.BorderColor = System.Drawing.Color.Lime;
            this.btnThem.HoverState.FillColor = System.Drawing.Color.Lime;
            this.btnThem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = global::QuanLyTruongHoc.Properties.Resources.add;
            this.btnThem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 36);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(21, 91);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1600, 10);
            this.guna2Separator1.TabIndex = 8;
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDataGrid.BackColor = System.Drawing.Color.White;
            this.panelDataGrid.BorderColor = System.Drawing.Color.LightGray;
            this.panelDataGrid.BorderRadius = 15;
            this.panelDataGrid.BorderThickness = 1;
            this.panelDataGrid.Controls.Add(this.dgvThoiKhoaBieu);
            this.panelDataGrid.Location = new System.Drawing.Point(21, 141);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Padding = new System.Windows.Forms.Padding(20);
            this.panelDataGrid.Size = new System.Drawing.Size(1600, 750);
            this.panelDataGrid.TabIndex = 9;
            // 
            // dgvThoiKhoaBieu
            // 
            this.dgvThoiKhoaBieu.AllowUserToAddRows = false;
            this.dgvThoiKhoaBieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThoiKhoaBieu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvThoiKhoaBieu.ColumnHeadersHeight = 60;
            this.dgvThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThu2,
            this.colThu3,
            this.colThu4,
            this.colThu5,
            this.colThu6,
            this.colThu7,
            this.colChuNhat});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThoiKhoaBieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(20, 20);
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.ReadOnly = true;
            this.dgvThoiKhoaBieu.RowHeadersVisible = false;
            this.dgvThoiKhoaBieu.RowHeadersWidth = 51;
            this.dgvThoiKhoaBieu.RowTemplate.Height = 40;
            this.dgvThoiKhoaBieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(1560, 710);
            this.dgvThoiKhoaBieu.TabIndex = 8;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvThoiKhoaBieu.ThemeStyle.ReadOnly = true;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Height = 40;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThoiKhoaBieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThoiKhoaBieu_CellClick);
            // 
            // colThu2
            // 
            this.colThu2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu2.HeaderText = "Thứ 2";
            this.colThu2.MinimumWidth = 6;
            this.colThu2.Name = "colThu2";
            this.colThu2.ReadOnly = true;
            // 
            // colThu3
            // 
            this.colThu3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu3.HeaderText = "Thứ 3";
            this.colThu3.MinimumWidth = 6;
            this.colThu3.Name = "colThu3";
            this.colThu3.ReadOnly = true;
            // 
            // colThu4
            // 
            this.colThu4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu4.HeaderText = "Thứ 4";
            this.colThu4.MinimumWidth = 6;
            this.colThu4.Name = "colThu4";
            this.colThu4.ReadOnly = true;
            // 
            // colThu5
            // 
            this.colThu5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu5.HeaderText = "Thứ 5";
            this.colThu5.MinimumWidth = 6;
            this.colThu5.Name = "colThu5";
            this.colThu5.ReadOnly = true;
            // 
            // colThu6
            // 
            this.colThu6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu6.HeaderText = "Thứ 6";
            this.colThu6.MinimumWidth = 6;
            this.colThu6.Name = "colThu6";
            this.colThu6.ReadOnly = true;
            // 
            // colThu7
            // 
            this.colThu7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThu7.HeaderText = "Thứ 7";
            this.colThu7.MinimumWidth = 6;
            this.colThu7.Name = "colThu7";
            this.colThu7.ReadOnly = true;
            // 
            // colChuNhat
            // 
            this.colChuNhat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChuNhat.HeaderText = "Chủ nhật";
            this.colChuNhat.MinimumWidth = 6;
            this.colChuNhat.Name = "colChuNhat";
            this.colChuNhat.ReadOnly = true;
            // 
            // lblTuanHoc
            // 
            this.lblTuanHoc.AutoSize = true;
            this.lblTuanHoc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuanHoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTuanHoc.Location = new System.Drawing.Point(21, 116);
            this.lblTuanHoc.Name = "lblTuanHoc";
            this.lblTuanHoc.Size = new System.Drawing.Size(272, 20);
            this.lblTuanHoc.TabIndex = 10;
            this.lblTuanHoc.Text = "THỜI KHÓA BIỂU TUẦN: 01/05/2025";
            // 
            // ucQuanLyThoiKhoaBieu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTuanHoc);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelLopVaNgay);
            this.Name = "ucQuanLyThoiKhoaBieu";
            this.Size = new System.Drawing.Size(1640, 960);
            this.Load += new System.EventHandler(this.ucQuanLyThoiKhoaBieu_Load);
            this.panelLopVaNgay.ResumeLayout(false);
            this.panelLopVaNgay.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelLopVaNgay;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChonLop;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Panel panelButtons;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThoiKhoaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuNhat;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel panelDataGrid;
        private System.Windows.Forms.Label lblChonLop;
        private System.Windows.Forms.Label lblChonNgay;
        private System.Windows.Forms.Label lblTuanHoc;
    }
}
