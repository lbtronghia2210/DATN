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
    class BLTraLai
    {
        string err = "";
        BLThongBao BLTB = new BLThongBao();
        public int TraLai(string MaHoaDon, string MaMon, int SLTra)
        {
            int check = 1;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var ds = from i in ql.HDONs
                     join y in ql.CHITIETHDONs on i.MaHoaDon equals y.MaHoaDon
                     where y.MaMon == MaMon && i.TongTien==0 && y.MaHoaDon==MaHoaDon
                     select new
                     {
                         y.MaMon,
                         y.SoLuong
                     };
            foreach (var i in ds)
            {
                if(i.SoLuong>=SLTra)
                {
                    BLChonMon BLCM = new BLChonMon();
                    if (i.SoLuong>SLTra)
                    {
                        //Cap nhat lai chi tiet va nguyen lieu
                        int slmoi =int.Parse(i.SoLuong.ToString()) - SLTra;
                        int slcu = int.Parse(i.SoLuong.ToString());
                        BLCM.CapNhatKhiCapNhat(MaHoaDon, MaMon, slmoi, slcu);
                        BLCM.CapNhatChiTietPhieu(MaHoaDon, MaMon, slmoi,ref err);
                    }
                    if (i.SoLuong == SLTra)
                    {
                        // Cap nhat lai nguyen lieu va huy chi tiet phieu
                        int slmoi = int.Parse(i.SoLuong.ToString()) - SLTra;
                        int slcu = int.Parse(i.SoLuong.ToString());
                        BLCM.CapNhatKhiCapNhat(MaHoaDon, MaMon, slmoi, slcu);
                        BLCM.XoaChiTietPhieu(ref err, MaHoaDon, MaMon);
                    }
                    check = 1;
                    BLTB.Show("Thành Công!");
                }
                else
                {
                    BLTB.Show("Số Lượng Trả Không Đượt Vượt Quá Số Lượng Món Đã Đặt!");
                    check = 0;
                }
            }
            return check;
        }
    }
}
