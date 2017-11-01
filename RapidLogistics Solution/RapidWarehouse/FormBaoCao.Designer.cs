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
            this.ccbQuarter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReportQuater = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKeChiTietSanLuongTonKho = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSanLuongTonKho = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
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
            this.chkBoxId = new System.Windows.Forms.CheckBox();
            this.chkMawb = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.btnReportView = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbReportCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbBoxIdOut = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMasterBillOut = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.tabPage3.Controls.Add(this.ccbQuarter);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.btnReportQuater);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnKeChiTietSanLuongTonKho);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.dtpTo);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.dtpFrom);
            this.tabPage3.Controls.Add(this.btnSanLuongTonKho);
            this.tabPage3.Location = new System.Drawing.Point(4, 52);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1248, 768);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "       Báo Cáo Tồn Kho, Đối Soát Ca        ";
            // 
            // ccbQuarter
            // 
            this.ccbQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbQuarter.FormattingEnabled = true;
            this.ccbQuarter.Items.AddRange(new object[] {
            "Q1",
            "Q2",
            "Q3",
            "Q4",
            "Q4 năm trước"});
            this.ccbQuarter.Location = new System.Drawing.Point(896, 86);
            this.ccbQuarter.Margin = new System.Windows.Forms.Padding(2);
            this.ccbQuarter.Name = "ccbQuarter";
            this.ccbQuarter.Size = new System.Drawing.Size(204, 33);
            this.ccbQuarter.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(828, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 25);
            this.label6.TabIndex = 61;
            this.label6.Text = "Qúy :";
            // 
            // btnReportQuater
            // 
            this.btnReportQuater.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportQuater.Location = new System.Drawing.Point(866, 157);
            this.btnReportQuater.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportQuater.Name = "btnReportQuater";
            this.btnReportQuater.Size = new System.Drawing.Size(232, 122);
            this.btnReportQuater.TabIndex = 60;
            this.btnReportQuater.Text = "Báo cáo quý đối với hàng tồn kho (chưa có người nhận)";
            this.btnReportQuater.UseVisualStyleBackColor = true;
            this.btnReportQuater.Click += new System.EventHandler(this.btnReportQuater_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(361, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(448, 40);
            this.label5.TabIndex = 59;
            this.label5.Text = "Báo cáo tồn kho, đối soát";
            // 
            // btnKeChiTietSanLuongTonKho
            // 
            this.btnKeChiTietSanLuongTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeChiTietSanLuongTonKho.Location = new System.Drawing.Point(511, 157);
            this.btnKeChiTietSanLuongTonKho.Margin = new System.Windows.Forms.Padding(2);
            this.btnKeChiTietSanLuongTonKho.Name = "btnKeChiTietSanLuongTonKho";
            this.btnKeChiTietSanLuongTonKho.Size = new System.Drawing.Size(232, 122);
            this.btnKeChiTietSanLuongTonKho.TabIndex = 51;
            this.btnKeChiTietSanLuongTonKho.Text = "Bảng kê chi tiết sản lượng tồn kho";
            this.btnKeChiTietSanLuongTonKho.UseVisualStyleBackColor = true;
            this.btnKeChiTietSanLuongTonKho.Click += new System.EventHandler(this.btnKeChiTietSanLuongTonKho_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(455, 90);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(117, 25);
            this.label23.TabIndex = 50;
            this.label23.Text = "Đến ngày :";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(590, 90);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(153, 28);
            this.dtpTo.TabIndex = 49;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(122, 90);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 25);
            this.label22.TabIndex = 48;
            this.label22.Text = "Từ ngày:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(257, 90);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(153, 28);
            this.dtpFrom.TabIndex = 47;
            // 
            // btnSanLuongTonKho
            // 
            this.btnSanLuongTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanLuongTonKho.Location = new System.Drawing.Point(148, 157);
            this.btnSanLuongTonKho.Margin = new System.Windows.Forms.Padding(2);
            this.btnSanLuongTonKho.Name = "btnSanLuongTonKho";
            this.btnSanLuongTonKho.Size = new System.Drawing.Size(232, 122);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 52);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1248, 768);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "        Báo Cáo Xác Nhận Đến        ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(352, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(395, 40);
            this.label4.TabIndex = 52;
            this.label4.Text = "Báo cáo xác nhận đến";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(743, 79);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 25);
            this.label19.TabIndex = 51;
            this.label19.Text = "Thùng :";
            // 
            // cbbBoxIdReport
            // 
            this.cbbBoxIdReport.FormattingEnabled = true;
            this.cbbBoxIdReport.Items.AddRange(new object[] {
            "===Tất cả==="});
            this.cbbBoxIdReport.Location = new System.Drawing.Point(841, 78);
            this.cbbBoxIdReport.Margin = new System.Windows.Forms.Padding(2);
            this.cbbBoxIdReport.Name = "cbbBoxIdReport";
            this.cbbBoxIdReport.Size = new System.Drawing.Size(253, 30);
            this.cbbBoxIdReport.TabIndex = 3;
            this.cbbBoxIdReport.SelectedIndexChanged += new System.EventHandler(this.cbbBoxIdReport_SelectedIndexChanged);
            this.cbbBoxIdReport.Leave += new System.EventHandler(this.cbbBoxIdReport_Leave);
            // 
            // btnChiTietTheoThung
            // 
            this.btnChiTietTheoThung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietTheoThung.Location = new System.Drawing.Point(841, 138);
            this.btnChiTietTheoThung.Margin = new System.Windows.Forms.Padding(2);
            this.btnChiTietTheoThung.Name = "btnChiTietTheoThung";
            this.btnChiTietTheoThung.Size = new System.Drawing.Size(232, 122);
            this.btnChiTietTheoThung.TabIndex = 6;
            this.btnChiTietTheoThung.Text = "Báo cáo chi tiết sản lượng nhập kho (theo thùng)";
            this.btnChiTietTheoThung.UseVisualStyleBackColor = true;
            this.btnChiTietTheoThung.Click += new System.EventHandler(this.btnChiTietTheoThung_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(332, 80);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 25);
            this.label18.TabIndex = 48;
            this.label18.Text = "MAWB :";
            // 
            // btnChiTietSanLuong
            // 
            this.btnChiTietSanLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietSanLuong.Location = new System.Drawing.Point(452, 138);
            this.btnChiTietSanLuong.Margin = new System.Windows.Forms.Padding(2);
            this.btnChiTietSanLuong.Name = "btnChiTietSanLuong";
            this.btnChiTietSanLuong.Size = new System.Drawing.Size(232, 122);
            this.btnChiTietSanLuong.TabIndex = 5;
            this.btnChiTietSanLuong.Text = "Báo cáo chi tiết sản lượng nhập kho";
            this.btnChiTietSanLuong.UseVisualStyleBackColor = true;
            this.btnChiTietSanLuong.Click += new System.EventHandler(this.btnChiTietSanLuong_Click);
            // 
            // cbbMasterList
            // 
            this.cbbMasterList.FormattingEnabled = true;
            this.cbbMasterList.Items.AddRange(new object[] {
            "===Tất cả==="});
            this.cbbMasterList.Location = new System.Drawing.Point(429, 80);
            this.cbbMasterList.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMasterList.Name = "cbbMasterList";
            this.cbbMasterList.Size = new System.Drawing.Size(270, 30);
            this.cbbMasterList.TabIndex = 2;
            this.cbbMasterList.SelectedIndexChanged += new System.EventHandler(this.cbbMasterList_SelectedIndexChanged);
            this.cbbMasterList.Leave += new System.EventHandler(this.cbbMasterList_Leave);
            // 
            // btnSanLuongNhap
            // 
            this.btnSanLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanLuongNhap.Location = new System.Drawing.Point(70, 138);
            this.btnSanLuongNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnSanLuongNhap.Name = "btnSanLuongNhap";
            this.btnSanLuongNhap.Size = new System.Drawing.Size(232, 122);
            this.btnSanLuongNhap.TabIndex = 4;
            this.btnSanLuongNhap.Text = "Báo cáo sản lượng nhập kho";
            this.btnSanLuongNhap.UseVisualStyleBackColor = true;
            this.btnSanLuongNhap.Click += new System.EventHandler(this.btnSanLuongNhap_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(17, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "Ngày đến :";
            // 
            // dtpNgayBaoCao
            // 
            this.dtpNgayBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBaoCao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBaoCao.Location = new System.Drawing.Point(152, 80);
            this.dtpNgayBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayBaoCao.Name = "dtpNgayBaoCao";
            this.dtpNgayBaoCao.Size = new System.Drawing.Size(153, 28);
            this.dtpNgayBaoCao.TabIndex = 1;
            this.dtpNgayBaoCao.ValueChanged += new System.EventHandler(this.dtpNgayBaoCao_ValueChanged);
            // 
            // tabNhap
            // 
            this.tabNhap.Controls.Add(this.tabPage1);
            this.tabNhap.Controls.Add(this.tabPage2);
            this.tabNhap.Controls.Add(this.tabPage3);
            this.tabNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabNhap.Location = new System.Drawing.Point(0, 0);
            this.tabNhap.Margin = new System.Windows.Forms.Padding(2);
            this.tabNhap.Name = "tabNhap";
            this.tabNhap.Padding = new System.Drawing.Point(6, 12);
            this.tabNhap.SelectedIndex = 0;
            this.tabNhap.Size = new System.Drawing.Size(1256, 824);
            this.tabNhap.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.progressBar);
            this.tabPage2.Controls.Add(this.chkBoxId);
            this.tabPage2.Controls.Add(this.chkMawb);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.toDate);
            this.tabPage2.Controls.Add(this.btnReportView);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cbReportCategory);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbbBoxIdOut);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbbMasterBillOut);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.fromDate);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 52);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1248, 768);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "        Báo Cáo Xuất Kho        ";
            // 
            // chkBoxId
            // 
            this.chkBoxId.AutoSize = true;
            this.chkBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxId.Location = new System.Drawing.Point(1032, 228);
            this.chkBoxId.Name = "chkBoxId";
            this.chkBoxId.Size = new System.Drawing.Size(79, 24);
            this.chkBoxId.TabIndex = 67;
            this.chkBoxId.Text = "Tất cả";
            this.chkBoxId.UseVisualStyleBackColor = true;
            this.chkBoxId.CheckedChanged += new System.EventHandler(this.chkBoxId_CheckedChanged);
            // 
            // chkMawb
            // 
            this.chkMawb.AutoSize = true;
            this.chkMawb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMawb.Location = new System.Drawing.Point(1032, 180);
            this.chkMawb.Name = "chkMawb";
            this.chkMawb.Size = new System.Drawing.Size(79, 24);
            this.chkMawb.TabIndex = 66;
            this.chkMawb.Text = "Tất cả";
            this.chkMawb.UseVisualStyleBackColor = true;
            this.chkMawb.CheckedChanged += new System.EventHandler(this.chkMawb_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(599, 137);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 65;
            this.label9.Text = "Đến ngày:";
            // 
            // toDate
            // 
            this.toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(704, 131);
            this.toDate.Margin = new System.Windows.Forms.Padding(2);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(270, 26);
            this.toDate.TabIndex = 64;
            // 
            // btnReportView
            // 
            this.btnReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportView.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnReportView.Location = new System.Drawing.Point(17, 308);
            this.btnReportView.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportView.Name = "btnReportView";
            this.btnReportView.Size = new System.Drawing.Size(1214, 48);
            this.btnReportView.TabIndex = 61;
            this.btnReportView.Text = "Xem báo cáo";
            this.btnReportView.UseVisualStyleBackColor = true;
            this.btnReportView.Click += new System.EventHandler(this.btnReportView_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Loại báo cáo:";
            // 
            // cbReportCategory
            // 
            this.cbReportCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReportCategory.FormattingEnabled = true;
            this.cbReportCategory.Location = new System.Drawing.Point(221, 81);
            this.cbReportCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbReportCategory.Name = "cbReportCategory";
            this.cbReportCategory.Size = new System.Drawing.Size(753, 28);
            this.cbReportCategory.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(353, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(477, 40);
            this.label3.TabIndex = 58;
            this.label3.Text = "Báo cáo xuất kho - Hàng đi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 226);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Thùng:";
            // 
            // cbbBoxIdOut
            // 
            this.cbbBoxIdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBoxIdOut.FormattingEnabled = true;
            this.cbbBoxIdOut.Location = new System.Drawing.Point(221, 226);
            this.cbbBoxIdOut.Margin = new System.Windows.Forms.Padding(2);
            this.cbbBoxIdOut.Name = "cbbBoxIdOut";
            this.cbbBoxIdOut.Size = new System.Drawing.Size(753, 28);
            this.cbbBoxIdOut.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Vận đơn chủ:";
            // 
            // cbbMasterBillOut
            // 
            this.cbbMasterBillOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMasterBillOut.FormattingEnabled = true;
            this.cbbMasterBillOut.Location = new System.Drawing.Point(221, 178);
            this.cbbMasterBillOut.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMasterBillOut.Name = "cbbMasterBillOut";
            this.cbbMasterBillOut.Size = new System.Drawing.Size(753, 28);
            this.cbbMasterBillOut.TabIndex = 2;
            this.cbbMasterBillOut.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBillOut_SelectedIndexChanged);
            this.cbbMasterBillOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBillOut_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(111, 137);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 20);
            this.label20.TabIndex = 48;
            this.label20.Text = "Từ ngày:";
            // 
            // fromDate
            // 
            this.fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(221, 131);
            this.fromDate.Margin = new System.Windows.Forms.Padding(2);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(270, 26);
            this.fromDate.TabIndex = 1;
            this.fromDate.ValueChanged += new System.EventHandler(this.dtpNgayXuatReport_ValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(221, 271);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(753, 23);
            this.progressBar.TabIndex = 68;
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1275, 824);
            this.Controls.Add(this.tabNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các Báo Cáo - Rapid Logistics v1.0.17";
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
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbBoxIdOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbMasterBillOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ccbQuarter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReportQuater;
        private System.Windows.Forms.Button btnReportView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbReportCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.CheckBox chkBoxId;
        private System.Windows.Forms.CheckBox chkMawb;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}