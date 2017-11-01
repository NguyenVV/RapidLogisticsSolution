namespace RapidWarehouse
{
    partial class frmTrace
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtShipment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblShipment = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEcus = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(896, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtShipment
            // 
            this.txtShipment.Location = new System.Drawing.Point(12, 42);
            this.txtShipment.Name = "txtShipment";
            this.txtShipment.Size = new System.Drawing.Size(896, 26);
            this.txtShipment.TabIndex = 1;
            this.txtShipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipment_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập mã đơn hàng để tìm kiếm:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(348, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 29);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "ShipmentNo";
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblShipment.ForeColor = System.Drawing.Color.Purple;
            this.lblShipment.Location = new System.Drawing.Point(13, 77);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(21, 20);
            this.lblShipment.TabIndex = 5;
            this.lblShipment.Text = "_";
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblDelivery.ForeColor = System.Drawing.Color.Purple;
            this.lblDelivery.Location = new System.Drawing.Point(13, 144);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(21, 20);
            this.lblDelivery.TabIndex = 6;
            this.lblDelivery.Text = "_";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox2.Controls.Add(this.lblEcus);
            this.groupBox2.Controls.Add(this.lblShipment);
            this.groupBox2.Controls.Add(this.lblDelivery);
            this.groupBox2.Controls.Add(this.lblTitle);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 303);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
            // 
            // lblEcus
            // 
            this.lblEcus.AutoSize = true;
            this.lblEcus.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lblEcus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblEcus.Location = new System.Drawing.Point(13, 210);
            this.lblEcus.Name = "lblEcus";
            this.lblEcus.Size = new System.Drawing.Size(21, 20);
            this.lblEcus.TabIndex = 7;
            this.lblEcus.Text = "_";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 116);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(896, 36);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 485);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtShipment);
            this.Name = "frmTrace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm thông tin";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtShipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblEcus;
    }
}