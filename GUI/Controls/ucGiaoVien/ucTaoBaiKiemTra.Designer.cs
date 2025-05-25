namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    partial class ucTaoBaiKiemTra
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
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.tabControlMain = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabThongTinChung = new System.Windows.Forms.TabPage();
            this.lblNoteTimeLimit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblEndDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTestPeriod = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numAttemptsAllowed = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblAttemptsAllowed = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numDuration = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboTestType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTestType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblClass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboSubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSubject = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTestName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTestName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGeneralInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabCauHoi = new System.Windows.Forms.TabPage();
            this.panelQuestions = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoQuestions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnImportQuestions = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddEssayQuestion = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddMultipleChoiceQuestion = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuestionManagement = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabCauHinhDiem = new System.Windows.Forms.TabPage();
            this.panelGrading = new Guna.UI2.WinForms.Guna2Panel();
            this.chkRandomizeQuestions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkShowResultImmediately = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtGradingNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGradingNotes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numPassingScore = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblPassingScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGradingOptions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabXemTruoc = new System.Windows.Forms.TabPage();
            this.panelPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPreviewTest = new Guna.UI2.WinForms.Guna2Button();
            this.lblPreviewInstruction = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chkPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPreviewTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSaveDraft = new Guna.UI2.WinForms.Guna2Button();
            this.btnPublish = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabThongTinChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttemptsAllowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.tabCauHoi.SuspendLayout();
            this.panelQuestions.SuspendLayout();
            this.tabCauHinhDiem.SuspendLayout();
            this.panelGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPassingScore)).BeginInit();
            this.tabXemTruoc.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderColor = System.Drawing.Color.Black;
            this.panelMain.BorderRadius = 15;
            this.panelMain.BorderThickness = 1;
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FillColor = System.Drawing.Color.White;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1640, 960);
            this.panelMain.TabIndex = 2;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabThongTinChung);
            this.tabControlMain.Controls.Add(this.tabCauHoi);
            this.tabControlMain.Controls.Add(this.tabCauHinhDiem);
            this.tabControlMain.Controls.Add(this.tabXemTruoc);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.Location = new System.Drawing.Point(20, 20);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1600, 860);
            this.tabControlMain.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlMain.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControlMain.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlMain.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControlMain.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControlMain.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControlMain.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabControlMain.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabThongTinChung
            // 
            this.tabThongTinChung.BackColor = System.Drawing.Color.White;
            this.tabThongTinChung.Controls.Add(this.lblNoteTimeLimit);
            this.tabThongTinChung.Controls.Add(this.dtpEndDate);
            this.tabThongTinChung.Controls.Add(this.dtpStartDate);
            this.tabThongTinChung.Controls.Add(this.lblEndDate);
            this.tabThongTinChung.Controls.Add(this.lblStartDate);
            this.tabThongTinChung.Controls.Add(this.lblTestPeriod);
            this.tabThongTinChung.Controls.Add(this.numAttemptsAllowed);
            this.tabThongTinChung.Controls.Add(this.lblAttemptsAllowed);
            this.tabThongTinChung.Controls.Add(this.numDuration);
            this.tabThongTinChung.Controls.Add(this.lblDuration);
            this.tabThongTinChung.Controls.Add(this.cboTestType);
            this.tabThongTinChung.Controls.Add(this.lblTestType);
            this.tabThongTinChung.Controls.Add(this.txtDescription);
            this.tabThongTinChung.Controls.Add(this.lblDescription);
            this.tabThongTinChung.Controls.Add(this.cboClass);
            this.tabThongTinChung.Controls.Add(this.lblClass);
            this.tabThongTinChung.Controls.Add(this.cboSubject);
            this.tabThongTinChung.Controls.Add(this.lblSubject);
            this.tabThongTinChung.Controls.Add(this.txtTestName);
            this.tabThongTinChung.Controls.Add(this.lblTestName);
            this.tabThongTinChung.Controls.Add(this.lblGeneralInfo);
            this.tabThongTinChung.Location = new System.Drawing.Point(4, 44);
            this.tabThongTinChung.Name = "tabThongTinChung";
            this.tabThongTinChung.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTinChung.Size = new System.Drawing.Size(1592, 812);
            this.tabThongTinChung.TabIndex = 0;
            this.tabThongTinChung.Text = "Thông tin chung";
            // 
            // lblNoteTimeLimit
            // 
            this.lblNoteTimeLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblNoteTimeLimit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteTimeLimit.ForeColor = System.Drawing.Color.Gray;
            this.lblNoteTimeLimit.Location = new System.Drawing.Point(111, 353);
            this.lblNoteTimeLimit.Name = "lblNoteTimeLimit";
            this.lblNoteTimeLimit.Size = new System.Drawing.Size(363, 23);
            this.lblNoteTimeLimit.TabIndex = 21;
            this.lblNoteTimeLimit.Text = "* Đặt thời gian bằng 0 nếu không giới hạn thời gian";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 5;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(447, 498);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowUpDown = true;
            this.dtpEndDate.Size = new System.Drawing.Size(200, 36);
            this.dtpEndDate.TabIndex = 19;
            this.dtpEndDate.Value = new System.DateTime(2025, 5, 15, 23, 59, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 5;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(111, 490);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowUpDown = true;
            this.dtpStartDate.Size = new System.Drawing.Size(200, 36);
            this.dtpStartDate.TabIndex = 18;
            this.dtpStartDate.Value = new System.DateTime(2025, 5, 8, 7, 30, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(447, 442);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(127, 23);
            this.lblEndDate.TabIndex = 17;
            this.lblEndDate.Text = "Thời gian kết thúc";
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(111, 434);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(124, 23);
            this.lblStartDate.TabIndex = 16;
            this.lblStartDate.Text = "Thời gian bắt đầu";
            // 
            // lblTestPeriod
            // 
            this.lblTestPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblTestPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTestPeriod.Location = new System.Drawing.Point(95, 391);
            this.lblTestPeriod.Name = "lblTestPeriod";
            this.lblTestPeriod.Size = new System.Drawing.Size(199, 22);
            this.lblTestPeriod.TabIndex = 15;
            this.lblTestPeriod.Text = "2. Thời gian mở cho học sinh";
            // 
            // numAttemptsAllowed
            // 
            this.numAttemptsAllowed.BackColor = System.Drawing.Color.Transparent;
            this.numAttemptsAllowed.BorderRadius = 5;
            this.numAttemptsAllowed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numAttemptsAllowed.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAttemptsAllowed.Location = new System.Drawing.Point(447, 300);
            this.numAttemptsAllowed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAttemptsAllowed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAttemptsAllowed.Name = "numAttemptsAllowed";
            this.numAttemptsAllowed.Size = new System.Drawing.Size(124, 39);
            this.numAttemptsAllowed.TabIndex = 14;
            this.numAttemptsAllowed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAttemptsAllowed
            // 
            this.lblAttemptsAllowed.BackColor = System.Drawing.Color.Transparent;
            this.lblAttemptsAllowed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttemptsAllowed.Location = new System.Drawing.Point(447, 269);
            this.lblAttemptsAllowed.Name = "lblAttemptsAllowed";
            this.lblAttemptsAllowed.Size = new System.Drawing.Size(119, 23);
            this.lblAttemptsAllowed.TabIndex = 13;
            this.lblAttemptsAllowed.Text = "Số lần làm tối đa";
            // 
            // numDuration
            // 
            this.numDuration.BackColor = System.Drawing.Color.Transparent;
            this.numDuration.BorderRadius = 5;
            this.numDuration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numDuration.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDuration.Location = new System.Drawing.Point(111, 292);
            this.numDuration.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(124, 39);
            this.numDuration.TabIndex = 12;
            this.numDuration.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(111, 269);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(169, 23);
            this.lblDuration.TabIndex = 11;
            this.lblDuration.Text = "Thời gian làm bài (phút)";
            // 
            // cboTestType
            // 
            this.cboTestType.BackColor = System.Drawing.Color.Transparent;
            this.cboTestType.BorderRadius = 5;
            this.cboTestType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTestType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTestType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTestType.ItemHeight = 30;
            this.cboTestType.Items.AddRange(new object[] {
            "15 phút",
            "Giữa kỳ",
            "Cuối kỳ",
            "Bài tập về nhà"});
            this.cboTestType.Location = new System.Drawing.Point(447, 202);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(200, 36);
            this.cboTestType.TabIndex = 10;
            // 
            // lblTestType
            // 
            this.lblTestType.BackColor = System.Drawing.Color.Transparent;
            this.lblTestType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.Location = new System.Drawing.Point(447, 163);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(93, 23);
            this.lblTestType.TabIndex = 9;
            this.lblTestType.Text = "Loại kiểm tra";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(126, 606);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Hướng dẫn làm bài, mô tả...";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(1196, 182);
            this.txtDescription.TabIndex = 20;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(111, 569);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(182, 23);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Mô tả/Hướng dẫn làm bài";
            // 
            // cboClass
            // 
            this.cboClass.BackColor = System.Drawing.Color.Transparent;
            this.cboClass.BorderRadius = 5;
            this.cboClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClass.ItemHeight = 30;
            this.cboClass.Location = new System.Drawing.Point(447, 96);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(200, 36);
            this.cboClass.TabIndex = 7;
            // 
            // lblClass
            // 
            this.lblClass.BackColor = System.Drawing.Color.Transparent;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(447, 57);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(30, 23);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Lớp";
            // 
            // cboSubject
            // 
            this.cboSubject.BackColor = System.Drawing.Color.Transparent;
            this.cboSubject.BorderRadius = 5;
            this.cboSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubject.ItemHeight = 30;
            this.cboSubject.Location = new System.Drawing.Point(111, 202);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(200, 36);
            this.cboSubject.TabIndex = 5;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(111, 163);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(64, 23);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Môn học";
            // 
            // txtTestName
            // 
            this.txtTestName.BorderRadius = 5;
            this.txtTestName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestName.DefaultText = "";
            this.txtTestName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTestName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTestName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTestName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTestName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTestName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTestName.Location = new System.Drawing.Point(111, 96);
            this.txtTestName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.PlaceholderText = "Nhập tên bài kiểm tra";
            this.txtTestName.SelectedText = "";
            this.txtTestName.Size = new System.Drawing.Size(200, 36);
            this.txtTestName.TabIndex = 3;
            // 
            // lblTestName
            // 
            this.lblTestName.BackColor = System.Drawing.Color.Transparent;
            this.lblTestName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.Location = new System.Drawing.Point(111, 57);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(114, 23);
            this.lblTestName.TabIndex = 2;
            this.lblTestName.Text = "Tên bài kiểm tra";
            // 
            // lblGeneralInfo
            // 
            this.lblGeneralInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblGeneralInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblGeneralInfo.Location = new System.Drawing.Point(95, 26);
            this.lblGeneralInfo.Name = "lblGeneralInfo";
            this.lblGeneralInfo.Size = new System.Drawing.Size(146, 25);
            this.lblGeneralInfo.TabIndex = 1;
            this.lblGeneralInfo.Text = "1. Thông tin chung";
            // 
            // tabCauHoi
            // 
            this.tabCauHoi.BackColor = System.Drawing.Color.White;
            this.tabCauHoi.Controls.Add(this.panelQuestions);
            this.tabCauHoi.Controls.Add(this.btnImportQuestions);
            this.tabCauHoi.Controls.Add(this.btnAddEssayQuestion);
            this.tabCauHoi.Controls.Add(this.btnAddMultipleChoiceQuestion);
            this.tabCauHoi.Controls.Add(this.lblQuestionManagement);
            this.tabCauHoi.Location = new System.Drawing.Point(4, 44);
            this.tabCauHoi.Name = "tabCauHoi";
            this.tabCauHoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabCauHoi.Size = new System.Drawing.Size(1592, 812);
            this.tabCauHoi.TabIndex = 1;
            this.tabCauHoi.Text = "Quản lý câu hỏi";
            // 
            // panelQuestions
            // 
            this.panelQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuestions.AutoScroll = true;
            this.panelQuestions.BorderColor = System.Drawing.Color.LightGray;
            this.panelQuestions.BorderRadius = 5;
            this.panelQuestions.BorderThickness = 1;
            this.panelQuestions.Controls.Add(this.lblNoQuestions);
            this.panelQuestions.Location = new System.Drawing.Point(20, 91);
            this.panelQuestions.Name = "panelQuestions";
            this.panelQuestions.Size = new System.Drawing.Size(1552, 663);
            this.panelQuestions.TabIndex = 4;
            // 
            // lblNoQuestions
            // 
            this.lblNoQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoQuestions.BackColor = System.Drawing.Color.Transparent;
            this.lblNoQuestions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblNoQuestions.ForeColor = System.Drawing.Color.Gray;
            this.lblNoQuestions.Location = new System.Drawing.Point(395, 310);
            this.lblNoQuestions.Name = "lblNoQuestions";
            this.lblNoQuestions.Size = new System.Drawing.Size(255, 22);
            this.lblNoQuestions.TabIndex = 0;
            this.lblNoQuestions.Text = "Chưa có câu hỏi nào trong bài kiểm tra";
            // 
            // btnImportQuestions
            // 
            this.btnImportQuestions.BorderRadius = 5;
            this.btnImportQuestions.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportQuestions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImportQuestions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImportQuestions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImportQuestions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImportQuestions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportQuestions.ForeColor = System.Drawing.Color.White;
            this.btnImportQuestions.Location = new System.Drawing.Point(459, 50);
            this.btnImportQuestions.Name = "btnImportQuestions";
            this.btnImportQuestions.Size = new System.Drawing.Size(180, 36);
            this.btnImportQuestions.TabIndex = 3;
            this.btnImportQuestions.Text = "Nhập câu hỏi từ tệp";
            // 
            // btnAddEssayQuestion
            // 
            this.btnAddEssayQuestion.BorderRadius = 5;
            this.btnAddEssayQuestion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEssayQuestion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEssayQuestion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddEssayQuestion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddEssayQuestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEssayQuestion.ForeColor = System.Drawing.Color.White;
            this.btnAddEssayQuestion.Location = new System.Drawing.Point(244, 50);
            this.btnAddEssayQuestion.Name = "btnAddEssayQuestion";
            this.btnAddEssayQuestion.Size = new System.Drawing.Size(180, 36);
            this.btnAddEssayQuestion.TabIndex = 2;
            this.btnAddEssayQuestion.Text = "Thêm câu hỏi tự luận";
            // 
            // btnAddMultipleChoiceQuestion
            // 
            this.btnAddMultipleChoiceQuestion.BorderRadius = 5;
            this.btnAddMultipleChoiceQuestion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMultipleChoiceQuestion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMultipleChoiceQuestion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddMultipleChoiceQuestion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddMultipleChoiceQuestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMultipleChoiceQuestion.ForeColor = System.Drawing.Color.White;
            this.btnAddMultipleChoiceQuestion.Location = new System.Drawing.Point(20, 50);
            this.btnAddMultipleChoiceQuestion.Name = "btnAddMultipleChoiceQuestion";
            this.btnAddMultipleChoiceQuestion.Size = new System.Drawing.Size(180, 36);
            this.btnAddMultipleChoiceQuestion.TabIndex = 1;
            this.btnAddMultipleChoiceQuestion.Text = "Thêm câu hỏi trắc nghiệm";
            // 
            // lblQuestionManagement
            // 
            this.lblQuestionManagement.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestionManagement.Location = new System.Drawing.Point(20, 20);
            this.lblQuestionManagement.Name = "lblQuestionManagement";
            this.lblQuestionManagement.Size = new System.Drawing.Size(136, 27);
            this.lblQuestionManagement.TabIndex = 0;
            this.lblQuestionManagement.Text = "Quản lý câu hỏi";
            // 
            // tabCauHinhDiem
            // 
            this.tabCauHinhDiem.BackColor = System.Drawing.Color.White;
            this.tabCauHinhDiem.Controls.Add(this.panelGrading);
            this.tabCauHinhDiem.Controls.Add(this.lblGradingOptions);
            this.tabCauHinhDiem.Location = new System.Drawing.Point(4, 44);
            this.tabCauHinhDiem.Name = "tabCauHinhDiem";
            this.tabCauHinhDiem.Size = new System.Drawing.Size(1592, 812);
            this.tabCauHinhDiem.TabIndex = 2;
            this.tabCauHinhDiem.Text = "Cấu hình điểm số";
            // 
            // panelGrading
            // 
            this.panelGrading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrading.BorderColor = System.Drawing.Color.LightGray;
            this.panelGrading.BorderRadius = 5;
            this.panelGrading.BorderThickness = 1;
            this.panelGrading.Controls.Add(this.chkRandomizeQuestions);
            this.panelGrading.Controls.Add(this.chkShowResultImmediately);
            this.panelGrading.Controls.Add(this.txtGradingNotes);
            this.panelGrading.Controls.Add(this.lblGradingNotes);
            this.panelGrading.Controls.Add(this.numPassingScore);
            this.panelGrading.Controls.Add(this.lblPassingScore);
            this.panelGrading.Location = new System.Drawing.Point(20, 48);
            this.panelGrading.Name = "panelGrading";
            this.panelGrading.Size = new System.Drawing.Size(1552, 706);
            this.panelGrading.TabIndex = 5;
            // 
            // chkRandomizeQuestions
            // 
            this.chkRandomizeQuestions.AutoSize = true;
            this.chkRandomizeQuestions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRandomizeQuestions.CheckedState.BorderRadius = 0;
            this.chkRandomizeQuestions.CheckedState.BorderThickness = 0;
            this.chkRandomizeQuestions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRandomizeQuestions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRandomizeQuestions.Location = new System.Drawing.Point(177, 327);
            this.chkRandomizeQuestions.Name = "chkRandomizeQuestions";
            this.chkRandomizeQuestions.Size = new System.Drawing.Size(238, 25);
            this.chkRandomizeQuestions.TabIndex = 5;
            this.chkRandomizeQuestions.Text = "Đảo thứ tự câu hỏi ngẫu nhiên";
            this.chkRandomizeQuestions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkRandomizeQuestions.UncheckedState.BorderRadius = 0;
            this.chkRandomizeQuestions.UncheckedState.BorderThickness = 0;
            this.chkRandomizeQuestions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkShowResultImmediately
            // 
            this.chkShowResultImmediately.AutoSize = true;
            this.chkShowResultImmediately.Checked = true;
            this.chkShowResultImmediately.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowResultImmediately.CheckedState.BorderRadius = 0;
            this.chkShowResultImmediately.CheckedState.BorderThickness = 0;
            this.chkShowResultImmediately.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowResultImmediately.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowResultImmediately.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowResultImmediately.Location = new System.Drawing.Point(177, 293);
            this.chkShowResultImmediately.Name = "chkShowResultImmediately";
            this.chkShowResultImmediately.Size = new System.Drawing.Size(226, 25);
            this.chkShowResultImmediately.TabIndex = 4;
            this.chkShowResultImmediately.Text = "Hiển thị kết quả ngay lập tức";
            this.chkShowResultImmediately.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowResultImmediately.UncheckedState.BorderRadius = 0;
            this.chkShowResultImmediately.UncheckedState.BorderThickness = 0;
            this.chkShowResultImmediately.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtGradingNotes
            // 
            this.txtGradingNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGradingNotes.BorderRadius = 5;
            this.txtGradingNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGradingNotes.DefaultText = "";
            this.txtGradingNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGradingNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGradingNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGradingNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGradingNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGradingNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGradingNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGradingNotes.Location = new System.Drawing.Point(177, 389);
            this.txtGradingNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGradingNotes.Multiline = true;
            this.txtGradingNotes.Name = "txtGradingNotes";
            this.txtGradingNotes.PlaceholderText = "Nhập ghi chú về cách chấm điểm, tiêu chí...";
            this.txtGradingNotes.SelectedText = "";
            this.txtGradingNotes.Size = new System.Drawing.Size(1198, 100);
            this.txtGradingNotes.TabIndex = 3;
            // 
            // lblGradingNotes
            // 
            this.lblGradingNotes.BackColor = System.Drawing.Color.Transparent;
            this.lblGradingNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradingNotes.Location = new System.Drawing.Point(177, 361);
            this.lblGradingNotes.Name = "lblGradingNotes";
            this.lblGradingNotes.Size = new System.Drawing.Size(192, 23);
            this.lblGradingNotes.TabIndex = 2;
            this.lblGradingNotes.Text = "Ghi chú về cách chấm điểm";
            // 
            // numPassingScore
            // 
            this.numPassingScore.BackColor = System.Drawing.Color.Transparent;
            this.numPassingScore.BorderRadius = 5;
            this.numPassingScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPassingScore.DecimalPlaces = 1;
            this.numPassingScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPassingScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numPassingScore.Location = new System.Drawing.Point(177, 249);
            this.numPassingScore.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPassingScore.Name = "numPassingScore";
            this.numPassingScore.Size = new System.Drawing.Size(100, 25);
            this.numPassingScore.TabIndex = 1;
            this.numPassingScore.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblPassingScore
            // 
            this.lblPassingScore.BackColor = System.Drawing.Color.Transparent;
            this.lblPassingScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassingScore.Location = new System.Drawing.Point(177, 217);
            this.lblPassingScore.Name = "lblPassingScore";
            this.lblPassingScore.Size = new System.Drawing.Size(123, 23);
            this.lblPassingScore.TabIndex = 0;
            this.lblPassingScore.Text = "Điểm đạt yêu cầu";
            // 
            // lblGradingOptions
            // 
            this.lblGradingOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblGradingOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblGradingOptions.Location = new System.Drawing.Point(20, 20);
            this.lblGradingOptions.Name = "lblGradingOptions";
            this.lblGradingOptions.Size = new System.Drawing.Size(152, 27);
            this.lblGradingOptions.TabIndex = 0;
            this.lblGradingOptions.Text = "Cấu hình điểm số";
            // 
            // tabXemTruoc
            // 
            this.tabXemTruoc.BackColor = System.Drawing.Color.White;
            this.tabXemTruoc.Controls.Add(this.panelPreview);
            this.tabXemTruoc.Controls.Add(this.lblPreviewTitle);
            this.tabXemTruoc.Location = new System.Drawing.Point(4, 44);
            this.tabXemTruoc.Name = "tabXemTruoc";
            this.tabXemTruoc.Size = new System.Drawing.Size(1592, 812);
            this.tabXemTruoc.TabIndex = 3;
            this.tabXemTruoc.Text = "Xem trước và cài đặt";
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BorderColor = System.Drawing.Color.LightGray;
            this.panelPreview.BorderRadius = 5;
            this.panelPreview.BorderThickness = 1;
            this.panelPreview.Controls.Add(this.btnPreviewTest);
            this.panelPreview.Controls.Add(this.lblPreviewInstruction);
            this.panelPreview.Controls.Add(this.chkPassword);
            this.panelPreview.Controls.Add(this.txtPassword);
            this.panelPreview.Location = new System.Drawing.Point(20, 48);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(1552, 706);
            this.panelPreview.TabIndex = 5;
            // 
            // btnPreviewTest
            // 
            this.btnPreviewTest.BorderRadius = 5;
            this.btnPreviewTest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviewTest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviewTest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviewTest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviewTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviewTest.ForeColor = System.Drawing.Color.White;
            this.btnPreviewTest.Location = new System.Drawing.Point(589, 399);
            this.btnPreviewTest.Name = "btnPreviewTest";
            this.btnPreviewTest.Size = new System.Drawing.Size(201, 44);
            this.btnPreviewTest.TabIndex = 4;
            this.btnPreviewTest.Text = "Xem trước bài kiểm tra";
            // 
            // lblPreviewInstruction
            // 
            this.lblPreviewInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviewInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewInstruction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewInstruction.Location = new System.Drawing.Point(504, 354);
            this.lblPreviewInstruction.Name = "lblPreviewInstruction";
            this.lblPreviewInstruction.Size = new System.Drawing.Size(545, 23);
            this.lblPreviewInstruction.TabIndex = 3;
            this.lblPreviewInstruction.Text = "Nhấn nút \"Xem trước bài kiểm tra\" để kiểm tra trước khi đăng bài cho học sinh";
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPassword.CheckedState.BorderRadius = 0;
            this.chkPassword.CheckedState.BorderThickness = 0;
            this.chkPassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPassword.Location = new System.Drawing.Point(504, 271);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(227, 25);
            this.chkPassword.TabIndex = 1;
            this.chkPassword.Text = "Yêu cầu mật khẩu để làm bài";
            this.chkPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkPassword.UncheckedState.BorderRadius = 0;
            this.chkPassword.UncheckedState.BorderThickness = 0;
            this.chkPassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.Enabled = false;
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(504, 304);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu cho bài kiểm tra";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(343, 36);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(232, 27);
            this.lblPreviewTitle.TabIndex = 0;
            this.lblPreviewTitle.Text = "Xem trước và cài đặt thêm";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnSaveDraft);
            this.panelActions.Controls.Add(this.btnPublish);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(20, 880);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1600, 60);
            this.panelActions.TabIndex = 1;
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveDraft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSaveDraft.BorderRadius = 5;
            this.btnSaveDraft.BorderThickness = 1;
            this.btnSaveDraft.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveDraft.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveDraft.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveDraft.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveDraft.FillColor = System.Drawing.Color.White;
            this.btnSaveDraft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSaveDraft.Location = new System.Drawing.Point(1259, 12);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(120, 36);
            this.btnSaveDraft.TabIndex = 3;
            this.btnSaveDraft.Text = "Lưu nháp";
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPublish.BorderRadius = 5;
            this.btnPublish.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPublish.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPublish.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPublish.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(1397, 12);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(188, 36);
            this.btnPublish.TabIndex = 2;
            this.btnPublish.Text = "Đăng bài kiểm tra";
            // 
            // ucTaoBaiKiemTra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelMain);
            this.Name = "ucTaoBaiKiemTra";
            this.Size = new System.Drawing.Size(1640, 960);
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabThongTinChung.ResumeLayout(false);
            this.tabThongTinChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttemptsAllowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.tabCauHoi.ResumeLayout(false);
            this.tabCauHoi.PerformLayout();
            this.panelQuestions.ResumeLayout(false);
            this.panelQuestions.PerformLayout();
            this.tabCauHinhDiem.ResumeLayout(false);
            this.tabCauHinhDiem.PerformLayout();
            this.panelGrading.ResumeLayout(false);
            this.panelGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPassingScore)).EndInit();
            this.tabXemTruoc.ResumeLayout(false);
            this.tabXemTruoc.PerformLayout();
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.ucTaoBaiKiemTra_Load);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabThongTinChung;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoteTimeLimit;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestPeriod;
        private Guna.UI2.WinForms.Guna2NumericUpDown numAttemptsAllowed;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttemptsAllowed;
        private Guna.UI2.WinForms.Guna2NumericUpDown numDuration;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDuration;
        private Guna.UI2.WinForms.Guna2ComboBox cboTestType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestType;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescription;
        private Guna.UI2.WinForms.Guna2ComboBox cboClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClass;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubject;
        private Guna.UI2.WinForms.Guna2TextBox txtTestName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGeneralInfo;
        private System.Windows.Forms.TabPage tabCauHoi;
        private Guna.UI2.WinForms.Guna2Panel panelQuestions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoQuestions;
        private Guna.UI2.WinForms.Guna2Button btnImportQuestions;
        private Guna.UI2.WinForms.Guna2Button btnAddEssayQuestion;
        private Guna.UI2.WinForms.Guna2Button btnAddMultipleChoiceQuestion;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionManagement;
        private System.Windows.Forms.TabPage tabCauHinhDiem;
        private Guna.UI2.WinForms.Guna2Panel panelGrading;
        private Guna.UI2.WinForms.Guna2CheckBox chkRandomizeQuestions;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowResultImmediately;
        private Guna.UI2.WinForms.Guna2TextBox txtGradingNotes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGradingNotes;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPassingScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPassingScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGradingOptions;
        private System.Windows.Forms.TabPage tabXemTruoc;
        private Guna.UI2.WinForms.Guna2Panel panelPreview;
        private Guna.UI2.WinForms.Guna2Panel panelActions;
        private Guna.UI2.WinForms.Guna2Button btnSaveDraft;
        private Guna.UI2.WinForms.Guna2Button btnPublish;
        private Guna.UI2.WinForms.Guna2Button btnPreviewTest;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPreviewInstruction;
        private Guna.UI2.WinForms.Guna2CheckBox chkPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPreviewTitle;
    }
}
