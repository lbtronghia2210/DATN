using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frDangKiTK : Form
    {
        public frDangKiTK()
        {
            InitializeComponent();
        }
        string err;
        BLThongBao BLTB = new BLThongBao();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (jTextMK.TextValue == jTextNhapLaiMK.TextValue)
                {
                    BLCapQuyen BLCQ = new BLCapQuyen();
                    string hasPass = BLCQ.MaHoa(jTextMK.TextValue);
                    BLCQ.ThemTaiKhoan(jTextMaNV.TextValue, jTextTenDN.TextValue, hasPass, "Nhân Viên", "0", ref err);
                    BLTB.Show("Đã đăng kí thành công!");
                    this.Close();

                }
                else
                {
                    BLTB.Show("Mật khẩu không trùng khớp!");
                }
            }
            catch
            {
                BLTB.Show("Lỗi");
            }
        }
        public void kiemtra()
        {
            if (jTextMaNV.TextValue == "Mã Nhân Viên" || jTextTenDN.TextValue == "Tên Đăng Nhập" || jTextMK.TextValue == "Mật Khẩu" || jTextNhapLaiMK.TextValue == "Nhập Lại Mật Khẩu" || jTextMaNV.TextValue == "" || jTextTenDN.TextValue == "" || jTextMK.TextValue == "" || jTextNhapLaiMK.TextValue == "")
            {
                jbtnDangKi.Enabled = false;
            }
            else jbtnDangKi.Enabled = true;

        }
        
        private void DangKiTaiKhoan_Load(object sender, EventArgs e)
        {
            jbtnDangKi.ForeColor = Color.White;
            label1.Focus();
        }


        private void jTextMaNV_Load(object sender, EventArgs e)
        {
            
        }

        private void jTextMaNV_TextChangeEvent(object sender, EventArgs e)
        {
            kiemtra();
            jTextNhapLaiMK.ForeColor = Color.Silver;
            jTextMK.ForeColor = Color.Silver;
            jTextMaNV.ForeColor = Color.Black;
            jTextTenDN.ForeColor = Color.Silver;
        }

        private void jTextTenDN_TextChangeEvent(object sender, EventArgs e)
        {
            kiemtra();
            jTextNhapLaiMK.ForeColor = Color.Silver;
            jTextMK.ForeColor = Color.Silver;
            jTextMaNV.ForeColor = Color.Silver;
            jTextTenDN.ForeColor = Color.Black;
        }

        private void jTextMK_TextChangeEvent(object sender, EventArgs e)
        {
            kiemtra();
            jTextNhapLaiMK.ForeColor = Color.Silver;
            jTextMK.ForeColor = Color.Black;
            jTextMaNV.ForeColor = Color.Silver;
            jTextTenDN.ForeColor = Color.Silver;
        }

        private void jTextNhapLaiMK_TextChangeEvent(object sender, EventArgs e)
        {
            kiemtra();
            jTextNhapLaiMK.ForeColor = Color.Black;
            jTextMK.ForeColor = Color.Silver;
            jTextMaNV.ForeColor = Color.Silver;
            jTextTenDN.ForeColor = Color.Silver;
        }

        private void jbtnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                if (jTextMK.TextValue == jTextNhapLaiMK.TextValue)
                {
                    BLCapQuyen BLCQ = new BLCapQuyen();
                    string hasPass = BLCQ.MaHoa(jTextMK.TextValue.ToString());
                    //MessageBox.Show("" + hasPass);
                    BLCQ.ThemTaiKhoan(jTextMaNV.TextValue, jTextTenDN.TextValue, hasPass, "TK2", "0", ref err);
                    BLTB.Show("Đã đăng kí thành công!");
                    this.Close();

                }
                else
                {
                    BLTB.Show("Mật khẩu không trùng khớp!");
                }
            }
            catch
            {
                BLTB.Show("Lỗi");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn hủy đăng kí không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
                this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
