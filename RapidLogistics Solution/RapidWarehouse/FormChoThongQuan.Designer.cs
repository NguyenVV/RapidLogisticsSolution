namespace RapidWarehouse
{
    partial class FormChoThongQuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoThongQuan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtShipmentIdBlock = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.grvShipmentsWaitConfirmed = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXuatKhoConfirmed = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentsWaitConfirmed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnXuatKhoConfirmed);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox1.Size = new System.Drawing.Size(1649, 1122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hàng chờ thông quan";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtShipmentIdBlock);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(33, 60);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(567, 114);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thêm Shipment chờ thông quan";
            // 
            // txtShipmentIdBlock
            // 
            this.txtShipmentIdBlock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentIdBlock.Location = new System.Drawing.Point(7, 52);
            this.txtShipmentIdBlock.Name = "txtShipmentIdBlock";
            this.txtShipmentIdBlock.Size = new System.Drawing.Size(505, 38);
            this.txtShipmentIdBlock.TabIndex = 44;
            this.txtShipmentIdBlock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipmentIdBlock_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDong);
            this.groupBox4.Controls.Add(this.grvShipmentsWaitConfirmed);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(33, 207);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1590, 892);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách shipments chờ thông quan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1079, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(539, 27);
            this.label8.TabIndex = 35;
            this.label8.Text = "Tích chọn shipment để giữ lại khi nhấn nút \"Xuất Kho\"";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(1069, 1059);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(227, 55);
            this.btnDong.TabIndex = 33;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // grvShipmentsWaitConfirmed
            // 
            this.grvShipmentsWaitConfirmed.AllowUserToAddRows = false;
            this.grvShipmentsWaitConfirmed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipmentsWaitConfirmed.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipmentsWaitConfirmed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipmentsWaitConfirmed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvShipmentsWaitConfirmed.Location = new System.Drawing.Point(3, 42);
            this.grvShipmentsWaitConfirmed.Name = "grvShipmentsWaitConfirmed";
            this.grvShipmentsWaitConfirmed.RowTemplate.Height = 33;
            this.grvShipmentsWaitConfirmed.Size = new System.Drawing.Size(1584, 847);
            this.grvShipmentsWaitConfirmed.TabIndex = 24;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThoat.Location = new System.Drawing.Point(1423, 87);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(197, 87);
            this.btnThoat.TabIndex = 49;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXuatKhoConfirmed
            // 
            this.btnXuatKhoConfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatKhoConfirmed.ForeColor = System.Drawing.Color.Green;
            this.btnXuatKhoConfirmed.Location = new System.Drawing.Point(1198, 87);
            this.btnXuatKhoConfirmed.Name = "btnXuatKhoConfirmed";
            this.btnXuatKhoConfirmed.Size = new System.Drawing.Size(197, 87);
            this.btnXuatKhoConfirmed.TabIndex = 50;
            this.btnXuatKhoConfirmed.Text = "Xuất Kho";
            this.btnXuatKhoConfirmed.UseVisualStyleBackColor = true;
            this.btnXuatKhoConfirmed.Click += new System.EventHandler(this.btnXuatKhoConfirmed_Click);
            // 
            // FormChoThongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1649, 1122);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChoThongQuan";
            this.Text = "Hàng chờ thông quan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChoThongQuan_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentsWaitConfirmed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtShipmentIdBlock;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView grvShipmentsWaitConfirmed;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXuatKhoConfirmed;
    }
}