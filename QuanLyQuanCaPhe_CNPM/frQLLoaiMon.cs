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
    public partial class frQLLoaiMon : Form
    {
        DataTable dataLoaimon = null;
        bool Them = false;
        BLQuanLyLoaiMon BLLM = new BLQuanLyLoaiMon();
        string err;
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        public frQLLoaiMon()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            try
            {
                dataLoaimon = new DataTable();
                dataLoaimon.Clear();
                dgvLoaiMon.DataSource = BLLM.LayLoaiMon();
                dgvLoaiMon.AutoResizeColumns();
                grctrlThongTin.Enabled = false;

                // Xóa trống các đối tượng trong Panel
                this.txtMaLoai.ResetText();
                this.txtTenLoai.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                dgvLoaiMon_CellClick(null, null);
                
            }
            catch
            {
                MessageBox.Show("Lỗi không lấy được cơ sở dữ liệu!");
            }
        }
        private void QLLoaiMon_Load(object sender, EventArgs e)
        {
            BLDS.DesignDgv(dgvLoaiMon);
            BLDS.DesignDgv2(dgvTimMonAn);
            try
            {
                loadData();
                BLLM.TaoTenMon(cmbTimKiem);
            }
            catch { }
        }

        private void dgvTimMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLoaiMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvLoaiMon.CurrentCell.RowIndex;
                txtMaLoai.Text = dgvLoaiMon.Rows[r].Cells[0].Value.ToString();
                txtTenLoai.Text = dgvLoaiMon.Rows[r].Cells[1].Value.ToString();
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

                this.txtMaLoai.ResetText();
                this.txtTenLoai.ResetText();

                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.txtMaLoai.Enabled = true;
                this.txtMaLoai.Text = BLLM.TaoMaLoai();
                this.txtMaLoai.Focus();
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = dgvLoaiMon.CurrentCell.RowIndex;
                string strLM =
                dgvLoaiMon.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLLM.XoaLoaiMon(ref err, strLM);
                    loadData();
                    BLLM.TaoTenMon(cmbTimKiem);
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
            dgvLoaiMon_CellClick(null, null);

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlThongTin.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaLoai.Enabled = false;
            this.txtTenLoai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {

                    BLQuanLyLoaiMon BLQLM = new BLQuanLyLoaiMon();
                    BLQLM.ThemLoaiMon(this.txtMaLoai.Text, this.txtTenLoai.Text, ref err);
                    loadData();
                    BLQLM.TaoTenMon(cmbTimKiem);
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
                    BLQuanLyLoaiMon BLQLM = new BLQuanLyLoaiMon();
                    BLQLM.CapNhatLoaiMon(this.txtMaLoai.Text, this.txtTenLoai.Text, ref err);
                    loadData();
                    BLQLM.TaoTenMon(cmbTimKiem);
                    // Thông báo
                    BLTB.Show("Đã sửa xong!");
                }
                catch
                {
                    BLTB.Show("Không sửa được. Lỗi rồi!");
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaLoai.ResetText();
            this.txtTenLoai.ResetText();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;

            dgvLoaiMon_CellClick(null, null);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
            cmbTimKiem.ResetText();
        }

        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLLM.TimKiem(cmbTimKiem, dgvTimMonAn);
            }
            catch
            {

            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

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
