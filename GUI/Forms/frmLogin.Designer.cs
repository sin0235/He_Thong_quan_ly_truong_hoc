using Guna.UI2.WinForms;
using System.Drawing;

namespace QuanLyTruongHoc
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSchoolName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonCloseLogin = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlLogin = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblForgotAcc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblError = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.chkShowPw = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblWelcomeText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSystemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnFacebook = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnTwitter = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnInstagram = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblCopyright = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlMainScreen.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlMainScreen;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pnlMainScreen, "pnlMainScreen");
            this.pnlMainScreen.BorderRadius = 15;
            this.pnlMainScreen.Controls.Add(this.lblSchoolName);
            this.pnlMainScreen.Controls.Add(this.guna2CircleButtonCloseLogin);
            this.pnlMainScreen.Controls.Add(this.pnlLogin);
            this.pnlMainScreen.Controls.Add(this.lblWelcomeText);
            this.pnlMainScreen.Controls.Add(this.lblSystemName);
            this.pnlMainScreen.Controls.Add(this.btnFacebook);
            this.pnlMainScreen.Controls.Add(this.btnTwitter);
            this.pnlMainScreen.Controls.Add(this.btnInstagram);
            this.pnlMainScreen.Controls.Add(this.lblCopyright);
            this.pnlMainScreen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(219)))));
            this.pnlMainScreen.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.pnlMainScreen.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainScreen_Paint);
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblSchoolName, "lblSchoolName");
            this.lblSchoolName.ForeColor = System.Drawing.Color.White;
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2CircleButtonCloseLogin
            // 
            this.guna2CircleButtonCloseLogin.Animated = true;
            this.guna2CircleButtonCloseLogin.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButtonCloseLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonCloseLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonCloseLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            resources.ApplyResources(this.guna2CircleButtonCloseLogin, "guna2CircleButtonCloseLogin");
            this.guna2CircleButtonCloseLogin.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonCloseLogin.Name = "guna2CircleButtonCloseLogin";
            this.guna2CircleButtonCloseLogin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonCloseLogin.Click += new System.EventHandler(this.guna2CircleButtonCloseLogin_Click);
            // 
            // pnlLogin
            // 
            resources.ApplyResources(this.pnlLogin, "pnlLogin");
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLogin.BorderRadius = 30;
            this.pnlLogin.Controls.Add(this.guna2Separator1);
            this.pnlLogin.Controls.Add(this.picLogo);
            this.pnlLogin.Controls.Add(this.lblForgotAcc);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.chkShowPw);
            this.pnlLogin.Controls.Add(this.txtPW);
            this.pnlLogin.Controls.Add(this.txtUserName);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlLogin.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.ShadowDecoration.BorderRadius = 30;
            this.pnlLogin.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlLogin.ShadowDecoration.Depth = 50;
            this.pnlLogin.ShadowDecoration.Enabled = true;
            this.pnlLogin.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8, 8, 16, 16);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.guna2Separator1.FillThickness = 2;
            resources.ApplyResources(this.guna2Separator1, "guna2Separator1");
            this.guna2Separator1.Name = "guna2Separator1";
            // 
            // picLogo
            // 
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::QuanLyTruongHoc.Properties.Resources.school;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Name = "picLogo";
            this.picLogo.ShadowDecoration.BorderRadius = 50;
            this.picLogo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(219)))));
            this.picLogo.ShadowDecoration.Depth = 15;
            this.picLogo.ShadowDecoration.Enabled = true;
            this.picLogo.TabStop = false;
            this.picLogo.UseTransparentBackground = true;
            // 
            // lblForgotAcc
            // 
            resources.ApplyResources(this.lblForgotAcc, "lblForgotAcc");
            this.lblForgotAcc.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.lblForgotAcc.Name = "lblForgotAcc";
            // 
            // lblError
            // 
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            this.lblError.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BorderRadius = 25;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkShowPw
            // 
            resources.ApplyResources(this.chkShowPw, "chkShowPw");
            this.chkShowPw.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.chkShowPw.CheckedState.BorderRadius = 2;
            this.chkShowPw.CheckedState.BorderThickness = 0;
            this.chkShowPw.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.chkShowPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.chkShowPw.Name = "chkShowPw";
            this.chkShowPw.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chkShowPw.UncheckedState.BorderRadius = 2;
            this.chkShowPw.UncheckedState.BorderThickness = 1;
            this.chkShowPw.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkShowPw.CheckedChanged += new System.EventHandler(this.chbShowPw_CheckedChanged);
            // 
            // txtPW
            // 
            this.txtPW.Animated = true;
            this.txtPW.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.txtPW.BackColor = System.Drawing.Color.Transparent;
            this.txtPW.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtPW.BorderRadius = 25;
            this.txtPW.BorderThickness = 2;
            this.txtPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPW.DefaultText = "";
            this.txtPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            resources.ApplyResources(this.txtPW, "txtPW");
            this.txtPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtPW.IconRight = ((System.Drawing.Image)(resources.GetObject("txtPW.IconRight")));
            this.txtPW.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtPW.IconRightSize = new System.Drawing.Size(28, 28);
            this.txtPW.Name = "txtPW";
            this.txtPW.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtPW.PlaceholderText = "Password";
            this.txtPW.SelectedText = "";
            this.txtPW.TextOffset = new System.Drawing.Point(14, 0);
            this.txtPW.UseSystemPasswordChar = true;
            this.txtPW.TextChanged += new System.EventHandler(this.txtPW_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Animated = true;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtUserName.BorderRadius = 25;
            this.txtUserName.BorderThickness = 2;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtUserName.IconRight = ((System.Drawing.Image)(resources.GetObject("txtUserName.IconRight")));
            this.txtUserName.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtUserName.IconRightSize = new System.Drawing.Size(28, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUserName.PlaceholderText = "Username";
            this.txtUserName.SelectedText = "";
            this.txtUserName.TextOffset = new System.Drawing.Point(14, 0);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.lblLogin.Name = "lblLogin";
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblWelcomeText, "lblWelcomeText");
            this.lblWelcomeText.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemName
            // 
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblSystemName, "lblSystemName");
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFacebook
            // 
            this.btnFacebook.BackColor = System.Drawing.Color.Transparent;
            this.btnFacebook.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnFacebook.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFacebook.Image = global::QuanLyTruongHoc.Properties.Resources.facebook;
            this.btnFacebook.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnFacebook.ImageRotate = 0F;
            this.btnFacebook.ImageSize = new System.Drawing.Size(28, 28);
            resources.ApplyResources(this.btnFacebook, "btnFacebook");
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            // 
            // btnTwitter
            // 
            this.btnTwitter.BackColor = System.Drawing.Color.Transparent;
            this.btnTwitter.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnTwitter.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTwitter.Image = global::QuanLyTruongHoc.Properties.Resources.twitter;
            this.btnTwitter.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnTwitter.ImageRotate = 0F;
            this.btnTwitter.ImageSize = new System.Drawing.Size(28, 28);
            resources.ApplyResources(this.btnTwitter, "btnTwitter");
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            // 
            // btnInstagram
            // 
            this.btnInstagram.BackColor = System.Drawing.Color.Transparent;
            this.btnInstagram.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnInstagram.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnInstagram.Image = global::QuanLyTruongHoc.Properties.Resources.instagram;
            this.btnInstagram.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnInstagram.ImageRotate = 0F;
            this.btnInstagram.ImageSize = new System.Drawing.Size(28, 28);
            resources.ApplyResources(this.btnInstagram, "btnInstagram");
            this.btnInstagram.Name = "btnInstagram";
            this.btnInstagram.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblCopyright, "lblCopyright");
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCopyright.Name = "lblCopyright";
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.pnlMainScreen.ResumeLayout(false);
            this.pnlMainScreen.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogin;
        private Guna2HtmlLabel lblSchoolName;
        private Guna2DragControl guna2DragControl1;
        private Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtPW;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPw;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblError;
        private Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblForgotAcc;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonCloseLogin;
        private Guna2CustomGradientPanel pnlLogin;
        private Guna2Separator guna2Separator1;
        private Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcomeText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSystemName;
        private Guna.UI2.WinForms.Guna2ImageButton btnFacebook;
        private Guna.UI2.WinForms.Guna2ImageButton btnTwitter;
        private Guna.UI2.WinForms.Guna2ImageButton btnInstagram;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCopyright;
    }
}