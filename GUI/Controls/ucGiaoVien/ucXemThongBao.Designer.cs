namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    partial class ucXemThongBao
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
            this.thongBaoDgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lamMoiTBBtn = new Guna.UI2.WinForms.Guna2Button();
            this.thongBaoChungBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.timKiemTBBtn = new Guna.UI2.WinForms.Guna2Button();
            this.timKiemTBTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.MaNguoiGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.thongBaoDgv)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // thongBaoDgv
            // 
            this.thongBaoDgv.AllowUserToAddRows = false;
            this.thongBaoDgv.AllowUserToDeleteRows = false;
            this.thongBaoDgv.AllowUserToResizeColumns = false;
            this.thongBaoDgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.thongBaoDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.thongBaoDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.thongBaoDgv.ColumnHeadersHeight = 36;
            this.thongBaoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.thongBaoDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNguoiGui,
            this.TieuDe,
            this.NoiDung,
            this.NgayGui,
            this.NguoiGui});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.thongBaoDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.thongBaoDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.thongBaoDgv.Location = new System.Drawing.Point(15, 203);
            this.thongBaoDgv.MultiSelect = false;
            this.thongBaoDgv.Name = "thongBaoDgv";
            this.thongBaoDgv.ReadOnly = true;
            this.thongBaoDgv.RowHeadersVisible = false;
            this.thongBaoDgv.RowHeadersWidth = 51;
            this.thongBaoDgv.RowTemplate.Height = 36;
            this.thongBaoDgv.Size = new System.Drawing.Size(1531, 705);
            this.thongBaoDgv.TabIndex = 6;
            this.thongBaoDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.thongBaoDgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.thongBaoDgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.thongBaoDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.thongBaoDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.thongBaoDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.thongBaoDgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.thongBaoDgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.thongBaoDgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.thongBaoDgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.thongBaoDgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongBaoDgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.thongBaoDgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.thongBaoDgv.ThemeStyle.HeaderStyle.Height = 36;
            this.thongBaoDgv.ThemeStyle.ReadOnly = true;
            this.thongBaoDgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.thongBaoDgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.thongBaoDgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongBaoDgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.thongBaoDgv.ThemeStyle.RowsStyle.Height = 36;
            this.thongBaoDgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.thongBaoDgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.thongBaoDgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.thongBaoDgv_CellDoubleClick);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 10;
            this.guna2CustomGradientPanel1.Controls.Add(this.lamMoiTBBtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.thongBaoChungBtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Button1);
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(15, 21);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1531, 85);
            this.guna2CustomGradientPanel1.TabIndex = 18;
            // 
            // lamMoiTBBtn
            // 
            this.lamMoiTBBtn.BackColor = System.Drawing.Color.Transparent;
            this.lamMoiTBBtn.BorderRadius = 10;
            this.lamMoiTBBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lamMoiTBBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lamMoiTBBtn.FillColor = System.Drawing.Color.Red;
            this.lamMoiTBBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamMoiTBBtn.ForeColor = System.Drawing.Color.White;
            this.lamMoiTBBtn.HoverState.FillColor = System.Drawing.Color.Tomato;
            this.lamMoiTBBtn.Location = new System.Drawing.Point(1336, 23);
            this.lamMoiTBBtn.Name = "lamMoiTBBtn";
            this.lamMoiTBBtn.Size = new System.Drawing.Size(180, 45);
            this.lamMoiTBBtn.TabIndex = 10;
            this.lamMoiTBBtn.Text = "Làm Mới";
            this.lamMoiTBBtn.Click += new System.EventHandler(this.lamMoiTBBtn_Click);
            // 
            // thongBaoChungBtn
            // 
            this.thongBaoChungBtn.BackColor = System.Drawing.Color.Transparent;
            this.thongBaoChungBtn.BorderRadius = 10;
            this.thongBaoChungBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thongBaoChungBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thongBaoChungBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thongBaoChungBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thongBaoChungBtn.FillColor = System.Drawing.Color.DarkOrange;
            this.thongBaoChungBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongBaoChungBtn.ForeColor = System.Drawing.Color.White;
            this.thongBaoChungBtn.HoverState.FillColor = System.Drawing.Color.Orange;
            this.thongBaoChungBtn.Location = new System.Drawing.Point(25, 23);
            this.thongBaoChungBtn.Name = "thongBaoChungBtn";
            this.thongBaoChungBtn.Size = new System.Drawing.Size(257, 45);
            this.thongBaoChungBtn.TabIndex = 8;
            this.thongBaoChungBtn.Text = "Thông Báo Chung";
            this.thongBaoChungBtn.Click += new System.EventHandler(this.thongBaoChungBtn_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2Button1.Location = new System.Drawing.Point(25, 203);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(225, 45);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Đổi ảnh đại diện";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderRadius = 10;
            this.guna2CustomGradientPanel2.Controls.Add(this.timKiemTBBtn);
            this.guna2CustomGradientPanel2.Controls.Add(this.timKiemTBTxt);
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2Button8);
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(15, 112);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(1531, 85);
            this.guna2CustomGradientPanel2.TabIndex = 19;
            // 
            // timKiemTBBtn
            // 
            this.timKiemTBBtn.BackColor = System.Drawing.Color.Transparent;
            this.timKiemTBBtn.BorderRadius = 10;
            this.timKiemTBBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.timKiemTBBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.timKiemTBBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.timKiemTBBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.timKiemTBBtn.FillColor = System.Drawing.Color.LimeGreen;
            this.timKiemTBBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemTBBtn.ForeColor = System.Drawing.Color.White;
            this.timKiemTBBtn.HoverState.FillColor = System.Drawing.Color.Chartreuse;
            this.timKiemTBBtn.Location = new System.Drawing.Point(802, 22);
            this.timKiemTBBtn.Name = "timKiemTBBtn";
            this.timKiemTBBtn.Size = new System.Drawing.Size(170, 45);
            this.timKiemTBBtn.TabIndex = 20;
            this.timKiemTBBtn.Text = "Tìm Kiếm";
            this.timKiemTBBtn.Click += new System.EventHandler(this.timKiemTBBtn_Click);
            // 
            // timKiemTBTxt
            // 
            this.timKiemTBTxt.BackColor = System.Drawing.Color.Transparent;
            this.timKiemTBTxt.BorderRadius = 10;
            this.timKiemTBTxt.BorderThickness = 2;
            this.timKiemTBTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.timKiemTBTxt.DefaultText = "";
            this.timKiemTBTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.timKiemTBTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.timKiemTBTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.timKiemTBTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.timKiemTBTxt.FillColor = System.Drawing.Color.Azure;
            this.timKiemTBTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.timKiemTBTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemTBTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.timKiemTBTxt.Location = new System.Drawing.Point(25, 15);
            this.timKiemTBTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timKiemTBTxt.Name = "timKiemTBTxt";
            this.timKiemTBTxt.PlaceholderText = "Tìm kiếm thông báo.....";
            this.timKiemTBTxt.SelectedText = "";
            this.timKiemTBTxt.Size = new System.Drawing.Size(762, 52);
            this.timKiemTBTxt.TabIndex = 25;
            // 
            // guna2Button8
            // 
            this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button8.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button8.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2Button8.Location = new System.Drawing.Point(25, 203);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Size = new System.Drawing.Size(225, 45);
            this.guna2Button8.TabIndex = 1;
            this.guna2Button8.Text = "Đổi ảnh đại diện";
            // 
            // MaNguoiGui
            // 
            this.MaNguoiGui.DataPropertyName = "MaNguoiGui";
            this.MaNguoiGui.HeaderText = "Mã Người Gửi";
            this.MaNguoiGui.MinimumWidth = 6;
            this.MaNguoiGui.Name = "MaNguoiGui";
            this.MaNguoiGui.ReadOnly = true;
            this.MaNguoiGui.Visible = false;
            // 
            // TieuDe
            // 
            this.TieuDe.DataPropertyName = "TieuDe";
            this.TieuDe.HeaderText = "Tiêu đề";
            this.TieuDe.MinimumWidth = 6;
            this.TieuDe.Name = "TieuDe";
            this.TieuDe.ReadOnly = true;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.MinimumWidth = 6;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            // 
            // NgayGui
            // 
            this.NgayGui.DataPropertyName = "NgayGui";
            this.NgayGui.HeaderText = "Ngày Gửi";
            this.NgayGui.MinimumWidth = 6;
            this.NgayGui.Name = "NgayGui";
            this.NgayGui.ReadOnly = true;
            // 
            // NguoiGui
            // 
            this.NguoiGui.DataPropertyName = "NguoiGui";
            this.NguoiGui.HeaderText = "Người Gửi";
            this.NguoiGui.MinimumWidth = 6;
            this.NguoiGui.Name = "NguoiGui";
            this.NguoiGui.ReadOnly = true;
            // 
            // ucXemThongBao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.thongBaoDgv);
            this.Name = "ucXemThongBao";
            this.Size = new System.Drawing.Size(1561, 922);
            ((System.ComponentModel.ISupportInitialize)(this.thongBaoDgv)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView thongBaoDgv;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button thongBaoChungBtn;
        private Guna.UI2.WinForms.Guna2Button lamMoiTBBtn;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2TextBox timKiemTBTxt;
        private Guna.UI2.WinForms.Guna2Button timKiemTBBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNguoiGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiGui;
    }
}
