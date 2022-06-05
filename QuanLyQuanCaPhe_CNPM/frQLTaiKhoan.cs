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
    public partial class frQLTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frQLTaiKhoan()
        {
            InitializeComponent();
        }
        DataTable dtcq = null;
        bool Them = false;
        string err;
        BLCapQuyen BLCQ = new BLCapQuyen();
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        public void loadData()
        {
            try
            {
                dtcq = new DataTable();
                dgvDangNhap.DataSource = BLCQ.LayThongTin();
                dgvDangNhap.AutoResizeColumns();
                grctrlThongTin.Enabled = false;
                // Xóa trống các đối tượng trong Panel

                this.txtMaNV.ResetText();
                //this.txtMatKhau.ResetText();
                this.txtTenDangNhap.ResetText();
                this.txtTenNV.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                dgvDangNhap_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Lỗi không lấy được cơ sở dữ liệu!");
            }
        }
        private void CapQuyen_Load(object sender, EventArgs e)
        {
            BLDS.DesignDgv(dgvDangNhap);
            loadData();
        }

        private void dgvDangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvDangNhap.CurrentCell.RowIndex;
                txtMaNV.Text = dgvDangNhap.Rows[r].Cells[0].Value.ToString().Trim();
                txtTenNV.Text = dgvDangNhap.Rows[r].Cells[1].Value.ToString().Trim();
                txtTenDangNhap.Text = dgvDangNhap.Rows[r].Cells[2].Value.ToString().Trim();
                string a = dgvDangNhap.Rows[r].Cells[3].Value.ToString().Trim();
                if (a == "TK1")
                    radCQ.Checked = true;
                else
                    radNV.Checked = true;
            }
            catch
            {

            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Them = true;
                //// Xóa trống các đối tượng trong Panel

                //this.txtMaNV.ResetText();
                //this.txtMatKhau.ResetText();
                //this.txtTenDangNhap.ResetText();
                //this.txtTenNV.ResetText();
                //// Cho thao tác trên các nút Lưu / Hủy / Panel
                //this.btnLuu.Enabled = true;
                //this.btnHuy.Enabled = true;
                //this.grctrlThongTin.Enabled = true;

                //this.txtMaNV.Enabled = true;
                //this.txtTenDangNhap.Enabled = true;
                //this.txtTenNV.Enabled = false;
                //this.txtMatKhau.Enabled = true;
                //// Không cho thao tác trên các nút Thêm / Xóa / Thoát
                //this.btnThem.Enabled = false;
                //this.btnSua.Enabled = false;
                //this.btnXoa.Enabled = false;
                //// Đưa con trỏ đến TextField txtThanhPho
                //this.txtMaNV.Enabled = true;
                //this.txtMaNV.Enabled = true;

                //this.txtMaNV.Focus();
                frDangKiTK dk = new frDangKiTK();
                dk.ShowDialog();
                loadData();
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                Them = false;
                dgvDangNhap_CellClick(null, null);
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;

                this.txtMaNV.Enabled = false;
                //this.txtTenDangNhap.Enabled = false;
                this.txtTenNV.Enabled = false;
                //this.txtMatKhau.Enabled = false;
            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string a;
            if (radCQ.Checked == false)
                a = "Nhân Viên";
            else
                a = "Chủ Quán";
            // Thực hiện lệnh
            BLCapQuyen BLCQ = new BLCapQuyen();
            BLCQ.CapNhatTaiKhoan(txtMaNV.Text, txtTenDangNhap.Text, BLCQ.layQuyen(a), "0", ref err);
            // Load lại dữ liệu trên DataGridView
            loadData();
            // Thông báo
            BLTB.Show("Đã sửa xong!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = dgvDangNhap.CurrentCell.RowIndex;
                string strNV =
                dgvDangNhap.Rows[r].Cells[2].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLCQ.XoaTaiKhoan(ref err, strNV);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMaNV.ResetText();
                //this.txtMatKhau.Text = "*************************";
                this.txtTenDangNhap.ResetText();
                this.txtTenNV.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                dgvDangNhap_CellClick(null, null);
            }
            catch
            {

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BLCQ.layTenNV(txtTenNV, txtMaNV);
            }
            catch
            {
                txtTenNV.ResetText();
            }
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
