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

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    public partial class FrChiTietSoLuong : Form
    {
        public FrChiTietSoLuong()
        {
            InitializeComponent();
        }
        BLChiTietSoLuong BLCTSL = new BLChiTietSoLuong();
        BLDesign BLDS = new BLDesign();
        public string maMonDangChon { get; set; }
        private void ChiTietSoLuong_Load(object sender, EventArgs e)
        {
            try
            {
                BLCTSL.LayChiTiet(dgvChiTietSoLuong, maMonDangChon);
                foreach (DataGridViewRow Myrow in dgvChiTietSoLuong.Rows)
                {
                    if (Myrow.Cells[4].Value.ToString() == "Hết sạch")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (Myrow.Cells[4].Value.ToString() == "Sắp hết")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }

            }
            catch
            {

            }
          
        }
    }
}
