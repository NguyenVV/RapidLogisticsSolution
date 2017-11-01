namespace RapidWarehouse
{
    partial class FormCreateEditEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateEditEmployee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.lbListEmployee = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.dtpBirthDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbbRole);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(10, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(597, 549);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(38, 484);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(137, 39);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Tạo Mới";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(359, 485);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 38);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(200, 485);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(211, 227);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(266, 26);
            this.dtpBirthDate.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(35, 227);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ngày Sinh";
            // 
            // cbbRole
            // 
            this.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Items.AddRange(new object[] {
            "Nhân Viên",
            "Administrator",
            "Hải Quan"});
            this.cbbRole.Location = new System.Drawing.Point(211, 138);
            this.cbbRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(266, 28);
            this.cbbRole.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(35, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phân quyền";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(211, 356);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(266, 105);
            this.txtAddress.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(35, 358);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(211, 311);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(266, 26);
            this.txtEmail.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(35, 311);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(211, 268);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(266, 26);
            this.txtPhone.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(35, 268);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điện Thoại";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(211, 186);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(266, 26);
            this.txtFullName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(35, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ và Tên";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(211, 93);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.MaxLength = 150;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(266, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(35, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(211, 49);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(266, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản đăng nhập";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearchEmployee);
            this.groupBox2.Controls.Add(this.lbListEmployee);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(621, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(418, 549);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Nhân Viên";
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(15, 42);
            this.txtSearchEmployee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(388, 26);
            this.txtSearchEmployee.TabIndex = 1;
            // 
            // lbListEmployee
            // 
            this.lbListEmployee.FormattingEnabled = true;
            this.lbListEmployee.ItemHeight = 20;
            this.lbListEmployee.Location = new System.Drawing.Point(16, 93);
            this.lbListEmployee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbListEmployee.Name = "lbListEmployee";
            this.lbListEmployee.Size = new System.Drawing.Size(389, 404);
            this.lbListEmployee.TabIndex = 0;
            this.lbListEmployee.SelectedIndexChanged += new System.EventHandler(this.lbListEmployee_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.Location = new System.Drawing.Point(324, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(347, 40);
            this.label9.TabIndex = 7;
            this.label9.Text = "Quản lý người dùng";
            // 
            // FormCreateEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1061, 626);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCreateEditEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng - Rapid Logistics v1.0.17";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCreateEditEmployee_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.ListBox lbListEmployee;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label9;
    }
}