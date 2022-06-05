using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraReports.UI;
using QuanLyQuanCaPhe_CNPM.BS_Layer;
using System.IO;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frRPLuong : DevExpress.XtraEditors.XtraForm
    {
        public frRPLuong()
        {
            InitializeComponent();
        }
        BLTinhLuong BLTL = new BLTinhLuong();
        private void FormTinhLuong_Load(object sender, EventArgs e)
        {
            DateTime day = System.DateTime.Now;
            cmbThang.Text = day.Month.ToString();
            cmbNam.Text = day.Year.ToString();
            BLDesign BLDS = new BLDesign();
            BLDS.DesignDgv(dgvLuong);
        }

        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLTinhLuong BLTL = new BLTinhLuong();
                BLTL.LayLuong(dgvLuong, cmbThang, cmbNam,lblTongLuong);
                lblTieuDe.Text = "Lương Của Nhân Viên Trong Tháng " + cmbThang.Text + " Năm " + cmbNam.Text;
            }
            catch
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReportTinhLuong rp = new ReportTinhLuong();
            rp.TongLuong = lblTongLuong.Text;
            rp.DataSource = BLTL.XuatLuong(cmbThang, cmbNam);

            string rpPath = "TinhLuong\\" + "ThongKeLuong_"+cmbThang.Text+"_"+cmbNam.Text + ".pdf";
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
        }
    }
}
