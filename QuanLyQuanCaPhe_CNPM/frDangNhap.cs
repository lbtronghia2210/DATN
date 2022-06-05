using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public string Quyen { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string TenNV { get; set; }
        public string MaNV { get; set; }
        string err;
        DateTime NgayLam = System.DateTime.Now;
        BLThongBao BLTB = new BLThongBao();
        public frDangNhap()
        {
            InitializeComponent();
        }
        //public string layCa(DateTime NgayLam)
        //{
        //    int hour = NgayLam.TimeOfDay.Hours;
        //    if (hour >= 6 && hour <= 12)
        //        return "Ca Sáng";
        //    if (hour > 12 && hour <= 18)
        //        return "Ca Chiều";
        //    else
        //        return "Ca Đêm";
        //    return "";  
        //}
        public void LayTaiKhoan()
        {
            try
            {
                BLDangNhap BLDN = new BLDangNhap();
                int a = BLDN.DangNhap(txtUserName.TextName.ToString(), txtPassWord.TextName.ToString());
                if (a != 0)
                {
                    // Lấy Dữ Liệu
                    BLThongBao BLTB = new BLThongBao();
                    //BLTB.Show("Đăng Nhập Thành Công!");
                    frHome home = new frHome();
                    home.TenDN = txtUserName.TextName.ToString();
                    home.MatKhau = txtPassWord.TextName.ToString();
                    home.MaNV = BLDN.LayMaNV(txtUserName.TextName.ToString());
                    home.Quyen = BLDN.LayQuyen(txtUserName.TextName.ToString(), txtPassWord.TextName.ToString());
                    home.TenNV = BLDN.LayTenNV(txtUserName.TextName.ToString(), txtPassWord.TextName.ToString());
                    home.TenDN = txtUserName.TextName.ToString();
                    home.IP = BLDN.getIP();
                   //BLDN.ThemChamCong(home.MaNV, NgayLam.ToString(), layCa(NgayLam), ref err);
                    // Mở Form Home
                    this.Hide();
                    home.ShowDialog();
                    this.Show();
                }
                else
                {
                    BLTB.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu. Kiểm Tra Lại !");
                }
            }
            catch
            {
                try
                {
                    BLDangNhap BLDN = new BLDangNhap();
                    frHome home = new frHome();
                    home.TenDN = txtUserName.TextName.ToString();
                    home.MatKhau = txtPassWord.TextName.ToString();
                    home.MaNV = BLDN.LayMaNV(txtUserName.TextName.ToString());
                    home.Quyen = BLDN.LayQuyen(txtUserName.TextName.ToString(), txtPassWord.TextName.ToString());
                    home.TenNV = BLDN.LayTenNV(txtUserName.TextName.ToString(), txtPassWord.TextName.ToString());
                    home.TenDN = txtUserName.TextName.ToString();
                    //BLDN.ThemChamCong(home.MaNV, NgayLam.ToString(), layCa(NgayLam), ref err);
                    // Mở Form Home
                    this.Hide();

                    home.ShowDialog();

                    this.Show();
                }
                catch
                {

                }
            }
        }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                DialogResult a = MessageBox.Show("Bạn có muốn thoát chương trình không", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                    this.Close();
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //frDangKiTK dk = new frDangKiTK();
                //this.Hide();
                //dk.ShowDialog();
                //this.Show();
            }
            catch
            {

            }
        }

        private void jTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LayTaiKhoan();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtUserName_Load(object sender, EventArgs e)
        {

        }

        private void jThinButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BLDangNhap BLDN = new BLDangNhap();
                if (File.Exists("server.bat"))
                {
                    BLDN.startServer("server.bat");
                }
                LayTaiKhoan(); 
            }
            catch
            {

            }
        }

        private void jThinButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                LayTaiKhoan();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
