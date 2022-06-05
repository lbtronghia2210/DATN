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
    public partial class frQLNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        public frQLNguyenLieu()
        {
            InitializeComponent();
        }
        BLDesign BLDS = new BLDesign();
        BLNguyenLieu BLNL = new BLNguyenLieu();
        BLThongBao BLTB = new BLThongBao();
        bool Them;
        string err = "";
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        void LoadData()
        {
            BLDS.DesignDgv(dgvNL);
            try
            {
                //Lấy dữ liệu
                BLNL.LayNguyenLieu(dgvNL);
                // Xử lý giao diện
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grThongTin.Enabled = false;

                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                // Reset trống các TextEdit
                this.txtMaNL.ResetText();
                this.txtTenNL.ResetText();
                dgvNL_CellClick(null, null);
            }
            catch
            {
                BLTB.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNL.Focus();
                Them = true;
                this.txtMaNL.ResetText();
                this.txtTenNL.ResetText();
                this.txtDVT.ResetText();
                this.txtSLCon.ResetText();
                // Cho thao tác trên các nút Lưu / Hủy / Panel
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grThongTin.Enabled = true;
                // Không cho thao tác trên các nút Thêm / Xóa / Thoát
                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                txtMaNL.Text = BLNL.TaoMaNguyenLieu();
                txtMaNL.Enabled = true;
            }
            catch
            {

            }
        }

        private void QuanLyNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    //BLNguyenLieu BLNL = new BLNguyenLieu();
                    BLNL.ThemNguyenLieu(txtMaNL.Text, txtTenNL.Text,txtDVT.Text,txtSLCon.Text, ref err);
                    LoadData();
                    // Thông báo
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
                    //BLNguyenLieu BLNL = new BLNguyenLieu();
                    BLNL.CapNhatNguyenLieu(txtMaNL.Text, txtTenNL.Text,txtDVT.Text,txtSLCon.Text, ref err);
                    LoadData();
                    // Thông báo
                    BLTB.Show("Đã thêm xong!");
                }
                catch
                {
                    BLTB.Show("Không sửa được!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvNL.CurrentCell.RowIndex;
                string strNL = dgvNL.Rows[r].Cells[0].Value.ToString();
                //MessageBox.Show(strNL);
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLNL.XoaNguyenLieu(ref err, strNL);
                    LoadData();
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

        private void dgvNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int r = dgvNL.CurrentCell.RowIndex;
                txtMaNL.Text = dgvNL.Rows[r].Cells[0].Value.ToString();
                txtTenNL.Text = dgvNL.Rows[r].Cells[1].Value.ToString();
                txtDVT.Text = dgvNL.Rows[r].Cells[2].Value.ToString();
                txtSLCon.Text = dgvNL.Rows[r].Cells[3].Value.ToString();
                //THong Tin Luong
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xử lý giao diện
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grThongTin.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            // Reset trống các TextEdit
            this.txtMaNL.ResetText();
            this.txtTenNL.ResetText();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.grThongTin.Enabled = true;
            //dgvNL_CellClick(null, null);

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;


            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaNL.Enabled = false;
            this.txtTenNL.Focus();
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
