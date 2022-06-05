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

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frChuyenBan : DevExpress.XtraEditors.XtraForm
    {
        public string MaBanCu { get; set; }
        public string MaBanMoi { get; set; }
        public string MaNV { get; set; }
        int temp = 0;
        BLChuyenBan BLCB = new BLChuyenBan();
        BLQuanLyBan BLB = new BLQuanLyBan();
        BLThongBao BLTB = new BLThongBao();
        BLChonMon BLCM = new BLChonMon();
        public frChuyenBan()
        {
            InitializeComponent();
        }
        public class Ban
        {
            public int TrangThai = 0;
            public SimpleButton A;
            public Label lblTenban;
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
            BLB.XoaHet(TabPDSBan);
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
                tp.Width = TabPDSBan.Width;
                tp.Text = p.TenKV.Trim();
                tp.BackColor = Color.WhiteSmoke;
                
                    QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                    var ban = from x in ql.BANs
                              join q in ql.KHUVUCs on x.MaKV equals q.MaKV
                              where q.TenKV == tp.Text && x.SoChoNgoi >= numKhachThucTe.Value && x.MaBan!=MaBanCu &&  x.TrangThai=="0"
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
                        LBan[i].A.Size = new Size(70, 70);
                        LBan[i].A.BackColor = Color.Blue;
                        LBan[i].A.Name = a.MaBan.ToString();
                        LBan[i].A.ImageOptions.Location = ImageLocation.MiddleCenter;
                        LBan[i].A.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        LBan[i].A.AppearanceHovered.BackColor = Color.Gold;
                        LBan[i].A.AppearancePressed.BackColor = Color.Yellow;
                        if (a.TrangThai.Trim() == "0")
                            this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.table;
                        else if (a.TrangThai.Trim() == "1")
                            this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.dining;
                        else
                            this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.Odered;



                        LBan[i].lblTenban = new Label();
                        LBan[i].lblTenban.Size = new Size(70, 20);
                        LBan[i].lblTenban.Text = a.MaBan.Trim();
                        LBan[i].lblTenban.BackColor = Color.WhiteSmoke;
                        LBan[i].lblTenban.Font = new Font(LBan[i].lblTenban.Font, FontStyle.Bold);
                        LBan[i].A.Click += A_Click;
                        tp.Controls.Add(LBan[i].A);
                        tp.Controls.Add(LBan[i].lblTenban);
                        if (i == temp)
                        {
                            LBan[i].A.Location = new Point(40, 5);
                        }
                        else
                        {
                            if (LBan[i - 1].A.Location.X + 160 > tp.Width) LBan[i].A.Location = new Point(40, LBan[i - 1].A.Location.Y + 110);
                            else
                            {
                                LBan[i].A.Location = new Point(LBan[i - 1].A.Location.X + 80, LBan[i - 1].A.Location.Y);
                            }

                        }
                        LBan[i].lblTenban.Location = new Point(LBan[i].A.Location.X, LBan[i].A.Location.Y + 70);
                        LBan[i].lblTenban.TextAlign = ContentAlignment.MiddleCenter;
                        i++;
                    }
                    temp += ban.Count();
                
                tp.Refresh();
                TabPDSBan.Controls.Add(tp);
            }
        }
        public void loadData()
        {
            loadban();
        }
        private void A_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton bt = sender as SimpleButton;
                BLXemThongTinBan BLXTB = new BLXemThongTinBan();
                //DataTable dt = BLXTB.ThongTinBan(bt.Name);
                MaBanMoi = bt.Name.Trim();
                DoiMauBan(bt, LBan);
                BLQuanLyBan BLB = new BLQuanLyBan();

                BLB.LayBan(MaBanMoi, txtMaBanMoi, txtTenBanMoi, txtSoChoNgoi, txtMaKV, txtTenKVmoi, txtTrangThai);
                //Xuly giao dien
                
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

        private void ChuyenBan_Load(object sender, EventArgs e)
        {
            try
            {
                BLCB.LayBanCu(MaBanCu, txtMaBanCu, txtTenBanCu, txtTenKVcu);
                loadData();
            }
            catch
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BLCB.ChuyenBan(txtMaBanCu.Text.Trim(),BLCM.LayMaHoaDon(txtMaBanCu.Text.Trim()), txtMaBanMoi.Text.Trim(), BLCM.LayMaHoaDon(txtMaBanMoi.Text.Trim()));
                BLTB.Show("Đã chuyển bàn " + txtMaBanCu.Text.Trim() + " sang bàn " + txtMaBanMoi.Text.Trim() + " thành công!");
                this.Hide();
            }
            catch
            {
                this.Hide();
            }
        }

        private void numKhachThucTe_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadban();
            }
            catch
            {

            }
        }
    }
}
