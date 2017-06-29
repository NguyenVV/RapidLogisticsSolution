using BusinessEntities;
using BusinessServices.Interfaces;
using Microsoft.Win32;
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
            OpenConnection();
        }
        
        private void OpenConnection()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RapidSolution");
            if (key != null)
            {
                Ultilities.Security.buildNewConnection(key.GetValue("DataSource").ToString(), key.GetValue("InitialCatalog").ToString(),
                    key.GetValue("UserID").ToString(), key.GetValue("Password").ToString());
            }
            else
            {
                if (MessageBox.Show("Bạn chưa có thiết lập thông tin cơ sở dữ liệu, bạn có muốn thiết lập bây giờ không ?", "Thiết lập thông tin cơ sở dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.Container.GetInstance<FormConfigDB>().Show();
                }
            }
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
                    try
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
                    }catch(Exception ex)
                    {
                        Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "Đã có lỗi xảy ra khi đăng nhập, vui lòng thử lại sau", ex);
                        lblError.Text = "Đã có lỗi xảy ra khi đăng nhập, vui lòng thử lại sau!";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblConfigDb_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormConfigDB>().Show();
        }
    }
}
