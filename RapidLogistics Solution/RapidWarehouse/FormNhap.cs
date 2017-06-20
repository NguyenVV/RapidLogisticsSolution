using System;
using System.Windows.Forms;
using BusinessEntities;
using BusinessServices.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Novacode;
using System.Diagnostics;
using System.Linq;
using System.Drawing;

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
        bool nhapMoiKhongCanXacNhan;
        BoxInforEntity currentBoxOut;
        MasterAirwayBillEntity currentMasterOut;
        List<ManifestEntity> manifestList;
        EmployeeEntity currentEmployee;
        private int xpos = 0, ypos = 0;
        private int xposX = 0, yposX = 0;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
        private readonly IShipmentWaitToConfirmedServices _shipmentWaitConfirmedServices;
        public FormNhap(IMasterBillServices masterBillServices, IShipmentServices shipmentServices, IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices, IManifestServices manifestServices, IShipmentWaitToConfirmedServices shipmentWaitToConfirmedServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _manifestServices = manifestServices;
            _shipmentWaitConfirmedServices = shipmentWaitToConfirmedServices;
            currentEmployee = FormLogin.mEmployee;
            grvShipments.ColumnCount = 3;
            grvShipments.Columns[0].Name = "STT";
            grvShipments.Columns[0].ValueType = typeof(int);
            grvShipments.Columns[2].Name = "Id";
            grvShipments.Columns[2].ValueType = typeof(int);
            grvShipments.Columns[2].Visible = false;
            grvShipments.Columns[1].Name = "Shipment Id";
            grvShipmentListOut.ColumnCount = 2;
            grvShipmentListOut.Columns[0].Name = "STT";
            grvShipmentListOut.Columns[0].ValueType = typeof(int);
            grvShipmentListOut.Columns[1].Name = "Shipment Id";

            grvShipmentsWaitConfirmed.ColumnCount = 2;
            grvShipmentsWaitConfirmed.Columns[0].Name = "STT";
            grvShipmentsWaitConfirmed.Columns[0].ValueType = typeof(int);
            grvShipmentsWaitConfirmed.Columns[1].Name = "Shipment Id";

            //listViewShipmentBlocked.Columns.Add("Shipment Id", 500);
            //listViewShipmentBlocked.View = View.Details;

            AddDeleteButtonToGridView(grvShipments);
            AddDeleteButtonToGridView(grvShipmentListOut);
            AddDeleteButtonToGridView(grvShipmentsWaitConfirmed);
            LoadAllWaitConfirmedToGridview();

            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            dtpNgayBaoCao.CustomFormat = "dd/MM/yyyy";
            dtpNgayXuatReport.CustomFormat = "dd/MM/yyyy";
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.CustomFormat = "dd/MM/yyyy";
            grvShipments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipmentListOut.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipmentsWaitConfirmed.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ResetHardCodeText();
            manifestList = (List<ManifestEntity>)_manifestServices.GetManifestByDateString(dtpNgayDen.Value.ToString("yyyy-MM-dd"));
            //LoadAllMasterBillByDateToComboboxXacNhanDen(dtpNgayDen.Value);
            //LoadAllMasterBillByDateToCombobox(dtpNgayDen.Value, cbbMasterBill);

            cbbMasterBill.SelectedText = "";
            LoadAllMasterBillByDateToCombobox(dtpNgayBaoCao.Value, cbbMasterList);
            FillInforXacNhanDen();
            FillInforOut();
            CloseBox();
            CloseBoxOut();
            ResetFormInfoNhap();
            ResetFormInfoXuat();
            xpos = label10.Location.X;
            ypos = label10.Location.Y;
            timer1.Start();
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

        private void ResetFormInfoXuat()
        {
            //Form xuat
            lblDonDaQuetOut.Text = String.Empty;
            lblThungDaQuetOut.Text = String.Empty;
            lblDonDaXuat.Text = String.Empty;
            //lblNgayDen.Text = String.Empty;
            lblShipmentScanedOut.Text = String.Empty;
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
                MessageBox.Show("Mã MAWB không có trong manifest", "Nhập thông tin", MessageBoxButtons.OK);
                cbbMasterBill.Focus();
                return false;
            }
            if (!CheckIsBoxIdExistsInManifest(cbbBoxId.Text))
            {
                MessageBox.Show("Mã BoxId không có trong manifest", "Nhập thông tin", MessageBoxButtons.OK);
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
                            _shipmentServices.Create(shipment);
                        }
                    }
                    catch (Exception e) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void SaveBoxInfor()", e); }
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

        private void dtpNgayXuat_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayXuat.Value, cbbMasterBillOut);
            lblNgayXuat.Text = dtpNgayXuat.Value.ToString("dd/MM/yyyy");
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

            var box = _boxInforServices.GetByBoxId(cbbBoxIdOut.Text);
            LoadShipmentsByBoxId(box, grvShipmentListOut);
            lblShipmentScanedOut.Text = (grvShipmentListOut.Rows.Count).ToString();
        }

        private void SaveShipmentOut()
        {
            int rowCount = grvShipmentListOut.Rows.Count;
            if (rowCount > 0)
            {
                List<ShipmentOutEntity> listShipment = new List<ShipmentOutEntity>();
                for (int i = 0; i < rowCount; i++)
                {
                    string shipmentId = grvShipmentListOut["Shipment Id", i].Value.ToString();
                    if (!_shipmentOutServices.IsExist(shipmentId))
                    {
                        ShipmentOutEntity shipmentOut = new ShipmentOutEntity();
                        shipmentOut.ShipmentId = shipmentId;
                        shipmentOut.BoxIdRef = currentBoxOut.Id;
                        shipmentOut.BoxIdString = currentBoxOut.BoxId;
                        shipmentOut.MasterBillId = currentMasterOut.Id;
                        shipmentOut.MasterBillIdString = currentMasterOut.MasterAirwayBill;
                        shipmentOut.DateOut = dtpNgayXuat.Value;
                        shipmentOut.DateCreated = DateTime.Now;
                        shipmentOut.EmployeeId = currentEmployee.Id;
                        listShipment.Add(shipmentOut);
                    }
                }

                _shipmentOutServices.Create(listShipment);
            }
        }

        private void CloseBoxOut()
        {
            dtpNgayXuat.Enabled = true;
            cbbMasterBillOut.Enabled = true;
            cbbBoxIdOut.Enabled = true;
            txtShipmentIdOut.Enabled = false;
            grvShipmentListOut.Enabled = false;
            txtShipmentIdOut.Text = String.Empty;
            grvShipmentListOut.Rows.Clear();
        }

        /// <summary>
        /// Xóa trên form xuất kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvShipmentListOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowFromGridview(grvShipmentListOut, e, 2);
            numberShipmentOut--;
            ReIndexingRow(grvShipmentListOut);
        }

        private void cbbMasterBillOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMasterBillOut.SelectedIndex > 0)
            {
                MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterBillOut.SelectedItem;
                lblDonDaQuetOut.Text = "" + _boxInforServices.GetTotalByMasterBill(itemMaster.Id);
                lblDonDaXuat.Text = "" + _shipmentOutServices.GetTotalByMasterBill(itemMaster.Id);
                lblMasterBillOut.Text = itemMaster.MasterAirwayBill;
                LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdOut);
                lblThungDaQuetOut.Text = (cbbBoxIdOut.Items.Count - 1) > 0 ? (cbbBoxIdOut.Items.Count - 1).ToString() : "0";
            }
            else
            {
                cbbBoxIdOut.DataSource = null;
                lblDonDaXuat.Text = "0";
                lblDonDaQuetOut.Text = "0";
                lblThungDaQuetOut.Text = "0";
                lblMasterBillOut.Text = "";
            }
        }

        private void cbbBoxIdOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBoxIdOut.SelectedIndex > 0)
            {
                BoxInforEntity item = (BoxInforEntity)cbbBoxIdOut.SelectedItem;
                lblBoxIdOut.Text = item.BoxId;
                LoadShipmentsByBoxId(item, grvShipmentListOut);
                lblShipmentScanedOut.Text = (grvShipmentListOut.Rows.Count).ToString();
            }
            else
            {
                grvShipmentListOut.Rows.Clear();
                lblBoxIdOut.Text = "";
                lblShipmentScanedOut.Text = "0";
            }
        }

        private void btnOpenBoxOut_Click(object sender, EventArgs e)
        {
            if (btnOpenBoxOut.Text.Equals("Mở", StringComparison.CurrentCultureIgnoreCase))
            {
                if (String.IsNullOrWhiteSpace(cbbMasterBillOut.Text) || String.IsNullOrWhiteSpace(cbbBoxIdOut.Text))
                {
                    MessageBox.Show("Bạn cần phải nhập Master airway bill (MAWB) và Mã thùng trước", "Nhập thông tin", MessageBoxButtons.OK);
                    return;
                }
                currentMasterOut = _masterBillServices.GetByMasterBillId(cbbMasterBillOut.Text);
                if (currentMasterOut == null)
                {
                    var result = MessageBox.Show("Mã MAWB vừa nhập chưa được xác nhận đến trên hệ thống!\n Bạn có muốn nhập mới luôn không ?", "Nhập thông tin", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        nhapMoiKhongCanXacNhan = false;
                        return;
                    }
                    nhapMoiKhongCanXacNhan = true;

                    currentMasterOut = new MasterAirwayBillEntity();
                    currentMasterOut.MasterAirwayBill = cbbMasterBillOut.Text;
                    currentMasterOut.DateArrived = dtpNgayDen.Value;
                    currentMasterBillId = _masterBillServices.CreateMasterAirwayBill(currentMasterOut);
                    currentMasterBill = currentMasterOut.MasterAirwayBill;
                    currentMasterOut.Id = currentMasterBillId;
                }
                else
                {
                    currentMasterBill = currentMasterOut.MasterAirwayBill;
                    currentMasterBillId = currentMasterOut.Id;
                }

                currentBoxOut = _boxInforServices.GetByBoxId(cbbBoxIdOut.Text);
                if (currentBoxOut == null)
                {
                    var result = MessageBox.Show("Mã thùng vừa nhập chưa được xác nhận đến trên hệ thống!\n Bạn có muốn nhập mới luôn không ?", "Nhập thông tin", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        nhapMoiKhongCanXacNhan = false;
                        return;
                    }
                    nhapMoiKhongCanXacNhan = true;

                    currentBoxOut = new BoxInforEntity();
                    currentBoxOut.BoxId = cbbBoxIdOut.Text;
                    currentBoxOut.ShipmentQuantity = 0;
                    currentBoxOut.MasterBillId = currentMasterBillId;
                    currentBoxIdInt = _boxInforServices.CreateBoxInfor(currentBoxOut);
                    currentBoxId = currentBoxOut.BoxId;
                    currentBoxOut.Id = currentBoxIdInt;
                    //MessageBox.Show("Mã thùng vừa nhập không có trên hệ thống", "Nhập thông tin", MessageBoxButtons.OK);
                    //return;
                }
                else
                {
                    currentBoxIdInt = currentBoxOut.Id;
                    currentBoxId = currentBoxOut.BoxId;
                }


                OpenBoxOut();
                btnOpenBoxOut.Text = "Đóng";
            }
            else
            {
                SaveShipmentOut();
                CloseBoxOut();
                btnOpenBoxOut.Text = "Mở";
                //ResetFormInfoXuat();
                LoadAllMasterBillByDateToCombobox(dtpNgayXuat.Value, cbbMasterBillOut);
            }

            if (currentMasterOut != null)
            {
                lblThungDaQuetOut.Text = "" + _boxInforServices.GetByMasterBill(currentMasterOut.Id).Count();
                lblDonDaXuat.Text = "" + _shipmentOutServices.GetTotalByMasterBill(currentMasterOut.Id);
            }
        }

        private void txtShipmentIdOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShipmentIdOut.Text) || String.IsNullOrWhiteSpace(txtShipmentIdOut.Text))
                return;

            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                lblVuaNhapOut.Text = txtShipmentIdOut.Text;

                if (IsExistsOnTheGridView(grvShipmentsWaitConfirmed, txtShipmentIdOut.Text))
                {
                    Beep(1000, 1000);
                    Beep(1000, 1000);
                    Beep(1000, 1000);
                    MessageBox.Show("Shipment vừa nhập " + txtShipmentIdOut.Text + " đã có trên danh sách chờ thông quan", "Shipment chờ thông quan");
                    txtShipmentIdOut.Text = String.Empty;
                    return;
                }

                if (IsExistsOnTheGridView(grvShipmentListOut, txtShipmentIdOut.Text))
                {
                    MessageBox.Show("Tìm thấy shipment vừa nhập đã có trên lưới", "Shipment trùng lặp");
                    txtShipmentIdOut.Text = String.Empty;
                    return;
                }

                //Check chưa có trong bảng ShipmentInfor thì thêm mới vào
                if (_shipmentServices.GetByShipmentIdAndBoxId(txtShipmentIdOut.Text, currentBoxOut.Id) == null)
                {
                    if (!nhapMoiKhongCanXacNhan)
                    {
                        MessageBox.Show("Mã shipment vừa nhập hiện không có trong kho hoặc trong mã thùng này\n nên không thể xuất kho", "Nhập thông tin", MessageBoxButtons.OK);
                        txtShipmentIdOut.Text = String.Empty;
                        return;
                    }
                    ShipmentEntity shipment = new ShipmentEntity();
                    shipment.ShipmentId = txtShipmentIdOut.Text;
                    shipment.BoxId = currentBoxOut.Id;
                    try
                    {
                        shipment.Id = _shipmentServices.Create(shipment);
                    }
                    catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void txtShipmentIdOut_KeyDown(object sender, KeyEventArgs e)", ex); }
                }

                if (_shipmentOutServices.IsExist(txtShipmentIdOut.Text))
                {
                    MessageBox.Show("Mã shipment vừa nhập đã được xuất rồi\n nên không thể xuất kho", "Nhập thông tin", MessageBoxButtons.OK);
                    txtShipmentIdOut.Text = String.Empty;
                    return;
                }

                grvShipmentListOut.Rows.Add(grvShipmentListOut.Rows.Count + 1, txtShipmentIdOut.Text);
                lblShipmentScanedOut.Text = "" + grvShipmentListOut.Rows.Count;
                numberShipmentOut++;
                grvShipmentListOut.ClearSelection();
                grvShipmentListOut.Rows[grvShipmentListOut.Rows.Count - 1].Selected = true;
                grvShipmentListOut.FirstDisplayedScrollingRowIndex = grvShipmentListOut.Rows.Count - 1;

                txtShipmentIdOut.Text = String.Empty;
                //}
                //else
                //{
                //    MessageBox.Show("Mã shipment vừa nhập hiện không có trong kho hoặc trong mã thùng này\n nên không thể xuất kho", "Nhập thông tin", MessageBoxButtons.OK);
                //    txtShipmentIdOut.Text = String.Empty;
                //    return;
                //}
            }
        }

        #endregion

        #region Dùng chung
        private void ResetHardCodeText()
        {
            lblMaVuaNhap.Text = "";
            lblVuaNhapOut.Text = "";
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
                    else if (grvType == 2)
                    {
                        _shipmentOutServices.Delete(grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString());
                        lblShipmentScanedOut.Text = (grv.Rows.Count - 1) + "";
                    }
                    else
                    {
                        try
                        {
                            _shipmentWaitConfirmedServices.Delete(grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString());
                            ShipmentOutEntity item = new ShipmentOutEntity();

                            item.ShipmentId = grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString();
                            ShipmentEntity shipment = _shipmentServices.GetByShipmentId(item.ShipmentId);
                            BoxInforEntity box = _boxInforServices.GetByBoxId(shipment.BoxId);
                            MasterAirwayBillEntity master = _masterBillServices.GetByMasterBillId(box.MasterBillId);
                            item.BoxIdRef = box.Id;
                            item.BoxIdString = box.BoxId;
                            item.MasterBillId = master.Id;
                            item.MasterBillIdString = master.MasterAirwayBill;
                            _shipmentOutServices.Create(item);
                        }
                        catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "Save shipmentout and delete _shipmentWaitConfirmedServices", ex); }
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
        private void btnSanLuongNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbMasterList.Text) || cbbMasterList.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã MAWB ở trên để làm báo cáo");
                return;
            }
            SanLuongNhapKho();
        }

        public void SanLuongNhapKho()
        {
            MasterAirwayBillEntity masterItem = (MasterAirwayBillEntity)cbbMasterList.SelectedItem;
            List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(masterItem.Id);
            string fileName = Environment.CurrentDirectory + @"\SanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW01";
            string headlineText = "TỔNG HỢP SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

                            + "VẬN ĐƠN CHỦ (MAWB): " + masterItem.MasterAirwayBill.ToUpper();
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
            paraFormat.Position = 11;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);
            int rowCount = listBox.Count;
            Table table = doc.AddTable(rowCount + 2, 3);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Mã Thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Tổng đơn hàng (Total HAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");

            table.Rows[1].Cells[0].Paragraphs.First().Append("Total").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[1].Paragraphs.First().Append(listBox.Count + "").Font(new FontFamily("Times New Roman"));
            int total = 0;
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows[i + 2].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[1].Paragraphs.First().Append(listBox[i].BoxId).Bold().Font(new FontFamily("Times New Roman"));
                int totalInBox = _shipmentServices.GetByBoxId(listBox[i].Id).Count();
                total += totalInBox;
                table.Rows[i + 2].Cells[2].Paragraphs.First().Append(totalInBox + "").Bold().Font(new FontFamily("Times New Roman"));
            }
            table.Rows[1].Cells[2].Paragraphs.First().Append(total + "").Font(new FontFamily("Times New Roman"));

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

        private void dtpNgayBaoCao_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayBaoCao.Value, cbbMasterList);
        }

        private void btnChiTietSanLuong_Click(object sender, EventArgs e)
        {
            ChiTietSanLuongNhapKho();
        }

        private void ChiTietSanLuongNhapKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateArrived(dtpNgayBaoCao.Value);
            int totalThung = 0;
            int totalShipment = 0;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null & listShipment.Count > 0)
                            {
                                foreach (var ship in listShipment)
                                {
                                    ReportDetailEntity entity = new ReportDetailEntity();
                                    entity.MasterId = item.MasterAirwayBill;
                                    entity.BoxId = box.BoxId;
                                    entity.ShipmentId = ship.ShipmentId;
                                    listDetail.Add(entity);
                                }
                                totalShipment += listShipment.Count;
                            }
                        }
                        totalThung += listBox.Count;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW02";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

                            + "TỔNG SỐ THÙNG: " + totalThung
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

        private void cbbMasterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMasterList.SelectedIndex > 0)
            {
                MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterList.SelectedItem;

                LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdReport);
                cbbBoxIdReport.SelectedIndex = 1;
            }
        }

        private void cbbBoxIdReport_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnChiTietTheoThung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbBoxIdReport.Text) || cbbBoxIdReport.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã thùng ở trên để làm báo cáo");
                return;
            }

            ChiTietSanLuongNhapKhoTheoThung();
        }

        private void ChiTietSanLuongNhapKhoTheoThung()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            BoxInforEntity boxSelected = (BoxInforEntity)cbbBoxIdReport.SelectedItem;

            int totalShipment = 0;

            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(boxSelected.Id);

            if (listShipment != null & listShipment.Count > 0)
            {
                foreach (var ship in listShipment)
                {
                    ReportDetailEntity entity = new ReportDetailEntity();
                    entity.MasterId = cbbMasterList.Text;
                    entity.BoxId = boxSelected.BoxId;
                    entity.ShipmentId = ship.ShipmentId;
                    listDetail.Add(entity);
                }
                totalShipment = listShipment.Count;
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKhoTheoThung" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW03";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

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

        private void btnChiTietXuatKho_Click(object sender, EventArgs e)
        {
            ChiTietSanLuongXuatKho();
        }

        private void ChiTietSanLuongXuatKho()
        {
            List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDate(dtpNgayXuatReport.Value);
            int totalThung = 0;
            int totalShipment;
            if (listDetail != null && listDetail.Count > 0)
            {
                totalShipment = listDetail.Count;
                totalThung = 1;
                int boxId = listDetail[0].BoxIdRef;
                for (int i = 1; i < totalShipment; i++)
                {
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

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tEMW01";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG XUẤT KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayXuatReport.Value.ToString("dd/MM/yyyy") + "\n"

                            + "TỔNG SỐ THÙNG: " + totalThung
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
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterBillIdString).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxIdString).Font(new FontFamily("Times New Roman"));
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

        private void btnSanLuongTonKho_Click(object sender, EventArgs e)
        {
            if (!ValidateFromToDate())
                return;

            TongHopSanLuongTonKho();
        }

        private void TongHopSanLuongTonKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            //get all MAWB in the duration
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            //get all shipment exported in the duration
            List<ShipmentOutEntity> listXuatKho = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            int totalThung = 0;
            int totalShipment = 0;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    //get all Box in this MAWB
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        //Count shipment on each box
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null && listShipment.Count > 0)
                            {
                                int totalShipmentInStock = 0;
                                foreach (var ship in listShipment)
                                {
                                    //Loc nhung ship da xuat trong khoang thoi gian da chon
                                    if (!listXuatKho.Any(t => t.ShipmentId.Equals(ship.ShipmentId, StringComparison.CurrentCultureIgnoreCase)))
                                    {
                                        totalShipmentInStock += 1;
                                    }
                                }
                                //update total shipment
                                totalShipment += totalShipmentInStock;
                                //Nếu các shipment trong box này còn tồn thì mới cho vào báo cáo
                                if (totalShipmentInStock > 0)
                                {
                                    ReportDetailEntity entity = new ReportDetailEntity();
                                    entity.MasterId = item.MasterAirwayBill;
                                    entity.BoxId = box.BoxId;
                                    entity.TotalShipment = totalShipmentInStock;
                                    listDetail.Add(entity);

                                    totalThung += 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\TongHopSanLuongTonKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIVT01";
            string headlineText = "TỔNG HỢP SẢN LƯỢNG TỒN KHO";
            string ngayDen = "TỪ NGÀY " + dtpFrom.Value.ToString("dd/MM/yyyy")

                            + "\tĐẾN NGÀY : " + dtpTo.Value.ToString("dd/MM/yyyy");

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

            Table table = doc.AddTable(listDetail.Count + 2, 4);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn tổng (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Tổng đơn hàng (Total HAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;

            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            table.Rows[1].Cells[0].Paragraphs.First().Append("Total").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[2].Paragraphs.First().Append(totalThung + "").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[3].Paragraphs.First().Append(totalShipment + "").Font(new FontFamily("Times New Roman"));

            int numberRow = listDetail.Count;
            for (int i = 0; i < numberRow; i++)
            {
                table.Rows[i + 2].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[2].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[3].Paragraphs.First().Append("" + listDetail[i].TotalShipment).Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            Paragraph title1 = doc.InsertParagraph(ngayDen, false, paraFormat);
            title1.Alignment = Alignment.center;
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }


        private void BangKeChiTietSanLuongTonKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            //get all MAWB in the duration
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            //get all shipment exported in the duration
            List<ShipmentOutEntity> listXuatKho = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            int totalThung = 0;
            int totalShipment = 0;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    //get all Box in this MAWB
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null && listShipment.Count > 0)
                            {
                                int totalShipmentInStock = 0;
                                foreach (var ship in listShipment)
                                {
                                    //Loc nhung ship da xuat trong khoang thoi gian da chon
                                    if (!listXuatKho.Any(t => t.ShipmentId == ship.ShipmentId))
                                    {
                                        ReportDetailEntity entity = new ReportDetailEntity();
                                        entity.MasterId = item.MasterAirwayBill;
                                        entity.BoxId = box.BoxId;
                                        entity.ShipmentId = ship.ShipmentId;
                                        listDetail.Add(entity);
                                        totalShipmentInStock += 1;
                                    }
                                }

                                if (totalShipmentInStock > 0)
                                {
                                    totalShipment += totalShipmentInStock;
                                    totalThung += 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\TongHopSanLuongTonKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIVT02";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG TỒN KHO";
            string ngayDen = "TỪ NGÀY " + dtpFrom.Value.ToString("dd/MM/yyyy")

                            + "\tĐẾN NGÀY : " + dtpTo.Value.ToString("dd/MM/yyyy")
                            + "\nTỔNG SỐ THÙNG: " + totalThung
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

            Table table = doc.AddTable(totalShipment + 1, 7);

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
            Paragraph title1 = doc.InsertParagraph(ngayDen, false, paraFormat);
            title1.Alignment = Alignment.center;
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }

        private void btnKeChiTietSanLuongTonKho_Click(object sender, EventArgs e)
        {
            if (!ValidateFromToDate())
                return;

            BangKeChiTietSanLuongTonKho();
        }

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!txtShipmentIdOut.Enabled)
            {
                LoadAllMasterBillByDateToCombobox(dtpNgayXuat.Value, cbbMasterBillOut);
            }
            else
            {
                MessageBox.Show("Bạn cần Đóng thùng đang làm việc lại rồi làm mới!");
            }
        }

        private void tabNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabNhap.SelectedIndex)
            {
                case 1:
                    xposX = lblXuatKho.Location.X;
                    yposX = lblXuatKho.Location.Y;
                    if (!txtShipmentIdOut.Enabled)
                    {
                        LoadAllMasterBillByDateToCombobox(dtpNgayXuat.Value, cbbMasterBillOut);
                    }
                    cbbMasterBillOut.Focus();
                    break;
                case 2:
                    LoadAllMasterBillByDateToCombobox(dtpNgayXuatReport.Value, cbbMasterList);
                    cbbMasterList.Focus();
                    break;
                case 3:
                    txtShipmentIdBlock.Focus();
                    break;
                default:
                    break;
            }
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

        private void txtSearchOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchOut.Text) && !string.IsNullOrEmpty(txtSearchOut.Text))
            {
                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
                {
                    if (IsExistsOnTheGridView(grvShipmentListOut, txtSearchOut.Text))
                    {
                        MessageBox.Show("Tìm thấy shipment vừa nhập đã có trên lưới", "Shipment trùng lặp");
                    }

                    var result = _shipmentServices.SearchByShipmentId(txtSearchOut.Text);
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy BoxId nào chứa Shipment vừa nhập!");
                    }
                    else
                    {
                        string boxId = result.BoxId == string.Empty ? cbbBoxIdOut.Text : result.BoxId;
                        MessageBox.Show("BoxId chứa Shipment vừa nhập là:\n\n" + boxId + "\nBoxId này sẽ được copy xuống ô text box tìm kiếm bên dưới!", "Tìm thấy BoxId");
                        txtSearchOut.Text = boxId;
                        //txtSearchOut.Focus();
                    }
                }
            }
        }

        #region Chờ thông quan
        private void txtShipmentIdBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShipmentIdBlock.Text) || String.IsNullOrWhiteSpace(txtShipmentIdBlock.Text))
                return;

            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (IsExistsOnTheGridView(grvShipmentsWaitConfirmed, txtShipmentIdBlock.Text))
                {
                    MessageBox.Show("Tìm thấy shipment vừa nhập đã có trên lưới", "Shipment trùng lặp");
                    return;
                }

                if (radConfirmed.Checked)
                {
                    if (!_shipmentServices.Exists(txtShipmentIdBlock.Text))
                    {
                        MessageBox.Show("Shipment này chưa được xác nhận đến nên không thể thêm", "Không thể thêm", MessageBoxButtons.OK);
                        return;
                    }

                    var entity = new ShipmentWaitConfirmedEntity();
                    entity.ShipmentId = txtShipmentIdBlock.Text;
                    entity.CreatedDate = DateTime.Now;
                    _shipmentWaitConfirmedServices.Create(entity);
                }

                grvShipmentsWaitConfirmed.Rows.Add(grvShipmentsWaitConfirmed.Rows.Count + 1, txtShipmentIdBlock.Text);
                grvShipmentsWaitConfirmed.ClearSelection();
                grvShipmentsWaitConfirmed.Rows[grvShipmentsWaitConfirmed.Rows.Count - 1].Selected = true;
                grvShipmentsWaitConfirmed.FirstDisplayedScrollingRowIndex = grvShipmentsWaitConfirmed.Rows.Count - 1;

                txtShipmentIdBlock.Text = String.Empty;
            }
        }

        private void grvShipmentsWaitConfirmed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowFromGridview(grvShipmentsWaitConfirmed, e, 3);
            ReIndexingRow(grvShipmentsWaitConfirmed);
        }

        private void LoadAllWaitConfirmedToGridview()
        {
            var listShip = _shipmentWaitConfirmedServices.GetAll();
            if (listShip != null && listShip.Count() > 0)
            {
                int i = 1;
                foreach (var item in listShip)
                {
                    grvShipmentsWaitConfirmed.Rows.Add(i, item.ShipmentId);
                    i++;
                }
            }
            //AddShipmentListToGrid()
        }
        #endregion

        private bool ValidateFromToDate()
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Giá trị từ ngày không được lớn hơn giá trị đến ngày!", "Chọn lại giá trị từ ngày");
                dtpFrom.Focus();
                return false;
            }

            return true;
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

        private void cbbMasterBillOut_Leave(object sender, EventArgs e)
        {
            cbbMasterBillOut.Text = cbbMasterBillOut.Text.ToUpper();
        }

        private void cbbBoxIdOut_Leave(object sender, EventArgs e)
        {
            cbbBoxIdOut.Text = cbbBoxIdOut.Text.ToUpper();
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
                //Xac nhan den
                if (xposX >= this.Width)
                {
                    this.lblXuatKho.Location = new System.Drawing.Point(0, yposX);
                    xposX = 0;
                }
                else
                {
                    this.lblXuatKho.Location = new System.Drawing.Point(xposX, yposX);
                    xposX += 8;
                }
            }
        }

        private void cbbMasterList_Leave(object sender, EventArgs e)
        {
            cbbMasterList.Text = cbbMasterList.Text.ToUpper();
        }

        private void cbbBoxIdReport_Leave(object sender, EventArgs e)
        {
            cbbBoxIdReport.Text = cbbBoxIdReport.Text.ToUpper();
        }
        #endregion

    }
}
