using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormChangePassword : Form
    {
        IEmployeeServices mEmployeeService;
        public FormChangePassword(IEmployeeServices employeeServices)
        {
            InitializeComponent();
            mEmployeeService = employeeServices;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtOldPassword.Text.Length < 4)
            {
                MessageBox.Show("Nhập password chưa hợp lệ, phải từ 4 ký tự");
                txtOldPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("Nhập password chưa hợp lệ, phải từ 4 ký tự");
                txtNewPassword.Focus();
                return;
            }
            if (txtReenter.Text.Length < 4)
            {
                MessageBox.Show("Nhập password chưa hợp lệ, phải từ 4 ký tự");
                txtReenter.Focus();
                return;
            }

            if(mEmployeeService.Login(FormLogin.mEmployee.UserName, txtOldPassword.Text) == null)
            {
                MessageBox.Show("Nhập password chưa hợp đúng, hãy thử lại!");
                txtOldPassword.Focus();
                return;
            }
            
            mEmployeeService.ChangePassword(FormLogin.mEmployee, txtNewPassword.Text);

            EmployeeEntity employee = mEmployeeService.Login(FormLogin.mEmployee.UserName, txtNewPassword.Text);
            if (employee != null)
            {
                FormLogin.mEmployee = employee;
                MessageBox.Show("Đổi password thành công!");
            }
            else
            {
                MessageBox.Show("Đổi password không thành công, hãy thử lại!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            home.Show();
            this.Dispose();
        }
    }
}
