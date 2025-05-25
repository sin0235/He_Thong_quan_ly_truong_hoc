namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTKBItem
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
            this.lblNoidung = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblThoigian = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGiaoVien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMonHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlColor = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTiet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMain.SuspendLayout();
            this.pnlColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderColor = System.Drawing.Color.Black;
            this.pnlMain.BorderRadius = 12;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.lblNoidung);
            this.pnlMain.Controls.Add(this.lblThoigian);
            this.pnlMain.Controls.Add(this.lblGiaoVien);
            this.pnlMain.Controls.Add(this.lblMonHoc);
            this.pnlMain.Controls.Add(this.pnlColor);
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlMain.Location = new System.Drawing.Point(14, 9);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.BorderRadius = 15;
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlMain.ShadowDecoration.Depth = 10;
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(265, 188);
            this.pnlMain.TabIndex = 0;
            // 
            // lblNoidung
            // 
            this.lblNoidung.AutoSize = false;
            this.lblNoidung.BackColor = System.Drawing.Color.Transparent;
            this.lblNoidung.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoidung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNoidung.Location = new System.Drawing.Point(68, 115);
            this.lblNoidung.Name = "lblNoidung";
            this.lblNoidung.Size = new System.Drawing.Size(181, 49);
            this.lblNoidung.TabIndex = 3;
            this.lblNoidung.Text = "Ôn tập cho bài kiểm tra số 2";
            // 
            // lblThoigian
            // 
            this.lblThoigian.BackColor = System.Drawing.Color.Transparent;
            this.lblThoigian.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblThoigian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblThoigian.Location = new System.Drawing.Point(68, 84);
            this.lblThoigian.Name = "lblThoigian";
            this.lblThoigian.Size = new System.Drawing.Size(109, 19);
            this.lblThoigian.TabIndex = 2;
            this.lblThoigian.Text = "07:30 - 08:15 sáng";
            this.lblThoigian.Click += new System.EventHandler(this.lblThoigian_Click);
            // 
            // lblGiaoVien
            // 
            this.lblGiaoVien.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaoVien.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaoVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblGiaoVien.Location = new System.Drawing.Point(68, 55);
            this.lblGiaoVien.Name = "lblGiaoVien";
            this.lblGiaoVien.Size = new System.Drawing.Size(125, 19);
            this.lblGiaoVien.TabIndex = 1;
            this.lblGiaoVien.Text = "Cô Nguyễn Thị Hiền";
            this.lblGiaoVien.Click += new System.EventHandler(this.lblGiaoVien_Click);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.lblMonHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblMonHoc.Location = new System.Drawing.Point(68, 15);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(116, 23);
            this.lblMonHoc.TabIndex = 0;
            this.lblMonHoc.Text = "Toán Đại Số 10";
            // 
            // pnlColor
            // 
            this.pnlColor.BorderRadius = 8;
            this.pnlColor.Controls.Add(this.lblTiet);
            this.pnlColor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlColor.Location = new System.Drawing.Point(15, 19);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(37, 149);
            this.pnlColor.TabIndex = 6;
            // 
            // lblTiet
            // 
            this.lblTiet.BackColor = System.Drawing.Color.Transparent;
            this.lblTiet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiet.ForeColor = System.Drawing.Color.White;
            this.lblTiet.Location = new System.Drawing.Point(7, 65);
            this.lblTiet.Name = "lblTiet";
            this.lblTiet.Size = new System.Drawing.Size(21, 23);
            this.lblTiet.TabIndex = 0;
            this.lblTiet.Text = "#1";
            this.lblTiet.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTKBItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTKBItem";
            this.Size = new System.Drawing.Size(295, 206);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlColor.ResumeLayout(false);
            this.pnlColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMonHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGiaoVien;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThoigian;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoidung;
        private Guna.UI2.WinForms.Guna2Panel pnlColor;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTiet;
    }
}
