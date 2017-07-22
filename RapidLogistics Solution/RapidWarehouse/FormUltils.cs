using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public class FormUltils
    {
        private static FormUltils utils;

        public static FormUltils getInstance()
        {
            if(utils == null)
            {
                utils = new FormUltils();
            }

            return utils;
        }

        public void GobackHome(System.Windows.Forms.Form form)
        {
            Program.Container.GetInstance<FormHome>().Show();
            form.Dispose();
        }

        public string GetFormText()
        {
            return string.Format("Kho hàng {0} - {1}", FormLogin.mWarehouse.Name, GetVersionInfo());
        }

        public string GetVersionInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion==null ?"1.0.0.0": fvi.FileVersion;

            return "Rapid Warehouse v" + version;
        }

        public void ExcelExport(DataTable data, String fileName, bool openAfter)
        {
            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;

            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (ExcelWriter writer = new ExcelWriter(fileName))
                    {
                        writer.WriteStartDocument();

                        // Write the worksheet contents
                        writer.WriteStartWorksheet("Sheet1");

                        //Write header row
                        writer.WriteStartRow();
                        foreach (DataColumn col in data.Columns)
                            writer.WriteExcelUnstyledCell(col.Caption);
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in data.Rows)
                        {
                            writer.WriteStartRow();
                            foreach (object o in row.ItemArray)
                            {
                                writer.WriteExcelAutoStyledCell(o);
                            }
                            writer.WriteEndRow();
                        }

                        // Close up the document
                        writer.WriteEndWorksheet();
                        writer.WriteEndDocument();
                        writer.Close();
                        //if (openAfter)
                        //    OpenFileDialog.OpenFile(fileName);
                        retry = DialogResult.Cancel;
                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
