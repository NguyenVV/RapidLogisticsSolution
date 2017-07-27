using BusinessEntities;
using BusinessServices.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormLogin : Form
    {
        IEmployeeServices mEmployeeService;
        IWarehouseServices mWarehouseService;
        public static EmployeeEntity mEmployee;
        public static WarehouseEntity mWarehouse;

        public FormLogin(IEmployeeServices employeeServices, IWarehouseServices warehouseService)
        {
            InitializeComponent();
            mEmployeeService = employeeServices;
            mWarehouseService = warehouseService;
            CheckConnection();
            this.Text = "Đăng Nhập - " + FormUltils.getInstance().GetVersionInfo();
            lblVersion.Text = FormUltils.getInstance().GetVersionInfo();
        }

        private void CheckConnection()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RapidSolution");

            try
            {
                LoadAllWarehouses();
                lblError.Text = "Đã có kết nối, mời bạn đăng nhập!";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                if (key != null)
                {
                    Ultilities.Security.buildNewConnection(key.GetValue("DataSource").ToString(), key.GetValue("InitialCatalog").ToString(),
                        key.GetValue("UserID").ToString(), key.GetValue("Password").ToString());
                    this.Dispose();
                    Application.Restart();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Không có kết nối đến cơ sở dữ liệu, hãy cấu hình CSDL!";
                    //ShowDialogQuestionConnectToDb();
                }
            }
        }

        private void LoadAllWarehouses()
        {
            var list = mWarehouseService.GetAll();
            cbbWarehouse.DataSource = list;
            cbbWarehouse.DisplayMember = "Name";
            cbbWarehouse.ValueMember = "Id";
        }
        private void ShowDialogQuestionConnectToDb()
        {
            if (MessageBox.Show("Kết nối đến CSDL thất bại !\nBạn có muốn thiết lập bây giờ không ?", "Thiết lập thông tin cơ sở dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Program.Container.GetInstance<FormConfigDB>().Show();
            }

            lblError.Text = "Không có kết nối đến cơ sở dữ liệu!";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                try
                {
                    mEmployee = mEmployeeService.Login(txtUserName.Text, txtPassword.Text);
                    if (mEmployee != null)
                    {
                        lblError.Text = "";
                        if (mEmployee.Role == "Hải Quan")
                        {
                            Program.Container.GetInstance<FormHaiQuanView>().Show();
                        }
                        else
                        {
                            Program.Container.GetInstance<FormHome>().Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Bạn đã nhập sai User name hoặc Password, hãy thử lại!";
                    }
                }
                catch (Exception ex)
                {
                    Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "Đã có lỗi xảy ra khi đăng nhập, vui lòng thử lại sau", ex);
                    lblError.Text = "Đã có lỗi xảy ra khi đăng nhập, vui lòng thử lại sau!";
                    ShowDialogQuestionConnectToDb();
                }
            }
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập User Name từ 4 ký tự trở lên!", "Nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Vui lòng nhập Password từ 4 ký tự trở lên!", "Nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbWarehouse.Text) || cbbWarehouse.Text.Length < 4 || cbbWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn kho!", "Nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbWarehouse.Focus();
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
        private void lblConfigDb_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Container.GetInstance<FormConfigDB>().Show();
        }
        public List<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls).ToList();
        }

        private void cbbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbWarehouse.SelectedItem != null)
            {
                mWarehouse = (WarehouseEntity)cbbWarehouse.SelectedItem;
            }
        }
    }
}
