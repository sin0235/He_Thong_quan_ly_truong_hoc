using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTKB
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
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTuanHienTai = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuanTruoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuanTiepTheo = new Guna.UI2.WinForms.Guna2Button();
            this.lblTuan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboTuan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNamHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNoData = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoData = new System.Windows.Forms.Label();
            this.picNoData = new System.Windows.Forms.PictureBox();
            this.pnlFilters.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlNoData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilters.BorderRadius = 8;
            this.pnlFilters.Controls.Add(this.btnTuanHienTai);
            this.pnlFilters.Controls.Add(this.btnTuanTruoc);
            this.pnlFilters.Controls.Add(this.btnTuanTiepTheo);
            this.pnlFilters.Controls.Add(this.lblTuan);
            this.pnlFilters.Controls.Add(this.cboTuan);
            this.pnlFilters.Controls.Add(this.lblNamHoc);
            this.pnlFilters.Controls.Add(this.cboNamHoc);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.ShadowDecoration.BorderRadius = 8;
            this.pnlFilters.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.pnlFilters.ShadowDecoration.Enabled = true;
            this.pnlFilters.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 0, 6);
            this.pnlFilters.Size = new System.Drawing.Size(1550, 59);
            this.pnlFilters.TabIndex = 1;
            // 
            // btnTuanHienTai
            // 
            this.btnTuanHienTai.Animated = true;
            this.btnTuanHienTai.AutoRoundedCorners = true;
            this.btnTuanHienTai.BorderRadius = 18;
            this.btnTuanHienTai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanHienTai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanHienTai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanHienTai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanHienTai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.btnTuanHienTai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanHienTai.ForeColor = System.Drawing.Color.White;
            this.btnTuanHienTai.IndicateFocus = true;
            this.btnTuanHienTai.Location = new System.Drawing.Point(949, 12);
            this.btnTuanHienTai.Name = "btnTuanHienTai";
            this.btnTuanHienTai.Size = new System.Drawing.Size(128, 38);
            this.btnTuanHienTai.TabIndex = 9;
            this.btnTuanHienTai.Text = "Hiện tại";
            this.btnTuanHienTai.Click += new System.EventHandler(this.btnTuanHienTai_Click);
            // 
            // btnTuanTruoc
            // 
            this.btnTuanTruoc.Animated = true;
            this.btnTuanTruoc.AutoRoundedCorners = true;
            this.btnTuanTruoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTruoc.BorderRadius = 17;
            this.btnTuanTruoc.BorderThickness = 1;
            this.btnTuanTruoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTruoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTruoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanTruoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanTruoc.FillColor = System.Drawing.Color.White;
            this.btnTuanTruoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanTruoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTruoc.IndicateFocus = true;
            this.btnTuanTruoc.Location = new System.Drawing.Point(780, 12);
            this.btnTuanTruoc.Name = "btnTuanTruoc";
            this.btnTuanTruoc.Size = new System.Drawing.Size(128, 36);
            this.btnTuanTruoc.TabIndex = 8;
            this.btnTuanTruoc.Text = "← Tuần trước";
            this.btnTuanTruoc.Click += new System.EventHandler(this.btnTuanTruoc_Click);
            // 
            // btnTuanTiepTheo
            // 
            this.btnTuanTiepTheo.Animated = true;
            this.btnTuanTiepTheo.AutoRoundedCorners = true;
            this.btnTuanTiepTheo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTiepTheo.BorderRadius = 17;
            this.btnTuanTiepTheo.BorderThickness = 1;
            this.btnTuanTiepTheo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTiepTheo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTiepTheo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanTiepTheo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanTiepTheo.FillColor = System.Drawing.Color.White;
            this.btnTuanTiepTheo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanTiepTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTiepTheo.IndicateFocus = true;
            this.btnTuanTiepTheo.Location = new System.Drawing.Point(1118, 12);
            this.btnTuanTiepTheo.Name = "btnTuanTiepTheo";
            this.btnTuanTiepTheo.Size = new System.Drawing.Size(128, 36);
            this.btnTuanTiepTheo.TabIndex = 7;
            this.btnTuanTiepTheo.Text = "Tiếp theo →";
            this.btnTuanTiepTheo.Click += new System.EventHandler(this.btnTuanTiepTheo_Click);
            // 
            // lblTuan
            // 
            this.lblTuan.BackColor = System.Drawing.Color.Transparent;
            this.lblTuan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTuan.Location = new System.Drawing.Point(344, 17);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(38, 23);
            this.lblTuan.TabIndex = 6;
            this.lblTuan.Text = "Tuần";
            // 
            // cboTuan
            // 
            this.cboTuan.BackColor = System.Drawing.Color.Transparent;
            this.cboTuan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboTuan.BorderRadius = 18;
            this.cboTuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuan.DropDownWidth = 200;
            this.cboTuan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTuan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboTuan.ItemHeight = 30;
            this.cboTuan.Location = new System.Drawing.Point(398, 14);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Size = new System.Drawing.Size(293, 36);
            this.cboTuan.TabIndex = 5;
            this.cboTuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cboTuan.SelectedIndexChanged += new System.EventHandler(this.cboTuan_SelectedIndexChanged);
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblNamHoc.Location = new System.Drawing.Point(20, 17);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(68, 23);
            this.lblNamHoc.TabIndex = 2;
            this.lblNamHoc.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboNamHoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboNamHoc.BorderRadius = 18;
            this.cboNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboNamHoc.ItemHeight = 30;
            this.cboNamHoc.Location = new System.Drawing.Point(104, 12);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(192, 36);
            this.cboNamHoc.TabIndex = 0;
            this.cboNamHoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cboNamHoc.SelectedIndexChanged += new System.EventHandler(this.cboNamHoc_SelectedIndexChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 140);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1640, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.Controls.Add(this.pnlNoData);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 59);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.pnlContent.Size = new System.Drawing.Size(1550, 981);
            this.pnlContent.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1510, 951);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.pnlNoData.Location = new System.Drawing.Point(526, 340);
            this.pnlNoData.Name = "pnlNoData";
            this.pnlNoData.Size = new System.Drawing.Size(500, 300);
            this.pnlNoData.TabIndex = 2;
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
            this.lblNoData.Text = "Không có thời khóa biểu cho tuần này";
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
            // ucTKB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.pnlFilters);
            this.Name = "ucTKB";
            this.Size = new System.Drawing.Size(1550, 1040);
            this.Load += new System.EventHandler(this.ucTKB_Load);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlNoData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlFilters;
        private Guna.UI2.WinForms.Guna2ComboBox cboNamHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNamHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTuan;
        private Guna.UI2.WinForms.Guna2ComboBox cboTuan;
        private Guna.UI2.WinForms.Guna2Button btnTuanTiepTheo;
        private Guna.UI2.WinForms.Guna2Button btnTuanTruoc;
        private Guna.UI2.WinForms.Guna2Button btnTuanHienTai;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlNoData;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.PictureBox picNoData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
