using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLCapQuyen
    {
        public DataTable LayThongTin()
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var tk = (from p in qlcfEntity.TAIKHOANs
                      join q in qlcfEntity.NHANVIENs on p.MaNV equals q.MaNV
                      select new { p.MaNV, q.HoTen, p.TenDN, p.MaLoaiTK }).ToList();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Tên Đăng Nhập");
            dt.Columns.Add("Quyền");

            foreach (var p in tk)
            {
                dt.Rows.Add(p.MaNV.Trim(), p.HoTen.Trim(),p.TenDN.Trim(), p.MaLoaiTK.Trim());
            }
            return dt;
        }
        public bool ThemTaiKhoan(string MaNV, string TenDN, string MK, string Quyen,string TrangThai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            TAIKHOAN Dn = new TAIKHOAN();
            Dn.MaNV = MaNV;
            Dn.TenDN = TenDN;
            Dn.MatKhau = MK;
            Dn.MaLoaiTK = Quyen;
            Dn.TrangThai = TrangThai;
            qlcfEntity.TAIKHOANs.Add(Dn);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool XoaTaiKhoan(ref string err, string TenDN)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            TAIKHOAN Dn = new TAIKHOAN();
            Dn.TenDN = TenDN;
            qlcfEntity.TAIKHOANs.Attach(Dn);
            qlcfEntity.TAIKHOANs.Remove(Dn);
            qlcfEntity.SaveChanges();
            return true;
        }
        public bool CapNhatTaiKhoan(string MaNV, string TenDN, string Quyen, string TrangThai, ref string err)
        {
            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var dn = (from a in qlcfEntity.TAIKHOANs
                      where a.TenDN == TenDN
                      select a).SingleOrDefault();
            if (dn != null)
            {
                //nv.MaNV = MaNV;
                //dn.MatKhau = MK;
                dn.MaLoaiTK = Quyen;
                qlcfEntity.SaveChanges();
            }
            return true;
        }
        public void layTenNV(TextEdit txtTenNV, TextEdit txtMaNV)
        {
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var tennv = (from x in qlcf.NHANVIENs
                         where x.MaNV == txtMaNV.Text
                         select new { x.HoTen }).ToList();
            if (tennv.Count == 0)
                txtTenNV.ResetText();
            else
            {
                foreach (var a in tennv)
                {
                    txtTenNV.Text = a.HoTen;
                }
            }
           
              
        }
        public string layQuyen(string TenTK)
        {
            QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
            var q = from i in ql.LOAITAIKHOANs
                    where i.TenLoaiTK.Trim() == TenTK.Trim()
                    select new
                    {
                        i.MaLoaiTK
                    };
            //MessageBox.Show("" + TenTK);
            foreach(var y in q)
            {
                return y.MaLoaiTK;
            }
            return "";

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
            return sb.ToString().Substring(0, 15);
        }
    }
}
