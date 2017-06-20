using BusinessEntities;
using BusinessServices.Interfaces;
using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormLogin : Form
    {
        IEmployeeServices mEmployeeService;
        public static EmployeeEntity mEmployee;
        
        public FormLogin(IEmployeeServices employeeServices)
        {
            InitializeComponent();
            mEmployeeService = employeeServices;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                FormHome home = new FormHome();
                if (txtUserName.Text.Equals("Administrator", StringComparison.CurrentCultureIgnoreCase)
                    && txtPassword.Text.Equals("Pass@word"))
                {
                    lblError.Text = "";
                    mEmployee = new EmployeeEntity();
                    mEmployee.Role = "Administrator";
                    home.ShowHideButton();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    mEmployee = mEmployeeService.Login(txtUserName.Text, txtPassword.Text);
                    if (mEmployee != null)
                    {
                        lblError.Text = "";
                        home.Show();
                        home.ShowHideButton();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Bạn đã nhập sai User name hoặc Password, hãy thử lại!";
                    }
                }
            }
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length < 4)
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

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
