using BusinessServices.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
                lblMessage.Text = "Kết nối đến CSDL thất bại, hãy thử lại!";
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //buildNewConnection(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
            Ultilities.Security.SaveToRegedit(txtServer.Text, txtDbName.Text, txtUserName.Text, txtPassword.Text);
            this.Dispose();
        }

    }
}
