using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCaPhe_CNPM.BS_Layer;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLChonMon
    {
        string err="";
        public void LayThucDon(DataGridView dgvThucDon)
        {
            Image img = null;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var p = from i in ql.THUCDONs
                    select new
                    {
                        i.MaMon,
                        i.TenMon,
                        i.DonGia,
                        i.HinhAnh
                    };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Món");
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("Đơn Giá");
            dt.Columns.Add("Hình Ảnh");
            foreach (var i in p)
            {
                dgvThucDon.RowTemplate.Resizable = DataGridViewTriState.True;
                dgvThucDon.RowTemplate.Height = 110;
                try
                {
                    if (i.HinhAnh.Trim() != "No Image")
                        img = Image.FromFile(i.HinhAnh);
                    else
                        img = Image.FromFile("HinhAnh/amthucganh.jpg");
                    dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                }
                catch
                {
                    img = Image.FromFile("HinhAnh/amthucganh.jpg");
                    dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                }
            }

        }
        public void TimKiemMenu(DataGridView dgvThucDon, TextEdit txtTimKiem, ComboBoxEdit cmbLoaiMon)
        {
            Image img = null;
            if(cmbLoaiMon.Text=="Tất Cả")
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var p = from i in ql.THUCDONs
                        where i.TenMon.Contains(txtTimKiem.Text)
                        select new
                        {
                            i.MaMon,
                            i.TenMon,
                            i.DonGia,
                            i.HinhAnh
                        };
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Món");
                dt.Columns.Add("Tên Món");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Hình Ảnh");
                dgvThucDon.Rows.Clear();
                foreach (var i in p)
                {

                    dgvThucDon.RowTemplate.Resizable = DataGridViewTriState.True;
                    dgvThucDon.RowTemplate.Height = 110;
                    try
                    {
                        if (i.HinhAnh.Trim() != "No Image")
                            img = Image.FromFile(i.HinhAnh);
                        else
                            img = Image.FromFile("HinhAnh/amthucganh.jpg");
                        dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                    }
                    catch
                    {
                        img = Image.FromFile("HinhAnh/amthucganh.jpg");
                        dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                    }

                }
                
            }
            else if(cmbLoaiMon.Text!="Tất Cả")
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var p = from i in ql.THUCDONs
                        join x in ql.LOAIMONs on i.MaLoai equals x.MaLoai
                        where i.TenMon.Contains(txtTimKiem.Text) && x.TenLoai.Trim()==cmbLoaiMon.Text
                        select new
                        {
                            i.MaMon,
                            i.TenMon,
                            i.DonGia,
                            i.HinhAnh
                        };
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Món");
                dt.Columns.Add("Tên Món");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Hình Ảnh");
                dgvThucDon.Rows.Clear();
                foreach (var i in p)
                {

                    dgvThucDon.RowTemplate.Resizable = DataGridViewTriState.True;
                    dgvThucDon.RowTemplate.Height = 110;
                    try
                    {
                        if (i.HinhAnh.Trim() != "No Image")
                            img = Image.FromFile(i.HinhAnh);
                        else
                            img = Image.FromFile("HinhAnh/amthucganh.jpg");
                        dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                    }
                    catch
                    {
                        img = Image.FromFile("HinhAnh/amthucganh.jpg");
                        dgvThucDon.Rows.Add(i.MaMon.Trim(), i.TenMon.Trim(), i.DonGia.ToString().Trim(), img);
                    }

                }
            }
        }
        public void TaoTenMon(ComboBoxEdit cmbLoaiMon)
        {
            for (int i = cmbLoaiMon.Properties.Items.Count - 1; i >= 0; i--)
            {
                cmbLoaiMon.Properties.Items.RemoveAt(i);
            }
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var chon = from p in qlcf.LOAIMONs
                       group p by p.TenLoai into g
                       select new
                       {
                           TenLoai = g.Key
                       };
            cmbLoaiMon.Properties.Items.Add("Tất Cả");
            foreach (var p in chon)
            {
                cmbLoaiMon.Properties.Items.Add(p.TenLoai.Trim());
            }
        }
        public void LayHinhAnh(string MaMon, PictureEdit PicThucAn)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var hinhAnh = from h in ql.THUCDONs
                          where h.MaMon == MaMon
                          select h;
            foreach (var item in hinhAnh)
            {
                try
                {
                    if (item.HinhAnh.Trim() != "No Image")
                        PicThucAn.Image = Image.FromFile(item.HinhAnh);
                    else
                        PicThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
                }
                catch
                {
                    PicThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
                }
            }
        }
        public string LayHinhAnh(string MaMon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var hinhAnh = from h in ql.THUCDONs
                          where h.MaMon == MaMon
                          select h;
            foreach (var item in hinhAnh)
            {
                if (item.HinhAnh == null)
                    return "No Image";
                return item.HinhAnh.ToString().Trim();
            }
            return "";
        }

        public void KiemTraBan(string MaBanDangChon, SimpleButton btnTaoPhieu, NumericUpDown SL)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ban = from p in ql.BANs join q in ql.HDONs on p.MaBan equals q.MaBan
                      where p.MaBan == MaBanDangChon && q.TongTien ==0
                      select p;


            if (ban.Count() != 0)
            {
                btnTaoPhieu.Enabled = false;
                //btnThemMon.Enabled = true;
                SL.Enabled = true;
            }
            else
            {
                btnTaoPhieu.Enabled = true;
                //btnThemMon.Enabled = false;
                SL.Enabled = false;
            }

        }
        public string LayTrangThai(string MaBanDangChon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ban = from p in ql.BANs
                      where p.MaBan == MaBanDangChon
                      select p;
            foreach (var item in ban)
            {
                return item.TrangThai.Trim();
            }
            return "";
        }
       
        public string LayMaHoaDon()
        {
            int max = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ma = from p in ql.HDONs
                     select new
                     {
                         p.MaHoaDon
                     };
            foreach (var i in ma)
            {
                if (max < int.Parse(i.MaHoaDon.Trim()))
                {
                    max = int.Parse(i.MaHoaDon.Trim());
                }
            }
            return (max + 1).ToString();
        }
        public void ThongTinBan(string MaHoaDon, string MaBan, DataGridView dgvChiTietBan)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var Thucan1 = from p in ql.HDONs
                          join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                          where p.MaHoaDon == MaHoaDon && p.MaBan==MaBan && p.TongTien==0
                          select new
                          {
                              q.MaMon,
                              q.SoLuong
                          };
            var Thucan2 = from p in Thucan1
                          join q in ql.THUCDONs on p.MaMon equals q.MaMon
                          select new { p.SoLuong, q.TenMon, q.DonGia,p.MaMon };
            DataTable data = new DataTable();
            data.Columns.Add("Mã Món");
            data.Columns.Add("Tên Món");
            data.Columns.Add("Đơn Giá");
            data.Columns.Add("Số Lượng");
            foreach (var q in Thucan2)
            {
                data.Rows.Add(q.MaMon.Trim(),q.TenMon.Trim(), q.DonGia.ToString().Trim(), q.SoLuong.ToString().Trim());
            }
            dgvChiTietBan.DataSource = data;
        }
        public bool ThemPhieu(string MaHoaDon, DateTime NgayTao, string MaBan, string MaNV, string VAT, string MaKH, int TongTien, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            HDON p = new HDON();
            p.MaHoaDon = MaHoaDon;
            p.NgayTao = NgayTao;
            p.MaBan = MaBan;
            p.MaNV = MaNV;
            p.VAT = VAT;
            p.MaKH = MaKH;
            p.TongTien = TongTien;
            qlcfEntity.HDONs.Add(p);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaPhieu(ref string err, string MaHoaDon)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            HDON p = new HDON();
            p.MaHoaDon = MaHoaDon;
            qlcfEntity.HDONs.Attach(p);
            qlcfEntity.HDONs.Remove(p);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool CapNhatPhieu(string MaHoaDon,  int TongTien, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Phieu = (from a in qlcfEntity.HDONs
                         where a.MaHoaDon.Trim() == MaHoaDon.Trim() && a.TongTien==0
                         select a).SingleOrDefault();
            if (Phieu != null)
            {
                //nv.MaNV = MaNV;
                //Phieu.NgayTao = NgayTao;
                //Phieu.MaBan = "";
                Phieu.TongTien = TongTien;
                //Phieu.MaNV = MaNV;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public bool CapNhatPhieu(string MaHoaDon, string VAT, string MaKH, int TongTien, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Phieu = (from a in qlcfEntity.HDONs
                         where a.MaHoaDon == MaHoaDon.Trim() && a.TongTien==0
                         select a).SingleOrDefault();
            if (Phieu != null)
            {
                Phieu.TongTien = TongTien;
                Phieu.VAT = VAT;
                Phieu.MaKH = MaKH;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        
        public bool ThemChiTietPhieu(string MaHoaDon, string MaMon, int SL, int DonGia, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            CHITIETHDON a = new CHITIETHDON();
            a.MaHoaDon = MaHoaDon;
            a.MaMon = MaMon;
            a.SoLuong = SL;
            a.DonGia = DonGia;
            a.ThanhTien = DonGia * SL;
            qlcfEntity.CHITIETHDONs.Add(a);
            qlcfEntity.SaveChanges();
            return true;
        }
        //public bool ThemChiTietTemp(string MaHoaDon, string MaMon, int SL, DateTime NgayTao, ref string err)
        //{
        //    QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
        //    TEMPDT a = new TEMPDT();
        //    a.MaHoaDon = MaHoaDon;
        //    a.MaMon = MaMon;
        //    a.SoLuong = SL;
        //    //a.NgayTao = NgayTao;
        //    qlcfEntity.TEMPDTs.Add(a);
        //    qlcfEntity.SaveChanges();
        //    return true;
        //}
        public int LayDonGia(string MaMon) // Lấy đơn giá
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var dongia = from x in ql.THUCDONs
                         where x.MaMon == MaMon
                         select new { x.DonGia };
            foreach(var a in dongia)
            {
                return int.Parse(a.DonGia.ToString());
            }
            return 0;
        }
        public bool ThemChiTietThem(string MaBanDangChon, string MaHoaDon, string MaMon, int SL, ref string err) // Thêm món ăn vào bàn
        {
            int check = 0;
            int SLTong = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ban = from p in ql.BANs
                      join i in ql.HDONs on p.MaBan equals i.MaBan
                      where p.MaBan == MaBanDangChon && i.TongTien == 0
                      select new { i.MaHoaDon };;
            foreach(var i in ban)
            {
                MaHoaDon = i.MaHoaDon;
            }
            var dsTA = from i in ql.HDONs
                       join x in ql.CHITIETHDONs on i.MaHoaDon equals x.MaHoaDon
                       where i.MaHoaDon == MaHoaDon
                       select x;
            foreach( var b in dsTA)
            {
                if(b.MaMon.Trim()==MaMon)
                {
                    SLTong = int.Parse(b.SoLuong.ToString()) +SL;
                    check = 1;
                }
            }
            if (check == 0)
            {
                QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
                CHITIETHDON a = new CHITIETHDON();
                a.MaHoaDon = MaHoaDon;
                a.MaMon = MaMon;
                a.SoLuong = SL;
                a.DonGia = LayDonGia(MaMon);
                a.ThanhTien = a.DonGia * a.SoLuong;
                qlcfEntity.CHITIETHDONs.Add(a);
                qlcfEntity.SaveChanges();
                return true;
            }
            else
            {
                CapNhatChiTietPhieu(MaHoaDon, MaMon, SLTong, ref err);
            }
            return true;
        }
        
        public bool XoaChiTietPhieu(ref string err, string MaHoaDon, string MaMon)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            CHITIETHDON c = new CHITIETHDON();
            c.MaHoaDon = MaHoaDon;
            c.MaMon = MaMon;
            qlcfEntity.CHITIETHDONs.Attach(c);
            qlcfEntity.CHITIETHDONs.Remove(c);
            qlcfEntity.SaveChanges();
            return true;
        }
      
        public bool XoaChiTietPhieuKhiHuy(ref string err, string MaHoaDon)
        {
           
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var x = (from y in qlcfEntity.CHITIETHDONs
                     where y.MaHoaDon.Trim() == MaHoaDon
                     select y).ToList();
            foreach(var a in x)
            {
                CHITIETHDON c = new CHITIETHDON();
                c.MaHoaDon = a.MaHoaDon.Trim();
                c.MaMon = a.MaMon.Trim();
                qlcfEntity.CHITIETHDONs.Attach(c);
                qlcfEntity.CHITIETHDONs.Remove(c);
                qlcfEntity.SaveChanges();
            }
           
            return true;
        }
    
        public bool CapNhatChiTietPhieu(string MaHoaDon, string MaMon, int Soluong, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Phieu = (from a in qlcfEntity.CHITIETHDONs
                         where a.MaHoaDon == MaHoaDon && a.MaMon ==MaMon
                         select a).SingleOrDefault();
            if (Phieu != null)
            {
                
                Phieu.SoLuong = Soluong;
                Phieu.ThanhTien = Soluong * Phieu.DonGia;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
   
        public string LayMaHoaDon(string MBDangChon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var mp = (from p in ql.HDONs
                       where p.MaBan == MBDangChon && p.TongTien==0
                       select p);
            foreach(var item in mp)
            {
                //MessageBox.Show(item.MaHoaDon);
                return item.MaHoaDon.Trim();
            }
            
            return "";
        }
        public void CapNhatKhiThem(string MaHoaDon,string MaMon, int SoLuongCan, int SoLuongCo) // cap nhat so luong nguyen lieu
        {
            BLNguyenLieu BLNL = new BLNguyenLieu();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds1 = from i in ql.CONGTHUCs
                      join y in ql.CHITIETHDONs on i.MaMon equals y.MaMon
                      where i.MaMon == MaMon && y.MaHoaDon==MaHoaDon
                      select new
                      {
                          i.MaNL,
                          i.MaMon,
                          i.HamLuong
                      }; // Lay danh sach mon ăn
            var ds2 = from i in ds1
                      join y in ql.NGUYENLIEUx on i.MaNL equals y.MaNL
                      select new
                      {
                          i.MaNL,
                          y.TenNL,
                          i.HamLuong,
                          y.SoLuong,
                          y.DVT
                      };
            foreach (var a in ds2)
            {
                int hLuong = int.Parse(a.HamLuong);
                int Tong = int.Parse(a.SoLuong.ToString()) - (hLuong * SoLuongCan);
                BLNL.CapNhatNguyenLieu(a.MaNL, a.TenNL, a.DVT, Tong.ToString(), ref err);
            }
        }
        public void CapNhatKhiCapNhat(string MaHoaDon,string MaMon, int SoLuongMoi, int SoLuongCu)
        {
            BLNguyenLieu BLNL = new BLNguyenLieu();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds1 = from i in ql.CONGTHUCs
                      join y in ql.CHITIETHDONs on i.MaMon equals y.MaMon
                      where i.MaMon == MaMon && y.MaHoaDon == MaHoaDon
                      select new
                      {
                          i.MaNL,
                          i.MaMon,
                          i.HamLuong
                      }; // Lay danh sach mon ăn
            var ds2 = from i in ds1
                      join y in ql.NGUYENLIEUx on i.MaNL equals y.MaNL
                      select new
                      {
                          i.MaNL,
                          y.TenNL,
                          i.HamLuong,
                          y.SoLuong,
                          y.DVT
                      };
            if (SoLuongCu > SoLuongMoi)
            {
                foreach (var a in ds2)
                {
                    int ThayDoi = Math.Abs(SoLuongMoi - SoLuongCu);
                    int hLuong = int.Parse(a.HamLuong);
                    int Tong = int.Parse(a.SoLuong.ToString()) + hLuong * ThayDoi;
                    BLNL.CapNhatNguyenLieu(a.MaNL, a.TenNL, a.DVT, Tong.ToString(), ref err);
                }
                
            }
            if (SoLuongCu < SoLuongMoi)
            {
                foreach (var a in ds2)
                {
                    int ThayDoi = Math.Abs(SoLuongMoi - SoLuongCu);
                    int hLuong = int.Parse(a.HamLuong);
                    int Tong = int.Parse(a.SoLuong.ToString()) - hLuong * ThayDoi;
                    BLNL.CapNhatNguyenLieu(a.MaNL, a.TenNL, a.DVT, Tong.ToString(), ref err);
                }
            }
        }
        public void CapNhatKhiHuy(string MaHoaDon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var dsmm = from i in ql.CHITIETHDONs
                       where i.MaHoaDon == MaHoaDon
                       select new
                       {
                           i.MaMon, i.SoLuong
                       };
            foreach(var i in dsmm)
            {
                int sl =int.Parse(i.SoLuong.ToString());
                CapNhatKhiCapNhat(MaHoaDon, i.MaMon, 0, sl);
            }
        }
        public string KiemTraNL(int SoLuongCan, int SoLuongCo)
        {
            string Check = "0";
            if (SoLuongCo < SoLuongCan)
            {
                return "1";
            }
            return Check;
        }
        public int SoLuongHT(string MaMon) // Hien thi so luong con
        {
            int min = 1000000000;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();

            var ds1 = from i in ql.NGUYENLIEUx
                      join y in ql.CONGTHUCs on i.MaNL equals y.MaNL
                      where y.MaMon == MaMon.Trim()
                      select new
                      {
                          MaNguyenLieu = i.MaNL,
                          SoLuongCo = i.SoLuong,
                          SoLuongCan = y.HamLuong
                      };
            foreach(var a in ds1)
            {
                int SLC = int.Parse(a.SoLuongCan);
                int SLHT = int.Parse(a.SoLuongCo.ToString());
                if(min> (SLHT/SLC))
                {
                    min = (SLHT / SLC);
                }
            }
            return min;
        }
        public int LaySoLuong(string MaHoaDon, string TenMon) // Lay so luong cua mon trong chi tiet phieu
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from i in ql.THUCDONs
                     join x in ql.CHITIETHDONs on i.MaMon equals x.MaMon
                     where i.TenMon == TenMon && x.MaHoaDon == MaHoaDon
                     select new
                     {
                         x.SoLuong
                     };
            foreach(var a in ds)
            {
                int sl = int.Parse(a.SoLuong.ToString());
                return sl;
            }
            return 1;
        }
        public string LayMaMon(string MaHoaDon, string TenMon) // Lay so luong cua mon trong chi tiet phieu
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from i in ql.THUCDONs
                     join x in ql.CHITIETHDONs on i.MaMon equals x.MaMon
                     where i.TenMon == TenMon && x.MaHoaDon == MaHoaDon
                     select new
                     {
                         x.MaMon
                     };
            foreach (var a in ds)
            {
                string mm = a.MaMon;
                return mm.Trim();
            }
            return "";
        }
        public string LayMaMon(string TenMon) // Lay so luong cua mon trong chi tiet phieu
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from i in ql.THUCDONs
                     where i.TenMon == TenMon.Trim()
                     select new
                     {
                         i.MaMon
                     };
            foreach (var a in ds)
            {
                string mm = a.MaMon;
                return mm.Trim();
            }
            return "";
        }
        public DataTable XuatBill(string MaHoaDon)
        {
            string st = "Data Source=(local); Initial Catalog=QuanLyQuanAn; Integrated Security=True";
            SqlConnection sql = new SqlConnection(st);
            sql.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from HOADON where MaHoaDon ='" + MaHoaDon + "'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            return dt;
        }
        public DataTable XuatHoaDonDo(string MaHoaDon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from x in ql.HOADONs
                     where x.MaHoaDon.Trim() == MaHoaDon
                     select new { x.TenMon, x.DVT, x.SoLuong, x.DonGia, x.ThanhTien };
            DataTable table = new DataTable();
            table.Columns.Add("Tên Món");
            table.Columns.Add("Đơn Vị Tính");
            table.Columns.Add("Số Lượng");
            table.Columns.Add("Đơn Giá");
            table.Columns.Add("Thành Tiền");
            foreach (var t in ds)
            {
                table.Rows.Add(t.TenMon.Trim(), t.DVT.Trim(), t.SoLuong, t.DonGia, t.ThanhTien);
            }
            return table;
        }

    }
}
