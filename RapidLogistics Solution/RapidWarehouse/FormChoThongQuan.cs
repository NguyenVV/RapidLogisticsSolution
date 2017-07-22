using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormChoThongQuan : Form
    {
        int numberShipmentOut = 1;
        string currentMasterBill = String.Empty;
        string currentBoxId = String.Empty;
        EmployeeEntity currentEmployee;
        private int indexWaitConfirmedDeleted = 0;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IShipmentWaitToConfirmedServices _shipmentWaitConfirmedServices;
        private readonly IShipmentOutTempServices _shipmentOutTempServices;
        public FormChoThongQuan(IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IShipmentWaitToConfirmedServices shipmentWaitToConfirmedServices
            , IShipmentOutTempServices shipmentOutTempServices)
        {
            InitializeComponent();
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _shipmentWaitConfirmedServices = shipmentWaitToConfirmedServices;
            _shipmentOutTempServices = shipmentOutTempServices;
            currentEmployee = FormLogin.mEmployee;
            grvShipmentsWaitConfirmed.ColumnCount = 2;
            grvShipmentsWaitConfirmed.Columns[0].Name = "STT";
            grvShipmentsWaitConfirmed.Columns[0].ValueType = typeof(int);
            grvShipmentsWaitConfirmed.Columns[0].ReadOnly = true;
            grvShipmentsWaitConfirmed.Columns[1].Name = "Shipment Id";
            grvShipmentsWaitConfirmed.Columns[1].ReadOnly = true;

            AddCheckBoxToGridView(grvShipmentsWaitConfirmed);
            AddDeleteButtonToGridView(grvShipmentsWaitConfirmed);
            LoadAllWaitConfirmedToGridview();

            grvShipmentsWaitConfirmed.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvShipmentsWaitConfirmed.ReadOnly = false;

            this.Text = "Hàng chờ thông quan - " + FormUltils.getInstance().GetVersionInfo();
        }


        #region Dùng chung

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
        #endregion

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

                var entity = new ShipmentWaitConfirmedEntity();
                entity.ShipmentId = txtShipmentIdBlock.Text;
                entity.CreatedDate = DateTime.Now;
                entity.EmployeeId = FormLogin.mEmployee.Id;
                _shipmentWaitConfirmedServices.Create(entity);

                grvShipmentsWaitConfirmed.Rows.Add(grvShipmentsWaitConfirmed.Rows.Count + 1, txtShipmentIdBlock.Text);
                grvShipmentsWaitConfirmed.ClearSelection();
                grvShipmentsWaitConfirmed.Rows[grvShipmentsWaitConfirmed.Rows.Count - 1].Selected = true;
                grvShipmentsWaitConfirmed.FirstDisplayedScrollingRowIndex = grvShipmentsWaitConfirmed.Rows.Count - 1;

                txtShipmentIdBlock.Text = String.Empty;
            }
        }

        private void ConfirmListShipment()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn giữ lại những Shipment đã chọn và Xuất Kho những cái không chọn không ?", "Xuất kho shipment chờ thông quan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (grvShipmentsWaitConfirmed != null && grvShipmentsWaitConfirmed.Rows.Count > 0)
                {
                    List<ShipmentOutEntity> listXuat = new List<ShipmentOutEntity>();
                    List<string> listShipmentId = new List<string>();
                    List<DataGridViewRow> rowDeletedList = new List<DataGridViewRow>();
                    try
                    {
                        foreach (DataGridViewRow row in grvShipmentsWaitConfirmed.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["dataGridViewCheckBox"].Value) == false)
                            {
                                ShipmentOutEntity item = new ShipmentOutEntity();

                                item.ShipmentId = row.Cells["Shipment Id"].Value.ToString();
                                string[] shipmentRefs = _shipmentServices.GetReferenceOfShipment(item.ShipmentId);
                                if (shipmentRefs != null)
                                {
                                    item.BoxIdRef = int.Parse(shipmentRefs[2]);
                                    item.BoxIdString = shipmentRefs[3];
                                    item.MasterBillId = int.Parse(shipmentRefs[4]);
                                    item.MasterBillIdString = shipmentRefs[5];
                                    item.DateCreated = DateTime.Now;
                                    item.EmployeeId = currentEmployee.Id;
                                    item.DateOut = DateTime.Now;
                                    listXuat.Add(item);
                                    listShipmentId.Add(item.ShipmentId);
                                    rowDeletedList.Add(row);
                                }
                            }
                        }

                        if (rowDeletedList.Count > 0)
                        {
                            _shipmentOutServices.Create(listXuat);
                            _shipmentWaitConfirmedServices.Delete(listShipmentId);
                            MessageBox.Show("Xuất Kho thành công " + listXuat.Count + " shipment", "Xuất kho shipment chờ thông quan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (var row in rowDeletedList)
                            {
                                grvShipmentsWaitConfirmed.Rows.Remove(row);
                            }
                            ReIndexingRow(grvShipmentsWaitConfirmed);
                        }
                        else
                        {
                            MessageBox.Show("Bạn đã giữ lại tất cả mà không xuất kho shipment nào cả, hãy thử lại !", "Xuất kho shipment chờ thông quan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất Kho bị lỗi, vui lòng thử lại", "Xuất kho shipment chờ thông quan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "Save shipmentout and delete _shipmentWaitConfirmedServices", ex);
                    }
                }
            }
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

        #region Events buttons


        private void FormChoThongQuan_FormClosed(object sender, FormClosedEventArgs e)
        {
            GoHome();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void GoHome()
        {
            var home = new FormHome();
            home.ShowHideButton();
            home.Show();
            this.Dispose();
        }
        private void btnXuatKhoConfirmed_Click(object sender, EventArgs e)
        {
            ConfirmListShipment();
        }

        #endregion

        private void grvShipmentsWaitConfirmed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowFromGridview(grvShipmentsWaitConfirmed, e, 3);
            numberShipmentOut--;
            ReIndexingRow(grvShipmentsWaitConfirmed);
        }
        private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType=3)
        {
            //if click is on new row or header row
            if (e.RowIndex == grv.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == grv.Columns["dataGridViewDeleteButton"].Index)
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa đơn hàng : " + grv.Rows[e.RowIndex].Cells["Shipment Id"].Value + " khỏi danh sách chờ thông quan", "Xóa đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                try
                {
                    if (grvType == 3)
                    {
                        _shipmentWaitConfirmedServices.Delete(grv.Rows[e.RowIndex].Cells["Shipment Id"].Value.ToString());
                    }
                }
                catch (Exception ex) { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "private void DeleteRowFromGridview(DataGridView grv, DataGridViewCellEventArgs e, int grvType)", ex); }

                grv.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
