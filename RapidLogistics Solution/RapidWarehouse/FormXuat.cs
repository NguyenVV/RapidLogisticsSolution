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
using System.Media;
using System.IO;
namespace RapidWarehouse
{
    public delegate void SaveDataDelegate(object position);
    public delegate string SaveShipmentOutDelegate(ShipmentOutEntity shipmentOut);
    public partial class FormXuat : Form
    {
        int numberShipmentOut = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        bool nhapMoiKhongCanXacNhan;
        ShipmentRepository _repositoryShipment = new ShipmentRepository();
        ManifestEntity manifestnew = new ManifestEntity();
        BoxOutEntity currentBoxOut;
        MasterAirwayBillEntity currentMasterOut;
        EmployeeEntity currentEmployee;
        SoundPlayer beep = new SoundPlayer(Environment.CurrentDirectory + @"\beep.wav");
        SoundPlayer ding = new SoundPlayer(Environment.CurrentDirectory + @"\ding.wav");
        SoundPlayer beep7 = new SoundPlayer(Environment.CurrentDirectory + @"\beep7.wav");
        private int indexWaitConfirmedDeleted = 0;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IBoxOutServices _boxOutServices;
        private readonly string SHIPMENT_NO = "Shipment No";
        private readonly string DECLARATIONNO = "Số tờ khai";
        private readonly string COMPANYNAME = "Người gửi";
        private readonly string COUNTRY = "Nước gửi";
        private readonly string CONTACTNAME = "Người nhận";
        private readonly string ADDRESS = "Địa chỉ nhận";
        private readonly string CONSIGNEE = "Consignee";
        private readonly string CONTENT = "Nội dung hàng";
        private readonly string PACKAGE = "Số kiện";
        private readonly string WEIGHT = "Khối lượng";
        private readonly string DATE_CREATED = "Ngày xuất kho";
        private readonly string DATEOFCOMPLETION = "Ngày thông quan";
        public FormXuat(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices, IBoxOutServices boxOutServices
            )
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _boxOutServices = boxOutServices;
            currentEmployee = FormLogin.mEmployee;
            BuildingGridviewRow();
            AddDeleteButtonToGridView(grvShipmentListOut);
            dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            txtShipmentNo.Text = "";
            ComboBoxBindData(cbbMasterBillOut);
            CloseBoxOut();
            cbbMasterBillOut.Focus();
            this.Text = "Xuất kho - " + FormUltils.getInstance().GetVersionInfo();
        }
        #region Xuất kho
        private void BuildingGridviewRow()
        {
            grvShipmentListOut.Size = new System.Drawing.Size(772, 601);
            grvShipmentListOut.ColumnCount = 3;
            //grvShipmentListOut.Columns[0].Name = STT;
            //grvShipmentListOut.Columns[0].ValueType = typeof(int);
            //grvShipmentListOut.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //grvShipmentListOut.Columns[0].ReadOnly = true;
            grvShipmentListOut.Columns[0].Name = SHIPMENT_NO;
            grvShipmentListOut.Columns[0].ValueType = typeof(string);
            grvShipmentListOut.Columns[1].Name = DATE_CREATED;
            grvShipmentListOut.Columns[1].ValueType = typeof(string);
            grvShipmentListOut.Columns[2].Name = WEIGHT;
            grvShipmentListOut.Columns[2].ValueType = typeof(double);
            //grvShipmentListOut.Columns[2].Name = DECLARATIONNO;
            //grvShipmentListOut.Columns[2].ValueType = typeof(string);
            //grvShipmentListOut.Columns[3].Name = COMPANYNAME;
            //grvShipmentListOut.Columns[4].ValueType = typeof(string);
            //grvShipmentListOut.Columns[4].Name = COUNTRY;
            //grvShipmentListOut.Columns[4].ValueType = typeof(string);
            //grvShipmentListOut.Columns[5].Name = CONTACTNAME;
            //grvShipmentListOut.Columns[5].ValueType = typeof(string);
            //grvShipmentListOut.Columns[6].Name = ADDRESS;
            //grvShipmentListOut.Columns[6].ValueType = typeof(string);
            //grvShipmentListOut.Columns[7].Name = CONSIGNEE;
            //grvShipmentListOut.Columns[7].ValueType = typeof(string);
            //grvShipmentListOut.Columns[8].Name = CONTENT;
            //grvShipmentListOut.Columns[8].ValueType = typeof(string);
            //grvShipmentListOut.Columns[9].Name = PACKAGE;
            //grvShipmentListOut.Columns[9].ValueType = typeof(int);
            //grvShipmentListOut.Columns[11].Name = DATEOFCOMPLETION;
            //grvShipmentListOut.Columns[11].ValueType = typeof(string);
        }
        private void FillInforOut()
        {
            lblMasterBillOut.Text = cbbMasterBillOut.Text;
            lblBoxIdOut.Text = cbbBoxIdOut.Text;
            lblNgayXuat.Text = dtpNgayXuat.Value.ToString("dd/MM/yyyy");
        }
        private void OpenBoxOut()
        {
            FillInforOut();
            numberShipmentOut = 1;
            dtpNgayXuat.Enabled = false;
            cbbMasterBillOut.Enabled = false;
            cbbBoxIdOut.Enabled = false;
            txtShipmentIdOut.Enabled = true;
            grvShipmentListOut.Enabled = true;
            txtShipmentIdOut.Focus();
            lblShipmentScanedOut.Text = (grvShipmentListOut.Rows.Count).ToString();
        }
        private void SaveShipmentOut(object position, ShipmentOutEntity shipmentOut)
        {
            int rowIndex = (int)position;
            if (grvShipmentListOut != null && grvShipmentListOut.Rows.Count > 0)
            {
                string shipmentId = Convert.ToString(grvShipmentListOut[SHIPMENT_NO, 0].Value);
                if (nhapMoiKhongCanXacNhan)
                {
                    ShipmentEntity shipment = new ShipmentEntity();
                    shipment.ShipmentId = shipmentId;
                    shipment.BoxId = currentBoxOut.Id;
                    shipment.DateCreated = DateTime.Now;
                    shipment.WarehouseId = FormLogin.mWarehouse.Id;
                    shipment.EmployeeId = currentEmployee.Id;
                    string package = Convert.ToString(grvShipmentListOut[PACKAGE, 0].Value);
                    if (string.IsNullOrEmpty(package))
                    {
                        shipment.NumberPackage = 1;
                    }
                    else
                    {
                        shipment.NumberPackage = Int32.Parse(Convert.ToString(grvShipmentListOut[PACKAGE, 0].Value));
                    }
                    shipment.Sender = Convert.ToString(grvShipmentListOut[COMPANYNAME, 0].Value);
                    shipment.DeclarationNo = Convert.ToString(grvShipmentListOut[DECLARATIONNO, 0].Value);
                    shipment.Address = Convert.ToString(grvShipmentListOut[ADDRESS, 0].Value);
                    shipment.Content = Convert.ToString(grvShipmentListOut[CONTENT, 0].Value);
                    shipment.Destination = Convert.ToString(grvShipmentListOut[CONSIGNEE, 0].Value);
                    shipment.Consignee = Convert.ToString(grvShipmentListOut[CONSIGNEE, 0].Value);
                    shipment.Receiver = Convert.ToString(grvShipmentListOut[CONTACTNAME, 0].Value);
                    string weight = Convert.ToString(grvShipmentListOut[WEIGHT, 0].Value);
                    if (string.IsNullOrEmpty(weight))
                    {
                        shipment.Weight = 0d;
                    }
                    else
                    {
                        shipment.Weight = Double.Parse(Convert.ToString(grvShipmentListOut[WEIGHT, 0].Value));
                    }
                    shipment.Country = Convert.ToString(grvShipmentListOut[COUNTRY, 0].Value);
                    shipment.DateOfCompletion = null;
                    if (grvShipmentListOut[DATEOFCOMPLETION, 0].Value != null)
                        shipment.DateOfCompletion = Convert.ToDateTime(grvShipmentListOut[DATEOFCOMPLETION, rowIndex - 10].Value);
                    _shipmentServices.CreateOrUpdateByQuery(shipment);
                }
                _shipmentOutServices.CreateOrUpdateByQuery(shipmentOut);
            }
        }
        private void CloseBoxOut()
        {
            dtpNgayXuat.Enabled = true;
            cbbMasterBillOut.Enabled = true;
            cbbBoxIdOut.Enabled = true;
            txtShipmentIdOut.Enabled = false;
            txtShipmentIdOut.BackColor = Color.WhiteSmoke;
            grvShipmentListOut.Enabled = false;
            txtShipmentIdOut.Text = String.Empty;
            grvShipmentListOut.Rows.Clear();
            lblCountIn.Text = "0";
            lblClearance.Text = "0";
        }

        private void cbbBoxIdOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBoxIdOut.SelectedIndex > 0)
            {
                lblBoxIdOut.Text = cbbBoxIdOut.Text;
            }
            else
            {
                grvShipmentListOut.Rows.Clear();
                lblBoxIdOut.Text = "";
                lblShipmentScanedOut.Text = "0";
            }
        }
        private bool CheckBoxIdProcessingByAnother(int boxId)
        {
            var shipmentOut = _shipmentOutServices.GetByBoxId(boxId);
            if (shipmentOut != null && shipmentOut.First().EmployeeId != currentEmployee.Id)
            {
                MessageBox.Show("Mã thùng này đang được xử lý bởi người khác, vui lòng chọn mã thùng khác! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        #region btnOpenBoxOut_Click
        private void btnOpenBoxOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOpenBoxOut.Text.Equals("Mở", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (String.IsNullOrWhiteSpace(cbbMasterBillOut.Text) || String.IsNullOrWhiteSpace(cbbBoxIdOut.Text))
                    {
                        MessageBox.Show("Bạn phải nhập mã Airwaybill", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentMasterOut = _masterBillServices.GetByMasterBillId(cbbMasterBillOut.Text);
                    if (currentMasterOut == null)
                    {
                        nhapMoiKhongCanXacNhan = true;
                        currentMasterOut = new MasterAirwayBillEntity
                        {
                            MasterAirwayBill = cbbMasterBillOut.Text,
                            DateArrived = dtpNgayXuat.Value,
                            EmployeeId = currentEmployee.Id,
                            DateCreated = DateTime.Now
                        };
                        currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(currentMasterOut);
                        currentMasterBill = currentMasterOut.MasterAirwayBill;
                        currentMasterOut.Id = currentMasterBillId;
                    }
                    else
                    {
                        currentMasterBill = currentMasterOut.MasterAirwayBill;
                        currentMasterBillId = currentMasterOut.Id;
                    }
                    /// Chuyển sang BOX OUT
                    currentBoxOut = _boxOutServices.GetByBoxCodeandAirWaybill(cbbBoxIdOut.Text, currentMasterOut.Id);
                    if (currentBoxOut == null)
                    {
                        nhapMoiKhongCanXacNhan = true;
                        currentBoxOut = new BoxOutEntity
                        {
                            BoxId = cbbBoxIdOut.Text,
                            ShipmentQuantity = 0,
                            MasterBillId = currentMasterBillId,
                            EmployeeId = currentEmployee.Id,
                            DateCreated = DateTime.Now,
                            DateInt = _repositoryShipment.DateToInt(DateTime.Now)
                        };
                        currentBoxIdInt = _boxOutServices.CreateBoxOut(currentBoxOut);
                        currentBoxId = currentBoxOut.BoxId;
                        currentBoxOut.Id = currentBoxIdInt;
                    }
                    else
                    {
                        currentBoxIdInt = currentBoxOut.Id;
                        currentBoxId = currentBoxOut.BoxId;
                    }
                    if (!LoadShipmentsByBoxId(currentBoxOut, grvShipmentListOut))
                        return;
                    OpenBoxOut();
                    // Dữ liệu xác nhận đến
                    #region Dữ liệu xác nhận đến                    
                    BoxInforEntity boxEntity = _boxInforServices.GetByBoxId(cbbBoxIdOut.Text.Trim());
                    if (boxEntity != null)
                        lblCountIn.Text =  _boxInforServices.GetByBoxId(boxEntity.Id).ShipmentQuantity.ToString();
                    IEnumerable<ShipmentEntity> lstShipmentInfor = _shipmentServices.GetByBoxId(boxEntity.Id);
                    if (lstShipmentInfor != null)
                    {
                        lstShipmentInfor = lstShipmentInfor.Where(t => t.Status == "Check");
                        lblClearance.Text =  lstShipmentInfor.Count().ToString();
                    }
                    #endregion
                    txtShipmentIdOut.BackColor = Color.LightYellow;
                    btnOpenBoxOut.Text = "Đóng";
                }
                else
                {
                    currentBoxOut = _boxOutServices.GetByBoxCode(cbbBoxIdOut.Text);
                    if (currentBoxOut == null)
                        return;
                    else
                    {
                        IEnumerable<ShipmentOutEntity> lstshipment = _shipmentOutServices.GetByBoxId(currentBoxOut.Id);
                        if (lstshipment == null)
                            _boxOutServices.Delete(currentBoxOut.Id);
                        else
                            _boxOutServices.CreateOrUpdateByQuery(lstshipment.Count(), currentBoxOut.Id);
                    }
                    CloseBoxOut();
                    btnOpenBoxOut.Text = "Mở";
                }
            }
            catch (Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "btnOpenBoxOut_Click", ex);
                return;
            }
        }
        #endregion
        bool startProcessing = false;
        #region ShipmentIdOut Keydown
        private void txtShipmentIdOut_KeyDown(object sender, KeyEventArgs e)
        {
            string shipmentinput = txtShipmentIdOut.Text.Trim().ToUpper();
            ShipmentEntity shipment = new ShipmentEntity();
            try
            {
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    if (String.IsNullOrEmpty(shipmentinput) || String.IsNullOrWhiteSpace(txtShipmentIdOut.Text))
                        return;
                    if (startProcessing)
                        return;
                    startProcessing = true;
                    #region Kiểm tra trùng trên lưới nhập
                    if (IsExistsOnTheGridView(grvShipmentListOut, shipmentinput))
                    {
                        beep7.Play();
                        txtShipmentIdOut.Enabled = false;
                        int rowIndex = -1;
                        DataGridViewRow row = grvShipmentListOut.Rows
                            .Cast<DataGridViewRow>()
                            .Where(r => r.Cells[0].Value.ToString().Equals(shipmentinput))
                            .First();
                        rowIndex = row.Index;
                        grvShipmentListOut.Rows[rowIndex].Selected = true;
                        MessageBox.Show("TRÙNG DỮ LIỆU TRÊN LƯỚI !!!\nBạn hãy kiểm tra dữ liệu vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtShipmentIdOut.Enabled = true;
                        txtShipmentIdOut.Text = String.Empty;
                        txtShipmentNo.Text = "";
                        txtShipmentIdOut.Focus();
                        startProcessing = false;
                        return;
                    }
                    #endregion
                    #region Kiểm tra trùng trên thùng đã xuất
                    if (_repositoryShipment.ShipmentOutExist(shipmentinput))
                    {
                        beep7.Play();
                        txtShipmentIdOut.Enabled = false;
                        MessageBox.Show("TRÙNG DỮ LIỆU TRÊN THÙNG ĐÃ XUẤT KHO !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtShipmentIdOut.Enabled = true;
                        txtShipmentIdOut.Text = String.Empty;
                        txtShipmentNo.Text = "";
                        txtShipmentIdOut.Focus();
                        startProcessing = false;
                        return;
                    }
                    #endregion
                    #region Kiểm tra vị trí thùng
                    if (_repositoryShipment.ShipmentExist(shipmentinput))
                    {
                        beep7.Play();
                        manifestnew = new ManifestEntity();
                        manifestnew = _repositoryShipment.GetManifestByShipmentNo(shipmentinput);
                        if (manifestnew.BoxID != cbbBoxIdOut.Text.Trim())
                        {
                            txtShipmentIdOut.Enabled = false;
                            if (MessageBox.Show("LẠC HƯỚNG THÙNG !!! \nDữ liệu bạn nhập có thể nằm ở thùng: " + manifestnew.BoxID + "(" + manifestnew.MasterAirWayBill + ")\nBạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                txtShipmentIdOut.Enabled = true;
                                txtShipmentIdOut.Text = String.Empty;
                                txtShipmentNo.Text = "";
                                startProcessing = false;
                                return;
                            }
                        }
                    }
                    #endregion
                    #region Kiểm tra hàng thông quan
                    if (!_shipmentOutServices.GetStatusCompletion(shipmentinput))
                    {
                        beep.Play();
                        txtShipmentIdOut.BackColor = Color.Tomato;
                        if (MessageBox.Show("Hàng chưa được phép thông quan. \nBạn có muốn tiếp tục không ?", "Hàng chưa được phép thông quan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            txtShipmentIdOut.Enabled = true;
                            startProcessing = false;
                            txtShipmentIdOut.Text = "";
                            txtShipmentIdOut.Focus();
                            txtShipmentNo.Text = "";
                            txtShipmentIdOut.BackColor = Color.LightYellow;
                            return;
                        }
                        else
                            txtShipmentIdOut.BackColor = Color.LightYellow;
                    }
                    #endregion
                    try
                    {
                        //grvShipmentListOut.Rows.Add(grvShipmentListOut.Rows.Count + 1, shipmentinput, DateTime.Now, Math.Round(manifestnew.Weight, 3));
                        grvShipmentListOut.Rows.Insert(0, shipmentinput, DateTime.Now, Math.Round(manifestnew.Weight, 3));
                        // grvShipmentListOut.FirstDisplayedScrollingRowIndex = grvShipmentListOut.RowCount - 1;
                        grvShipmentListOut.FirstDisplayedScrollingRowIndex = 0;
                        lblShipmentScanedOut.Text = "" + grvShipmentListOut.Rows.Count;
                        numberShipmentOut++;
                        grvShipmentListOut.ClearSelection();
                        grvShipmentListOut.Rows[0].Selected = true;
                        //  grvShipmentListOut.Rows[grvShipmentListOut.Rows.Count - 1].Selected = true;
                        //  AddOneShipmentToGridView(grvShipmentListOut.Rows.Count + 1, shipmentexport, grvShipmentListOut);
                    }
                    catch
                    {
                        startProcessing = false;
                    }
                    ShipmentOutEntity shipmentOut = new ShipmentOutEntity();
                    shipmentOut.ShipmentId = shipmentinput;
                    shipmentOut.BoxIdRef = currentBoxOut.Id;
                    shipmentOut.BoxIdString = currentBoxOut.BoxId;
                    shipmentOut.MasterBillId = currentMasterOut.Id;
                    shipmentOut.MasterBillIdString = currentMasterOut.MasterAirwayBill;
                    shipmentOut.DateOut = dtpNgayXuat.Value;
                    shipmentOut.DateCreated = DateTime.Now;
                    shipmentOut.DateInt = _repositoryShipment.DateToInt(DateTime.Now);
                    shipmentOut.EmployeeId = currentEmployee.Id;
                    shipmentOut.WarehouseId = FormLogin.mWarehouse.Id;
                    shipmentOut.Weight = Math.Round(Convert.ToDouble(manifestnew.Weight), 3);
                    shipmentOut.DeclarationNo = _shipmentOutServices.GetDeclarationNo(shipmentinput);
                    shipmentOut.DateOfCompletion = _shipmentOutServices.GetDateOfCompletion(shipmentinput);
                    shipmentOut.Tel = manifestnew.Tel;
                    shipmentOut.Address = manifestnew.Address;
                    shipmentOut.ContactName = manifestnew.ContactName;
                    shipmentOut.CompanyName = manifestnew.CompanyName;
                    shipmentOut.Content = manifestnew.Content;
                    shipmentOut.Country = manifestnew.Country;
                    shipmentOut.Destination = manifestnew.Destination;
                    shipmentOut.Original = manifestnew.Original;
                    shipmentOut.Quantity = manifestnew.Quantity;
                    shipmentOut.TotalValue = manifestnew.TotalValue;
                    _repositoryShipment.CreateShipmentOut(shipmentOut);
                    // SaveShipmentOut(grvShipmentListOut.Rows.Count, shipmentOut);
                    ding.Play();
                    txtShipmentIdOut.Text = String.Empty;
                    startProcessing = false;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "txtShipmentIdOut_KeyDown", ex);
                return;
            }

        }
        #endregion

        #endregion

        #region Dùng chung       
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

        private void LoadAllMasterBillByDateToCombobox(DateTime date, ComboBox cbbMaster)
        {
            cbbMaster.DataSource = null;
            cbbMaster.Items.Clear();
            int dateint = _repositoryShipment.DateToInt(date);
            List<MasterAirwayBillEntity> masterBillList = _repositoryShipment.GetAirwaybillByDate(dateint);
            masterBillList = masterBillList.OrderByDescending(x => x.DateArrived).ToList();
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbMaster.DataSource = masterBillList;
                cbbMaster.ValueMember = "Id";
                cbbMaster.DisplayMember = "MasterAirwayBill";
            }
        }
        private void ComboBoxBindData(ComboBox cbbMaster)
        {
            cbbMaster.DataSource = null;
            cbbMaster.Items.Clear();
            List<MasterAirwayBillEntity> masterBillList = _repositoryShipment.GetAllAirwaybill();
            masterBillList = masterBillList.OrderByDescending(x => x.DateArrived).ToList();
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbMaster.DataSource = masterBillList;
                cbbMaster.ValueMember = "Id";
                cbbMaster.DisplayMember = "MasterAirwayBill";
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
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        private void AddShipmentListToGrid(List<ShipmentExport> listShipment, DataGridView grv)
        {
            if (grv != null && listShipment != null)
            {
                int index = 1;
                grv.Rows.Clear();
                foreach (ShipmentExport item in listShipment)
                {
                    AddOneShipmentToGridView(index, item, grv);
                    index++;
                }
                numberShipmentOut = index;
            }
        }
        private void AddOneShipmentToGridView(int index, ShipmentExport item, DataGridView grv)
        {
            grv.Rows.Add(item.ShipmentId, item.DateOut, item.Weight);
            grv.FirstDisplayedScrollingRowIndex = 0;
        }
        private bool LoadShipmentsByBoxId(BoxOutEntity boxEntity, DataGridView shipmentGrid)
        {
            ShipmentRepository _repositoryShipment = new ShipmentRepository();
            ShipmentExport shipmentexport = new ShipmentExport();
            try
            {
                if (boxEntity == null)
                {
                    shipmentGrid.DataSource = null;
                    return false;
                }
                List<ShipmentExport> listShipment = _repositoryShipment.GetListShipmentByBoxId(boxEntity.Id);
                string text = "";
                DialogResult process = DialogResult.Yes;
                if (listShipment != null && listShipment.Count > 0)
                {
                    text += "Tổng số đơn hàng: " + listShipment.Count;
                    text += "\nXuất kho ngày " + boxEntity.DateCreated.ToString("dd/MM/yyyy");
                    text += "\nBạn muốn mở không ?";
                    process = MessageBox.Show(text, boxEntity.BoxId, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (process == DialogResult.Yes)
                {
                    if (listShipment != null)
                    {
                        AddShipmentListToGrid(listShipment, shipmentGrid);
                    }
                    return true;
                }
                else
                {
                    shipmentGrid.DataSource = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "LoadShipmentsByBoxId", ex);
                return false;
            }
        }
        private void LoadBoxIdListFromMasterBillId(int masterBillId, ComboBox cbbBoxes)
        {
            if (masterBillId <= 0)
                return;

            List<BoxOutEntity> listBoxOut = _repositoryShipment.GetBoxIdByMasterBillid(masterBillId);
            if (listBoxOut != null && listBoxOut.Count > 0)
            {
                cbbBoxes.DataSource = listBoxOut;
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
        #region Delete from grid
        private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)
        {
            if (e.RowIndex == grv.NewRowIndex || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == grv.Columns["dataGridViewDeleteButton"].Index)
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa đơn hàng : " + grv.Rows[e.RowIndex].Cells[SHIPMENT_NO].Value, "Xóa đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                try
                {
                    if (grvType == 2)
                    {
                        _shipmentOutServices.Delete(grv.Rows[e.RowIndex].Cells[SHIPMENT_NO].Value.ToString());
                        lblShipmentScanedOut.Text = (grv.Rows.Count - 1) + "";
                    }
                }
                catch (Exception ex)
                {
                    Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)", ex);
                }
                grv.Rows.RemoveAt(e.RowIndex);
            }
        }
        #endregion

        #region Events
        private void txtShipmentIdOut_TextChanged(object sender, EventArgs e)
        {
            txtShipmentNo.Text = txtShipmentIdOut.Text;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chức năng xuất kho?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GoHome();
            }
        }
        private void GoHome()
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        private void ClickKeyTab(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cbbMasterBillOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMasterBillOut.SelectedIndex >= 0)
            {
                cbbBoxIdOut.Text = "";
                MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterBillOut.SelectedItem;
                lblMasterBillOut.Text = itemMaster.MasterAirwayBill;
                LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdOut);
            }
            else
            {
                cbbBoxIdOut.DataSource = null;
                lblMasterBillOut.Text = "";
            }
        }
        private void cbbMasterBillOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{TAB}");
                if (cbbMasterBillOut.SelectedIndex >= 0)
                {
                    MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterBillOut.SelectedItem;
                    lblMasterBillOut.Text = itemMaster.MasterAirwayBill;
                    LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdOut);
                }
                else
                {
                    cbbBoxIdOut.DataSource = null;
                    lblMasterBillOut.Text = "";
                }
            }
        }

        private void cbbBoxIdOut_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }
        private void cbbMasterBillOut_Leave(object sender, EventArgs e)
        {
            cbbMasterBillOut.Text = cbbMasterBillOut.Text.ToUpper();
        }
        private void FormXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            GoHome();
        }
        #endregion     

        #region Báo cáo
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ChiTietSanLuongXuatKho();
        }
        private void cbbBoxIdOut_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{TAB}");
                lblBoxIdOut.Text = cbbBoxIdOut.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<frmTrace>().Show();
        }
        private void dtpNgayXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void grvShipmentListOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowFromGridview(grvShipmentListOut, e, 2);
            numberShipmentOut--;
        }

        private void ChiTietSanLuongXuatKho()
        {
            BoxOutEntity box = _boxOutServices.GetByBoxCode(cbbBoxIdOut.Text);
            if (box == null)
            {
                MessageBox.Show("Chọn mã thùng để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<ShipmentExport> listDetail = _repositoryShipment.GetListShipmentByBoxId(box.Id);
            DataTable table = new DataTable();
            table.Columns.Add(StringHeaderReports.STT);
            table.Columns.Add(StringHeaderReports.MAWB);
            table.Columns.Add(StringHeaderReports.BOXID);
            table.Columns.Add(StringHeaderReports.SHIPMENTNO);
            //table.Columns.Add(StringHeaderReports.DECLARATION_NO, typeof(string));
            table.Columns.Add(StringHeaderReports.CONTENT);
            //table.Columns.Add(StringHeaderReports.NUMBER_PACKAGE);
            table.Columns.Add(StringHeaderReports.WEIGHT);

            int totalThung = 0, index = 1;
            int totalShipment;
            if (listDetail != null && listDetail.Count > 0)
            {
                totalShipment = listDetail.Count;
                totalThung = 1;
                int boxId = listDetail[0].BoxIdRef;
                for (int i = 0; i < totalShipment; i++)
                {
                    // var shipment = listShipDetail.Find(t => t.ShipmentId == listDetail[i].ShipmentId);
                    DataRow row = table.NewRow();
                    row[StringHeaderReports.STT] = index;
                    row[StringHeaderReports.MAWB] = listDetail[i].MasterBillIdString;
                    row[StringHeaderReports.SHIPMENTNO] = "'" + listDetail[i].ShipmentId;
                    row[StringHeaderReports.BOXID] = listDetail[i].BoxIdString;
                    row[StringHeaderReports.WEIGHT] = listDetail[i].Weight;
                    row[StringHeaderReports.CONTENT] = listDetail[i].Content;
                    table.Rows.Add(row);
                    index++;

                    if (boxId != listDetail[i].BoxIdRef)
                    {
                        totalThung++;
                        boxId = listDetail[i].BoxIdRef;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có hàng hóa nào được xuất kho!");
                return;
            }
            string infoHeader = "MÃ THÙNG: ";
            string value = box.BoxId;

            Dictionary<string, string> first = new Dictionary<string, string>();
            first.Add("NGÀY XUẤT : ", dtpNgayXuat.Value.ToString("dd/MM/yyyy"));
            Dictionary<string, string> second = new Dictionary<string, string>();
            second.Add(infoHeader, value);
            second.Add("TỔNG SỐ ĐƠN HÀNG: ", "" + totalShipment);            
            FormUltils.getInstance().ExportToExcel(table, "CT_Xuat_Kho_Theo_Thung", StringHeaderReports.REPORTS_NAME_CHI_TIET_XUAT_KHO, StringHeaderReports.REPORT_CODE_01, first, second);

            #region word report
            //int totalShipment;
            //if (listDetail != null && listDetail.Count > 0)
            //{
            //    totalShipment = listDetail.Count;
            //}
            //else
            //{
            //    MessageBox.Show("Chưa có đơn hàng của mã thùng này nào được xuất kho!", "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            //string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tEMW01";
            //string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG XUẤT KHO";
            //string ngayDen = "NGÀY ĐẾN : " + dtpNgayXuat.Value.ToString("dd/MM/yyyy") + "\n"

            //                + "MÃ SỐ THÙNG: " + box.BoxId
            //                + "\t\t\tTỔNG ĐƠN HÀNG: " + totalShipment;
            //string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            //// A formatting object for our headline:
            //var headLineFormat = new Formatting();
            //headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //headLineFormat.Size = 18D;
            //headLineFormat.Position = 12;
            //headLineFormat.Bold = true;

            //// A formatting object for our normal paragraph text:
            //var paraFormat = new Formatting();
            //paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraFormat.Size = 12D;
            //paraFormat.Position = 10;
            //paraFormat.Bold = false;


            //var paraRightFormat = new Formatting();
            //paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraRightFormat.Size = 12D;
            //paraRightFormat.Position = 12;
            //paraRightFormat.Bold = true;

            //// Create the document in memory:
            //var doc = DocX.Create(fileName);

            //Table table = doc.AddTable(listDetail.Count + 1, 7);

            ////table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            //table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            ////table.Rows[0].Cells[0].Width = 50;
            //table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[1].Width = 800;
            //table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[2].Width = 100;
            //table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            //for (int i = 0; i < totalShipment; i++)
            //{
            //    table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterBillIdString).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxIdString).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //}

            //doc.InsertParagraph(companyName, false, paraFormat);
            //doc.InsertParagraph(Environment.NewLine);
            //// Insert the now text obejcts;
            //Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            //title.Alignment = Alignment.center;
            //doc.InsertParagraph(ngayDen, false, paraFormat);
            //doc.InsertTable(table);
            //doc.InsertParagraph(Environment.NewLine);
            //Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            //giaoNhan.Alignment = Alignment.center;
            //// Save to the output directory:

            //doc.SaveAs(fileName);
            //// Open in Word:
            //Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
            #endregion
        }
        #endregion
    }
}
