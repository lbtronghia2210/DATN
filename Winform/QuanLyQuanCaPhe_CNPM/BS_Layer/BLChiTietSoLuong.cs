using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    class BLChiTietSoLuong
    {
        public void LayChiTiet(DataGridView dgvChiTietSoLuong, string maMon)
        {
            QuanLyQuanAnEntities qlcfEntities = new QuanLyQuanAnEntities();
            var chitiet = from p in qlcfEntities.THUCDONs
                          join q in qlcfEntities.CONGTHUCs
                          on p.MaMon equals q.MaMon
                          where p.MaMon ==maMon
                          select new
                          {
                              p.MaMon, p.TenMon, q.MaNL
                          };
            var chitiet2 = from p in chitiet
                           join q in qlcfEntities.NGUYENLIEUx
                           on p.MaNL equals q.MaNL
                           where p.MaMon == maMon
                           select new
                           {
                               q.MaNL,
                               q.TenNL,
                               q.DVT,
                               q.SoLuong
                              
                           };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NL");
            dt.Columns.Add("Tên NL");
            dt.Columns.Add("Đơn Vị");
            dt.Columns.Add("Số Lượng Còn");
            dt.Columns.Add("Trình Trạng");
            foreach (var p in chitiet2)
            {
                string tinhTrang = "";
                if(p.DVT.Trim().ToLower()!="gram")
                {
                    if (p.SoLuong == 0)
                        tinhTrang = "Hết sạch";
                    else if (p.SoLuong > 0 && p.SoLuong <= 30)
                        tinhTrang = "Sắp hết";
                    else
                        tinhTrang = "Ổn";
                }
                else
                {
                    if (p.SoLuong == 0)
                        tinhTrang = "Hết sạch";
                    else if (p.SoLuong > 1 && p.SoLuong <= 1500)
                        tinhTrang = "Sắp hết";
                    else
                        tinhTrang = "Ổn";
                }
                
                dt.Rows.Add(p.MaNL.Trim(),p.TenNL.Trim(),p.DVT.Trim(),p.SoLuong,tinhTrang);
            }
            dgvChiTietSoLuong.DataSource = dt;
            dgvChiTietSoLuong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            dgvChiTietSoLuong.DefaultCellStyle.Font = new Font("Tahoma", 9f);
            dgvChiTietSoLuong.RowHeadersVisible = false;
            dgvChiTietSoLuong.AllowUserToAddRows = false;
        }
    }
}
