namespace RapidWarehouse
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnXndTheoMawb = new System.Windows.Forms.Button();
            this.btnManageWarehouse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnWaitToConfirm = new System.Windows.Forms.Button();
            this.btnExportInventory = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageEmployee = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnXndTheoMawb);
            this.groupBox1.Controls.Add(this.btnManageWarehouse);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnWaitToConfirm);
            this.groupBox1.Controls.Add(this.btnExportInventory);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.btnReports);
            this.groupBox1.Controls.Add(this.btnChangePass);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnLogout);
            this.groupBox1.Controls.Add(this.lblWelcome);
            this.groupBox1.Controls.Add(this.btnManageEmployee);
            this.groupBox1.Controls.Add(this.btnInventory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Purple;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(40, 42, 40, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(1158, 524);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MENU";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Purple;
            this.btnSearch.Location = new System.Drawing.Point(252, 198);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(194, 78);
            this.btnSearch.TabIndex = 44;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnXndTheoMawb
            // 
            this.btnXndTheoMawb.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXndTheoMawb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXndTheoMawb.ForeColor = System.Drawing.Color.Purple;
            this.btnXndTheoMawb.Location = new System.Drawing.Point(26, 66);
            this.btnXndTheoMawb.Margin = new System.Windows.Forms.Padding(2);
            this.btnXndTheoMawb.Name = "btnXndTheoMawb";
            this.btnXndTheoMawb.Size = new System.Drawing.Size(194, 78);
            this.btnXndTheoMawb.TabIndex = 6;
            this.btnXndTheoMawb.Text = "Xác nhận đến MAWB";
            this.btnXndTheoMawb.UseVisualStyleBackColor = false;
            this.btnXndTheoMawb.Click += new System.EventHandler(this.btnXndTheoMawb_Click);
            // 
            // btnManageWarehouse
            // 
            this.btnManageWarehouse.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnManageWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageWarehouse.ForeColor = System.Drawing.Color.Purple;
            this.btnManageWarehouse.Location = new System.Drawing.Point(476, 322);
            this.btnManageWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageWarehouse.Name = "btnManageWarehouse";
            this.btnManageWarehouse.Size = new System.Drawing.Size(194, 78);
            this.btnManageWarehouse.TabIndex = 43;
            this.btnManageWarehouse.Text = "Quản lý kho hàng";
            this.btnManageWarehouse.UseVisualStyleBackColor = false;
            this.btnManageWarehouse.Click += new System.EventHandler(this.btnManageWarehouse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RapidWarehouse.Properties.Resources.logo;
            this.pictureBox1.InitialImage = global::RapidWarehouse.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(806, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // btnWaitToConfirm
            // 
            this.btnWaitToConfirm.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnWaitToConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaitToConfirm.ForeColor = System.Drawing.Color.Purple;
            this.btnWaitToConfirm.Location = new System.Drawing.Point(476, 66);
            this.btnWaitToConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnWaitToConfirm.Name = "btnWaitToConfirm";
            this.btnWaitToConfirm.Size = new System.Drawing.Size(194, 78);
            this.btnWaitToConfirm.TabIndex = 2;
            this.btnWaitToConfirm.Text = "Kiểm tra ra cổng";
            this.btnWaitToConfirm.UseVisualStyleBackColor = false;
            this.btnWaitToConfirm.Click += new System.EventHandler(this.btnWaitToConfirm_Click);
            // 
            // btnExportInventory
            // 
            this.btnExportInventory.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportInventory.ForeColor = System.Drawing.Color.Purple;
            this.btnExportInventory.Location = new System.Drawing.Point(252, 66);
            this.btnExportInventory.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportInventory.Name = "btnExportInventory";
            this.btnExportInventory.Size = new System.Drawing.Size(194, 78);
            this.btnExportInventory.TabIndex = 1;
            this.btnExportInventory.Text = "Xuất kho";
            this.btnExportInventory.UseVisualStyleBackColor = false;
            this.btnExportInventory.Click += new System.EventHandler(this.btnExportInventory_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Purple;
            this.lblTime.Location = new System.Drawing.Point(862, 261);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(124, 46);
            this.lblTime.TabIndex = 39;
            this.lblTime.Text = "15:30";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Purple;
            this.lblDate.Location = new System.Drawing.Point(798, 228);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(259, 20);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "Thứ sáu ngày 13 tháng 6 năm 2017";
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.Purple;
            this.btnReports.Location = new System.Drawing.Point(26, 321);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(194, 78);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Báo cáo";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.ForeColor = System.Drawing.Color.Purple;
            this.btnChangePass.Location = new System.Drawing.Point(252, 322);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(194, 78);
            this.btnChangePass.TabIndex = 4;
            this.btnChangePass.Text = "Hệ thống";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Purple;
            this.btnExit.Location = new System.Drawing.Point(802, 415);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(268, 48);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Purple;
            this.btnLogout.Location = new System.Drawing.Point(802, 351);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(268, 48);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Đổi người dùng";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Purple;
            this.lblWelcome.Location = new System.Drawing.Point(835, 315);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(185, 20);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Xin chào Nguyễn Văn A !";
            // 
            // btnManageEmployee
            // 
            this.btnManageEmployee.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnManageEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployee.ForeColor = System.Drawing.Color.Purple;
            this.btnManageEmployee.Location = new System.Drawing.Point(476, 198);
            this.btnManageEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageEmployee.Name = "btnManageEmployee";
            this.btnManageEmployee.Size = new System.Drawing.Size(194, 78);
            this.btnManageEmployee.TabIndex = 5;
            this.btnManageEmployee.Text = "Quản lý người dùng";
            this.btnManageEmployee.UseVisualStyleBackColor = false;
            this.btnManageEmployee.Click += new System.EventHandler(this.btnManageEmployee_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.Purple;
            this.btnInventory.Location = new System.Drawing.Point(26, 198);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(2);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(194, 78);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "Xác nhận đến";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // timerMinute
            // 
            this.timerMinute.Interval = 1000;
            this.timerMinute.Tick += new System.EventHandler(this.timerMinute_Tick);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1174, 540);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormHome";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho hàng Rapid Hà Nội - Rapid Logistics v1.0.17";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHome_FormClosed);
            this.Shown += new System.EventHandler(this.FormHome_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageEmployee;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnWaitToConfirm;
        private System.Windows.Forms.Button btnExportInventory;
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnManageWarehouse;
        private System.Windows.Forms.Button btnXndTheoMawb;
        private System.Windows.Forms.Button btnSearch;
    }
}