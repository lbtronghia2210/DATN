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
    public partial class frQLKhuVuc : DevExpress.XtraEditors.XtraForm
    {
        public frQLKhuVuc()
        {
            InitializeComponent();
        }
        BLKhuVuc BLKV = new BLKhuVuc();
        BLDesign BLDS = new BLDesign();
        BLThongBao BLTB = new BLThongBao();
        bool Them = false;
        string err;
        public void loadData()
        {
            try
            {
                BLDS.DesignDgv(dgvKhuVuc);
                BLKV.LayKhuVuc(dgvKhuVuc);
                grctrlThongTin.Enabled = false;

                // Xóa trống các đối tượng trong Panel
                this.txtMaKV.ResetText();
                this.txtTenKV.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                dgvKhuVuc_CellClick(null, null);

            }
            catch
            {
                BLTB.Show("Lỗi không lấy được cơ sở dữ liệu!");
            }
        }

        private void QLKhuVuc_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvKhuVuc.CurrentCell.RowIndex;
                txtMaKV.Text = dgvKhuVuc.Rows[r].Cells[0].Value.ToString();
                txtTenKV.Text = dgvKhuVuc.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them = true;

                this.txtMaKV.ResetText();
                this.txtTenKV.ResetText();

                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.txtMaKV.Enabled = true;
                this.txtMaKV.Text = BLKV.TaoMaKV();
                this.txtMaKV.Focus();
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvKhuVuc.CurrentCell.RowIndex;
                string strKV =
                dgvKhuVuc.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLKV.XoaKhuVuc(strKV,ref err);
                    loadData();
                    //BLLM.TaoTenMon(cmbTimKiem);
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
            dgvKhuVuc_CellClick(null, null);

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlThongTin.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaKV.Enabled = false;
            this.txtTenKV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLKV.ThemKhuVuc(txtMaKV.Text, txtTenKV.Text, ref err);
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
                    // Thực hiện lệnh
                    BLKV.CapNhatKhuVuc(txtMaKV.Text, txtTenKV.Text, ref err);
                    loadData();
                    // Thông báo
                    BLTB.Show("Đã sửa xong!");
                }
                catch
                {
                    BLTB.Show("Không sửa được. Lỗi rồi!");
                }

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaKV.ResetText();
            this.txtTenKV.ResetText();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;

            dgvKhuVuc_CellClick(null, null);
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
