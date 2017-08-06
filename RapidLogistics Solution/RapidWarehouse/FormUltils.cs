using System;
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
        /// Exports the DataTable values to Excel. 
        /// </summary> 
        public void ExportToExcel(DataTable tableData, string fileName, string reportName, string reportCode, Dictionary<string,string> first, Dictionary<string, string> second)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            excel.StandardFont = "Times New Roman";
            excel.StandardFontSize = 12;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "RapidReports";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;
                int numberOfTableColumn = tableData.Columns.Count;
                int numberOfTableRows = tableData.Rows.Count;
                
                //worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].EntireColumn.AutoFit();
                worksheet.Cells[cellRowIndex, cellColumnIndex] = StringHeaderReports.COMPANY_NAME;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, cellColumnIndex + 2]].Merge();
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, cellColumnIndex + 2]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                worksheet.Cells[cellRowIndex, numberOfTableColumn] = reportCode;
                cellRowIndex+=3;
                // begin Report name
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].Font.Size = 18;
                worksheet.Cells[cellRowIndex, cellColumnIndex] = reportName;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].Font.Bold = true;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].Merge();
                // End Report name

                // Begin Overview info
                int index = 0, distance = numberOfTableColumn - 4;
                cellRowIndex++;
                foreach (KeyValuePair<string, string> entry in first)
                {
                    if (index > 0 && index % 2 == 0)
                    {
                        worksheet.Cells[cellRowIndex, distance + index + 1] = entry.Key;
                        worksheet.Cells[cellRowIndex, distance + index + 2] = entry.Value;
                    }
                    else
                    {
                        worksheet.Cells[cellRowIndex, index + 2] = entry.Key;
                        worksheet.Cells[cellRowIndex, index + 3] = entry.Value;
                    }
                    
                    index+=2;
                }
                if(second != null && second.Keys.Count > 0)
                {
                    index = 0;
                    cellRowIndex++;
                    foreach (KeyValuePair<string, string> entry in second)
                    {
                        if (index > 0 && index % 2 == 0)
                        {
                            worksheet.Cells[cellRowIndex, distance + index + 1] = entry.Key;
                            worksheet.Cells[cellRowIndex, distance + index + 2] = entry.Value;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, index + 2] = entry.Key;
                            worksheet.Cells[cellRowIndex, index + 3] = entry.Value;
                        }

                        index += 2;
                    }
                }
                // End Overview info

                // Begin headers
                cellRowIndex++;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].Font.Bold = true;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex, numberOfTableColumn]].RowHeight = 40;
                // set border
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex + numberOfTableRows, numberOfTableColumn]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                worksheet.Range[worksheet.Cells[cellRowIndex, cellColumnIndex], worksheet.Cells[cellRowIndex + numberOfTableRows, numberOfTableColumn]].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                for (int i = 0; i < numberOfTableColumn; i++)
                {
                    worksheet.Cells[cellRowIndex, i + 1] = tableData.Columns[i].Caption;
                    worksheet.Cells[cellRowIndex, i + 1].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbSilver;
                }
                //End headers
                cellRowIndex++;
                //Loop through each row and read value from each column.
                for (int i = 0; i < numberOfTableRows; i++)
                {
                    for (int j = 0; j < numberOfTableColumn; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                        if (j == 0)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            worksheet.Cells[cellRowIndex, cellColumnIndex].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }
                        
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = tableData.Rows[i][j].ToString();
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                worksheet.Range[worksheet.Cells[cellRowIndex + 2, 1], worksheet.Cells[cellRowIndex + 2, numberOfTableColumn]].Font.Bold = true;
                worksheet.Range[worksheet.Cells[cellRowIndex + 2, 1], worksheet.Cells[cellRowIndex + 2, 2]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                worksheet.Cells[cellRowIndex + 2, 1] = StringHeaderReports.BO_PHAN_KHO;
                worksheet.Range[worksheet.Cells[cellRowIndex + 2, 1], worksheet.Cells[cellRowIndex + 2, 2]].Merge();
                worksheet.Cells[cellRowIndex + 2, numberOfTableColumn - 1] = StringHeaderReports.BO_PHAN_GIAO_NHAN;
                worksheet.Range[worksheet.Cells[cellRowIndex + 2, numberOfTableColumn - 1], worksheet.Cells[cellRowIndex + 2, numberOfTableColumn]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                worksheet.Range[worksheet.Cells[cellRowIndex + 2, numberOfTableColumn - 1], worksheet.Cells[cellRowIndex + 2, numberOfTableColumn]].Merge();
                worksheet.Columns.AutoFit();

                workbook.SaveAs(fileName);
                excel.Quit();
                workbook = null;
                excel = null;
                Process.Start("EXCEL.EXE", "\"" + fileName + "\"");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (excel != null)
                {
                    excel.Quit();
                    workbook = null;
                    excel = null;
                }
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
