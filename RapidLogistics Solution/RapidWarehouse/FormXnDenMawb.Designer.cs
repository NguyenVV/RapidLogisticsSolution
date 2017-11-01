namespace RapidWarehouse
{
    partial class FormXnDenMawb
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMAWB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.lblShipmentScaned = new System.Windows.Forms.Label();
            this.lblNgayDen = new System.Windows.Forms.Label();
            this.lblMasterBill = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnXNĐ = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.prgShipments = new System.Windows.Forms.ProgressBar();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMAWB);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1156, 228);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nhập số vận đơn:";
            // 
            // txtMAWB
            // 
            this.txtMAWB.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAWB.Location = new System.Drawing.Point(5, 180);
            this.txtMAWB.Name = "txtMAWB";
            this.txtMAWB.Size = new System.Drawing.Size(1146, 32);
            this.txtMAWB.TabIndex = 32;
            this.txtMAWB.TextChanged += new System.EventHandler(this.txtMAWB_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.lblShipmentScaned);
            this.panel1.Controls.Add(this.lblNgayDen);
            this.panel1.Controls.Add(this.lblMasterBill);
            this.panel1.Font = new System.Drawing.Font("Cambria", 8.25F);
            this.panel1.ForeColor = System.Drawing.Color.ForestGreen;
            this.panel1.Location = new System.Drawing.Point(5, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 114);
            this.panel1.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(378, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 34);
            this.label1.TabIndex = 33;
            this.label1.Text = "XÁC NHẬN DỮ LIỆU";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtTotal.Location = new System.Drawing.Point(694, 68);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(125, 28);
            this.txtTotal.TabIndex = 32;
            this.txtTotal.Text = "Tổng số : ";
            this.txtTotal.Visible = false;
            // 
            // lblShipmentScaned
            // 
            this.lblShipmentScaned.AutoSize = true;
            this.lblShipmentScaned.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentScaned.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblShipmentScaned.Location = new System.Drawing.Point(840, 68);
            this.lblShipmentScaned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShipmentScaned.Name = "lblShipmentScaned";
            this.lblShipmentScaned.Size = new System.Drawing.Size(42, 28);
            this.lblShipmentScaned.TabIndex = 29;
            this.lblShipmentScaned.Text = "88";
            // 
            // lblNgayDen
            // 
            this.lblNgayDen.AutoSize = true;
            this.lblNgayDen.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDen.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNgayDen.Location = new System.Drawing.Point(15, 75);
            this.lblNgayDen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayDen.Name = "lblNgayDen";
            this.lblNgayDen.Size = new System.Drawing.Size(164, 28);
            this.lblNgayDen.TabIndex = 5;
            this.lblNgayDen.Text = "flightnumber";
            // 
            // lblMasterBill
            // 
            this.lblMasterBill.AutoSize = true;
            this.lblMasterBill.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBill.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMasterBill.Location = new System.Drawing.Point(15, 42);
            this.lblMasterBill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMasterBill.Name = "lblMasterBill";
            this.lblMasterBill.Size = new System.Drawing.Size(123, 28);
            this.lblMasterBill.TabIndex = 1;
            this.lblMasterBill.Text = "airwaybill";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.Purple;
            this.btnCheck.Location = new System.Drawing.Point(7, 276);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(1155, 43);
            this.btnCheck.TabIndex = 31;
            this.btnCheck.Text = "Kiểm tra dữ liệu";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnXNĐ
            // 
            this.btnXNĐ.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXNĐ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXNĐ.ForeColor = System.Drawing.Color.Purple;
            this.btnXNĐ.Location = new System.Drawing.Point(7, 323);
            this.btnXNĐ.Margin = new System.Windows.Forms.Padding(2);
            this.btnXNĐ.Name = "btnXNĐ";
            this.btnXNĐ.Size = new System.Drawing.Size(1155, 47);
            this.btnXNĐ.TabIndex = 4;
            this.btnXNĐ.Text = "Xác nhận dữ liệu";
            this.btnXNĐ.UseVisualStyleBackColor = false;
            this.btnXNĐ.Click += new System.EventHandler(this.btnXNĐ_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Purple;
            this.btnExit.Location = new System.Drawing.Point(7, 374);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(1155, 47);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // prgShipments
            // 
            this.prgShipments.Location = new System.Drawing.Point(11, 244);
            this.prgShipments.Name = "prgShipments";
            this.prgShipments.Size = new System.Drawing.Size(1151, 23);
            this.prgShipments.TabIndex = 39;
            // 
            // FormXnDenMawb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.prgShipments);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnXNĐ);
            this.Controls.Add(this.btnCheck);
            this.Location = new System.Drawing.Point(838, 23);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormXnDenMawb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận đến theo mã Airwaybill";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNhap_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label lblShipmentScaned;
        private System.Windows.Forms.Label lblNgayDen;
        private System.Windows.Forms.Label lblMasterBill;
        private System.Windows.Forms.Button btnXNĐ;
        private System.Windows.Forms.TextBox txtMAWB;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar prgShipments;
    }
}

