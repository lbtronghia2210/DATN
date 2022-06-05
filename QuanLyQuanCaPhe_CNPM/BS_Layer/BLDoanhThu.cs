using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLDoanhThu
    {
        public string temp { get; set; }
        public void LayDoanhThuTrongNgay(DataGridView dgv, LabelControl lblSoHD, LabelControl lblTongTien  )
        {
            DateTime day = DateTime.Now.Date;
            List<HD> Lst = new List<HD>();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao == day
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            //
            dgv.DataSource = Lst;
            dgv.Columns[0].HeaderText = "Mã HĐ";
            dgv.Columns[1].HeaderText = "Ngày Tạo";
            dgv.Columns[2].HeaderText = "VAT";
            dgv.Columns[3].HeaderText = "Tổng Tiền";
            //
            double TongTien =double.Parse(ds.ToList().Select(c => c.TongTien).Sum().ToString());
            var TongHD = ds.Count();
            lblSoHD.Text = "Tổng Số Hóa Đơn: " + TongHD.ToString();
            lblTongTien.Text ="Tổng Doanh Thu: "+  string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }
       
        public void LayDoanhThuTrongThang(DataGridView dgv, LabelControl lblSoHD, LabelControl lblTongTien)
        {
            DateTime day = DateTime.Now.Date;
            List<HD> Lst = new List<HD>();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.Thang ==day.Month && x.Nam == day.Year
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            //
            dgv.DataSource = Lst;
            dgv.Columns[0].HeaderText = "Mã HĐ";
            dgv.Columns[1].HeaderText = "Ngày Tạo";
            dgv.Columns[2].HeaderText = "VAT";
            dgv.Columns[3].HeaderText = "Tổng Tiền";
            //
            double TongTien = double.Parse(ds.ToList().Select(c => c.TongTien).Sum().ToString());
            var TongHD = ds.Count();
            lblSoHD.Text = "Tổng Số Hóa Đơn: " + TongHD.ToString();
            lblTongTien.Text = "Tổng Doanh Thu: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }

        public void LayDoanhThuTrongTuan(DataGridView dgv, LabelControl lblSoHD, LabelControl lblTongTien)
        {
            DateTime today = DateTime.Now.Date;
            DateTime start = FirstDayOfWeek(today);
            List<HD> Lst = new List<HD>();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao >= start.Date && x.NgayTao <=today
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            //
            dgv.DataSource = Lst;
            dgv.Columns[0].HeaderText = "Mã HĐ";
            dgv.Columns[1].HeaderText = "Ngày Tạo";
            dgv.Columns[2].HeaderText = "VAT";
            dgv.Columns[3].HeaderText = "Tổng Tiền";
            //
            double TongTien = double.Parse(ds.ToList().Select(c => c.TongTien).Sum().ToString());
            var TongHD = ds.Count();
            lblSoHD.Text = "Tổng Số Hóa Đơn: " + TongHD.ToString();
            lblTongTien.Text = "Tổng Doanh Thu: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }
        public void LayDoanhThuTrongKhoang(DataGridView dgv,DateTime start, DateTime end, LabelControl lblSoHD, LabelControl lblTongTien)
        {
            int cmp = DateTime.Compare(start, end);
            DateTime s;
            DateTime e;
            if (cmp < 0)
            {
                s = start;
                e = end;
            }
            else if (cmp > 0)
            {
                s = end;
                e = start;
            }
            else
            {
                s = start;
                e = end;
            }
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            List<HD> Lst = new List<HD>();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao >= s && x.NgayTao <= e
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            //
            dgv.DataSource = Lst;
            dgv.Columns[0].HeaderText = "Mã HĐ";
            dgv.Columns[1].HeaderText = "Ngày Tạo";
            dgv.Columns[2].HeaderText = "VAT";
            dgv.Columns[3].HeaderText = "Tổng Tiền";
            //
            double TongTien = double.Parse(ds.ToList().Select(c => c.TongTien).Sum().ToString());
            var TongHD = ds.Count();
            lblSoHD.Text = "Tổng Số Hóa Đơn: " + TongHD.ToString();
            lblTongTien.Text = "Tổng Doanh Thu: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }

        public DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;  
        }
        public List<HD> XuatDoanhThuTheoNgay()
        {
            List<HD> Lst = new List<HD>();
            DateTime day = DateTime.Now.Date;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao == day
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            temp = "HomNay_"+day.Day.ToString() + "_" + day.Month.ToString() + "_" + day.Year.ToString();
            return Lst;
            
        }
        public List<HD> XuatDoanhThuTrongTuan()
        {
            List<HD> Lst = new List<HD>();
            DateTime today = DateTime.Now.Date;
            DateTime start = FirstDayOfWeek(today);
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao >= start.Date && x.NgayTao <= today
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            temp = "TuanNay_"+start.Day.ToString() + "_" + start.Month.ToString() + "_" + start.Year.ToString()+"-"+today.Day.ToString() + "_" + today.Month.ToString() + "_" + today.Year.ToString();
            return Lst;
            
        }
        public List<HD> XuatDoanhThuTrongThang()
        {
            List<HD> Lst = new List<HD>();
            DateTime day = DateTime.Now.Date;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.Thang == day.Month && x.Nam == day.Year
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);  
            }
            temp = "ThangNay_" + day.Month.ToString()+"_"+day.Year.ToString();
            return Lst;
        }
        public List<HD> XuatDoanhThuTrongKhoang(DateTime start, DateTime end)
        {
            List<HD> Lst = new List<HD>();
            int cmp = DateTime.Compare(start, end);
            DateTime s;
            DateTime e;
            if(cmp<0)
            {
                s = start;
                e = end;
            }
            else if(cmp>0)
            {
                s = end;
                e = start;
            }
            else
            {
                s = start;
                e = end;
            }
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.DoanhThus
                     where x.NgayTao>=s && x.NgayTao<=e
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };

            foreach (var p in ds)
            {
                HD a = new HD();
                a.MaHoaDon = p.MaHoaDon;
                //a.MaNV = p.MaNV;
                a.NgayTao = p.NgayTao.ToString().Substring(0, 10);
                a.VAT = p.VAT;
                a.TongTien = int.Parse(p.TongTien.ToString());
                Lst.Add(a);
            }
            temp = "KhoangThoiGian_" + s.Day.ToString() + "_" + s.Month.ToString() + "_" + s.Year.ToString() + "-" + e.Day.ToString() + "_" + e.Month.ToString() + "_" + e.Year.ToString();
            return Lst;
        }
        public string LayTongTienHoaDon(string TT)
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(TT.ToString()));
        }
        public string LayVAT(string MaHoaDon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.HDONs
                     where x.MaHoaDon == MaHoaDon
                     select new { x.MaHoaDon, x.NgayTao, x.VAT, x.TongTien };
            foreach (var a in ds)
            {
                return a.VAT;
            }
            return "0";
        }
        public string LayTongThucAn(string MaHoaDon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.HDONs
                     join i in ql.CHITIETHDONs on x.MaHoaDon equals i.MaHoaDon
                     where x.MaHoaDon == MaHoaDon
                     select new { i.ThanhTien };

            double TongTien = double.Parse(ds.ToList().Select(c => c.ThanhTien).Sum().ToString());
            return string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }
        public string layTemp()
        {
            return temp;
        }
    }
    
    public class HD
    {
        public string MaHoaDon { get; set; }
        public string NgayTao { get; set; }
        //public string MaNV { get; set; }
        public string VAT { get; set; }
        public int TongTien { get; set; }
    }
}
