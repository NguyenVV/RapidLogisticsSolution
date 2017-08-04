using BusinessEntities;
using BusinessServices.Interfaces;
using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormNhap : Form
    {
        //public DataTable tblShipments = new DataTable();
        int numberShipment = 1;
        int numberShipmentOut = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        List<ManifestEntity> manifestList;
        EmployeeEntity currentEmployee;
        private int xpos = 0, ypos = 0;
        private int xposX = 0, yposX = 0;
        private int indexWaitConfirmedDeleted = 0;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
        private readonly IShipmentWaitToConfirmedServices _shipmentWaitConfirmedServices;
        private readonly IShipmentOutTempServices _shipmentOutTempServices;
        private readonly string SHIPMENT_NO = "Shipment No";
        private readonly string MAWB = "MAWB";
        private readonly string STT = "STT";
        private readonly string ID = "Id";
        private readonly string DECLARATIONNO = "Số tờ khai";
        private readonly string COMPANYNAME = "Người gửi";
        private readonly string COUNTRY = "Nước gửi";
        private readonly string CONTACTNAME = "Người nhận";
        private readonly string ADDRESS = "Địa chỉ nhận";
        private readonly string CONSIGNEE = "Consignee";
        private readonly string CONTENT = "Nội dung hàng";
        private readonly string PACKAGE = "Số kiện";
        private readonly string WEIGHT = "Khối lượng";
        private readonly string DATEOFCOMPLETION = "Ngày thông quan";
        public FormNhap(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IManifestServices manifestServices, IShipmentWaitToConfirmedServices shipmentWaitToConfirmedServices
            , IShipmentOutTempServices shipmentOutTempServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _manifestServices = manifestServices;
            _shipmentWaitConfirmedServices = shipmentWaitToConfirmedServices;
            _shipmentOutTempServices = shipmentOutTempServices;
            currentEmployee = FormLogin.mEmployee;
            BuildingTheGridviewRowStrure();

            AddDeleteButtonToGridView(grvShipments);

            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            ResetHardCodeText();
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            //LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);

            cbbMasterBill.SelectedText = "";
            FillInforXacNhanDen();
            CloseBox();
            ResetFormInfoNhap();
            dtpNgayDen.Focus();
            this.Text = "Xác nhận đến - " + FormUltils.getInstance().GetVersionInfo();
            //xpos = label10.Location.X;
            //ypos = label10.Location.Y;
            //timer1.Start();
        }

        #region Xác nhận đến
        private void BuildingTheGridviewRowStrure()
        {
            grvShipments.ColumnCount = 14;
            grvShipments.Columns[0].Name = STT;
            grvShipments.Columns[0].ValueType = typeof(int);
            grvShipments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipments.Columns[1].Name = MAWB;
            grvShipments.Columns[1].ValueType = typeof(string);
            grvShipments.Columns[2].Name = ID;
            grvShipments.Columns[2].ValueType = typeof(int);
            grvShipments.Columns[2].Visible = false;
            grvShipments.Columns[3].Name = SHIPMENT_NO;
            grvShipments.Columns[3].ValueType = typeof(string);
            grvShipments.Columns[4].Name = DECLARATIONNO;
            grvShipments.Columns[4].ValueType = typeof(string);
            grvShipments.Columns[5].Name = COMPANYNAME;
            grvShipments.Columns[5].ValueType = typeof(string);
            grvShipments.Columns[6].Name = COUNTRY;
            grvShipments.Columns[6].ValueType = typeof(string);
            grvShipments.Columns[7].Name = CONTACTNAME;
            grvShipments.Columns[7].ValueType = typeof(string);
            grvShipments.Columns[8].Name = ADDRESS;
            grvShipments.Columns[8].ValueType = typeof(string);
            grvShipments.Columns[9].Name = CONSIGNEE;
            grvShipments.Columns[9].ValueType = typeof(string);
            grvShipments.Columns[10].Name = CONTENT;
            grvShipments.Columns[10].ValueType = typeof(string);
            grvShipments.Columns[11].Name = PACKAGE;
            grvShipments.Columns[11].ValueType = typeof(int);
            grvShipments.Columns[12].Name = WEIGHT;
            grvShipments.Columns[12].ValueType = typeof(float);
            grvShipments.Columns[13].Name = DATEOFCOMPLETION;
            grvShipments.Columns[13].ValueType = typeof(string);
        }
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text.Equals("Mở", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!ValidateInputDataConfirmArrived())
                    return;

                OpenBox();
                LoadShipmentsByBoxIdInXacNhanDen(cbbBoxId.Text, grvShipments);
                btnOpenClose.Text = "Đóng";
                //if (!cbbBoxId.Items.Contains(cbbBoxId.Text))
                //{
                //    cbbBoxId.Items.Add(cbbBoxId.Text);
                //}
                //if (!cbbMasterBill.Items.Contains(cbbMasterBill.Text))
                //{
                //    cbbMasterBill.Items.Add(cbbMasterBill.Text);
                //}
            }
            else
            {
                SaveBoxInfor();
                CloseBox();
                btnOpenClose.Text = "Mở";
            }

            //manifestList.Where(m => m.BoxID.Equals(cbbBoxId.Text, StringComparison.CurrentCultureIgnoreCase)).GroupBy(t => t.ShipmentNo).Select(p => p.First()).Count();
            //lblThungDaQuet.Text = cbbBoxId.Items.Count > 0 ? cbbBoxId.Items.Count.ToString() : "0";
            MasterAirwayBillEntity itemMaster = _masterBillServices.GetByMasterBillId(cbbMasterBill.Text);
            if (itemMaster != null)
            {
                lblThungDaQuet.Text = "" + _boxInforServices.GetTotalByMasterBill(itemMaster.Id);
                lblDonDaQuet.Text = "" + _boxInforServices.GetTotalShipmentByMasterBill(itemMaster.Id);// +"("+_shipmentServices.GetTotalShipmentByMasterBill(itemMaster.Id) + ")";
            }
        }

        private void ResetFormInfoNhap()
        {
            lblDonDaQuet.Text = String.Empty;
            lblThungDaQuet.Text = String.Empty;
            lblShipmentScaned.Text = String.Empty;
            //lblNgayDen.Text = String.Empty;
            lblMasterBill.Text = String.Empty;
            lblBoxId.Text = String.Empty;
        }
        
        private void OpenBox()
        {
            FillInforXacNhanDen();
            numberShipment = 1;
            dtpNgayDen.Enabled = false;
            cbbMasterBill.Enabled = false;
            cbbBoxId.Enabled = false;
            txtShipmentId.Enabled = true;
            grvShipments.Enabled = true;
            txtShipmentId.Focus();
        }

        private bool ValidateInputDataConfirmArrived()
        {
            if (String.IsNullOrWhiteSpace(cbbMasterBill.Text) || String.IsNullOrWhiteSpace(cbbBoxId.Text))
            {
                MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) và Mã thùng trước", "Nhập thông tin", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return false;
            }

            if (!CheckIsMawbExistsInManifest(cbbMasterBill.Text))
            {
                MessageBox.Show("Mã MAWB không có trong manifest của ngày đã chọn " + dtpNgayDen.Value.ToString("dd/MM/yyyy"), "Nhập thông tin", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return false;
            }
            if (!CheckIsBoxIdExistsInManifest(cbbBoxId.Text))
            {
                MessageBox.Show("Mã BoxId không có trong manifest của ngày đã chọn " + dtpNgayDen.Value.ToString("dd/MM/yyyy"), "Nhập thông tin", MessageBoxButtons.OK);
                cbbBoxId.Focus();
                return false;
            }

            BoxInforEntity box = _boxInforServices.GetByBoxId(cbbBoxId.Text);
            int shipmentAmount = manifestList.Where(m => m.BoxID.Equals(cbbBoxId.Text, StringComparison.CurrentCultureIgnoreCase)).GroupBy(t => t.ShipmentNo).Select(p => p.First()).Count();

            if (box != null)
            {
                var resultBox = MessageBox.Show("Mã thùng này đã được xác nhận rồi, có " + shipmentAmount + " đơn hàng\nBạn có muốn mở không ?", "Mã thùng đã được xác nhận", MessageBoxButtons.YesNo);
                cbbBoxId.Focus();
                return resultBox == DialogResult.Yes;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xử lý mã thùng: " + cbbBoxId.Text + " với tổng số đơn hàng = " + shipmentAmount, "Chọn xử lý", MessageBoxButtons.YesNo);

            return result == DialogResult.Yes;
        }
        private void FillInforXacNhanDen()
        {
            lblMasterBill.Text = cbbMasterBill.Text;
            lblBoxId.Text = cbbBoxId.Text;
            lblNgayDen.Text = dtpNgayDen.Value.ToString("dd/MM/yyyy");
        }
        private void SaveBoxInfor()
        {
            if (grvShipments.Rows.Count > 0)
            {
                MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(cbbMasterBill.Text);
                if (masterBill == null)
                {
                    masterBill = new MasterAirwayBillEntity();
                    masterBill.MasterAirwayBill = cbbMasterBill.Text;
                    masterBill.DateArrived = dtpNgayDen.Value;
                    masterBill.DateCreated = DateTime.Now;
                    masterBill.EmployeeId = currentEmployee.Id;
                    currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(masterBill);
                    currentMasterBill = masterBill.MasterAirwayBill;
                    masterBill.Id = currentMasterBillId;
                    //cbbMasterBill.Items.Add(masterBill);
                    LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);
                    cbbMasterBill.SelectedText = masterBill.MasterAirwayBill;
                }
                else
                {
                    currentMasterBillId = masterBill.Id;
                    currentMasterBill = masterBill.MasterAirwayBill;
                }

                BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(cbbBoxId.Text);
                if (boxEntity == null)
                {
                    boxEntity = new BoxInforEntity();
                    boxEntity.BoxId = cbbBoxId.Text;
                    boxEntity.ShipmentQuantity = numberShipment;
                    boxEntity.MasterBillId = currentMasterBillId;
                    boxEntity.DateCreated = DateTime.Now;
                    boxEntity.EmployeeId = currentEmployee.Id;
                    currentBoxIdInt = _boxInforServices.CreateBoxInfor(boxEntity);
                    boxEntity.Id = currentBoxIdInt;
                    currentBoxId = boxEntity.BoxId;
                    //cbbBoxId.Items.Add(boxEntity);
                }
                else
                {
                    currentBoxIdInt = boxEntity.Id;
                    currentBoxId = boxEntity.BoxId;
                }
                int rowCount = grvShipments.Rows.Count;
                if (rowCount > 0)
                {
                    List<ShipmentEntity> listShipment = new List<ShipmentEntity>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        string shipmentId = Convert.ToString(grvShipments[SHIPMENT_NO, i].Value);
                        ShipmentEntity shipment = new ShipmentEntity();
                        shipment.ShipmentId = shipmentId;
                        shipment.BoxId = currentBoxIdInt;
                        shipment.DateCreated = DateTime.Now;
                        shipment.WarehouseId = FormLogin.mWarehouse.Id;
                        shipment.EmployeeId = currentEmployee.Id;
                        string package = Convert.ToString(grvShipments[PACKAGE, i].Value);
                        if (string.IsNullOrEmpty(package))
                        {
                            shipment.NumberPackage = 1;
                        }
                        else
                        {
                            shipment.NumberPackage = Int32.Parse(Convert.ToString(grvShipments[PACKAGE, i].Value));
                        }

                        shipment.Sender = Convert.ToString(grvShipments[COMPANYNAME, i].Value);
                        shipment.DeclarationNo = Convert.ToString(grvShipments[DECLARATIONNO, i].Value);
                        shipment.Address = Convert.ToString(grvShipments[ADDRESS, i].Value);
                        shipment.Content = Convert.ToString(grvShipments[CONTENT, i].Value);
                        shipment.Destination = Convert.ToString(grvShipments[CONSIGNEE, i].Value);
                        shipment.Consignee = Convert.ToString(grvShipments[CONSIGNEE, i].Value);
                        shipment.Receiver = Convert.ToString(grvShipments[CONTACTNAME, i].Value);
                        shipment.Weight = double.Parse(Convert.ToString(grvShipments[WEIGHT, i].Value));
                        string weight = Convert.ToString(grvShipments[WEIGHT, i].Value);
                        if (string.IsNullOrEmpty(weight))
                        {
                            shipment.Weight = 0d;
                        }
                        else
                        {
                            shipment.Weight = Double.Parse(Convert.ToString(grvShipments[WEIGHT, i].Value));
                        }
                        shipment.Country = Convert.ToString(grvShipments[COUNTRY, i].Value);
                        shipment.DateOfCompletion = Convert.ToDateTime(grvShipments[DATEOFCOMPLETION, i].Value);
                        listShipment.Add(shipment);
                    }
                    _shipmentServices.CreateOrUpdate(listShipment);
                }
            }
        }
        private void CloseBox()
        {
            dtpNgayDen.Enabled = true;
            cbbMasterBill.Enabled = true;
            cbbBoxId.Enabled = true;
            txtShipmentId.Enabled = false;
            grvShipments.Enabled = false;
            txtShipmentId.Text = String.Empty;
            grvShipments.Rows.Clear();
        }
        //private void LuuXacNhanDen()
        //{
        //    var masterBillList = manifestList.GroupBy(t => t.MasterAirWayBill).Select(p => p.First()).ToList();

        //    if (masterBillList != null && masterBillList.Count > 0)
        //    {
        //        foreach (var manifest in masterBillList)
        //        {
        //            MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(manifest.MasterAirWayBill);
        //            if (masterBill == null)
        //            {
        //                masterBill = new MasterAirwayBillEntity();
        //                masterBill.MasterAirwayBill = manifest.MasterAirWayBill;
        //                masterBill.DateArrived = dtpNgayDen.Value;
        //                masterBill.DateCreated = DateTime.Now;
        //                masterBill.EmployeeId = currentEmployee.Id;
        //                currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(masterBill);
        //                currentMasterBill = masterBill.MasterAirwayBill;
        //                masterBill.Id = currentMasterBillId;
        //            }

        //            List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
        //            if (listBoxInfo != null && listBoxInfo.Count > 0)
        //            {
        //                foreach (var itemBoxID in listBoxInfo)
        //                {
        //                    BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(itemBoxID.BoxID);
        //                    if (boxEntity == null)
        //                    {
        //                        boxEntity = new BoxInforEntity();
        //                        boxEntity.BoxId = itemBoxID.BoxID;
        //                        boxEntity.DateCreated = DateTime.Now;
        //                        boxEntity.EmployeeId = currentEmployee.Id;
        //                        boxEntity.ShipmentQuantity = manifestList.Where(t => t.BoxID == itemBoxID.BoxID).Count();
        //                        boxEntity.MasterBillId = currentMasterBillId;
        //                        currentBoxIdInt = _boxInforServices.CreateBoxInfor(boxEntity);
        //                        boxEntity.Id = currentBoxIdInt;
        //                        currentBoxId = boxEntity.BoxId;
        //                    }
        //                    else
        //                    {
        //                        currentBoxIdInt = boxEntity.Id;
        //                        currentBoxId = boxEntity.BoxId;
        //                    }

        //                    // Add shipment here
        //                    List<ManifestEntity> listShipmentNo = manifestList.Where(t => t.BoxID == itemBoxID.BoxID).GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
        //                    if (listShipmentNo != null && listShipmentNo.Count > 0)
        //                    {
        //                        List<ShipmentEntity> listShipment = new List<ShipmentEntity>();

        //                        foreach (var item in listShipmentNo)
        //                        {
        //                            ShipmentEntity shipment = new ShipmentEntity();
        //                            shipment.ShipmentId = item.ShipmentNo;
        //                            shipment.BoxId = currentBoxIdInt;
        //                            shipment.DateCreated = DateTime.Now;
        //                            shipment.EmployeeId = currentEmployee.Id;
        //                            shipment.WarehouseId = FormLogin.mWarehouse.Id;
        //                            shipment.Address = item.Address;
        //                            shipment.BoxIdString = item.BoxID;
        //                            shipment.Content = item.Content;
        //                            shipment.Country = item.Country;
        //                            shipment.DeclarationNo = item.DeclarationNo;
        //                            shipment.Destination = item.Destination;
        //                            shipment.NumberPackage = 1;
        //                            try
        //                            {
        //                                if (!_shipmentServices.Exists(shipment.ShipmentId))
        //                                {
        //                                    listShipment.Add(shipment);
        //                                }
        //                            }
        //                            catch (Exception e) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void LuuXacNhanDen()", e); }
        //                        }

        //                        int count = _shipmentServices.CreateOrUpdate(listShipment);
        //                    }
        //                }
        //            }
        //        }

        //        MessageBox.Show("Đã lưu xác nhận đến thành công!");
        //        //btnXacNhan.Enabled = false;
        //    }
        //}
        private void LoadAllMasterBillByDateToComboboxXacNhanDen(DateTime date)
        {
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            List<ManifestEntity> finalList = new List<ManifestEntity>();
            finalList.Add(new ManifestEntity());

            var masterBillList = manifestList.GroupBy(t => t.MasterAirWayBill).Select(p => p.First()).ToList();
            if (masterBillList != null && masterBillList.Count > 0)
            {
                finalList.AddRange(masterBillList);
                cbbMasterBill.DataSource = finalList;
                cbbMasterBill.ValueMember = "MasterAirwayBill";
                cbbMasterBill.DisplayMember = "MasterAirwayBill";
            }
            else
            {
                cbbMasterBill.DataSource = null;
                cbbMasterBill.Items.Clear();
            }
        }
        private void LoadAllBoxIdByMasterBill(int masterBillId)
        {
            cbbBoxId.Items.Clear();
            cbbBoxId.DataSource = null;

            List<BoxInforEntity> masterBillList = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(masterBillId);
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbBoxId.DataSource = masterBillList;
                cbbBoxId.ValueMember = "Id";
                cbbBoxId.DisplayMember = "MasterAirwayBill";
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

        private bool CheckIsBoxIdExistsInManifest(string boxId)
        {
            if (manifestList != null && manifestList.Count > 0)
            {
                if (manifestList.Any(m => m.BoxID.Equals(boxId, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return true;
                }
            }

            return false;
        }
        private void cbbMasterBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterAirwayBillEntity masterBill = (MasterAirwayBillEntity)cbbMasterBill.SelectedItem;
            if (masterBill != null)
            {
                List<BoxInforEntity> listBoxInfo = _boxInforServices.GetByMasterBill(masterBill.Id).ToList();
                if (listBoxInfo != null && listBoxInfo.Count > 0)
                {
                    cbbBoxId.DataSource = listBoxInfo;
                    cbbBoxId.ValueMember = "Id";
                    cbbBoxId.DisplayMember = "BoxId";
                }
                else
                {
                    cbbBoxId.DataSource = null;
                    cbbBoxId.Items.Clear();
                }
            }
            else
            {
                cbbBoxId.Items.Clear();
            }

            lblMasterBill.Text = cbbMasterBill.Text;
        }

        //private void btnXacNhan_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(cbbMasterBill.Text))
        //    {
        //        MessageBox.Show("Hãy chọn một mã MAWB để xác nhận");
        //        return;
        //    }

        //    //LuuXacNhanDen();
        //}

        private void cbbBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddShipmentListToGrid(List<ManifestEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ManifestEntity item in listShipment)
                {
                    if (string.IsNullOrEmpty(item.DeclarationNo))
                    {
                        item.DeclarationNo = _shipmentServices.GetDeclarationNo(item.ShipmentNo);
                    }
                    
                    string dateOfCreation = _shipmentServices.GetDateOfCompletion(item.ShipmentNo);
                    grv.Rows.Add(index, item.MasterAirWayBill, 0, item.ShipmentNo, item.DeclarationNo, item.CompanyName
                        ,item.Country, item.ContactName, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", item.Weight), dateOfCreation);
                    index++;
                }
                // setting up value count on gridview
                numberShipment = index;
            }
        }

        private void AddShipmentListToGrid(List<ShipmentEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ShipmentEntity item in listShipment)
                {
                    grv.Rows.Add(index, cbbMasterBill.Text, item.Id, item.ShipmentId, item.DeclarationNo, item.Sender
                        , item.Country, item.Receiver, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", item.Weight), item.DateOfCompletion);
                    index++;
                }
                // setting up value count on gridview
                numberShipment = index;
            }
        }

        private void dtpNgayDen_ValueChanged(object sender, EventArgs e)
        {
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            lblNgayDen.Text = dtpNgayDen.Value.ToString("dd/MM/yyyy");
            //LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);
        }
        private void UpdateValueOverviewNhapKho()
        {
            lblShipmentScaned.Text = "" + grvShipments.Rows.Count;
            numberShipment++;

            lblMaVuaNhap.Text = txtShipmentId.Text;
            txtShipmentId.Text = String.Empty;
        }

        private void txtShipmentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShipmentId.Text) || String.IsNullOrWhiteSpace(txtShipmentId.Text))
                return;

            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                if (IsExistsOnTheGridView(grvShipments, txtShipmentId.Text))
                {
                    MessageBox.Show("Tìm thấy đơn hàng vừa nhập đã có trên lưới", "Đơn hàng trùng lặp");
                    txtShipmentId.Text = String.Empty;
                    return;
                }

                if (_shipmentServices.GetByShipmentId(txtShipmentId.Text) != null)
                {
                    MessageBox.Show("Mã đơn hàng vừa nhập đã có trong kho nên không thể nhập kho", "Đơn hàng đã tồn tại", MessageBoxButtons.OK);
                    txtShipmentId.Text = String.Empty;
                    return;
                }

                // Thêm shipment vào lưới để nhập kho
                grvShipments.Rows.Add(grvShipments.Rows.Count + 1, txtShipmentId.Text);
                grvShipments.ClearSelection();
                grvShipments.Rows[grvShipments.Rows.Count - 1].Selected = true;
                grvShipments.FirstDisplayedScrollingRowIndex = grvShipments.Rows.Count - 1;
                UpdateValueOverviewNhapKho();
            }
        }

        private void LoadShipmentsByBoxIdInXacNhanDen(string boxId, DataGridView shipmentGrid, bool isFromManifest = true)
        {
            if (!string.IsNullOrEmpty(boxId))
            {
                if (isFromManifest)
                {
                    List<ManifestEntity> listShipmentManifest = manifestList.Where(t => t.BoxID == cbbBoxId.Text).GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
                    if (listShipmentManifest != null && listShipmentManifest.Count > 0)
                    {
                        AddShipmentListToGrid(listShipmentManifest, shipmentGrid);
                    }
                    else
                    {
                        shipmentGrid.Rows.Clear();
                    }
                }
                else
                {
                    List<ShipmentEntity> listShipmentDatabase = _shipmentServices.GetByBoxId(_boxInforServices.GetByBoxId(boxId).Id).ToList();
                    if (listShipmentDatabase != null && listShipmentDatabase.Count > 0)
                    {
                        AddShipmentListToGrid(listShipmentDatabase, shipmentGrid);
                    }
                    else
                    {
                        shipmentGrid.Rows.Clear();
                    }
                }
            }
            else
            {
                shipmentGrid.Rows.Clear();
            }

            lblBoxId.Text = boxId;
            lblShipmentScaned.Text = (shipmentGrid.Rows.Count).ToString();

        }

        #endregion

        #region Xuất kho

        private bool CheckBoxIdProcessingByAnother(int boxId)
        {
            var shipmentOut = _shipmentOutTempServices.GetByBoxId(boxId);
            if (shipmentOut != null && shipmentOut.First().EmployeeId != currentEmployee.Id)
            {
                MessageBox.Show("Mã thùng này đang được xử lý bởi người khác, vui lòng chọn mã thùng khác! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }
        #endregion

        #region Dùng chung
        private void ResetHardCodeText()
        {
            lblMaVuaNhap.Text = "";
        }
        private void AddDeleteButtonToGridView(DataGridView grv)
        {
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "";
            deleteButton.Text = "Xóa";
            deleteButton.UseColumnTextForButtonValue = true;
            grv.Columns.Add(deleteButton);
            grv.Columns["dataGridViewDeleteButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void AddCheckBoxToGridView(DataGridView grv)
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "dataGridViewCheckBox";
            checkColumn.HeaderText = "";
            checkColumn.Width = 30;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            //grv.Columns.Insert(2, checkColumn);
            grv.Columns.Add(checkColumn);
        }

        private void LoadAllMasterBillByDateToCombobox(DateTime date, ComboBox cbbMaster)
        {
            List<MasterAirwayBillEntity> masterBillList = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateArrived(date);
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbMaster.DataSource = masterBillList;
                cbbMaster.ValueMember = "Id";
                cbbMaster.DisplayMember = "MasterAirwayBill";
            }
            else
            {
                cbbMaster.DataSource = null;
                cbbMaster.Items.Clear();
            }
        }

        /// <summary>
        /// Kiểm tra xem mã shipment vừa scan đã có trên lưới hay chưa
        /// </summary>
        /// <param name="grv"></param>
        /// <param name="shipmentId"></param>
        /// <returns></returns>
        private bool IsExistsOnTheGridView(DataGridView grv, string shipmentId)
        {
            //check if the value from textBox1 is existed in dataGridView1:
            for (int i = 0; i < grv.Rows.Count; i++)
            {
                //for (int j = 0; j < grv.Columns.Count; j++)
                //{
                if (grv.Rows[i].Cells[SHIPMENT_NO].Value != null && shipmentId.Equals(grv.Rows[i].Cells[SHIPMENT_NO].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    grv.ClearSelection();
                    grv.Rows[i].Selected = true;
                    grv.FirstDisplayedScrollingRowIndex = i;
                    grv.Focus();
                    indexWaitConfirmedDeleted = i;
                    return true;
                }
                //}
            }

            return false;
        }

        /// <summary>
        /// xóa trên form nhập kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvShipments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowFromGridview(grvShipments, e, 1);
            numberShipment--;
            ReIndexingRow(grvShipments);
        }

        private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)
        {
            //if click is on new row or header row
            if (e.RowIndex == grv.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == grv.Columns["dataGridViewDeleteButton"].Index)
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa đơn hàng : " + grv.Rows[e.RowIndex].Cells[SHIPMENT_NO].Value, "Xóa đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                try
                {
                    if (grvType == 1)
                    {
                        int id = 0;
                        try
                        {
                            id = Convert.ToInt32(grv.Rows[e.RowIndex].Cells["Id"].Value);
                        }
                        catch { }

                        if (id > 0)
                        {
                            _shipmentServices.Delete(id);
                        }
                        else
                        {
                            _shipmentServices.Delete(grv.Rows[e.RowIndex].Cells[SHIPMENT_NO].Value.ToString());
                        }
                        lblShipmentScaned.Text = (grv.Rows.Count - 1) + "";
                    }
                }
                catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)", ex); }

                grv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void ReIndexingRow(DataGridView grv)
        {
            if (grv != null)
            {
                int rowCount = grv.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    grv.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        private void AddShipmentListToGrid(List<ShipmentOutEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ShipmentOutEntity item in listShipment)
                {
                    grv.Rows.Add(index, item.ShipmentId);
                    index++;
                }
                // setting up value count on gridview
                numberShipmentOut = index;
            }
        }
        private void LoadShipmentsByBoxId(BoxInforEntity boxEntity, DataGridView shipmentGrid)
        {
            if (boxEntity == null)
            {
                shipmentGrid.Rows.Clear();
                return;
            }

            List<ShipmentOutEntity> listShipment = (List<ShipmentOutEntity>)_shipmentOutServices.GetByBoxId(boxEntity.Id);
            List<ShipmentOutEntity> listShipmentOutTemp = (List<ShipmentOutEntity>)_shipmentOutTempServices.GetByBoxId(boxEntity.Id);

            if (listShipment != null)
            {
                if (listShipmentOutTemp != null)
                {
                    var result = MessageBox.Show("Có "+listShipmentOutTemp.Count+ " đơn hàng chưa lưu ở phiên làm việc trước, bạn có muốn tiếp tục xử lý hay không ?","Load đơn hàng chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        listShipment.AddRange(listShipmentOutTemp);
                    }
                    else
                    {
                        _shipmentOutTempServices.DeleteByEmployeeId(currentEmployee.Id);
                    }
                }
            }
            else
            {
                listShipment = listShipmentOutTemp;
            }

            if (listShipment != null && listShipment.Count > 0)
            {
                AddShipmentListToGrid(listShipment, shipmentGrid);
            }
            else
            {
                shipmentGrid.Rows.Clear();
            }
        }
        private void LoadBoxIdListFromMasterBillId(int masterBillId, ComboBox cbbBoxes)
        {
            if (masterBillId <= 0)
                return;

            List<BoxInforEntity> finalList = new List<BoxInforEntity>();
            var temp = new BoxInforEntity();
            temp.Id = 0;
            temp.BoxId = string.Empty;
            finalList.Add(temp);

            List<BoxInforEntity> listBoxInfo = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(masterBillId);
            if (listBoxInfo != null && listBoxInfo.Count > 0)
            {
                finalList.AddRange(listBoxInfo);
                cbbBoxes.DataSource = finalList;
                cbbBoxes.ValueMember = "Id";
                cbbBoxes.DisplayMember = "BoxId";
            }
            else
            {
                cbbBoxes.DataSource = null;
                cbbBoxes.Items.Clear();
            }
        }

        #endregion

        #region Các báo cáo
        
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrEmpty(txtSearch.Text))
            {
                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
                {
                    if (IsExistsOnTheGridView(grvShipments, txtSearch.Text))
                    {
                        MessageBox.Show("Tìm thấy đơn hàng vừa nhập đã có trên lưới", "Đơn hàng trùng lặp");
                    }

                    var result = _shipmentServices.SearchByShipmentId(txtSearch.Text);
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy thùng nào chứa đơn hàng vừa nhập!");
                    }
                    else
                    {
                        MessageBox.Show("Thùng chứa đơn hàng vừa nhập là:\n\n" + result.BoxId + "\nMã thùng này sẽ được copy xuống ô text box tìm kiếm bên dưới!", "Tìm thấy mã thùng");
                        txtSearch.Text = result.BoxId;
                        txtSearch.Focus();
                    }
                }
            }
        }

        private void cbbBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbbMasterBill_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }

        private void ClickKeyTab(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbbBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }

        private void cbbMasterBillOut_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }

        private void cbbBoxIdOut_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }
        
        #endregion

        #region Events buttons
        private void cbbMasterBill_Leave(object sender, EventArgs e)
        {
            cbbMasterBill.Text = cbbMasterBill.Text.ToUpper();
        }

        private void cbbBoxId_Leave(object sender, EventArgs e)
        {
            cbbBoxId.Text = cbbBoxId.Text.ToUpper();
        }
        
        private void FormNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (tabNhap.SelectedIndex == 0)
            //{
            //    //Xac nhan den
            //    if (xpos <= 0)
            //    {
            //        this.label10.Location = new System.Drawing.Point(this.Width, ypos);
            //        xpos = this.Width;
            //    }
            //    else
            //    {
            //        this.label10.Location = new System.Drawing.Point(xpos, ypos);
            //        xpos -= 5;
            //    }
            //}
            //else if (tabNhap.SelectedIndex == 1)
            //{
            //    //Nhap kho
            //    if (xposX >= this.Width)
            //    {
            //        //this.lblXuatKho.Location = new System.Drawing.Point(0, yposX);
            //        xposX = 0;
            //    }
            //    else
            //    {
            //        //this.lblXuatKho.Location = new System.Drawing.Point(xposX, yposX);
            //        xposX += 8;
            //    }
            //}
        }
 
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("NHẬP MÃ ĐỂ TÌM KIẾM"))
            {
                txtSearch.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbBoxId.Text) || cbbBoxId.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã thùng để in báo cáo");
                return;
            }

            ChiTietSanLuongNhapKhoTheoThung();
        }
        private void ChiTietSanLuongNhapKhoTheoThung()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            BoxInforEntity boxSelected = (BoxInforEntity)cbbBoxId.SelectedItem;

            int totalShipment = 0;

            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(boxSelected.Id);

            if (listShipment != null & listShipment.Count > 0)
            {
                foreach (var ship in listShipment)
                {
                    ReportDetailEntity entity = new ReportDetailEntity();
                    entity.MasterId = cbbMasterBill.Text;
                    entity.BoxId = boxSelected.BoxId;
                    entity.ShipmentId = ship.ShipmentId;
                    listDetail.Add(entity);
                }
                totalShipment = listShipment.Count;
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKhoTheoThung" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW03";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayDen.Value.ToString("dd/MM/yyyy") + "\n"

                            + "MÃ THÙNG: " + boxSelected.BoxId
                            + "\t\t\tTỔNG SỐ ĐƠN HÀNG: " + totalShipment;
            string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 10;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            Table table = doc.AddTable(listDetail.Count + 1, 7);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            for (int i = 0; i < totalShipment; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            doc.InsertParagraph(ngayDen, false, paraFormat);
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text) || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "NHẬP MÃ ĐỂ TÌM KIẾM";
            }
        }
        
        #endregion
    }
}
