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
            this.btnXNĐ = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbbMasterBill = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayDen = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblShipmentScaned = new System.Windows.Forms.Label();
            this.lblNgayDen = new System.Windows.Forms.Label();
            this.lblMasterBill = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grvShipments = new System.Windows.Forms.DataGridView();
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
            this.groupBox3.Controls.Add(this.cbbMasterBill);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpNgayDen);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(37, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1192, 177);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhập thông tin";
            // 
            // btnXNĐ
            // 
            this.btnXNĐ.BackColor = System.Drawing.Color.Transparent;
            this.btnXNĐ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnXNĐ.ForeColor = System.Drawing.Color.Green;
            this.btnXNĐ.Location = new System.Drawing.Point(732, 28);
            this.btnXNĐ.Name = "btnXNĐ";
            this.btnXNĐ.Size = new System.Drawing.Size(216, 120);
            this.btnXNĐ.TabIndex = 4;
            this.btnXNĐ.Text = "XN Đến";
            this.btnXNĐ.UseVisualStyleBackColor = false;
            this.btnXNĐ.Click += new System.EventHandler(this.btnXNĐ_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(975, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(164, 120);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnThoat_Click);
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
            this.cbbMasterBill.Size = new System.Drawing.Size(460, 33);
            this.cbbMasterBill.TabIndex = 2;
            this.cbbMasterBill.SelectedIndexChanged += new System.EventHandler(this.cbbMasterBill_SelectedIndexChanged);
            this.cbbMasterBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbMasterBill_KeyDown);
            this.cbbMasterBill.Leave += new System.EventHandler(this.cbbMasterBill_Leave);
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
            this.dtpNgayDen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpNgayDen_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(532, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(681, 63);
            this.label10.TabIndex = 38;
            this.label10.Text = "Xác nhận đến theo MAWB";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblShipmentScaned);
            this.panel1.Controls.Add(this.lblNgayDen);
            this.panel1.Controls.Add(this.lblMasterBill);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(37, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 255);
            this.panel1.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkGray;
            this.label12.Location = new System.Drawing.Point(12, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 36);
            this.label12.TabIndex = 32;
            this.label12.Text = "Tổng số : ";
            // 
            // lblShipmentScaned
            // 
            this.lblShipmentScaned.AutoSize = true;
            this.lblShipmentScaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentScaned.ForeColor = System.Drawing.Color.Magenta;
            this.lblShipmentScaned.Location = new System.Drawing.Point(207, 162);
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
            // lblMasterBill
            // 
            this.lblMasterBill.AutoSize = true;
            this.lblMasterBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterBill.ForeColor = System.Drawing.Color.Yellow;
            this.lblMasterBill.Location = new System.Drawing.Point(212, 22);
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
            this.groupBox1.Location = new System.Drawing.Point(37, 562);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1598, 915);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đơn hàng";
            // 
            // grvShipments
            // 
            this.grvShipments.AllowUserToAddRows = false;
            this.grvShipments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvShipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvShipments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvShipments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grvShipments.Location = new System.Drawing.Point(3, 34);
            this.grvShipments.Name = "grvShipments";
            this.grvShipments.ReadOnly = true;
            this.grvShipments.RowTemplate.Height = 33;
            this.grvShipments.Size = new System.Drawing.Size(1589, 844);
            this.grvShipments.TabIndex = 9;
            this.grvShipments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShipments_CellClick);
            // 
            // FormXnDenMawb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1675, 1466);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "FormXnDenMawb";
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
        private System.Windows.Forms.ComboBox cbbMasterBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayDen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblShipmentScaned;
        private System.Windows.Forms.Label lblNgayDen;
        private System.Windows.Forms.Label lblMasterBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grvShipments;
        private System.Windows.Forms.Button btnXNĐ;
    }
}

