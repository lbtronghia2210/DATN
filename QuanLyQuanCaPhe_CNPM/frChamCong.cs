using QuanLyQuanCaPhe_CNPM.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frChamCong : Form
    {
        public frChamCong()
        {
            InitializeComponent();
        }
        BLChamCong BLCC = new BLChamCong();
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        string err = "";
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            loadCa();
            BLDS.DesignDgv(dgvChamCong);
            BLDS.DesignDgv(dgvNhanVien);
            BLCC.LayNhanVien(dgvNhanVien);
            dgvNhanVien_CellClick(null, null);
            BLCC.ThemNam(txtNam);
            BLCC.ThemNgay(txtNgay);
            BLCC.ThemThang(txtThang);
            BLCC.LayNgay(txtNgay, txtThang, txtNam);
            lblThongTin.Text = "Danh Sách Nhân Viên Làm Ngày: " + txtNgay.Text+"/"+ txtThang.Text+"/" + txtNam.Text+" " + cmbCa.Text;
        }
      
        public void loadCa()
        {
            for (int i = cmbCa.Properties.Items.Count - 1; i >= 0; i--)
            {
                cmbCa.Properties.Items.RemoveAt(i);
            }
            BLCC.LayCa(cmbCa);
        }
        private void txtNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtNgay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void cmbCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void cmbCa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thấy Nhân Viên Nào!");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvNhanVien.CurrentCell.RowIndex;
                txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
                btnThem.Enabled = true;
            }
            catch
            {

            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string day = txtNgay.Text + "/" + txtThang.Text + "/" + txtNam.Text;
                BLCC.ThemChamCong(txtMaNV.Text, day, cmbCa.Text, ref err);
                BLTB.Show("Đã thêm thành công " + txtTenNV.Text + ".Vào ngày " + day + " Ca " + cmbCa.Text);
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
                btnThem.Enabled = false;

            }
            catch
            {
                BLTB.Show("Lỗi. Đã Tồn Tại!");
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa,lblThongTin);
            }
        }
    

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Parse(txtNgay.Text + "/" + txtThang.Text + "/" + txtNam.Text);
                int r = dgvChamCong.CurrentCell.RowIndex;
                BLCC.XoaNhanVien(d, cmbCa.Text, dgvChamCong.Rows[r].Cells[0].Value.ToString());
                BLCC.LayThongTinNgayLam(dgvChamCong, txtNgay, txtThang, txtNam, cmbCa, lblThongTin);
                BLTB.Show("Xóa Thành Công");
                btnXoa.Enabled = false;

            }
            catch
            {
                BLTB.Show("Xóa Thất Bại");
            }
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void BtnTimTen_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
