namespace RapidWarehouse
{
    partial class FormConfigDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigDB));
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(303, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 55);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cấu hình cơ sở dữ liệu";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(359, 497);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(181, 46);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDbName
            // 
            this.txtDbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbName.Location = new System.Drawing.Point(80, 234);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(461, 38);
            this.txtDbName.TabIndex = 2;
            this.txtDbName.Text = "RapidSolution";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(80, 496);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(181, 47);
            this.btnTestConnection.TabIndex = 5;
            this.btnTestConnection.Text = "Kiểm tra kết nối";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Máy chủ";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.Location = new System.Drawing.Point(79, 150);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(461, 38);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "192.168.100.4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên cơ sở dữ liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(82, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 26);
            this.label4.TabIndex = 18;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(80, 409);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(461, 38);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "trungnd123@";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tài khoản đăng nhập CSDL";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(79, 325);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(461, 38);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mật khẩu đăng nhập CSDL";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMessage.Location = new System.Drawing.Point(81, 457);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(296, 25);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Kết nối đến CSDL thành công";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(616, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Mật khẩu cập nhật dữ liệu";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(621, 325);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(461, 38);
            this.textBox3.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(624, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 26);
            this.label9.TabIndex = 24;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(622, 234);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(461, 38);
            this.textBox4.TabIndex = 8;
            this.textBox4.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(616, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(291, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Địa chỉ cập nhật dữ liệu(FTP)";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(621, 150);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(461, 38);
            this.textBox5.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(266, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "Tài khoản cập nhật dữ liệu";
            // 
            // FormConfigDB
            // 
            this.AcceptButton = this.btnTestConnection;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 600);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConfigDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu Hình - Rapid Logistics v1.0.17";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormConfigDB_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
    }
}