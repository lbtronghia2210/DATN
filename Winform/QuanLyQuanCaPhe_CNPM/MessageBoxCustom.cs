using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class MessageBoxCustom : Form
    {
        public string thongBao { get; set; }
        public MessageBoxCustom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MessageBoxCustom_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = thongBao;
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
