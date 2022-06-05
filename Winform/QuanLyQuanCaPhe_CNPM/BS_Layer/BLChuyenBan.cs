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
    class BLChuyenBan
    {
        string err;
        BLXemThongTinBan BLXTT = new BLXemThongTinBan();
        public void LayBanCu(string MaBanHienTai, TextEdit txtMaBan, TextEdit txtTenBan, TextEdit txtTenKV)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var ban = (from p in qlcfEntity.BANs
                       join q in qlcfEntity.KHUVUCs on p.MaKV equals q.MaKV
                       select new
                       {
                           p.MaBan,
                           p.TenBan,
                           q.TenKV
                       }).ToList();
            foreach (var p in ban)
            {
                if (p.MaBan.Trim() == MaBanHienTai.Trim())
                {
                    txtMaBan.Text = p.MaBan.Trim();
                    txtTenBan.Text = p.TenBan.Trim();
                    txtTenKV.Text = p.TenKV.Trim();
                }
            }
        }
        //public bool CapNhatPhieu(string MaBanMoi, string MaNV, string MaBanCu)
        //{

        //    string MaHoaDon = "";
        //    string NgayTao = "";
        //    QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
        //    var Phieu = (from a in qlcfEntity.HDONs
        //               where a.MaBan == MaBanCu
        //               select new {
        //                   a.MaHoaDon,
        //                   a.NgayTao,
        //                   a.MaBan,
        //                   a.MaNV
        //               }).ToList();
        //    var Phieu2 = (from a in qlcfEntity.HDONs
        //                  where a.MaBan == MaBanCu
        //                  select a).ToList();
        //    foreach (var x in Phieu)
        //    {
        //        foreach(var y in Phieu2)
        //        {
        //            if(x.MaHoaDon==y.MaHoaDon && x.MaBan==y.MaBan)
        //            {
        //                MaHoaDon = x.MaHoaDon;
        //                NgayTao = x.NgayTao.ToString();
        //                MaBanCu = x.MaBan;
        //                MaNV = x.MaNV;

        //                y.MaHoaDon = MaHoaDon;
        //                y.NgayTao = DateTime.Parse(NgayTao);
        //                y.MaBan = MaBanMoi;
        //                y.MaNV = MaNV;
        //                qlcfEntity.SaveChanges();
        //            }
        //        }
        //    }

        //    BLXemThongTinBan BLXTT = new BLXemThongTinBan();
        //    BLXTT.DoiTrangThai(MaBanCu);
        //    BLXTT.DoiTrangThai(MaBanMoi);
        //    MessageBox.Show("Đã chuyển bàn " + MaBanCu.Trim() + " sang bàn " + MaBanMoi.Trim() + " thành công!");
        //    return true;
        //}
        //public bool ChuyenBan(string MBCanChuyen, string MaHoaDonC, string MBDich, string MaHoaDonD)
        //{
        //    BLQuanLyBan BLQLB = new BLQuanLyBan();
        //    //
        //    QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
        //    var Item1 = (from p in ql.HDONs
        //                 where p.MaBan == MBDich
        //                 select new
        //                 {
        //                     p.MaHoaDon
        //                 }).ToList();

        //    if (Item1.Count() == 0)
        //    {
        //        var Item2 = (from p in ql.HDONs
        //                     where p.MaBan == MBCanChuyen
        //                     select p).SingleOrDefault();
        //        try
        //        {
        //            if (Item2 != null)
        //            {
        //                Item2.MaBan = MBDich;
        //                ql.SaveChanges();
        //                BLQLB.CapNhatBan(MBCanChuyen, "0", ref err);
        //                BLQLB.CapNhatBan(MBDich, "1", ref err);

        //            }
        //        }
        //        catch
        //        {
        //            BLQLB.CapNhatBan(MBCanChuyen, "0", ref err);
        //            BLQLB.CapNhatBan(MBDich, "1", ref err);
        //        }
        //    }
        //    else
        //    {
        //        var dsTADich = from p in ql.HDONs
        //                       join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
        //                       where p.MaBan == MBDich
        //                       select new
        //                       {
        //                           q.MaHoaDon,
        //                           q.MaMon,
        //                           q.SoLuong
        //                       };
        //        var dsTAChuyen = from p in ql.HDONs
        //                         join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
        //                         where p.MaBan == MBCanChuyen
        //                         select new
        //                         {
        //                             q.MaHoaDon,
        //                             q.MaMon,
        //                             q.SoLuong
        //                         };

        //        foreach (var x in dsTAChuyen)
        //        {
        //            int check = 0;
        //            string MaHoaDon = "";
        //            string maMon = "";
        //            int soLuong = 0;
        //            string ngayTao = "";
        //            int temp = 0;
        //            foreach (var y in dsTADich)
        //            {
        //                if (y.MaMon == x.MaMon)
        //                {
        //                    check = 1;
        //                    temp = int.Parse(y.SoLuong.ToString());
        //                }
        //                MaHoaDon = y.MaHoaDon; // ma phieu ban dich
        //            }
        //            maMon = x.MaMon;
        //            soLuong = int.Parse(x.SoLuong.ToString());
        //            //ngayTao = x.NgayTao.ToString().Trim();

        //            try
        //            {
        //                if (check == 0)
        //                {
        //                    BLChonMon BLDM = new BLChonMon();
        //                    BLDM.ThemChiTietPhieu(MaHoaDon, maMon, soLuong, DateTime.Parse(ngayTao), ref err);
        //                    BLDM.ThemChiTietTemp(MaHoaDon, maMon, soLuong, DateTime.Parse(ngayTao), ref err);
        //                    //BLDM.XoaChiTietPhieu(ref err, x.MaHoaDon, x.MaMon);
        //                    BLDM.XoaChiTietTemp(ref err, x.MaHoaDon, x.MaMon);
        //                    BLDM.XoaPhieu(ref err, x.MaHoaDon);
        //                }
        //                else
        //                {
        //                    int tongSL = temp + soLuong;
        //                    BLChonMon BLDM = new BLChonMon();
        //                    BLDM.CapNhatChiTietPhieu(MaHoaDon, maMon, tongSL, ref err);
        //                    //BLDM.CapNhatChiTietTemp(MaHoaDon, maMon, tongSL, ref err);
        //                    //BLDM.XoaChiTietPhieu(ref err, x.MaHoaDon, x.MaMon);
        //                    BLDM.XoaChiTietTemp(ref err, x.MaHoaDon, x.MaMon);
        //                    BLDM.XoaPhieu(ref err, x.MaHoaDon);
        //                }
        //            }
        //            catch
        //            {

        //            }
        //        }
        //        BLQLB.CapNhatBan(MBCanChuyen,"0", ref err);
        //        BLQLB.CapNhatBan(MBDich, "1", ref err);

        //    }
        //    return true;
        //}
        public bool ChuyenBan(string MBCanChuyen, string MaHoaDonC, string MBDich, string MaHoaDonD)
        {
            BLQuanLyBan BLQLB = new BLQuanLyBan();
            BLChonMon BLDM = new BLChonMon();
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var Item1 = (from p in ql.HDONs
                         where p.MaBan == MBDich && p.TongTien==0
                         select new
                         {
                             p.MaHoaDon
                         }).ToList();

            if (Item1.Count() == 0)
            {
                var Item2 = (from p in ql.HDONs
                             where p.MaBan == MBCanChuyen && p.TongTien==0
                             select p).SingleOrDefault();
                try
                {
                    if (Item2 != null)
                    {
                        Item2.MaBan = MBDich;
                        ql.SaveChanges();
                        BLQLB.CapNhatBan(MBCanChuyen, "0", ref err);
                        BLQLB.CapNhatBan(MBDich, "1", ref err);

                    }
                }
                catch
                {
                    BLQLB.CapNhatBan(MBCanChuyen, "0", ref err);
                    BLQLB.CapNhatBan(MBDich, "1", ref err);
                }
            }
            else
            {
                var dsTADich = from p in ql.HDONs
                               join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                               where p.MaBan == MBDich && p.TongTien==0
                               select new
                               {
                                   q.MaHoaDon,
                                   q.MaMon,
                                   q.SoLuong,
                                   q.DonGia
                               };
                var dsTAChuyen = from p in ql.HDONs
                                 join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                                 where p.MaBan == MBCanChuyen && p.TongTien==0
                                 select new
                                 {
                                     q.MaHoaDon,
                                     q.MaMon,
                                     q.SoLuong,
                                     q.DonGia
                                 };

                foreach (var x in dsTAChuyen)
                {
                    int check = 0;
                    string MaHoaDon = "";
                    string maMon = "";
                    int soLuong = 0;
                    int temp = 0;
                    int DonGia = 0;
                    foreach (var y in dsTADich)
                    {
                        if (y.MaMon == x.MaMon)
                        {
                            check = 1;
                            temp = int.Parse(y.SoLuong.ToString());
                        }
                        MaHoaDon = y.MaHoaDon; // ma phieu ban dich
                    }
                    maMon = x.MaMon;
                    DonGia = int.Parse(x.DonGia.ToString());
                    soLuong = int.Parse(x.SoLuong.ToString());
                    //ngayTao = x.NgayTao.ToString().Trim();
                    try
                    {
                        if (check == 0)
                        {
                            //BLChonMon BLDM = new BLChonMon();
                            BLDM.ThemChiTietPhieu(MaHoaDon, maMon, soLuong,DonGia, ref err);
                            //BLDM.ThemChiTietTemp(MaHoaDon, maMon, soLuong, DateTime.Parse(ngayTao), ref err);
                            //BLDM.XoaChiTietPhieu(ref err, x.MaHoaDon, x.MaMon);
                            //BLDM.XoaChiTietTemp(ref err, x.MaHoaDon, x.MaMon);
                        }
                        else
                        {
                            int tongSL = temp + soLuong;
                            //BLChonMon BLDM = new BLChonMon();
                            BLDM.CapNhatChiTietPhieu(BLDM.LayMaHoaDon(MBDich), maMon, tongSL, ref err);
                            //BLDM.CapNhatChiTietTemp(MaHoaDon, maMon, tongSL, ref err);
                            //BLDM.XoaChiTietPhieu(ref err, x.MaHoaDon, x.MaMon);
                            //BLDM.XoaChiTietTemp(ref err, x.MaHoaDon, x.MaMon);
                        }
                    }
                    catch
                    {

                    }
                }
                BLDM.XoaPhieu(ref err, MaHoaDonC);
                BLQLB.CapNhatBan(MBCanChuyen, "0", ref err);
                BLQLB.CapNhatBan(MBDich, "1", ref err);

            }
            return true;
        }
    }

}
