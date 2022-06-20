using DevExpress.XtraTabbedMdi;
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
using System.Globalization;
using System.IO;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frHome : DevExpress.XtraEditors.XtraForm
    {
        public string Quyen { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string TenNV { get; set; }
        public string MaNV { get; set; }
        public string IP { get; set; }
        public double DoanhThu { get; set; }
        BLChotCa BLChot = new BLChotCa();
        BLThongBao BLTB = new BLThongBao();
        BLHome BLH = new BLHome();
        public frHome()
        {
            InitializeComponent();
        }
        

        private void btnQuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLNhanVien forms = new frQLNhanVien();
                Form frm = BLH.kiemtraform(typeof(frQLNhanVien), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TrangChu()
        {
            try
            {
                frXemBan forms = new frXemBan();
                Form frm = BLH.kiemtraform(typeof(frXemBan), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                    forms.MaNV = MaNV;
                }
                else
                {
                    frm.Activate();
                    forms.MaNV = MaNV;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            try
            {
                TrangChu();
                BLH.GiaoDienMacDinh();
                //MessageBox.Show(BLChot.LayChotCaGanNhat());
                barChotCa.Caption ="     Người Chốt Ca Gần Nhất: "+ BLChot.LayChotCaGanNhat();
                DoanhThu = (Double.Parse(BLChot.DoanhThu()));
                lblDoanhThuNgay.Caption = "Doanh Thu Trong Ngày: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", DoanhThu);
                barTaiKhoan.Caption = "Tên Tài Khoản: " + TenDN;
                barQuyen.Caption = "Quyền: " + Quyen.Trim();
                barTenNV.Caption = "Tên Nhân Viên: " + TenNV;
                strIP.Caption = "IP Server: " + IP;
                if(Quyen=="Nhân Viên")
                {
                    ribpageQuanLy.Visible = false;
                    ribpageThongKe.Visible = false;
                    btnCapQuyen.Enabled = false;
                }
                else
                {
                    ribpageQuanLy.Visible = true;
                    ribpageThongKe.Visible = true;
                    btnCapQuyen.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnQuanLyThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLThucDon forms = new frQLThucDon();
                Form frm = BLH.kiemtraform(typeof(frQLThucDon),this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch
            {
                
            }
        }

        private void btnQuanLyBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLBan forms = new frQLBan();
                Form frm = BLH.kiemtraform(typeof(frQLBan), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuanLyLoaiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLLoaiMon forms = new frQLLoaiMon();
                Form frm = BLH.kiemtraform(typeof(frQLLoaiMon), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barbtnTrangChu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrangChu();
        }

        private void btnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frRPDoanhThu f = new frRPDoanhThu();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();

        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frDoiMK dmk = new frDoiMK();
                dmk.TenDN = this.TenDN;
                dmk.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLTaiKhoan forms = new frQLTaiKhoan();
                forms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frChamCong forms = new frChamCong();
                Form frm = BLH.kiemtraform(typeof(frChamCong), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {

        }
        
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frRPLuong forms = new frRPLuong();
                forms.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQLNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLNguyenLieu forms = new frQLNguyenLieu();
                Form frm = BLH.kiemtraform(typeof(frQLNguyenLieu), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuanLyKV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frQLKhuVuc forms = new frQLKhuVuc();
                Form frm = BLH.kiemtraform(typeof(frQLKhuVuc), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barStaticItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DoanhThu = (Double.Parse(BLChot.DoanhThu()));
                //BLChotCa BLChot = new BLChotCa();
                BLChot.ThemChot(DateTime.Now, BLChot.LayMax().ToString(), int.Parse(DoanhThu.ToString()), MaNV);
                //BLChot.XoaHetDoanhThu();
                barChotCa.Caption = "     Người Chốt Ca Gần Nhất: "+ BLChot.LayChotCaGanNhat();
                //DoanhThu = (Double.Parse(BLChot.DoanhThu()) + Double.Parse(BLChot.DoanhThuChotCa()));
                lblDoanhThuNgay.Caption = "Doanh Thu Trong Ngày: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", DoanhThu);

                BLTB.Show("Chốt ca thành công! Phải bàn giao " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", DoanhThu) + " cho nhân viên ca tiếp theo!");
            }
            catch {  }
        }

       

        private void ribbonControl1_MouseHover(object sender, EventArgs e)
        {
            DoanhThu = (Double.Parse(BLChot.DoanhThu()));
            lblDoanhThuNgay.Caption = "Doanh Thu Trong Ngày: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", DoanhThu);
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void frHome_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void timerChotCa_Tick(object sender, EventArgs e)
        {
            DoanhThu = (Double.Parse(BLChot.DoanhThu()));
            lblDoanhThuNgay.Caption = "Doanh Thu Trong Ngày: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", DoanhThu);
        }

        private void btnKhachVaNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrQLKhach forms = new FrQLKhach();
                Form frm = BLH.kiemtraform(typeof(FrQLKhach), this);
                if (frm == null)
                {
                    forms.MdiParent = this;
                    forms.Show();
                }
                else
                {
                    frm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            
        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BLDangNhap BLDN = new BLDangNhap();

            if (barToggleSwitchItem1.Checked == true)
            {
                if (File.Exists(@"E:\DATNN\DATN\Winform\server.bat"))
                {
                    BLDN.startServer(@"E:\DATNN\DATN\Winform\server.bat");
                }
                else
                {
                    MessageBox.Show("Không có file start server !!");
                }
            }
            else
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM cmd.exe /T");
            }
        }
    }
}
