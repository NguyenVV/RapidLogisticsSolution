using BusinessEntities;
using BusinessServices.Interfaces;
using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using RapidWarehouse.Data;

namespace RapidWarehouse
{
    public partial class frmTrace : Form
    {
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        ShipmentRepository _repositoryShipment = new ShipmentRepository();
        public frmTrace(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmentEntity shipment = new ShipmentEntity();
            ShipmentOutEntity shipmentout = new ShipmentOutEntity();
            if (String.IsNullOrWhiteSpace(txtShipment.Text) || String.IsNullOrWhiteSpace(txtShipment.Text))
            {
                MessageBox.Show("Bạn phải nhập mã đơn hàng để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string input = txtShipment.Text.Trim().ToUpper();
                lblTitle.Text = input;
                // Shipment out
                shipmentout = _shipmentOutServices.GetByShipmentId(input);
                if (shipmentout != null)
                    lblShipment.Text = "Thông tin xuất kho: " + shipmentout.MasterBillIdString + System.Environment.NewLine + shipmentout.BoxIdString + "(" + shipmentout.DateOut.ToString("d MMM yyyy") + ")";
                // Shipment in           
                shipment = _repositoryShipment.GetShipment(input);
                if (shipment != null)
                    lblDelivery.Text = "Thông tin đơn hàng: " + shipment.Receiver + " - " + shipment.ReceiverTel + System.Environment.NewLine + "Địa chỉ: " + shipment.Address;
                // Ecuss
                if (_shipmentOutServices.GetStatusCompletion(input))
                {
                    lblEcus.ForeColor = Color.Green;
                    lblEcus.Text = "Đã thông quan.";
                }                
                else
                {
                    lblEcus.ForeColor = Color.OrangeRed;
                    lblEcus.Text = "Chưa thông quan.";
                }
                    

            }
            catch (Exception ex)
            {
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        private void txtShipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1_Click(sender, e);
            }
        }
    }
}
