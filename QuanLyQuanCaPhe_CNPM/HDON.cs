//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyQuanCaPhe_CNPM
{
    using System;
    using System.Collections.Generic;
    
    public partial class HDON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDON()
        {
            this.CHITIETHDONs = new HashSet<CHITIETHDON>();
        }
    
        public string MaHoaDon { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string MaBan { get; set; }
        public string MaNV { get; set; }
        public string VAT { get; set; }
        public string MaKH { get; set; }
        public int TongTien { get; set; }
    
        public virtual BAN BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHDON> CHITIETHDONs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}