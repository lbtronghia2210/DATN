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
    class BLGopBan
    {
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
                    txtMaBan.Text= p.MaBan.Trim();
                    txtTenBan.Text = p.TenBan.Trim();
                    txtTenKV.Text = p.TenKV.Trim();
                }
            }
        }
        public bool CapNhatPhieu(string MaBanMoi, string MaNV, string MaBanCu)
        {

            string MaPhieu = "";
            string NgayTao = "";
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var Phieu = (from a in qlcfEntity.HDONs
                         where a.MaBan == MaBanCu
                         select new
                         {
                             a.MaHoaDon,
                             a.NgayTao,
                             a.MaBan,
                             a.MaNV
                         }).ToList();
            var Phieu2 = (from a in qlcfEntity.HDONs
                          where a.MaBan == MaBanCu
                          select a).ToList();
            foreach (var x in Phieu)
            {
                foreach(var y in Phieu2)
                {
                    if (x.MaHoaDon == y.MaHoaDon && x.MaBan == y.MaBan)
                    {
                        MaPhieu = x.MaHoaDon;
                        NgayTao = x.NgayTao.ToString();
                        MaBanCu = x.MaBan;
                        MaNV = x.MaNV;

                        y.MaHoaDon = MaPhieu;
                        y.NgayTao = DateTime.Parse(NgayTao);
                        y.MaBan = MaBanMoi;
                        y.MaNV = MaNV;
                        qlcfEntity.SaveChanges();
                    }
                }
            }
           
            
            MessageBox.Show("Đã gộp bàn " + MaBanCu.Trim() + " sang bàn " + MaBanMoi.Trim() + " thành công!");
            return true;
        }
        public void DoiTrangThai(string MaBanDangChon)
        {
            string err = "";
            string maBan = "";
            string tenBan = "";
            string soNguoi = "";
            string maKV = "";
            string trangThai = "";
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ban = from p in ql.BANs
                      where p.MaBan == MaBanDangChon
                      select p;
            foreach (var p in ban)
            {
                maBan = p.MaBan;
                tenBan = p.TenBan;
                trangThai = "1";
                maKV = p.MaKV;
                soNguoi = p.SoChoNgoi.ToString();
                BLQuanLyBan BLQLB = new BLQuanLyBan();
                BLQLB.CapNhatBan(maBan, tenBan, int.Parse(soNguoi), maKV, trangThai, ref err);
            }

        }

    }
}

