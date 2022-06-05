using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLThongBao
    {
        public void Show(string ThongBao)
        {
            MessageBoxCustom msg = new MessageBoxCustom();
            msg.thongBao = ThongBao;
            msg.ShowDialog();
        }
    }
}
