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
    class BLQuanLyThucDon
    {
        public void LayThucDon(DataGridView dgv)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            List<TD> listTD = new List<TD>();
            var monan = (from p in qlcf.THUCDONs
                         join q in qlcf.LOAIMONs on p.MaLoai equals q.MaLoai
                         select new
                         {
                            p.MaMon,
                            p.TenMon,
                            p.DVT,
                            p.DonGia,
                            q.TenLoai
                         }).ToList();

            foreach (var p in monan)
            {
                TD td = new TD();
                td.MaMon = p.MaMon.Trim();
                td.TenMon = p.TenMon.Trim();
                td.DVT = p.DVT.Trim();
                td.Gia = int.Parse(p.DonGia.ToString());
                td.TenLoaiMon = p.TenLoai.Trim();
                listTD.Add(td);
            }
            dgv.DataSource = listTD;
            dgv.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
            dgv.Columns[0].HeaderText = "Mã Món";
            dgv.Columns[1].HeaderText = "Tên Món";
            dgv.Columns[2].HeaderText = "ĐVT";
            dgv.Columns[3].HeaderText = "Giá";
            dgv.Columns[4].HeaderText = "Tên Loại Món";
        }
        public bool ThemThucDon(string MaMon, string TenMon, string DVT, int Gia, string MaLoai,string HinhAnh, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            THUCDON td = new THUCDON();
            td.MaMon = MaMon;
            td.TenMon = TenMon;
            td.DVT = DVT;
            td.DonGia = Gia;
            td.MaLoai = MaLoai;
            td.HinhAnh = HinhAnh;

            qlcfEntity.THUCDONs.Add(td);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaThucDon(ref string err, string MaMon)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            THUCDON td = new THUCDON();
            td.MaMon = MaMon;
            qlcfEntity.THUCDONs.Attach(td);
            qlcfEntity.THUCDONs.Remove(td);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool CapNhatThucDon(string MaMon, string TenMon, string DVT, int Gia, string MaLoai,string HinhAnh, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var td = (from a in qlcfEntity.THUCDONs
                      where a.MaMon == MaMon
                      select a).SingleOrDefault();
            if (td != null)
            {
                //td.MaMon = MaMon;
                td.TenMon = TenMon;
                td.DVT = DVT;
                td.DonGia = Gia;
                
                td.MaLoai = MaLoai;
                td.HinhAnh = HinhAnh;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public string LayMaMon(string TenLoaiMon)
        {
            string a = "";
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var mamon = (from x in qlcf.LOAIMONs
                        where x.TenLoai.Trim() == TenLoaiMon
                        select new { x.MaLoai }).ToList();
            if(mamon.Count!=0)
            {
                foreach(var i in mamon)
                {
                    a = i.MaLoai;
                }
            }
            return a;
        }
        public void loadTenMon(ComboBoxEdit cmbTenLoai)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tenmon = (from i in qlcf.LOAIMONs
                          select new {TenLoai= i.TenLoai }).ToList();
            foreach(var t in tenmon)
            {
                cmbTenLoai.Properties.Items.Add(t.TenLoai.Trim());
            }
        }
        public void reloadTenMon(ComboBoxEdit cmbTenLoai)
        {
            cmbTenLoai.Properties.Items.Clear();
            loadTenMon(cmbTenLoai);
        }
        public string TaoMaThucDon()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.THUCDONs
                     select new { x.MaMon };
            foreach (var a in ds)
            {
                if (int.Parse(a.MaMon.ToString().Trim().Substring(2)) > str)
                {
                    str = int.Parse(a.MaMon.ToString().Trim().Substring(2));
                }
            }
            return "MM" + (str + 1);
        }
        public class TD
        {
            public string MaMon { get; set; }
            public string TenMon { get; set; }
            public string DVT { get; set; }
            public int Gia { get; set; }
            public string TenLoaiMon { get; set; }
        }

    }
}
