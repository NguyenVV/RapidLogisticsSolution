﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        public void ExcelExport<T>(List<T> items, String fileName, string nameReport)
        {
            DataTable data = ToDataTable(items);
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
                            writer.WriteExcelUnstyledCell("");
                        writer.WriteEndRow();

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

        /// <summary> 
        /// Exports the datagridview values to Excel. 
        /// </summary> 
        public void ExportToExcel<T>(List<T> items)
        {
            DataTable dgvCityDetails = ToDataTable(items);
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvCityDetails.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCityDetails.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Columns[j].Caption;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Rows[i][j].ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
