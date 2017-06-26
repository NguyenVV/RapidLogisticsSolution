using BusinessEntities;
using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        public void ShowHideButton()
        {
            if (FormLogin.mEmployee != null)
            {
                if (FormLogin.mEmployee.Role.Equals("Administrator"))
                {
                    btnManageEmployee.Visible = true;
                }
                else
                {
                    btnManageEmployee.Visible = false;
                }

                lblWelcome.Text = "Xin chào " + FormLogin.mEmployee.FullName + "!";
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormNhap>().Show();
            this.Dispose();
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormCreateEditEmployee>().Show();
            this.Dispose();
        }

        private void Logout()
        {
            this.Dispose();
            Program.Container.GetInstance<FormLogin>().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormChangePassword>().Show();
            this.Dispose();
        }
    }
}
