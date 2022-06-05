using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLNguyenLieu
    {
        public void LayNguyenLieu(DataGridView dgv)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var nl = from p in qlcf.NGUYENLIEUx
                     select p;
                        
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nguyên Liệu");
            dt.Columns.Add("Tên Nguyên Liệu");
            dt.Columns.Add("Đơn Vị Tính");
            dt.Columns.Add("Số Lượng Còn");
            foreach (var p in nl)
            {
                dt.Rows.Add(p.MaNL.Trim(), p.TenNL.Trim(),p.DVT.Trim(),p.SoLuong.ToString().Trim());
            }
            dgv.DataSource = dt;
        }
        public bool ThemNguyenLieu(string MaNL, string TenNL, string DVT, string SoLuong, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            NGUYENLIEU nl = new NGUYENLIEU();
            nl.MaNL = MaNL;
            nl.TenNL = TenNL;
            nl.DVT = DVT;
            nl.SoLuong = int.Parse(SoLuong);
            
            qlcfEntity.NGUYENLIEUx.Add(nl);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaNguyenLieu(ref string err, string MaNL)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            NGUYENLIEU nl = new NGUYENLIEU();
            nl.MaNL = MaNL;
            qlcfEntity.NGUYENLIEUx.Attach(nl);
            qlcfEntity.NGUYENLIEUx.Remove(nl);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool CapNhatNguyenLieu(string MaNL, string TenNL, string DVT, string SoLuong, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var nl = (from a in qlcfEntity.NGUYENLIEUx
                      where a.MaNL == MaNL
                      select a).SingleOrDefault();
            if (nl != null)
            {
                //td.MaMon = MaMon;
                nl.TenNL = TenNL;
                nl.TenNL = TenNL;
                nl.DVT = DVT;
                nl.SoLuong =int.Parse(SoLuong);
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public string TaoMaNguyenLieu()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.NGUYENLIEUx
                     select new { x.MaNL };
            foreach (var a in ds)
            {
                if (int.Parse(a.MaNL.ToString().Trim().Substring(2)) > str)
                {
                    str = int.Parse(a.MaNL.ToString().Trim().Substring(2));
                }
            }
            return "NL" + (str + 1);
        }
    }
}
