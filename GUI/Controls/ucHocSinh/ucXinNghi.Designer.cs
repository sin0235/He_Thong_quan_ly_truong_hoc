namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucXinNghi
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
            this.pnlNghi = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaoMoi = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.cboThoiGian = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblThoiGian = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangCho = new Guna.UI2.WinForms.Guna2Button();
            this.btnDaDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlDonXinNghi = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNoData = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoData = new System.Windows.Forms.Label();
            this.picNoData = new System.Windows.Forms.PictureBox();
            this.pnlTaoDonMoi = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNghi.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlDonXinNghi.SuspendLayout();
            this.pnlNoData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNghi
            // 
            this.pnlNghi.Controls.Add(this.btnTaoMoi);
            this.pnlNghi.Controls.Add(this.pnlFilter);
            this.pnlNghi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNghi.Location = new System.Drawing.Point(0, 0);
            this.pnlNghi.Name = "pnlNghi";
            this.pnlNghi.ShadowDecoration.BorderRadius = 8;
            this.pnlNghi.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.pnlNghi.ShadowDecoration.Enabled = true;
            this.pnlNghi.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 0, 6);
            this.pnlNghi.Size = new System.Drawing.Size(1640, 70);
            this.pnlNghi.TabIndex = 1;
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Animated = true;
            this.btnTaoMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnTaoMoi.BorderRadius = 22;
            this.btnTaoMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            this.btnTaoMoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTaoMoi.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnTaoMoi.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTaoMoi.Location = new System.Drawing.Point(20, 13);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(200, 45);
            this.btnTaoMoi.TabIndex = 3;
            this.btnTaoMoi.Text = "Xin phép nghỉ học";
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.cboThoiGian);
            this.pnlFilter.Controls.Add(this.lblThoiGian);
            this.pnlFilter.Controls.Add(this.btnAll);
            this.pnlFilter.Controls.Add(this.btnTuChoi);
            this.pnlFilter.Controls.Add(this.btnDangCho);
            this.pnlFilter.Controls.Add(this.btnDaDuyet);
            this.pnlFilter.Location = new System.Drawing.Point(384, 13);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1240, 45);
            this.pnlFilter.TabIndex = 2;
            // 
            // cboThoiGian
            // 
            this.cboThoiGian.BackColor = System.Drawing.Color.Transparent;
            this.cboThoiGian.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboThoiGian.BorderRadius = 18;
            this.cboThoiGian.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThoiGian.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThoiGian.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThoiGian.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboThoiGian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboThoiGian.ItemHeight = 30;
            this.cboThoiGian.Items.AddRange(new object[] {
            "Tất cả",
            "Tháng này",
            "6 tháng gần đây",
            "1 năm gần đây"});
            this.cboThoiGian.Location = new System.Drawing.Point(101, 4);
            this.cboThoiGian.Name = "cboThoiGian";
            this.cboThoiGian.Size = new System.Drawing.Size(248, 36);
            this.cboThoiGian.StartIndex = 0;
            this.cboThoiGian.TabIndex = 7;
            this.cboThoiGian.TextOffset = new System.Drawing.Point(5, 0);
            this.cboThoiGian.SelectedIndexChanged += new System.EventHandler(this.cboThoiGian_SelectedIndexChanged);
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.BackColor = System.Drawing.Color.Transparent;
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblThoiGian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblThoiGian.Location = new System.Drawing.Point(16, 13);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(74, 23);
            this.lblThoiGian.TabIndex = 6;
            this.lblThoiGian.Text = "Thời gian:";
            // 
            // btnAll
            // 
            this.btnAll.Animated = true;
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderRadius = 18;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(184)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(371, 5);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(148, 36);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Tất cả";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Animated = true;
            this.btnTuChoi.BackColor = System.Drawing.Color.Transparent;
            this.btnTuChoi.BorderRadius = 18;
            this.btnTuChoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuChoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuChoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuChoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuChoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(838, 5);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(148, 36);
            this.btnTuChoi.TabIndex = 3;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // btnDangCho
            // 
            this.btnDangCho.Animated = true;
            this.btnDangCho.BackColor = System.Drawing.Color.Transparent;
            this.btnDangCho.BorderRadius = 18;
            this.btnDangCho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangCho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangCho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangCho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangCho.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            this.btnDangCho.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangCho.ForeColor = System.Drawing.Color.White;
            this.btnDangCho.Location = new System.Drawing.Point(682, 5);
            this.btnDangCho.Name = "btnDangCho";
            this.btnDangCho.Size = new System.Drawing.Size(148, 36);
            this.btnDangCho.TabIndex = 2;
            this.btnDangCho.Text = "Đang chờ";
            this.btnDangCho.Click += new System.EventHandler(this.btnDangCho_Click);
            // 
            // btnDaDuyet
            // 
            this.btnDaDuyet.Animated = true;
            this.btnDaDuyet.BackColor = System.Drawing.Color.Transparent;
            this.btnDaDuyet.BorderRadius = 18;
            this.btnDaDuyet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDaDuyet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDaDuyet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDaDuyet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDaDuyet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.btnDaDuyet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDaDuyet.Location = new System.Drawing.Point(526, 5);
            this.btnDaDuyet.Name = "btnDaDuyet";
            this.btnDaDuyet.Size = new System.Drawing.Size(148, 36);
            this.btnDaDuyet.TabIndex = 1;
            this.btnDaDuyet.Text = "Đã duyệt";
            this.btnDaDuyet.Click += new System.EventHandler(this.btnDaDuyet_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 70);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1640, 2);
            this.guna2Separator1.TabIndex = 2;
            // 
            // pnlDonXinNghi
            // 
            this.pnlDonXinNghi.AutoScroll = true;
            this.pnlDonXinNghi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlDonXinNghi.Controls.Add(this.pnlNoData);
            this.pnlDonXinNghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDonXinNghi.Location = new System.Drawing.Point(0, 72);
            this.pnlDonXinNghi.Name = "pnlDonXinNghi";
            this.pnlDonXinNghi.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDonXinNghi.Size = new System.Drawing.Size(1640, 888);
            this.pnlDonXinNghi.TabIndex = 3;
            // 
            // pnlNoData
            // 
            this.pnlNoData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlNoData.BackColor = System.Drawing.Color.White;
            this.pnlNoData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlNoData.BorderRadius = 15;
            this.pnlNoData.BorderThickness = 1;
            this.pnlNoData.Controls.Add(this.lblNoData);
            this.pnlNoData.Controls.Add(this.picNoData);
            this.pnlNoData.Location = new System.Drawing.Point(570, 294);
            this.pnlNoData.Name = "pnlNoData";
            this.pnlNoData.Size = new System.Drawing.Size(500, 300);
            this.pnlNoData.TabIndex = 0;
            this.pnlNoData.Visible = false;
            // 
            // lblNoData
            // 
            this.lblNoData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNoData.Location = new System.Drawing.Point(30, 200);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(440, 60);
            this.lblNoData.TabIndex = 1;
            this.lblNoData.Text = "Không có đơn xin nghỉ học nào";
            this.lblNoData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picNoData
            // 
            this.picNoData.Location = new System.Drawing.Point(175, 40);
            this.picNoData.Name = "picNoData";
            this.picNoData.Size = new System.Drawing.Size(150, 150);
            this.picNoData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNoData.TabIndex = 0;
            this.picNoData.TabStop = false;
            // 
            // pnlTaoDonMoi
            // 
            this.pnlTaoDonMoi.AutoScroll = true;
            this.pnlTaoDonMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlTaoDonMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTaoDonMoi.Location = new System.Drawing.Point(0, 72);
            this.pnlTaoDonMoi.Name = "pnlTaoDonMoi";
            this.pnlTaoDonMoi.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTaoDonMoi.Size = new System.Drawing.Size(1640, 888);
            this.pnlTaoDonMoi.TabIndex = 4;
            this.pnlTaoDonMoi.Visible = false;
            this.pnlTaoDonMoi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTaoDonMoi_Paint);
            // 
            // ucXinNghi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlTaoDonMoi);
            this.Controls.Add(this.pnlDonXinNghi);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.pnlNghi);
            this.Name = "ucXinNghi";
            this.Size = new System.Drawing.Size(1640, 960);
            this.Load += new System.EventHandler(this.ucXinNghi_Load);
            this.pnlNghi.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDonXinNghi.ResumeLayout(false);
            this.pnlNoData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlNghi;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnTuChoi;
        private Guna.UI2.WinForms.Guna2Button btnDangCho;
        private Guna.UI2.WinForms.Guna2Button btnDaDuyet;
        private Guna.UI2.WinForms.Guna2Button btnTaoMoi;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel pnlDonXinNghi;
        private Guna.UI2.WinForms.Guna2Panel pnlNoData;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.PictureBox picNoData;
        private Guna.UI2.WinForms.Guna2Panel pnlTaoDonMoi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThoiGian;
        private Guna.UI2.WinForms.Guna2ComboBox cboThoiGian;
    }
}
