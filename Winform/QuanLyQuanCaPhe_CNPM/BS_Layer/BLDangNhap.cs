using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLDangNhap
    {
        public int DangNhap(string TenDN, string MK)
        {
            MK = MaHoa(MK);
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tk = from p in qlcf.TAIKHOANs
                     where p.TenDN.Trim()== TenDN && p.MatKhau.Trim() == MK
                     select p;
            int a = tk.Count();
            return a;
        }
        
        public string LayTenNV(string TenDN, string MK)
        {
            string TenNV = "";
            MK = MaHoa(MK);
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var q = (from p in qlcf.TAIKHOANs join
                     nv in qlcf.NHANVIENs on p.MaNV equals nv.MaNV
                     where p.TenDN.Trim() == TenDN && p.MatKhau.Trim() == MK && p.MaNV ==nv.MaNV
                     select new { nv.HoTen,nv.MaNV,p.MaLoaiTK}).ToList();
            if (q.Count != 0)
            {
                foreach (var i in q)
                {
                    TenNV = i.HoTen.Trim();
                    return TenNV;
                }
            }
            return TenNV;
        }
        
        public string LayQuyen(string TenDN, string MK)
        {
            MK = MaHoa(MK);
            string Quyen = "";
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var r = (from p in qlcf.TAIKHOANs join q in qlcf.LOAITAIKHOANs on p.MaLoaiTK equals q.MaLoaiTK
                     where p.TenDN.Trim() == TenDN && p.MatKhau.Trim() == MK
                     select new {q.TenLoaiTK }).ToList();
            if (r.Count != 0)
            {
                foreach (var i in r)
                {
                    Quyen = i.TenLoaiTK.Trim();
                    return Quyen;
                }
            }
            return Quyen;
        }
        public string LayMaNV(string TenDN)
        {
            //MK = MaHoa(MK);
            string MaNV = "";
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var q = (from p in qlcf.TAIKHOANs
                     where p.TenDN.Trim() == TenDN
                     select new { p.MaNV }).ToList();
            if (q.Count != 0)
            {
                foreach (var i in q)
                {
                    MaNV = i.MaNV.Trim();
                    return MaNV;
                }
            }
            return MaNV;
        }
        public bool ThemChamCong(string MaNV, string NgayLam, string Ca, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            CHAMCONG cc = new CHAMCONG();
            cc.MaNV = MaNV;
            cc.NgayLam = DateTime.Parse(NgayLam);
            cc.MaCa = Ca;
            qlcfEntity.CHAMCONGs.Add(cc);
            qlcfEntity.SaveChanges();
            return true;
        }
        public string MaHoa(string MK)
        {
            MD5 mH = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(MK);
            byte[] hash = mH.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().Substring(0,15);
        }
        public void startServer(string name)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.FileName = name;
            p.Start();
        }
        public void stopServer(string name)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM cmd.exe /T");
        }
        public string getIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Can't Find";
        }
    }
}
