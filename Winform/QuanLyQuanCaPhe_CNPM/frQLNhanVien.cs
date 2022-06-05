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
    public partial class frQLNhanVien : Form
    {
        public frQLNhanVien()
        {
            InitializeComponent();
        }
        //List<string> DSTinh = new List<string>();

        bool Them;
        string err;
        BLNhanVien BLNV = new BLNhanVien();
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        void LoadData()
        {
            BLDS.DesignDgv(dgvQLNV);
            try
            {
                //Lấy dữ liệu
                dgvQLNV.DataSource = BLNV.LayNhanVien();
                dgvQLNV.AutoResizeColumns();
                BLNV.reloadDiaChi(cmbDiaChi);
                // Xử lý giao diện
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                // Reset trống các TextEdit
                this.txtMaNhanVien.ResetText();
                this.txtHoTen.ResetText();
                this.txtPhai.ResetText();
                this.deditNgaySinh.ResetText();
                this.deditVaoLam.ResetText();
                this.txtDiaChi.ResetText();
                this.txtLuongCB.ResetText();
                this.txtSDT.ResetText();
                this.cmbDiaChi.Text = "Tất Cả";
                this.cmbLocGioiTinh.Text = "Tất Cả";
                this.BtnTimTen.ResetText();
                dgvQLNV_CellClick_1(null, null);
            }
            catch
            {
                BLTB.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
        }
        

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if(Them)
            {
                try
                {
                    // Thực hiện lệnh
                    BLNhanVien BLNV = new BLNhanVien();
                    BLNV.ThemNhanVien(txtMaNhanVien.Text, txtHoTen.Text, txtPhai.Text, deditNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, deditVaoLam.Text, txtLuongCB.Text, ref err);
                    // Load lại dữ liệu trên DataGridView
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
                    // Thực hiện lệnh
                    BLNhanVien BLNV = new BLNhanVien();
                    BLNV.CapNhatNhanvien(txtMaNhanVien.Text, txtHoTen.Text, txtPhai.Text, deditNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, deditVaoLam.Text, txtLuongCB.Text, ref err);
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    BLTB.Show("Đã sửa xong!");
                }
                catch
                {
                    BLTB.Show("Không sửa được!");
                }
               
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them = true;
                this.txtMaNhanVien.ResetText();
                this.txtHoTen.ResetText();
                this.txtPhai.ResetText();
                this.deditNgaySinh.ResetText();
                this.deditVaoLam.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.txtLuongCB.ResetText();
                // Cho thao tác trên các nút Lưu / Hủy / Panel
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;
                // Không cho thao tác trên các nút Thêm / Xóa / Thoát
                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;

                this.txtMaNhanVien.Enabled = true;
                this.txtMaNhanVien.Focus();
                deditVaoLam.Text = System.DateTime.Now.ToString();
                txtMaNhanVien.Text = BLNV.TaoMaNhanVien();
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvQLNV.CurrentCell.RowIndex;
                string strNV =
                dgvQLNV.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLNV.XoaNhanvien(ref err, strNV);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.grctrlThongTin.Enabled = true;
            dgvQLNV_CellClick_1(null, null);

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaNhanVien.Enabled = false;
            this.txtMaNhanVien.Focus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xử lý giao diện
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            // Reset trống các TextEdit
            this.txtMaNhanVien.ResetText();
            this.txtHoTen.ResetText();
            this.txtPhai.ResetText();
            this.deditNgaySinh.ResetText();
            this.deditVaoLam.ResetText();
            this.txtDiaChi.ResetText();
            this.txtLuongCB.ResetText();
            this.txtSDT.ResetText();
        }
        

        private void cmbLocGioiTinh_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbDiaChi_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvQLNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int r = dgvQLNV.CurrentCell.RowIndex;
                txtMaNhanVien.Text = dgvQLNV.Rows[r].Cells[0].Value.ToString();
                txtHoTen.Text = dgvQLNV.Rows[r].Cells[1].Value.ToString();
                txtPhai.Text = dgvQLNV.Rows[r].Cells[2].Value.ToString();
                deditNgaySinh.Text = dgvQLNV.Rows[r].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvQLNV.Rows[r].Cells[4].Value.ToString();
                txtSDT.Text = dgvQLNV.Rows[r].Cells[5].Value.ToString();
                deditVaoLam.Text = dgvQLNV.Rows[r].Cells[6].Value.ToString();
                txtLuongCB.Text = dgvQLNV.Rows[r].Cells[7].Value.ToString();
                //THong Tin Luong
                BLNhanVien qlnv = new BLNhanVien();
                qlnv.LayLuong(lblTongCa, lbTongTien, txtMaNhanVien.Text.Trim(), txtLuongCB);
            
            }
            catch { }
        }

        private void txtTimTen_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BLNV.Loc(cmbLocGioiTinh, cmbDiaChi, BtnTimTen, dgvQLNV);
                if (BtnTimTen.Text == "" && cmbLocGioiTinh.Text == "Tất Cả" && cmbDiaChi.Text == "Tất Cả")
                    LoadData();
            }
            catch { }
        }

        private void cmbDiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbLocGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
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
