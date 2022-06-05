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
    public partial class frQLCongThuc : DevExpress.XtraEditors.XtraForm
    {
        public string MaMonDangChon { get; set; }
        public string TenMonDangChon { get; set; }
        BLThongBao BLTB = new BLThongBao();
        string MaNL = "";
        public frQLCongThuc()
        {
            InitializeComponent();
        }
        BLCongThuc BLCT = new BLCongThuc();
        BLDesign BLDS = new BLDesign();
        
        private void FormCongThuc_Load(object sender, EventArgs e)
        {
            try
            {
                BLDS.DesignDgv(dgvCongThuc);
                lblTenMonDangChon.Text = TenMonDangChon;
                BLCT.LayTenMonAn(cmbTenMon);
                cmbTenMon.Text = TenMonDangChon;
                //BLCT.timCT2(dgvCongThuc, MaMonDangChon);
                BLCT.LayTenNguyenLieu(cmbTenNL);
                BLCT.LayDonViTinh(lblDVT,cmbTenNL.Text);
            }
            catch
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BLCT.ThemCT(MaMonDangChon, cmbHamLuong.Text, cmbTenNL);
                BLCT.timCT2(dgvCongThuc, MaMonDangChon);
                BLTB.Show("Đã Thêm Xong!");
            }
            catch
            {

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                BLCT.XoaCT(MaMonDangChon, MaNL);
                BLCT.timCT2(dgvCongThuc, MaMonDangChon);
                BLTB.Show("Đã Xóa Xong!");
            }
            catch
            {

            }
        }

        private void dgvCongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvCongThuc.CurrentCell.RowIndex;
            MaNL = dgvCongThuc.Rows[r].Cells[0].Value.ToString();

        }

        private void cmbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BLCT.LayTenMonAn(cmbTenMon);
            BLChonMon BLCM = new BLChonMon();
            MaMonDangChon = BLCM.LayMaMon(cmbTenMon.Text);
            BLCT.timCT2(dgvCongThuc, MaMonDangChon);
            lblTenMonDangChon.Text = cmbTenMon.Text;
            MaMonDangChon = BLCM.LayMaMon(cmbTenMon.Text);
        }

        private void cmbTenNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCT.LayDonViTinh(lblDVT, cmbTenNL.Text);
            }
            catch
            {

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
