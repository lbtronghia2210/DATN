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
    public partial class frQLBan : Form
    {
        public string MaBanDangChon { get; set; }

        public frQLBan()
        {
            InitializeComponent();
        }
        bool Them = false;
        string err;
        int temp = 0;
        BLQuanLyBan BLB = new BLQuanLyBan();
        BLThongBao BLTB = new BLThongBao();
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
                    else if (a.TrangThai.Trim() == "BT")
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.billtemp;
                    else
                        this.LBan[i].A.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.Ordered;



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
                        LBan[i].A.Location = new Point(33, 5);
                    }
                    else
                    {
                        if (LBan[i - 1].A.Location.X + 150 > tp.Width)
                            LBan[i].A.Location = new Point(33, LBan[i - 1].A.Location.Y + 110);
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
            this.txtMaBan.ResetText();
            this.txtMaKV.ResetText();
            this.txtSoChoNgoi.ResetText();
            this.cmbTrangThai.ResetText();
            this.txtTenBan.ResetText();
            this.cmbTenKV.ResetText();

            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
        }
        private void A_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton bt = sender as SimpleButton;
                BLXemThongTinBan BLXTB = new BLXemThongTinBan();
                //DataTable dt = BLXTB.ThongTinBan(bt.Name);
                MaBanDangChon = bt.Name.Trim();
                BLQuanLyBan BLB = new BLQuanLyBan();
                DoiMauBan(bt, LBan);
                BLB.LayBan(MaBanDangChon, txtMaBan, txtTenBan, txtSoChoNgoi, txtMaKV, cmbTenKV, cmbTrangThai);
                //Xuly giao dien
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.grctrlThongTin.Enabled = false;
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
        private void QLBan_Load(object sender, EventArgs e)
        {
            try
            {
                loadData();
                BLB.LayTenKhuVuc(cmbTenKV);
            }
            catch { }
        }

        private void cmbTenKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLB.LayMaKV(cmbTenKV, txtMaKV);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them = true;
                this.txtMaBan.ResetText();
                this.txtMaKV.ResetText();
                this.txtSoChoNgoi.ResetText();
                this.cmbTrangThai.ResetText();
                this.txtTenBan.ResetText();
                this.cmbTenKV.ResetText();

                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                this.grctrlThongTin.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.txtMaBan.Enabled = true;
                this.txtMaBan.Text = BLB.TaoMaBan();
                this.txtMaBan.Focus();
                this.cmbTenKV.Text = TabPDSBan.SelectedTab.Text;


            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string trangthai = "";
            if (cmbTrangThai.Text == "Đã Có Khách")
                trangthai = "1";
            else
                trangthai = "0";
            if (Them)
            {
                try
                {
                    BLQuanLyBan BLB = new BLQuanLyBan();
                    BLB.ThemBan(this.txtMaBan.Text, this.txtTenBan.Text, int.Parse(this.txtSoChoNgoi.Text), this.txtMaKV.Text, trangthai, ref err);
                    loadData();
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
                    if(txtMaBan.Text=="")
                    {
                        BLTB.Show("Không xác định được Mã Bàn");
                    }
                    else
                    {
                        BLQuanLyBan BLB = new BLQuanLyBan();
                        BLB.CapNhatBan(this.txtMaBan.Text, this.txtTenBan.Text, int.Parse(this.txtSoChoNgoi.Text), this.txtMaKV.Text, trangthai, ref err);
                        loadData();
                        // Thông báo
                        BLTB.Show("Đã sửa xong!");
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    BLB.XoaBan(ref err, txtMaBan.Text);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.grctrlThongTin.Enabled = true;
           

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
        

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaBan.Enabled = false;
            this.txtTenBan.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaBan.ResetText();
            this.txtMaKV.ResetText();
            this.txtSoChoNgoi.ResetText();
            this.cmbTrangThai.ResetText();
            this.txtTenBan.ResetText();
            this.cmbTenKV.ResetText();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlThongTin.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TabPDSBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
