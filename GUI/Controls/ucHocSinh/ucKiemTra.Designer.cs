namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucKiemTra
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
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbSemester = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSemester = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSchoolYear = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnComingSoon = new Guna.UI2.WinForms.Guna2Button();
            this.btnHomework = new Guna.UI2.WinForms.Guna2Button();
            this.btnTests = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTestContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilter.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFilter.BorderRadius = 10;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.cmbSemester);
            this.pnlFilter.Controls.Add(this.lblSemester);
            this.pnlFilter.Controls.Add(this.cmbSchoolYear);
            this.pnlFilter.Controls.Add(this.lblSchoolYear);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlFilter.Size = new System.Drawing.Size(1640, 70);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Animated = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderRadius = 8;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::QuanLyTruongHoc.Properties.Resources.search;
            this.btnSearch.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSearch.IndicateFocus = true;
            this.btnSearch.Location = new System.Drawing.Point(1550, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(1254, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm bài kiểm tra...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(290, 40);
            this.txtSearch.TabIndex = 4;
            // 
            // cmbSemester
            // 
            this.cmbSemester.BackColor = System.Drawing.Color.Transparent;
            this.cmbSemester.BorderRadius = 8;
            this.cmbSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSemester.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSemester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSemester.ItemHeight = 30;
            this.cmbSemester.Items.AddRange(new object[] {
            "Học kì 1",
            "Học kì 2"});
            this.cmbSemester.Location = new System.Drawing.Point(357, 19);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(140, 36);
            this.cmbSemester.StartIndex = 0;
            this.cmbSemester.TabIndex = 3;
            // 
            // lblSemester
            // 
            this.lblSemester.BackColor = System.Drawing.Color.Transparent;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSemester.Location = new System.Drawing.Point(268, 25);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(49, 23);
            this.lblSemester.TabIndex = 2;
            this.lblSemester.Text = "Học kì:";
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.cmbSchoolYear.BorderRadius = 8;
            this.cmbSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSchoolYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchoolYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSchoolYear.ItemHeight = 30;
            this.cmbSchoolYear.Items.AddRange(new object[] {
            "2024-2025",
            "2023-2024",
            "2022-2023"});
            this.cmbSchoolYear.Location = new System.Drawing.Point(95, 19);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(140, 36);
            this.cmbSchoolYear.StartIndex = 0;
            this.cmbSchoolYear.TabIndex = 1;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSchoolYear.Location = new System.Drawing.Point(20, 25);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(69, 23);
            this.lblSchoolYear.TabIndex = 0;
            this.lblSchoolYear.Text = "Năm học:";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnComingSoon);
            this.pnlMenu.Controls.Add(this.btnHomework);
            this.pnlMenu.Controls.Add(this.btnTests);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.FillColor = System.Drawing.Color.White;
            this.pnlMenu.Location = new System.Drawing.Point(0, 70);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlMenu.Size = new System.Drawing.Size(1640, 70);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnComingSoon
            // 
            this.btnComingSoon.BorderRadius = 10;
            this.btnComingSoon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnComingSoon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnComingSoon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnComingSoon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnComingSoon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(100)))));
            this.btnComingSoon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComingSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnComingSoon.Location = new System.Drawing.Point(400, 10);
            this.btnComingSoon.Name = "btnComingSoon";
            this.btnComingSoon.Size = new System.Drawing.Size(180, 50);
            this.btnComingSoon.TabIndex = 2;
            this.btnComingSoon.Text = "🗓️ Sắp đến hạn";
            // 
            // btnHomework
            // 
            this.btnHomework.BorderRadius = 10;
            this.btnHomework.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomework.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomework.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomework.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomework.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(160)))), ((int)(((byte)(77)))));
            this.btnHomework.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomework.ForeColor = System.Drawing.Color.White;
            this.btnHomework.Location = new System.Drawing.Point(210, 10);
            this.btnHomework.Name = "btnHomework";
            this.btnHomework.Size = new System.Drawing.Size(180, 50);
            this.btnHomework.TabIndex = 1;
            this.btnHomework.Text = "📚 Bài tập về nhà";
            // 
            // btnTests
            // 
            this.btnTests.BorderRadius = 10;
            this.btnTests.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTests.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTests.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTests.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTests.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.btnTests.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTests.ForeColor = System.Drawing.Color.White;
            this.btnTests.Location = new System.Drawing.Point(20, 10);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(180, 50);
            this.btnTests.TabIndex = 0;
            this.btnTests.Text = "📝 Bài kiểm tra";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlTestContainer);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 140);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1640, 820);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlTestContainer
            // 
            this.pnlTestContainer.AutoScroll = true;
            this.pnlTestContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTestContainer.Location = new System.Drawing.Point(20, 20);
            this.pnlTestContainer.Name = "pnlTestContainer";
            this.pnlTestContainer.Size = new System.Drawing.Size(1600, 780);
            this.pnlTestContainer.TabIndex = 0;
            // 
            // ucKiemTra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ucKiemTra";
            this.Size = new System.Drawing.Size(1640, 960);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSemester;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSemester;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSchoolYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchoolYear;
        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Button btnHomework;
        private Guna.UI2.WinForms.Guna2Button btnTests;
        private Guna.UI2.WinForms.Guna2Button btnComingSoon;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel pnlTestContainer;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}
