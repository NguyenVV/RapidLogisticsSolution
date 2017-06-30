using System;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            timerMinute.Start();
            lblTime.Text = DateTime.Now.ToString("HH:mm");
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
                lblDate.Text = string.Format("{0}, ngày {1} tháng {2} năm {3}", getTodayVietNamese(DateTime.Today.DayOfWeek),DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
                lblWelcome.Text = "Xin chào " + FormLogin.mEmployee.FullName + "!";
            }
        }
        private string getTodayVietNamese(DayOfWeek dayweek)
        {
            switch (dayweek)
            {
                case DayOfWeek.Sunday:
                    return "Chủ nhật";
                case DayOfWeek.Monday:
                    return "Thứ hai";
                case DayOfWeek.Tuesday:
                    return "Thứ ba";
                case DayOfWeek.Wednesday:
                    return "Thứ tư";
                case DayOfWeek.Thursday:
                    return "Thứ năm";
                case DayOfWeek.Friday:
                    return "Thứ sáu";
                default:
                    return "Thứ bẩy";
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

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void btnExportInventory_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormXuat>().Show();
            this.Dispose();
        }

        private void btnWaitToConfirm_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormChoThongQuan>().Show();
            this.Dispose();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormBaoCao>().Show();
            this.Dispose();
        }
    }
}
