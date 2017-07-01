namespace RapidWarehouse
{
    partial class FormBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaoCao));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnKeChiTietSanLuongTonKho = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSanLuongTonKho = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.cbbBoxIdReport = new System.Windows.Forms.ComboBox();
            this.btnChiTietTheoThung = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnChiTietSanLuong = new System.Windows.Forms.Button();
            this.cbbMasterList = new System.Windows.Forms.ComboBox();
            this.btnSanLuongNhap = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayBaoCao = new System.Windows.Forms.DateTimePicker();
            this.tabNhap = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbBoxId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMasterBill = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpNgayXuatReport = new System.Windows.Forms.DateTimePicker();
            this.btnChiTietXuatKho = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabNhap.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnKeChiTietSanLuongTonKho);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.dtpTo);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.dtpFrom);
            this.tabPage3.Controls.Add(this.btnSanLuongTonKho);
            this.tabPage3.Location = new System.Drawing.Point(4, 56);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1527, 929);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Báo Cáo Tồn Kho, Đối Soát Ca        ";
            // 
            // btnKeChiTietSanLuongTonKho
            // 
            this.btnKeChiTietSanLuongTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeChiTietSanLuongTonKho.Location = new System.Drawing.Point(821, 176);
            this.btnKeChiTietSanLuongTonKho.Name = "btnKeChiTietSanLuongTonKho";
            this.btnKeChiTietSanLuongTonKho.Size = new System.Drawing.Size(283, 146);
            this.btnKeChiTietSanLuongTonKho.TabIndex = 51;
            this.btnKeChiTietSanLuongTonKho.Text = "Bảng kê chi tiết sản lượng tồn kho";
            this.btnKeChiTietSanLuongTonKho.UseVisualStyleBackColor = true;
            this.btnKeChiTietSanLuongTonKho.Click += new System.EventHandler(this.btnKeChiTietSanLuongTonKho_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(721, 99);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 29);
            this.label23.TabIndex = 50;
            this.label23.Text = "Đến ngày :";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(886, 99);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(186, 31);
            this.dtpTo.TabIndex = 49;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(314, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 29);
            this.label22.TabIndex = 48;
            this.label22.Text = "Từ ngày:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(479, 99);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(186, 31);
            this.dtpFrom.TabIndex = 47;
            // 
            // btnSanLuongTonKho
            // 
            this.btnSanLuongTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanLuongTonKho.Location = new System.Drawing.Point(379, 176);
            this.btnSanLuongTonKho.Name = "btnSanLuongTonKho";
            this.btnSanLuongTonKho.Size = new System.Drawing.Size(283, 146);
            this.btnSanLuongTonKho.TabIndex = 46;
            this.btnSanLuongTonKho.Text = "Tổng hợp sản lượng tồn kho";
            this.btnSanLuongTonKho.UseVisualStyleBackColor = true;
            this.btnSanLuongTonKho.Click += new System.EventHandler(this.btnSanLuongTonKho_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cbbBoxIdReport);
            this.tabPage1.Controls.Add(this.btnChiTietTheoThung);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.btnChiTietSanLuong);
            this.tabPage1.Controls.Add(this.cbbMasterList);
            this.tabPage1.Controls.Add(this.btnSanLuongNhap);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dtpNgayBaoCao);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 56);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1527, 929);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "        Báo Cáo Xác Nhận Đến        ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(908, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 29);
            this.label19.TabIndex = 51;
            this.label19.Text = "Thùng :";
            // 
            // cbbBoxIdReport
            // 
            this.cbbBoxIdReport.FormattingEnabled = true;
            this.cbbBoxIdReport.Location = new System.Drawing.Point(1028, 94);
            this.cbbBoxIdReport.Name = "cbbBoxIdReport";
            this.cbbBoxIdReport.Size = new System.Drawing.Size(308, 33);
            this.cbbBoxIdReport.TabIndex = 50;
            this.cbbBoxIdReport.SelectedIndexChanged += new System.EventHandler(this.cbbBoxIdReport_SelectedIndexChanged);
            this.cbbBoxIdReport.Leave += new System.EventHandler(this.cbbBoxIdReport_Leave);
            // 
            // btnChiTietTheoThung
            // 
            this.btnChiTietTheoThung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietTheoThung.Location = new System.Drawing.Point(1028, 165);
            this.btnChiTietTheoThung.Name = "btnChiTietTheoThung";
            this.btnChiTietTheoThung.Size = new System.Drawing.Size(283, 146);
            this.btnChiTietTheoThung.TabIndex = 49;
            this.btnChiTietTheoThung.Text = "Báo cáo chi tiết sản lượng nhập kho (theo thùng)";
            this.btnChiTietTheoThung.UseVisualStyleBackColor = true;
            this.btnChiTietTheoThung.Click += new System.EventHandler(this.btnChiTietTheoThung_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(405, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 29);
            this.label18.TabIndex = 48;
            this.label18.Text = "MAWB :";
            // 
            // btnChiTietSanLuong
            // 
            this.btnChiTietSanLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietSanLuong.Location = new System.Drawing.Point(551, 165);
            this.btnChiTietSanLuong.Name = "btnChiTietSanLuong";
            this.btnChiTietSanLuong.Size = new System.Drawing.Size(283, 146);
            this.btnChiTietSanLuong.TabIndex = 47;
            this.btnChiTietSanLuong.Text = "Báo cáo chi tiết sản lượng nhập kho";
            this.btnChiTietSanLuong.UseVisualStyleBackColor = true;
            this.btnChiTietSanLuong.Click += new System.EventHandler(this.btnChiTietSanLuong_Click);
            // 
            // cbbMasterList
            // 
            this.cbbMasterList.FormattingEnabled = true;
            this.cbbMasterList.Location = new System.Drawing.Point(522, 96);
            this.cbbMasterList.Name = "cbbMasterList";
            this.cbbMasterList.Size = new System.Drawing.Size(329, 33);
            this.cbbMasterList.TabIndex = 46;
            this.cbbMasterList.SelectedIndexChanged += new System.EventHandler(this.cbbMasterList_SelectedIndexChanged);
            this.cbbMasterList.Leave += new System.EventHandler(this.cbbMasterList_Leave);
            // 
            // btnSanLuongNhap
            // 
            this.btnSanLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanLuongNhap.Location = new System.Drawing.Point(86, 165);
            this.btnSanLuongNhap.Name = "btnSanLuongNhap";
            this.btnSanLuongNhap.Size = new System.Drawing.Size(283, 146);
            this.btnSanLuongNhap.TabIndex = 45;
            this.btnSanLuongNhap.Text = "Báo cáo sản lượng nhập kho";
            this.btnSanLuongNhap.UseVisualStyleBackColor = true;
            this.btnSanLuongNhap.Click += new System.EventHandler(this.btnSanLuongNhap_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(21, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 29);
            this.label7.TabIndex = 44;
            this.label7.Text = "Ngày đến :";
            // 
            // dtpNgayBaoCao
            // 
            this.dtpNgayBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBaoCao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBaoCao.Location = new System.Drawing.Point(186, 96);
            this.dtpNgayBaoCao.Name = "dtpNgayBaoCao";
            this.dtpNgayBaoCao.Size = new System.Drawing.Size(186, 31);
            this.dtpNgayBaoCao.TabIndex = 43;
            this.dtpNgayBaoCao.ValueChanged += new System.EventHandler(this.dtpNgayBaoCao_ValueChanged);
            // 
            // tabNhap
            // 
            this.tabNhap.Controls.Add(this.tabPage1);
            this.tabNhap.Controls.Add(this.tabPage2);
            this.tabNhap.Controls.Add(this.tabPage3);
            this.tabNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabNhap.Location = new System.Drawing.Point(0, 0);
            this.tabNhap.Name = "tabNhap";
            this.tabNhap.Padding = new System.Drawing.Point(6, 12);
            this.tabNhap.SelectedIndex = 0;
            this.tabNhap.Size = new System.Drawing.Size(1535, 989);
            this.tabNhap.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbbBoxId);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbbMasterBill);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.dtpNgayXuatReport);
            this.tabPage2.Controls.Add(this.btnChiTietXuatKho);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 56);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1527, 929);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "        Báo Cáo Xuất Kho        ";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.OliveDrab;
            this.button2.Location = new System.Drawing.Point(1030, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(283, 146);
            this.button2.TabIndex = 57;
            this.button2.Text = "Bảng kê chi tiết sản lượng xuất kho theo thùng";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(524, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 146);
            this.button1.TabIndex = 56;
            this.button1.Text = "Bảng kê chi tiết sản lượng xuất kho theo MAWB";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(910, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 55;
            this.label1.Text = "Thùng :";
            // 
            // cbbBoxId
            // 
            this.cbbBoxId.FormattingEnabled = true;
            this.cbbBoxId.Location = new System.Drawing.Point(1030, 92);
            this.cbbBoxId.Name = "cbbBoxId";
            this.cbbBoxId.Size = new System.Drawing.Size(308, 33);
            this.cbbBoxId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(407, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "MAWB :";
            // 
            // cbbMasterBill
            // 
            this.cbbMasterBill.FormattingEnabled = true;
            this.cbbMasterBill.Location = new System.Drawing.Point(524, 94);
            this.cbbMasterBill.Name = "cbbMasterBill";
            this.cbbMasterBill.Size = new System.Drawing.Size(329, 33);
            this.cbbMasterBill.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(16, 94);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 29);
            this.label20.TabIndex = 48;
            this.label20.Text = "Ngày xuất :";
            // 
            // dtpNgayXuatReport
            // 
            this.dtpNgayXuatReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuatReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuatReport.Location = new System.Drawing.Point(181, 94);
            this.dtpNgayXuatReport.Name = "dtpNgayXuatReport";
            this.dtpNgayXuatReport.Size = new System.Drawing.Size(186, 31);
            this.dtpNgayXuatReport.TabIndex = 1;
            // 
            // btnChiTietXuatKho
            // 
            this.btnChiTietXuatKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietXuatKho.Location = new System.Drawing.Point(82, 163);
            this.btnChiTietXuatKho.Name = "btnChiTietXuatKho";
            this.btnChiTietXuatKho.Size = new System.Drawing.Size(283, 146);
            this.btnChiTietXuatKho.TabIndex = 4;
            this.btnChiTietXuatKho.Text = "Bảng kê chi tiết sản lượng xuất kho";
            this.btnChiTietXuatKho.UseVisualStyleBackColor = true;
            this.btnChiTietXuatKho.Click += new System.EventHandler(this.btnChiTietXuatKho_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(432, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 48);
            this.label3.TabIndex = 58;
            this.label3.Text = "Báo cáo xuất kho - Hàng đi";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(431, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(451, 48);
            this.label4.TabIndex = 52;
            this.label4.Text = "Báo cáo xác nhận đến";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(441, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(513, 48);
            this.label5.TabIndex = 59;
            this.label5.Text = "Báo cáo tồn kho, đối soát";
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1535, 989);
            this.Controls.Add(this.tabNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBaoCao";
            this.Text = "Các Báo Cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBaoCao_FormClosed);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabNhap.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnKeChiTietSanLuongTonKho;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnSanLuongTonKho;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbbBoxIdReport;
        private System.Windows.Forms.Button btnChiTietTheoThung;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnChiTietSanLuong;
        private System.Windows.Forms.ComboBox cbbMasterList;
        private System.Windows.Forms.Button btnSanLuongNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNgayBaoCao;
        private System.Windows.Forms.TabControl tabNhap;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpNgayXuatReport;
        private System.Windows.Forms.Button btnChiTietXuatKho;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbBoxId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbMasterBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}