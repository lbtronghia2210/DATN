using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLQuanLyPhieu
    {
        public bool XoaPhieu(ref string err, string MaPhieu)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            HDON p = new HDON();
            p.MaHoaDon = MaPhieu;
            qlcfEntity.HDONs.Attach(p);
            qlcfEntity.HDONs.Remove(p);
            qlcfEntity.SaveChanges();
            return true;
        }
    }
}
