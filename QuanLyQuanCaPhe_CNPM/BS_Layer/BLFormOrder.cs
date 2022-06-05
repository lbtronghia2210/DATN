using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLFormOrder
    {
        string err="";
        public void ThemThongTinOrder(string MaBanDangChon, string TrangThai)
        {
            BLQuanLyBan BLQLB = new BLQuanLyBan();
            BLQLB.CapNhatBan(MaBanDangChon, TrangThai, ref err);
        }
        public int KiemTra(string Ten, string SDT, string Gio)
        {
            if (Ten == "Tên" || SDT == "Số Điện Thoại" || Gio == "Giờ" || Ten == "" || SDT == "" || Gio == "" )
                return 0;
            return 1;
        }
    }
}
