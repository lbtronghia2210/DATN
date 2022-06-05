using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLChotCa
    {
        //public bool ThemHD(string HD, DateTime Ngay, int TongTien)
        //{
        //    QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
        //    BANGPHU p = new BANGPHU();
        //    p.HD = HD;
        //    p.TongTien = TongTien;
        //    p.Ngay = Ngay;
        //    qlcfEntity.BANGPHUs.Add(p);
        //    qlcfEntity.SaveChanges();
        //    return true;
        //}
        //public bool XoaHD(string HD)
        //{
        //    QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
        //    BANGPHU p = new BANGPHU();
        //    p.HD = HD;
        //    qlcfEntity.BANGPHUs.Attach(p);
        //    qlcfEntity.BANGPHUs.Remove(p);
        //    qlcfEntity.SaveChanges();
        //    return true;
        //}
        public bool ThemChot(DateTime Ngay, string Lan, int TongTien, string MaNV)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            CHOTCA p = new CHOTCA();
            p.Lan = Lan;
            p.Ngay = Ngay;
            p.TongTien = TongTien;
            p.MaNV = MaNV;
            qlcfEntity.CHOTCAs.Add(p);
            qlcfEntity.SaveChanges();
            return true;
        }
        public string DoanhThu()
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var dt = from i in ql.HDONs
                     where i.NgayTao.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10)
                     select i;
            var sum = dt.ToList().Select(c => c.TongTien).Sum().ToString();
            return sum;
        }
        //public string DoanhThuChotCa()
        //{
        //    QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
        //    var dt = from i in ql.CHOTCAs
        //             where i.Ngay.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10)
        //             select i;
        //    var sum = dt.ToList().Select(c => c.TongTien).Sum().ToString();
        //    return sum;
        //}
        //public void XoaHetDoanhThu()
        //{
        //    QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
        //    var ds = from i in ql.BANGPHUs
        //             select new { i.HD };
        //    foreach (var x in ds)
        //    {
        //        XoaHD(x.HD);
        //    }
        //}
        public int LayMax()
        {
            int max = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from i in ql.CHOTCAs
                     where i.Ngay.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10)
                     select new { i.Lan };
            foreach (var x in ds)
            {
                if(int.Parse(x.Lan.Trim())>max)
                {
                    max = int.Parse(x.Lan.Trim());
                }
            }
            return max + 1;
        }
        public string LayChotCaGanNhat()
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = (from c in ql.CHOTCAs
                       where c.Ngay.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10)
                       select new { c.Lan });
            int max = 0;
            foreach (var a in ds)
            {
                if(int.Parse(a.Lan) >max)
                {
                    max = int.Parse(a.Lan);
                }
            }
            var ds2 = from c in ql.CHOTCAs
                      join d in ql.NHANVIENs on c.MaNV equals d.MaNV
                      where c.Ngay.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10) && c.Lan == max.ToString()
                      select new { d.HoTen,c.TongTien };
            foreach(var x in ds2)
            {
                string tien = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(x.TongTien.ToString()));

                return x.HoTen.Trim() + " (" + tien + ")";
            }
            return "";
        }
    }
}
