//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiaoDichChuyenTien
    {
        public string MaGD { get; set; }
        public string MaKHGoi { get; set; }
        public string MaKHNhan { get; set; }
        public decimal SoTien { get; set; }
        public string NoiDung { get; set; }
        public string MaNV { get; set; }
        public System.DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual KhachHang KhachHang1 { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
