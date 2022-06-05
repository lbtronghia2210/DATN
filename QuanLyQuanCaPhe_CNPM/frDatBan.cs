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
    public partial class frDatBan : Form
    {
        public frDatBan()
        {
            InitializeComponent();
        }
        public string MaBanDangChon { get; set; }
        BLThongBao BLTB = new BLThongBao();
        BLFormOrder BLOD = new BLFormOrder();
        private void jFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            try
            {
                if(BLOD.KiemTra(txtTen.TextValue,txtSdt.TextValue,txtGio.TextValue) ==0)
                {
                    BLTB.Show("Phải Điền Đầy Đủ Thông Tin");
                }
                else
                {
                    CapNhat();
                }
                
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void FormOrder_Load(object sender, EventArgs e)
        {
            txtGio.Font = new Font("Tahoma", 12.0f);
            txtSdt.Font = new Font("Tahoma", 12.0f);
            txtTen.Font = new Font("Tahoma", 12.0f);
        }
        public void CapNhat()
        {
            
            string str = txtTen.TextValue + "---" + txtSdt.TextValue + "---" + txtGio.TextValue;
            BLOD.ThemThongTinOrder(MaBanDangChon,str);
            BLTB.Show("Đạt Thành Công: "+ str);
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_Load(object sender, EventArgs e)
        {

        }

        private void txtGio_Load(object sender, EventArgs e)
        {

        }

        private void txtTen_Load(object sender, EventArgs e)
        {

        }
    }
}
