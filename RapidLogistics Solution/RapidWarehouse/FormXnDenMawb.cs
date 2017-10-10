using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormXnDenMawb : Form
    {
        int numberShipment = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        List<ManifestEntity> manifestList;
        EmployeeEntity currentEmployee;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
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
            BuildingTheGridviewRowStrure();

            //AddDeleteButtonToGridView(grvShipments);

            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);

            cbbMasterBill.SelectedText = "";
            FillInforXacNhanDen();
            CloseBox();
            ResetFormInfoNhap();
            dtpNgayDen.Focus();
            this.Text = "Xác nhận đến theo MAWB- " + FormUltils.getInstance().GetVersionInfo();
        }

        #region Xác nhận đến
        
        private void BuildingTheGridviewRowStrure()
        {
            grvShipments.ColumnCount = 14;
            grvShipments.Columns[0].Name = STT;
            grvShipments.Columns[0].ValueType = typeof(int);
            grvShipments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipments.Columns[0].ReadOnly = true;
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
        private void ResetFormInfoNhap()
        {
            lblShipmentScaned.Text = String.Empty;
            lblNgayDen.Text = String.Empty;
            lblMasterBill.Text = String.Empty;
        }
        
        private bool ValidateInputDataConfirmArrived()
        {
            if (String.IsNullOrWhiteSpace(cbbMasterBill.Text))
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

            return true;
        }
        private void FillInforXacNhanDen()
        {
            lblMasterBill.Text = cbbMasterBill.Text;
            lblNgayDen.Text = dtpNgayDen.Value.ToString("dd/MM/yyyy");
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
            shipment.DeclarationNo = manifest.DeclarationNo;
            shipment.Address = manifest.Address;
            shipment.Content = manifest.Content;
            shipment.Destination = manifest.Destination;
            shipment.Consignee = manifest.Destination;
            shipment.Receiver = manifest.ContactName;
            shipment.Weight = manifest.Weight;
            shipment.Country = manifest.Country;
            //shipment.DateOfCompletion = "";
            //DateTime completed = Convert.ToDateTime(grvShipments[DATEOFCOMPLETION, i].Value);
            //if (grvShipments[DATEOFCOMPLETION, i].Value != null && !string.IsNullOrEmpty(grvShipments[DATEOFCOMPLETION, i].Value.ToString()))
            //    shipment.DateOfCompletion = Convert.ToDateTime(grvShipments[DATEOFCOMPLETION, i].Value);
            //else
            //    shipment.DateOfCompletion = null;
            return shipment;
        }
        private void CloseBox()
        {
            dtpNgayDen.Enabled = true;
            cbbMasterBill.Enabled = true;
            //grvShipments.Enabled = false;
            grvShipments.Rows.Clear();
        }
        int count = 0;
        private void LuuXacNhanDen(string masterBill)
        {
            count = 0;
            List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == masterBill).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
            if (listBoxInfo != null && listBoxInfo.Count > 0)
            {
                //object result = Jacksonsoft.WaitWindow.Show(this.ProgressWorkerMethod, "Vui lòng chờ...   0%");
                //MessageBox.Show(result.ToString());
                
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

                    // Add shipment here
                    List<ManifestEntity> listShipmentNo = manifestList.Where(t => t.BoxID == itemBoxID.BoxID).GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList();
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
                            shipment.Weight = item.Weight;

                            listShipment.Add(shipment);
                        }

                        count += _shipmentServices.CreateOrUpdate(listShipment);
                    }
                }

                MessageBox.Show("Đã lưu xác nhận đến thành công!\nTổng số đơn hàng là " + count, "Lưu xác nhận đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            LuuXacNhanDen(e.Arguments[0].ToString());
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
        private void LoadAllMasterBillByDateToComboboxXacNhanDen(DateTime date)
        {
            manifestList = _manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            List<MasterAirwayBillEntity> finalList = new List<MasterAirwayBillEntity>();
            //finalList.Add(new ManifestEntity());

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

        private void cbbMasterBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMasterBill.Text = cbbMasterBill.Text;
            //List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
            lblShipmentScaned.Text = "0";
            if (manifestList != null)
            {
                lblShipmentScaned.Text = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.ShipmentNo).Select(p => p.First()).Count() + "";
            }
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
        
        private void AddShipmentListToGrid(IEnumerable<ManifestEntity> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ManifestEntity item in listShipment)
                {
                    //if (string.IsNullOrEmpty(item.DeclarationNo))
                    //{
                    //    item.DeclarationNo = _shipmentServices.GetDeclarationNo(item.ShipmentNo);
                    //}

                    //string dateOfCreation = _shipmentServices.GetDateOfCompletion(item.ShipmentNo);

                    grv.Rows.Add(index, item.MasterAirWayBill, 0, item.ShipmentNo, item.DeclarationNo, item.CompanyName
                        , item.Country, item.ContactName, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", item.Weight), "");
                    index++;
                    //if(!isConfirmed)
                    //    _shipmentServices.CreateOrUpdate(convertFromManifest(item));
                }
                // setting up value count on gridview
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
                    grv.Rows.Add(index, cbbMasterBill.Text, item.Id, item.ShipmentId, item.DeclarationNo, item.Sender
                        , item.Country, item.Receiver, item.Address, item.Destination, item.Content, 1, String.Format("{0:0.000}", item.Weight), item.DateOfCompletion == new DateTime() ? null : item.DateOfCompletion);
                    index++;
                    //if (!isConfirmed)
                    //    _shipmentServices.CreateOrUpdate(item);
                }
                // setting up value count on gridview
                numberShipment = index;
            }
        }

        private void dtpNgayDen_ValueChanged(object sender, EventArgs e)
        {
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            lblNgayDen.Text = dtpNgayDen.Value.ToString("dd/MM/yyyy");
            LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);
        }
        
        #endregion

        #region Dùng chung
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

        private void FormNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
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
                //cbbMasterBill.Items.Add(masterBill);
                //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);
                //cbbMasterBill.SelectedText = masterBill.MasterAirwayBill;
            }
            else
            {
                currentMasterBillId = masterBill.Id;
                currentMasterBill = masterBill.MasterAirwayBill;
                MessageBox.Show("Mã MAWB: " + masterBill.MasterAirwayBill + " này đã được xác nhận rồi", "Mã MAWB đã được xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod,"Vui lòng chờ...", cbbMasterBill.Text);
            //MessageBox.Show(result.ToString());
            //LuuXacNhanDen();
            AddShipmentListToGrid(manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.ShipmentNo).Select(p => p.First()).ToList(), grvShipments);
        }

        private void dtpNgayDen_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }

        #endregion
    }
}
