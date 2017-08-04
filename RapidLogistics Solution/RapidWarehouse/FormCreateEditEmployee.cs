using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ultilities;

namespace RapidWarehouse
{
    public partial class FormCreateEditEmployee : Form
    {
        IEmployeeServices mEmployeeService;
        EmployeeEntity employeeCreateOrUpdate;
        List<EmployeeEntity> listAllEmployee;
        public FormCreateEditEmployee(IEmployeeServices employeeServices)
        {
            InitializeComponent();
            mEmployeeService = employeeServices;
            LoadAllEmployeeToListBox();
            this.Text = "Quản lý người dùng - " + FormUltils.getInstance().GetVersionInfo();
        }

        private void LoadAllEmployeeToListBox()
        {
            listAllEmployee = mEmployeeService.GetAll();
            if (listAllEmployee != null && listAllEmployee.Count > 0)
            {
                listAllEmployee.Remove(FormLogin.mEmployee);
            }
            lbListEmployee.DataSource = listAllEmployee;
            lbListEmployee.DisplayMember = "UserName";
            lbListEmployee.ValueMember = "Id";
        }

        private void FillDataEmployeeToForm(EmployeeEntity employee)
        {
            txtAddress.Text = employee.Address;
            txtEmail.Text = employee.Email;
            txtFullName.Text = employee.FullName;
            txtPassword.Text = Security.Decrypt(employee.Pasword);
            txtPhone.Text = employee.Phone;
            txtUserName.Text = employee.UserName;
            dtpBirthDate.Value = employee.BirthDate;
            cbbRole.Text = employee.Role;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataInput())
            {
                // Create new
                if (employeeCreateOrUpdate == null)
                {
                    if (mEmployeeService.IsExist(txtUserName.Text))
                    {
                        MessageBox.Show("User Name này đã tồn tại, vui lòng chọn user name khác!");
                        txtUserName.Focus();
                        return;
                    }

                    employeeCreateOrUpdate.Id = 0;
                    employeeCreateOrUpdate = new EmployeeEntity();
                    employeeCreateOrUpdate.Address = txtAddress.Text;
                    employeeCreateOrUpdate.BirthDate = dtpBirthDate.Value;
                    employeeCreateOrUpdate.DateCreated = DateTime.Now;
                    employeeCreateOrUpdate.Email = txtEmail.Text;
                    employeeCreateOrUpdate.FullName = txtFullName.Text;
                    employeeCreateOrUpdate.Pasword = Security.Encrypt(txtPassword.Text);
                    employeeCreateOrUpdate.Phone = txtPhone.Text;
                    employeeCreateOrUpdate.Role = cbbRole.Text;
                    employeeCreateOrUpdate.Status = true;
                    employeeCreateOrUpdate.UserName = txtUserName.Text;
                    employeeCreateOrUpdate.WarehouseId = FormLogin.mWarehouse.Id;

                    if (mEmployeeService.CreateOrUpdateEmployee(employeeCreateOrUpdate) > 0)
                        MessageBox.Show("Tạo " + txtUserName.Text + " với role " + cbbRole.Text + " thành công !");
                    else
                        MessageBox.Show("Tạo user name "+ txtUserName.Text + " với role " + cbbRole.Text + " thất bại !");
                }
                else
                {
                    // Update
                    employeeCreateOrUpdate.Address = txtAddress.Text;
                    employeeCreateOrUpdate.BirthDate = dtpBirthDate.Value;
                    employeeCreateOrUpdate.DateCreated = DateTime.Now;
                    employeeCreateOrUpdate.Email = txtEmail.Text;
                    employeeCreateOrUpdate.FullName = txtFullName.Text;
                    employeeCreateOrUpdate.Pasword = Security.Encrypt(txtPassword.Text);
                    employeeCreateOrUpdate.Phone = txtPhone.Text;
                    employeeCreateOrUpdate.Role = cbbRole.Text;
                    employeeCreateOrUpdate.Status = true;
                    employeeCreateOrUpdate.UserName = txtUserName.Text;
                    employeeCreateOrUpdate.WarehouseId = FormLogin.mWarehouse.Id;
                    mEmployeeService.CreateOrUpdateEmployee(employeeCreateOrUpdate);
                    MessageBox.Show("Cập nhật " + cbbRole.Text + " thành công !");
                }
                
                employeeCreateOrUpdate = null;
                LoadAllEmployeeToListBox();
                txtUserName.Enabled = false;
            }
        }

        private bool ValidateDataInput()
        {
            if(string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập User Name từ 4 ký tự trở lên!");
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập Password từ 4 ký tự trở lên!");
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbRole.Text))
            {
                MessageBox.Show("Vui lòng chọn quyền cho user!");
                cbbRole.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFullName.Text) || txtFullName.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên từ 4 ký tự trở lên!");
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length < 10)
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại từ 10 ký tự trở lên!");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email!");
                txtEmail.Focus();
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

        private void lbListEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeCreateOrUpdate = (EmployeeEntity)lbListEmployee.SelectedItem;
            if (employeeCreateOrUpdate != null)
            {
                FillDataEmployeeToForm(employeeCreateOrUpdate);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            employeeCreateOrUpdate = null;
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtUserName.Text = "";
            txtUserName.Enabled = true;
            dtpBirthDate.Value = DateTime.Now;
            cbbRole.Text = "";
            txtUserName.Focus();
        }
    }
}
