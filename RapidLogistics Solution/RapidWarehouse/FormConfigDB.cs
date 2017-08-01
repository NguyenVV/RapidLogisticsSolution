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

            this.Text = "Cấu Hình - " + FormUltils.getInstance().GetVersionInfo();
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
                _employeeServices.isConnection();
                //_employeeServices.RefreshConnection();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Kết nối đến CSDL thành công!";
            }
            catch (Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Application, "Test connection", ex);
                Ultilities.Security.SaveToRegedit(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Kết nối đến CSDL thất bại!";
                //if (MessageBox.Show("Kết nối đến CSDL thất bại, thử lại ngay bây giờ!", "Kết nối thất bại", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //{
                //    this.Dispose();
                //    Application.Restart();
                //}
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ultilities.Security.buildNewConnection(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
            Ultilities.Security.SaveToRegedit(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
            //_employeeServices.RefreshConnection();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Lưu cấu hình thành công!";
            this.Dispose();
            Application.Restart();
        }

        private void FormConfigDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Container.GetInstance<FormLogin>().Show();
            this.Dispose();
        }
    }
}
