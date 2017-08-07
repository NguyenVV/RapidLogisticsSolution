using BusinessEntities;
using BusinessServices.Interfaces;
using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RapidWarehouse
{
    public partial class FormBaoCao : Form
    {
        private readonly IMasterBillServices _masterBillServices;
        private readonly IShipmentServices _shipmentServices;
        private readonly IShipmentOutServices _shipmentOutServices;
        private readonly IBoxInforServices _boxInforServices;
        private readonly IManifestServices _manifestServices;
        private readonly IShipmentWaitToConfirmedServices _shipmentWaitConfirmedServices;
        private readonly IShipmentOutTempServices _shipmentOutTempServices;
        public FormBaoCao(IMasterBillServices masterBillServices, IShipmentServices shipmentServices
            , IBoxInforServices boxInforServices, IShipmentOutServices shipmentOutServices
            , IManifestServices manifestServices, IShipmentWaitToConfirmedServices shipmentWaitToConfirmedServices
            , IShipmentOutTempServices shipmentOutTempServices)
        {
            InitializeComponent();
            _masterBillServices = masterBillServices;
            _shipmentServices = shipmentServices;
            _shipmentOutServices = shipmentOutServices;
            _boxInforServices = boxInforServices;
            _manifestServices = manifestServices;
            _shipmentWaitConfirmedServices = shipmentWaitToConfirmedServices;
            _shipmentOutTempServices = shipmentOutTempServices;
            
            dtpNgayBaoCao.CustomFormat = "dd/MM/yyyy";
            dtpNgayXuatReport.CustomFormat = "dd/MM/yyyy";
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.CustomFormat = "dd/MM/yyyy";

            LoadAllMasterBillByDateToCombobox(dtpNgayXuatReport.Value, cbbMasterBillOut);
            LoadAllMasterBillByDateToCombobox(dtpNgayBaoCao.Value, cbbMasterList);
            this.Text = "Các báo cáo - " + FormUltils.getInstance().GetVersionInfo();
        }


        #region Các báo cáo
        private void btnSanLuongNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbMasterList.Text) || cbbMasterList.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã MAWB ở trên để làm báo cáo");
                return;
            }
            MasterAirwayBillEntity masterItem = (MasterAirwayBillEntity)cbbMasterList.SelectedItem;
            if (masterItem == null)
            {
                MessageBox.Show("Không tìm thấy MAWB mà bạn đã nhập trong ngày đến đã chọn", "Không tìm thấy MAWB đã nhập trong ngày đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SanLuongNhapKho(masterItem);
        }

        public void SanLuongNhapKho(MasterAirwayBillEntity masterItem)
        {
            List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(masterItem.Id);
            string fileName = Environment.CurrentDirectory + @"\SanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW01";
            string headlineText = "TỔNG HỢP SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

                            + "VẬN ĐƠN CHỦ (MAWB): " + masterItem.MasterAirwayBill.ToUpper();
            string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 11;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);
            int rowCount = listBox.Count;
            Table table = doc.AddTable(rowCount + 2, 3);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Mã Thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Tổng đơn hàng (Total HAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");

            table.Rows[1].Cells[0].Paragraphs.First().Append("Total").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[1].Paragraphs.First().Append(listBox.Count + "").Font(new FontFamily("Times New Roman"));
            int total = 0;
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows[i + 2].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[1].Paragraphs.First().Append(listBox[i].BoxId).Bold().Font(new FontFamily("Times New Roman"));
                int totalInBox = _shipmentServices.GetByBoxId(listBox[i].Id).Count();
                total += totalInBox;
                table.Rows[i + 2].Cells[2].Paragraphs.First().Append(totalInBox + "").Bold().Font(new FontFamily("Times New Roman"));
            }
            table.Rows[1].Cells[2].Paragraphs.First().Append(total + "").Font(new FontFamily("Times New Roman"));

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            doc.InsertParagraph(ngayDen, false, paraFormat);
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }

        private void dtpNgayBaoCao_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayBaoCao.Value, cbbMasterList);
        }

        private void btnChiTietSanLuong_Click(object sender, EventArgs e)
        {
            ChiTietSanLuongNhapKho();
        }
        private DataGridView SetupDataGridView()
        {
            DataGridView songsDataGridView = new DataGridView();

            songsDataGridView.ColumnCount = 5;

            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(songsDataGridView.Font, FontStyle.Bold);

            songsDataGridView.Name = "songsDataGridView";
            songsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            songsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            songsDataGridView.GridColor = Color.Black;
            songsDataGridView.RowHeadersVisible = true;

            songsDataGridView.Columns[0].Name = "Release Date";
            songsDataGridView.Columns[1].Name = "Track";
            songsDataGridView.Columns[2].Name = "Title";
            songsDataGridView.Columns[3].Name = "Artist";
            //songsDataGridView.Columns[4].Name = "Album";
            //songsDataGridView.Columns[4].DefaultCellStyle.Font =
            //    new Font(songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            songsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
            songsDataGridView.Dock = DockStyle.Fill;

            return songsDataGridView;
        }
        private void ChiTietSanLuongNhapKho()
        {
            DataTable table = new DataTable();
            table.Columns.Add(StringHeaderReports.STT);
            table.Columns.Add(StringHeaderReports.MAWB);
            table.Columns.Add(StringHeaderReports.SHIPMENTNO);
            table.Columns.Add(StringHeaderReports.DECLARATION_NO);
            table.Columns.Add(StringHeaderReports.BOXID);
            table.Columns.Add(StringHeaderReports.CONTENT);
            table.Columns.Add(StringHeaderReports.NUMBER_PACKAGE);
            table.Columns.Add(StringHeaderReports.WEIGHT);
            //List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateArrived(dtpNgayBaoCao.Value);
            int totalThung = 0;
            int totalShipment = 0;
            int index = 1;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null & listShipment.Count > 0)
                            {
                                foreach (var ship in listShipment)
                                {
                                    DataRow row = table.NewRow();
                                    row[StringHeaderReports.STT] = index;
                                    row[StringHeaderReports.MAWB] = item.MasterAirwayBill;
                                    row[StringHeaderReports.SHIPMENTNO] = ship.ShipmentId;
                                    row[StringHeaderReports.DECLARATION_NO] = ship.DeclarationNo;
                                    row[StringHeaderReports.BOXID] = box.BoxId;
                                    row[StringHeaderReports.CONTENT] = ship.Content;
                                    row[StringHeaderReports.NUMBER_PACKAGE] = ship.NumberPackage;
                                    row[StringHeaderReports.WEIGHT] = ship.Weight;
                                    table.Rows.Add(row);
                                    index++;
                                }
                                totalShipment += listShipment.Count;
                            }
                        }
                        totalThung += listBox.Count;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }
            Dictionary<string, string> first = new Dictionary<string, string>();
            first.Add("NGÀY ĐẾN : ", dtpNgayBaoCao.Value.ToString("dd/MM/yyyy"));
            Dictionary<string, string> second = new Dictionary<string, string>();
            second.Add("TỔNG SỐ THÙNG: ", totalThung+"");
            second.Add("TỔNG SỐ ĐƠN HÀNG: ",""+ totalShipment);
            
            string fileNameExcel = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".xls";
            //FormUltils.getInstance().ExcelExport(listDetail, fileNameExcel, true);
            FormUltils.getInstance().ExportToExcel(table, fileNameExcel, StringHeaderReports.REPORTS_NAME_CHI_TIET_NHAP_KHO,StringHeaderReports.REPORT_CODE_02, first,second);
            #region export to word
            //string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            //string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW02";
            //string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            //string ngayDen = "NGÀY ĐẾN : " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

            //                + "TỔNG SỐ THÙNG: " + totalThung
            //                + "\t\t\tTỔNG SỐ ĐƠN HÀNG: " + totalShipment;
            //string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            //// A formatting object for our headline:
            //var headLineFormat = new Formatting();
            //headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //headLineFormat.Size = 18D;
            //headLineFormat.Position = 12;
            //headLineFormat.Bold = true;

            //// A formatting object for our normal paragraph text:
            //var paraFormat = new Formatting();
            //paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraFormat.Size = 12D;
            //paraFormat.Position = 10;
            //paraFormat.Bold = false;


            //var paraRightFormat = new Formatting();
            //paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraRightFormat.Size = 12D;
            //paraRightFormat.Position = 12;
            //paraRightFormat.Bold = true;

            //// Create the document in memory:
            //var doc = DocX.Create(fileName);

            //Table table = doc.AddTable(listDetail.Count + 1, 7);

            ////table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            //table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            ////table.Rows[0].Cells[0].Width = 50;
            //table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[1].Width = 800;
            //table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[2].Width = 100;
            //table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            //for (int i = 0; i < totalShipment; i++)
            //{
            //    table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //}

            //doc.InsertParagraph(companyName, false, paraFormat);
            //doc.InsertParagraph(Environment.NewLine);
            //// Insert the now text obejcts;
            //Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            //title.Alignment = Alignment.center;
            //doc.InsertParagraph(ngayDen, false, paraFormat);
            //doc.InsertTable(table);
            //doc.InsertParagraph(Environment.NewLine);
            //Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            //giaoNhan.Alignment = Alignment.center;
            //// Save to the output directory:

            //doc.SaveAs(fileName);
            //// Open in Word:
            //Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
            #endregion
        }

        private void cbbMasterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMasterList.SelectedIndex >= 0)
            {
                MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterList.SelectedItem;

                LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdReport);
                cbbBoxIdReport.SelectedIndex = 0;
            }
        }

        private void cbbBoxIdReport_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cbbMasterList_Leave(object sender, EventArgs e)
        {
            cbbMasterList.Text = cbbMasterList.Text.ToUpper();
        }
        private void cbbBoxIdReport_Leave(object sender, EventArgs e)
        {
            cbbBoxIdReport.Text = cbbBoxIdReport.Text.ToUpper();
        }

        private void btnChiTietTheoThung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbBoxIdReport.Text) || cbbBoxIdReport.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã thùng ở trên để làm báo cáo","Chọn thùng",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            BoxInforEntity boxSelected = (BoxInforEntity)cbbBoxIdReport.SelectedItem;
            if (boxSelected == null)
            {
                MessageBox.Show("Không tìm thấy mã thùng mà bạn đã nhập trong ngày đến đã chọn", "Không tìm thấy thùng đã nhập trong ngày đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChiTietSanLuongNhapKhoTheoThung(boxSelected);
        }

        private void ChiTietSanLuongNhapKhoTheoThung(BoxInforEntity boxSelected)
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();

            int totalShipment = 0;

            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(boxSelected.Id);

            if (listShipment != null & listShipment.Count > 0)
            {
                foreach (var ship in listShipment)
                {
                    ReportDetailEntity entity = new ReportDetailEntity();
                    entity.MasterId = cbbMasterList.Text;
                    entity.BoxId = boxSelected.BoxId;
                    entity.ShipmentId = ship.ShipmentId;
                    listDetail.Add(entity);
                }
                totalShipment = listShipment.Count;
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKhoTheoThung" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW03";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

                            + "MÃ THÙNG: " + boxSelected.BoxId
                            + "\t\t\tTỔNG SỐ ĐƠN HÀNG: " + totalShipment;
            string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 10;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            Table table = doc.AddTable(listDetail.Count + 1, 7);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            for (int i = 0; i < totalShipment; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            doc.InsertParagraph(ngayDen, false, paraFormat);
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }

        private void btnChiTietXuatKho_Click(object sender, EventArgs e)
        {
            List<ShipmentOutEntity> listOutDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDate(dtpNgayXuatReport.Value);
            List<ShipmentEntity> listDetail = (List<ShipmentEntity>)_shipmentOutServices.GetByDateForReport(dtpNgayXuatReport.Value);
            ChiTietSanLuongXuatKho(listOutDetail, listDetail);
        }

        private void ChiTietSanLuongXuatKho(List<ShipmentOutEntity> listDetail, List<ShipmentEntity> listShipDetail, string masterBillIdString = null, string boxIdString=null)
        {
            DataTable table = new DataTable();
            table.Columns.Add(StringHeaderReports.STT);
            table.Columns.Add(StringHeaderReports.MAWB);
            table.Columns.Add(StringHeaderReports.BOXID);
            table.Columns.Add(StringHeaderReports.SHIPMENTNO);
            table.Columns.Add(StringHeaderReports.DECLARATION_NO, typeof(string));
            table.Columns.Add(StringHeaderReports.CONTENT);
            table.Columns.Add(StringHeaderReports.NUMBER_PACKAGE);
            table.Columns.Add(StringHeaderReports.WEIGHT);

            int totalThung = 0, index = 1;
            int totalShipment;
            if (listDetail != null && listDetail.Count > 0)
            {
                totalShipment = listDetail.Count;
                totalThung = listDetail.Select(t=>t.BoxIdRef).Distinct().Count();

                for (int i = 0; i < totalShipment; i++)
                {
                    var shipment = listShipDetail.Find(t => t.ShipmentId == listDetail[i].ShipmentId);
                    DataRow row = table.NewRow();
                    row[StringHeaderReports.STT] = index;
                    row[StringHeaderReports.MAWB] = listDetail[i].MasterBillIdString;
                    row[StringHeaderReports.SHIPMENTNO] = listDetail[i].ShipmentId;
                    row[StringHeaderReports.BOXID] = listDetail[i].BoxIdString;
                    row[StringHeaderReports.CONTENT] = shipment.Content;
                    row[StringHeaderReports.NUMBER_PACKAGE] = shipment.NumberPackage;
                    row[StringHeaderReports.WEIGHT] = shipment.Weight;
                    row[StringHeaderReports.DECLARATION_NO] = "'" + shipment.DeclarationNo;
                    table.Rows.Add(row);
                    index++;
                }
            }
            else
            {
                MessageBox.Show("Chưa có hàng hóa nào được xuất kho!");
                return;
            }

            string infoHeader = "TỔNG SỐ THÙNG: ";
            string value = "" + totalThung;
            string reportCode = StringHeaderReports.REPORT_CODE_01;
            if (boxIdString != null)
            {
                infoHeader = "MÃ THÙNG: ";
                value = boxIdString;
                reportCode = StringHeaderReports.REPORT_CODE_03;
            }
            else
            {
                if(masterBillIdString!= null)
                {
                    infoHeader = "MÃ MAWB: " ;
                    value = masterBillIdString;
                    reportCode = StringHeaderReports.REPORT_CODE_02;
                }
            }

            Dictionary<string, string> first = new Dictionary<string, string>();
            first.Add("NGÀY XUẤT : ", dtpNgayXuatReport.Value.ToString("dd/MM/yyyy"));
            Dictionary<string, string> second = new Dictionary<string, string>();
            second.Add(infoHeader, value);
            second.Add("TỔNG SỐ ĐƠN HÀNG: ", "" + totalShipment);

            string fileNameExcel = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".xls";
            //FormUltils.getInstance().ExcelExport(listDetail, fileNameExcel, true);
            FormUltils.getInstance().ExportToExcel(table, fileNameExcel, StringHeaderReports.REPORTS_NAME_CHI_TIET_XUAT_KHO, reportCode, first, second);
            #region word export
            //string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            //string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tEMW01";
            //string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG XUẤT KHO";
            //string ngayDen = "NGÀY XUẤT : " + dtpNgayXuatReport.Value.ToString("dd/MM/yyyy") + "\n"

            //                + infoHeader
            //                + "\t\t\tTỔNG SỐ ĐƠN HÀNG: " + totalShipment;
            //string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            //// A formatting object for our headline:
            //var headLineFormat = new Formatting();
            //headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //headLineFormat.Size = 18D;
            //headLineFormat.Position = 12;
            //headLineFormat.Bold = true;

            //// A formatting object for our normal paragraph text:
            //var paraFormat = new Formatting();
            //paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraFormat.Size = 12D;
            //paraFormat.Position = 10;
            //paraFormat.Bold = false;


            //var paraRightFormat = new Formatting();
            //paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            //paraRightFormat.Size = 12D;
            //paraRightFormat.Position = 12;
            //paraRightFormat.Bold = true;

            //// Create the document in memory:
            //var doc = DocX.Create(fileName);

            //Table table = doc.AddTable(listDetail.Count + 1, 7);

            ////table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            //table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            ////table.Rows[0].Cells[0].Width = 50;
            //table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[1].Width = 800;
            //table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            ////table.Rows[0].Cells[2].Width = 100;
            //table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            //table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            //for (int i = 0; i < totalShipment; i++)
            //{
            //    table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterBillIdString).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxIdString).Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //    table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            //}

            //doc.InsertParagraph(companyName, false, paraFormat);
            //doc.InsertParagraph(Environment.NewLine);
            //// Insert the now text obejcts;
            //Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            //title.Alignment = Alignment.center;
            //doc.InsertParagraph(ngayDen, false, paraFormat);
            //doc.InsertTable(table);
            //doc.InsertParagraph(Environment.NewLine);
            //Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            //giaoNhan.Alignment = Alignment.center;
            //// Save to the output directory:

            //doc.SaveAs(fileName);
            //// Open in Word:
            //Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
            #endregion
        }

        private void btnSanLuongTonKho_Click(object sender, EventArgs e)
        {
            if (!ValidateFromToDate())
                return;

            TongHopSanLuongTonKho();
        }

        private void TongHopSanLuongTonKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            //get all MAWB in the duration
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            //get all shipment exported in the duration
            List<ShipmentOutEntity> listXuatKho = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            int totalThung = 0;
            int totalShipment = 0;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    //get all Box in this MAWB
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        //Count shipment on each box
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null && listShipment.Count > 0)
                            {
                                int totalShipmentInStock = 0;
                                foreach (var ship in listShipment)
                                {
                                    //Loc nhung ship da xuat trong khoang thoi gian da chon
                                    if (!listXuatKho.Any(t => t.ShipmentId.Equals(ship.ShipmentId, StringComparison.CurrentCultureIgnoreCase)))
                                    {
                                        totalShipmentInStock += 1;
                                    }
                                }
                                //update total shipment
                                totalShipment += totalShipmentInStock;
                                //Nếu các shipment trong box này còn tồn thì mới cho vào báo cáo
                                if (totalShipmentInStock > 0)
                                {
                                    ReportDetailEntity entity = new ReportDetailEntity();
                                    entity.MasterId = item.MasterAirwayBill;
                                    entity.BoxId = box.BoxId;
                                    entity.TotalShipment = totalShipmentInStock;
                                    listDetail.Add(entity);

                                    totalThung += 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\TongHopSanLuongTonKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIVT01";
            string headlineText = "TỔNG HỢP SẢN LƯỢNG TỒN KHO";
            string ngayDen = "TỪ NGÀY " + dtpFrom.Value.ToString("dd/MM/yyyy")

                            + "\tĐẾN NGÀY : " + dtpTo.Value.ToString("dd/MM/yyyy");

            string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 10;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            Table table = doc.AddTable(listDetail.Count + 2, 4);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn tổng (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Tổng đơn hàng (Total HAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;

            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            table.Rows[1].Cells[0].Paragraphs.First().Append("Total").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[2].Paragraphs.First().Append(totalThung + "").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[3].Paragraphs.First().Append(totalShipment + "").Font(new FontFamily("Times New Roman"));

            int numberRow = listDetail.Count;
            for (int i = 0; i < numberRow; i++)
            {
                table.Rows[i + 2].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[2].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[3].Paragraphs.First().Append("" + listDetail[i].TotalShipment).Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            Paragraph title1 = doc.InsertParagraph(ngayDen, false, paraFormat);
            title1.Alignment = Alignment.center;
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }
        
        private void BangKeChiTietSanLuongTonKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            //get all MAWB in the duration
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            //get all shipment exported in the duration
            List<ShipmentOutEntity> listXuatKho = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDateRange(dtpFrom.Value, dtpTo.Value);
            int totalThung = 0;
            int totalShipment = 0;
            if (listMaster != null && listMaster.Count > 0)
            {
                foreach (var item in listMaster)
                {
                    //get all Box in this MAWB
                    List<BoxInforEntity> listBox = (List<BoxInforEntity>)_boxInforServices.GetByMasterBill(item.Id);
                    if (listBox != null && listBox.Count > 0)
                    {
                        foreach (var box in listBox)
                        {
                            List<ShipmentEntity> listShipment = (List<ShipmentEntity>)_shipmentServices.GetByBoxId(box.Id);
                            if (listShipment != null && listShipment.Count > 0)
                            {
                                int totalShipmentInStock = 0;
                                foreach (var ship in listShipment)
                                {
                                    //Loc nhung ship da xuat trong khoang thoi gian da chon
                                    if (!listXuatKho.Any(t => t.ShipmentId == ship.ShipmentId))
                                    {
                                        ReportDetailEntity entity = new ReportDetailEntity();
                                        entity.MasterId = item.MasterAirwayBill;
                                        entity.BoxId = box.BoxId;
                                        entity.ShipmentId = ship.ShipmentId;
                                        listDetail.Add(entity);
                                        totalShipmentInStock += 1;
                                    }
                                }

                                if (totalShipmentInStock > 0)
                                {
                                    totalShipment += totalShipmentInStock;
                                    totalThung += 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hàng nhập về vào ngày đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\TongHopSanLuongTonKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIVT02";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG TỒN KHO";
            string ngayDen = "TỪ NGÀY " + dtpFrom.Value.ToString("dd/MM/yyyy")

                            + "\tĐẾN NGÀY : " + dtpTo.Value.ToString("dd/MM/yyyy")
                            + "\nTỔNG SỐ THÙNG: " + totalThung
                            + "\t\t\tTỔNG SỐ ĐƠN HÀNG: " + totalShipment;
            string boPhanGiaoNhan = "BỘ PHẬN KHO\t\t\t\t\t\tBỘ PHẬN GIAO NHẬN";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 10;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            Table table = doc.AddTable(totalShipment + 1, 7);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Font(new FontFamily("Times New Roman"));
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Vận đơn chủ (MAWB)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Mã đơn hàng (ShipmentNo)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Mã thùng (BoxId)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[4].Paragraphs.First().Append("Nội dung (Content)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[5].Paragraphs.First().Append("Số lượng (Quantity)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[0].Cells[6].Paragraphs.First().Append("Trọng lượng (Weight)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[0].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[1].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[2].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[3].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[4].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[5].FillColor = Color.FromName("DarkGray");
            table.Rows[0].Cells[6].FillColor = Color.FromName("DarkGray");


            for (int i = 0; i < totalShipment; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[4].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[5].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[6].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            Paragraph title1 = doc.InsertParagraph(ngayDen, false, paraFormat);
            title1.Alignment = Alignment.center;
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:

            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }

        private void btnKeChiTietSanLuongTonKho_Click(object sender, EventArgs e)
        {
            if (!ValidateFromToDate())
                return;

            BangKeChiTietSanLuongTonKho();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Program.Container.GetInstance<FormHome>().Show();
            this.Dispose();
        }
        
        private bool ValidateFromToDate()
        {
            if (dtpFrom.Value.ToString("yyyyMMdd").CompareTo(dtpTo.Value.ToString("yyyyMMdd")) > 0)
            {
                MessageBox.Show("Giá trị từ ngày không được lớn hơn giá trị đến ngày!", "Chọn lại giá trị từ ngày");
                dtpFrom.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region Dùng chung

        private void LoadAllMasterBillByDateToCombobox(DateTime date, ComboBox cbbMaster)
        {
            cbbMaster.DataSource = null;
            cbbMaster.Items.Clear();

            List<MasterAirwayBillEntity> masterBillList = _shipmentOutServices.GetAllMasterBillByDate(date).ToList();
            if (masterBillList != null && masterBillList.Count > 0)
            {
                cbbMaster.DataSource = masterBillList;
                cbbMaster.ValueMember = "Id";
                cbbMaster.DisplayMember = "MasterAirwayBill";
            }
        }
        private void LoadBoxIdListFromMasterBillId(int masterBillId, ComboBox cbbBoxes)
        {
            if (masterBillId <= 0)
                return;

            List<BoxInforEntity> listBoxInfo = _shipmentOutServices.GetAllBoxByMasterBill(masterBillId).ToList();
            if (listBoxInfo != null && listBoxInfo.Count > 0)
            {
                cbbBoxes.DataSource = listBoxInfo;
                cbbBoxes.ValueMember = "Id";
                cbbBoxes.DisplayMember = "BoxId";
            }
            else
            {
                cbbBoxes.DataSource = null;
                cbbBoxes.Items.Clear();
            }
        }
        
        #endregion

        private void FormBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            var home = new FormHome();
            home.Show();
            this.Dispose();
        }

        private void cbbMasterBillOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMasterBillOut.SelectedIndex >= 0)
            {
                MasterAirwayBillEntity itemMaster = (MasterAirwayBillEntity)cbbMasterBillOut.SelectedItem;

                LoadBoxIdListFromMasterBillId(itemMaster.Id, cbbBoxIdOut);
                cbbBoxIdOut.SelectedIndex = 0;
            }
        }

        private void btnReportByMawb_Click(object sender, EventArgs e)
        {
            MasterAirwayBillEntity master = (MasterAirwayBillEntity)cbbMasterBillOut.SelectedItem;
            if (master != null)
            {
                List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByMasterBillId(master.Id);
                List<ShipmentEntity> listShipDetail = (List<ShipmentEntity>)_shipmentOutServices.GetByMasterBillIdForReport(master.Id);
                ChiTietSanLuongXuatKho(listDetail, listShipDetail, master.MasterAirwayBill);
            }
            else
            {
                MessageBox.Show("Không có MAWB nào trong ngày đến đã chọn", "Không có MAWB nào trong ngày đến", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReportByBox_Click(object sender, EventArgs e)
        {
            BoxInforEntity box = (BoxInforEntity)cbbBoxIdOut.SelectedItem;
            if (box != null)
            {
                List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByBoxId(box.Id);
                List<ShipmentEntity> listShipDetail = (List<ShipmentEntity>)_shipmentOutServices.GetByBoxIdForReport(box.Id);
                ChiTietSanLuongXuatKho(listDetail, listShipDetail, box.BoxId);
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã thùng mà bạn đã nhập trong ngày xuất đã chọn", "Không tìm thấy thùng đã nhập trong ngày xuất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpNgayXuatReport_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayXuatReport.Value, cbbMasterBillOut);
        }

        private void btnReportQuater_Click(object sender, EventArgs e)
        {
            if (ccbQuarter.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn quý để làm báo cáo", "Hãy chọn quý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ccbQuarter.Focus();
                return;
            }
            DateTime start, end;
            int quarter = 4;
            switch (ccbQuarter.SelectedIndex)
            {
                case 0:
                    start = new DateTime(DateTime.Now.Year, 1, 1);
                    end = new DateTime(DateTime.Now.Year, 3, 31);
                    quarter = 1;
                    break;
                case 1:
                    start = new DateTime(DateTime.Now.Year, 4, 1);
                    end = new DateTime(DateTime.Now.Year, 6, 30);
                    quarter = 2;
                    break;
                case 2:
                    start = new DateTime(DateTime.Now.Year, 7, 1);
                    end = new DateTime(DateTime.Now.Year, 9, 30);
                    quarter = 3;
                    break;
                case 3:
                    start = new DateTime(DateTime.Now.Year, 10, 1);
                    end = new DateTime(DateTime.Now.Year, 12, 31);
                    quarter = 4;
                    break;
                default:
                    start = new DateTime(DateTime.Now.Year - 1, 10, 1);
                    end = new DateTime(DateTime.Now.Year - 1, 12, 31);
                    quarter = 4;
                    break;
            }
            BangKeChiTietSanLuongTonKhoTheoQuy(start, end, quarter);
        }
        private void BangKeChiTietSanLuongTonKhoTheoQuy(DateTime start, DateTime end, int quarter)
        {
            List<ShipmentEntity> listXuatKho = (List<ShipmentEntity>)_shipmentOutServices.GetListNotDeliveryByQuarter(start, end);
            int totalShipment =0;
            if (listXuatKho != null && listXuatKho.Count > 0)
            {
                totalShipment = listXuatKho.Count;
            }
            else
            {
                MessageBox.Show("Không có hàng tồn vào quý đã chọn đã chọn");
                return;
            }

            string fileName = Environment.CurrentDirectory + @"\BangKeChiTietSanLuongTonKhoTheoQuy" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC";
            string headlineText = "MẪU CUNG CẤP THÔNG TIN HÀNG TỒN ĐỌNG";
            string ngayDen = "Về các vận đơn quá 90 ngày, kể từ ngày hàng đến cửa khẩu nhập chưa có người nhận tại..........................\n"

                            + "(Theo quy định tại Thông tư số 203/2014/TT-BTC)"
                            + "\n(Kỳ báo cáo: Quý..." + quarter+"... năm..."+start.Year+"...\n\n"
                            + "Kính gửi: Doanh nghiệp kinh doanh cảng, kho bãi...";
            string boPhanGiaoNhan = "Nơi nhận\t\t\t\t\t\t\tGIÁM ĐỐC DOANH NGHIỆP";
            string noiNhan = "Cục Hải quan...\t\t\t\t\t\t(Ký, ghi rõ họ tên, đóng dấu)";
            string noiNhan1 = "Chi cục Hải quan(quản lý kho)...";
            string note = "Ghi chú: ";
            string noteContent = "Ô số (9) ghi rõ: Hàng hóa từ bỏ, quá thời hạn khai hải quan, hàng hóa thu gom không người nhận, hàng hóa ngoài vận đơn, bản khai.";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            headLineFormat.Bold = true;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            paraFormat.Position = 10;
            paraFormat.Bold = false;


            var paraRightFormat = new Formatting();
            paraRightFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraRightFormat.Size = 12D;
            paraRightFormat.Position = 12;
            paraRightFormat.Bold = true;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            Table table = doc.AddTable(totalShipment + 2, 11);

            //table.ColumnWidths.Add(100); table.ColumnWidths.Add(500); table.ColumnWidths.Add(100);

            table.Rows[0].Cells[0].Paragraphs.First().Append("TT").Font(new FontFamily("Times New Roman")).Bold();
            //table.Rows[0].Cells[0].Width = 50;
            table.Rows[0].Cells[1].Paragraphs.First().Append("Tên hàng").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            //table.Rows[0].Cells[1].Width = 800;
            table.Rows[0].Cells[2].Paragraphs.First().Append("Số lượng, trọng lượng").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs.First().Append("Số, loại cont/số seal").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[4].Paragraphs.First().Append("Người gửi, địa chỉ").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[5].Paragraphs.First().Append("Người nhận, địa chỉ").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[6].Paragraphs.First().Append("Số/ngày vận đơn").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[7].Paragraphs.First().Append("Tên PTVT/ngày nhập cảnh").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[8].Paragraphs.First().Append("Vị trí/địa điểm lưu giữ hàng").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[9].Paragraphs.First().Append("Phân loại tồn đọng").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[10].Paragraphs.First().Append("Ghi chú").Font(new FontFamily("Times New Roman")).Bold().Alignment = Alignment.center;

            table.Rows[1].Cells[0].Paragraphs.First().Append("(1)").Font(new FontFamily("Times New Roman"));
            table.Rows[1].Cells[1].Paragraphs.First().Append("(2)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[2].Paragraphs.First().Append("(3)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            //table.Rows[1].Cells[3].Paragraphs.First().Append("(2)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[4].Paragraphs.First().Append("(4)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[5].Paragraphs.First().Append("(5)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[6].Paragraphs.First().Append("(6)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[7].Paragraphs.First().Append("(7)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[8].Paragraphs.First().Append("(8)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[9].Paragraphs.First().Append("(9)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;
            table.Rows[1].Cells[10].Paragraphs.First().Append("(10)").Font(new FontFamily("Times New Roman")).Alignment = Alignment.center;

            for (int i = 0; i < totalShipment; i++)
            {
                table.Rows[i + 2].Cells[0].Paragraphs.First().Append((i + 1) + "").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[1].Paragraphs.First().Append(listXuatKho[i].Content).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[2].Paragraphs.First().Append(Convert.ToString(listXuatKho[i].Weight)).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[3].Paragraphs.First().Append(_boxInforServices.GetBoxIdStringById(listXuatKho[i].BoxId)).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[4].Paragraphs.First().Append(listXuatKho[i].Sender != null?listXuatKho[i].Sender + ", ":"" + listXuatKho[i].Country).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[5].Paragraphs.First().Append(listXuatKho[i].Receiver != null ?listXuatKho[i].Receiver + ", ":"" + listXuatKho[i].Address).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[6].Paragraphs.First().Append(listXuatKho[i].ShipmentId + "/" + (listXuatKho[i].DateCreated != new DateTime() ? listXuatKho[i].DateCreated.ToString("dd-MM-yyyy"):"")).Font(new FontFamily("Times New Roman"));

                table.Rows[i + 2].Cells[7].Paragraphs.First().Append(listXuatKho[i].DateOfCompletion != null ?listXuatKho[i].DateOfCompletion != new DateTime()?Convert.ToDateTime(listXuatKho[i].DateOfCompletion).ToString("dd-MM-yyyy"):"":"").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[8].Paragraphs.First().Append(listXuatKho[i].Consignee).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[9].Paragraphs.First().Append("Hàng hóa thu gom không người nhận").Font(new FontFamily("Times New Roman"));
                table.Rows[i + 2].Cells[10].Paragraphs.First().Append("").Font(new FontFamily("Times New Roman"));
            }

            doc.InsertParagraph(companyName, false, paraFormat);
            doc.InsertParagraph(Environment.NewLine);
            // Insert the now text obejcts;
            Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
            title.Alignment = Alignment.center;
            Paragraph title1 = doc.InsertParagraph(ngayDen, false, paraFormat);
            title1.Alignment = Alignment.center;
            doc.InsertTable(table);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph giaoNhan = doc.InsertParagraph(boPhanGiaoNhan, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            //doc.InsertParagraph(Environment.NewLine);
            Paragraph noiNhanPara = doc.InsertParagraph(noiNhan, false, paraFormat);
            giaoNhan.Alignment = Alignment.center;
            //doc.InsertParagraph(Environment.NewLine);
            Paragraph noiNhanPara1 = doc.InsertParagraph(noiNhan1, false, paraFormat);
            giaoNhan.Alignment = Alignment.center;
            //doc.InsertParagraph(Environment.NewLine);
            doc.InsertParagraph(Environment.NewLine);
            Paragraph ghichuPara = doc.InsertParagraph(note, false, paraRightFormat);
            giaoNhan.Alignment = Alignment.center;
            Paragraph ghichuContentPara = doc.InsertParagraph(noteContent, false, paraFormat);
            giaoNhan.Alignment = Alignment.center;
            // Save to the output directory:
            doc.SaveAs(fileName);
            // Open in Word:
            Process.Start("WINWORD.EXE", "\"" + fileName + "\"");
        }
    }
}
