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
            this.cbbBoxIdOut = new System.Windows.Forms.ComboBox();
            this.cbbMasterBillOut = new System.Windows.Forms.ComboBox();
            this.btnOpenBoxOut = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClearance = new System.Windows.Forms.Label();
            this.lblCountIn = new System.Windows.Forms.Label();
            this.txtShipmentNo = new System.Windows.Forms.Label();
            this.lblShipmentScanedOut = new System.Windows.Forms.Label();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.lblBoxIdOut = new System.Windows.Forms.Label();
            this.lblMasterBillOut = new System.Windows.Forms.Label();
            this.txtShipmentIdOut = new System.Windows.Forms.TextBox();
            this.grvShipmentListOut = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentListOut)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbBoxIdOut
            // 
            this.cbbBoxIdOut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBoxIdOut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBoxIdOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbbBoxIdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBoxIdOut.FormattingEnabled = true;
            this.cbbBoxIdOut.Location = new System.Drawing.Point(485, 42);
            this.cbbBoxIdOut.Margin = new System.Windows.Forms.Padding(2);
            this.cbbBoxIdOut.Name = "cbbBoxIdOut";
            this.cbbBoxIdOut.Size = new System.Drawing.Size(364, 30);
            this.cbbBoxIdOut.TabIndex = 3;
            this.cbbBoxIdOut.SelectedIndexChanged += new System.EventHandler(this.cbbBoxIdOut_SelectedIndexChanged);
            this.cbbBoxIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbBoxIdOut_KeyDown_1);
            // 
            // cbbMasterBillOut
            // 
            this.cbbMasterBillOut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbMasterBillOut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbMasterBillOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbbMasterBillOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMasterBillOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbbMasterBillOut.FormattingEnabled = true;
            this.cbbMasterBillOut.Location = new System.Drawing.Point(215, 42);
            this.cbbMasterBillOut.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMasterBillOut.Name = "cbbMasterBillOut";
            this.cbbMasterBillOut.Size = new System.Drawing.Size(263, 30);
            this.cbbMasterBillOut.TabIndex = 2;
            this.cbbMasterBillOut.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBillOut_SelectedIndexChanged);
            this.cbbMasterBillOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBillOut_KeyDown);
            this.cbbMasterBillOut.Leave += new System.EventHandler(this.cbbMasterBillOut_Leave);
            // 
            // btnOpenBoxOut
            // 
            this.btnOpenBoxOut.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOpenBoxOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOpenBoxOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOpenBoxOut.Location = new System.Drawing.Point(23, 77);
            this.btnOpenBoxOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenBoxOut.Name = "btnOpenBoxOut";
            this.btnOpenBoxOut.Size = new System.Drawing.Size(1087, 54);
            this.btnOpenBoxOut.TabIndex = 4;
            this.btnOpenBoxOut.Text = "Mở";
            this.btnOpenBoxOut.UseVisualStyleBackColor = false;
            this.btnOpenBoxOut.Click += new System.EventHandler(this.btnOpenBoxOut_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label14.Location = new System.Drawing.Point(481, 15);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 20);
            this.label14.TabIndex = 48;
            this.label14.Text = "Mã thùng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label15.Location = new System.Drawing.Point(211, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 47;
            this.label15.Text = "Số vận đơn";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label16.Location = new System.Drawing.Point(22, 14);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 46;
            this.label16.Text = "Ngày xuất";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuat.Location = new System.Drawing.Point(23, 42);
            this.dtpNgayXuat.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(188, 30);
            this.dtpNgayXuat.TabIndex = 1;
            this.dtpNgayXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpNgayXuat_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblClearance);
            this.panel2.Controls.Add(this.lblCountIn);
            this.panel2.Controls.Add(this.txtShipmentNo);
            this.panel2.Controls.Add(this.lblShipmentScanedOut);
            this.panel2.Controls.Add(this.lblNgayXuat);
            this.panel2.Controls.Add(this.lblBoxIdOut);
            this.panel2.Controls.Add(this.lblMasterBillOut);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(23, 135);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 91);
            this.panel2.TabIndex = 46;
            // 
            // lblClearance
            // 
            this.lblClearance.AutoSize = true;
            this.lblClearance.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearance.ForeColor = System.Drawing.Color.Red;
            this.lblClearance.Location = new System.Drawing.Point(955, 55);
            this.lblClearance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClearance.Name = "lblClearance";
            this.lblClearance.Size = new System.Drawing.Size(27, 28);
            this.lblClearance.TabIndex = 32;
            this.lblClearance.Text = "0";
            // 
            // lblCountIn
            // 
            this.lblCountIn.AutoSize = true;
            this.lblCountIn.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountIn.ForeColor = System.Drawing.Color.Aqua;
            this.lblCountIn.Location = new System.Drawing.Point(1021, 55);
            this.lblCountIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountIn.Name = "lblCountIn";
            this.lblCountIn.Size = new System.Drawing.Size(27, 28);
            this.lblCountIn.TabIndex = 31;
            this.lblCountIn.Text = "0";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.AutoSize = true;
            this.txtShipmentNo.Font = new System.Drawing.Font("Lucida Console", 14F, System.Drawing.FontStyle.Bold);
            this.txtShipmentNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtShipmentNo.Location = new System.Drawing.Point(323, 30);
            this.txtShipmentNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Size = new System.Drawing.Size(192, 28);
            this.txtShipmentNo.TabIndex = 30;
            this.txtShipmentNo.Text = "ShipmentNo";
            // 
            // lblShipmentScanedOut
            // 
            this.lblShipmentScanedOut.AutoSize = true;
            this.lblShipmentScanedOut.Font = new System.Drawing.Font("Lucida Console", 32F, System.Drawing.FontStyle.Bold);
            this.lblShipmentScanedOut.ForeColor = System.Drawing.Color.Lime;
            this.lblShipmentScanedOut.Location = new System.Drawing.Point(822, 7);
            this.lblShipmentScanedOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShipmentScanedOut.Name = "lblShipmentScanedOut";
            this.lblShipmentScanedOut.Size = new System.Drawing.Size(108, 65);
            this.lblShipmentScanedOut.TabIndex = 29;
            this.lblShipmentScanedOut.Text = "99";
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayXuat.ForeColor = System.Drawing.Color.Lime;
            this.lblNgayXuat.Location = new System.Drawing.Point(5, 7);
            this.lblNgayXuat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(104, 23);
            this.lblNgayXuat.TabIndex = 5;
            this.lblNgayXuat.Text = "Ngày xuất";
            // 
            // lblBoxIdOut
            // 
            this.lblBoxIdOut.AutoSize = true;
            this.lblBoxIdOut.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxIdOut.ForeColor = System.Drawing.Color.Aqua;
            this.lblBoxIdOut.Location = new System.Drawing.Point(5, 63);
            this.lblBoxIdOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoxIdOut.Name = "lblBoxIdOut";
            this.lblBoxIdOut.Size = new System.Drawing.Size(65, 23);
            this.lblBoxIdOut.TabIndex = 3;
            this.lblBoxIdOut.Text = "BoxId";
            // 
            // lblMasterBillOut
            // 
            this.lblMasterBillOut.AutoSize = true;
            this.lblMasterBillOut.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBillOut.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBillOut.Location = new System.Drawing.Point(5, 35);
            this.lblMasterBillOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMasterBillOut.Name = "lblMasterBillOut";
            this.lblMasterBillOut.Size = new System.Drawing.Size(70, 23);
            this.lblMasterBillOut.TabIndex = 1;
            this.lblMasterBillOut.Text = "MAWB";
            // 
            // txtShipmentIdOut
            // 
            this.txtShipmentIdOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtShipmentIdOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentIdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipmentIdOut.Location = new System.Drawing.Point(203, 232);
            this.txtShipmentIdOut.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipmentIdOut.Name = "txtShipmentIdOut";
            this.txtShipmentIdOut.Size = new System.Drawing.Size(907, 30);
            this.txtShipmentIdOut.TabIndex = 7;
            this.txtShipmentIdOut.TextChanged += new System.EventHandler(this.txtShipmentIdOut_TextChanged);
            this.txtShipmentIdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipmentIdOut_KeyDown);
            // 
            // grvShipmentListOut
            // 
            this.grvShipmentListOut.AllowUserToAddRows = false;
            this.grvShipmentListOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipmentListOut.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.grvShipmentListOut.ColumnHeadersHeight = 30;
            this.grvShipmentListOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grvShipmentListOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvShipmentListOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grvShipmentListOut.GridColor = System.Drawing.SystemColors.ControlLight;
            this.grvShipmentListOut.Location = new System.Drawing.Point(0, 0);
            this.grvShipmentListOut.Margin = new System.Windows.Forms.Padding(2);
            this.grvShipmentListOut.Name = "grvShipmentListOut";
            this.grvShipmentListOut.RowHeadersWidth = 18;
            this.grvShipmentListOut.RowTemplate.Height = 33;
            this.grvShipmentListOut.Size = new System.Drawing.Size(1084, 442);
            this.grvShipmentListOut.TabIndex = 9;
            this.grvShipmentListOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipmentListOut_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grvShipmentListOut);
            this.panel1.Location = new System.Drawing.Point(26, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 442);
            this.panel1.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Image = global::RapidWarehouse.Properties.Resources.if_barcode_16085702;
            this.button1.Location = new System.Drawing.Point(167, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 30);
            this.button1.TabIndex = 54;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSearch.Image = global::RapidWarehouse.Properties.Resources.if_system_search_118797;
            this.btnSearch.Location = new System.Drawing.Point(952, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 51);
            this.btnSearch.TabIndex = 49;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Image = global::RapidWarehouse.Properties.Resources.if_Print_1493286;
            this.btnPrint.Location = new System.Drawing.Point(867, 19);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 51);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThoat.Image = global::RapidWarehouse.Properties.Resources.if_xfce_system_exit_23651;
            this.btnThoat.Location = new System.Drawing.Point(1039, 19);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(71, 52);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Shipment number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(988, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 34);
            this.label2.TabIndex = 33;
            this.label2.Text = "/";
            // 
            // FormXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1131, 734);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnOpenBoxOut);
            this.Controls.Add(this.cbbBoxIdOut);
            this.Controls.Add(this.dtpNgayXuat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtShipmentIdOut);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbbMasterBillOut);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất kho";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormXuat_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvShipmentListOut)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbbBoxIdOut;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbbMasterBillOut;
        private System.Windows.Forms.Button btnOpenBoxOut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblShipmentScanedOut;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.Label lblBoxIdOut;
        private System.Windows.Forms.Label lblMasterBillOut;
        private System.Windows.Forms.TextBox txtShipmentIdOut;
        private System.Windows.Forms.Label txtShipmentNo;
        private System.Windows.Forms.DataGridView grvShipmentListOut;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountIn;
        private System.Windows.Forms.Label lblClearance;
        private System.Windows.Forms.Label label2;
    }
}