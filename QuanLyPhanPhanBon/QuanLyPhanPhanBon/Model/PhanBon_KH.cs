//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhanPhanBon.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanBon_KH
    {
        public int IDPhanBon { get; set; }
        public int IDKhachHang { get; set; }
        public int STT { get; set; }
        public int SoLuong { get; set; }
        public System.DateTime NgayBan { get; set; }
        public string KhuyenMai { get; set; }
        public decimal Gia { get; set; }
        public string TenPhanBon { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual KhuyenMai KhuyenMai1 { get; set; }
        public virtual PhanBon PhanBon { get; set; }
    }
}
