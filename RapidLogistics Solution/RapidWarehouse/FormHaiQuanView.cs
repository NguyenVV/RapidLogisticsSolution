using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Globalization;
using System.Windows.Forms;
using RapidWarehouse.Data;
namespace RapidWarehouse
{
    public partial class FormHaiQuanView : Form
    {
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        ShipmentRepository _repositoryShipment = new ShipmentRepository();
        ShipmentOutEntity shipment = new ShipmentOutEntity();
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
                shipment = _repositoryShipment.GetShipmentOut(txtShipmentNo.Text.Trim().ToUpper());

                if (shipment != null)
                {
                    FillForm(shipment);
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
        private void FillForm(ShipmentOutEntity shipmentOut)
        {
            txtDateOut.Text = shipmentOut != null ? shipmentOut.DateOut.ToString("dd-MM-yyyy") : "";
            txtDateClearance.Text = shipmentOut != null ? shipmentOut.DateCreated.ToString("dd-MM-yyyy") : "";
            if (shipment != null)
            {
                txtContent.Text = shipmentOut.Content;
                txtCountry.Text = shipmentOut.Country;
                txtPackage.Text = shipmentOut.Quantity.ToString();
                txtReceiveer.Text = shipmentOut.ContactName;
                txtSender.Text = shipmentOut.CompanyName;
                txtSoTk.Text = shipmentOut.DeclarationNo;
                txtWeight.Text = shipmentOut.Weight + "";
                txtAddressReceiver.Text = shipmentOut.Address;
                lblMawb.Text = shipmentOut.MasterBillIdString;
                txtDateIn.Text = shipmentOut.DateCreated != null ? shipment.DateCreated.ToString("dd-MM-yyyy") : "";
                txtBoxIdString.Text = shipmentOut.BoxIdString;
                txtDateClearance.Text = Convert.ToDateTime(shipmentOut.DateOfCompletion) == new DateTime()?"": Convert.ToDateTime(shipmentOut.DateOfCompletion).ToString("dd-MM-yyyy");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var shipment = _repositoryShipment.GetShipmentOutByParam(txtShipmentNoSearch.Text, txtSoToKhaiSearch.Text, txtSenderSearch.Text, txtReceiverSearch.Text);
            if(shipment == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }          
            lblShipmentNo.Text = shipment.ShipmentId;
            FillForm(shipment);
        }
    }
}
