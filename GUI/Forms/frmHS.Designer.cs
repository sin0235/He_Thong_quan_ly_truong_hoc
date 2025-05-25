using System.Drawing;

namespace QuanLyTruongHoc
{
    partial class frmHS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHS));
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlSubSettings = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnKQHT = new Guna.UI2.WinForms.Guna2Button();
            this.btnTKB = new Guna.UI2.WinForms.Guna2Button();
            this.btnBT = new Guna.UI2.WinForms.Guna2Button();
            this.btnInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongBao = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSchoolName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlTop = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPageTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picUserAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.ucKiemTra1 = new QuanLyTruongHoc.GUI.Controls.ucKiemTra(maHS);
            this.ucXinNghi1 = new QuanLyTruongHoc.GUI.Controls.ucXinNghi(ID, maHS);
            this.ucKQHT1 = new QuanLyTruongHoc.GUI.Controls.ucKQHT(maHS, ID);
            this.ucTKB1 = new QuanLyTruongHoc.GUI.Controls.ucTKB(maHS, ID);
            this.ucInfoHS1 = new QuanLyTruongHoc.GUI.Controls.ucInfoHS(maHS);
            this.ucThongBao1 = new QuanLyTruongHoc.GUI.Controls.ucThongBao(maHS, ID);
            this.pnlTitleBar.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlSubSettings.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlMainScreen.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
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
            this.pnlTitleBar.Size = new System.Drawing.Size(1920, 40);
            this.pnlTitleBar.TabIndex = 0;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseDown);
            this.pnlTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseMove);
            this.pnlTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseUp);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblFormTitle.Location = new System.Drawing.Point(12, 8);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(180, 27);
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
            this.pnlLeft.Location = new System.Drawing.Point(0, 40);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(280, 1040);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(210)))));
            this.pnlMenu.Controls.Add(this.pnlSubSettings);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.btnKQHT);
            this.pnlMenu.Controls.Add(this.btnTKB);
            this.pnlMenu.Controls.Add(this.btnBT);
            this.pnlMenu.Controls.Add(this.btnInfo);
            this.pnlMenu.Controls.Add(this.btnThongBao);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlMenu.Location = new System.Drawing.Point(0, 209);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlMenu.Size = new System.Drawing.Size(280, 831);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlSubSettings
            // 
            this.pnlSubSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlSubSettings.BorderRadius = 10;
            this.pnlSubSettings.Controls.Add(this.btnLogout);
            this.pnlSubSettings.Controls.Add(this.btnChangePassword);
            this.pnlSubSettings.Controls.Add(this.btnProfile);
            this.pnlSubSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(175)))), ((int)(((byte)(235)))));
            this.pnlSubSettings.ForeColor = System.Drawing.Color.Black;
            this.pnlSubSettings.Location = new System.Drawing.Point(12, 664);
            this.pnlSubSettings.Name = "pnlSubSettings";
            this.pnlSubSettings.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSubSettings.Size = new System.Drawing.Size(260, 155);
            this.pnlSubSettings.TabIndex = 8;
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
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnLogout.Location = new System.Drawing.Point(5, 95);
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
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnChangePassword.Location = new System.Drawing.Point(5, 50);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(250, 45);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click_1);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnProfile.BorderRadius = 8;
            this.btnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FillColor = System.Drawing.Color.Transparent;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnProfile.Location = new System.Drawing.Point(5, 5);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(250, 45);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Hồ sơ học sinh";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderRadius = 10;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnSettings.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSettings.Location = new System.Drawing.Point(10, 776);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(260, 55);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Cài đặt";
            this.btnSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.TextOffset = new System.Drawing.Point(15, 0);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.BorderRadius = 10;
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FillColor = System.Drawing.Color.Transparent;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnReports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnReports.ImageSize = new System.Drawing.Size(24, 24);
            this.btnReports.Location = new System.Drawing.Point(10, 275);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(260, 55);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Đơn xin phép";
            this.btnReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnKQHT
            // 
            this.btnKQHT.BackColor = System.Drawing.Color.Transparent;
            this.btnKQHT.BorderRadius = 10;
            this.btnKQHT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKQHT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKQHT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKQHT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKQHT.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKQHT.FillColor = System.Drawing.Color.Transparent;
            this.btnKQHT.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKQHT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnKQHT.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKQHT.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnKQHT.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKQHT.Location = new System.Drawing.Point(10, 220);
            this.btnKQHT.Name = "btnKQHT";
            this.btnKQHT.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnKQHT.Size = new System.Drawing.Size(260, 55);
            this.btnKQHT.TabIndex = 4;
            this.btnKQHT.Text = "Kết quả học tập";
            this.btnKQHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKQHT.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnTKB
            // 
            this.btnTKB.BackColor = System.Drawing.Color.Transparent;
            this.btnTKB.BorderRadius = 10;
            this.btnTKB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTKB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTKB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTKB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTKB.FillColor = System.Drawing.Color.Transparent;
            this.btnTKB.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnTKB.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTKB.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnTKB.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTKB.Location = new System.Drawing.Point(10, 165);
            this.btnTKB.Name = "btnTKB";
            this.btnTKB.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTKB.Size = new System.Drawing.Size(260, 55);
            this.btnTKB.TabIndex = 3;
            this.btnTKB.Text = "Thời khóa biểu";
            this.btnTKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTKB.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnBT
            // 
            this.btnBT.BackColor = System.Drawing.Color.Transparent;
            this.btnBT.BorderRadius = 10;
            this.btnBT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBT.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBT.FillColor = System.Drawing.Color.Transparent;
            this.btnBT.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnBT.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBT.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnBT.ImageSize = new System.Drawing.Size(24, 24);
            this.btnBT.Location = new System.Drawing.Point(10, 110);
            this.btnBT.Name = "btnBT";
            this.btnBT.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBT.Size = new System.Drawing.Size(260, 55);
            this.btnBT.TabIndex = 2;
            this.btnBT.Text = "Kiểm tra - đánh giá";
            this.btnBT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBT.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.BorderRadius = 10;
            this.btnInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInfo.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnInfo.ImageSize = new System.Drawing.Size(24, 24);
            this.btnInfo.Location = new System.Drawing.Point(10, 55);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInfo.Size = new System.Drawing.Size(260, 55);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Thông tin cá nhân";
            this.btnInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInfo.TextOffset = new System.Drawing.Point(15, 0);
            this.btnInfo.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.Transparent;
            this.btnThongBao.BorderRadius = 10;
            this.btnThongBao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongBao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongBao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongBao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnThongBao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongBao.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnThongBao.ImageSize = new System.Drawing.Size(24, 24);
            this.btnThongBao.Location = new System.Drawing.Point(10, 0);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThongBao.Size = new System.Drawing.Size(260, 55);
            this.btnThongBao.TabIndex = 0;
            this.btnThongBao.Text = "Thông báo";
            this.btnThongBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongBao.TextOffset = new System.Drawing.Point(15, 0);
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
            this.pnlLogo.Size = new System.Drawing.Size(280, 209);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblSchoolName.Location = new System.Drawing.Point(41, 159);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(199, 32);
            this.lblSchoolName.TabIndex = 1;
            this.lblSchoolName.Text = "TRƯỜNG THPT ABC";
            this.lblSchoolName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::QuanLyTruongHoc.Properties.Resources.defautImage;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(66, 17);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(149, 138);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.Controls.Add(this.pnlContent);
            this.pnlMainScreen.Controls.Add(this.pnlTop);
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.Location = new System.Drawing.Point(280, 40);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(1640, 1040);
            this.pnlMainScreen.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.pnlContent.Controls.Add(this.ucKiemTra1);
            this.pnlContent.Controls.Add(this.ucXinNghi1);
            this.pnlContent.Controls.Add(this.ucKQHT1);
            this.pnlContent.Controls.Add(this.ucTKB1);
            this.pnlContent.Controls.Add(this.ucInfoHS1);
            this.pnlContent.Controls.Add(this.ucThongBao1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1640, 960);
            this.pnlContent.TabIndex = 1;
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
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1640, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 22);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(141, 39);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Thông báo";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblUserName.Location = new System.Drawing.Point(1435, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(127, 27);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Văn A";
            // 
            // picUserAvatar
            // 
            this.picUserAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picUserAvatar.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Boy;
            this.picUserAvatar.ImageRotate = 0F;
            this.picUserAvatar.Location = new System.Drawing.Point(1577, 20);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picUserAvatar.Size = new System.Drawing.Size(50, 50);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserAvatar.TabIndex = 0;
            this.picUserAvatar.TabStop = false;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 18;
            // 
            // ucKiemTra1
            // 
            this.ucKiemTra1.BackColor = System.Drawing.Color.White;
            this.ucKiemTra1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiemTra1.Location = new System.Drawing.Point(20, 20);
            this.ucKiemTra1.Name = "ucKiemTra1";
            this.ucKiemTra1.Size = new System.Drawing.Size(1600, 920);
            this.ucKiemTra1.TabIndex = 4;
            // 
            // ucXinNghi1
            // 
            this.ucXinNghi1.AutoScroll = true;
            this.ucXinNghi1.BackColor = System.Drawing.Color.White;
            this.ucXinNghi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucXinNghi1.Location = new System.Drawing.Point(20, 20);
            this.ucXinNghi1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucXinNghi1.Name = "ucXinNghi1";
            this.ucXinNghi1.Size = new System.Drawing.Size(1600, 920);
            this.ucXinNghi1.TabIndex = 3;
            // 
            // ucKQHT1
            // 
            this.ucKQHT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKQHT1.Location = new System.Drawing.Point(20, 20);
            this.ucKQHT1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucKQHT1.Name = "ucKQHT1";
            this.ucKQHT1.Size = new System.Drawing.Size(1600, 920);
            this.ucKQHT1.TabIndex = 2;
            this.ucKQHT1.Visible = false;
            // 
            // ucTKB1
            // 
            this.ucTKB1.BackColor = System.Drawing.Color.White;
            this.ucTKB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTKB1.Location = new System.Drawing.Point(20, 20);
            this.ucTKB1.Margin = new System.Windows.Forms.Padding(1842, 5707, 1842, 5707);
            this.ucTKB1.Name = "ucTKB1";
            this.ucTKB1.Size = new System.Drawing.Size(1600, 920);
            this.ucTKB1.TabIndex = 0;
            this.ucTKB1.Visible = false;
            // 
            // ucInfoHS1
            // 
            this.ucInfoHS1.AutoScroll = true;
            this.ucInfoHS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ucInfoHS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInfoHS1.Location = new System.Drawing.Point(20, 20);
            this.ucInfoHS1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ucInfoHS1.Name = "ucInfoHS1";
            this.ucInfoHS1.Size = new System.Drawing.Size(1600, 920);
            this.ucInfoHS1.TabIndex = 1;
            this.ucInfoHS1.Visible = false;
            // 
            // ucThongBao1
            // 
            this.ucThongBao1.BackColor = System.Drawing.Color.White;
            this.ucThongBao1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucThongBao1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucThongBao1.Location = new System.Drawing.Point(20, 20);
            this.ucThongBao1.Margin = new System.Windows.Forms.Padding(4);
            this.ucThongBao1.Name = "ucThongBao1";
            this.ucThongBao1.Size = new System.Drawing.Size(1600, 920);
            this.ucThongBao1.TabIndex = 0;
            // 
            // frmHS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainScreen);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmHS";
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
            this.pnlMainScreen.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            this.ResumeLayout(false);
            btnThongBao.Click += btnThongBao_Click;
            btnInfo.Click += btnInfo_Click;
            btnTKB.Click += btnTKB_Click;
            btnKQHT.Click += btnKQHT_Click;
            btnReports.Click += btnReports_Click;
            btnBT.Click += btnBT_Click;


        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMaximize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLeft;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTop;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLogo;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMenu;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchoolName;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnThongBao;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnKQHT;
        private Guna.UI2.WinForms.Guna2Button btnTKB;
        private Guna.UI2.WinForms.Guna2Button btnBT;
        private Guna.UI2.WinForms.Guna2Button btnInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picUserAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageTitle;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlSubSettings;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private GUI.Controls.ucThongBao ucThongBao1;
        private GUI.Controls.ucInfoHS ucInfoHS1;
        private GUI.Controls.ucTKB ucTKB1;
        private GUI.Controls.ucKQHT ucKQHT1;
        private GUI.Controls.ucXinNghi ucXinNghi1;
        private GUI.Controls.ucKiemTra ucKiemTra1;


    }
}

