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
    
    public partial class TAIKHOAN
    {
        public string MaNV { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string MaLoaiTK { get; set; }
        public string TrangThai { get; set; }
    
        public virtual LOAITAIKHOAN LOAITAIKHOAN { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}