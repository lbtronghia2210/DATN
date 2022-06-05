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
    class BLChamCong
    {
        public bool ThemChamCong(string MaNV, string NgayLam, string Ca,ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            CHAMCONG cc = new CHAMCONG();
            
            cc.MaNV = MaNV;
            cc.NgayLam = DateTime.Parse(NgayLam);
            cc.MaCa = Ca;
            qlcfEntities.CHAMCONGs.Add(cc);
            qlcfEntities.SaveChanges();
            return true;
        }
        public bool XoaChamCong(string MaNV, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            CHAMCONG cc = new CHAMCONG();
            cc.MaNV = MaNV;
            qlcfEntities.CHAMCONGs.Attach(cc);
            qlcfEntities.CHAMCONGs.Remove(cc);
            qlcfEntities.SaveChanges();
            return true;
        }
        public void LayNhanVien(DataGridView dgvNhanVien)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var nvs =
            from p in qlcfEntities.NHANVIENs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Sinh");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.NgaySinh.ToString().Substring(0, 10));
            }
            dgvNhanVien.DataSource = dt;
        }
        public void XoaNhanVien(DateTime NgayLam, string Ca, string MaNV)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            CHAMCONG cc = new CHAMCONG();
            cc.MaNV = MaNV.Trim();
            cc.NgayLam = NgayLam;
            cc.MaCa = Ca;
            qlcfEntities.CHAMCONGs.Attach(cc);
            qlcfEntities.CHAMCONGs.Remove(cc);
            qlcfEntities.SaveChanges();


        }
        public void LayThongTinNgayLam(DataGridView dgvChamCong,TextEdit txtNgay, TextEdit txtThang, TextEdit txtNam, ComboBoxEdit cmbCa,Label lblThongTin)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var nvs = from p in qlcfEntities.CHAMCONGs
                      join q in qlcfEntities.NHANVIENs on p.MaNV equals q.MaNV
                      where p.NgayLam.Day.ToString().Trim() == txtNgay.Text && p.NgayLam.Month.ToString().Trim() == txtThang.Text && p.NgayLam.Year.ToString().Trim() == txtNam.Text && p.MaCa.Trim() == cmbCa.Text
                      select new
                      {
                          p.MaNV,
                          q.HoTen,
                          p.NgayLam,
                          p.MaCa
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Làm");
            dt.Columns.Add("Ca");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.NgayLam.ToString().Substring(0, 10),p.MaCa);
            }
            dgvChamCong.DataSource = dt;
            lblThongTin.Text = "Danh Sách Nhân Viên Làm Ngày: " + txtNgay.Text + "/" + txtThang.Text + "/" + txtNam.Text + " " + cmbCa.Text;
        }
        public void ThemNgay(ComboBoxEdit cmbNgay)
        {
            for(int i=1;i<=31;i++)
            {
                cmbNgay.Properties.Items.Add(i);
            }
        }
        public void ThemThang(ComboBoxEdit cmbThang)
        {
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Properties.Items.Add(i);
            }
        }
        public void ThemNam(ComboBoxEdit cmbNam)
        {
            for (int i = 2019; i <= 2030; i++)
            {
                cmbNam.Properties.Items.Add(i);
            }
        }
        public void LayNgay(ComboBoxEdit Ngay, ComboBoxEdit Thang, ComboBoxEdit Nam)
        {
            DateTime day = System.DateTime.Now;
            Ngay.Text = day.Day.ToString();
            Thang.Text = day.Month.ToString();
            Nam.Text = day.Year.ToString();
        }
        public void LayCa(ComboBoxEdit cmb)
        {
            int hour = DateTime.Now.TimeOfDay.Hours;
            int minute = DateTime.Now.TimeOfDay.Minutes;
            //MessageBox.Show("" + hour.ToString());
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ca = from i in ql.CAs
                     select i;
            foreach (var p in ca)
            {
                cmb.Properties.Items.Add(p.MaCa);
                int hbd = int.Parse(p.GioBD.ToString().Substring(0, 2));
                int mbd = int.Parse(p.GioBD.ToString().Substring(3, 2));
                int hkt = int.Parse(p.GioKT.ToString().Substring(0, 2));
                int mkt = int.Parse(p.GioKT.ToString().Substring(3, 2));
                if( (hour*60 +minute ) >= (hbd*60 + mbd) && (hour * 60 + minute) <= (hkt * 60 + mkt))
                {
                    cmb.Text = p.MaCa;
                }
            }
        }
    }
}
