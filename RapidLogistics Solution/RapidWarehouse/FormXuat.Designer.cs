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
            this.lblDonDaQuetOut = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDonDaXuat = new System.Windows.Forms.Label();
            this.lblThungDaQuetOut = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.groupBox6.Location = new System.Drawing.Point(31, 104);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1612, 201);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nhập thông tin";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Location = new System.Drawing.Point(1393, 66);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 87);
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
            this.cbbBoxIdOut.Location = new System.Drawing.Point(587, 101);
            this.cbbBoxIdOut.Name = "cbbBoxIdOut";
            this.cbbBoxIdOut.Size = new System.Drawing.Size(363, 39);
            this.cbbBoxIdOut.TabIndex = 3;
            this.cbbBoxIdOut.SelectedIndexChanged += new System.EventHandler(this.cbbBoxIdOut_SelectedIndexChanged);
            this.cbbBoxIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbBoxIdOut_KeyDown);
            this.cbbBoxIdOut.Leave += new System.EventHandler(this.cbbBoxIdOut_Leave);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThoat.Location = new System.Drawing.Point(1499, 66);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 87);
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
            this.cbbMasterBillOut.Location = new System.Drawing.Point(220, 101);
            this.cbbMasterBillOut.Name = "cbbMasterBillOut";
            this.cbbMasterBillOut.Size = new System.Drawing.Size(345, 39);
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
            this.btnOpenBoxOut.Location = new System.Drawing.Point(1117, 66);
            this.btnOpenBoxOut.Name = "btnOpenBoxOut";
            this.btnOpenBoxOut.Size = new System.Drawing.Size(264, 87);
            this.btnOpenBoxOut.TabIndex = 4;
            this.btnOpenBoxOut.Text = "Mở";
            this.btnOpenBoxOut.UseVisualStyleBackColor = false;
            this.btnOpenBoxOut.Click += new System.EventHandler(this.btnOpenBoxOut_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(593, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 31);
            this.label14.TabIndex = 48;
            this.label14.Text = "Mã thùng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(226, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 31);
            this.label15.TabIndex = 47;
            this.label15.Text = "MAWB";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(15, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 31);
            this.label16.TabIndex = 46;
            this.label16.Text = "Ngày xuất";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuat.Location = new System.Drawing.Point(12, 101);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(186, 35);
            this.dtpNgayXuat.TabIndex = 1;
            this.dtpNgayXuat.ValueChanged += new System.EventHandler(this.dtpNgayXuat_ValueChanged);
            // 
            // txtSearchOut
            // 
            this.txtSearchOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchOut.Location = new System.Drawing.Point(1233, 605);
            this.txtSearchOut.Name = "txtSearchOut";
            this.txtSearchOut.Size = new System.Drawing.Size(395, 38);
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
            this.panel2.Controls.Add(this.lblDonDaQuetOut);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblDonDaXuat);
            this.panel2.Controls.Add(this.lblThungDaQuetOut);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.lblShipmentScanedOut);
            this.panel2.Controls.Add(this.lblNgayXuat);
            this.panel2.Controls.Add(this.lblBoxIdOut);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.lblMasterBillOut);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(31, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1597, 249);
            this.panel2.TabIndex = 46;
            // 
            // lblDonDaQuetOut
            // 
            this.lblDonDaQuetOut.AutoSize = true;
            this.lblDonDaQuetOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonDaQuetOut.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblDonDaQuetOut.Location = new System.Drawing.Point(1444, 59);
            this.lblDonDaQuetOut.Name = "lblDonDaQuetOut";
            this.lblDonDaQuetOut.Size = new System.Drawing.Size(86, 44);
            this.lblDonDaQuetOut.TabIndex = 36;
            this.lblDonDaQuetOut.Text = "101";
            this.lblDonDaQuetOut.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(1154, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(293, 36);
            this.label9.TabIndex = 35;
            this.label9.Text = "Tổng đơn đã quét : ";
            this.label9.Visible = false;
            // 
            // lblDonDaXuat
            // 
            this.lblDonDaXuat.AutoSize = true;
            this.lblDonDaXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonDaXuat.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblDonDaXuat.Location = new System.Drawing.Point(1456, 104);
            this.lblDonDaXuat.Name = "lblDonDaXuat";
            this.lblDonDaXuat.Size = new System.Drawing.Size(86, 44);
            this.lblDonDaXuat.TabIndex = 34;
            this.lblDonDaXuat.Text = "201";
            // 
            // lblThungDaQuetOut
            // 
            this.lblThungDaQuetOut.AutoSize = true;
            this.lblThungDaQuetOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThungDaQuetOut.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblThungDaQuetOut.Location = new System.Drawing.Point(1446, 17);
            this.lblThungDaQuetOut.Name = "lblThungDaQuetOut";
            this.lblThungDaQuetOut.Size = new System.Drawing.Size(42, 44);
            this.lblThungDaQuetOut.TabIndex = 33;
            this.lblThungDaQuetOut.Text = "4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(1239, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 36);
            this.label11.TabIndex = 32;
            this.label11.Text = "Tổng số : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(1154, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(291, 36);
            this.label13.TabIndex = 31;
            this.label13.Text = "Tổng đơn đã xuất : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkGray;
            this.label17.Location = new System.Drawing.Point(1154, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(248, 36);
            this.label17.TabIndex = 30;
            this.label17.Text = "Thùng đã quét : ";
            // 
            // lblShipmentScanedOut
            // 
            this.lblShipmentScanedOut.AutoSize = true;
            this.lblShipmentScanedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentScanedOut.ForeColor = System.Drawing.Color.Red;
            this.lblShipmentScanedOut.Location = new System.Drawing.Point(1413, 150);
            this.lblShipmentScanedOut.Name = "lblShipmentScanedOut";
            this.lblShipmentScanedOut.Size = new System.Drawing.Size(129, 91);
            this.lblShipmentScanedOut.TabIndex = 29;
            this.lblShipmentScanedOut.Text = "99";
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.ForeColor = System.Drawing.Color.Lime;
            this.lblNgayXuat.Location = new System.Drawing.Point(5, 23);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(158, 36);
            this.lblNgayXuat.TabIndex = 5;
            this.lblNgayXuat.Text = "Ngày xuất";
            // 
            // lblBoxIdOut
            // 
            this.lblBoxIdOut.AutoSize = true;
            this.lblBoxIdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxIdOut.ForeColor = System.Drawing.Color.Aqua;
            this.lblBoxIdOut.Location = new System.Drawing.Point(13, 151);
            this.lblBoxIdOut.Name = "lblBoxIdOut";
            this.lblBoxIdOut.Size = new System.Drawing.Size(210, 76);
            this.lblBoxIdOut.TabIndex = 3;
            this.lblBoxIdOut.Text = "BoxId";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkGray;
            this.label21.Location = new System.Drawing.Point(8, 117);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(193, 36);
            this.label21.TabIndex = 2;
            this.label21.Text = "Đang xử lý : ";
            // 
            // lblMasterBillOut
            // 
            this.lblMasterBillOut.AutoSize = true;
            this.lblMasterBillOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBillOut.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBillOut.Location = new System.Drawing.Point(216, 14);
            this.lblMasterBillOut.Name = "lblMasterBillOut";
            this.lblMasterBillOut.Size = new System.Drawing.Size(199, 63);
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
            this.groupBox2.Location = new System.Drawing.Point(31, 652);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1644, 776);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đơn hàng";
            // 
            // grvShipmentListOut
            // 
            this.grvShipmentListOut.AllowUserToAddRows = false;
            this.grvShipmentListOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipmentListOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipmentListOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipmentListOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvShipmentListOut.Location = new System.Drawing.Point(3, 36);
            this.grvShipmentListOut.Name = "grvShipmentListOut";
            this.grvShipmentListOut.RowTemplate.Height = 33;
            this.grvShipmentListOut.Size = new System.Drawing.Size(1638, 737);
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
            this.lblXuatKho.Location = new System.Drawing.Point(667, 26);
            this.lblXuatKho.Name = "lblXuatKho";
            this.lblXuatKho.Size = new System.Drawing.Size(256, 63);
            this.lblXuatKho.TabIndex = 47;
            this.lblXuatKho.Text = "Xuất Kho";
            // 
            // lblVuaNhapOut
            // 
            this.lblVuaNhapOut.AutoSize = true;
            this.lblVuaNhapOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuaNhapOut.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblVuaNhapOut.Location = new System.Drawing.Point(410, 597);
            this.lblVuaNhapOut.Name = "lblVuaNhapOut";
            this.lblVuaNhapOut.Size = new System.Drawing.Size(531, 51);
            this.lblVuaNhapOut.TabIndex = 48;
            this.lblVuaNhapOut.Text = "LMPDS-371715458-5699";
            // 
            // txtShipmentIdOut
            // 
            this.txtShipmentIdOut.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtShipmentIdOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentIdOut.Location = new System.Drawing.Point(31, 605);
            this.txtShipmentIdOut.Name = "txtShipmentIdOut";
            this.txtShipmentIdOut.Size = new System.Drawing.Size(373, 31);
            this.txtShipmentIdOut.TabIndex = 7;
            this.txtShipmentIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipmentIdOut_KeyDown);
            // 
            // FormXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1675, 1448);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtSearchOut);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblXuatKho);
            this.Controls.Add(this.lblVuaNhapOut);
            this.Controls.Add(this.txtShipmentIdOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label lblDonDaQuetOut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDonDaXuat;
        private System.Windows.Forms.Label lblThungDaQuetOut;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
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