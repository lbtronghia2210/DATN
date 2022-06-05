using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class ReportTinhLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportTinhLuong()
        {
            InitializeComponent();
        }
        public string TongLuong { get; set; }

        private void reportFooterBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTongLuong.Text = TongLuong;
        }
    }
}
