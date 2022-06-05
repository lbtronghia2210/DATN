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
    public partial class frDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frDoiMK()
        {
            InitializeComponent();
        }
        public string TenDN { get; set; }
        BLDoiMatKhau BLDMK = new BLDoiMatKhau();
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BLDMK.DoiMK(TenDN, txtMatKhauCu, txtMatKhauMoi, txtXacNhanMatKhau,this);
            }
            catch
            {

            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
