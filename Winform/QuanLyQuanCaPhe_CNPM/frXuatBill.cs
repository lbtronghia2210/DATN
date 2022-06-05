using DevExpress.LookAndFeel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Novacode;
using QuanLyQuanCaPhe_CNPM.BS_Layer;
using Syncfusion;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frXuatBill : Form
    {
        public frXuatBill()
        {
            InitializeComponent();
        }
        BLThongBao BLTB = new BLThongBao();
        public string TenBan {get;set;}
        public string BangSo { get; set; }
        public string BangChu { get; set; }
        public string TongTien { get; set; }
        public int TongTienBanDau { get; set; }
        //public string VAT { get; set; }
        string err = "";
        public string MaHoaDon { get; set; }


        private void lblBan_Click(object sender, EventArgs e)
        {

        }

        private void FormXuatBill_Load(object sender, EventArgs e)
        {
            try
            {
                lblBan2.Text = TenBan;
                lblTongTien2.Text = BangSo;
                btnXuat.Enabled = false;
                btnXuat.ForeColor = Color.Silver;
                if (jtxtTien.TextValue == "" || TienThoi(jtxtTien.TextValue) < 0)
                {
                    btnXuat.Enabled = false;
                    btnXuat.ForeColor = Color.Silver;
                }
                else
                {
                    btnXuat.Enabled = true;
                    btnXuat.ForeColor = Color.White;
                }
                txtBangChu.Text = BangChu.Substring(10);
            }
            catch
            {

            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if(jtxtTien.TextValue!="")
            {
                try
                {
                    BLChonMon BLCM = new BLChonMon();
                    ReportHoaDon rp = new ReportHoaDon();
                    BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                    BLQuanLyBan BLQLB = new BLQuanLyBan();
                    BLQLKhach BLKH = new BLQLKhach();
                    //

                    //
                    if (cmbSDT.Text != "" && txtMaKH.Text != "" && txtTenKH.Text != "" && txtMST.Text != "")
                    {
                        if (txtMaKH.Text == BLKH.TaoMaKH())
                        {
                            BLKH.ThemKH(cmbSDT, txtMaKH, txtTenKH, txtMST);
                        }
                    }
                    if (chkHDD.Checked == false)
                    {
                        BLCM.CapNhatPhieu(MaHoaDon, int.Parse(TongTien), ref err);
                        BLQLB.CapNhatBan(TenBan, "0", ref err);

                        rp.DataSource = BLCM.XuatBill(MaHoaDon);
                        rp.BangChu = BangChu;
                        rp.BangSo = BangSo;
                        rp.VAT = lblVAT2.Text;
                        rp.TienBanDau = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTienBanDau);
                        rp.TienThoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TienThoi(jtxtTien.TextValue));
                        rp.TienKhachGui = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", int.Parse(jtxtTien.TextValue));
                        string rpPath = "HoaDonDaXuat\\" + "HD " + MaHoaDon + ".pdf";
                        if (File.Exists(rpPath))
                        {
                            File.Delete(rpPath);
                            rp.ExportToPdf(rpPath);
                            System.Diagnostics.Process.Start(rpPath);
                        }
                        else
                        {
                            rp.ExportToPdf(rpPath);
                            System.Diagnostics.Process.Start(rpPath);
                        }
                        this.Close();
                    }

                    else
                    {
                        string rpPath = "HoaDonDaXuat\\" + "HD " + MaHoaDon + ".pdf";
                        string docxPath = "XuatFileHoaDonDo.docx";
                        BLCM.CapNhatPhieu(MaHoaDon, lblVAT2.Text, txtMaKH.Text, int.Parse(TongTien), ref err);
                        DocX gDoc;
                        if (File.Exists(@"HoaDonDo.docx"))
                        {
                            gDoc = CreateInvoiceFromTemplate(DocX.Load(@"HoaDonDo.docx"));
                            gDoc.SaveAs(@"XuatFileHoaDonDo.docx");
                            if (File.Exists(rpPath))
                            {
                                File.Delete(rpPath);
                                WordDocument wordDocument = new WordDocument(docxPath, FormatType.Docx);
                                DocToPDFConverter converter = new DocToPDFConverter();
                                PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);
                                converter.Dispose();
                                wordDocument.Close();
                                pdfDocument.Save(rpPath);
                                pdfDocument.Close(true);
                                System.Diagnostics.Process.Start(rpPath);
                            }
                            else
                            {
                                WordDocument wordDocument = new WordDocument(docxPath, FormatType.Docx);
                                DocToPDFConverter converter = new DocToPDFConverter();
                                PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);
                                converter.Dispose();
                                wordDocument.Close();
                                pdfDocument.Save(rpPath);
                                pdfDocument.Close(true);
                                System.Diagnostics.Process.Start(rpPath);
                            }
                        }
                        else
                        {
                            BLTB.Show("Không có file HoaDonDo.docx");
                        }

                        BLQLB.CapNhatBan(TenBan, "0", ref err);
                        this.Close();
                    }
                }
                catch
                {
                    BLTB.Show("Không thể xuất hóa đơn!");
                }
            }
            else
            {
                BLTB.Show("Vui lòng nhập số tiền khách trả!");
            }
        }
        public int TienThoi(string SoTienKhachGui)
        {
            try
            {

                int t = int.Parse(SoTienKhachGui) - int.Parse(TongTien);
                return t;
            }
            catch
            {
                
            }
            return 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jtxtTien_TextChangeEvent(object sender, EventArgs e)
        {
            jtxtTien.ForeColor = Color.Black;
            try
            {
                lblKhachGui.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Double.Parse(jtxtTien.TextValue.ToString()));
                if (jtxtTien.TextValue == "" || TienThoi(jtxtTien.TextValue) < 0)
                {
                    btnXuat.Enabled = false;
                    btnXuat.ForeColor = Color.Silver;
                    if(jtxtTien.TextValue=="")
                    {
                        lblKhachGui.Text = "0 VNĐ";
                    }
                }
                else
                {
                    btnXuat.Enabled = true;
                    btnXuat.ForeColor = Color.White;
                }
            }
            catch
            {

            }
        }

        private void jtxtTien_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                KiemTraHDD();
            }
            catch
            {

            }
        }
        public void KiemTraHDD()
        {
            int TTien = int.Parse(TongTien);
            if (chkHDD.Checked == true)
            {
                tabctrlThongTin.Enabled = true;

                lblVAT2.Text = "10%";
                TTien = TongTienBanDau + (TongTienBanDau * 10) / 100;
                TongTien = TTien.ToString();
                lblTongTien2.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Double.Parse(TongTien));
                BangSo = lblTongTien2.Text;

                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                BangChu = BLXTT.So_chu(Double.Parse(TongTien));
                //BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                txtBangChu.Text = BangChu;
                //
                BLQLKhach BLKH = new BLQLKhach();
                BLKH.LayKhach(cmbSDT);
                txtMaKH.Text= BLKH.TaoMaKH();
            }
            else
            {
                tabctrlThongTin.Enabled = false;

                lblVAT2.Text = "Không";
                TongTien = TongTienBanDau.ToString();
                lblTongTien2.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Double.Parse(TongTien));
                BangSo = lblTongTien2.Text;

                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                BangChu= BLXTT.So_chu(Double.Parse(TongTien));
                txtBangChu.Text = BangChu;
            }
        }

        private void cmbSDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLQLKhach BLKH = new BLQLKhach();
                BLKH.LayThongTin(cmbSDT, txtMaKH, txtTenKH, txtMST);
            }
            catch
            {

            }
        }

        private void cmbSDT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLQLKhach BLKH = new BLQLKhach();
                BLKH.LayThongTin(cmbSDT, txtMaKH, txtTenKH, txtMST);
            }
            catch
            {

            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void txtMST_TextChanged(object sender, EventArgs e)
        {

        }


        

        private void jFlatButton1_Click(object sender, EventArgs e)
        {
            
        }
        private DocX CreateInvoiceFromTemplate(DocX template)
        {
            double ft = 0;
            ft = double.Parse((int.Parse(TongTien) - TongTienBanDau).ToString());


            template.AddCustomProperty(new CustomProperty("NgayTao", DateTime.Now.ToString()));
            template.AddCustomProperty(new CustomProperty("MaKH", txtMaKH.Text));
            template.AddCustomProperty(new CustomProperty("TenKH", txtTenKH.Text));
            template.AddCustomProperty(new CustomProperty("MaThue", txtMST.Text));
            template.AddCustomProperty(new CustomProperty("SĐT", cmbSDT.Text));
            template.AddCustomProperty(new CustomProperty("VAT", lblVAT2.Text));
            template.AddCustomProperty(new CustomProperty("TienThue", string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ",ft)));
            template.AddCustomProperty(new CustomProperty("TongHD", BangSo));
            template.AddCustomProperty(new CustomProperty("BangChu", BangChu));
            template.AddCustomProperty(new CustomProperty("KhachDua", lblKhachGui.Text));
            template.AddCustomProperty(new CustomProperty("TienThua", string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(TienThoi(jtxtTien.TextValue).ToString()))));
            template.AddCustomProperty(new CustomProperty("TongTA", string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(TongTienBanDau.ToString()))));

            var t = template.Tables[0];
            CreateAndInsertInvoiceTableAfter(t, ref template);
            t.Remove();
            return template;
        }

        private Table CreateAndInsertInvoiceTableAfter(Table t, ref DocX document)
        {
            BLChonMon BLCM = new BLChonMon();
            var data = BLCM.XuatHoaDonDo(MaHoaDon);

            Table invoiceTable = t.InsertTableAfterSelf(data.Rows.Count + 1, data.Columns.Count);



            invoiceTable.Rows[0].Cells[0].Paragraphs.First().Append("Tên Món").Bold();
            invoiceTable.Rows[0].Cells[1].Paragraphs.First().Append("Đơn Vị Tính").Bold();
            invoiceTable.Rows[0].Cells[2].Paragraphs.First().Append("Số Lượng").Bold();
            invoiceTable.Rows[0].Cells[3].Paragraphs.First().Append("Đơn Giá").Bold();
            invoiceTable.Rows[0].Cells[4].Paragraphs.First().Append("Thành Tiền").Bold();

            for (var row = 1; row < invoiceTable.RowCount; row++)
            {
                for (var cell = 0; cell < invoiceTable.ColumnCount; cell++)
                {
                    if (cell == 3 || cell == 4)
                    {
                        double gt = double.Parse(data.Rows[row - 1].ItemArray[cell].ToString().Trim());
                        invoiceTable.Rows[row].Cells[cell].Paragraphs.First().Append(string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt));

                    }
                    else
                        invoiceTable.Rows[row].Cells[cell].Paragraphs.First().Append(data.Rows[row - 1].ItemArray[cell].ToString().Trim());

                }
            }
            return invoiceTable;
        }

        private void txtBangChu_Click(object sender, EventArgs e)
        {
            
        }

        private void jFlatButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                BLChonMon BLCM = new BLChonMon();
                ReportHoaDon rp = new ReportHoaDon();
                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                BLQuanLyBan BLQLB = new BLQuanLyBan();
                BLQLKhach BLKH = new BLQLKhach();
                if (cmbSDT.Text != "" && txtMaKH.Text != "" && txtTenKH.Text != "" && txtMST.Text != "")
                {
                    if (txtMaKH.Text == BLKH.TaoMaKH())
                    {
                        BLKH.ThemKH(cmbSDT, txtMaKH, txtTenKH, txtMST);
                    }
                }
                if (chkHDD.Checked == false)
                {
                    //BLCM.CapNhatPhieu(MaHoaDon, int.Parse(TongTien), ref err);
                    BLQLB.CapNhatBan(TenBan, "1", ref err);

                    rp.DataSource = BLCM.XuatBill(MaHoaDon);
                    rp.BangChu = BangChu;
                    rp.BangSo = BangSo;
                    rp.VAT = lblVAT2.Text;
                    rp.TienBanDau = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTienBanDau);
                    //rp.TienThoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TienThoi(jtxtTien.TextValue));
                    //rp.TienKhachGui = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", int.Parse(jtxtTien.TextValue));
                    rp.HoaDonTamTinh = "Hóa Đơn Tạm Tính";
                    string rpPath = "HoaDonTamTinh\\" + "HD " + MaHoaDon + ".pdf";
                    if (File.Exists(rpPath))
                    {
                        File.Delete(rpPath);
                        rp.ExportToPdf(rpPath);
                        System.Diagnostics.Process.Start(rpPath);
                    }
                    else
                    {
                        rp.ExportToPdf(rpPath);
                        System.Diagnostics.Process.Start(rpPath);
                    }

                    this.Close();
                }

                else
                {
                    string rpPath = "HoaDonTamTinh\\" + "HD " + MaHoaDon + ".pdf";
                    string docxPath = "XuatFileHoaDonDo.docx";
                    DocX gDoc;
                    if (File.Exists(@"HoaDonDo.docx"))
                    {
                        gDoc = CreateInvoiceFromTemplate(DocX.Load(@"HoaDonDo.docx"));
                        gDoc.SaveAs(@"XuatFileHoaDonDo.docx");
                        if (File.Exists(rpPath))
                        {
                            File.Delete(rpPath);

                            WordDocument wordDocument = new WordDocument(docxPath, FormatType.Docx);
                            DocToPDFConverter converter = new DocToPDFConverter();
                            PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);
                            converter.Dispose();
                            wordDocument.Close();
                            pdfDocument.Save(rpPath);
                            pdfDocument.Close(true);
                            System.Diagnostics.Process.Start(rpPath);
                        }
                        else
                        {
                            WordDocument wordDocument = new WordDocument(docxPath, FormatType.Docx);
                            DocToPDFConverter converter = new DocToPDFConverter();
                            PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);
                            converter.Dispose();
                            wordDocument.Close();
                            pdfDocument.Save(rpPath);
                            pdfDocument.Close(true);
                            System.Diagnostics.Process.Start(rpPath);
                        }
                    }
                    else
                    {
                        BLTB.Show("Không có file HoaDonDo.docx");
                    }

                    BLQLB.CapNhatBan(TenBan, "1", ref err);
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
