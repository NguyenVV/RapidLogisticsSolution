using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
            grvShipments.ColumnCount = 3;
            grvShipments.Columns[0].Name = "STT";
            grvShipments.Columns[0].ValueType = typeof(int);
            grvShipments.Columns[2].Name = "Id";
            grvShipments.Columns[2].ValueType = typeof(int);
            grvShipments.Columns[2].Visible = false;
            grvShipments.Columns[1].Name = "Shipment Id";

            AddDeleteButtonToGridView(grvShipments);

            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            ResetHardCodeText();
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            //LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);

            cbbMasterBill.SelectedText = "";
            FillInforXacNhanDen();
            CloseBox();
            ResetFormInfoNhap();
            ResetFormInfoXuat();
            //xpos = label10.Location.X;
            //ypos = label10.Location.Y;
            //timer1.Start();
        }

        #region Xác nhận đến
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text.Equals("Mở", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!ValidateInputDataConfirmArrived())
                    return;

                OpenBox();
                LoadShipmentsByBoxIdInXacNhanDen(cbbBoxId.Text, grvShipments);
                btnOpenClose.Text = "Đóng";
                if (!cbbBoxId.Items.Contains(cbbBoxId.Text))
                {
                    cbbBoxId.Items.Add(cbbBoxId.Text);
                }
                if (!cbbMasterBill.Items.Contains(cbbMasterBill.Text))
                {
                    cbbMasterBill.Items.Add(cbbMasterBill.Text);
                }
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
                lblDonDaQuet.Text = "" + _boxInforServices.GetTotalShipmentByMasterBill(itemMaster.Id);
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

        private void ResetFormInfoXuat() { 
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
                var resultBox = MessageBox.Show("Mã BoxId này đã được xác nhận rồi, có " + shipmentAmount + " shipments, bạn có muốn mở không ?", "BoxId đã được xác nhận", MessageBoxButtons.YesNo);
                cbbBoxId.Focus();
                return resultBox == DialogResult.Yes;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xử lý BoxId: " + cbbBoxId.Text + " với tổng số ShipmentNo = " + shipmentAmount, "Chọn xử lý", MessageBoxButtons.YesNo);

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
                        string shipmentId = grvShipments["Shipment Id", i].Value.ToString();
                        ShipmentEntity shipment = new ShipmentEntity();
                        shipment.ShipmentId = shipmentId;
                        shipment.BoxId = currentBoxIdInt;
                        shipment.DateCreated = DateTime.Now;
                        shipment.EmployeeId = currentEmployee.Id;
                        try
                        {
                            if (!_shipmentServices.Exists(shipmentId))
                            {
                                listShipment.Add(shipment);
                            }
                        }
                        catch (Exception e) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void SaveBoxInfor()", e); }
                    }
                    _shipmentServices.Create(listShipment);
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
        private void LuuXacNhanDen()
        {
            var masterBillList = manifestList.GroupBy(t => t.MasterAirWayBill).Select(p => p.First()).ToList();

            if (masterBillList != null && masterBillList.Count > 0)
            {
                foreach (var manifest in masterBillList)
                {
                    MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(manifest.MasterAirWayBill);
                    if (masterBill == null)
                    {
                        masterBill = new MasterAirwayBillEntity();
                        masterBill.MasterAirwayBill = manifest.MasterAirWayBill;
                        masterBill.DateArrived = dtpNgayDen.Value;
                        masterBill.DateCreated = DateTime.Now;
                        masterBill.EmployeeId = currentEmployee.Id;
                        currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(masterBill);
                        currentMasterBill = masterBill.MasterAirwayBill;
                        masterBill.Id = currentMasterBillId;
                    }

                    List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
                    if (listBoxInfo != null && listBoxInfo.Count > 0)
                    {
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
                                    try
                                    {
                                        if (!_shipmentServices.Exists(shipment.ShipmentId))
                                        {
                                            listShipment.Add(shipment);
                                        }
                                    }
                                    catch (Exception e) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void LuuXacNhanDen()", e); }
                                }

                                int count = _shipmentServices.Create(listShipment);
                            }
                        }
                    }
                }

                MessageBox.Show("Đã lưu xác nhận đến thành công!");
                //btnXacNhan.Enabled = false;
            }
        }
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
            //if (!string.IsNullOrEmpty(cbbMasterBill.Text))
            //{
            //    if (!string.IsNullOrEmpty(cbbMasterBill.Text))
            //    {
            //        MasterAirwayBillEntity masterBill = _masterBillServices.GetByMasterBillId(cbbMasterBill.Text);
            //        //if (masterBill != null)
            //        //{
            //        //    btnXacNhan.Text = "Đã Xác Nhận";
            //        //    btnXacNhan.Enabled = false;
            //        //}
            //        //else
            //        //{
            //        //    btnXacNhan.Text = "Xác Nhận MAWB Này";
            //        //    btnXacNhan.Enabled = true;
            //        //}
            //    }

            //    List<ManifestEntity> finalList = new List<ManifestEntity>();
            //    finalList.Add(new ManifestEntity());

            //    List<ManifestEntity> listBoxInfo = manifestList.Where(t => t.MasterAirWayBill == cbbMasterBill.Text).GroupBy(t => t.BoxID).Select(p => p.First()).ToList();
            //    if (listBoxInfo != null && listBoxInfo.Count > 0)
            //    {
            //        finalList.AddRange(listBoxInfo);
            //        cbbBoxId.DataSource = finalList;
            //        cbbBoxId.ValueMember = "BoxId";
            //        cbbBoxId.DisplayMember = "BoxId";
            //    }
            //    else
            //    {
            //        cbbBoxId.DataSource = null;
            //        cbbBoxId.Items.Clear();
            //    }
            //}
            //else
            //{
            //    cbbBoxId.DataSource = null;
            //    cbbBoxId.Items.Clear();
            //}

            //lblMasterBill.Text = cbbMasterBill.Text;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMasterBill.Text))
            {
                MessageBox.Show("Hãy chọn một mã MAWB để xác nhận");
                return;
            }

            LuuXacNhanDen();
        }

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
                    grv.Rows.Add(index, item.ShipmentNo, item.ShipmentNo);
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
                    grv.Rows.Add(index, item.ShipmentId, item.Id);
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
            //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);
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
                    MessageBox.Show("Tìm thấy shipment vừa nhập đã có trên lưới", "Shipment trùng lặp");
                    txtShipmentId.Text = String.Empty;
                    return;
                }

                if (_shipmentServices.GetByShipmentId(txtShipmentId.Text) != null)
                {
                    MessageBox.Show("Mã shipment vừa nhập đã có trong kho nên không thể nhập kho", "Shipment đã tồn tại", MessageBoxButtons.OK);
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
            cbbMaster.DataSource = null;
            cbbMaster.Items.Clear();

            List<MasterAirwayBillEntity> finalList = new List<MasterAirwayBillEntity>();
            var temp = new MasterAirwayBillEntity();
            temp.Id = 0;
            temp.MasterAirwayBill = string.Empty;
            finalList.Add(temp);

            List<MasterAirwayBillEntity> masterBillList = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateArrived(date);
            if (masterBillList != null && masterBillList.Count > 0)
            {
                finalList.AddRange(masterBillList);
                cbbMaster.DataSource = finalList;
                cbbMaster.ValueMember = "Id";
                cbbMaster.DisplayMember = "MasterAirwayBill";
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
                if (grv.Rows[i].Cells["Shipment Id"].Value != null && shipmentId.Equals(grv.Rows[i].Cells["Shipment Id"].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
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
                DialogResult result = MessageBox.Show("Bạn muốn xóa shipment : " + grv.Rows[e.RowIndex].Cells["Shipment Id"].Value, "Xóa shipment", MessageBoxButtons.YesNo);
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
                            _shipmentServices.Delete(grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString());
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
                        MessageBox.Show("Tìm thấy shipment vừa nhập đã có trên lưới", "Shipment trùng lặp");
                    }

                    var result = _shipmentServices.SearchByShipmentId(txtSearch.Text);
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy BoxId nào chứa Shipment vừa nhập!");
                    }
                    else
                    {
                        MessageBox.Show("BoxId chứa Shipment vừa nhập là:\n\n" + result.BoxId + "\nBoxId này sẽ được copy xuống ô text box tìm kiếm bên dưới!", "Tìm thấy BoxId");
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
            if (tabNhap.SelectedIndex == 0)
            {
                //Xac nhan den
                if (xpos <= 0)
                {
                    this.label10.Location = new System.Drawing.Point(this.Width, ypos);
                    xpos = this.Width;
                }
                else
                {
                    this.label10.Location = new System.Drawing.Point(xpos, ypos);
                    xpos -= 5;
                }
            }
            else if (tabNhap.SelectedIndex == 1)
            {
                //Nhap kho
                if (xposX >= this.Width)
                {
                    //this.lblXuatKho.Location = new System.Drawing.Point(0, yposX);
                    xposX = 0;
                }
                else
                {
                    //this.lblXuatKho.Location = new System.Drawing.Point(xposX, yposX);
                    xposX += 8;
                }
            }
        }
 
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("NHẬP MÃ ĐỂ TÌM KIẾM"))
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text) || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "NHẬP MÃ ĐỂ TÌM KIẾM";
            }
        }
        
        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblThungDaQuet_Click(object sender, EventArgs e)
        {

        }

    }
}
