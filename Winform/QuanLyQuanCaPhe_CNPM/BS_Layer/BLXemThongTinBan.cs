using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Media;
using System.IO;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLXemThongTinBan
    {
        string err;
        BLThongBao BLTB = new BLThongBao();
        public int TimSoTang()
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tim = from p in qlcf.KHUVUCs
                      select p;
            return tim.Count();
        }
        public void ThongTinBan(string MaHoaDon, DataGridView dgv)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            List<TTB> list = new List<TTB>();
            var Thucan1 = from p in ql.HDONs
                          join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                          where p.MaHoaDon == MaHoaDon && p.TongTien==0
                          select new
                          {
                              q.MaMon,
                              q.SoLuong,
                              q.ThanhTien
                          };

            var Thucan2 = from p in Thucan1
                          join q in ql.THUCDONs on p.MaMon equals q.MaMon
                          
                          select new {p.MaMon, q.TenMon, p.SoLuong,q.DonGia, p.ThanhTien};

            
            foreach (var q in Thucan2)
            {
                TTB tb = new TTB();
                tb.MaMon = q.MaMon;
                tb.TenMon = q.TenMon;
                tb.SoLuong = int.Parse(q.SoLuong.ToString());
                tb.DonGia = int.Parse(q.DonGia.ToString());
                tb.ThanhTien = int.Parse(q.ThanhTien.ToString());
                list.Add(tb);
            }

            dgv.DataSource = list;
            dgv.Columns[0].HeaderText = "Mã Món";
            dgv.Columns[1].HeaderText = "Tên Món";
            dgv.Columns[2].HeaderText = "Số Lượng";
            dgv.Columns[3].HeaderText = "Đơn Giá";
            dgv.Columns[4].HeaderText = "Thành Tiền";

            dgv.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
            dgv.Columns[4].DefaultCellStyle.Format = "0,##0 VNĐ";
        }
        public int TinhTien(string MaBan, string MaHoaDon)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var Thucan1 = from p in ql.HDONs
                          join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                          where p.MaBan == MaBan && p.TongTien==0 && p.MaHoaDon==MaHoaDon
                          select new
                          {
                              q.MaMon,
                              q.SoLuong,
                              q.ThanhTien
                          };
            int x = 0;
            x=int.Parse(Thucan1.ToList().Select(c => c.ThanhTien).Sum().ToString());
            return x;
        }
        public void DoiTrangThaiTT(string MaBanDangChon)
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
                trangThai = "0";
                maKV = p.MaKV;
                soNguoi = p.SoChoNgoi.ToString();
                BLQuanLyBan BLQLB = new BLQuanLyBan();
                BLQLB.CapNhatBan(maBan, tenBan, int.Parse(soNguoi), maKV, trangThai, ref err);
            }

        }
        
        public void XoaPhieu(string MaBanDangChon)
        {
            string err = "";
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var Phieu = from i in ql.HDONs
                        where i.MaBan.Trim() == MaBanDangChon
                        select new
                        {
                            i.MaHoaDon
                        };
            foreach (var p in Phieu)
            {
                foreach (var q in ql.HDONs)
                {
                    if (p.MaHoaDon == q.MaHoaDon)
                    {
                        BLQuanLyPhieu QL = new BLQuanLyPhieu();
                        QL.XoaPhieu(ref err, p.MaHoaDon);
                    }
                }
            }

        }
        public string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        public string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        public string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }
            return Ktach;
        }
        public string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng.";
            return lso_chu.ToString().Trim();
        }

        internal void CapNhatBan(List<frXemBan.Ban> lBan)
        {
            for (int i = 0; i < lBan.Count; i++)
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var dsban = from ban in ql.BANs
                            select ban;
                foreach (var item in dsban)
                {
                    if (item.MaBan == lBan[i].A.Name)
                    {
                        if (item.TrangThai.Trim() == "0")
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.table;
                        else if (item.TrangThai.Trim() == "1")
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.dining;
                        else if (item.TrangThai.Trim() == "BT")
                        {
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtemp;
                        }
                        else
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.Ordered;
                    }
                }
            }
        }
        internal void DoiHinhKhiBillTam(List<frXemBan.Ban> lBan)
        {
            for (int i = 0; i < lBan.Count; i++)
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var dsban = from ban in ql.BANs
                            select ban;
                foreach (var item in dsban)
                {
                    if (item.MaBan == lBan[i].A.Name)
                    {
                        if (item.TrangThai.Trim() == "BT")
                        {
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtemp;
                            lBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtempchange;  
                        }
                    }
                }
            }
        }
        public void playSound()
        {
            if(File.Exists("AmThanh//alert.wav"))
            {
                SoundPlayer simpleSound = new SoundPlayer("AmThanh//alert.wav");
                simpleSound.Play();
            }
            else
            {
              
            }
        }
        public int checkListBan(List<frXemBan.Ban> lBan)
        {
            for (int i = 0; i < lBan.Count; i++)
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var dsban = from ban in ql.BANs
                            select ban;
                foreach (var item in dsban)
                {
                    if (item.MaBan == lBan[i].A.Name && item.TrangThai.Trim()!=lBan[i].trangThai)
                    {
                        if (item.TrangThai.Trim() == "BT")
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
        public string DoanhThu()
        {
            int Sum = 0;
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var dt = from i in ql.HDONs
                     select i;
            foreach (var x in dt)
            {
                if (x.NgayTao.ToString().Substring(0, 10) == DateTime.Now.ToString().Substring(0, 10))
                {
                    Sum += int.Parse(x.TongTien.ToString());
                }
            }
            return Sum.ToString();
        }
        public int kiemTraThayDoi(string MaHoaDon, DataGridView dgv)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            List<TTB> list = new List<TTB>();
            var Thucan1 = from p in ql.HDONs
                          join q in ql.CHITIETHDONs on p.MaHoaDon equals q.MaHoaDon
                          where p.MaHoaDon == MaHoaDon && p.TongTien == 0
                          select new
                          {
                              q.MaMon,
                              q.SoLuong,
                              q.ThanhTien
                          };

            var Thucan2 = from p in Thucan1
                          join q in ql.THUCDONs on p.MaMon equals q.MaMon

                          select new { p.MaMon, q.TenMon, p.SoLuong, q.DonGia, p.ThanhTien };

            int sodongthucte = Thucan2.Count();
            int sodongtrongform = dgv.RowCount;
            foreach (var p in Thucan2)
            {
                for (int i = 0; i < sodongtrongform; i++)
                {

                    if (p.SoLuong != int.Parse(dgv.Rows[i].Cells[2].Value.ToString()) && p.MaMon.Trim() == dgv.Rows[i].Cells[0].Value.ToString().Trim())
                    {
                        return 1;
                    }
                }
            }
            if (sodongthucte != sodongtrongform)
                return 1;

            return 0;
        }
        public class TTB
        {
            public string MaMon { get; set; }
            public string TenMon { get; set; }
            public int SoLuong { get; set; }
            public int DonGia { get; set; }
            public int ThanhTien {get; set; }
        }

    }
}
