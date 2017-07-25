using BusinessServices.Interfaces;
using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormHaiQuanView : Form
    {

        private readonly IShipmentServices _shipmentServices;
        public FormHaiQuanView(IShipmentServices shipmentServices)
        {
            InitializeComponent();
            _shipmentServices = shipmentServices;
        }

        private void txtShipmentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShipmentNo.Text) || String.IsNullOrWhiteSpace(txtShipmentNo.Text))
                return;

            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                lblShipmentNo.Text = txtShipmentNo.Text;
                var shipment = _shipmentServices.GetByShipmentId(txtShipmentNo.Text);
                if(shipment != null)
                {
                    txtContent.Text = shipment.Content;
                    txtCountry.Text = shipment.Country;
                    txtPackage.Text = shipment.NumberPackage + "";
                    txtReceiveer.Text = shipment.Receiver;
                    txtSender.Text = shipment.Sender;
                    txtSoTk.Text = shipment.DeclarationNo;
                    txtWeight.Text = shipment.Weight + "";
                    txtAddressReceiver.Text = shipment.Address;
                    lblWarehouseName.Text = shipment.Destination;
                    lblWarehouseCode.Text = FormLogin.mWarehouse.IdCode;
                    txtDateIn.Text = shipment.DateCreated.ToString("dd-MM-yyyy");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng vừa nhập", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormHaiQuanView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
