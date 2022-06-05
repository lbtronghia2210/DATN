using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLQuanLyLoaiMon
    {
        public DataTable LayLoaiMon()
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var tps =
            from p in qlcfEntity.LOAIMONs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Loại");
            dt.Columns.Add("Tên Loại");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaLoai.Trim(), p.TenLoai.Trim());
            }
            return dt;
        }
        public bool ThemLoaiMon(string MaLoai, string TenLoai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            LOAIMON lm = new LOAIMON();
            lm.MaLoai = MaLoai;
            lm.TenLoai = TenLoai;
            qlcfEntity.LOAIMONs.Add(lm);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaLoaiMon(ref string err, string MaLoai)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            LOAIMON lm = new LOAIMON();
            lm.MaLoai = MaLoai;
            qlcfEntity.LOAIMONs.Attach(lm);
            qlcfEntity.LOAIMONs.Remove(lm);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool CapNhatLoaiMon(string MaLoai, string TenLoai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var lm = (from a in qlcfEntity.LOAIMONs
                      where a.MaLoai == MaLoai
                      select a).SingleOrDefault();
            if (lm != null)
            {
                //nv.MaNV = MaNV;
                lm.TenLoai = TenLoai;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public void TaoTenMon( ComboBoxEdit cmbTimKiem)
        {
            for (int i = cmbTimKiem.Properties.Items.Count - 1; i >= 0; i--)
            {
                cmbTimKiem.Properties.Items.RemoveAt(i);
            }
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var chon = from p in qlcf.LOAIMONs
                       group p by p.TenLoai into g
                       select new
                       {
                           TenLoai = g.Key
                       };
            foreach (var p in chon)
            {
                cmbTimKiem.Properties.Items.Add(p.TenLoai.Trim());
            }
        }
        public void TimKiem(ComboBoxEdit cmbTimKiem, DataGridView dgvTimKiem)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var monan = (from p in qlcf.THUCDONs
                         join q in qlcf.LOAIMONs on p.MaLoai equals q.MaLoai
                         where q.TenLoai == cmbTimKiem.SelectedItem.ToString()
                         select new
                         {
                             Mamon = p.MaMon,
                             Tenmon = p.TenMon,
                             Donvi = p.DVT,
                             Gia = p.DonGia,
                             Tenloaimon = q.TenLoai
                         }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Món");
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("Đơn Vị Tính");
            dt.Columns.Add("Giá");
            dt.Columns.Add("Tên Loại Món");
            foreach (var p in monan)
            {
                dt.Rows.Add(p.Mamon.Trim(), p.Tenmon.Trim(), p.Donvi.ToString().Trim(), p.Gia.ToString().Trim(), p.Tenloaimon.Trim());
            }
            dgvTimKiem.DataSource = dt;
        }
        public string TaoMaLoai()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.LOAIMONs
                     select new { x.MaLoai };
            foreach (var a in ds)
            {
                if (int.Parse(a.MaLoai.ToString().Trim().Substring(2)) > str)
                {
                    str = int.Parse(a.MaLoai.ToString().Trim().Substring(2));
                }
            }
            return "LM" + (str + 1);
        }
    }
}

