using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLCongThuc
    {
        public bool ThemCT(string MaMon, string HamLuong, ComboBoxEdit cmbTenNL)
        {
            string a = layMaNL(cmbTenNL.Text);
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            CONGTHUC ct = new CONGTHUC();
            ct.MaMon = MaMon;
            ct.MaNL = a;
            ct.HamLuong = HamLuong;
            ql.CONGTHUCs.Add(ct);
            ql.SaveChanges();
            return true;
        }
        public bool XoaCT(string MaMon, string MaNL)
        {
           
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            CONGTHUC ct = new CONGTHUC();
            ct.MaMon = MaMon;
            ct.MaNL = MaNL;
            ql.CONGTHUCs.Attach(ct);
            ql.CONGTHUCs.Remove(ct);
            ql.SaveChanges();
            return true;
        }
        public string layMaNL(string TenNL)
        {
            string st = "";
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var Ma = (from i in qlcf.NGUYENLIEUx
                      where i.TenNL == TenNL
                      select new { i.MaNL }).ToList();
            foreach (var a in Ma)
            {
                st = a.MaNL;
            }
            return st;
        }
        public void timCT(DataGridView dgvCongThuc, string MaMon)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var ct = from p in qlcf.THUCDONs
                     join q in qlcf.CONGTHUCs on p.MaMon equals q.MaMon
                     where p.MaMon == MaMon
                     select new { q.MaNL, q.HamLuong };
            var a = from p in ct
                    join c in qlcf.NGUYENLIEUx on p.MaNL equals c.MaNL
                    select new { p.MaNL, c.TenNL, p.HamLuong, c.DVT };
            DataTable dt = new DataTable();
            //dt.Columns.Add("Mã Nguyên Liệu");
            dt.Columns.Add("Tên Nguyên Liệu");
            dt.Columns.Add("Hàm Lượng");
            dt.Columns.Add("Đơn Vị Tính");
            foreach (var c in a)
            {
                dt.Rows.Add(c.TenNL.Trim(), c.HamLuong.Trim(),c.DVT.Trim());
            }
            dgvCongThuc.DataSource = dt;
        }
        public void timCT2(DataGridView dgvCongThuc, string MaMon)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var ct = from p in qlcf.THUCDONs
                     join q in qlcf.CONGTHUCs on p.MaMon equals q.MaMon
                     where p.MaMon == MaMon
                     select new { q.MaNL, q.HamLuong };
            var a = from p in ct
                    join c in qlcf.NGUYENLIEUx on p.MaNL equals c.MaNL
                    select new { p.MaNL, c.TenNL, p.HamLuong, c.DVT };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nguyên Liệu");
            dt.Columns.Add("Tên Nguyên Liệu");
            dt.Columns.Add("Hàm Lượng");
            dt.Columns.Add("Đơn Vị Tính");
            foreach (var c in a)
            {
                dt.Rows.Add(c.MaNL.Trim(), c.TenNL.Trim(), c.HamLuong.Trim(), c.DVT.Trim());
            }
            dgvCongThuc.DataSource = dt;
        }
        public void LayTenNguyenLieu(ComboBoxEdit cmbTenNL)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tennl = (from x in qlcf.NGUYENLIEUx
                         select new { x.TenNL } ).ToList();
            //for (int i = cmbTenNL.Properties.Items.Count - 1; i >= 0; i--)
            //{
            //    cmbTenNL.Properties.Items.RemoveAt(i);
            //}
            cmbTenNL.Properties.Items.Clear();
            foreach (var a in tennl)
            {
                cmbTenNL.Properties.Items.Add(a.TenNL.Trim());
            }
        }
        public void LayTenMonAn(ComboBoxEdit cmb)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tennl = (from x in qlcf.THUCDONs
                         select new { x.TenMon }).ToList();
            //for (int i = cmbTenNL.Properties.Items.Count - 1; i >= 0; i--)
            //{
            //    cmbTenNL.Properties.Items.RemoveAt(i);
            //}
            cmb.Properties.Items.Clear();
            foreach (var a in tennl)
            {
                cmb.Properties.Items.Add(a.TenMon.Trim());
            }
        }
        public void LayDonViTinh(LabelControl lbl, string TenNL)//
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var Ma = (from i in qlcf.NGUYENLIEUx
                      where i.TenNL == TenNL
                      select new { i.DVT }).ToList();
            foreach (var a in Ma)
            {
                lbl.Text = a.DVT.ToString();
                return;
            }
        }
        //public void LayHamLuong(ComboBoxEdit cmbHamLuong)
        //{
        //    QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
        //    var tennl = (from x in qlcf.CONGTHUCs
        //                 select new { x.HamLuong }).ToList();
        //    for (int i = cmbHamLuong.Properties.Items.Count - 1; i >= 0; i--)
        //    {
        //        cmbHamLuong.Properties.Items.RemoveAt(i);
        //    }
        //    foreach (var a in tennl)
        //    {
        //        cmbHamLuong.Properties.Items.Add(a.HamLuong);
        //    }
        //}
    }
}
