namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmChangePW
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePW));
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblCurrentPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNewPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblConfirmPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.passwordStrengthBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblPasswordHint = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnShowCurrentPassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowConfirmPassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowNewPassword = new Guna.UI2.WinForms.Guna2Button();
            this.txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.iconCurrentPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.iconNewPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.iconConfirmPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlTitleBar.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconConfirmPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BorderColor = System.Drawing.Color.DimGray;
            this.pnlTitleBar.BorderThickness = 1;
            this.pnlTitleBar.Controls.Add(this.lblFormTitle);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonClose);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMaximize);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMinimize);
            resources.ApplyResources(this.pnlTitleBar, "pnlTitleBar");
            this.pnlTitleBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlTitleBar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(123)))), ((int)(((byte)(213)))));
            this.pnlTitleBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlTitleBar.Name = "pnlTitleBar";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFormTitle, "lblFormTitle");
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Name = "lblFormTitle";
            // 
            // guna2CircleButtonClose
            // 
            resources.ApplyResources(this.guna2CircleButtonClose, "guna2CircleButtonClose");
            this.guna2CircleButtonClose.Animated = true;
            this.guna2CircleButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButtonClose.BorderThickness = 1;
            this.guna2CircleButtonClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.guna2CircleButtonClose.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            this.guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            // 
            // guna2CircleButtonMaximize
            // 
            resources.ApplyResources(this.guna2CircleButtonMaximize, "guna2CircleButtonMaximize");
            this.guna2CircleButtonMaximize.Animated = true;
            this.guna2CircleButtonMaximize.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButtonMaximize.BorderThickness = 1;
            this.guna2CircleButtonMaximize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMaximize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMaximize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(68)))));
            this.guna2CircleButtonMaximize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            this.guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            // 
            // guna2CircleButtonMinimize
            // 
            resources.ApplyResources(this.guna2CircleButtonMinimize, "guna2CircleButtonMinimize");
            this.guna2CircleButtonMinimize.Animated = true;
            this.guna2CircleButtonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButtonMinimize.BorderThickness = 1;
            this.guna2CircleButtonMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(202)))), ((int)(((byte)(78)))));
            this.guna2CircleButtonMinimize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            this.guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblCurrentPassword, "lblCurrentPassword");
            this.lblCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblNewPassword, "lblNewPassword");
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNewPassword.Name = "lblNewPassword";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblConfirmPassword, "lblConfirmPassword");
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Animated = true;
            this.btnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.BorderRadius = 10;
            this.btnChangePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePassword.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(123)))), ((int)(((byte)(213)))));
            this.btnChangePassword.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnChangePassword, "btnChangePassword");
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ShadowDecoration.BorderRadius = 10;
            this.btnChangePassword.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(216)))), ((int)(((byte)(236)))));
            this.btnChangePassword.ShadowDecoration.Depth = 5;
            this.btnChangePassword.ShadowDecoration.Enabled = true;
            this.btnChangePassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 6, 6);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContainer.BorderRadius = 15;
            this.pnlContainer.Controls.Add(this.passwordStrengthBar);
            this.pnlContainer.Controls.Add(this.btnShowCurrentPassword);
            this.pnlContainer.Controls.Add(this.btnShowConfirmPassword);
            this.pnlContainer.Controls.Add(this.btnShowNewPassword);
            this.pnlContainer.Controls.Add(this.lblCurrentPassword);
            this.pnlContainer.Controls.Add(this.txtCurrentPassword);
            this.pnlContainer.Controls.Add(this.lblNewPassword);
            this.pnlContainer.Controls.Add(this.txtNewPassword);
            this.pnlContainer.Controls.Add(this.lblConfirmPassword);
            this.pnlContainer.Controls.Add(this.txtConfirmPassword);
            this.pnlContainer.Controls.Add(this.lblPasswordHint);
            this.pnlContainer.Controls.Add(this.btnChangePassword);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pnlContainer, "pnlContainer");
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.ShadowDecoration.BorderRadius = 15;
            this.pnlContainer.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlContainer.ShadowDecoration.Depth = 10;
            this.pnlContainer.ShadowDecoration.Enabled = true;
            this.pnlContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 5, 10, 10);
            // 
            // passwordStrengthBar
            // 
            this.passwordStrengthBar.BorderRadius = 5;
            resources.ApplyResources(this.passwordStrengthBar, "passwordStrengthBar");
            this.passwordStrengthBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.passwordStrengthBar.Name = "passwordStrengthBar";
            this.passwordStrengthBar.ProgressColor = System.Drawing.Color.Red;
            this.passwordStrengthBar.ProgressColor2 = System.Drawing.Color.Red;
            this.passwordStrengthBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblPasswordHint
            // 
            resources.ApplyResources(this.lblPasswordHint, "lblPasswordHint");
            this.lblPasswordHint.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblPasswordHint.Name = "lblPasswordHint";
            this.lblPasswordHint.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnShowCurrentPassword
            // 
            this.btnShowCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnShowCurrentPassword.BorderColor = System.Drawing.Color.Transparent;
            this.btnShowCurrentPassword.BorderRadius = 8;
            this.btnShowCurrentPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowCurrentPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowCurrentPassword.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnShowCurrentPassword, "btnShowCurrentPassword");
            this.btnShowCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowCurrentPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnShowCurrentPassword.Image = global::QuanLyTruongHoc.Properties.Resources.eye_closed;
            this.btnShowCurrentPassword.ImageSize = new System.Drawing.Size(25, 25);
            this.btnShowCurrentPassword.Name = "btnShowCurrentPassword";
            this.btnShowCurrentPassword.Click += new System.EventHandler(this.btnShowCurrentPassword_Click);
            // 
            // btnShowConfirmPassword
            // 
            this.btnShowConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnShowConfirmPassword.BorderColor = System.Drawing.Color.Transparent;
            this.btnShowConfirmPassword.BorderRadius = 8;
            this.btnShowConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowConfirmPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowConfirmPassword.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnShowConfirmPassword, "btnShowConfirmPassword");
            this.btnShowConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowConfirmPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnShowConfirmPassword.Image = global::QuanLyTruongHoc.Properties.Resources.eye_closed;
            this.btnShowConfirmPassword.ImageSize = new System.Drawing.Size(25, 25);
            this.btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            this.btnShowConfirmPassword.Click += new System.EventHandler(this.btnShowConfirmPassword_Click);
            // 
            // btnShowNewPassword
            // 
            this.btnShowNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnShowNewPassword.BorderColor = System.Drawing.Color.Transparent;
            this.btnShowNewPassword.BorderRadius = 8;
            this.btnShowNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowNewPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowNewPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowNewPassword.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnShowNewPassword, "btnShowNewPassword");
            this.btnShowNewPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowNewPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnShowNewPassword.Image = global::QuanLyTruongHoc.Properties.Resources.eye_closed;
            this.btnShowNewPassword.ImageSize = new System.Drawing.Size(25, 25);
            this.btnShowNewPassword.Name = "btnShowNewPassword";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Animated = true;
            this.txtCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtCurrentPassword.BorderRadius = 8;
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.DefaultText = "";
            this.txtCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtCurrentPassword, "txtCurrentPassword");
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentPassword.IconLeft = global::QuanLyTruongHoc.Properties.Resources.lock_icon;
            this.txtCurrentPassword.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtCurrentPassword.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '●';
            this.txtCurrentPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCurrentPassword.PlaceholderText = "Nhập mật khẩu hiện tại";
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.ShadowDecoration.BorderRadius = 8;
            this.txtCurrentPassword.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtCurrentPassword.ShadowDecoration.Depth = 3;
            this.txtCurrentPassword.ShadowDecoration.Enabled = true;
            this.txtCurrentPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 4, 4);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Animated = true;
            this.txtNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtNewPassword.BorderRadius = 8;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtNewPassword, "txtNewPassword");
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.IconLeft = global::QuanLyTruongHoc.Properties.Resources.key_icon;
            this.txtNewPassword.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtNewPassword.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNewPassword.PlaceholderText = "Nhập mật khẩu mới";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.ShadowDecoration.BorderRadius = 8;
            this.txtNewPassword.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtNewPassword.ShadowDecoration.Depth = 3;
            this.txtNewPassword.ShadowDecoration.Enabled = true;
            this.txtNewPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 4, 4);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Animated = true;
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtConfirmPassword, "txtConfirmPassword");
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.IconLeft = global::QuanLyTruongHoc.Properties.Resources.confirm_icon;
            this.txtConfirmPassword.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtConfirmPassword.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu mới";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.ShadowDecoration.BorderRadius = 8;
            this.txtConfirmPassword.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtConfirmPassword.ShadowDecoration.Depth = 3;
            this.txtConfirmPassword.ShadowDecoration.Enabled = true;
            this.txtConfirmPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 4, 4);
            // 
            // iconCurrentPassword
            // 
            this.iconCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.iconCurrentPassword, "iconCurrentPassword");
            this.iconCurrentPassword.ImageRotate = 0F;
            this.iconCurrentPassword.Name = "iconCurrentPassword";
            this.iconCurrentPassword.TabStop = false;
            // 
            // iconNewPassword
            // 
            this.iconNewPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.iconNewPassword, "iconNewPassword");
            this.iconNewPassword.ImageRotate = 0F;
            this.iconNewPassword.Name = "iconNewPassword";
            this.iconNewPassword.TabStop = false;
            // 
            // iconConfirmPassword
            // 
            this.iconConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.iconConfirmPassword, "iconConfirmPassword");
            this.iconConfirmPassword.ImageRotate = 0F;
            this.iconConfirmPassword.Name = "iconConfirmPassword";
            this.iconConfirmPassword.TabStop = false;
            // 
            // frmChangePW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChangePW";
            this.Load += new System.EventHandler(this.frmChangePW_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconConfirmPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMaximize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCurrentPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNewPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnChangePassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPasswordHint;
        private Guna.UI2.WinForms.Guna2PictureBox iconCurrentPassword;
        private Guna.UI2.WinForms.Guna2PictureBox iconNewPassword;
        private Guna.UI2.WinForms.Guna2PictureBox iconConfirmPassword;
        private Guna.UI2.WinForms.Guna2Button btnShowCurrentPassword;
        private Guna.UI2.WinForms.Guna2Button btnShowNewPassword;
        private Guna.UI2.WinForms.Guna2Button btnShowConfirmPassword;
        private Guna.UI2.WinForms.Guna2ProgressBar passwordStrengthBar;
    }
}
