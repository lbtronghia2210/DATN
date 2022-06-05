using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLDoiMatKhau
    {
        BLThongBao BLTB = new BLThongBao();
        public void DoiMK(string TenDN, TextEdit txtMatKhauCu, TextEdit txtMatKhauMoi, TextEdit txtXacNhan, Form DoiMK)
        {

            QuanLyQuanAnEntities qlcfEntity = new QuanLyQuanAnEntities();
            var tk = (from a in qlcfEntity.TAIKHOANs
                      where a.TenDN == TenDN
                      select a).SingleOrDefault();

            if (tk != null)
            {
                if (tk.MatKhau.Trim() == MaHoa(txtMatKhauCu.Text) && txtMatKhauMoi.Text == txtXacNhan.Text)
                {
                    tk.MatKhau = MaHoa(txtMatKhauMoi.Text);
                    qlcfEntity.SaveChanges();
                    BLTB.Show("Đổi mật khẩu thành công");
                    DoiMK.Hide();
                }
                else
                {
                    BLTB.Show("Sai mật khẩu cũ hoặc mật khẩu mới không khớp!");
                }
            }
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
