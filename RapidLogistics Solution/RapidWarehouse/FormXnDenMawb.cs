using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RapidWarehouse.Data;
using System.Globalization;

namespace RapidWarehouse
{
    public partial class FormXnDenMawb : Form
    {
        int totalshipments = 0;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        List<ManifestEntity> manifestList;
        EmployeeEntity currentEmployee;
        ShipmentRepository repositoryShipment = new ShipmentRepository();
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
        private readonly string SHIPMENT_NO = "Shipment No"; 
        public FormXnDenMawb(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IManifestServices manifestServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _manifestServices = manifestServices;
            currentEmployee = FormLogin.mEmployee;

            txtMAWB.Text = "";
            txtMAWB.Focus();
            CloseBox();
            ResetFormInfoNhap();
            btnXNĐ.Enabled = false;
            this.Text = "Xác nhận đến theo MAWB- " + FormUltils.getInstance().GetVersionInfo();
        }
        #region Xác nhận đến      
        private void ResetFormInfoNhap()
        {
            lblShipmentScaned.Text = String.Empty;
            lblNgayDen.Text = String.Empty;
            lblMasterBill.Text = String.Empty;
        }
        private bool ValidateInputDataConfirmArrived()
        {
            if (String.IsNullOrWhiteSpace(txtMAWB.Text))
            {
                MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) và Mã thùng trước", "Nhập thông tin", MessageBoxButtons.OK);
                txtMAWB.Focus();
                return false;
            }
            return true;
        }  
        private void CloseBox()
        {
            txtMAWB.Enabled = true;
        }        
        private void SaveShipment(string masterBill)
        {
           int countTotal = 0;            
            List<BoxIdEntity> listBoxid = repositoryShipment.GetBoxIdByAirwaybill(masterBill);
            if (listBoxid.Count > 0)
            {
                foreach (var box in listBoxid)
                {
                    int countBox = 0;
                    BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(box.BoxId);
                    if (boxEntity == null)
                    {
                        boxEntity = new BoxInforEntity();
                        boxEntity.BoxId = box.BoxId;
                        boxEntity.DateCreated = DateTime.Now;
                        boxEntity.EmployeeId = currentEmployee.Id;
                        boxEntity.ShipmentQuantity =0;
                        boxEntity.MasterBillId = currentMasterBillId;
                        currentBoxIdInt = _boxInforServices.CreateBoxInfor(boxEntity);
                        boxEntity.Id = currentBoxIdInt;
                        currentBoxId = boxEntity.BoxId;
                    }
                    else
                    {
                        currentBoxIdInt = boxEntity.Id;
                        currentBoxId = boxEntity.BoxId;
                    }
                    List<ManifestEntity> listManifest = new List<ManifestEntity>();
                    listManifest = repositoryShipment.GetManifestByBoxId(box.BoxId);
                    listManifest = listManifest.GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();                  
                    if (listManifest != null && listManifest.Count > 0)
                    {
                        List<ShipmentEntity> listShipment = new List<ShipmentEntity>();
                        foreach (var item in listManifest)
                        {                            
                            ShipmentEntity shipment = new ShipmentEntity();
                            shipment.Mawb = item.MasterAirWayBill;
                            shipment.ShipmentId = item.ShipmentNo;
                            shipment.BoxId = currentBoxIdInt;
                            shipment.DateCreated = DateTime.Now;
                            shipment.EmployeeId = currentEmployee.Id;
                            shipment.WarehouseId = FormLogin.mWarehouse.Id;
                            shipment.Address = item.Address;
                            shipment.BoxIdString = item.BoxID;
                            if (_shipmentOutServices.GetStatusCompletion(item.ShipmentNo))
                                shipment.Status = "Clearance";
                            else
                                shipment.Status = "Check";
                            shipment.Content = item.Content;
                            shipment.Country = item.Country;
                            shipment.DeclarationNo = item.DeclarationNo;
                            shipment.Destination = item.Destination;
                            shipment.NumberPackage = 1;
                            shipment.TotalValue = item.TotalValue;
                            shipment.Sender = item.CompanyName;
                            shipment.Consignee = item.Destination;
                            shipment.Receiver = item.ContactName;
                            shipment.Weight = Math.Round(item.Weight, 3) ;
                            shipment.ReceiverTel = item.Tel;                            
                            listShipment.Add(shipment);
                        }                        
                        countBox = repositoryShipment.CreateShipment(listShipment);                      
                        if (countBox > 0)
                        {
                            countTotal += countBox;
                            _boxInforServices.CreateOrUpdateByQuery(countBox, boxEntity.Id);
                        }                      
                    }
                }
                MessageBox.Show("Đã xác nhận đến thành công!\nTổng số đơn hàng là " + countTotal, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            SaveShipment(e.Arguments[0].ToString());
            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
        }
        private void ProgressWorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            //	Do something
            for (int progress = 1; progress <= 100; progress++)
            {
                //	Update the wait window message
                e.Window.Message = string.Format("Vui lòng chờ ... {0}%", progress.ToString().PadLeft(3));
            }
            //	Use the arguments sent in
            if (e.Arguments.Count > 0)
            {
                //	Set the result to return
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                //	Set the result to return
                e.Result = "Hello World";
            }
        }
        private int LoadAllMasterBillByDateToComboboxXacNhanDen(string airwaybill)
        {
            List<MasterAirwayBillEntity> finalList = new List<MasterAirwayBillEntity>();
            //manifestList = _manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            manifestList = repositoryShipment.GetManifestByAirwaybill(airwaybill);
            if (manifestList.Count == 0)
                return 0;
            else
            {
                var masterBillList = manifestList.GroupBy(t => t.MasterAirWayBill).Select(p => p.First());
                if (masterBillList != null && masterBillList.Any())
                {
                    foreach (ManifestEntity manifest in masterBillList)
                    {
                        MasterAirwayBillEntity entity = new MasterAirwayBillEntity();
                        entity.MasterAirwayBill = manifest.MasterAirWayBill;
                        finalList.Add(entity);
                    }
                }
                return manifestList.Count;
            }

        }
        private bool CheckIsMawbExistsInManifest(string mawb)
        {
            if (manifestList != null && manifestList.Count > 0)
            {
                if (manifestList.Any(m => m.MasterAirWayBill.Equals(mawb, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return true;
                }
            }
            return false;
        }   
        #endregion      

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        #region Events buttons      

        private void FormNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        private void btnXNĐ_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtMAWB.Text))
                {
                    MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) trước", "Nhập thông tin", MessageBoxButtons.OK);
                    txtMAWB.Focus();
                    return;
                }
                if (!CheckIsMawbExistsInManifest(txtMAWB.Text))
                {
                    MessageBox.Show(txtMAWB.Text + " không có thông tin manifest.", "Thông báo", MessageBoxButtons.OK);
                    txtMAWB.Focus();
                    return;
                }
                MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(txtMAWB.Text);
                if (masterBill == null)
                {
                    //  DateTime dateconvert = DateTime.ParseExact(manifestList.First().FlightDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string iString = manifestList.First().FlightDate + " 00:00 AM";
                    DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);

                    masterBill = new MasterAirwayBillEntity();
                    masterBill.MasterAirwayBill = txtMAWB.Text;
                    masterBill.DateArrived = oDate;
                    masterBill.DateCreated = DateTime.Now;
                    masterBill.DateInt = repositoryShipment.DateToInt(DateTime.Now);
                    masterBill.EmployeeId = currentEmployee.Id;
                    currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(masterBill);
                    currentMasterBill = masterBill.MasterAirwayBill;
                    masterBill.Id = currentMasterBillId;
                }
                else
                {
                    currentMasterBillId = masterBill.Id;
                    currentMasterBill = masterBill.MasterAirwayBill;
                    //MessageBox.Show("Mã MAWB: " + masterBill.MasterAirwayBill + " này đã được xác nhận rồi", "Mã MAWB đã được xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                }
                object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod, "Vui lòng chờ...", txtMAWB.Text);
            }
            catch (Exception ex)
            {
            }
        }
        private void txtMAWB_TextChanged(object sender, EventArgs e)
        {
            lblMasterBill.Text = txtMAWB.Text;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            totalshipments = 0;
            int returnvalue = LoadAllMasterBillByDateToComboboxXacNhanDen(txtMAWB.Text);
            if (returnvalue > 0)
            {
                lblNgayDen.Text = "Chuyến bay: " + manifestList.First().FlightNumber;
                txtTotal.Visible = true;
                totalshipments = manifestList.Where(t => t.MasterAirWayBill == txtMAWB.Text).GroupBy(t => t.ShipmentNo).Select(p => p.First()).Count();
                lblShipmentScaned.Text = totalshipments.ToString() + " Shipments";
                
                btnXNĐ.Enabled = true;
            }
            else
            {
                lblNgayDen.Text = "Không tồn tại dữ liệu.";
                txtTotal.Visible = false;
                lblShipmentScaned.Text = "";
                txtMAWB.Text = "";
            }
        }
        #endregion
    }
}
