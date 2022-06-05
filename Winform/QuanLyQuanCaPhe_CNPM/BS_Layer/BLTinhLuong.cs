using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLTinhLuong
    {
        public void LayLuong(DataGridView dgv, ComboBoxEdit cmbT, ComboBoxEdit cmbNam, LabelControl TongLuong)
        {
            int T = int.Parse(cmbT.Text);
            int N = int.Parse(cmbNam.Text.Trim());
            List<TLuong> Lst = new List<TLuong>();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.TINHLUONGs
                     where x.Thang == T && x.Nam == N
                     select x;

            

            foreach (var p in ds)
            {
                TLuong l = new TLuong();
                l.MaNV = p.MaNV.Trim();
                l.HoTen = p.HoTen.Trim();
                l.Thang = int.Parse(p.Thang.ToString().Trim());
                l.Nam = int.Parse(p.Nam.ToString().Trim());
                l.TongSoCa = int.Parse(p.TongSoCa.ToString().Trim());
                l.LuongCoBan = int.Parse(p.LuongCoBan.ToString().Trim());
                l.Luong = int.Parse(p.Luong.ToString().Trim());
                Lst.Add(l);
            }
            dgv.DataSource = Lst;
            dgv.Columns[0].HeaderText = "Mã NV";
            dgv.Columns[1].HeaderText = "Họ Tên";
            dgv.Columns[2].HeaderText = "Tháng";
            dgv.Columns[3].HeaderText = "Năm";
            dgv.Columns[4].HeaderText = "Tổng Ca";
            dgv.Columns[5].HeaderText = "Lương CB";
            dgv.Columns[6].HeaderText = "Lương Nhận";

            dgv.Columns[5].DefaultCellStyle.Format = "0,##0 VNĐ";
            dgv.Columns[6].DefaultCellStyle.Format = "0,##0 VNĐ";
            double TongTien = double.Parse(ds.ToList().Select(c => c.Luong).Sum().ToString());
            TongLuong.Text = "Tổng Lương Cần Trả: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTien);
        }
        public List<TLuong> XuatLuong(ComboBoxEdit cmbT, ComboBoxEdit cmbNam)
        {
            //List<TLuong> l = new List<TLuong>();
            int T = int.Parse(cmbT.Text);
            int N = int.Parse(cmbNam.Text.Trim());
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.TINHLUONGs
                     where x.Thang == T && x.Nam == N
                     select x;
            List<TLuong> l = new List<TLuong>();
            foreach (var i in ds)
            {
                TLuong a = new TLuong();
                a.MaNV = i.MaNV;
                a.HoTen = i.HoTen;
                a.TongSoCa =int.Parse(i.TongSoCa.ToString());
                a.LuongCoBan = int.Parse(i.LuongCoBan.ToString());
                a.Luong = int.Parse(i.Luong.ToString());
                a.Thang = int.Parse(i.Thang.ToString());
                a.Nam = int.Parse(i.Nam.ToString());
                l.Add(a);
            }

            return l;
        }
    }
    public class TLuong
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int TongSoCa { get; set; }
        public int LuongCoBan { get; set; }
        public int Luong { get; set; }
    }
}
