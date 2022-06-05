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
    public partial class frChonMon : DevExpress.XtraEditors.XtraForm
    {
        bool check = false;
        string TenMon = "";
        string soluong = "";
        string trangThai = "";
        public string MaMonTrongChiTiet { get; set; }
        public string MaMonTrongThucDon { get; set; }
        public string MaBanDangChon { get; set; }
        public string MaNV { get; set; }
        public string MaPhieuTuDong { get; set; }
        string err;
        DateTime NgayTao = DateTime.Now;
        BLChonMon BLDM = new BLChonMon();
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        public frChonMon()
        {
            InitializeComponent();
        }

        private void DatMon_Load(object sender, EventArgs e)
        {
            BLDS.DesignDgv2(dgvThucDon);
            BLDS.DesignDgv(dgvChiTietDatMon);
            BLDM.KiemTraBan(MaBanDangChon, btnTaoPhieu, numSL);
            BLDM.TaoTenMon(cmbLoaiMon);
            groupControl4.Text = "Bàn " + MaBanDangChon + " Đã Đặt:";
            trangThai = BLDM.LayTrangThai(MaBanDangChon);
            if (btnTaoPhieu.Enabled == false)
            {
                tabMeNu.Enabled = true;
                LoadMonAn();
                btnXacNhan.Enabled = true;
            }
            else
                btnHuy.Enabled = true;
        }
        public void LoadMonAn()
        {

            try
            {
                BLDM.LayThucDon(dgvThucDon);
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
            }
            catch
            {

            }
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                MaPhieuTuDong = BLDM.LayMaHoaDon();
                BLDM.ThemPhieu(MaPhieuTuDong, NgayTao, MaBanDangChon, MaNV, "Không", "KH1", 0, ref err);
                BLQuanLyBan BLQLB = new BLQuanLyBan();
                trangThai = BLDM.LayTrangThai(MaBanDangChon);
                if (trangThai == "0" || trangThai == "1" || trangThai.Trim()!="BT")
                    BLQLB.CapNhatBan(MaBanDangChon, "1", ref err);
                btnHuy.Enabled = true;
                btnTaoPhieu.Enabled = false;
                tabMeNu.Enabled = true;
                LoadMonAn();
            }
            catch
            {

            }
        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                jbtnCapNhat.Enabled = false;
                jbtnXoa.Enabled = false;
                if (dgvThucDon.Rows.Count != 1)
                {
                    numSL.Enabled = true;
                }

                numSL.Value = 1;
                btnThemMonAn.Enabled = true;
                //numSL.Enabled = true;
                int r = dgvThucDon.CurrentCell.RowIndex;
                lblDangChon.Text = "Đang chọn " + dgvThucDon.Rows[r].Cells[1].Value.ToString().Trim();
                MaMonTrongThucDon = dgvThucDon.Rows[r].Cells[0].Value.ToString().Trim();
                lblSLCon.Text = BLDM.SoLuongHT(MaMonTrongThucDon).ToString();
                //if (check == false)
                //{
                //    btnTaoPhieu.Enabled = true;
                //}
                //check = true;
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
                BLDM.LayHinhAnh(MaMonTrongThucDon, picMonAn);
            }
            catch
            {

            }
        }

        private void dgvChiTietDatMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChiTietDatMon.RowCount > 1)
                {
                    jbtnXoa.Enabled = true;
                }
                else
                {
                    // btnXoaMon.Enabled = false;
                    jbtnXoa.Enabled = true;
                }
                int r = dgvChiTietDatMon.CurrentCell.RowIndex;
                MaMonTrongChiTiet = dgvChiTietDatMon.Rows[r].Cells[0].Value.ToString().Trim();
                lblSLCon.Text = BLDM.SoLuongHT(MaMonTrongChiTiet).ToString();
                TenMon = dgvChiTietDatMon.Rows[r].Cells[1].Value.ToString().Trim();
                numCapNhatSoLuong.Value = int.Parse(dgvChiTietDatMon.Rows[r].Cells[3].Value.ToString().Trim());
                jbtnCapNhat.Enabled = true;
                lblTen.Text = TenMon;
                //
                lblDangChon.Text = "Đang chọn " + dgvChiTietDatMon.Rows[r].Cells[1].Value.ToString().Trim();
                BLDM.LayHinhAnh(MaMonTrongChiTiet, picMonAn);
            }
            catch
            {

            }
        }

        private void numSL_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (numSL.Value != 0)
                {
                    if (BLDM.KiemTraNL(int.Parse(numSL.Value.ToString()), int.Parse(lblSLCon.Text)) == "0") // Kiểm tra số lượng có và cần
                    {
                        int r = dgvThucDon.CurrentCell.RowIndex;
                        int DonGia = int.Parse(dgvThucDon.Rows[r].Cells[2].Value.ToString().Trim());
                        BLDM.ThemChiTietThem(MaBanDangChon, MaPhieuTuDong, MaMonTrongThucDon, int.Parse(numSL.Value.ToString()), ref err);
                        //BLDM.ThemTemp(MaBanDangChon, MaPhieuTuDong, MaMonTrongThucDon, int.Parse(numSL.Value.ToString()), NgayTao, ref err);
                        BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
                        //BLTB.Show("Thêm món ăn vào thành công!");
                        BLDM.CapNhatKhiThem(BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongThucDon, int.Parse(numSL.Value.ToString()), int.Parse(lblSLCon.Text)); // Cập nhật lại nguyên liệu
                        lblSLCon.Text = BLDM.SoLuongHT(MaMonTrongThucDon).ToString();
                        //BLDM.KiemTraNguyenLieuThem(MaMonTrongThucDon, BLDM.LayMaHoaDon(MaBanDangChon));
                        btnXacNhan.Enabled = true;
                    }
                    else
                    {
                        BLTB.Show("Không đủ số lượng trong kho!");
                    }
                }
                else
                {
                    BLTB.Show("Số Lượng Không Được Bằng 0!");
                }
            }
            catch
            {
                BLTB.Show("Lỗi. Không Thêm Món Trùng Nhau!");
            }
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                BLTB.Show("Đã đặt món thành công!");
                this.Hide();
                //BLQuanLyBan BLQLB = new BLQuanLyBan();
                //BLQLB.CapNhatBan(MaBanDangChon, "1", ref err);
            }
            catch
            {
                BLTB.Show("Lỗi rồi!");
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            try
            {
                BLDM.XoaChiTietPhieu(ref err, BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet);
                BLTB.Show("Xóa khỏi danh sách thành công!");
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);

            }
            catch
            {
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                //BLDM.XoaChiTietPhieuKhiHuy(ref err, BLDM.LayMaHoaDon(MaBanDangChon));
                //BLDM.XoaTempKhiHuy(ref err, BLDM.LayMaHoaDon(MaBanDangChon));
                BLChonMon BLCM = new BLChonMon();
                BLCM.CapNhatKhiHuy(BLCM.LayMaHoaDon(MaBanDangChon));
                BLDM.XoaPhieu(ref err, BLDM.LayMaHoaDon(MaBanDangChon));
                BLQuanLyBan BLQLB = new BLQuanLyBan();
                BLQLB.CapNhatBan(MaBanDangChon, "0", ref err);
                BLTB.Show("Bạn đã hủy chọn món cho bàn thành công!");
                this.Hide();
            }
            catch
            {
                BLTB.Show("Bạn đã hủy đặt bàn thành công!");
                BLDM.XoaChiTietPhieuKhiHuy(ref err, MaPhieuTuDong);
                this.Hide();
            }
        }

        private void numCapNhatSoLuong_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCapNhatSoLuong_Click(object sender, EventArgs e)
        {
            GrctrlCapNhat.Enabled = true;
            btnXacNhan.Enabled = true;
        }

        private void xtraTabDoUong_Click(object sender, EventArgs e)
        {

            //BLDM.LayThucDonNU(dgvNuocUong);
            //BLDM.ThongTinBan(MaBanDangChon, dgvChiTietDatMon);


        }

        private void xtraTabThucAn_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabDoUong_Paint(object sender, PaintEventArgs e)
        {
            //BLDM.LayThucDonNU(dgvNuocUong);
            //BLDM.ThongTinBan(MaBanDangChon, dgvChiTietDatMon);
        }

        private void dgvNuocUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    int r = dgvNuocUong.CurrentCell.RowIndex;
            //    lblDangChon.Text = "Đang chọn " + dgvNuocUong.Rows[r].Cells[1].Value.ToString().Trim();
            //    MaMonTrongThucDon = dgvNuocUong.Rows[r].Cells[0].Value.ToString().Trim();
            //    if (check == false)
            //    {
            //        btnTaoPhieu.Enabled = true;
            //    }
            //    check = true;
            //    BLDM.ThongTinBan(MaBanDangChon, dgvChiTietDatMon);
            //}
            //catch
            //{

            //}
        }

        private void dgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            BLDM.TimKiemMenu(dgvThucDon, txtTimKiem, cmbLoaiMon);
        }

        private void jThinButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int SoLuongCu = BLDM.LaySoLuong(BLDM.LayMaHoaDon(MaBanDangChon), lblTen.Text);
                int SoLuongCon = BLDM.SoLuongHT(BLDM.LayMaMon(BLDM.LayMaHoaDon(MaBanDangChon), lblTen.Text));
                if (numCapNhatSoLuong.Value!=0 && SoLuongCu!=numCapNhatSoLuong.Value)
                {
                    //MessageBox.Show(""+SoLuongCu);
                    if (BLDM.KiemTraNL(int.Parse(numCapNhatSoLuong.Value.ToString()), SoLuongCon + SoLuongCu) == "0")
                    {
                        BLDM.CapNhatKhiCapNhat(BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet, int.Parse(numCapNhatSoLuong.Value.ToString()), SoLuongCu);// CAp nhat nguyen lieu
                        BLDM.CapNhatChiTietPhieu(BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet, int.Parse(numCapNhatSoLuong.Value.ToString()), ref err);//cap nhat chi tiet phieu
                        //BLDM.CapNhatChiTietTemp(BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet, int.Parse(numCapNhatSoLuong.Value.ToString()), NgayTao, ref err);
                        BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
                        BLTB.Show("Cập nhật thành công!");
                        lblSLCon.Text = BLDM.SoLuongHT(MaMonTrongChiTiet).ToString();
                        lblDangChon.Text = "Đang Chọn " + lblTen.Text;
                    }
                    else
                    {
                        BLTB.Show("Không đủ số lượng trong kho");
                    }

                }
                else
                {
                    BLTB.Show("Số Lượng Cập Nhật Không Được Bằng 0 Hoặc Không Thay Đổi!");
                }
            }
            catch
            {
                //BLDM.CapNhatChiTietPhieu(BLDM.LayMaPhieu(MaBanDangChon), MaMonTrongChiTiet, int.Parse(numCapNhatSoLuong.Value.ToString()), NgayTao, ref err);
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
            }
        }

        private void jbtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int SoLuongCu = BLDM.LaySoLuong(BLDM.LayMaHoaDon(MaBanDangChon), lblTen.Text);
                int SoLuongCon = BLDM.SoLuongHT(BLDM.LayMaMon(BLDM.LayMaHoaDon(MaBanDangChon), lblTen.Text));

                BLDM.CapNhatKhiCapNhat(BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet, 0, SoLuongCu);
                BLDM.XoaChiTietPhieu(ref err, BLDM.LayMaHoaDon(MaBanDangChon), MaMonTrongChiTiet);
                BLTB.Show("Xóa khỏi danh sách thành công!");
                lblSLCon.Text = (SoLuongCon + SoLuongCu).ToString();
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);

            }
            catch
            {
                BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLDM.TimKiemMenu(dgvThucDon, txtTimKiem, cmbLoaiMon);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if(MaMonTrongThucDon!=null)
                lblSLCon.Text = BLDM.SoLuongHT(MaMonTrongThucDon).ToString();
                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                if(BLXTT.kiemTraThayDoi(BLDM.LayMaHoaDon(MaBanDangChon),dgvChiTietDatMon)==1)
                {
                    BLDM.ThongTinBan(BLDM.LayMaHoaDon(MaBanDangChon), MaBanDangChon, dgvChiTietDatMon);
                }
            }
            catch
            {

            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            FrChiTietSoLuong ctsl = new FrChiTietSoLuong();
            ctsl.maMonDangChon = MaMonTrongThucDon;
            if (ctsl.maMonDangChon != null)
                ctsl.ShowDialog();
        }
    }
}
