using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class ReportDoanhThu : DevExpress.XtraReports.UI.XtraReport
    {
        public string TongDoanhThu { get; set; }
        public string TieuDe { get; set; }
        public ReportDoanhThu()
        {
            InitializeComponent();
        }

        private void reportFooterBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTong.Text = TongDoanhThu;
        }

        private void reportFooterBand1_AfterPrint(object sender, EventArgs e)
        {

        }

        private void reportHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTieuDe.Text = TieuDe;
        }
    }
}
