using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyQuanCaPhe_CNPM.BS_Layer;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frGopBan : DevExpress.XtraEditors.XtraForm
    {
        public string MaNV { get; set; }
        public string MaBanCu { get; set; }
        public string MaBanCanGop { get; set; }
        int temp = 0;
        BLGopBan BLGB = new BLGopBan();
        BLQuanLyBan BLB = new BLQuanLyBan();
        BLThongBao BLTB = new BLThongBao();
        public frGopBan()
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
                tp.BackColor = Color.White;
                
                    QuanLyQuanAnEntities ql = new QuanLyQuanAnEntities();
                    var ban = from x in ql.BANs
                              join q in ql.KHUVUCs on x.MaKV equals q.MaKV
                              where q.TenKV == tp.Text && x.MaBan!=MaBanCu && x.TrangThai.Trim() =="1"
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
                    LBan[i].A.AppearancePressed.BackColor = Color.Yellow;
                    LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.dining;
                    LBan[i].lblTenban = new Label();
                    LBan[i].lblTenban.Size = new Size(50, 20);
                    LBan[i].lblTenban.Text = a.MaBan.Trim();
                    LBan[i].lblTenban.Name = "lbl" + LBan[i].A.Name.Trim();// Quan Ly Label
                    LBan[i].lblTenban.BackColor = Color.White;
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
                        if (LBan[i - 1].A.Location.X + 150 > tp.Width) LBan[i].A.Location = new Point(40, LBan[i - 1].A.Location.Y + 110);
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

                btnThem.Enabled = true;
                //MaBanMoi = bt.Name.Trim();
                MaBanCanGop = bt.Name.Trim();
                BLQuanLyBan BLB = new BLQuanLyBan();
                //BLB.LayBan(MaBanMoi, txtMaBanMoi, txtTenBanMoi, txtSoChoNgoi, txtMaKV, txtTenKVmoi, txtTrangThai);
                //Xuly giao dien
                DoiMauBan(bt, LBan);
                //AnBan(bt, LBan);
                TestDS();
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
                    btnBan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                }
                else
                    B[i].A.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        } // Doi mau ban
        public void AnBan(string MaBan, List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (MaBan.Trim() == B[i].A.Name.Trim())
                {
                    B[i].A.Visible = false;
                    B[i].lblTenban.Visible = false;
                }
            }
        } // An ban di
        public void HienBan(string MaBan, List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (MaBan.Trim() == B[i].A.Name.Trim())
                {
                    B[i].A.Visible = true;
                    B[i].lblTenban.Visible = true;
                }
            }
        } //Hien ban len
        public void XoaItem()
        {
            string str = lstBanCanGop.SelectedItem.ToString();
            lstBanCanGop.Items.RemoveAt(lstBanCanGop.SelectedIndices[0]);
            HienBan(str.Trim(), LBan);
            btnXoa.Enabled = false;
        } //Xoa ban khoi danh sach
        private void GopBan_Load(object sender, EventArgs e)
        {
            try
            {
              
                BLGB.LayBanCu(MaBanCu, txtMaBanCu, txtTenBanCu, txtTenKVcu);
                loadData();
                TestDS();
            }
            catch
            {

            }
        }
        public void TestDS() //Kiem tra xem de hien nut Gop ban
        {
            if (lstBanCanGop.Items.Count != 0)
                btnGopBan.Enabled = true;
            else
                btnGopBan.Enabled = false;
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                try
                {
                    BLChuyenBan BLCB = new BLChuyenBan();
                    BLChonMon BLCM = new BLChonMon();
                    foreach (var i in lstBanCanGop.Items)
                    {
                        str += i.ToString().Trim()+",";
                        BLCB.ChuyenBan(i.ToString().Trim(), BLCM.LayMaHoaDon(i.ToString().Trim()), txtMaBanCu.Text.Trim(), BLCM.LayMaHoaDon(txtMaBanCu.Text.Trim()));
                    }
                    BLTB.Show("Gộp thành công bàn "+str+" sang bàn "+txtMaBanCu.Text.ToString());
                    this.Close();
                }
                catch
                {
                    //BLChuyenBan BLCB = new BLChuyenBan();
                    //foreach (var i in lstBanCanGop.Items)
                    //{
                    //    str += i.ToString().Trim() + ",";
                    //    //BLCB.ChuyenBan(i.ToString().Trim(), txtMaBanCu.Text.Trim());
                    //}
                    //BLTB.Show("Gộp thành công bàn " + str + " sang bàn " + txtMaBanCu.Text.ToString());
                    //this.Close();
                }
            }
            catch
            { 

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                AnBan(MaBanCanGop, LBan);
                lstBanCanGop.Items.Add(MaBanCanGop);
                TestDS();
                btnThem.Enabled = false;
            }
            catch
            {
                BLTB.Show("Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaItem();
            TestDS();
        }

        private void lstBanCanGop_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
