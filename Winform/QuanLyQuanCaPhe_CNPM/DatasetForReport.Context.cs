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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyQuanCaPheEntities2 : DbContext
    {
        public QuanLyQuanCaPheEntities2()
            : base("name=QuanLyQuanCaPheEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        //public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<TINHLUONG> TINHLUONGs { get; set; }
    }
}
