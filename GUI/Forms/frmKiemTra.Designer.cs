namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmKiemTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemTra));
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDong = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnResize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnMinimum = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNavigation = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.chkMarkForReview = new Guna.UI2.WinForms.Guna2CheckBox();
            this.progressExam = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlExamHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblExamSummary = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.flowQuestionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblQuestionMap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelLegend = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLegendAnswered = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelAnswered = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLegendMarked = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelMarked = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLegendCurrent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelCurrent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLegendUnanswered = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelUnanswered = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblExamTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlTimer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTimerValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.imgTimer = new Guna.UI2.WinForms.Guna2PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlTitleBar.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlExamHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.pnlTitleBar.Controls.Add(this.lblFormTitle);
            this.pnlTitleBar.Controls.Add(this.btnDong);
            this.pnlTitleBar.Controls.Add(this.btnResize);
            this.pnlTitleBar.Controls.Add(this.btnMinimum);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1455, 50);
            this.pnlTitleBar.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(12, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblFormTitle.Size = new System.Drawing.Size(87, 27);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Kiểm tra";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BorderThickness = 1;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1414, 15);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDong.Size = new System.Drawing.Size(20, 20);
            this.btnDong.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnDong, "Đóng");
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.BorderThickness = 1;
            this.btnResize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.btnResize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResize.ForeColor = System.Drawing.Color.White;
            this.btnResize.Location = new System.Drawing.Point(1389, 15);
            this.btnResize.Name = "btnResize";
            this.btnResize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnResize.Size = new System.Drawing.Size(20, 20);
            this.btnResize.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnResize, "Phóng to");
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnMinimum
            // 
            this.btnMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimum.BorderThickness = 1;
            this.btnMinimum.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimum.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimum.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.btnMinimum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimum.ForeColor = System.Drawing.Color.White;
            this.btnMinimum.Location = new System.Drawing.Point(1363, 15);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnMinimum.Size = new System.Drawing.Size(20, 20);
            this.btnMinimum.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnMinimum, "Thu nhỏ");
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlNavigation);
            this.pnlContainer.Controls.Add(this.pnlExamHeader);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 50);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1455, 844);
            this.pnlContainer.TabIndex = 2;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlNavigation.BorderThickness = 1;
            this.pnlNavigation.Controls.Add(this.btnPrev);
            this.pnlNavigation.Controls.Add(this.chkMarkForReview);
            this.pnlNavigation.Controls.Add(this.progressExam);
            this.pnlNavigation.Controls.Add(this.btnSubmit);
            this.pnlNavigation.Controls.Add(this.btnNext);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.FillColor = System.Drawing.Color.White;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 784);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Padding = new System.Windows.Forms.Padding(20);
            this.pnlNavigation.Size = new System.Drawing.Size(1455, 60);
            this.pnlNavigation.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.BorderRadius = 18;
            this.btnPrev.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrev.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrev.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Location = new System.Drawing.Point(88, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(120, 36);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Câu trước";
            // 
            // chkMarkForReview
            // 
            this.chkMarkForReview.AutoSize = true;
            this.chkMarkForReview.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.chkMarkForReview.CheckedState.BorderRadius = 0;
            this.chkMarkForReview.CheckedState.BorderThickness = 0;
            this.chkMarkForReview.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.chkMarkForReview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMarkForReview.Location = new System.Drawing.Point(484, 20);
            this.chkMarkForReview.Name = "chkMarkForReview";
            this.chkMarkForReview.Size = new System.Drawing.Size(177, 25);
            this.chkMarkForReview.TabIndex = 4;
            this.chkMarkForReview.Text = "Đánh dấu xem lại sau";
            this.chkMarkForReview.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkMarkForReview.UncheckedState.BorderRadius = 0;
            this.chkMarkForReview.UncheckedState.BorderThickness = 0;
            this.chkMarkForReview.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // progressExam
            // 
            this.progressExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressExam.BorderRadius = 4;
            this.progressExam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.progressExam.Location = new System.Drawing.Point(674, 26);
            this.progressExam.Name = "progressExam";
            this.progressExam.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.progressExam.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.progressExam.Size = new System.Drawing.Size(636, 10);
            this.progressExam.TabIndex = 3;
            this.progressExam.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.progressExam.Value = 30;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BorderRadius = 18;
            this.btnSubmit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSubmit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSubmit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(50)))));
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(1315, 12);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Nộp bài";
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 18;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(238, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(149, 36);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Câu tiếp theo";
            // 
            // pnlExamHeader
            // 
            this.pnlExamHeader.AutoSize = true;
            this.pnlExamHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlExamHeader.Controls.Add(this.lblExamSummary);
            this.pnlExamHeader.Controls.Add(this.pnlContent);
            this.pnlExamHeader.Controls.Add(this.lblExamTitle);
            this.pnlExamHeader.Controls.Add(this.pnlTimer);
            this.pnlExamHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExamHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlExamHeader.Name = "pnlExamHeader";
            this.pnlExamHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlExamHeader.Size = new System.Drawing.Size(1455, 787);
            this.pnlExamHeader.TabIndex = 0;
            // 
            // lblExamSummary
            // 
            this.lblExamSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblExamSummary.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblExamSummary.Location = new System.Drawing.Point(15, 61);
            this.lblExamSummary.Name = "lblExamSummary";
            this.lblExamSummary.Size = new System.Drawing.Size(259, 21);
            this.lblExamSummary.TabIndex = 2;
            this.lblExamSummary.Text = "Lớp 10A1 | 20 câu hỏi | 30 phút | 10 điểm";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlSidebar);
            this.pnlContent.Controls.Add(this.pnlMain);
            this.pnlContent.Location = new System.Drawing.Point(15, 88);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1455, 1446);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlSidebar.BorderThickness = 1;
            this.pnlSidebar.Controls.Add(this.flowQuestionButtons);
            this.pnlSidebar.Controls.Add(this.lblQuestionMap);
            this.pnlSidebar.Controls.Add(this.panelLegend);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.White;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSidebar.Size = new System.Drawing.Size(364, 1446);
            this.pnlSidebar.TabIndex = 3;
            // 
            // flowQuestionButtons
            // 
            this.flowQuestionButtons.AutoScroll = true;
            this.flowQuestionButtons.BackColor = System.Drawing.Color.White;
            this.flowQuestionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowQuestionButtons.Location = new System.Drawing.Point(15, 115);
            this.flowQuestionButtons.Name = "flowQuestionButtons";
            this.flowQuestionButtons.Padding = new System.Windows.Forms.Padding(5);
            this.flowQuestionButtons.Size = new System.Drawing.Size(334, 1316);
            this.flowQuestionButtons.TabIndex = 2;
            // 
            // lblQuestionMap
            // 
            this.lblQuestionMap.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuestionMap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestionMap.Location = new System.Drawing.Point(15, 92);
            this.lblQuestionMap.Name = "lblQuestionMap";
            this.lblQuestionMap.Size = new System.Drawing.Size(334, 23);
            this.lblQuestionMap.TabIndex = 0;
            this.lblQuestionMap.Text = "Sơ đồ câu hỏi";
            this.lblQuestionMap.Click += new System.EventHandler(this.lblQuestionMap_Click);
            // 
            // panelLegend
            // 
            this.panelLegend.BackColor = System.Drawing.Color.White;
            this.panelLegend.Controls.Add(this.lblLegendAnswered);
            this.panelLegend.Controls.Add(this.panelAnswered);
            this.panelLegend.Controls.Add(this.lblLegendMarked);
            this.panelLegend.Controls.Add(this.panelMarked);
            this.panelLegend.Controls.Add(this.lblLegendCurrent);
            this.panelLegend.Controls.Add(this.panelCurrent);
            this.panelLegend.Controls.Add(this.lblLegendUnanswered);
            this.panelLegend.Controls.Add(this.panelUnanswered);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLegend.Location = new System.Drawing.Point(15, 15);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(334, 77);
            this.panelLegend.TabIndex = 1;
            // 
            // lblLegendAnswered
            // 
            this.lblLegendAnswered.BackColor = System.Drawing.Color.Transparent;
            this.lblLegendAnswered.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendAnswered.Location = new System.Drawing.Point(182, 19);
            this.lblLegendAnswered.Name = "lblLegendAnswered";
            this.lblLegendAnswered.Size = new System.Drawing.Size(46, 21);
            this.lblLegendAnswered.TabIndex = 7;
            this.lblLegendAnswered.Text = "Đã làm";
            // 
            // panelAnswered
            // 
            this.panelAnswered.BackColor = System.Drawing.Color.Transparent;
            this.panelAnswered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.panelAnswered.BorderRadius = 8;
            this.panelAnswered.BorderThickness = 1;
            this.panelAnswered.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelAnswered.Location = new System.Drawing.Point(162, 18);
            this.panelAnswered.Name = "panelAnswered";
            this.panelAnswered.Size = new System.Drawing.Size(16, 16);
            this.panelAnswered.TabIndex = 6;
            // 
            // lblLegendMarked
            // 
            this.lblLegendMarked.BackColor = System.Drawing.Color.Transparent;
            this.lblLegendMarked.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendMarked.Location = new System.Drawing.Point(182, 47);
            this.lblLegendMarked.Name = "lblLegendMarked";
            this.lblLegendMarked.Size = new System.Drawing.Size(109, 21);
            this.lblLegendMarked.TabIndex = 5;
            this.lblLegendMarked.Text = "Đánh dấu xem lại";
            // 
            // panelMarked
            // 
            this.panelMarked.BackColor = System.Drawing.Color.Transparent;
            this.panelMarked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.panelMarked.BorderRadius = 8;
            this.panelMarked.BorderThickness = 1;
            this.panelMarked.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(230)))));
            this.panelMarked.Location = new System.Drawing.Point(162, 46);
            this.panelMarked.Name = "panelMarked";
            this.panelMarked.Size = new System.Drawing.Size(16, 16);
            this.panelMarked.TabIndex = 4;
            // 
            // lblLegendCurrent
            // 
            this.lblLegendCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblLegendCurrent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendCurrent.Location = new System.Drawing.Point(26, 47);
            this.lblLegendCurrent.Name = "lblLegendCurrent";
            this.lblLegendCurrent.Size = new System.Drawing.Size(76, 21);
            this.lblLegendCurrent.TabIndex = 3;
            this.lblLegendCurrent.Text = "Câu hiện tại";
            // 
            // panelCurrent
            // 
            this.panelCurrent.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrent.BorderRadius = 8;
            this.panelCurrent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.panelCurrent.Location = new System.Drawing.Point(6, 46);
            this.panelCurrent.Name = "panelCurrent";
            this.panelCurrent.Size = new System.Drawing.Size(16, 16);
            this.panelCurrent.TabIndex = 2;
            // 
            // lblLegendUnanswered
            // 
            this.lblLegendUnanswered.BackColor = System.Drawing.Color.Transparent;
            this.lblLegendUnanswered.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendUnanswered.Location = new System.Drawing.Point(26, 19);
            this.lblLegendUnanswered.Name = "lblLegendUnanswered";
            this.lblLegendUnanswered.Size = new System.Drawing.Size(74, 21);
            this.lblLegendUnanswered.TabIndex = 1;
            this.lblLegendUnanswered.Text = "Chưa trả lời";
            // 
            // panelUnanswered
            // 
            this.panelUnanswered.BackColor = System.Drawing.Color.Transparent;
            this.panelUnanswered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelUnanswered.BorderRadius = 8;
            this.panelUnanswered.BorderThickness = 1;
            this.panelUnanswered.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelUnanswered.Location = new System.Drawing.Point(6, 18);
            this.panelUnanswered.Name = "panelUnanswered";
            this.panelUnanswered.Size = new System.Drawing.Size(16, 16);
            this.panelUnanswered.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMain.BorderRadius = 15;
            this.pnlMain.Location = new System.Drawing.Point(370, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1155, 684);
            this.pnlMain.TabIndex = 3;
            // 
            // lblExamTitle
            // 
            this.lblExamTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblExamTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblExamTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblExamTitle.Location = new System.Drawing.Point(20, 15);
            this.lblExamTitle.Name = "lblExamTitle";
            this.lblExamTitle.Size = new System.Drawing.Size(251, 27);
            this.lblExamTitle.TabIndex = 1;
            this.lblExamTitle.Text = "Kiểm tra 15 phút - Toán học";
            // 
            // pnlTimer
            // 
            this.pnlTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pnlTimer.BorderRadius = 20;
            this.pnlTimer.BorderThickness = 1;
            this.pnlTimer.Controls.Add(this.lblTimerValue);
            this.pnlTimer.Controls.Add(this.imgTimer);
            this.pnlTimer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlTimer.Location = new System.Drawing.Point(1236, 20);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(200, 40);
            this.pnlTimer.TabIndex = 0;
            // 
            // lblTimerValue
            // 
            this.lblTimerValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTimerValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTimerValue.Location = new System.Drawing.Point(50, 8);
            this.lblTimerValue.Name = "lblTimerValue";
            this.lblTimerValue.Size = new System.Drawing.Size(65, 23);
            this.lblTimerValue.TabIndex = 1;
            this.lblTimerValue.Text = "00:30:00";
            // 
            // imgTimer
            // 
            this.imgTimer.BackColor = System.Drawing.Color.Transparent;
            this.imgTimer.Image = global::QuanLyTruongHoc.Properties.Resources.clock_icon;
            this.imgTimer.ImageRotate = 0F;
            this.imgTimer.Location = new System.Drawing.Point(15, 8);
            this.imgTimer.Name = "imgTimer";
            this.imgTimer.Size = new System.Drawing.Size(24, 24);
            this.imgTimer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTimer.TabIndex = 0;
            this.imgTimer.TabStop = false;
            // 
            // frmKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1455, 894);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKiemTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.pnlExamHeader.ResumeLayout(false);
            this.pnlExamHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.pnlTimer.ResumeLayout(false);
            this.pnlTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2CircleButton btnDong;
        private Guna.UI2.WinForms.Guna2CircleButton btnResize;
        private Guna.UI2.WinForms.Guna2CircleButton btnMinimum;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlExamHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlNavigation;
        private Guna.UI2.WinForms.Guna2Panel pnlTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimerValue;
        private Guna.UI2.WinForms.Guna2PictureBox imgTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblExamSummary;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblExamTitle;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel flowQuestionButtons;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2ProgressBar progressExam;
        private Guna.UI2.WinForms.Guna2CheckBox chkMarkForReview;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
        private Guna.UI2.WinForms.Guna2Panel panelLegend;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLegendAnswered;
        private Guna.UI2.WinForms.Guna2Panel panelAnswered;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLegendMarked;
        private Guna.UI2.WinForms.Guna2Panel panelMarked;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLegendCurrent;
        private Guna.UI2.WinForms.Guna2Panel panelCurrent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLegendUnanswered;
        private Guna.UI2.WinForms.Guna2Panel panelUnanswered;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionMap;
    }
}