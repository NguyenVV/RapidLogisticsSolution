using BusinessEntities;
using BusinessServices.Interfaces;
using Novacode;
using System;
using System.Collections.Generic;
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
        }


        #region Các báo cáo
        private void btnSanLuongNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbMasterList.Text) || cbbMasterList.Text == string.Empty)
            {
                MessageBox.Show("Hãy chọn mã MAWB ở trên để làm báo cáo");
                return;
            }
            SanLuongNhapKho();
        }

        public void SanLuongNhapKho()
        {
            MasterAirwayBillEntity masterItem = (MasterAirwayBillEntity)cbbMasterList.SelectedItem;
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

        private void ChiTietSanLuongNhapKho()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            List<MasterAirwayBillEntity> listMaster = (List<MasterAirwayBillEntity>)_masterBillServices.GetByDateArrived(dtpNgayBaoCao.Value);
            int totalThung = 0;
            int totalShipment = 0;
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
                                    ReportDetailEntity entity = new ReportDetailEntity();
                                    entity.MasterId = item.MasterAirwayBill;
                                    entity.BoxId = box.BoxId;
                                    entity.ShipmentId = ship.ShipmentId;
                                    listDetail.Add(entity);
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

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongNhapKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tIMW02";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG NHẬP KHO";
            string ngayDen = "NGÀY ĐẾN : " + dtpNgayBaoCao.Value.ToString("dd/MM/yyyy") + "\n"

                            + "TỔNG SỐ THÙNG: " + totalThung
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
                MessageBox.Show("Hãy chọn mã thùng ở trên để làm báo cáo");
                return;
            }

            ChiTietSanLuongNhapKhoTheoThung();
        }

        private void ChiTietSanLuongNhapKhoTheoThung()
        {
            List<ReportDetailEntity> listDetail = new List<ReportDetailEntity>();
            BoxInforEntity boxSelected = (BoxInforEntity)cbbBoxIdReport.SelectedItem;

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
            List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByDate(dtpNgayXuatReport.Value);
            ChiTietSanLuongXuatKho(listDetail);
        }

        private void ChiTietSanLuongXuatKho(List<ShipmentOutEntity> listDetail, string masterBillIdString = null, string boxIdString=null)
        {
            int totalThung = 0;
            int totalShipment;
            if (listDetail != null && listDetail.Count > 0)
            {
                totalShipment = listDetail.Count;
                totalThung = 1;
                int boxId = listDetail[0].BoxIdRef;
                for (int i = 1; i < totalShipment; i++)
                {
                    if (boxId != listDetail[i].BoxIdRef)
                    {
                        totalThung++;
                        boxId = listDetail[i].BoxIdRef;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có hàng hóa nào được xuất kho!");
                return;
            }

            string infoHeader = "TỔNG SỐ THÙNG: " + totalThung;
            if(boxIdString != null)
            {
                infoHeader = "MÃ THÙNG: " + boxIdString;
            }
            else
            {
                if(masterBillIdString!= null)
                {
                    infoHeader = "MÃ MAWB: " + masterBillIdString;
                }
            }

            string fileName = Environment.CurrentDirectory + @"\ChiTietSanLuongXuatKho" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".doc";
            string companyName = "CÔNG TY CP CÔNG NGHỆ THẦN TỐC\t\t\t\t\t\tEMW01";
            string headlineText = "BẢNG KÊ CHI TIẾT SẢN LƯỢNG XUẤT KHO";
            string ngayDen = "NGÀY XUẤT : " + dtpNgayXuatReport.Value.ToString("dd/MM/yyyy") + "\n"

                            + infoHeader
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
                table.Rows[i + 1].Cells[1].Paragraphs.First().Append(listDetail[i].MasterBillIdString).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[2].Paragraphs.First().Append(listDetail[i].ShipmentId).Font(new FontFamily("Times New Roman"));
                table.Rows[i + 1].Cells[3].Paragraphs.First().Append(listDetail[i].BoxIdString).Font(new FontFamily("Times New Roman"));
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
                ChiTietSanLuongXuatKho(listDetail, master.MasterAirwayBill);
            }
        }

        private void btnReportByBox_Click(object sender, EventArgs e)
        {
            BoxInforEntity box = (BoxInforEntity)cbbBoxIdOut.SelectedItem;
            if (box != null)
            {
                List<ShipmentOutEntity> listDetail = (List<ShipmentOutEntity>)_shipmentOutServices.GetByBoxId(box.Id);
                ChiTietSanLuongXuatKho(listDetail, null, box.BoxId);
            }
        }

        private void dtpNgayXuatReport_ValueChanged(object sender, EventArgs e)
        {
            LoadAllMasterBillByDateToCombobox(dtpNgayXuatReport.Value, cbbMasterBillOut);
        }
    }
}
