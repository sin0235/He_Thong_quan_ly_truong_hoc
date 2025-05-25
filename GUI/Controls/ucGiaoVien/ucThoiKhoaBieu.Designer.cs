namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    partial class ucThoiKhoaBieu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvThoiKhoaBieu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.thuHaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuBaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuTuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuNamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuSauColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thuBayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chuNhatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.ngayChonDTP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.thongKeSoTietTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lamMoiBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThoiKhoaBieu
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvThoiKhoaBieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThoiKhoaBieu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThoiKhoaBieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThoiKhoaBieu.ColumnHeadersHeight = 36;
            this.dgvThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thuHaiColumn,
            this.thuBaColumn,
            this.thuTuColumn,
            this.thuNamColumn,
            this.thuSauColumn,
            this.thuBayColumn,
            this.chuNhatColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThoiKhoaBieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(26, 217);
            this.dgvThoiKhoaBieu.MultiSelect = false;
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.ReadOnly = true;
            this.dgvThoiKhoaBieu.RowHeadersVisible = false;
            this.dgvThoiKhoaBieu.RowHeadersWidth = 51;
            this.dgvThoiKhoaBieu.RowTemplate.Height = 24;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(1518, 688);
            this.dgvThoiKhoaBieu.TabIndex = 0;
            this.dgvThoiKhoaBieu.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvThoiKhoaBieu.ThemeStyle.ReadOnly = true;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // thuHaiColumn
            // 
            this.thuHaiColumn.HeaderText = "Thứ Hai";
            this.thuHaiColumn.MinimumWidth = 6;
            this.thuHaiColumn.Name = "thuHaiColumn";
            this.thuHaiColumn.ReadOnly = true;
            // 
            // thuBaColumn
            // 
            this.thuBaColumn.HeaderText = "Thứ Ba";
            this.thuBaColumn.MinimumWidth = 6;
            this.thuBaColumn.Name = "thuBaColumn";
            this.thuBaColumn.ReadOnly = true;
            // 
            // thuTuColumn
            // 
            this.thuTuColumn.HeaderText = "Thứ Tư";
            this.thuTuColumn.MinimumWidth = 6;
            this.thuTuColumn.Name = "thuTuColumn";
            this.thuTuColumn.ReadOnly = true;
            // 
            // thuNamColumn
            // 
            this.thuNamColumn.HeaderText = "Thứ Năm";
            this.thuNamColumn.MinimumWidth = 6;
            this.thuNamColumn.Name = "thuNamColumn";
            this.thuNamColumn.ReadOnly = true;
            // 
            // thuSauColumn
            // 
            this.thuSauColumn.HeaderText = "Thứ Sáu";
            this.thuSauColumn.MinimumWidth = 6;
            this.thuSauColumn.Name = "thuSauColumn";
            this.thuSauColumn.ReadOnly = true;
            // 
            // thuBayColumn
            // 
            this.thuBayColumn.HeaderText = "Thứ Bảy";
            this.thuBayColumn.MinimumWidth = 6;
            this.thuBayColumn.Name = "thuBayColumn";
            this.thuBayColumn.ReadOnly = true;
            // 
            // chuNhatColumn
            // 
            this.chuNhatColumn.HeaderText = "Chủ Nhật";
            this.chuNhatColumn.MinimumWidth = 6;
            this.chuNhatColumn.Name = "chuNhatColumn";
            this.chuNhatColumn.ReadOnly = true;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 10;
            this.guna2CustomGradientPanel1.Controls.Add(this.ngayChonDTP);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(26, 38);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(403, 70);
            this.guna2CustomGradientPanel1.TabIndex = 16;
            // 
            // ngayChonDTP
            // 
            this.ngayChonDTP.BorderRadius = 10;
            this.ngayChonDTP.Checked = true;
            this.ngayChonDTP.FillColor = System.Drawing.Color.White;
            this.ngayChonDTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayChonDTP.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ngayChonDTP.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.ngayChonDTP.Location = new System.Drawing.Point(103, 16);
            this.ngayChonDTP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngayChonDTP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngayChonDTP.Name = "ngayChonDTP";
            this.ngayChonDTP.Size = new System.Drawing.Size(281, 39);
            this.ngayChonDTP.TabIndex = 11;
            this.ngayChonDTP.Value = new System.DateTime(2025, 4, 28, 19, 32, 54, 569);
            this.ngayChonDTP.ValueChanged += new System.EventHandler(this.ngayChonDTP_ValueChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 16);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(58, 32);
            this.guna2HtmlLabel1.TabIndex = 6;
            this.guna2HtmlLabel1.Text = "Ngày";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderRadius = 10;
            this.guna2CustomGradientPanel2.Controls.Add(this.thongKeSoTietTxt);
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2HtmlLabel4);
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(695, 38);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(849, 140);
            this.guna2CustomGradientPanel2.TabIndex = 22;
            // 
            // thongKeSoTietTxt
            // 
            this.thongKeSoTietTxt.BackColor = System.Drawing.Color.Transparent;
            this.thongKeSoTietTxt.BorderRadius = 10;
            this.thongKeSoTietTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.thongKeSoTietTxt.DefaultText = "";
            this.thongKeSoTietTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.thongKeSoTietTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.thongKeSoTietTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.thongKeSoTietTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.thongKeSoTietTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.thongKeSoTietTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongKeSoTietTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.thongKeSoTietTxt.Location = new System.Drawing.Point(22, 40);
            this.thongKeSoTietTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thongKeSoTietTxt.Name = "thongKeSoTietTxt";
            this.thongKeSoTietTxt.PlaceholderText = "12 Tiết Toán";
            this.thongKeSoTietTxt.SelectedText = "";
            this.thongKeSoTietTxt.Size = new System.Drawing.Size(807, 87);
            this.thongKeSoTietTxt.TabIndex = 7;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(3, 3);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(127, 32);
            this.guna2HtmlLabel4.TabIndex = 6;
            this.guna2HtmlLabel4.Text = "Tuần này có";
            // 
            // lamMoiBtn
            // 
            this.lamMoiBtn.BackColor = System.Drawing.Color.Transparent;
            this.lamMoiBtn.BorderRadius = 10;
            this.lamMoiBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lamMoiBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lamMoiBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.lamMoiBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamMoiBtn.ForeColor = System.Drawing.Color.White;
            this.lamMoiBtn.HoverState.FillColor = System.Drawing.Color.LightSteelBlue;
            this.lamMoiBtn.Location = new System.Drawing.Point(26, 133);
            this.lamMoiBtn.Name = "lamMoiBtn";
            this.lamMoiBtn.Size = new System.Drawing.Size(180, 45);
            this.lamMoiBtn.TabIndex = 31;
            this.lamMoiBtn.Text = "Làm Mới";
            this.lamMoiBtn.Click += new System.EventHandler(this.lamMoiBtn_Click);
            // 
            // ucThoiKhoaBieu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lamMoiBtn);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.dgvThoiKhoaBieu);
            this.Name = "ucThoiKhoaBieu";
            this.Size = new System.Drawing.Size(1561, 922);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvThoiKhoaBieu;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngayChonDTP;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2TextBox thongKeSoTietTxt;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuHaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuBaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuTuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuNamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuSauColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thuBayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chuNhatColumn;
        private Guna.UI2.WinForms.Guna2Button lamMoiBtn;
    }
}
