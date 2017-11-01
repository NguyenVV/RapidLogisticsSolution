using BusinessServices.Interfaces;
using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ////Dim admin_token As IntPtr
            //WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            //WindowsIdentity wid_admin = null;
            //WindowsImpersonationContext wic = null;
            //try
            //{
            //    SystemInfo sysInfo = new SystemInfo();
            //    string str = "";
            //    int index = 0;
            //    string PathSource = "";
            //    string PathDest = Application.StartupPath + "\\";
            //    //debug\

            //    XmlDocument m_xmld = default(XmlDocument);
            //    XmlNodeList m_nodelist = default(XmlNodeList);
            //    string pathXml = Application.StartupPath + "\\config.xml";

            //    m_xmld = new XmlDocument();
            //    //Load the Xml file

            //    m_xmld.Load(pathXml);
            //    //Get the list of name nodes 

            //    m_nodelist = m_xmld.SelectNodes("/configuration");



            //    XmlNodeList node_ServerUpdateCode = default(XmlNodeList);
            //    XmlNodeList node_UserUpdateCode = default(XmlNodeList);
            //    XmlNodeList node_PassUpdateCode = default(XmlNodeList);
            //    //Dim node_FolderUpdateCode As XmlNodeList
            //    XmlElement root = m_xmld.DocumentElement;
            //    node_ServerUpdateCode = root.GetElementsByTagName("ServerUpdateCode");
            //    node_UserUpdateCode = root.GetElementsByTagName("UserUpdateCode");
            //    node_PassUpdateCode = root.GetElementsByTagName("PassUpdateCode");
            //    //node_FolderUpdateCode = root.GetElementsByTagName("FolderUpdateCode")

            //    if (node_ServerUpdateCode(0).ChildNodes.Count > 0)
            //    {
            //        sysInfo.ServerUpdateCode = node_ServerUpdateCode(0).ChildNodes.Item(0).InnerText;
            //        //ip c?a server d?t file Update version
            //        sysInfo.ServerUpdateCode = EncryptionUtility.DecryptString(sysInfo.ServerUpdateCode, publicKey);
            //    }
            //    else
            //    {
            //        sysInfo.ServerUpdateCode = "";
            //    }
            //    if (node_UserUpdateCode(0).ChildNodes.Count > 0)
            //    {
            //        sysInfo.UserUpdateCode = node_UserUpdateCode(0).ChildNodes.Item(0).InnerText;
            //        //User log in vao server Update version
            //        sysInfo.UserUpdateCode = EncryptionUtility.DecryptString(sysInfo.UserUpdateCode, publicKey);
            //    }
            //    else
            //    {
            //        sysInfo.UserUpdateCode = "";
            //    }
            //    if (node_PassUpdateCode(0).ChildNodes.Count > 0)
            //    {
            //        sysInfo.PassUpdateCode = node_PassUpdateCode(0).ChildNodes.Item(0).InnerText;
            //        //Pass log in vao server Update Version
            //        sysInfo.PassUpdateCode = EncryptionUtility.DecryptString(sysInfo.PassUpdateCode, publicKey);
            //    }
            //    else
            //    {
            //        sysInfo.PassUpdateCode = "";
            //    }
            //    //If node_FolderUpdateCode(0).ChildNodes.Count > 0 Then
            //    // sysInfo.FolderUpdateCode = node_FolderUpdateCode(0).ChildNodes.Item(0).InnerText 'Folder ch?a file update version(\UpdateVersion\)
            //    // sysInfo.FolderUpdateCode = EncryptionUtility.DecryptString(sysInfo.FolderUpdateCode, publicKey)
            //    //Else
            //    // sysInfo.FolderUpdateCode = ""
            //    //End If

            //    string fileName = "";

            //    for (int i = 1; i <= 3; i++)
            //    {
            //        switch (i)
            //        {
            //            case 1:
            //                fileName = "BSM.xml";
            //                break;
            //            case 2:
            //                fileName = "BSM.exe";
            //                break;
            //            case 3:
            //                fileName = "BSM.pdb";
            //                break;
            //                //Case 4
            //                // fileName = "BSM.xml"
            //                //Case 5
            //                // fileName = "BSM.exe.config"
            //                //Case 6
            //                // fileName = "BSM.vshost.exe.config"
            //        }

            //        if (!System.IO.Directory.Exists(PathDest))
            //        {
            //            System.IO.Directory.CreateDirectory(PathDest);
            //        }
            //        this.Download(sysInfo.ServerUpdateCode, PathDest, fileName, sysInfo.UserUpdateCode, sysInfo.PassUpdateCode);

            //    }

            //    MessageBox.Show("Update Thành Công!");

            //    fileName = Application.StartupPath + "\\BSM.exe";
            //    System.Diagnostics.Process.Start(fileName);
            //    this.Close();
            //}
            //catch (System.Exception se)
            //{
            //    MessageBox.Show(se.ToString());
            //    MessageBox.Show("L?i Update Version!");
            //}
            //finally
            //{
            //    if (wic != null)
            //    {
            //        wic.Undo();
            //    }
            //}
        }
        private void Download(string ftpUri, string filePath, string fileName, string UserLogin, string PassLogin)
        {
            //FTPSettings.IP = "DOMAIN NAME"
            //FTPSettings.UserID = "USER ID"
            //FTPSettings.Password = "PASSWORD"
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUri + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(UserLogin, PassLogin);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount = 0;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                    ftpStream.Dispose();
                }
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
