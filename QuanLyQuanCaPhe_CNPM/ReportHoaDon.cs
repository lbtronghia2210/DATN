using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class ReportHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportHoaDon()
        {
            InitializeComponent();
        }
        public string BangChu { get; set; }
        public string BangSo { get; set; }
        public string TienThoi { get;set; }
        public string TienKhachGui { get; set; }
        public string VAT { get; set; }
        public string TienBanDau { get; set; }
        public string HoaDonTamTinh { get; set; }
        private void reportFooterBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void txtBangChu_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void reportFooterBand1_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTT2.Text =BangChu;
            lblTien.Text = BangSo;
            lblTienThoi.Text = TienThoi;
            lblKhachGui.Text = TienKhachGui;
            lblVAT.Text = VAT;
            lblTongTienThucAn.Text = TienBanDau;
        }

        private void reportFooterBand1_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void lblDiaChi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (HoaDonTamTinh == "Hóa Đơn Tạm Tính")
            {
                this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 14F,FontStyle.Bold);
                this.lblDiaChi.LocationFloat = new DevExpress.Utils.PointFloat(108.3526F, 219F);
                this.lblDiaChi.Multiline = true;
                this.lblDiaChi.Name = "lblDiaChi";
                this.lblDiaChi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                this.lblDiaChi.SizeF = new System.Drawing.SizeF(456.6249F, 38.83333F);
                this.lblDiaChi.StylePriority.UseFont = false;
                this.lblDiaChi.StylePriority.UseTextAlignment = false;
                this.lblDiaChi.Text = "Hóa Đơn Tạm Tính";
                this.lblDiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            }
            else
            {
                this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 11F);
                this.lblDiaChi.LocationFloat = new DevExpress.Utils.PointFloat(108.3526F, 219F);
                this.lblDiaChi.Multiline = true;
                this.lblDiaChi.Name = "lblDiaChi";
                this.lblDiaChi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                this.lblDiaChi.SizeF = new System.Drawing.SizeF(456.6249F, 38.83333F);
                this.lblDiaChi.StylePriority.UseFont = false;
                this.lblDiaChi.StylePriority.UseTextAlignment = false;
                this.lblDiaChi.Text = "Địa Chỉ: 81 - Hoàng Diệu 2 - Linh Trung - Thủ Đức - HCM\r\nSĐT: 0326492266\tEmail: h" +
        "erokim36@gmail.com";
                this.lblDiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            }
        }
    }
}
