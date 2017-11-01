namespace RapidWarehouse
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblShipmentScaned = new System.Windows.Forms.Label();
            this.lblNgayDen = new System.Windows.Forms.Label();
            this.lblBoxId = new System.Windows.Forms.Label();
            this.lblMasterBill = new System.Windows.Forms.Label();
            this.grvShipments = new System.Windows.Forms.DataGridView();
            this.lblMaVuaNhap = new System.Windows.Forms.Label();
            this.txtShipmentId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipments)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.cbbBoxId);
            this.groupBox3.Controls.Add(this.cbbMasterBill);
            this.groupBox3.Controls.Add(this.btnOpenClose);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpNgayDen);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1122, 185);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(563, 142);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(548, 34);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Location = new System.Drawing.Point(12, 142);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(547, 34);
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
            this.cbbBoxId.Location = new System.Drawing.Point(431, 57);
            this.cbbBoxId.Margin = new System.Windows.Forms.Padding(2);
            this.cbbBoxId.Name = "cbbBoxId";
            this.cbbBoxId.Size = new System.Drawing.Size(392, 27);
            this.cbbBoxId.TabIndex = 3;
            this.cbbBoxId.SelectedIndexChanged += new System.EventHandler(this.cbbBoxId_SelectedIndexChanged);
            this.cbbBoxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbBoxId_KeyDown);
            // 
            // cbbMasterBill
            // 
            this.cbbMasterBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbMasterBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbMasterBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbbMasterBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMasterBill.FormattingEnabled = true;
            this.cbbMasterBill.Location = new System.Drawing.Point(168, 57);
            this.cbbMasterBill.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMasterBill.Name = "cbbMasterBill";
            this.cbbMasterBill.Size = new System.Drawing.Size(242, 27);
            this.cbbMasterBill.TabIndex = 2;
            this.cbbMasterBill.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBill_SelectedIndexChanged);
            this.cbbMasterBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBill_KeyDown);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenClose.ForeColor = System.Drawing.Color.Red;
            this.btnOpenClose.Location = new System.Drawing.Point(12, 90);
            this.btnOpenClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(1099, 48);
            this.btnOpenClose.TabIndex = 5;
            this.btnOpenClose.Text = "Mở";
            this.btnOpenClose.UseVisualStyleBackColor = false;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(427, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mã Thùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(164, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "MAWB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ngày đến";
            // 
            // dtpNgayDen
            // 
            this.dtpNgayDen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDen.Location = new System.Drawing.Point(12, 57);
            this.dtpNgayDen.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayDen.Name = "dtpNgayDen";
            this.dtpNgayDen.Size = new System.Drawing.Size(141, 27);
            this.dtpNgayDen.TabIndex = 1;
            this.dtpNgayDen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpNgayDen_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblShipmentScaned);
            this.panel1.Controls.Add(this.lblNgayDen);
            this.panel1.Controls.Add(this.lblBoxId);
            this.panel1.Controls.Add(this.lblMasterBill);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 204);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 82);
            this.panel1.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.label12.ForeColor = System.Drawing.Color.DarkGray;
            this.label12.Location = new System.Drawing.Point(660, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Tổng số : ";
            // 
            // lblShipmentScaned
            // 
            this.lblShipmentScaned.AutoSize = true;
            this.lblShipmentScaned.Font = new System.Drawing.Font("Lucida Console", 14F);
            this.lblShipmentScaned.ForeColor = System.Drawing.Color.Magenta;
            this.lblShipmentScaned.Location = new System.Drawing.Point(791, 32);
            this.lblShipmentScaned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShipmentScaned.Name = "lblShipmentScaned";
            this.lblShipmentScaned.Size = new System.Drawing.Size(46, 28);
            this.lblShipmentScaned.TabIndex = 29;
            this.lblShipmentScaned.Text = "88";
            // 
            // lblNgayDen
            // 
            this.lblNgayDen.AutoSize = true;
            this.lblNgayDen.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblNgayDen.ForeColor = System.Drawing.Color.Lime;
            this.lblNgayDen.Location = new System.Drawing.Point(10, 14);
            this.lblNgayDen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayDen.Name = "lblNgayDen";
            this.lblNgayDen.Size = new System.Drawing.Size(101, 20);
            this.lblNgayDen.TabIndex = 5;
            this.lblNgayDen.Text = "Ngày đến";
            // 
            // lblBoxId
            // 
            this.lblBoxId.AutoSize = true;
            this.lblBoxId.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblBoxId.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblBoxId.Location = new System.Drawing.Point(20, 53);
            this.lblBoxId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoxId.Name = "lblBoxId";
            this.lblBoxId.Size = new System.Drawing.Size(81, 20);
            this.lblBoxId.TabIndex = 3;
            this.lblBoxId.Text = " BoxId";
            // 
            // lblMasterBill
            // 
            this.lblMasterBill.AutoSize = true;
            this.lblMasterBill.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblMasterBill.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBill.Location = new System.Drawing.Point(226, 14);
            this.lblMasterBill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMasterBill.Name = "lblMasterBill";
            this.lblMasterBill.Size = new System.Drawing.Size(57, 20);
            this.lblMasterBill.TabIndex = 1;
            this.lblMasterBill.Text = "MAWB";
            // 
            // grvShipments
            // 
            this.grvShipments.AllowUserToAddRows = false;
            this.grvShipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvShipments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grvShipments.Location = new System.Drawing.Point(0, 0);
            this.grvShipments.Margin = new System.Windows.Forms.Padding(2);
            this.grvShipments.Name = "grvShipments";
            this.grvShipments.RowTemplate.Height = 33;
            this.grvShipments.Size = new System.Drawing.Size(1111, 265);
            this.grvShipments.TabIndex = 9;
            this.grvShipments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipments_CellClick);
            // 
            // lblMaVuaNhap
            // 
            this.lblMaVuaNhap.AutoSize = true;
            this.lblMaVuaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVuaNhap.ForeColor = System.Drawing.Color.Red;
            this.lblMaVuaNhap.Location = new System.Drawing.Point(317, 293);
            this.lblMaVuaNhap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaVuaNhap.Name = "lblMaVuaNhap";
            this.lblMaVuaNhap.Size = new System.Drawing.Size(137, 25);
            this.lblMaVuaNhap.TabIndex = 35;
            this.lblMaVuaNhap.Text = "Mã vừa nhập";
            // 
            // txtShipmentId
            // 
            this.txtShipmentId.BackColor = System.Drawing.Color.White;
            this.txtShipmentId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentId.Location = new System.Drawing.Point(16, 293);
            this.txtShipmentId.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipmentId.Name = "txtShipmentId";
            this.txtShipmentId.Size = new System.Drawing.Size(297, 26);
            this.txtShipmentId.TabIndex = 8;
            this.txtShipmentId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShipmentId_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grvShipments);
            this.panel2.Location = new System.Drawing.Point(16, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 265);
            this.panel2.TabIndex = 41;
            // 
            // FormNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1153, 627);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMaVuaNhap);
            this.Controls.Add(this.txtShipmentId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormNhap";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận dữ liệu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNhap_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipments)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblShipmentScaned;
        private System.Windows.Forms.Label lblNgayDen;
        private System.Windows.Forms.Label lblBoxId;
        private System.Windows.Forms.Label lblMasterBill;
        private System.Windows.Forms.DataGridView grvShipments;
        private System.Windows.Forms.Label lblMaVuaNhap;
        private System.Windows.Forms.TextBox txtShipmentId;
        private System.Windows.Forms.Panel panel2;
    }
}

