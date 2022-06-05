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
    class BLKhuVuc
    {
        public void LayKhuVuc(DataGridView dgv)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var kv =
            from p in ql.KHUVUCs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Khu Vực");
            dt.Columns.Add("Tên Khu Vực");
            foreach (var p in kv)
            {
                dt.Rows.Add(p.MaKV.Trim(),p.TenKV.Trim());
            }
            dgv.DataSource = dt;
        }
        
        public bool ThemKhuVuc(string MaKV, string TenKV, ref string err)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            KHUVUC kv = new KHUVUC();
            kv.MaKV = MaKV;
            kv.TenKV = TenKV;
            
            ql.KHUVUCs.Add(kv);
            ql.SaveChanges();
            return true;
        }
        public bool XoaKhuVuc(string MaKV, ref string err)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            KHUVUC kv = new KHUVUC();
            kv.MaKV = MaKV;
            ql.KHUVUCs.Attach(kv);
            ql.KHUVUCs.Remove(kv);
            ql.SaveChanges();
            return true;
        }
        public bool CapNhatKhuVuc(string MaKV, string TenKV, ref string err)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var kv = (from a in ql.KHUVUCs
                      where a.MaKV == MaKV
                      select a).SingleOrDefault();
            if (kv != null)
            {
                //nv.MaNV = MaNV;
                kv.TenKV = TenKV;
                ql.SaveChanges();
            }
            return true;
        }
        public string TaoMaKV()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.KHUVUCs
                     select new { x.MaKV };
            foreach (var a in ds)
            {
                if (int.Parse(a.MaKV.ToString().Trim().Substring(2)) > str)
                {
                    str = int.Parse(a.MaKV.ToString().Trim().Substring(2));
                }
            }
            return "KV" + (str + 1);
        }
    }
}
