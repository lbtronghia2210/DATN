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
    public partial class FrQLKhach : Form
    {
        BLQLKhach BLQLK = new BLQLKhach();
        BLDesign BLD = new BLDesign();
        BLThongBao BLTB = new BLThongBao();
        bool Them;
        string err = "";
        public FrQLKhach()
        {
            InitializeComponent();
            
        }
        public void loadData()
        {
            try
            {
                dgvKH.DataSource = BLQLK.layKhach();
                BLD.DesignDgv(dgvKH);

                this.txtMaKhach.ResetText();
                this.txtTenKhach.ResetText();
                this.txtSDT.ResetText();
                this.txtMaThue.ResetText();

                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;

                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                dgvKH_CellClick(null, null);
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them = true;
                this.txtMaKhach.ResetText();
                this.txtMaThue.ResetText();
                this.txtSDT.ResetText();
                this.txtTenKhach.ResetText();

                txtMaKhach.Text = BLQLK.TaoMaKH();

                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                txtMaKhach.Enabled = true;
                txtTenKhach.Focus();

            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLQLK.xoaKH(ref err, txtMaKhach.Text);
                    loadData();
                    BLTB.Show("Đã xóa xong!");
                }
                else
                {
                    BLTB.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch
            {
                BLTB.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.grctrlThongTin.Enabled = true;


            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;


            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaKhach.Enabled = false;
            this.txtTenKhach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLQLK.themKH(txtMaKhach.Text, txtTenKhach.Text, txtSDT.Text, txtMaThue.Text,ref err);
                    loadData();
                    BLTB.Show("Đã thêm xong!");
                }
                catch
                {
                    BLTB.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                try
                {

                    BLQLK.capNhatKhach(txtMaKhach.Text, txtTenKhach.Text, txtSDT.Text, txtMaThue.Text, ref err);
                    loadData();
                    BLTB.Show("Đã sửa xong!");

                }
                catch
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaKhach.ResetText();
            this.txtMaThue.ResetText();
            this.txtSDT.ResetText();
            this.txtTenKhach.ResetText();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKH.CurrentCell.RowIndex;

            txtMaKhach.Text = dgvKH.Rows[r].Cells[0].Value.ToString();
            txtTenKhach.Text = dgvKH.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = dgvKH.Rows[r].Cells[2].Value.ToString();
            txtMaThue.Text = dgvKH.Rows[r].Cells[3].Value.ToString();
        }

        private void FrQLKhach_Load(object sender, EventArgs e)
        {
            loadData();
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
