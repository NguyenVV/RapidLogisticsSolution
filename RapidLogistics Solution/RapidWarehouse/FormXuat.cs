using BusinessEntities;
using BusinessServices.Interfaces;
using Novacode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormXuat : Form
    {
        int numberShipmentOut = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        int currentMasterBillId, currentBoxIdInt;
        bool nhapMoiKhongCanXacNhan;
        BoxInforEntity currentBoxOut;
        MasterAirwayBillEntity currentMasterOut;
        EmployeeEntity currentEmployee;
        private int indexWaitConfirmedDeleted = 0;
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IShipmentWaitToConfirmedServices _shipmentWaitConfirmedServices;
        private readonly IShipmentOutTempServices _shipmentOutTempServices;
        public FormXuat(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IShipmentWaitToConfirmedServices shipmentWaitToConfirmedServices
            , IShipmentOutTempServices shipmentOutTempServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _shipmentWaitConfirmedServices = shipmentWaitToConfirmedServices;
            _shipmentOutTempServices = shipmentOutTempServices;
            currentEmployee = FormLogin.mEmployee;
            grvShipmentListOut.ColumnCount = 2;
            grvShipmentListOut.Columns[0].Name = "STT";
            grvShipmentListOut.Columns[0].ValueType = typeof(int);
            grvShipmentListOut.Columns[1].Name = "Shipment Id";
            
            AddDeleteButtonToGridView(grvShipmentListOut);
            
            dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            grvShipmentListOut.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ResetHardCodeText();
            LoadAllMasterBillByDateToCombobox(DateTime.Today, cbbMasterBillOut);
            FillInforOut();
            CloseBoxOut();
            dtpNgayXuat.Focus();
        }
        
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
                _shipmentOutTempServices.DeleteByEmployeeId(currentEmployee.Id);
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
            if (cbbMasterBillOut.SelectedIndex >= 0)
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
                if (CheckBoxIdProcessingByAnother(item.Id))
                {
                    return;
                }

                lblBoxIdOut.Text = item.BoxId;
                //LoadShipmentsByBoxId(item, grvShipmentListOut);
                //lblShipmentScanedOut.Text = (grvShipmentListOut.Rows.Count).ToString();
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
            var shipmentOut = _shipmentOutTempServices.GetByBoxId(boxId);
            if (shipmentOut != null && shipmentOut.First().EmployeeId != currentEmployee.Id)
            {
                MessageBox.Show("Mã thùng này đang được xử lý bởi người khác, vui lòng chọn mã thùng khác! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
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

                    currentBoxOut = new BoxInforEntity
                    {
                        BoxId = cbbBoxIdOut.Text,
                        ShipmentQuantity = 0,
                        MasterBillId = currentMasterBillId,
                        EmployeeId = currentEmployee.Id,
                        DateCreated = DateTime.Now
                    };
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

                    if (CheckBoxIdProcessingByAnother(currentBoxOut.Id))
                    {
                        return;
                    }
                }
                var box = _boxInforServices.GetByBoxId(cbbBoxIdOut.Text);
                if (!LoadShipmentsByBoxId(box, grvShipmentListOut))
                    return;

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

                if (IsExistsOnTheGridView(grvShipmentListOut, txtShipmentIdOut.Text))
                {
                    MessageBox.Show("Tìm thấy đơn hàng vừa nhập đã có trên lưới", "Đơn hàng trùng lặp");
                    txtShipmentIdOut.Text = String.Empty;
                    return;
                }

                if (_shipmentWaitConfirmedServices.IsExist(txtShipmentIdOut.Text))
                {
                    Beep(1000, 1000);
                    Beep(1000, 1000);
                    Beep(1000, 1000);
                    var result = MessageBox.Show("Mã đơn hàng vừa nhập " + txtShipmentIdOut.Text + " đã có trên danh sách chờ thông quan\nBạn có muốn xuất kho đơn hàng này luôn không ?", "Đơn hàng chờ thông quan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            ////xóa trên gridview
                            //grvShipmentsWaitConfirmed.Rows.RemoveAt(indexWaitConfirmedDeleted);
                            //xóa trong db
                            _shipmentWaitConfirmedServices.Delete(txtShipmentIdOut.Text);
                        }
                        catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "Save shipmentout and delete _shipmentWaitConfirmedServices", ex); }

                    }
                    else
                    {
                        txtShipmentIdOut.Text = String.Empty;
                        return;
                    }
                }

                //Check chưa có trong bảng ShipmentInfor thì thêm mới vào trong trường hợp xuất không cần xác nhận
                if (_shipmentServices.GetByShipmentIdAndBoxId(txtShipmentIdOut.Text, currentBoxOut.Id) == null)
                {
                    if (!nhapMoiKhongCanXacNhan)
                    {
                        MessageBox.Show("Mã đơn hàng vừa nhập hiện không có trong kho hoặc trong mã thùng này\n nên không thể xuất kho", "Nhập thông tin", MessageBoxButtons.OK);
                        txtShipmentIdOut.Text = String.Empty;
                        return;
                    }

                    ShipmentEntity shipment = new ShipmentEntity
                    {
                        ShipmentId = txtShipmentIdOut.Text,
                        BoxId = currentBoxOut.Id,
                        EmployeeId = currentEmployee.Id,
                        DateCreated = DateTime.Now
                    };

                    try
                    {
                        shipment.Id = _shipmentServices.Create(shipment);
                    }
                    catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void txtShipmentIdOut_KeyDown(object sender, KeyEventArgs e)", ex); }
                }

                if (_shipmentOutServices.IsExist(txtShipmentIdOut.Text))
                {
                    MessageBox.Show("Mã đơn hàng vừa nhập đã được xuất rồi\n nên không thể xuất kho", "Nhập thông tin", MessageBoxButtons.OK);
                    txtShipmentIdOut.Text = String.Empty;
                    return;
                }

                grvShipmentListOut.Rows.Add(grvShipmentListOut.Rows.Count + 1, txtShipmentIdOut.Text);
                lblShipmentScanedOut.Text = "" + grvShipmentListOut.Rows.Count;
                numberShipmentOut++;
                grvShipmentListOut.ClearSelection();
                grvShipmentListOut.Rows[grvShipmentListOut.Rows.Count - 1].Selected = true;
                grvShipmentListOut.FirstDisplayedScrollingRowIndex = grvShipmentListOut.Rows.Count - 1;

                // Create object temp
                ShipmentOutEntity shipmentOut = new ShipmentOutEntity();
                shipmentOut.ShipmentId = txtShipmentIdOut.Text;
                shipmentOut.BoxIdRef = currentBoxOut.Id;
                shipmentOut.BoxIdString = currentBoxOut.BoxId;
                shipmentOut.MasterBillId = currentMasterOut.Id;
                shipmentOut.MasterBillIdString = currentMasterOut.MasterAirwayBill;
                shipmentOut.DateOut = dtpNgayXuat.Value;
                shipmentOut.DateCreated = DateTime.Now;
                shipmentOut.EmployeeId = currentEmployee.Id;
                _shipmentOutTempServices.Create(shipmentOut);
                // Clear text box after process
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
            
            List<MasterAirwayBillEntity> masterBillList = _shipmentOutServices.GetAllMasterBillByDate(date).ToList();
            //List<ShipmentOutEntity> listOut = (List < ShipmentOutEntity > )_shipmentOutServices.GetByDate(dtpNgayXuat.Value);
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbMaster.DataSource = masterBillList;
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
        
        private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)
        {
            //if click is on new row or header row
            if (e.RowIndex == grv.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == grv.Columns["dataGridViewDeleteButton"].Index)
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa đơn hàng : " + grv.Rows[e.RowIndex].Cells["Shipment Id"].Value, "Xóa đơn hàng", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

                try
                {
                    if (grvType == 2)
                    {
                        _shipmentOutServices.Delete(grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString());
                        lblShipmentScanedOut.Text = (grv.Rows.Count - 1) + "";
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
        private bool LoadShipmentsByBoxId(BoxInforEntity boxEntity, DataGridView shipmentGrid)
        {
            if (boxEntity == null)
            {
                shipmentGrid.DataSource = null;
                //shipmentGrid.Rows.Clear();
                return false;
            }

            List<ShipmentOutEntity> listShipment = (List<ShipmentOutEntity>)_shipmentOutServices.GetByBoxId(boxEntity.Id);
            List<ShipmentOutEntity> listShipmentOutTemp = (List<ShipmentOutEntity>)_shipmentOutTempServices.GetByBoxId(boxEntity.Id);
            string text = "Bạn có chắc chắn muốn xử lý mã thùng là " + boxEntity.BoxId;

            if (listShipment!=null && listShipment.Count > 0)
            {
                text += "\nvới tổng số đơn hàng đã xuất kho là " + listShipment.Count;
            }
            text += " không ?";
            if (MessageBox.Show(text, "Chọn xử lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (listShipmentOutTemp != null)
                {
                    var result = MessageBox.Show("Có " + listShipmentOutTemp.Count + " đơn hàng chưa lưu ở phiên làm việc trước, bạn có muốn tiếp tục xử lý hay không ?", "Load đơn hàng chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        listShipment.AddRange(listShipmentOutTemp);
                    }
                    else
                    {
                        _shipmentOutTempServices.DeleteByEmployeeId(currentEmployee.Id);
                    }
                }

                if (listShipment != null)
                {
                    AddShipmentListToGrid(listShipment, shipmentGrid);
                }

                return true;
            }
            else
            {
                shipmentGrid.DataSource = null;
                //shipmentGrid.Rows.Clear();
                return false;
            }
        }
        private void LoadBoxIdListFromMasterBillId(int masterBillId, ComboBox cbbBoxes)
        {
            if (masterBillId <= 0)
                return;
            
            List<BoxInforEntity> listBoxInfo = _shipmentOutServices.GetAllBoxByMasterBill(masterBillId).ToList();
            if (listBoxInfo != null && listBoxInfo.Count > 0)
            {
                cbbBoxes.DataSource = listBoxInfo;
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

        #region Events buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GoHome();
        }
        private void GoHome()
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
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

        private void ClickKeyTab(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbbMasterBillOut_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }

        private void cbbBoxIdOut_KeyDown(object sender, KeyEventArgs e)
        {
            ClickKeyTab(e);
        }
        private void dtpNgayXuat_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayXuat.Value, cbbMasterBillOut);
            lblNgayXuat.Text = dtpNgayXuat.Value.ToString("dd/MM/yyyy");
        }

        private void txtSearchOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchOut.Text) && !string.IsNullOrEmpty(txtSearchOut.Text))
            {
                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
                {
                    if (IsExistsOnTheGridView(grvShipmentListOut, txtSearchOut.Text))
                    {
                        MessageBox.Show("Tìm thấy đơn hàng vừa nhập đã có trên lưới", "Đơn hàng trùng lặp");
                    }

                    var result = _shipmentServices.SearchByShipmentId(txtSearchOut.Text);
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy Thùng nào chứa đơn hàng vừa nhập!");
                    }
                    else
                    {
                        string boxId = result.BoxId == string.Empty ? cbbBoxIdOut.Text : result.BoxId;
                        MessageBox.Show("Thùng chứa đơn hàng vừa nhập là:\n\n" + boxId + "\nMã thùng này sẽ được copy xuống ô text box tìm kiếm bên dưới!", "Tìm thấy mã thùng");
                        txtSearchOut.Text = boxId;
                        //txtSearchOut.Focus();
                    }
                }
            }
        }

        private void cbbMasterBillOut_Leave(object sender, EventArgs e)
        {
            cbbMasterBillOut.Text = cbbMasterBillOut.Text.ToUpper();
        }

        private void cbbBoxIdOut_Leave(object sender, EventArgs e)
        {
            cbbBoxIdOut.Text = cbbBoxIdOut.Text.ToUpper();
        }

        private void FormXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            GoHome();
        }
 
        private void txtSearchOut_Enter(object sender, EventArgs e)
        {
            if (txtSearchOut.Text.Equals("NHẬP MÃ ĐỂ TÌM KIẾM"))
            {
                txtSearchOut.Text = "";
            }
        }

        private void txtSearchOut_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchOut.Text) || string.IsNullOrWhiteSpace(txtSearchOut.Text))
            {
                txtSearchOut.Text = "NHẬP MÃ ĐỂ TÌM KIẾM";
            }
        }

        #endregion

        #region In báo cáo

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ChiTietSanLuongXuatKho();
        }
        private void ChiTietSanLuongXuatKho()
        {
            BoxInforEntity box = (BoxInforEntity)cbbBoxIdOut.SelectedItem;
            if (box == null)
            {
                MessageBox.Show("Chọn mã thùng để in báo cáo!", "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByBoxId(box.Id);
            int totalThung = 0;
            int totalShipment;
            if (listDetail != null && listDetail.Count > 0)
            {
                totalShipment = listDetail.Count;
            }
            else
            {
                MessageBox.Show("Chưa có đơn hàng của mã thùng này nào được xuất kho!","Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tEMW01";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG XUẤT KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayXuat.Value.ToString("dd/MM/yyyy") + "\n"

                            + "MÃ SỐ THÙNG: " + box.BoxId
                            + "\t\t\tTỔNG ĐƠN HÀNG: " + totalShipment;
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

        #endregion
    }
}
