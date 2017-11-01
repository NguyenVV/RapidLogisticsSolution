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
using RapidWarehouse.Data;
namespace RapidWarehouse
{
    public partial class FormNhap : Form
    {
        int numberShipment = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        List<ManifestEntity> manifestList;
        List<ShipmentEntity> lstShipmentInfor = new List<ShipmentEntity>();
        EmployeeEntity currentEmployee;
        ShipmentRepository _repositoryShipment = new ShipmentRepository();
        List<ManifestEntity> listManifest = new List<ManifestEntity>();
        private int indexWaitConfirmedDeleted = 0;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
        
        private readonly IShipmentOutTempServices _shipmentOutTempServices;
        private readonly string SHIPMENT_NO = "Shipment No";
        private readonly string STT = "STT";
        private readonly string ID = "Id";
        private readonly string COMPANYNAME = "Người gửi";
        private readonly string COUNTRY = "Nước gửi";
        private readonly string CONTACTNAME = "Người nhận";
        private readonly string ADDRESS = "Địa chỉ nhận";
        private readonly string CONSIGNEE = "Consignee";
        private readonly string CONTENT = "Nội dung hàng";
        private readonly string WEIGHT = "Khối lượng";
        //private readonly string DECLARATIONNO = "Số TK";
        //private readonly string DATEOFCOMPLETION = "Ngày thông quan";
        public FormNhap(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IManifestServices manifestServices, IShipmentOutTempServices shipmentOutTempServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _manifestServices = manifestServices;          
            _shipmentOutTempServices = shipmentOutTempServices;
            currentEmployee = FormLogin.mEmployee;
            BuildingTheGridviewRowStrure();
            AddDeleteButtonToGridView(grvShipments);
            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            ResetHardCodeText();
            LoadAllMasterBillByDateToCombobox(cbbMasterBill);
            cbbMasterBill.SelectedText = "";
            FillInforXacNhanDen();
            CloseBox();
            ResetFormInfoNhap();
            dtpNgayDen.Focus();
            this.Text = "Xác nhận đến - " + FormUltils.getInstance().GetVersionInfo();
        }

        #region Xác nhận đến
        private void BuildingTheGridviewRowStrure()
        {
            grvShipments.ColumnCount = 10;
            grvShipments.Columns[0].Name = STT;
            grvShipments.Columns[0].ValueType = typeof(int);
            grvShipments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipments.Columns[0].ReadOnly = true;
            grvShipments.Columns[1].Name = ID;
            grvShipments.Columns[1].ValueType = typeof(int);
            grvShipments.Columns[1].Visible = false;
            grvShipments.Columns[2].Name = SHIPMENT_NO;
            grvShipments.Columns[2].ValueType = typeof(string);
            grvShipments.Columns[3].Name = COMPANYNAME;
            grvShipments.Columns[3].ValueType = typeof(string);
            grvShipments.Columns[4].Name = COUNTRY;
            grvShipments.Columns[4].ValueType = typeof(string);
            grvShipments.Columns[5].Name = CONTACTNAME;
            grvShipments.Columns[5].ValueType = typeof(string);
            grvShipments.Columns[6].Name = ADDRESS;
            grvShipments.Columns[6].ValueType = typeof(string);
            grvShipments.Columns[7].Name = CONSIGNEE;
            grvShipments.Columns[7].ValueType = typeof(string);
            grvShipments.Columns[8].Name = CONTENT;
            grvShipments.Columns[8].ValueType = typeof(string);
            grvShipments.Columns[9].Name = WEIGHT;
            grvShipments.Columns[9].ValueType = typeof(float);

        }
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text.Equals("Mở", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!ValidateInputDataConfirmArrived())
                    return;

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
                }
                else
                {
                    currentBoxIdInt = boxEntity.Id;
                    currentBoxId = boxEntity.BoxId;
                }
                OpenBox();
                LoadShipmentsByBoxIdInXacNhanDen(cbbBoxId.Text, grvShipments);
                btnOpenClose.Text = "Đóng";
            }
            else
            {
                if (!isConfirmed)
                    SaveShipment();
                BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(cbbBoxId.Text);
                if (boxEntity == null)
                    return;
                else
                {
                    IEnumerable<ShipmentEntity> lstshipment = _shipmentServices.GetByBoxId(boxEntity.Id);
                    if (lstshipment == null)
                        _boxInforServices.Delete(boxEntity.Id);
                    else
                        _boxInforServices.CreateOrUpdateByQuery(lstshipment.Count(), boxEntity.Id);
                }

                CloseBox();
                btnOpenClose.Text = "Mở";
            }
            MasterAirwayBillEntity itemMaster = _masterBillServices.GetByMasterBillId(cbbMasterBill.Text);
        }
        private void ResetFormInfoNhap()
        {
            lblShipmentScaned.Text = String.Empty;
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
        private bool isConfirmed;
        private bool ValidateInputDataConfirmArrived()
        {
            isConfirmed = false;
            if (String.IsNullOrWhiteSpace(cbbMasterBill.Text) || String.IsNullOrWhiteSpace(cbbBoxId.Text))
            {
                MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) và Mã thùng trước", "Thông báo", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return false;
            }
            if (!CheckIsBoxIdExistsInManifest(cbbBoxId.Text))
            {
                MessageBox.Show("Không tồn tại dữ liệu.", "Thông báo", MessageBoxButtons.OK);
                cbbBoxId.Focus();
                return false;
            }
            BoxInforEntity box = _boxInforServices.GetByBoxId(cbbBoxId.Text);
            if (box == null)
            {
                listManifest = _repositoryShipment.GetManifestByBoxId(cbbBoxId.Text.Trim());
                listManifest = listManifest.GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
                var result = MessageBox.Show("Tổng số đơn hàng: " + listManifest.Count + "\nBạn có muốn xác nhận không?", cbbBoxId.Text, MessageBoxButtons.YesNo);
                return result == DialogResult.Yes;
            }
            else
            {

                lstShipmentInfor = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                var result = MessageBox.Show("Tổng số đơn hàng: " + lstShipmentInfor.Count + "\nBạn có muốn mở không?", cbbBoxId.Text, MessageBoxButtons.YesNo);
                return result == DialogResult.Yes;
            }

        }
        private void FillInforXacNhanDen()
        {
            lblMasterBill.Text = cbbMasterBill.Text;
            lblBoxId.Text = cbbBoxId.Text;
            lblNgayDen.Text = dtpNgayDen.Value.ToString("dd/MM/yyyy");
        }
        private void SaveShipment()
        {
            try
            {
                string boxstring = cbbBoxId.Text.Trim();
                int count = 0;
                BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(cbbBoxId.Text.Trim());
                if (boxEntity == null)
                {
                    boxEntity = new BoxInforEntity();
                    boxEntity.BoxId = boxstring;
                    boxEntity.DateCreated = DateTime.Now;
                    boxEntity.EmployeeId = currentEmployee.Id;
                    boxEntity.ShipmentQuantity = 0; //manifestList.Where(t => t.BoxID == boxstring).Count();
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
                if (_repositoryShipment.ShipmentExistByBoxId(boxEntity.Id))
                    return;
                List<ManifestEntity> listManifest = new List<ManifestEntity>();
                listManifest = _repositoryShipment.GetManifestByBoxId(boxstring);
                listManifest = listManifest.GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
                if (listManifest != null && listManifest.Count > 0)
                {
                    List<ShipmentEntity> listShipment = new List<ShipmentEntity>();
                    foreach (var item in listManifest)
                    {
                        if (_repositoryShipment.ShipmentExist(item.ShipmentNo))
                            continue;
                        ShipmentEntity shipment = new ShipmentEntity();
                        shipment.Mawb = item.MasterAirWayBill;
                        shipment.ShipmentId = item.ShipmentNo;
                        shipment.BoxId = currentBoxIdInt;
                        shipment.DateCreated = DateTime.Now;
                        shipment.EmployeeId = currentEmployee.Id;
                        shipment.WarehouseId = FormLogin.mWarehouse.Id;
                        shipment.Address = item.Address;
                        shipment.BoxIdString = item.BoxID;
                        shipment.Content = item.Content;
                        shipment.Country = item.Country;
                        shipment.DeclarationNo = item.DeclarationNo;
                        shipment.Destination = item.Destination;
                        shipment.NumberPackage = 1;
                        shipment.Sender = item.CompanyName;
                        shipment.Consignee = item.Destination;
                        shipment.Receiver = item.ContactName;
                        shipment.Weight = Math.Round(item.Weight, 3);
                        shipment.ReceiverTel = item.Tel;
                        listShipment.Add(shipment);
                    }
                    count += _shipmentServices.CreateOrUpdate(listShipment);
                }

                MessageBox.Show("Đã lưu xác nhận đến thành công!\nTổng số đơn hàng là " + count, "Lưu xác nhận đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }

        }
        private ShipmentEntity convertFromManifest(ManifestEntity manifest)
        {
            ShipmentEntity shipment = new ShipmentEntity();
            shipment.ShipmentId = manifest.ShipmentNo;
            shipment.BoxId = currentBoxIdInt;
            shipment.DateCreated = DateTime.Now;
            shipment.WarehouseId = FormLogin.mWarehouse.Id;
            shipment.EmployeeId = currentEmployee.Id;
            shipment.NumberPackage = manifest.Quantity;
            shipment.Sender = manifest.CompanyName;
            shipment.Address = manifest.Address;
            shipment.Content = manifest.Content;
            shipment.Destination = manifest.Destination;
            shipment.Consignee = manifest.Destination;
            shipment.Receiver = manifest.ContactName;
            shipment.Weight = manifest.Weight;
            shipment.Country = manifest.Country;
            return shipment;
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
        private void LuuXacNhanDen()
        {
            List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
            if (listBoxInfo != null && listBoxInfo.Count > 0)
            {
                int count = 0;
                foreach (var itemBoxID in listBoxInfo)
                {
                    BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(itemBoxID.BoxID);
                    if (boxEntity == null)
                    {
                        boxEntity = new BoxInforEntity();
                        boxEntity.BoxId = itemBoxID.BoxID;
                        boxEntity.DateCreated = DateTime.Now;
                        boxEntity.EmployeeId = currentEmployee.Id;
                        boxEntity.ShipmentQuantity = manifestList.Where(t => t.BoxID == itemBoxID.BoxID).Count();
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
                    List<ManifestEntity> listShipmentNo = new List<ManifestEntity>();
                    listManifest = _repositoryShipment.GetManifestByBoxId(boxEntity.BoxId);
                    listManifest = listManifest.GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
                    // Add shipment here
                    //    List<ManifestEntity> listShipmentNo = manifestList.Where(t => t.BoxID == itemBoxID.BoxID).GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
                    if (listShipmentNo != null && listShipmentNo.Count > 0)
                    {
                        List<ShipmentEntity> listShipment = new List<ShipmentEntity>();
                        foreach (var item in listShipmentNo)
                        {
                            ShipmentEntity shipment = new ShipmentEntity();
                            shipment.ShipmentId = item.ShipmentNo;
                            shipment.BoxId = currentBoxIdInt;
                            shipment.DateCreated = DateTime.Now;
                            shipment.EmployeeId = currentEmployee.Id;
                            shipment.WarehouseId = FormLogin.mWarehouse.Id;
                            shipment.Address = item.Address;
                            shipment.BoxIdString = item.BoxID;
                            shipment.Content = item.Content;
                            shipment.Country = item.Country;
                            shipment.DeclarationNo = item.DeclarationNo;
                            shipment.Destination = item.Destination;
                            shipment.NumberPackage = 1;
                            shipment.Sender = item.CompanyName;
                            shipment.Consignee = item.Destination;
                            shipment.Receiver = item.ContactName;
                            shipment.Weight = Math.Round(item.Weight, 3);
                            listShipment.Add(shipment);
                        }
                        count = _shipmentServices.CreateOrUpdate(listShipment);
                    }
                }
                MessageBox.Show("Đã lưu xác nhận đến thành công!\nTổng số đơn hàng là " + count, "Lưu xác nhận đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadAllMasterBillByDateToComboboxXacNhanDen(DateTime date)
        {
            manifestList = _manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            List<MasterAirwayBillEntity> finalList = new List<MasterAirwayBillEntity>();
            var masterBillList = manifestList.GroupBy(t => t.MasterAirWayBill).Select(p => p.First());
            if (masterBillList != null && masterBillList.Any())
            {
                foreach (ManifestEntity manifest in masterBillList)
                {
                    MasterAirwayBillEntity entity = new MasterAirwayBillEntity();
                    entity.MasterAirwayBill = manifest.MasterAirWayBill;
                    finalList.Add(entity);
                }
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
            cbbBoxId.Text = "";
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
            return _repositoryShipment.BoxIdExist(boxId);
        }
        private void cbbBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddShipmentListToGrid(IEnumerable<ManifestEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ManifestEntity item in listShipment)
                {
                    grv.Rows.Add(index, 0, item.ShipmentNo, item.CompanyName
                        , item.Country, item.ContactName, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", Math.Round(item.Weight, 3)), "");
                    index++;
                }
                numberShipment = index;
            }
        }
        private void AddShipmentListToGrid(IEnumerable<ShipmentEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ShipmentEntity item in listShipment)
                {
                    grv.Rows.Add(index, item.Id, item.ShipmentId, item.Sender, item.Country, item.Receiver, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", Math.Round(item.Weight)), item.DateOfCompletion == new DateTime() ? null : item.DateOfCompletion);
                    index++;
                }
                numberShipment = index;
            }
        }
        private void dtpNgayDen_ValueChanged(object sender, EventArgs e)
        {

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
                string dateOfCreation = _shipmentServices.GetDateOfCompletion(txtShipmentId.Text);//_shipmentServices.GetDeclarationNo(txtShipmentId.Text)
                grvShipments.Rows.Add(grvShipments.Rows.Count + 1, cbbMasterBill.Text, 0, txtShipmentId.Text, null, null
                    , null, null, null, null, null, 1, null, dateOfCreation);
                ShipmentEntity item = new ShipmentEntity();
                item.BoxId = currentBoxIdInt;
                item.BoxIdString = currentBoxId;
                item.ShipmentId = txtShipmentId.Text;
                item.Mawb = cbbMasterBill.Text;

                _shipmentServices.CreateOrUpdate(item);
                grvShipments.ClearSelection();
                grvShipments.Rows[grvShipments.Rows.Count - 1].Selected = true;
                grvShipments.FirstDisplayedScrollingRowIndex = grvShipments.Rows.Count - 1;
                UpdateValueOverviewNhapKho();
            }
        }

        private void LoadShipmentsByBoxIdInXacNhanDen(string boxId, DataGridView shipmentGrid)
        {
            if (!string.IsNullOrEmpty(boxId))
            {
                if (listManifest != null && listManifest.Any())
                {
                    AddShipmentListToGrid(listManifest, shipmentGrid);
                }
                else if (lstShipmentInfor != null && lstShipmentInfor.Any())
                {
                    AddShipmentListToGrid(lstShipmentInfor, shipmentGrid);
                }
                else
                {
                    shipmentGrid.Rows.Clear();
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
            grv.Columns.Add(checkColumn);
        }
        private void LoadAllMasterBillByDateToCombobox(ComboBox cbbMaster)
        {
            List<MasterAirwayBillEntity> masterBillList = (List<MasterAirwayBillEntity>)_masterBillServices.GetAllMasterBills();
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
                cbbBoxId.DataSource = null;
                cbbBoxId.Items.Clear();
            }
        }
        private bool IsExistsOnTheGridView(DataGridView grv, string shipmentId)
        {
            for (int i = 0; i < grv.Rows.Count; i++)
            {
                if (grv.Rows[i].Cells[SHIPMENT_NO].Value != null && shipmentId.Equals(grv.Rows[i].Cells[SHIPMENT_NO].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    grv.ClearSelection();
                    grv.Rows[i].Selected = true;
                    grv.FirstDisplayedScrollingRowIndex = i;
                    grv.Focus();
                    indexWaitConfirmedDeleted = i;
                    return true;
                }
            }

            return false;
        }
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

        private void cbbBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void cbbMasterBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterAirwayBillEntity masterBill = (MasterAirwayBillEntity)cbbMasterBill.SelectedItem;
            if (masterBill != null)
            {
                IEnumerable<BoxInforEntity> listBoxInfo = _boxInforServices.GetByMasterBill(masterBill.Id);
                if (listBoxInfo != null && listBoxInfo.Any())
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
        private void cbbMasterBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(cbbMasterBill.Text))
                {
                    return;
                }
                SendKeys.Send("{TAB}");
                MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(cbbMasterBill.Text);
                if (masterBill == null)
                {
                    cbbMasterBill.DataSource = null;
                    cbbMasterBill.Items.Clear();
                    cbbBoxId.DataSource = null;
                    cbbBoxId.Items.Clear();
                }
            }
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(cbbBoxId.Text))
                {
                    return;
                }
                SendKeys.Send("{TAB}");
                lblBoxId.Text = cbbBoxId.Text;
            }
        }
        #endregion
        #region Events buttons           
        private void FormNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
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

        private void btnXNĐ_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbbMasterBill.Text))
            {
                MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) trước", "Nhập thông tin", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return;
            }
            if (!CheckIsMawbExistsInManifest(cbbMasterBill.Text))
            {
                MessageBox.Show("Mã MAWB không có trong manifest của ngày đã chọn " + dtpNgayDen.Value.ToString("dd/MM/yyyy"), "Nhập thông tin", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return;
            }
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

            }
            else
            {
                currentMasterBillId = masterBill.Id;
                currentMasterBill = masterBill.MasterAirwayBill;
                MessageBox.Show("Mã MAWB: " + masterBill.MasterAirwayBill + " này đã được xác nhận rồi", "Mã MAWB đã được xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LuuXacNhanDen();
        }
        private void dtpNgayDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{TAB}");
            }
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
                    entity.Weight = ship.Weight;
                    entity.Content = ship.Content;
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
                table.Rows[i + 1].Cells[4].Paragraphs.First().Append(listDetail[i].Content).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[6].Paragraphs.First().Append("" + listDetail[i].Weight).Font(new FontFamily("Times New Roman"));
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

        #endregion
    }
}
