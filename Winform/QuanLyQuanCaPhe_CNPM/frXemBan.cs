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
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraBars;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frXemBan : DevExpress.XtraEditors.XtraForm
    {
        public string MaBanDangChon { get; set; }
        public string MaMonAn { get; set; } //lay de tra lai
        public string MaBanMoi { get; set; }
        public string MaNV { get; set; }
        public string TenMonAn { get; set; }
        public string SL { get; set; }
        public double gt = 0;
        BLThongBao BLTB = new BLThongBao();
        BLDesign BLDS = new BLDesign();
        BLChonMon BLCM = new BLChonMon();
        public frXemBan()
        {
            InitializeComponent();
        }
        string err;
        int temp = 0;
        BLXemThongTinBan BLXTT = new BLXemThongTinBan();
        public class Ban
        {
            //public string TrangThai;
            public SimpleButton A;
            public Label lblTenban;
            public ToolTip tlTip;
            public string trangThai;
        }
        public class Tang
        {
            public List<Ban> Lban;
        }
        
        public List<Ban> LBan = new List<Ban>();
        public List<TabPage> Ltp = new List<TabPage>();
        public int i = 0;
        public void loadban()
        {
            TabPDSBan.Controls.Clear();
            QuanLyQuanAnEntities qlcf = new QuanLyQuanAnEntities();
            var LayKhuVuc = (from p in qlcf.KHUVUCs
                             select new
                             {
                                 p.TenKV,
                                 p.MaKV
                             }).ToList();

            foreach (var p in LayKhuVuc)
            {
                string leng = p.MaKV.Trim();
                TabPage tp = new TabPage(leng);
                Ltp.Add(tp);
                tp.Width = grctrlBan.Width -10;
                tp.Text = p.TenKV.Trim();
                tp.BackColor = Color.WhiteSmoke;
                tp.MouseHover += tp_MouseHover;
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var ban = from x in ql.BANs
                          join q in ql.KHUVUCs on x.MaKV equals q.MaKV
                          where q.TenKV == tp.Text
                          select new
                          {
                              x.MaBan,
                              x.TrangThai,
                              x.TenBan
                          };
                foreach (var a in ban)
                {
                    Ban B = new Ban();
                    LBan.Add(B);
                    LBan[i].A = new SimpleButton();
                    LBan[i].A.Size = new Size(50, 50);
                    LBan[i].A.BackColor = Color.Blue;
                    LBan[i].A.Name = a.MaBan.ToString();
                    LBan[i].A.ImageOptions.Location = ImageLocation.MiddleCenter;
                    LBan[i].A.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    LBan[i].A.AppearanceHovered.BackColor = Color.Gold;
                    LBan[i].A.AppearancePressed.BackColor = Color.Red;
                    //LBan[i].TrangThai = a.TrangThai.Trim();
                    if (a.TrangThai.Trim() == "0")
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.table;
                    else if (a.TrangThai.Trim()=="1")
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.dining;
                    else if (a.TrangThai.Trim() == "BT")
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtemp;
                    else
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.Ordered;



                    LBan[i].lblTenban = new Label();
                    LBan[i].lblTenban.Size = new Size(50, 20);
                    LBan[i].lblTenban.Text = a.MaBan.Trim();
                    LBan[i].lblTenban.BackColor = Color.WhiteSmoke;
                    LBan[i].lblTenban.Font = new Font(LBan[i].lblTenban.Font, FontStyle.Bold);
                    LBan[i].trangThai = a.TrangThai.Trim();
                    LBan[i].A.Click += A_Click;
                    tp.Controls.Add(LBan[i].A);
                    tp.Controls.Add(LBan[i].lblTenban);
                    if (i == temp)
                    {
                        LBan[i].A.Location = new Point(30, 5);
                    }
                    else
                    {
                        if (LBan[i - 1].A.Location.X + 150 > TabPDSBan.Width)
                            LBan[i].A.Location = new Point(30, LBan[i - 1].A.Location.Y + 80);
                        else
                        {
                            LBan[i].A.Location = new Point(LBan[i - 1].A.Location.X + 70, LBan[i - 1].A.Location.Y);
                        }

                    }
                    LBan[i].lblTenban.Location = new Point(LBan[i].A.Location.X, LBan[i].A.Location.Y + 50);
                    LBan[i].lblTenban.TextAlign = ContentAlignment.MiddleCenter;
                    i++;
                }
                temp += ban.Count();

                tp.Refresh();
                TabPDSBan.Controls.Add(tp);
            }


        }
        public void CapNhatBan(List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                var dsban = from ban in ql.BANs
                         select ban;
                foreach(var item in dsban)
                {
                    if(item.MaBan==B[i].A.Name)
                    {
                        if (item.TrangThai.Trim() == "0")
                            B[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.table;
                        else if (item.TrangThai.Trim() == "1")
                            B[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.dining;
                        else if(item.TrangThai.Trim() == "BT")
                            B[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtemp;
                        else
                            B[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.Ordered;
                    }
                }
            }
        }
        public void A_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton bt = sender as SimpleButton;
                BLXemThongTinBan BLXTB = new BLXemThongTinBan();
                BLChonMon BLCM = new BLChonMon();
                BLXTB.ThongTinBan(BLCM.LayMaHoaDon(bt.Name),dgvChiTietBan);
                DoiMauBan(bt,LBan);
                MaBanDangChon = bt.Name.Trim(); // Lấy mã để thực hiện các việc khác
                lblChonBan.Text =bt.Name.Trim();
                //
                grctrlChiTietBan.Text = "Danh sách món ăn mà Bàn " + bt.Name.ToString().Trim() + " đã đặt:";
                BLQuanLyBan blql = new BLQuanLyBan();
                string tt = blql.LayTrangThai(MaBanDangChon);
                btnChonMon.Enabled = true;
                if (tt.Trim() == "1" || tt.Trim() == "BT")
                {
                    btnChuyenBan.Enabled = true;
                    btnGopBan.Enabled = true;
                }
                else
                {
                    btnChuyenBan.Enabled = false;
                    btnGopBan.Enabled = false;
                }
               
                btnDatBan.Enabled = true;
                btnTraLai.Enabled = false;
                // Thong tint tong tien
                //jMtxtTongTien.TextName.ToString() = BLXTB.TinhTien(MaBanDangChon).ToString()+" VNĐ";
                gt = Double.Parse(BLXTB.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);

                // Lay Trang Thai De Show Len Label
                if (blql.LayTrangThai(MaBanDangChon)=="1" || blql.LayTrangThai(MaBanDangChon) == "0" || blql.LayTrangThai(MaBanDangChon).Trim() == "BT")
                {
                    lblThongTinKhachDatTruoc.Text = "Khách: KHÔNG CÓ THÔNG TIN";
                    btnKhachDen.Enabled = false;
                    if (blql.LayTrangThai(MaBanDangChon) == "1" || blql.LayTrangThai(MaBanDangChon).Trim() == "BT")
                    {
                        btnDatBan.Enabled = false;
                        btnHuyDat.Enabled = true;
                        btnThanhToan.Enabled = true;
                    }
                    else if (blql.LayTrangThai(MaBanDangChon) == "0")
                    {
                        btnDatBan.Enabled = true;
                        btnHuyDat.Enabled = false;
                        btnThanhToan.Enabled = false;
                    }
                    
                }
                else
                {
                    lblThongTinKhachDatTruoc.Text = "Khách: " + blql.LayTrangThai(MaBanDangChon);
                    btnHuyDat.Enabled = true;
                    btnDatBan.Enabled = false;
                    btnThanhToan.Enabled = false;
                    btnKhachDen.Enabled = true;
                }
                // Hien so thanh chữ
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);

            }
            catch
            {

            }
            
        }
        public void DoiMauBan(SimpleButton btnBan, List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (btnBan.Name == B[i].A.Name)
                {
                    B[i].A.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    B[i].lblTenban.BackColor = Color.Red;
                    B[i].lblTenban.ForeColor = Color.LightBlue;
                }
                else
                {
                    B[i].A.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    B[i].lblTenban.BackColor = Color.WhiteSmoke;
                    B[i].lblTenban.ForeColor = Color.Black;
                }
            }
        }
        
        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void XemThongTinBan_Load(object sender, EventArgs e)
        {
            try
            {
                btnHuyDat.Enabled = false;
                btnThanhToan.Enabled = false;
                btnKhachDen.Enabled = false;
                BLDS.DesignDgv(dgvChiTietBan);
                btnTraLai.Enabled = false;
                loadban();
            }

            catch
            {

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                frXuatBill frxb = new frXuatBill();
                frxb.TenBan = MaBanDangChon;
                frxb.BangSo = lblTongTien.Text.ToString();
                frxb.BangChu = lblBangChu.Text;
                frxb.TongTien = gt.ToString();
                frxb.TongTienBanDau = int.Parse(gt.ToString());
                frxb.MaHoaDon = BLCM.LayMaHoaDon(MaBanDangChon);
                frxb.ShowDialog();
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                BLXTT.CapNhatBan(LBan);
                this.Refresh();
            }
            catch
            {

            }
        }
        public void ReloadBan()
        { 
            try
            {
                BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                TabPDSBan.Controls.Clear();
                loadban();
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
                btnChonMon.Enabled = false;
                btnDatBan.Enabled = false;
                btnHuyDat.Enabled = false;
                btnTraLai.Enabled = false;
                lblTongTien.Text = "";
            }
            catch
            {

            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            
            loadban();
            BLTB.Show("Đã Tải Lại!");
            grctrlChiTietBan.Text ="Chi Tiết Hóa Đơn";
        }

        private void btnDoiTrangThai_Click(object sender, EventArgs e)
        {
            try
            {
                //BLXemThongTinBan BLXTT = new BLXemThongTinBan();
                //BLXTT.DoiTrangThai(MaBanDangChon);
                //ReloadBan();
                //btnChuyenBan.Enabled = false;
                //btnGopBan.Enabled = false;
                //btnDoiTrangThai.Enabled = false;
                frDatBan frorder = new frDatBan();
                frorder.MaBanDangChon = MaBanDangChon;
                frorder.ShowDialog();
                frorder.Hide();
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                BLXTT.CapNhatBan(LBan);
                btnTraLai.Enabled = false;

            }
            catch
            {

            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            try
            {
                frChuyenBan cb = new frChuyenBan();
                cb.MaBanCu = MaBanDangChon;
                cb.ShowDialog();
                cb.Hide();
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
                btnDatBan.Enabled = false;
                BLXTT.CapNhatBan(LBan);
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);
                btnTraLai.Enabled = false;
            }
            catch
            {
                CapNhatBan(LBan);
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            try
            {
                frGopBan gb = new frGopBan();
                gb.MaBanCu = MaBanDangChon;
                gb.ShowDialog();
                gb.Hide();
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                BLXTT.CapNhatBan(LBan);


                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
                btnDatBan.Enabled = false;

                gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);
                btnTraLai.Enabled = false;
            }
            catch
            {
                CapNhatBan(LBan);
            }
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            try
            {
                frChonMon dm = new frChonMon();
                dm.MaBanDangChon = this.MaBanDangChon;
                dm.MaNV = this.MaNV;
                dm.ShowDialog();
                dm.Close();
                BLXTT.CapNhatBan(LBan);
                //BLChonMon BLCM = new BLChonMon();
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon),dgvChiTietBan);

                gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);
                BLXTT.kiemTraThayDoi(lblChonBan.Text.Trim(), dgvChiTietBan);

            }
            catch
            {

            }
        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            BLChonMon BLCM = new BLChonMon();
            BLQuanLyBan BLQLB = new BLQuanLyBan();
            string trangThai = BLCM.LayTrangThai(MaBanDangChon);
            try
            {
                BLCM.CapNhatKhiHuy(BLCM.LayMaHoaDon(MaBanDangChon));
                BLCM.XoaPhieu(ref err, BLCM.LayMaHoaDon(MaBanDangChon));
                BLQLB.CapNhatBan(MaBanDangChon, "0", ref err);
                BLTB.Show("Bạn đã hủy bàn thành công!");
                BLXTT.CapNhatBan(LBan);
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);
            }
            catch
            {
                //BLCM.XoaPhieu(ref err, BLCM.LayMaHoaDon(MaBanDangChon));
                BLQLB.CapNhatBan(MaBanDangChon, "0", ref err);
                CapNhatBan(LBan);
            }
            
        }

        private void btnKhachDen_Click(object sender, EventArgs e)
        {
            BLQuanLyBan BLQLB = new BLQuanLyBan();
            BLQLB.CapNhatBan(MaBanDangChon, "1", ref err);
            BLXTT.CapNhatBan(LBan);
            BLTB.Show("Khách đã đến!");
        }

        private void btnTraLai_Click(object sender, EventArgs e)
        {
            try
            {
                frTraLai fr = new frTraLai();
                fr.MaBanDangChon = MaBanDangChon;
                fr.MaMonAn = MaMonAn;
                fr.TenMonAn = TenMonAn;
                fr.SL = SL;
                fr.ShowDialog();
                btnTraLai.Enabled = false;
                BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                lblBangChu.Text = "Bằng Chữ: " + BLXTT.So_chu(gt);
            }
            catch
            {

            }
        }

        private void dgvChiTietBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChiTietBan.CurrentCell.RowIndex;
            MaMonAn = dgvChiTietBan.Rows[r].Cells[0].Value.ToString();
            TenMonAn = dgvChiTietBan.Rows[r].Cells[1].Value.ToString();
            SL = dgvChiTietBan.Rows[r].Cells[2].Value.ToString();
            btnTraLai.Enabled = true;

        }

        private void dgvChiTietBan_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {           
        }

        private void frXemBan_MouseHover(object sender, EventArgs e)
        {
           
        }
        private void tp_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           try
            {
                BLXTT.CapNhatBan(LBan);
                if (lblChonBan.Text != "Chưa Chọn" && BLXTT.kiemTraThayDoi(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan) == 1)
                {
                    BLXTT.ThongTinBan(BLCM.LayMaHoaDon(MaBanDangChon), dgvChiTietBan);
                    gt = Double.Parse(BLXTT.TinhTien(MaBanDangChon, BLCM.LayMaHoaDon(MaBanDangChon)).ToString());
                    lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);
                }
            }
            catch
            {

            } 
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoiHinh_Tick(object sender, EventArgs e)
        {
            try
            {
                BLXTT.DoiHinhKhiBillTam(LBan);
                DoiHinh.Interval = 2500;
            }
            catch
            {

            }
        }

        private void AmThanh_Tick(object sender, EventArgs e)
        {
            try
            {

                AmThanh.Interval = 1;
                AmThanh.Start();
                if (BLXTT.checkListBan(LBan) == 1)
                {
                    BLXTT.playSound();
                    AmThanh.Interval = 6000;
                }
            }
            catch
            {

            }
        }
    }
}
