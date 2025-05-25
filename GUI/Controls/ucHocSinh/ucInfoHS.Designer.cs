namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucInfoHS
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
            this.pnlAvatar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChangeAvatar = new System.Windows.Forms.LinkLabel();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblStudentInfoTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblIdentityCode = new System.Windows.Forms.Label();
            this.pnlAdditionalInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblQue = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblPlaceOfBirth = new System.Windows.Forms.Label();
            this.lblEthnicity = new System.Windows.Forms.Label();
            this.lblReligion = new System.Windows.Forms.Label();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.txtWard = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtDistrict = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtProvince = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContactInfoTitle = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlContact = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblHoTenCha = new System.Windows.Forms.Label();
            this.lblSDTCha = new System.Windows.Forms.Label();
            this.lblHoTenMe = new System.Windows.Forms.Label();
            this.lblEmergencyContactTitle = new System.Windows.Forms.Label();
            this.lblSDTMe = new System.Windows.Forms.Label();
            this.pnlEmergencyContact = new Guna.UI2.WinForms.Guna2Panel();
            this.txtHoTenCha = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSoDienThoaiCha = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHoTenMe = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSDTMe = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlAdditionalInfo.SuspendLayout();
            this.pnlEdit.SuspendLayout();
            this.pnlContact.SuspendLayout();
            this.pnlEmergencyContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.White;
            this.pnlAvatar.BorderRadius = 10;
            this.pnlAvatar.Controls.Add(this.lblChangeAvatar);
            this.pnlAvatar.Controls.Add(this.picAvatar);
            this.pnlAvatar.Location = new System.Drawing.Point(47, 47);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(201, 273);
            this.pnlAvatar.TabIndex = 1;
            // 
            // lblChangeAvatar
            // 
            this.lblChangeAvatar.AutoSize = true;
            this.lblChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAvatar.Location = new System.Drawing.Point(51, 198);
            this.lblChangeAvatar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChangeAvatar.Name = "lblChangeAvatar";
            this.lblChangeAvatar.Size = new System.Drawing.Size(136, 23);
            this.lblChangeAvatar.TabIndex = 1;
            this.lblChangeAvatar.TabStop = true;
            this.lblChangeAvatar.Text = "Đổi ảnh đại diện";
            this.lblChangeAvatar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeAvatar_LinkClicked);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.picAvatar.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Boy1;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(20, 16);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(161, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderRadius = 10;
            this.pnlInfo.Controls.Add(this.guna2Separator1);
            this.pnlInfo.Controls.Add(this.lblStudentInfoTitle);
            this.pnlInfo.Controls.Add(this.lblFullName);
            this.pnlInfo.Controls.Add(this.lblStudentId);
            this.pnlInfo.Controls.Add(this.lblClass);
            this.pnlInfo.Controls.Add(this.lblIdentityCode);
            this.pnlInfo.Controls.Add(this.pnlAdditionalInfo);
            this.pnlInfo.Location = new System.Drawing.Point(280, 47);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1235, 273);
            this.pnlInfo.TabIndex = 2;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(82, 173);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(977, 10);
            this.guna2Separator1.TabIndex = 6;
            // 
            // lblStudentInfoTitle
            // 
            this.lblStudentInfoTitle.AutoSize = true;
            this.lblStudentInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStudentInfoTitle.Location = new System.Drawing.Point(22, 16);
            this.lblStudentInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentInfoTitle.Name = "lblStudentInfoTitle";
            this.lblStudentInfoTitle.Size = new System.Drawing.Size(227, 32);
            this.lblStudentInfoTitle.TabIndex = 4;
            this.lblStudentInfoTitle.Text = "Thông tin học sinh";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(54, 59);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(90, 30);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "[Name]";
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentId.Location = new System.Drawing.Point(54, 98);
            this.lblStudentId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(74, 28);
            this.lblStudentId.TabIndex = 1;
            this.lblStudentId.Text = "Mã HS:";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(54, 135);
            this.lblClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(54, 28);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Lớp: ";
            // 
            // lblIdentityCode
            // 
            this.lblIdentityCode.AutoSize = true;
            this.lblIdentityCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityCode.Location = new System.Drawing.Point(416, 98);
            this.lblIdentityCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentityCode.Name = "lblIdentityCode";
            this.lblIdentityCode.Size = new System.Drawing.Size(142, 28);
            this.lblIdentityCode.TabIndex = 5;
            this.lblIdentityCode.Text = "Mã định danh: ";
            // 
            // pnlAdditionalInfo
            // 
            this.pnlAdditionalInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdditionalInfo.Controls.Add(this.lblQue);
            this.pnlAdditionalInfo.Controls.Add(this.lblGender);
            this.pnlAdditionalInfo.Controls.Add(this.lblDOB);
            this.pnlAdditionalInfo.Controls.Add(this.lblPlaceOfBirth);
            this.pnlAdditionalInfo.Controls.Add(this.lblEthnicity);
            this.pnlAdditionalInfo.Controls.Add(this.lblReligion);
            this.pnlAdditionalInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAdditionalInfo.Location = new System.Drawing.Point(0, 185);
            this.pnlAdditionalInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAdditionalInfo.Name = "pnlAdditionalInfo";
            this.pnlAdditionalInfo.Size = new System.Drawing.Size(1235, 88);
            this.pnlAdditionalInfo.TabIndex = 3;
            // 
            // lblQue
            // 
            this.lblQue.AutoSize = true;
            this.lblQue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQue.Location = new System.Drawing.Point(690, 48);
            this.lblQue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQue.Name = "lblQue";
            this.lblQue.Size = new System.Drawing.Size(130, 28);
            this.lblQue.TabIndex = 5;
            this.lblQue.Text = "Quê quán: ---";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(54, 13);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(120, 28);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Giới tính: ---";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(312, 13);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(132, 28);
            this.lblDOB.TabIndex = 1;
            this.lblDOB.Text = "Ngày sinh: ---";
            // 
            // lblPlaceOfBirth
            // 
            this.lblPlaceOfBirth.AutoSize = true;
            this.lblPlaceOfBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceOfBirth.Location = new System.Drawing.Point(54, 48);
            this.lblPlaceOfBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            this.lblPlaceOfBirth.Size = new System.Drawing.Size(117, 28);
            this.lblPlaceOfBirth.TabIndex = 2;
            this.lblPlaceOfBirth.Text = "Nơi sinh: ---";
            // 
            // lblEthnicity
            // 
            this.lblEthnicity.AutoSize = true;
            this.lblEthnicity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEthnicity.Location = new System.Drawing.Point(312, 48);
            this.lblEthnicity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEthnicity.Name = "lblEthnicity";
            this.lblEthnicity.Size = new System.Drawing.Size(113, 28);
            this.lblEthnicity.TabIndex = 3;
            this.lblEthnicity.Text = "Dân tộc: ---";
            // 
            // lblReligion
            // 
            this.lblReligion.AutoSize = true;
            this.lblReligion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReligion.Location = new System.Drawing.Point(690, 13);
            this.lblReligion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(120, 28);
            this.lblReligion.TabIndex = 4;
            this.lblReligion.Text = "Tôn giáo: ---";
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(153, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 39);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.btnEdit);
            this.pnlEdit.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlEdit.Location = new System.Drawing.Point(1248, 705);
            this.pnlEdit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(267, 41);
            this.pnlEdit.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = this.btnEdit.Font;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = this.btnEdit.Size;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(472, 274);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 28);
            this.lblEmail.TabIndex = 22;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.Enabled = false;
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(607, 260);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(218, 39);
            this.txtEmail.TabIndex = 23;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(39, 205);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(75, 28);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.Enabled = false;
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(198, 194);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(627, 39);
            this.txtAddress.TabIndex = 19;
            // 
            // lblWard
            // 
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(472, 136);
            this.lblWard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(112, 28);
            this.lblWard.TabIndex = 16;
            this.lblWard.Text = "Phường/xã:";
            // 
            // txtWard
            // 
            this.txtWard.BorderRadius = 5;
            this.txtWard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWard.DefaultText = "";
            this.txtWard.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWard.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWard.Enabled = false;
            this.txtWard.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWard.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWard.Location = new System.Drawing.Point(607, 126);
            this.txtWard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtWard.Name = "txtWard";
            this.txtWard.PlaceholderText = "";
            this.txtWard.SelectedText = "";
            this.txtWard.Size = new System.Drawing.Size(218, 39);
            this.txtWard.TabIndex = 17;
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(39, 136);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(121, 28);
            this.lblDistrict.TabIndex = 14;
            this.lblDistrict.Text = "Quận huyện:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.BorderRadius = 5;
            this.txtDistrict.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistrict.DefaultText = "";
            this.txtDistrict.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDistrict.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDistrict.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistrict.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistrict.Enabled = false;
            this.txtDistrict.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistrict.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistrict.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistrict.Location = new System.Drawing.Point(198, 126);
            this.txtDistrict.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.PlaceholderText = "";
            this.txtDistrict.SelectedText = "";
            this.txtDistrict.Size = new System.Drawing.Size(218, 39);
            this.txtDistrict.TabIndex = 15;
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvince.Location = new System.Drawing.Point(472, 64);
            this.lblProvince.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(108, 28);
            this.lblProvince.TabIndex = 12;
            this.lblProvince.Text = "Tỉnh thành:";
            // 
            // txtProvince
            // 
            this.txtProvince.BorderRadius = 5;
            this.txtProvince.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProvince.DefaultText = "";
            this.txtProvince.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProvince.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProvince.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProvince.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProvince.Enabled = false;
            this.txtProvince.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProvince.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvince.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProvince.Location = new System.Drawing.Point(607, 59);
            this.txtProvince.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.PlaceholderText = "";
            this.txtProvince.SelectedText = "";
            this.txtProvince.Size = new System.Drawing.Size(218, 39);
            this.txtProvince.TabIndex = 13;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(39, 64);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(95, 28);
            this.lblCountry.TabIndex = 10;
            this.lblCountry.Text = "Quốc gia:";
            // 
            // txtCountry
            // 
            this.txtCountry.BorderRadius = 5;
            this.txtCountry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCountry.DefaultText = "";
            this.txtCountry.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCountry.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCountry.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCountry.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCountry.Enabled = false;
            this.txtCountry.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCountry.Location = new System.Drawing.Point(198, 59);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.PlaceholderText = "";
            this.txtCountry.SelectedText = "";
            this.txtCountry.Size = new System.Drawing.Size(218, 39);
            this.txtCountry.TabIndex = 11;
            // 
            // lblContactInfoTitle
            // 
            this.lblContactInfoTitle.AutoSize = true;
            this.lblContactInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblContactInfoTitle.Location = new System.Drawing.Point(15, 13);
            this.lblContactInfoTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContactInfoTitle.Name = "lblContactInfoTitle";
            this.lblContactInfoTitle.Size = new System.Drawing.Size(213, 32);
            this.lblContactInfoTitle.TabIndex = 9;
            this.lblContactInfoTitle.Text = "Thông tin liên lạc";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(39, 274);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(132, 28);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.Enabled = false;
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(198, 260);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(218, 39);
            this.txtPhone.TabIndex = 3;
            // 
            // pnlContact
            // 
            this.pnlContact.BackColor = System.Drawing.Color.White;
            this.pnlContact.BorderRadius = 10;
            this.pnlContact.Controls.Add(this.txtPhone);
            this.pnlContact.Controls.Add(this.lblPhone);
            this.pnlContact.Controls.Add(this.lblContactInfoTitle);
            this.pnlContact.Controls.Add(this.txtCountry);
            this.pnlContact.Controls.Add(this.lblCountry);
            this.pnlContact.Controls.Add(this.txtProvince);
            this.pnlContact.Controls.Add(this.lblProvince);
            this.pnlContact.Controls.Add(this.txtDistrict);
            this.pnlContact.Controls.Add(this.lblDistrict);
            this.pnlContact.Controls.Add(this.txtWard);
            this.pnlContact.Controls.Add(this.lblWard);
            this.pnlContact.Controls.Add(this.txtAddress);
            this.pnlContact.Controls.Add(this.lblAddress);
            this.pnlContact.Controls.Add(this.txtEmail);
            this.pnlContact.Controls.Add(this.lblEmail);
            this.pnlContact.Location = new System.Drawing.Point(47, 360);
            this.pnlContact.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(852, 324);
            this.pnlContact.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Font = this.btnEdit.Font;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = this.btnEdit.Size;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            // 
            // lblHoTenCha
            // 
            this.lblHoTenCha.AutoSize = true;
            this.lblHoTenCha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTenCha.Location = new System.Drawing.Point(35, 64);
            this.lblHoTenCha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTenCha.Name = "lblHoTenCha";
            this.lblHoTenCha.Size = new System.Drawing.Size(131, 28);
            this.lblHoTenCha.TabIndex = 0;
            this.lblHoTenCha.Text = "Họ và tên cha";
            // 
            // lblSDTCha
            // 
            this.lblSDTCha.AutoSize = true;
            this.lblSDTCha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTCha.Location = new System.Drawing.Point(38, 136);
            this.lblSDTCha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDTCha.Name = "lblSDTCha";
            this.lblSDTCha.Size = new System.Drawing.Size(128, 28);
            this.lblSDTCha.TabIndex = 2;
            this.lblSDTCha.Text = "Số điện thoại";
            // 
            // lblHoTenMe
            // 
            this.lblHoTenMe.AutoSize = true;
            this.lblHoTenMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTenMe.Location = new System.Drawing.Point(40, 205);
            this.lblHoTenMe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTenMe.Name = "lblHoTenMe";
            this.lblHoTenMe.Size = new System.Drawing.Size(128, 28);
            this.lblHoTenMe.TabIndex = 4;
            this.lblHoTenMe.Text = "Họ và tên mẹ";
            // 
            // lblEmergencyContactTitle
            // 
            this.lblEmergencyContactTitle.AutoSize = true;
            this.lblEmergencyContactTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmergencyContactTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEmergencyContactTitle.Location = new System.Drawing.Point(15, 13);
            this.lblEmergencyContactTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmergencyContactTitle.Name = "lblEmergencyContactTitle";
            this.lblEmergencyContactTitle.Size = new System.Drawing.Size(283, 32);
            this.lblEmergencyContactTitle.TabIndex = 10;
            this.lblEmergencyContactTitle.Text = "Thông tin người liên hệ";
            // 
            // lblSDTMe
            // 
            this.lblSDTMe.AutoSize = true;
            this.lblSDTMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTMe.Location = new System.Drawing.Point(38, 271);
            this.lblSDTMe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDTMe.Name = "lblSDTMe";
            this.lblSDTMe.Size = new System.Drawing.Size(128, 28);
            this.lblSDTMe.TabIndex = 11;
            this.lblSDTMe.Text = "Số điện thoại";
            // 
            // pnlEmergencyContact
            // 
            this.pnlEmergencyContact.BackColor = System.Drawing.Color.White;
            this.pnlEmergencyContact.BorderRadius = 10;
            this.pnlEmergencyContact.Controls.Add(this.txtSDTMe);
            this.pnlEmergencyContact.Controls.Add(this.lblSDTMe);
            this.pnlEmergencyContact.Controls.Add(this.lblEmergencyContactTitle);
            this.pnlEmergencyContact.Controls.Add(this.txtHoTenMe);
            this.pnlEmergencyContact.Controls.Add(this.lblHoTenMe);
            this.pnlEmergencyContact.Controls.Add(this.txtSoDienThoaiCha);
            this.pnlEmergencyContact.Controls.Add(this.lblSDTCha);
            this.pnlEmergencyContact.Controls.Add(this.txtHoTenCha);
            this.pnlEmergencyContact.Controls.Add(this.lblHoTenCha);
            this.pnlEmergencyContact.Location = new System.Drawing.Point(932, 360);
            this.pnlEmergencyContact.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEmergencyContact.Name = "pnlEmergencyContact";
            this.pnlEmergencyContact.Size = new System.Drawing.Size(583, 324);
            this.pnlEmergencyContact.TabIndex = 5;
            // 
            // txtHoTenCha
            // 
            this.txtHoTenCha.BorderRadius = 5;
            this.txtHoTenCha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTenCha.DefaultText = "";
            this.txtHoTenCha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHoTenCha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHoTenCha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenCha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenCha.Enabled = false;
            this.txtHoTenCha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenCha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenCha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenCha.Location = new System.Drawing.Point(221, 59);
            this.txtHoTenCha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHoTenCha.Name = "txtHoTenCha";
            this.txtHoTenCha.PlaceholderText = "";
            this.txtHoTenCha.SelectedText = "";
            this.txtHoTenCha.Size = new System.Drawing.Size(272, 39);
            this.txtHoTenCha.TabIndex = 1;
            // 
            // txtSoDienThoaiCha
            // 
            this.txtSoDienThoaiCha.BorderRadius = 5;
            this.txtSoDienThoaiCha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoDienThoaiCha.DefaultText = "";
            this.txtSoDienThoaiCha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoDienThoaiCha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoDienThoaiCha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoDienThoaiCha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoDienThoaiCha.Enabled = false;
            this.txtSoDienThoaiCha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoDienThoaiCha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoaiCha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoDienThoaiCha.Location = new System.Drawing.Point(221, 125);
            this.txtSoDienThoaiCha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoDienThoaiCha.Name = "txtSoDienThoaiCha";
            this.txtSoDienThoaiCha.PlaceholderText = "";
            this.txtSoDienThoaiCha.SelectedText = "";
            this.txtSoDienThoaiCha.Size = new System.Drawing.Size(271, 39);
            this.txtSoDienThoaiCha.TabIndex = 3;
            // 
            // txtHoTenMe
            // 
            this.txtHoTenMe.BorderRadius = 5;
            this.txtHoTenMe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTenMe.DefaultText = "";
            this.txtHoTenMe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHoTenMe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHoTenMe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenMe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenMe.Enabled = false;
            this.txtHoTenMe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenMe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenMe.Location = new System.Drawing.Point(221, 194);
            this.txtHoTenMe.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHoTenMe.Name = "txtHoTenMe";
            this.txtHoTenMe.PlaceholderText = "";
            this.txtHoTenMe.SelectedText = "";
            this.txtHoTenMe.Size = new System.Drawing.Size(272, 39);
            this.txtHoTenMe.TabIndex = 5;
            // 
            // txtSDTMe
            // 
            this.txtSDTMe.BorderRadius = 5;
            this.txtSDTMe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDTMe.DefaultText = "";
            this.txtSDTMe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDTMe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDTMe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDTMe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDTMe.Enabled = false;
            this.txtSDTMe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDTMe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTMe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDTMe.Location = new System.Drawing.Point(221, 260);
            this.txtSDTMe.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSDTMe.Name = "txtSDTMe";
            this.txtSDTMe.PlaceholderText = "";
            this.txtSDTMe.SelectedText = "";
            this.txtSDTMe.Size = new System.Drawing.Size(271, 39);
            this.txtSDTMe.TabIndex = 12;
            // 
            // ucInfoHS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlEmergencyContact);
            this.Controls.Add(this.pnlContact);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlAvatar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucInfoHS";
            this.Size = new System.Drawing.Size(1640, 1040);
            this.Load += new System.EventHandler(this.ucInfoHS_Load);
            this.pnlAvatar.ResumeLayout(false);
            this.pnlAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlAdditionalInfo.ResumeLayout(false);
            this.pnlAdditionalInfo.PerformLayout();
            this.pnlEdit.ResumeLayout(false);
            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.pnlEmergencyContact.ResumeLayout(false);
            this.pnlEmergencyContact.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlAvatar;
        private System.Windows.Forms.LinkLabel lblChangeAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblFullName;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Panel pnlAdditionalInfo;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblStudentInfoTitle;
        private System.Windows.Forms.Label lblIdentityCode;
        private System.Windows.Forms.Label lblPlaceOfBirth;
        private System.Windows.Forms.Label lblEthnicity;
        private System.Windows.Forms.Label lblReligion;
        private System.Windows.Forms.Label lblQue;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblWard;
        private Guna.UI2.WinForms.Guna2TextBox txtWard;
        private System.Windows.Forms.Label lblDistrict;
        private Guna.UI2.WinForms.Guna2TextBox txtDistrict;
        private System.Windows.Forms.Label lblProvince;
        private Guna.UI2.WinForms.Guna2TextBox txtProvince;
        private System.Windows.Forms.Label lblCountry;
        private Guna.UI2.WinForms.Guna2TextBox txtCountry;
        private System.Windows.Forms.Label lblContactInfoTitle;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2Panel pnlContact;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel pnlEdit;
        private System.Windows.Forms.Label lblHoTenCha;
        private System.Windows.Forms.Label lblSDTCha;
        private System.Windows.Forms.Label lblHoTenMe;
        private System.Windows.Forms.Label lblEmergencyContactTitle;
        private System.Windows.Forms.Label lblSDTMe;
        private Guna.UI2.WinForms.Guna2Panel pnlEmergencyContact;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2TextBox txtSDTMe;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTenMe;
        private Guna.UI2.WinForms.Guna2TextBox txtSoDienThoaiCha;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTenCha;
    }
}
