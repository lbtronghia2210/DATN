using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLQLKhach
    {
        public void ThemKH(ComboBoxEdit cmbsdt, TextEdit MaKH, TextEdit TenKH, TextEdit MaSoThue)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            KHACHHANG KH = new KHACHHANG();
            KH.SDT = cmbsdt.Text;
            KH.MaKH = MaKH.Text;
            KH.TenKH = TenKH.Text;
            KH.MaThue = MaSoThue.Text;
            ql.KHACHHANGs.Add(KH);
            ql.SaveChanges();

            //foreach (var i in ds)
            //{
            //    cmb.Properties.Items.Add(i.SDT.Trim());
            //}
        }
        public void LayKhach(ComboBoxEdit cmb)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = (from i in ql.KHACHHANGs
                      where i.SDT!=null
                     select new { i.SDT }).ToList();
            //MessageBox.Show(""+ds.Count);
            for (int i = cmb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cmb.Properties.Items.RemoveAt(i);
            }
            foreach (var i in ds)
            {
                cmb.Properties.Items.Add(i.SDT.Trim());
            }
            
            //foreach (var i in ds)
            //{
            //    cmb.Properties.Items.Add(i.SDT.Trim());
            //}
        }
        public void LayThongTin(ComboBoxEdit cmb, TextEdit MAKH, TextEdit TenKH, TextEdit MaThue)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = (from i in ql.KHACHHANGs
                      where i.SDT != null && i.SDT==cmb.Text
                      select  i ).ToList();
            //MessageBox.Show(""+ds.Count);
            
            if(ds.Count!=0)
            {
                foreach(var a in ds)
                {
                    MAKH.Text = a.MaKH;
                    TenKH.Text = a.TenKH;
                    MaThue.Text = a.MaThue;
                    return;
                }
            }
            else
            {
                MAKH.Text= TaoMaKH();
                TenKH.Text = "";
                MaThue.Text = "";
            }
        }
        public string TaoMaKH()
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = (from i in ql.KHACHHANGs
                      select new { i.MaKH}).ToList();
            int max = 0;

            foreach(var a in ds)
            {
                if(int.Parse(a.MaKH.Trim().Substring(2)) >max)
                {
                    max = int.Parse(a.MaKH.Substring(2));
                }
            }
            return "KH"+(max + 1).ToString();
        }
        public DataTable layKhach()
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var khs =
            from p in qlcfEntities.KHACHHANGs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Khách");
            dt.Columns.Add("Tên Khách");
            dt.Columns.Add("Số Điện Thoại");
            dt.Columns.Add("Mã Số Thuế");
            foreach (var p in khs)
            {
                if (p.MaKH == null)
                    p.MaKH = " ";
                if (p.TenKH == null)
                    p.TenKH = " ";
                if (p.SDT == null)
                    p.SDT = " ";
                if (p.MaThue == null)
                    p.MaThue = " ";
                dt.Rows.Add(p.MaKH.Trim(), p.TenKH.Trim(), p.SDT.Trim(), p.MaThue.Trim());
            }
            return dt;
        }
        
        public bool themKH(string maKH,string tenKH, string SDT, string maThue, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = maKH;
            kh.TenKH = tenKH;
            kh.SDT = SDT;
            kh.MaThue = maThue;
            qlcfEntities.KHACHHANGs.Add(kh);
            qlcfEntities.SaveChanges();
            return true;
        }
        public bool xoaKH(ref string err, string maKH)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = maKH;
            qlcfEntities.KHACHHANGs.Attach(kh);
            qlcfEntities.KHACHHANGs.Remove(kh);
            qlcfEntities.SaveChanges();
            return true;
        }
        public bool capNhatKhach(string maKH, string tenKH, string SDT, string maThue, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var kh = (from a in qlcfEntities.KHACHHANGs
                      where a.MaKH ==maKH
                      select a).SingleOrDefault();
            if (kh != null)
            {
                //nv.MaNV = MaNV;
                kh.TenKH = tenKH;
                kh.SDT = SDT;
                kh.MaThue = maThue;
                
                qlcfEntities.SaveChanges();
            }
            return true;
        }
        
    }
}
