using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLNhanVien
    {
        public DataTable LayNhanVien()
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var nvs =
            from p in qlcfEntities.NHANVIENs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Phái");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Ngày Vào");
            dt.Columns.Add("Lương CB");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.Phai.Trim(), p.NgaySinh.ToString().Substring(0, 10), p.DiaChi.Trim(), p.SDT.Trim(), p.NgayVaoLam.ToString().Substring(0, 10), p.LuongCoBan.ToString().Trim());
            }
            return dt;
        }
        //public DataTable LayNhanVien(DataGrid view)
        //{
        //    QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
        //    var nvs =
        //    from p in qlcfEntities.NHANVIENs
        //    select p;
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Mã");
        //    dt.Columns.Add("Họ Tên");
        //    dt.Columns.Add("Phái");
        //    dt.Columns.Add("Ngày Sinh");
        //    dt.Columns.Add("Địa Chỉ");
        //    dt.Columns.Add("SĐT");
        //    dt.Columns.Add("Ngày Vào");
        //    dt.Columns.Add("Lương CB");
        //    foreach (var p in nvs)
        //    {
        //        dt.Rows.Add(p.MaNV, p.HoTen, p.Phai, p.NgaySinh, p.DiaChi, p.SDT, p.NgayVaoLam, p.LuongCoBan);
        //    }
        //    return dt;
        //}
        public bool ThemNhanVien(string MaNV, string Hoten,string Phai, string Ngaysinh, string Diachi,string SDT, string Ngayvaolam, string LuongCB, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MaNV = MaNV;
            nv.HoTen = Hoten;
            nv.Phai = Phai;
            nv.NgaySinh = DateTime.Parse(Ngaysinh);
            nv.DiaChi = Diachi;
            nv.SDT = SDT;
            nv.NgayVaoLam = DateTime.Parse(Ngayvaolam);
            nv.LuongCoBan = int.Parse(LuongCB);
            qlcfEntities.NHANVIENs.Add(nv);
            qlcfEntities.SaveChanges();
            return true;
        }
        public bool XoaNhanvien(ref string err, string MaNV)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MaNV = MaNV;
            qlcfEntities.NHANVIENs.Attach(nv);
            qlcfEntities.NHANVIENs.Remove(nv);
            qlcfEntities.SaveChanges();
            return true;
        }
        public bool CapNhatNhanvien(string MaNV, string Hoten,string Phai, string Ngaysinh, string DiaChi, string SDT, string Ngayvaolam, string LuongCB, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var nv = (from a in qlcfEntities.NHANVIENs
                      where a.MaNV == MaNV
                      select a).SingleOrDefault();
            if (nv != null)
            {
                //nv.MaNV = MaNV;
                nv.HoTen = Hoten;
                nv.DiaChi = DiaChi;
                nv.SDT = SDT;
                nv.NgayVaoLam = DateTime.Parse(Ngayvaolam);
                nv.LuongCoBan = int.Parse(LuongCB);
                nv.Phai = Phai;
                nv.NgaySinh = DateTime.Parse(Ngaysinh);
                qlcfEntities.SaveChanges();
            }
            return true;
        }
        public void loadDiaChi(ComboBoxEdit cmbDiaChi)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tinh = from p in qlcf.NHANVIENs
                       group p by p.DiaChi into g
                       select new
                       {
                           Tinh = g.Key
                       };
            foreach (var i in tinh)
            {

                cmbDiaChi.Properties.Items.Add(i.Tinh.Trim());
            }
        }
        public void reloadDiaChi(ComboBoxEdit cmbDiaChi)
        {
            cmbDiaChi.Properties.Items.Clear();
            cmbDiaChi.Properties.Items.Add("Tất Cả");
            loadDiaChi(cmbDiaChi);
        }
        public void LayLuong(LabelControl lblTongCaThang, LabelControl lblTongTienLuong, string MaNV, TextEdit txtLuongCoBan)
        {
            DateTime day = System.DateTime.Now;
            string Thang = day.Month.ToString();
            string Nam = day.Year.ToString();
            int tien = 0;
            QuanLyQuanAnEntities qlqa = new QuanLyQuanAnEntities();
            var dsLam = (from x in qlqa.NHANVIENs
                         join y in qlqa.CHAMCONGs on x.MaNV equals y.MaNV
                         where x.MaNV == MaNV && y.NgayLam.Month.ToString() == Thang && y.NgayLam.Year.ToString() == Nam
                         select new
                         {
                             x.MaNV

                         }).ToList();
            lblTongCaThang.Text = "- Tổng Ca (Tháng " + Thang + "): " + dsLam.Count() + " Ca";
            tien = int.Parse(dsLam.Count.ToString()) * int.Parse(txtLuongCoBan.Text);
            lblTongTienLuong.Text = "- Tổng Lương: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(tien.ToString()));
        }
        public void Loc(ComboBoxEdit cmbLocGioiTinh,ComboBoxEdit cmbDiaChi,TextEdit txtTimTen,DataGridView dgvQLNV)
        {
            try
            {
                if (cmbLocGioiTinh.Text == "Tất Cả" && cmbDiaChi.Text == "Tất Cả")
                {
                    try
                    {
                        QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
                        var tim = (from p in qlcf.NHANVIENs
                                   where p.HoTen.Contains(txtTimTen.Text)
                                   select new
                                   {
                                       p.MaNV,
                                       p.HoTen,
                                       p.Phai,
                                       p.NgaySinh,
                                       p.DiaChi,
                                       p.SDT,
                                       p.NgayVaoLam,
                                       p.LuongCoBan

                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");
                        foreach (var p in tim)
                        {
                            dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.Phai.Trim(), p.NgaySinh.ToString().Substring(0, 10), p.DiaChi.Trim(), p.SDT.Trim(), p.NgayVaoLam.ToString().Substring(0, 10), p.LuongCoBan.ToString().Trim());
                        }
                        dgvQLNV.DataSource = dt;
                    }
                    catch { }
                }
                else if (cmbLocGioiTinh.Text != "Tất Cả" && cmbDiaChi.Text == "Tất Cả")
                {
                    try
                    {
                        QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
                        var tim = (from p in qlcf.NHANVIENs
                                   where p.HoTen.Contains(txtTimTen.Text) && p.Phai == cmbLocGioiTinh.SelectedItem.ToString()
                                   select new
                                   {
                                       p.MaNV,
                                       p.HoTen,
                                       p.Phai,
                                       p.NgaySinh,
                                       p.DiaChi,
                                       p.SDT,
                                       p.NgayVaoLam,
                                       p.LuongCoBan

                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");
                        foreach (var p in tim)
                        {
                            dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.Phai.Trim(), p.NgaySinh.ToString().Substring(0, 10), p.DiaChi.Trim(), p.SDT.Trim(), p.NgayVaoLam.ToString().Substring(0, 10), p.LuongCoBan.ToString().Trim());
                        }
                        dgvQLNV.DataSource = dt;
                    }
                    catch { }
                }
                else if (cmbLocGioiTinh.Text == "Tất Cả" && cmbDiaChi.Text != "Tất Cả")
                {
                    try
                    {
                        QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
                        var tim = (from p in qlcf.NHANVIENs
                                   where p.HoTen.Contains(txtTimTen.Text) && p.DiaChi == cmbDiaChi.SelectedItem.ToString()
                                   select new
                                   {
                                       p.MaNV,
                                       p.HoTen,
                                       p.DiaChi,
                                       p.SDT,
                                       p.NgayVaoLam,
                                       p.LuongCoBan,
                                       p.Phai,
                                       p.NgaySinh

                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");
                        foreach (var p in tim)
                        {
                            dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.Phai.Trim(), p.NgaySinh.ToString().Substring(0, 10), p.DiaChi.Trim(), p.SDT, p.NgayVaoLam.ToString().Substring(0,10), p.LuongCoBan.ToString().Trim());
                        }
                        dgvQLNV.DataSource = dt;
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
                        var tim = (from p in qlcf.NHANVIENs
                                   where p.HoTen.Contains(txtTimTen.Text) && p.DiaChi == cmbDiaChi.SelectedItem.ToString() && p.Phai == cmbLocGioiTinh.SelectedItem.ToString()
                                   select new
                                   {
                                       p.MaNV,
                                       p.HoTen,
                                       p.DiaChi,
                                       p.SDT,
                                       p.NgayVaoLam,
                                       p.LuongCoBan,
                                       p.Phai,
                                       p.NgaySinh

                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");
                        foreach (var p in tim)
                        {
                            dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(), p.Phai.Trim(), p.NgaySinh.ToString().Substring(0, 10), p.DiaChi.Trim(), p.SDT.Trim(), p.NgayVaoLam.ToString().Substring(0, 10), p.LuongCoBan.ToString().Trim());
                        }
                        dgvQLNV.DataSource = dt;
                    }
                    catch { }
                }
            }
            catch { }
            
        }
        public string TaoMaNhanVien()
        {
            int str = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.NHANVIENs
                     select new { x.MaNV };
            foreach(var a in ds)
            {
                if(int.Parse(a.MaNV.ToString().Trim().Substring(2))>str)
                {
                    str = int.Parse(a.MaNV.ToString().Trim().Substring(2));
                }
            }
            return "NV" + (str+1);
        }
    }
}
