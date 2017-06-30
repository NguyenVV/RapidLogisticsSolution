using BusinessServices.Interfaces;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormConfigDB : Form
    {
        private readonly IEmployeeServices _employeeServices;
        public FormConfigDB(IEmployeeServices employeeServices)
        {
            InitializeComponent();
            this._employeeServices = employeeServices;
            lblMessage.Text = "";
            FillInfo();
        }

        private void FillInfo()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RapidSolution");
            if (key != null)
            {
                txtServer.Text = key.GetValue("DataSource").ToString();
                txtDbName.Text = key.GetValue("InitialCatalog").ToString();
                txtUserName.Text = key.GetValue("UserID").ToString();
                txtPassword.Text = key.GetValue("Password").ToString();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Ultilities.Security.buildNewConnection(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
                _employeeServices.GetAll();
                lblMessage.Text = "Kết nối đến CSDL thành công!";
            }
            catch(Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Application, "Test connection", ex);
                MessageBox.Show("Kết nối đến CSDL thất bại, thử lại ngay bây giờ!", "Kết nối thất bại",MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ultilities.Security.SaveToRegedit(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
            Application.Restart();
        }
    }
}
