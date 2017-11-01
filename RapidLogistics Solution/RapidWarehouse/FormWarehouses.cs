using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormWarehouses : Form
    {
        IWarehouseServices mWarehouseServices;
        WarehouseEntity warehouseCreateOrUpdate;
        List<WarehouseEntity> listAllWarehouse;
        public FormWarehouses(IWarehouseServices warehouseServices)
        {
            InitializeComponent();
            mWarehouseServices = warehouseServices;
            LoadAllWarehouseToListBox();
            this.Text = "Kho Hàng - " + FormUltils.getInstance().GetVersionInfo();
        }

        private void LoadAllWarehouseToListBox()
        {
            listAllWarehouse = mWarehouseServices.GetAll();

            lbListWarehouse.DataSource = listAllWarehouse;
            lbListWarehouse.DisplayMember = "Name";
            lbListWarehouse.ValueMember = "Id";
        }

        private void FillDataWarehouseToForm(WarehouseEntity warehouse)
        {
            txtAddress.Text = warehouse.Location;
            txtInfo.Text = warehouse.Description;
            txtName.Text = warehouse.Name;
            txtWarehouseCode.Text = warehouse.IdCode;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataInput())
            {
                // Create new
                if (warehouseCreateOrUpdate == null)
                {
                    if (IsExist(txtName.Text))
                    {
                        MessageBox.Show("Tên này đã tồn tại, vui lòng chọn tên khác!");
                        txtName.Focus();
                        return;
                    }

                    warehouseCreateOrUpdate = new WarehouseEntity();
                    warehouseCreateOrUpdate.Location = txtAddress.Text;
                    warehouseCreateOrUpdate.DateCreated = DateTime.Now;
                    warehouseCreateOrUpdate.Name = txtName.Text;
                    warehouseCreateOrUpdate.IdCode = txtWarehouseCode.Text;
                    warehouseCreateOrUpdate.Id = 0;
                    mWarehouseServices.CreateOrUpdate(warehouseCreateOrUpdate);
                    MessageBox.Show("Tạo kho hàng " + txtName.Text + " thành công !");
                }
                else
                {
                    // Update
                    warehouseCreateOrUpdate.Location = txtAddress.Text;
                    warehouseCreateOrUpdate.DateCreated = DateTime.Now;
                    warehouseCreateOrUpdate.Name = txtName.Text;
                    warehouseCreateOrUpdate.IdCode = txtWarehouseCode.Text;
                    mWarehouseServices.CreateOrUpdate(warehouseCreateOrUpdate);
                    MessageBox.Show("Cập nhật kho hàng " + txtName.Text + " thành công !");
                }

                warehouseCreateOrUpdate = null;
                LoadAllWarehouseToListBox();
            }
        }

        private bool IsExist(string name)
        {
            if (listAllWarehouse != null && listAllWarehouse.Count > 0)
            {
                return listAllWarehouse.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) && t.Name.Equals(FormLogin.mWarehouse.Name, StringComparison.CurrentCultureIgnoreCase));
            }

            return false;
        }
        private bool ValidateDataInput()
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập tên kho hàng từ 4 ký tự trở lên!");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ của kho hàng!");
                txtAddress.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void FormCreateEditEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void lbListWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            warehouseCreateOrUpdate = (WarehouseEntity)lbListWarehouse.SelectedItem;
            if (warehouseCreateOrUpdate != null)
            {
                FillDataWarehouseToForm(warehouseCreateOrUpdate);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            warehouseCreateOrUpdate = null;
            txtAddress.Text = "";
            txtName.Text = "";
            txtInfo.Text = "";
            txtWarehouseCode.Text = "";
            txtName.Focus();
        }
    }
}
