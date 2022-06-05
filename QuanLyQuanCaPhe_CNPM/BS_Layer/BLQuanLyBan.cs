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
    class BLQuanLyBan
    {
        public bool CapNhatBan(string MaBan, string TenBan, int songuoi, string MaKV, string trangThai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Ban = (from a in qlcfEntity.BANs
                       where a.MaBan == MaBan
                       select a).SingleOrDefault();
            if (Ban != null)
            {
                //nv.MaNV = MaNV;
                Ban.TenBan = TenBan;
                Ban.SoChoNgoi = songuoi;
                Ban.MaKV = MaKV;
                Ban.TrangThai = trangThai;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public bool CapNhatBan(string MaBan,string trangThai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Ban = (from a in qlcfEntity.BANs
                       where a.MaBan == MaBan
                       select a).SingleOrDefault();
            if (Ban != null)
            {
                //nv.MaNV = MaNV;
                //Ban.TenBan = TenBan;
                //Ban.SoChoNgoi = songuoi;
                //Ban.MaKV = MaKV;
                Ban.TrangThai = trangThai;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public bool ThemBan(string MaBan, string TenBan, int songuoi, string MaKV, string trangThai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            BAN b = new BAN();
            b.MaBan = MaBan;
            b.TenBan = TenBan;
            b.SoChoNgoi = songuoi;
            b.MaKV = MaKV;
            b.TrangThai = trangThai;
            qlcfEntity.BANs.Add(b);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaBan(ref string err, string MaBan)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            BAN b = new BAN();
            b.MaBan = MaBan;
            qlcfEntity.BANs.Attach(b);
            qlcfEntity.BANs.Remove(b);
            qlcfEntity.SaveChanges();
            return true;
        }
        public void LayBan(string MaBanHienTai, TextEdit txtMaBan, TextEdit txtTenBan, TextEdit SoChoNgoi, TextEdit txtMaKV, ComboBoxEdit txtTenKV, TextEdit txtTrangThai)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var ban = (from p in qlcfEntity.BANs
                      join q in qlcfEntity.KHUVUCs on p.MaKV equals q.MaKV
                      select new
                      {
                          p.MaBan,
                          p.TenBan,
                          p.SoChoNgoi,
                          p.MaKV,
                          q.TenKV,
                          p.TrangThai
                      }).ToList();
            foreach (var p in ban)
            {
                if(p.MaBan.Trim() ==MaBanHienTai.Trim())
                {
                    txtMaBan.Text = p.MaBan.Trim();
                    txtTenBan.Text = p.TenBan.Trim();
                    SoChoNgoi.Text = p.SoChoNgoi.ToString().Trim();
                    txtMaKV.Text = p.MaKV.Trim();
                    txtTenKV.Text = p.TenKV.Trim();
                    if (p.TrangThai.Trim() == "0")
                    {
                        txtTrangThai.Text = "Không Có Khách";
                    }
                    else
                    {
                        txtTrangThai.Text = "Đã Có Khách";
                    }
                }
            }    
        }
        public void LayTenKhuVuc(ComboBoxEdit cmbTenKV)
        {
            for (int i = cmbTenKV.Properties.Items.Count - 1; i >= 0; i--)
            {
                cmbTenKV.Properties.Items.RemoveAt(i);
            }
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var chon = from p in qlcf.KHUVUCs
                       group p by p.TenKV into g
                       select new
                       {
                           TenLoai = g.Key
                       };
            foreach (var p in chon)
            {
                cmbTenKV.Properties.Items.Add(p.TenLoai.Trim());
            }
        }
        public void LayMaKV(ComboBoxEdit TenKV, TextEdit txtMaKV)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var makV = (from x in qlcf.KHUVUCs
                    where x.TenKV.Trim() == TenKV.Text
                    select new { x.MaKV }).ToList();
            foreach( var a in makV)
            {
                txtMaKV.Text = a.MaKV;
            }
        }
        public string LayTrangThai(string MaBan)
        {
            string tt = "";
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var trangthai = (from x in qlcf.BANs
                             where x.MaBan.Trim() == MaBan
                            select new { x.TrangThai }).ToList();
            foreach (var a in trangthai)
            {
                tt = a.TrangThai;
            }
            return tt.Trim();
        }
        public void XoaHet(TabControl TabPDSBan)
        {
            try
            {
                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                for (int i = BLXTT.TimSoTang() - 1; i >= 0; i--)
                    TabPDSBan.Controls.RemoveAt(i);
            }
            catch
            {

            }
        }
        public string TaoMaBan()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.BANs
                     select new { x.MaBan };
            foreach (var a in ds)
            {
                if (int.Parse(a.MaBan.ToString().Trim().Substring(1)) > str)
                {
                    str = int.Parse(a.MaBan.ToString().Trim().Substring(1));
                }
            }
            return "B" + (str + 1);
        }
    }
}
