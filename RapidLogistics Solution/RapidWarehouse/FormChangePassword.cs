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
                MessageBox.Show("Nhập mật khẩu chưa hợp lệ, phải từ 4 ký tự");
                txtOldPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("Nhập mật khẩu chưa hợp lệ, phải từ 4 ký tự");
                txtNewPassword.Focus();
                return;
            }
            if (txtReenter.Text.Length < 4)
            {
                MessageBox.Show("Nhập mật khẩu chưa hợp lệ, phải từ 4 ký tự");
                txtReenter.Focus();
                return;
            }
            if (!txtReenter.Text.Equals(txtNewPassword.Text))
            {
                MessageBox.Show("Nhập mật khẩu mới và nhập lại mật khẩu mới chưa khớp nhau, hãy nhập lại");
                txtReenter.Focus();
                return;
            }

            if (mEmployeeService.Login(FormLogin.mEmployee.UserName, txtOldPassword.Text) == null)
            {
                MessageBox.Show("Nhập mật khẩu chưa đúng, hãy thử lại!");
                txtOldPassword.Focus();
                return;
            }
            
            mEmployeeService.ChangePassword(FormLogin.mEmployee, txtNewPassword.Text);

            EmployeeEntity employee = mEmployeeService.Login(FormLogin.mEmployee.UserName, txtNewPassword.Text);
            if (employee != null)
            {
                FormLogin.mEmployee = employee;
                MessageBox.Show("Đổi mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công, hãy thử lại!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            home.ShowHideButton();
            home.Show();
            this.Dispose();
        }

        private void FormChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHome home = new FormHome();
            home.ShowHideButton();
            home.Show();
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
