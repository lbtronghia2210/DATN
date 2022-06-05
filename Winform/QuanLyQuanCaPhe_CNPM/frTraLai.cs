using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frTraLai : DevExpress.XtraEditors.XtraForm
    {
        BLTraLai BLTL = new BLTraLai();
        BLChonMon BLCM = new BLChonMon();
        BLThongBao BLTB = new BLThongBao();
        public string MaBanDangChon { get; set; }
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public string SL { get; set; }
        public frTraLai()
        {
            InitializeComponent();
        }

        private void frTraLai_Load(object sender, EventArgs e)
        {
            try {
                lblTenMon.Text = TenMonAn.Trim();
                lblSL.Text = SL.Trim();
            }
            catch
            {

            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int check =BLTL.TraLai(BLCM.LayMaHoaDon(MaBanDangChon), MaMonAn, int.Parse(numSLTra.Value.ToString()));
                if (check == 1)
                    this.Close();
            }
            catch
            {

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
