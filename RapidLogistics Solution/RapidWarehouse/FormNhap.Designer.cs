﻿namespace RapidWarehouse
{
    partial class FormNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhap));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbbBoxId = new System.Windows.Forms.ComboBox();
            this.cbbMasterBill = new System.Windows.Forms.ComboBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayDen = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDonDaQuet = new System.Windows.Forms.Label();
            this.lblThungDaQuet = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShipmentScaned = new System.Windows.Forms.Label();
            this.lblNgayDen = new System.Windows.Forms.Label();
            this.lblBoxId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMasterBill = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grvShipments = new System.Windows.Forms.DataGridView();
            this.lblMaVuaNhap = new System.Windows.Forms.Label();
            this.txtShipmentId = new System.Windows.Forms.TextBox();
            this.btnXNĐ = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipments)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnXNĐ);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.cbbBoxId);
            this.groupBox3.Controls.Add(this.cbbMasterBill);
            this.groupBox3.Controls.Add(this.btnOpenClose);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpNgayDen);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(37, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1593, 177);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhập thông tin";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(1473, 24);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 120);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Location = new System.Drawing.Point(1366, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 120);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbbBoxId
            // 
            this.cbbBoxId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBoxId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBoxId.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbbBoxId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBoxId.FormattingEnabled = true;
            this.cbbBoxId.Location = new System.Drawing.Point(575, 101);
            this.cbbBoxId.Name = "cbbBoxId";
            this.cbbBoxId.Size = new System.Drawing.Size(363, 33);
            this.cbbBoxId.TabIndex = 3;
            this.cbbBoxId.SelectedIndexChanged += new System.EventHandler(this.cbbBoxId_SelectedIndexChanged);
            this.cbbBoxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbBoxId_KeyDown);
            this.cbbBoxId.Leave += new System.EventHandler(this.cbbBoxId_Leave);
            // 
            // cbbMasterBill
            // 
            this.cbbMasterBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbMasterBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbMasterBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbbMasterBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMasterBill.FormattingEnabled = true;
            this.cbbMasterBill.Location = new System.Drawing.Point(224, 101);
            this.cbbMasterBill.Name = "cbbMasterBill";
            this.cbbMasterBill.Size = new System.Drawing.Size(321, 33);
            this.cbbMasterBill.TabIndex = 2;
            this.cbbMasterBill.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBill_SelectedIndexChanged);
            this.cbbMasterBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBill_KeyDown);
            this.cbbMasterBill.Leave += new System.EventHandler(this.cbbMasterBill_Leave);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnOpenClose.ForeColor = System.Drawing.Color.Red;
            this.btnOpenClose.Location = new System.Drawing.Point(1182, 24);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(172, 120);
            this.btnOpenClose.TabIndex = 5;
            this.btnOpenClose.Text = "Mở";
            this.btnOpenClose.UseVisualStyleBackColor = false;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(569, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 31);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mã Thùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(218, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 28;
            this.label2.Text = "MAWB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 31);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ngày đến";
            // 
            // dtpNgayDen
            // 
            this.dtpNgayDen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDen.Location = new System.Drawing.Point(15, 103);
            this.dtpNgayDen.Name = "dtpNgayDen";
            this.dtpNgayDen.Size = new System.Drawing.Size(172, 33);
            this.dtpNgayDen.TabIndex = 1;
            this.dtpNgayDen.ValueChanged += new System.EventHandler(this.dtpNgayDen_ValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(1219, 557);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(395, 31);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.Text = "NHẬP MÃ ĐỂ TÌM KIẾM";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(584, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(370, 63);
            this.label10.TabIndex = 38;
            this.label10.Text = "Xác nhận đến";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblDonDaQuet);
            this.panel1.Controls.Add(this.lblThungDaQuet);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblShipmentScaned);
            this.panel1.Controls.Add(this.lblNgayDen);
            this.panel1.Controls.Add(this.lblBoxId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblMasterBill);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(37, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1593, 255);
            this.panel1.TabIndex = 37;
            // 
            // lblDonDaQuet
            // 
            this.lblDonDaQuet.AutoSize = true;
            this.lblDonDaQuet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonDaQuet.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDonDaQuet.Location = new System.Drawing.Point(1402, 74);
            this.lblDonDaQuet.Name = "lblDonDaQuet";
            this.lblDonDaQuet.Size = new System.Drawing.Size(72, 51);
            this.lblDonDaQuet.TabIndex = 34;
            this.lblDonDaQuet.Text = "68";
            // 
            // lblThungDaQuet
            // 
            this.lblThungDaQuet.AutoSize = true;
            this.lblThungDaQuet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThungDaQuet.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblThungDaQuet.Location = new System.Drawing.Point(1402, 11);
            this.lblThungDaQuet.Name = "lblThungDaQuet";
            this.lblThungDaQuet.Size = new System.Drawing.Size(47, 51);
            this.lblThungDaQuet.TabIndex = 33;
            this.lblThungDaQuet.Text = "5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkGray;
            this.label12.Location = new System.Drawing.Point(1227, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 36);
            this.label12.TabIndex = 32;
            this.label12.Text = "Tổng số : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(1087, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 36);
            this.label5.TabIndex = 31;
            this.label5.Text = "Đơn đã xác nhận : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(1087, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 36);
            this.label4.TabIndex = 30;
            this.label4.Text = "Thùng đã xác nhận : ";
            // 
            // lblShipmentScaned
            // 
            this.lblShipmentScaned.AutoSize = true;
            this.lblShipmentScaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentScaned.ForeColor = System.Drawing.Color.Magenta;
            this.lblShipmentScaned.Location = new System.Drawing.Point(1383, 151);
            this.lblShipmentScaned.Name = "lblShipmentScaned";
            this.lblShipmentScaned.Size = new System.Drawing.Size(129, 91);
            this.lblShipmentScaned.TabIndex = 29;
            this.lblShipmentScaned.Text = "88";
            // 
            // lblNgayDen
            // 
            this.lblNgayDen.AutoSize = true;
            this.lblNgayDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDen.ForeColor = System.Drawing.Color.Lime;
            this.lblNgayDen.Location = new System.Drawing.Point(4, 22);
            this.lblNgayDen.Name = "lblNgayDen";
            this.lblNgayDen.Size = new System.Drawing.Size(151, 36);
            this.lblNgayDen.TabIndex = 5;
            this.lblNgayDen.Text = "Ngày đến";
            // 
            // lblBoxId
            // 
            this.lblBoxId.AutoSize = true;
            this.lblBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxId.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblBoxId.Location = new System.Drawing.Point(4, 179);
            this.lblBoxId.Name = "lblBoxId";
            this.lblBoxId.Size = new System.Drawing.Size(52, 76);
            this.lblBoxId.TabIndex = 3;
            this.lblBoxId.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(4, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 36);
            this.label6.TabIndex = 2;
            this.label6.Text = "Đang xử lý : ";
            // 
            // lblMasterBill
            // 
            this.lblMasterBill.AutoSize = true;
            this.lblMasterBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBill.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBill.Location = new System.Drawing.Point(173, 14);
            this.lblMasterBill.Name = "lblMasterBill";
            this.lblMasterBill.Size = new System.Drawing.Size(199, 63);
            this.lblMasterBill.TabIndex = 1;
            this.lblMasterBill.Text = "MAWB";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.grvShipments);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 607);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1601, 842);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đơn hàng";
            // 
            // grvShipments
            // 
            this.grvShipments.AllowUserToAddRows = false;
            this.grvShipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvShipments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grvShipments.Location = new System.Drawing.Point(3, 34);
            this.grvShipments.Name = "grvShipments";
            this.grvShipments.RowTemplate.Height = 33;
            this.grvShipments.Size = new System.Drawing.Size(1595, 805);
            this.grvShipments.TabIndex = 9;
            this.grvShipments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipments_CellClick);
            // 
            // lblMaVuaNhap
            // 
            this.lblMaVuaNhap.AutoSize = true;
            this.lblMaVuaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVuaNhap.ForeColor = System.Drawing.Color.Red;
            this.lblMaVuaNhap.Location = new System.Drawing.Point(445, 549);
            this.lblMaVuaNhap.Name = "lblMaVuaNhap";
            this.lblMaVuaNhap.Size = new System.Drawing.Size(249, 44);
            this.lblMaVuaNhap.TabIndex = 35;
            this.lblMaVuaNhap.Text = "Mã vừa nhập";
            // 
            // txtShipmentId
            // 
            this.txtShipmentId.BackColor = System.Drawing.Color.White;
            this.txtShipmentId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentId.Location = new System.Drawing.Point(37, 555);
            this.txtShipmentId.Name = "txtShipmentId";
            this.txtShipmentId.Size = new System.Drawing.Size(395, 31);
            this.txtShipmentId.TabIndex = 8;
            this.txtShipmentId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShipmentId_KeyPress);
            // 
            // btnXNĐ
            // 
            this.btnXNĐ.BackColor = System.Drawing.Color.Transparent;
            this.btnXNĐ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnXNĐ.ForeColor = System.Drawing.Color.Green;
            this.btnXNĐ.Location = new System.Drawing.Point(960, 24);
            this.btnXNĐ.Name = "btnXNĐ";
            this.btnXNĐ.Size = new System.Drawing.Size(216, 120);
            this.btnXNĐ.TabIndex = 4;
            this.btnXNĐ.Text = "XN Đến";
            this.btnXNĐ.UseVisualStyleBackColor = false;
            this.btnXNĐ.Click += new System.EventHandler(this.btnXNĐ_Click);
            // 
            // FormNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1675, 1466);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMaVuaNhap);
            this.Controls.Add(this.txtShipmentId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận đến - Rapid Logistics v1.0.17";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNhap_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvShipments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbbBoxId;
        private System.Windows.Forms.ComboBox cbbMasterBill;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayDen;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDonDaQuet;
        private System.Windows.Forms.Label lblThungDaQuet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShipmentScaned;
        private System.Windows.Forms.Label lblNgayDen;
        private System.Windows.Forms.Label lblBoxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMasterBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grvShipments;
        private System.Windows.Forms.Label lblMaVuaNhap;
        private System.Windows.Forms.TextBox txtShipmentId;
        private System.Windows.Forms.Button btnXNĐ;
    }
}

