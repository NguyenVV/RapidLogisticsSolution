using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormHaiQuanView : Form
    {

        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        public FormHaiQuanView(IShipmentServices shipmentServices, IShipmentOutServices shipmentOutServices)
        {
            InitializeComponent();
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            txtShipmentNo.Focus();
        }

        private void txtShipmentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShipmentNo.Text) || String.IsNullOrWhiteSpace(txtShipmentNo.Text))
                return;

            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                lblShipmentNo.Text = txtShipmentNo.Text;
                var shipment = _shipmentServices.GetByShipmentId(txtShipmentNo.Text);
                var shipmentOut = _shipmentOutServices.GetByShipmentId(txtShipmentNo.Text);

                if (shipment != null)
                {
                    FillForm(shipment, shipmentOut);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng vừa nhập", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtShipmentNo.Text = "";
            }
        }

        private void FormHaiQuanView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblMawb.Text = "";
            lblShipmentNo.Text = "";
            txtAddressReceiver.Text = "";
            txtContent.Text = "";
            txtCountry.Text = "";
            txtDateClearance.Text = "";
            txtDateIn.Text = "";
            txtDateOut.Text = "";
            txtPackage.Text = "";
            txtReceiveer.Text = "";
            txtSender.Text = "";
            txtSoTk.Text = "";
            txtWeight.Text = "";
            txtBoxIdString.Text = "";
        }

        private void FillForm(ShipmentEntity shipment, ShipmentOutEntity shipmentOut)
        {
            txtDateOut.Text = shipmentOut != null ? shipmentOut.DateOut.ToString("dd-MM-yyyy") : "";
            txtDateClearance.Text = shipmentOut != null ? shipmentOut.DateCreated.ToString("dd-MM-yyyy") : "";

            if (shipment != null)
            {
                txtContent.Text = shipment.Content;
                txtCountry.Text = shipment.Country;
                txtPackage.Text = shipment.NumberPackage + "";
                txtReceiveer.Text = shipment.Receiver;
                txtSender.Text = shipment.Sender;
                txtSoTk.Text = shipment.DeclarationNo;
                txtWeight.Text = shipment.Weight + "";
                txtAddressReceiver.Text = shipment.Address;
                lblMawb.Text = shipment.Mawb;
                txtDateIn.Text = shipment.DateCreated != null ? shipment.DateCreated.ToString("dd-MM-yyyy") : "";
                txtBoxIdString.Text = shipment.BoxIdString;
                txtDateClearance.Text = Convert.ToDateTime(shipment.DateOfCompletion) == new DateTime()?"": Convert.ToDateTime(shipment.DateOfCompletion).ToString("dd-MM-yyyy hh:mm");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var shipment = _shipmentServices.SearchByConditions(txtShipmentNoSearch.Text, txtSoToKhaiSearch.Text, txtSenderSearch.Text, txtReceiverSearch.Text);
            if(shipment == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng nào! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var shipmentOut = _shipmentOutServices.GetByShipmentId(shipment.ShipmentId);
            lblShipmentNo.Text = shipment.ShipmentId;
            FillForm(shipment, shipmentOut);
        }
    }
}
