namespace RapidWarehouse
{
    partial class FormXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXuat));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbbBoxIdOut = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbbMasterBillOut = new System.Windows.Forms.ComboBox();
            this.btnOpenBoxOut = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.txtSearchOut = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblShipmentScanedOut = new System.Windows.Forms.Label();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.lblBoxIdOut = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblMasterBillOut = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grvShipmentListOut = new System.Windows.Forms.DataGridView();
            this.lblXuatKho = new System.Windows.Forms.Label();
            this.lblVuaNhapOut = new System.Windows.Forms.Label();
            this.txtShipmentIdOut = new System.Windows.Forms.TextBox();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentListOut)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnPrint);
            this.groupBox6.Controls.Add(this.cbbBoxIdOut);
            this.groupBox6.Controls.Add(this.btnThoat);
            this.groupBox6.Controls.Add(this.cbbMasterBillOut);
            this.groupBox6.Controls.Add(this.btnOpenBoxOut);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.dtpNgayXuat);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(23, 83);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(1209, 139);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nhập thông tin";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Location = new System.Drawing.Point(1045, 23);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 99);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbbBoxIdOut
            // 
            this.cbbBoxIdOut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBoxIdOut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBoxIdOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbbBoxIdOut.FormattingEnabled = true;
            this.cbbBoxIdOut.Location = new System.Drawing.Point(440, 81);
            this.cbbBoxIdOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbBoxIdOut.Name = "cbbBoxIdOut";
            this.cbbBoxIdOut.Size = new System.Drawing.Size(273, 33);
            this.cbbBoxIdOut.TabIndex = 3;
            this.cbbBoxIdOut.SelectedIndexChanged += new System.EventHandler(this.cbbBoxIdOut_SelectedIndexChanged);
            this.cbbBoxIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbBoxIdOut_KeyDown);
            this.cbbBoxIdOut.Leave += new System.EventHandler(this.cbbBoxIdOut_Leave);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThoat.Location = new System.Drawing.Point(1124, 23);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(74, 99);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbbMasterBillOut
            // 
            this.cbbMasterBillOut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbMasterBillOut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbMasterBillOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbbMasterBillOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbbMasterBillOut.FormattingEnabled = true;
            this.cbbMasterBillOut.Location = new System.Drawing.Point(165, 81);
            this.cbbMasterBillOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbMasterBillOut.Name = "cbbMasterBillOut";
            this.cbbMasterBillOut.Size = new System.Drawing.Size(260, 33);
            this.cbbMasterBillOut.TabIndex = 2;
            this.cbbMasterBillOut.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBillOut_SelectedIndexChanged);
            this.cbbMasterBillOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBillOut_KeyDown);
            this.cbbMasterBillOut.Leave += new System.EventHandler(this.cbbMasterBillOut_Leave);
            // 
            // btnOpenBoxOut
            // 
            this.btnOpenBoxOut.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOpenBoxOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnOpenBoxOut.ForeColor = System.Drawing.Color.Red;
            this.btnOpenBoxOut.Location = new System.Drawing.Point(838, 23);
            this.btnOpenBoxOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpenBoxOut.Name = "btnOpenBoxOut";
            this.btnOpenBoxOut.Size = new System.Drawing.Size(198, 99);
            this.btnOpenBoxOut.TabIndex = 4;
            this.btnOpenBoxOut.Text = "Mở";
            this.btnOpenBoxOut.UseVisualStyleBackColor = false;
            this.btnOpenBoxOut.Click += new System.EventHandler(this.btnOpenBoxOut_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(445, 53);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 25);
            this.label14.TabIndex = 48;
            this.label14.Text = "Mã thùng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(170, 53);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 25);
            this.label15.TabIndex = 47;
            this.label15.Text = "MAWB";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(11, 53);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 25);
            this.label16.TabIndex = 46;
            this.label16.Text = "Ngày xuất";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuat.Location = new System.Drawing.Point(9, 81);
            this.dtpNgayXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(140, 28);
            this.dtpNgayXuat.TabIndex = 1;
            //this.dtpNgayXuat.ValueChanged += new System.EventHandler(this.dtpNgayXuat_ValueChanged);
            this.dtpNgayXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpNgayXuat_KeyDown);
            this.dtpNgayXuat.Leave += new System.EventHandler(this.dtpNgayXuat_Leave);
            // 
            // txtSearchOut
            // 
            this.txtSearchOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchOut.Location = new System.Drawing.Point(925, 484);
            this.txtSearchOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchOut.Name = "txtSearchOut";
            this.txtSearchOut.Size = new System.Drawing.Size(297, 30);
            this.txtSearchOut.TabIndex = 8;
            this.txtSearchOut.Text = "NHẬP MÃ ĐỂ TÌM KIẾM";
            this.txtSearchOut.Enter += new System.EventHandler(this.txtSearchOut_Enter);
            this.txtSearchOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchOut_KeyDown);
            this.txtSearchOut.Leave += new System.EventHandler(this.txtSearchOut_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblShipmentScanedOut);
            this.panel2.Controls.Add(this.lblNgayXuat);
            this.panel2.Controls.Add(this.lblBoxIdOut);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.lblMasterBillOut);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(23, 257);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1198, 200);
            this.panel2.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(885, 66);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 26);
            this.label11.TabIndex = 32;
            this.label11.Text = "Tổng số : ";
            // 
            // lblShipmentScanedOut
            // 
            this.lblShipmentScanedOut.AutoSize = true;
            this.lblShipmentScanedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentScanedOut.ForeColor = System.Drawing.Color.Red;
            this.lblShipmentScanedOut.Location = new System.Drawing.Point(1016, 33);
            this.lblShipmentScanedOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShipmentScanedOut.Name = "lblShipmentScanedOut";
            this.lblShipmentScanedOut.Size = new System.Drawing.Size(98, 69);
            this.lblShipmentScanedOut.TabIndex = 29;
            this.lblShipmentScanedOut.Text = "99";
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.ForeColor = System.Drawing.Color.Lime;
            this.lblNgayXuat.Location = new System.Drawing.Point(4, 18);
            this.lblNgayXuat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(119, 26);
            this.lblNgayXuat.TabIndex = 5;
            this.lblNgayXuat.Text = "Ngày xuất";
            // 
            // lblBoxIdOut
            // 
            this.lblBoxIdOut.AutoSize = true;
            this.lblBoxIdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxIdOut.ForeColor = System.Drawing.Color.Aqua;
            this.lblBoxIdOut.Location = new System.Drawing.Point(10, 121);
            this.lblBoxIdOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoxIdOut.Name = "lblBoxIdOut";
            this.lblBoxIdOut.Size = new System.Drawing.Size(158, 58);
            this.lblBoxIdOut.TabIndex = 3;
            this.lblBoxIdOut.Text = "BoxId";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkGray;
            this.label21.Location = new System.Drawing.Point(6, 94);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(146, 26);
            this.label21.TabIndex = 2;
            this.label21.Text = "Đang xử lý : ";
            // 
            // lblMasterBillOut
            // 
            this.lblMasterBillOut.AutoSize = true;
            this.lblMasterBillOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBillOut.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBillOut.Location = new System.Drawing.Point(162, 11);
            this.lblMasterBillOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMasterBillOut.Name = "lblMasterBillOut";
            this.lblMasterBillOut.Size = new System.Drawing.Size(149, 46);
            this.lblMasterBillOut.TabIndex = 1;
            this.lblMasterBillOut.Text = "MAWB";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.grvShipmentListOut);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 522);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(1233, 645);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đơn hàng";
            // 
            // grvShipmentListOut
            // 
            this.grvShipmentListOut.AllowUserToAddRows = false;
            this.grvShipmentListOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvShipmentListOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipmentListOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipmentListOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipmentListOut.Location = new System.Drawing.Point(2, 29);
            this.grvShipmentListOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grvShipmentListOut.Name = "grvShipmentListOut";
            this.grvShipmentListOut.RowTemplate.Height = 33;
            this.grvShipmentListOut.Size = new System.Drawing.Size(1226, 585);
            this.grvShipmentListOut.TabIndex = 9;
            this.grvShipmentListOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipmentListOut_CellClick);
            this.grvShipmentListOut.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipmentListOut_CellEndEdit);
            // 
            // lblXuatKho
            // 
            this.lblXuatKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXuatKho.AutoSize = true;
            this.lblXuatKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXuatKho.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblXuatKho.Location = new System.Drawing.Point(500, 21);
            this.lblXuatKho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXuatKho.Name = "lblXuatKho";
            this.lblXuatKho.Size = new System.Drawing.Size(192, 46);
            this.lblXuatKho.TabIndex = 47;
            this.lblXuatKho.Text = "Xuất Kho";
            // 
            // lblVuaNhapOut
            // 
            this.lblVuaNhapOut.AutoSize = true;
            this.lblVuaNhapOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuaNhapOut.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblVuaNhapOut.Location = new System.Drawing.Point(308, 478);
            this.lblVuaNhapOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVuaNhapOut.Name = "lblVuaNhapOut";
            this.lblVuaNhapOut.Size = new System.Drawing.Size(396, 37);
            this.lblVuaNhapOut.TabIndex = 48;
            this.lblVuaNhapOut.Text = "LMPDS-371715458-5699";
            // 
            // txtShipmentIdOut
            // 
            this.txtShipmentIdOut.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtShipmentIdOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentIdOut.Location = new System.Drawing.Point(23, 484);
            this.txtShipmentIdOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtShipmentIdOut.Name = "txtShipmentIdOut";
            this.txtShipmentIdOut.Size = new System.Drawing.Size(281, 26);
            this.txtShipmentIdOut.TabIndex = 7;
            this.txtShipmentIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipmentIdOut_KeyDown);
            // 
            // FormXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1256, 830);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtSearchOut);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblXuatKho);
            this.Controls.Add(this.lblVuaNhapOut);
            this.Controls.Add(this.txtShipmentIdOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất kho - Rapid Logistics v1.0.17";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormXuat_FormClosed);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentListOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbbBoxIdOut;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbbMasterBillOut;
        private System.Windows.Forms.Button btnOpenBoxOut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.TextBox txtSearchOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblShipmentScanedOut;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.Label lblBoxIdOut;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblMasterBillOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grvShipmentListOut;
        private System.Windows.Forms.Label lblXuatKho;
        private System.Windows.Forms.Label lblVuaNhapOut;
        private System.Windows.Forms.TextBox txtShipmentIdOut;
    }
}