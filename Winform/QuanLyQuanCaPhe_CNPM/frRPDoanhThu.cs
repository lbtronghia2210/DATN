using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraReports.UI;
using QuanLyQuanCaPhe_CNPM.BS_Layer;
using System.Globalization;
using System.IO;

namespace QuanLyQuanCaPhe_CNPM
{
    public partial class frRPDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        public frRPDoanhThu()
        {
            InitializeComponent();
        }
        public string MaHoaDon {get;set;}
        public string VAT { get; set; }
        public string TongTien { get; set; }
        public string temp { get; set; }
        BLDoanhThu BLDT = new BLDoanhThu();
        BLThongBao BLTB = new BLThongBao();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReportDoanhThu rp = new ReportDoanhThu();
            rp.TongDoanhThu = lblTongDoanhThu.Text;
            rp.TieuDe = lblTieuDe.Text;
           
            if (cmbLuaChon.Text=="Hôm Nay")
            {
                rp.DataSource = BLDT.XuatDoanhThuTheoNgay();
            }
            if (cmbLuaChon.Text == "Tuần Này")
            {
                rp.DataSource = BLDT.XuatDoanhThuTrongTuan();
            }
            if (cmbLuaChon.Text=="Tháng Này")
            {
                rp.DataSource = BLDT.XuatDoanhThuTrongThang();
            }
            if(cmbLuaChon.Text=="Khoảng Thời Gian")
            {
                if (dateeditFr.Text != "" && dateeditTo.Text != "")
                {
                    rp.DataSource = BLDT.XuatDoanhThuTrongKhoang(DateTime.Parse(dateeditFr.Text), DateTime.Parse(dateeditTo.Text));
                }
                    
                else
                    BLTB.Show("Phải Chọn Khoảng Thời Gian!");
            }
            string rpPath = "DoanhThu\\" + "DoanhThu"+BLDT.layTemp()+".pdf";
            if (File.Exists(rpPath))
            {
                File.Delete(rpPath);
                rp.ExportToPdf(rpPath);
                System.Diagnostics.Process.Start(rpPath);
            }
            else
            {
                rp.ExportToPdf(rpPath);
                System.Diagnostics.Process.Start(rpPath);
            }
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            BLDesign BLDS = new BLDesign();
            BLDS.DesignDgv(dgvDoanhThu);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLuaChon.Text == "Hôm Nay")
                {
                    BLDT.LayDoanhThuTrongNgay(dgvDoanhThu, lblTongSoHD, lblTongDoanhThu);
                    grKhoangThoiGian.Enabled = false;
                    lblTieuDe.Text = "Thống Kê Doanh Thu Ngày " + DateTime.Now.Date.ToString().Substring(0, 10);

                    if (dgvDoanhThu.Rows.Count >= 1)
                    {
                        btnXemLai.Enabled = true;
                    }
                    else
                    {
                        btnXemLai.Enabled = false;
                        lblHD.Text = "";
                    }
                    dgvDoanhThu.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
                }
                if (cmbLuaChon.Text == "Tháng Này")
                {
                    BLDT.LayDoanhThuTrongThang(dgvDoanhThu, lblTongSoHD, lblTongDoanhThu);
                    grKhoangThoiGian.Enabled = false;
                    lblTieuDe.Text = "Thống Kê Doanh Thu Tháng " + DateTime.Now.Month.ToString()+" Năm " + DateTime.Now.Year.ToString();

                    if (dgvDoanhThu.Rows.Count >= 1)
                    {
                        btnXemLai.Enabled = true;
                    }
                    else
                    {
                        btnXemLai.Enabled = false;
                        lblHD.Text = "";
                    }
                    dgvDoanhThu.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
                }
                if (cmbLuaChon.Text == "Tuần Này")
                {
                    BLDT.LayDoanhThuTrongTuan(dgvDoanhThu, lblTongSoHD, lblTongDoanhThu);
                    grKhoangThoiGian.Enabled = false;
                    lblTieuDe.Text = "Thống Kê Doanh Thu Tuần Này. Từ Ngày " + BLDT.FirstDayOfWeek(DateTime.Now).ToString().Substring(0,10) + " Đến Ngày " + DateTime.Now.ToString().Substring(0,10);

                    if (dgvDoanhThu.Rows.Count >= 1)
                    {
                        btnXemLai.Enabled = true;
                    }
                    else
                    {
                        btnXemLai.Enabled = false;
                        lblHD.Text = "";
                    }
                    dgvDoanhThu.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
                }
                if (cmbLuaChon.Text == "Khoảng Thời Gian")
                {
                    grKhoangThoiGian.Enabled = true;
                    BLDT.LayDoanhThuTrongKhoang(dgvDoanhThu, DateTime.Parse(dateeditFr.Text), DateTime.Parse(dateeditTo.Text), lblTongSoHD, lblTongDoanhThu);
                    lblTieuDe.Text = "Thống Kê Doanh Thu Từ Ngày " + dateeditFr.Text + " Đến Ngày " + dateeditTo.Text;

                    if (dgvDoanhThu.Rows.Count >= 1)
                    {
                        btnXemLai.Enabled = true;
                    }
                    else
                    {
                        btnXemLai.Enabled = false;
                        lblHD.Text = "";
                    }
                    dgvDoanhThu.Columns[3].DefaultCellStyle.Format = "0,##0 VNĐ";
                }
                dgvDoanhThu_CellClick(null, null);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvDoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                int r = dgvDoanhThu.CurrentCell.RowIndex;
                MaHoaDon = dgvDoanhThu.Rows[r].Cells[0].Value.ToString();
                lblHD.Text = "HD " + MaHoaDon;
                VAT = dgvDoanhThu.Rows[r].Cells[3].Value.ToString();
                TongTien = dgvDoanhThu.Rows[r].Cells[4].Value.ToString();
                //textBox1.Text =dgvDoanhThu.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnXemLai_Click(object sender, EventArgs e)
        {
            try
            {
                ReportHoaDon rp = new ReportHoaDon();
                string rpPath = "HoaDonDaXuat\\" + "HD " + MaHoaDon.Trim() + ".pdf";
                if (File.Exists(rpPath))
                {
                    System.Diagnostics.Process.Start(rpPath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                }
            }
            catch
            {
                MessageBox.Show("Không xem được!");
            }
        }
    }
}
