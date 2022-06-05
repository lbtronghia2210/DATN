using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frQLThucDon : Form
    {
        public frQLThucDon()
        {
            InitializeComponent();
        }
        DataTable dataThucDon = null;
        bool Them = false;
        string err;
        BLQuanLyThucDon BLTD = new BLQuanLyThucDon();
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        public string MaMonDangChon { get; set; }
        public string TenMonDangChon { get; set; }
        void loaddata()
        {
            try
            {
                dataThucDon = new DataTable();
                dataThucDon.Clear();

                BLTD.LayThucDon(dgvThucdon);
                dgvThucdon.AutoResizeColumns();
                grctrlThongTin.Enabled = false;

                // Xóa trống các đối tượng trong Panel
                this.txtMaMon.ResetText();
                this.txtTenMon.ResetText();
                this.txtDonViTinh.ResetText();
                this.txtDonGia.ResetText();
                this.cmbTenLoai.ResetText();


                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
                this.btnDuyet.Enabled = false;
                this.btnMacDinh.Enabled = false;
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                dgvThucdon_CellClick_1(null, null);
            }
            catch
            {
                BLTB.Show("Lỗi không lấy được cơ sở dữ liệu!");
            }

        }
        private void QLThucDon_Load(object sender, EventArgs e)
        {
            BLDS.DesignDgv(dgvThucdon);
            BLDS.DesignDgv2(dgvCongThuc);
            loaddata();
            BLTD.reloadTenMon(cmbTenLoai);
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them = true;
                // Xóa trống các đối tượng trong Panel
                this.txtMaMon.ResetText();
                this.txtTenMon.ResetText();
                this.txtDonViTinh.ResetText();
                this.txtDonGia.ResetText();
                this.cmbTenLoai.ResetText();
                this.picThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
                this.txtLink.Text = "No Image";
                // Cho thao tác trên các nút Lưu / Hủy / Panel
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.btnMacDinh.Enabled = true;
                this.grctrlThongTin.Enabled = true;
                this.btnDuyet.Enabled = true;
                // Không cho thao tác trên các nút Thêm / Xóa / Thoát
                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                // Đưa con trỏ đến TextField
                this.txtMaMon.Enabled = true;
                this.txtMaMon.Text = BLTD.TaoMaThucDon();
                this.txtMaMon.Focus();
            }
            catch
            {

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loaddata();
            BLTD.reloadTenMon(cmbTenLoai);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaMon = BLTD.LayMaMon(cmbTenLoai.Text);
            

            if (Them)
            {
                try
                {
                    
                    BLQuanLyThucDon BLTD = new BLQuanLyThucDon();
                    string linkAnh = "";
                    if (txtLink.Text != "No Image")
                        linkAnh = "HinhAnh\\" + Path.GetFileName(txtLink.Text);
                    else
                        linkAnh = "No Image";
                    BLTD.ThemThucDon(this.txtMaMon.Text, this.txtTenMon.Text, this.txtDonViTinh.Text, int.Parse(this.txtDonGia.Text), MaMon,linkAnh, ref err);
                    if (File.Exists(Environment.CurrentDirectory + "\\" + linkAnh) == false && txtLink.Text!="No Image")
                    {
                        File.Copy(txtLink.Text, Environment.CurrentDirectory + "\\" + linkAnh);
                    }
                    loaddata();
                    BLTB.Show("Đã thêm xong!");
                }
                catch
                {
                    BLTB.Show("Không thêm được, Lỗi rồi!");
                }
            }
            else
            {
                try
                {
                    BLQuanLyThucDon BLTD = new BLQuanLyThucDon();
                    string linkAnh = "";
                    if (txtLink.Text != "No Image")
                        linkAnh = "HinhAnh\\" + Path.GetFileName(txtLink.Text);
                    else
                        linkAnh = "No Image";
                    BLTD.CapNhatThucDon(this.txtMaMon.Text, this.txtTenMon.Text, this.txtDonViTinh.Text, int.Parse(this.txtDonGia.Text), MaMon,linkAnh, ref err);
                    if(File.Exists(Environment.CurrentDirectory + "\\" + linkAnh)==false && txtLink.Text != "No Image")
                    {
                        File.Copy(txtLink.Text, Environment.CurrentDirectory + "\\" + linkAnh);
                    }
                    loaddata();
                    BLTB.Show("Đã sửa xong!");
                }
                catch
                {
                    BLTB.Show("Không thêm được. Lỗi rồi!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.grctrlThongTin.Enabled = true;
            dgvThucdon_CellClick_1(null, null);

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnMacDinh.Enabled = true;
            this.grctrlThongTin.Enabled = true;
            this.btnDuyet.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaMon.Enabled = false;
            this.txtTenMon.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dgvThucdon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BLChonMon BLDM = new BLChonMon();
            BLCongThuc BLCT = new BLCongThuc();
            try
            {
                
                int r = dgvThucdon.CurrentCell.RowIndex;
                txtMaMon.Text = dgvThucdon.Rows[r].Cells[0].Value.ToString().Trim();
                MaMonDangChon = txtMaMon.Text;
                txtTenMon.Text = dgvThucdon.Rows[r].Cells[1].Value.ToString().Trim();
                TenMonDangChon = txtTenMon.Text;
                txtDonViTinh.Text = dgvThucdon.Rows[r].Cells[2].Value.ToString().Trim();
                txtDonGia.Text = dgvThucdon.Rows[r].Cells[3].Value.ToString().Trim();
                cmbTenLoai.Text = dgvThucdon.Rows[r].Cells[4].Value.ToString().Trim();
                BLCT.timCT(dgvCongThuc, MaMonDangChon);
                //BLTD.timCT(dgvCongThuc, dgvThucdon);
                //
                BLDM.LayHinhAnh(MaMonDangChon, picThucAn);
                txtLink.Text = BLDM.LayHinhAnh(MaMonDangChon);
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                int r = dgvThucdon.CurrentCell.RowIndex;
                string strTD =
                dgvThucdon.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLTD.XoaThucDon(ref err, strTD);
                    loaddata();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frQLCongThuc ct = new frQLCongThuc();
                ct.MaMonDangChon = MaMonDangChon;
                ct.TenMonDangChon = TenMonDangChon;
                ct.ShowDialog();
            }
            catch
            {

            }    
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string str = openFileDialog1.FileName;
                    txtLink.Text = str;
                    picThucAn.Image = Image.FromFile(str);
                }
            }
            catch
            {
                picThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                txtLink.Text = "No Image";
                picThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
            }
            catch
            {
                txtLink.Text = "No Image";
                picThucAn.Image = Image.FromFile("HinhAnh/amthucganh.jpg");
            }
        }

        private void txtLink_EditValueChanged(object sender, EventArgs e)
        {

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
