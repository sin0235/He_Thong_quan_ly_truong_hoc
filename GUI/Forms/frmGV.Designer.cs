using System.Windows.Forms;

namespace QuanLyTruongHoc
{
    partial class frmGV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGV));
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnEx = new Guna.UI2.WinForms.Guna2Button();
            this.guiThongBaoBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSubSettings = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.thongTinCaNhanBtn = new Guna.UI2.WinForms.Guna2Button();
            this.quanLyLopBtn = new Guna.UI2.WinForms.Guna2Button();
            this.quanLyDiemSoBtn = new Guna.UI2.WinForms.Guna2Button();
            this.keHoachGiangDayBtn = new Guna.UI2.WinForms.Guna2Button();
            this.lichDayBtn = new Guna.UI2.WinForms.Guna2Button();
            this.thongBaoBtn = new Guna.UI2.WinForms.Guna2Button();
            this.btnSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyEx = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoEx = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSchoolName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlTop = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPageTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picUserAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTitleBar.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlSubSettings.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            this.pnlMainScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(165)))), ((int)(((byte)(230)))));
            this.pnlTitleBar.Controls.Add(this.lblFormTitle);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonClose);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMaximize);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMinimize);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1920, 50);
            this.pnlTitleBar.TabIndex = 0;
            this.pnlTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitleBar_Paint);
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseDown);
            this.pnlTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseMove);
            this.pnlTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseUp);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblFormTitle.Location = new System.Drawing.Point(12, 8);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(153, 23);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Quản Lý Trường Học";
            // 
            // guna2CircleButtonClose
            // 
            this.guna2CircleButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonClose.BorderThickness = 1;
            this.guna2CircleButtonClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.guna2CircleButtonClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonClose.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonClose.Location = new System.Drawing.Point(1879, 10);
            this.guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            this.guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonClose.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonClose.TabIndex = 3;
            this.guna2CircleButtonClose.Click += new System.EventHandler(this.guna2CircleButtonClose_Click);
            this.guna2CircleButtonClose.MouseEnter += new System.EventHandler(this.guna2CircleButtonClose_MouseEnter);
            this.guna2CircleButtonClose.MouseLeave += new System.EventHandler(this.guna2CircleButtonClose_MouseLeave);
            // 
            // guna2CircleButtonMaximize
            // 
            this.guna2CircleButtonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonMaximize.BorderThickness = 1;
            this.guna2CircleButtonMaximize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMaximize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMaximize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.guna2CircleButtonMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonMaximize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMaximize.Location = new System.Drawing.Point(1853, 10);
            this.guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            this.guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonMaximize.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonMaximize.TabIndex = 1;
            this.guna2CircleButtonMaximize.Click += new System.EventHandler(this.guna2CircleButtonMaximize_Click);
            this.guna2CircleButtonMaximize.MouseEnter += new System.EventHandler(this.guna2CircleButtonMaximize_MouseEnter);
            this.guna2CircleButtonMaximize.MouseLeave += new System.EventHandler(this.guna2CircleButtonMaximize_MouseLeave);
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
            this.guna2CircleButtonMinimize.Location = new System.Drawing.Point(1827, 10);
            this.guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            this.guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonMinimize.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonMinimize.TabIndex = 2;
            this.guna2CircleButtonMinimize.Click += new System.EventHandler(this.guna2CircleButtonMinimize_Click);
            this.guna2CircleButtonMinimize.MouseEnter += new System.EventHandler(this.guna2CircleButtonMinimize_MouseEnter);
            this.guna2CircleButtonMinimize.MouseLeave += new System.EventHandler(this.guna2CircleButtonMinimize_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 18;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(210)))));
            this.pnlLeft.BorderThickness = 1;
            this.pnlLeft.Controls.Add(this.pnlMenu);
            this.pnlLeft.Controls.Add(this.pnlLogo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlLeft.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(350, 1030);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(210)))));
            this.pnlMenu.Controls.Add(this.btnEx);
            this.pnlMenu.Controls.Add(this.guiThongBaoBtn);
            this.pnlMenu.Controls.Add(this.pnlSubSettings);
            this.pnlMenu.Controls.Add(this.thongTinCaNhanBtn);
            this.pnlMenu.Controls.Add(this.quanLyLopBtn);
            this.pnlMenu.Controls.Add(this.quanLyDiemSoBtn);
            this.pnlMenu.Controls.Add(this.keHoachGiangDayBtn);
            this.pnlMenu.Controls.Add(this.lichDayBtn);
            this.pnlMenu.Controls.Add(this.thongBaoBtn);
            this.pnlMenu.Controls.Add(this.btnSetting);
            this.pnlMenu.Controls.Add(this.btnQuanLyEx);
            this.pnlMenu.Controls.Add(this.btnTaoEx);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlMenu.Location = new System.Drawing.Point(0, 160);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlMenu.Size = new System.Drawing.Size(350, 870);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnEx
            // 
            this.btnEx.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEx.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEx.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEx.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.btnEx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnEx.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btnEx.Location = new System.Drawing.Point(0, 546);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(350, 72);
            this.btnEx.TabIndex = 15;
            this.btnEx.Text = "Kiểm tra đánh giá";
            // 
            // guiThongBaoBtn
            // 
            this.guiThongBaoBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.guiThongBaoBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiThongBaoBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.guiThongBaoBtn.Location = new System.Drawing.Point(3, 390);
            this.guiThongBaoBtn.Name = "guiThongBaoBtn";
            this.guiThongBaoBtn.Size = new System.Drawing.Size(350, 72);
            this.guiThongBaoBtn.TabIndex = 0;
            this.guiThongBaoBtn.Text = "Gửi Thông Báo";
            this.guiThongBaoBtn.Click += new System.EventHandler(this.guiThongBaoBtn_Click);
            // 
            // pnlSubSettings
            // 
            this.pnlSubSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlSubSettings.BorderRadius = 10;
            this.pnlSubSettings.Controls.Add(this.btnLogout);
            this.pnlSubSettings.Controls.Add(this.btnChangePassword);
            this.pnlSubSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(175)))), ((int)(((byte)(235)))));
            this.pnlSubSettings.ForeColor = System.Drawing.Color.Black;
            this.pnlSubSettings.Location = new System.Drawing.Point(28, 713);
            this.pnlSubSettings.Name = "pnlSubSettings";
            this.pnlSubSettings.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSubSettings.Size = new System.Drawing.Size(260, 96);
            this.pnlSubSettings.TabIndex = 14;
            this.pnlSubSettings.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnLogout.Location = new System.Drawing.Point(5, 50);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 45);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.BorderRadius = 8;
            this.btnChangePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangePassword.FillColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnChangePassword.Location = new System.Drawing.Point(5, 5);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(250, 45);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // thongTinCaNhanBtn
            // 
            this.thongTinCaNhanBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thongTinCaNhanBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thongTinCaNhanBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thongTinCaNhanBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thongTinCaNhanBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.thongTinCaNhanBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinCaNhanBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.thongTinCaNhanBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.thongTinCaNhanBtn.Location = new System.Drawing.Point(0, 78);
            this.thongTinCaNhanBtn.Name = "thongTinCaNhanBtn";
            this.thongTinCaNhanBtn.Size = new System.Drawing.Size(350, 72);
            this.thongTinCaNhanBtn.TabIndex = 13;
            this.thongTinCaNhanBtn.Text = "Cá Nhân";
            this.thongTinCaNhanBtn.Click += new System.EventHandler(this.thongTinCaNhanBtn_Click);
            // 
            // quanLyLopBtn
            // 
            this.quanLyLopBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.quanLyLopBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.quanLyLopBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.quanLyLopBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.quanLyLopBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.quanLyLopBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanLyLopBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.quanLyLopBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.quanLyLopBtn.Location = new System.Drawing.Point(0, 468);
            this.quanLyLopBtn.Name = "quanLyLopBtn";
            this.quanLyLopBtn.Size = new System.Drawing.Size(350, 72);
            this.quanLyLopBtn.TabIndex = 12;
            this.quanLyLopBtn.Text = "Quản Lý Lớp";
            this.quanLyLopBtn.Click += new System.EventHandler(this.quanLyLopBtn_Click);
            // 
            // quanLyDiemSoBtn
            // 
            this.quanLyDiemSoBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.quanLyDiemSoBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.quanLyDiemSoBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.quanLyDiemSoBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.quanLyDiemSoBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.quanLyDiemSoBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanLyDiemSoBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.quanLyDiemSoBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.quanLyDiemSoBtn.Location = new System.Drawing.Point(3, 312);
            this.quanLyDiemSoBtn.Name = "quanLyDiemSoBtn";
            this.quanLyDiemSoBtn.Size = new System.Drawing.Size(350, 72);
            this.quanLyDiemSoBtn.TabIndex = 10;
            this.quanLyDiemSoBtn.Text = "Điểm Số";
            this.quanLyDiemSoBtn.Click += new System.EventHandler(this.quanLyDiemSoBtn_Click);
            // 
            // keHoachGiangDayBtn
            // 
            this.keHoachGiangDayBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.keHoachGiangDayBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.keHoachGiangDayBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.keHoachGiangDayBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.keHoachGiangDayBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.keHoachGiangDayBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keHoachGiangDayBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.keHoachGiangDayBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.keHoachGiangDayBtn.Location = new System.Drawing.Point(0, 234);
            this.keHoachGiangDayBtn.Name = "keHoachGiangDayBtn";
            this.keHoachGiangDayBtn.Size = new System.Drawing.Size(350, 72);
            this.keHoachGiangDayBtn.TabIndex = 9;
            this.keHoachGiangDayBtn.Text = "Kế Hoạch Giảng Dạy";
            this.keHoachGiangDayBtn.Click += new System.EventHandler(this.keHoachGiangDayBtn_Click);
            // 
            // lichDayBtn
            // 
            this.lichDayBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lichDayBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lichDayBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lichDayBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lichDayBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.lichDayBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lichDayBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lichDayBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.lichDayBtn.Location = new System.Drawing.Point(0, 156);
            this.lichDayBtn.Name = "lichDayBtn";
            this.lichDayBtn.Size = new System.Drawing.Size(350, 72);
            this.lichDayBtn.TabIndex = 8;
            this.lichDayBtn.Text = "Thời Khóa Biểu";
            this.lichDayBtn.Click += new System.EventHandler(this.lichDayBtn_Click);
            // 
            // thongBaoBtn
            // 
            this.thongBaoBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thongBaoBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thongBaoBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thongBaoBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thongBaoBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.thongBaoBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.thongBaoBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.thongBaoBtn.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.thongBaoBtn.Location = new System.Drawing.Point(0, 0);
            this.thongBaoBtn.Name = "thongBaoBtn";
            this.thongBaoBtn.Size = new System.Drawing.Size(350, 72);
            this.thongBaoBtn.TabIndex = 7;
            this.thongBaoBtn.Text = "Thông Báo";
            this.thongBaoBtn.Click += new System.EventHandler(this.thongBaoBtn_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BorderRadius = 10;
            this.btnSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSetting.FillColor = System.Drawing.Color.Transparent;
            this.btnSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnSetting.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSetting.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnSetting.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSetting.Location = new System.Drawing.Point(10, 815);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(330, 55);
            this.btnSetting.TabIndex = 6;
            this.btnSetting.Text = "Cài Đặt";
            this.btnSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSetting.TextOffset = new System.Drawing.Point(15, 0);
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnQuanLyEx
            // 
            this.btnQuanLyEx.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.btnQuanLyEx.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyEx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyEx.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyEx.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyEx.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuanLyEx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuanLyEx.FillColor = System.Drawing.Color.Transparent;
            this.btnQuanLyEx.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyEx.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyEx.Image = global::QuanLyTruongHoc.Properties.Resources.exam_results;
            this.btnQuanLyEx.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyEx.Location = new System.Drawing.Point(28, 619);
            this.btnQuanLyEx.Name = "btnQuanLyEx";
            this.btnQuanLyEx.Size = new System.Drawing.Size(245, 45);
            this.btnQuanLyEx.TabIndex = 9;
            this.btnQuanLyEx.Text = "Quản lý bài kiểm tra";
            this.btnQuanLyEx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyEx.Click += new System.EventHandler(this.btnQuanLyEx_Click);
            // 
            // btnTaoEx
            // 
            this.btnTaoEx.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.btnTaoEx.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTaoEx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoEx.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoEx.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoEx.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoEx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoEx.FillColor = System.Drawing.Color.Transparent;
            this.btnTaoEx.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoEx.ForeColor = System.Drawing.Color.White;
            this.btnTaoEx.Image = global::QuanLyTruongHoc.Properties.Resources.exam;
            this.btnTaoEx.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaoEx.Location = new System.Drawing.Point(28, 670);
            this.btnTaoEx.Name = "btnTaoEx";
            this.btnTaoEx.Size = new System.Drawing.Size(245, 45);
            this.btnTaoEx.TabIndex = 8;
            this.btnTaoEx.Text = "Tạo bài kiểm tra";
            this.btnTaoEx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaoEx.Click += new System.EventHandler(this.btnTaoEx_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(193)))));
            this.pnlLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(115)))), ((int)(((byte)(188)))));
            this.pnlLogo.BorderThickness = 1;
            this.pnlLogo.Controls.Add(this.lblSchoolName);
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(193)))));
            this.pnlLogo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(134)))), ((int)(((byte)(207)))));
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(350, 160);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblSchoolName.Location = new System.Drawing.Point(28, 111);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(181, 27);
            this.lblSchoolName.TabIndex = 1;
            this.lblSchoolName.Text = "TRƯỜNG THPT ABC";
            this.lblSchoolName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(90, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 90);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 18;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlTop.BorderThickness = 1;
            this.pnlTop.Controls.Add(this.lblPageTitle);
            this.pnlTop.Controls.Add(this.lblUserName);
            this.pnlTop.Controls.Add(this.picUserAvatar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.pnlTop.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.pnlTop.Location = new System.Drawing.Point(350, 50);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1570, 99);
            this.pnlTop.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 22);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(94, 34);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Content";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblUserName.Location = new System.Drawing.Point(1360, 32);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(106, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Văn A";
            // 
            // picUserAvatar
            // 
            this.picUserAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picUserAvatar.ImageRotate = 0F;
            this.picUserAvatar.Location = new System.Drawing.Point(1503, 22);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picUserAvatar.Size = new System.Drawing.Size(40, 40);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserAvatar.TabIndex = 0;
            this.picUserAvatar.TabStop = false;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.Controls.Add(this.pnlContent);
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.pnlMainScreen.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.pnlMainScreen.Location = new System.Drawing.Point(350, 50);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(1570, 1030);
            this.pnlMainScreen.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(3, 105);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1561, 922);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // frmGV
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMainScreen);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Trường Học";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSubSettings.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            this.pnlMainScreen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMaximize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLeft;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLogo;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMenu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchoolName;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Button thongBaoBtn;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageTitle;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picUserAvatar;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Button lichDayBtn;
        private Guna.UI2.WinForms.Guna2Button quanLyLopBtn;
        private Guna.UI2.WinForms.Guna2Button quanLyDiemSoBtn;
        private Guna.UI2.WinForms.Guna2Button keHoachGiangDayBtn;
        private Guna.UI2.WinForms.Guna2Button thongTinCaNhanBtn;
        private Guna.UI2.WinForms.Guna2Panel pnlSubSettings;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2Button guiThongBaoBtn;
        private Guna.UI2.WinForms.Guna2Button btnTaoEx;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyEx;
        private Guna.UI2.WinForms.Guna2Button btnEx;
    }
}

